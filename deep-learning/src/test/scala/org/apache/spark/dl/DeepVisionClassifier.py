# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.

from lib2to3.pytree import convert
from multiprocessing.sharedctypes import Value
import sys

import torchvision.transforms as transforms
from horovod.spark.common.backend import SparkBackend
import horovod.spark.common.store as hstore
from horovod.spark.lightning import TorchEstimator
from PIL import Image
from pyspark.context import SparkContext
from pyspark.ml.param.shared import Param, Params
from lightning_utilities.core.imports import module_available
# from synapse.ml.dl.DeepVisionModel import DeepVisionModel
# from synapse.ml.dl.LitDeepVisionModel import LitDeepVisionModel
# from synapse.ml.dl.utils import keywords_catch
# from synapse.ml.dl.PredictionParams import PredictionParams
from PredictionParams import PredictionParams
from DeepVisionModel import DeepVisionModel
from LitDeepVisionModel import LitDeepVisionModel
from GatewayUtils import GatewayUtils
from utils import keywords_catch, generate_uuid
# from PythonEntryPoint import python_entry_point

from py4j.clientserver import ClientServer, JavaParameters, PythonParameters

_HOROVOD_AVAILABLE = module_available("horovod")
if _HOROVOD_AVAILABLE:
    import horovod

    _HOROVOD_EQUAL_0_25_0 = horovod.__version__ == "0.25.0"
    if not _HOROVOD_EQUAL_0_25_0:
        raise RuntimeError(
            "horovod should be of version 0.25.0, found: {}".format(horovod.__version__)
        )
else:
    raise ModuleNotFoundError("module not found: horovod")

class DeepVisionClassifier(TorchEstimator, PredictionParams):

    backbone = Param(
        Params._dummy(), "backbone", "backbone of the deep vision classifier"
    )

    additional_layers_to_train = Param(
        Params._dummy(),
        "additional_layers_to_train",
        "number of last layers to fine tune for the model, should be between 0 and 3",
    )

    num_classes = Param(Params._dummy(), "num_classes", "number of target classes")

    loss_name = Param(
        Params._dummy(),
        "loss_name",
        "string representation of torch.nn.functional loss function for the underlying pytorch_lightning model, e.g. binary_cross_entropy",
    )

    optimizer_name = Param(
        Params._dummy(),
        "optimizer_name",
        "string representation of optimizer function for the underlying pytorch_lightning model",
    )

    dropout_aux = Param(
        Params._dummy(),
        "dropout_aux",
        "numeric value that's applied to googlenet InceptionAux module's dropout layer only: probability of an element to be zeroed",
    )

    transform_fn = Param(
        Params._dummy(),
        "transform_fn",
        "A composition of transforms used to transform and augnment the input image, should be of type torchvision.transforms.Compose",
    )

    store_param = Param(
        Params._dummy(),
        "store_param",
        "A string representation of the store for horovod training",
    )

    store_prefix_path = Param(
        Params._dummy(),
        "store_prefix_path",
        "Prefix path used for store_param, should only be used when you use store_param instead of store",
    )

    @keywords_catch
    def __init__(
            self,
            backbone=None,
            additional_layers_to_train=0,
            num_classes=None,
            optimizer_name="adam",
            loss_name="cross_entropy",
            dropout_aux=0.7,
            transform_fn=None,
            # Classifier args
            label_col="label",
            image_col="image",
            prediction_col="prediction",
            # TorchEstimator args
            num_proc=None,
            backend=None,
            store=None,
            metrics=None,
            loss_weights=None,
            sample_weight_col=None,
            gradient_compression=None,
            input_shapes=None,
            validation=None,
            callbacks=None,
            batch_size=None,
            val_batch_size=None,
            epochs=None,
            verbose=1,
            random_seed=None,
            shuffle_buffer_size=None,
            partitions_per_process=None,
            run_id=None,
            train_minibatch_fn=None,
            train_steps_per_epoch=None,
            validation_steps_per_epoch=None,
            transformation_fn=None,
            train_reader_num_workers=None,
            trainer_args=None,
            val_reader_num_workers=None,
            reader_pool_type=None,
            label_shapes=None,
            inmemory_cache_all=False,
            num_gpus=None,
            logger=None,
            log_every_n_steps=50,
            data_module=None,
            loader_num_epochs=None,
            terminate_on_nan=False,
            profiler=None,
            debug_data_loader=False,
            train_async_data_loader_queue_size=None,
            val_async_data_loader_queue_size=None,
            use_gpu=True,
            mp_start_method=None,
    ):
        super(DeepVisionClassifier, self).__init__()

        self._setDefault(
            backbone=None,
            additional_layers_to_train=0,
            num_classes=None,
            optimizer_name="adam",
            loss_name="cross_entropy",
            dropout_aux=0.7,
            transform_fn=None,
            feature_cols=["image"],
            label_cols=["label"],
            label_col="label",
            image_col="image",
            prediction_col="prediction",
        )

        kwargs = self._kwargs
        self._set(**kwargs)

    def setBackbone(self, value):
        return self._set(backbone=value)

    def getBackbone(self):
        return self.getOrDefault(self.backbone)

    def setAdditionalLayersToTrain(self, value):
        return self._set(additional_layers_to_train=value)

    def getAdditionalLayersToTrain(self):
        return self.getOrDefault(self.additional_layers_to_train)

    def setNumClasses(self, value):
        return self._set(num_classes=value)

    def getNumClasses(self):
        return self.getOrDefault(self.num_classes)

    def setLossName(self, value):
        return self._set(loss_name=value)

    def getLossName(self):
        return self.getOrDefault(self.loss_name)

    def setOptimizerName(self, value):
        return self._set(optimizer_name=value)

    def getOptimizerName(self):
        return self.getOrDefault(self.optimizer_name)

    def setDropoutAUX(self, value):
        return self._set(dropout_aux=value)

    def getDropoutAUX(self):
        return self.getOrDefault(self.dropout_aux)

    def setTransformFn(self, value):
        return self._set(transform_fn=value)

    def getTransformFn(self):
        return self.getOrDefault(self.transform_fn)
    
    def setStoreParam(self, value):
        if self.getStore() is not None:
            raise ValueError("Only one of store and storeParam can be set, storeParam is the string representation of store")
        valid_stores = ("LocalStore", "HDFSStore", "DBFSLocalStore")
        if value not in valid_stores:
            raise ValueError(f"StoreParam should be one of {valid_stores}, received: {value}")
        return self._set(store_param=value)
    
    def getStoreParam(self):
        return self.getOrDefault(self.store_param)
    
    def setStorePrefixPath(self, value):
        if self.getStore() is not None:
            raise ValueError("No need to set storePrefixPath if you use store instead of storeParam")
        return self._set(store_prefix_path=value)
    
    def getStorePrefixPath(self):
        return self.getOrDefault(self.store_prefix_path)

    def _update_input_shapes(self):
        if self.getInputShapes() is None:
            if self.getBackbone().startswith("inception"):
                self.setInputShapes([[-1, 3, 299, 299]])
            else:
                self.setInputShapes([[-1, 3, 224, 224]])

    def _update_cols(self):
        self.setFeatureCols([self.getImageCol()])
        self.setLabelCols([self.getLabelCol()])
    
    def _update_store(self):
        if self.getStore() is None:
            if self.getStoreParam() is None:
                raise ValueError(f"At least one of store and storeParam needs to be set")
            if self.getStorePrefixPath() is None:
                raise ValueError(f"PrefixPath of {self.getStoreParam()} is not set")
            constructed_store = hstore.__dict__[self.getStoreParam()](prefix_path=self.getStorePrefixPath())
            self.setStore(constructed_store)
    
    def _fit_on_parquet(self, dataset_idx=None):
        self._update_store()
        return super()._fit_on_parquet(dataset_idx)

    def _fit(self, dataset):
        from pyspark.ml.common import _py2java, _java2py
        from pyspark.sql.session import SparkSession
        import logging

        sparkContext = self._get_active_spark_context()

        logging.warning(f"Active Spark Session: {SparkSession.getActiveSession()}")
        dataset = _java2py(sparkContext, dataset)
        logging.warning(f"dataset type: {type(dataset)}")

        self._update_input_shapes()
        self._update_cols()
        self._update_transformation_fn()
        self._update_store()
        
        model = LitDeepVisionModel(
            backbone=self.getBackbone(),
            additional_layers_to_train=self.getAdditionalLayersToTrain(),
            num_classes=self.getNumClasses(),
            input_shape=self.getInputShapes()[0],
            optimizer_name=self.getOptimizerName(),
            loss_name=self.getLossName(),
            label_col=self.getLabelCol(),
            image_col=self.getImageCol(),
            dropout_aux=self.getDropoutAUX(),
        )
        self._set(model=model)

        logging.warning(f"model created: {model}")
        deepVisionModel = super()._fit(dataset)
        logging.warning(f"-------fit completion: {deepVisionModel}")
        # Set python_entry_point to global variable
        # global python_entry_point
        uid = generate_uuid("DeepVisionModel")
        # python_entry_point.addObject(uid, deepVisionModel)
        return uid, deepVisionModel

    # override this method to provide a correct default backend
    def _get_or_create_backend(self):
        backend = self.getBackend()
        num_proc = self.getNumProc()
        if backend is None:
            if num_proc is None:
                num_proc = self._find_num_proc()
            backend = SparkBackend(
                num_proc,
                stdout=sys.stdout,
                stderr=sys.stderr,
                prefix_output_with_timestamp=True,
                verbose=self.getVerbose(),
            )
        elif num_proc is not None:
            raise ValueError(
                'At most one of parameters "backend" and "num_proc" may be specified'
            )
        return backend

    def _find_num_proc(self):
        if self.getUseGpu():
            # set it as number of executors for now (ignoring num_gpus per executor)
            sc = SparkContext.getOrCreate()
            return sc._jsc.sc().getExecutorMemoryStatus().size() - 1
        return None

    def _update_transformation_fn(self):
        if self.getTransformationFn() is None:
            if self.getTransformFn() is None:
                crop_size = self.getInputShapes()[0][-1]
                transform = transforms.Compose(
                    [
                        transforms.RandomResizedCrop(crop_size),
                        transforms.RandomHorizontalFlip(),
                        transforms.ToTensor(),
                        transforms.Normalize(
                            mean=[0.485, 0.456, 0.406], std=[0.229, 0.224, 0.225]
                        ),
                    ]
                )
                self.setTransformFn(transform)

            def _create_transform_row(image_col, label_col, transform):
                def _transform_row(row):
                    path = row[image_col]
                    label = row[label_col]
                    image = Image.open(path).convert("RGB")
                    image = transform(image).numpy()
                    return {image_col: image, label_col: label}

                return _transform_row

            self.setTransformationFn(
                _create_transform_row(
                    self.getImageCol(),
                    self.getLabelCol(),
                    self.getTransformFn(),
                )
            )

    def get_model_class(self):
        return DeepVisionModel

    def _get_model_kwargs(self, model, history, optimizer, run_id, metadata):
        return dict(
            history=history,
            model=model,
            optimizer=optimizer,
            input_shapes=self.getInputShapes(),
            run_id=run_id,
            _metadata=metadata,
            loss=self.getLoss(),
            loss_constructors=self.getLossConstructors(),
            label_col=self.getLabelCol(),
            image_col=self.getImageCol(),
            prediction_col=self.getPredictionCol(),
        )
    
    # For py4j only
    def _get_object_id(self):
        return self.uid
