// Copyright (C) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in project root for information.

package org.apache.spark.dl

import com.microsoft.azure.synapse.ml.codegen.Wrappable
import com.microsoft.azure.synapse.ml.core.test.base.TestBase
import com.microsoft.azure.synapse.ml.logging.BasicLogging
import org.apache.spark.SparkConf
import org.apache.spark.ml.param.{Param, ParamMap, Params}
import org.apache.spark.ml.util.Identifiable
import org.apache.spark.ml.{ComplexParamsWritable, Estimator, Model}
import org.apache.spark.sql.functions.{col, udf}
import org.apache.spark.sql.types.{DoubleType, IntegerType, StructType}
import org.apache.spark.sql.{DataFrame, Dataset, Row, SparkSession}
import org.apache.spark.util.{Utils => SparkUtils}
import py4j.ClientServer

import java.io.File
import java.lang.ProcessBuilder.Redirect
import java.util


trait PredictionParams extends Params {
  val labelCol: Param[String] = new Param[String](this, "labelCol", "label column name")

  def setLabelCol(v: String): this.type

  def getLabelCol: String = $(labelCol)

  val imageCol: Param[String] = new Param[String](this, "imageCol", "image column name")

  def setImageCol(v: String): this.type

  def getImageCol: String = $(imageCol)

  val predictionCol: Param[String] = new Param[String](this, "predictionCol", "prediction column name")

  def setPredictionCol(v: String): this.type

  def getPredictionCol: String = $(predictionCol)

  setDefault(
    labelCol -> "label",
    imageCol -> "image",
    predictionCol -> "prediction"
  )

}

class DeepVisionClassifier(override val uid: String, val pythonEntryPoint: PythonEntryPoint)
  extends Estimator[DeepVisionModel] with PredictionParams
    with ComplexParamsWritable
    with Wrappable
    with BasicLogging {

  logClass()

  def this(pythonEntryPoint: PythonEntryPoint) =
    this(pythonEntryPoint.createObject("DeepVisionClassifier"), pythonEntryPoint)

  val backbone = new Param[String](this,
    "backbone",
    "Backbone of the deep vision model, should be a string representation of torchvision model.")

  def setBackbone(v: String): this.type = {
    val methodValue = new util.HashMap[String, Any]()
    methodValue.put("value", v)
    this.pythonEntryPoint.callMethod(this.uid, "setBackbone", methodValue)
    set(backbone, v)
  }

  def getBackbone(): String = $(backbone)

  val additionalLayersToTrain = new Param[Int](this,
    "additionalLayersToTrain",
    "number of last layers to fine tune for the model, should be between 0 and 3")

  def setAdditionalLayersToTrain(v: Int): this.type = {
    val methodValue = new util.HashMap[String, Any]()
    methodValue.put("value", v)
    this.pythonEntryPoint.callMethod(this.uid, "setAdditionalLayersToTrain", methodValue)
    set(additionalLayersToTrain, v)
  }

  def getAdditionalLayersToTrain(): Int = $(additionalLayersToTrain)

  val numClasses = new Param[Int](this,
    "numClasses",
    "number of target classes")

  def setNumClasses(v: Int): this.type = {
    val methodValue = new util.HashMap[String, Any]()
    methodValue.put("value", v)
    this.pythonEntryPoint.callMethod(this.uid, "setNumClasses", methodValue)
    set(numClasses, v)
  }

  def getNumClasses(): Int = $(numClasses)

  val lossName = new Param[String](this,
    "lossName",
    "string representation of torch.nn.functional loss function for the underlying " +
      "pytorch_lightning model, e.g. binary_cross_entropy")

  def setLossName(v: String): this.type = {
    val methodValue = new util.HashMap[String, Any]()
    methodValue.put("value", v)
    this.pythonEntryPoint.callMethod(this.uid, "setLossName", methodValue)
    set(lossName, v)
  }

  def getLossName(): String = $(lossName)

  val optimizerName = new Param[String](this,
    "optimizerName",
    "string representation of optimizer function for the underlying pytorch_lightning model")

  def setOptimizerName(v: String): this.type = {
    val methodValue = new util.HashMap[String, Any]()
    methodValue.put("value", v)
    this.pythonEntryPoint.callMethod(this.uid, "setOptimizerName", methodValue)
    set(optimizerName, v)
  }

  def getOptimizerName(): String = $(optimizerName)

  val dropoutAUX = new Param[Double](this,
    "dropoutAUX",
    "numeric value that's applied to googlenet InceptionAux module's dropout " +
      "layer only: probability of an element to be zeroed")

  def setDropoutAUX(v: Double): this.type = {
    val methodValue = new util.HashMap[String, Any]()
    methodValue.put("value", v)
    this.pythonEntryPoint.callMethod(this.uid, "setDropoutAUX", methodValue)
    set(dropoutAUX, v)
  }

  def getDropoutAUX(): Double = $(dropoutAUX)

  setDefault(additionalLayersToTrain -> 0,
    optimizerName -> "adam",
    lossName -> "cross_entropy",
    dropoutAUX -> 0.7)

  def setLabelCol(v: String): this.type = {
    val methodValue = new util.HashMap[String, Any]()
    methodValue.put("value", v)
    this.pythonEntryPoint.callMethod(this.uid, "setLabelCol", methodValue)
    set(labelCol, v)
  }

  def setImageCol(v: String): this.type = {
    val methodValue = new util.HashMap[String, Any]()
    methodValue.put("value", v)
    this.pythonEntryPoint.callMethod(this.uid, "setImageCol", methodValue)
    set(imageCol, v)
  }

  def setPredictionCol(v: String): this.type = {
    val methodValue = new util.HashMap[String, Any]()
    methodValue.put("value", v)
    this.pythonEntryPoint.callMethod(this.uid, "setPredictionCol", methodValue)
    set(predictionCol, v)
  }

  val storeParam = new Param[String](this,
    "storeParam",
    "A string representation of the store for horovod training")

  def setStoreParam(v: String): this.type = {
    val methodValue = new util.HashMap[String, Any]()
    methodValue.put("value", v)
    this.pythonEntryPoint.callMethod(this.uid, "setStoreParam", methodValue)
    set(storeParam, v)
  }

  def getStoreParam(): String = $(storeParam)

  val storePrefixPath = new Param[String](this,
    "storePrefixPath",
    "Prefix path used for store_param, should only be used when you use store_param instead of store")

  def setStorePrefixPath(v: String): this.type = {
    val methodValue = new util.HashMap[String, Any]()
    methodValue.put("value", v)
    this.pythonEntryPoint.callMethod(this.uid, "setStorePrefixPath", methodValue)
    set(storePrefixPath, v)
  }

  def getStorePrefixPath(): String = $(storePrefixPath)

  override def fit(dataset: Dataset[_]): DeepVisionModel = {
    logFit({
      val methodValue = new util.HashMap[String, Any]()
      methodValue.put("df", dataset)
      val result = this.pythonEntryPoint.callMethod(this.uid, "fit", methodValue)
        .asInstanceOf[Tuple2[String, Any]]
      val uid = result._1
      val deepVisionModelObj = result._2
      this.pythonEntryPoint.addObject(uid, deepVisionModelObj)
      new DeepVisionModel(uid, this.pythonEntryPoint)
    })
  }

  override def copy(extra: ParamMap): Estimator[DeepVisionModel] = defaultCopy(extra)

  override def transformSchema(schema: StructType): StructType = {
    schema.add(getPredictionCol, IntegerType)
  }
}


class DeepVisionModel(override val uid: String, val pythonEntryPoint: PythonEntryPoint)
  extends Model[DeepVisionModel] with PredictionParams
    with ComplexParamsWritable with BasicLogging {

  logClass()

  def this(pythonEntryPoint: PythonEntryPoint) =
    this(pythonEntryPoint.createObject("DeepVisionModel"), pythonEntryPoint)

  def setLabelCol(v: String): this.type = {
    val methodValue = new util.HashMap[String, Any]()
    methodValue.put("value", v)
    this.pythonEntryPoint.callMethod(this.uid, "setLabelCol", methodValue)
    set(labelCol, v)
  }

  def setImageCol(v: String): this.type = {
    val methodValue = new util.HashMap[String, Any]()
    methodValue.put("value", v)
    this.pythonEntryPoint.callMethod(this.uid, "setImageCol", methodValue)
    set(imageCol, v)
  }

  def setPredictionCol(v: String): this.type = {
    val methodValue = new util.HashMap[String, Any]()
    methodValue.put("value", v)
    this.pythonEntryPoint.callMethod(this.uid, "setPredictionCol", methodValue)
    set(predictionCol, v)
  }

  override def transform(dataset: Dataset[_]): DataFrame = {
    logTransform({
      val methodValue = new util.HashMap[String, Any]()
      methodValue.put("dataset", dataset)
      val df = this.pythonEntryPoint.callMethod(this.uid, "transform", methodValue)
      df.asInstanceOf[DataFrame]
    })
  }

  override def copy(extra: ParamMap): DeepVisionModel = defaultCopy(extra)

  override def transformSchema(schema: StructType): StructType = {
    schema.add(getPredictionCol, IntegerType)
  }

}

object Utils {
  def runCmd(cmd: Seq[String],
             wd: File = new File("."),
             envVars: Map[String, String] = Map()): Unit = {
    val pb = new ProcessBuilder()
      .directory(wd)
      .command(cmd: _*)
      .redirectError(Redirect.INHERIT)
      .redirectOutput(Redirect.INHERIT)
    val env = pb.environment()
    envVars.foreach(p => env.put(p._1, p._2))
    val result = pb.start().waitFor()
    if (result != 0) {
      println(s"Error: result code: ${result}")
      throw new Exception(s"Execution resulted in non-zero exit code: ${result}")
    }
  }

}

//object SparkObj {
//  var Spark: SparkSession = null
//
//  def init(): String = {
//    val sparkConfig = new SparkConf()
//    Spark = SparkSession.builder().config(sparkConfig)
//      .master("local[*]").appName("test py4j").getOrCreate()
//    val secret: String = SparkUtils.createSecret(sparkConfig)
//    secret
//  }
//
//  def shutdown(): Unit = Spark.stop()
//}

class TestSuite extends TestBase {
  val sparkConfig = spark.sparkContext.getConf
  val secret = SparkUtils.createSecret(sparkConfig)

  def generateData(): (DataFrame, DataFrame) = {
    import spark.implicits._

    val trainFolder = "/home/serena/repos/SynapseML/deep-learning/target/jpg/train"
    val testFolder = "/home/serena/repos/SynapseML/deep-learning/target/jpg/test"
    val trainFiles = new File(trainFolder).listFiles().filter(_.getName.endsWith(".jpg")).map(_.toString)
    val testFiles = new File(testFolder).listFiles().filter(_.getName.endsWith(".jpg")).map(_.toString)

    //    import spark.implicits._
    def extractLabel(path: String): Int = {
      path.split("/".toCharArray).takeRight(1)(0).split(".".toCharArray)
        .take(1)(0).split("_".toCharArray).takeRight(1)(0).toInt / 81
    }

    val extractLabelUdf = udf(extractLabel _)

    val trainDF = trainFiles.toSeq.toDF("image")
      .withColumn("label", extractLabelUdf(col("image")).cast(DoubleType))
    val testDF = testFiles.toSeq.toDF("image")
      .withColumn("label", extractLabelUdf(col("image")).cast(DoubleType))
    (trainDF, testDF)
  }

  // We should run python script first
  // This opens port 25334
  test("runPython") {
    Utils.runCmd(Seq("/home/serena/miniconda3/envs/synapseml/bin/python", "PythonEntryPoint.py", secret),
      new File("/home/serena/repos/SynapseML/deep-learning/src/test/scala/org/apache/spark/dl"))
  }

  test("deepVisionClassifier") {
    val clientServer = new ClientServer.ClientServerBuilder()
      .authToken("5abf6ac7b7dd62fd1878624894296a60af59642666c8d0198e67aaf026f8c064")
      .build()

    val pyEntryPoint = new PythonEntryPoint(clientServer)
    pyEntryPoint.updateGatewayImports()

    val deepVisionClassifier = new DeepVisionClassifier(pyEntryPoint)
      .setBackbone("resnet50")
      .setAdditionalLayersToTrain(1)
      .setNumClasses(17)
      .setStoreParam("LocalStore")
      .setStorePrefixPath("./test")

    println(deepVisionClassifier.getNumClasses())
    println(deepVisionClassifier.getLossName())
    println(deepVisionClassifier.getAdditionalLayersToTrain())

    val dfs = generateData()
    val trainDF = dfs._1
    val testDF = dfs._2

    val deepVisionModel = deepVisionClassifier.fit(trainDF)

    pyEntryPoint.shutdownPython()
    pyEntryPoint.shutdown()
  }

}
