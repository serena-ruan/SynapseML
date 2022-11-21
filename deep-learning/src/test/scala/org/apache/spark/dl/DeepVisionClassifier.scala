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

trait IDeepVisionClassifier extends PredictionParams {

  def setBackbone(v: String): IDeepVisionClassifier

  def setAdditionalLayersToTrain(v: Int): IDeepVisionClassifier

  def setNumClasses(v: Int): IDeepVisionClassifier

  def setLossName(v: String): IDeepVisionClassifier

  def setOptimizerName(v: String): IDeepVisionClassifier

  def setDropoutAUX(v: Double): IDeepVisionClassifier

  def setStoreParam(v: String): IDeepVisionClassifier

  def setStorePrefixPath(v: String): IDeepVisionClassifier

  def fit(dataset: Dataset[_]): Any

  def updateGatewayImports(): Unit

  def shutdownPython(): Unit

  def shutdown(): Unit
}

class DeepVisionClassifier(override val uid: String, val clientServer: ClientServer)
  extends Estimator[DeepVisionModel] with IDeepVisionClassifier
    with ComplexParamsWritable
    with Wrappable
    with BasicLogging {

  logClass()

  def this() = this(Identifiable.randomUID("DeepVisionClassifier"), new ClientServer())

  def this(clientServer: ClientServer) = this(Identifiable.randomUID("DeepVisionClassifier"), clientServer)

  type ValueType = IDeepVisionClassifier

  //  var pyObject: ValueType = null
  val pyObject: ValueType = this.clientServer.getPythonServerEntryPoint(
    Array(classOf[ValueType])).asInstanceOf[ValueType]

  val backbone = new Param[String](this,
    "backbone",
    "Backbone of the deep vision model, should be a string representation of torchvision model.")

  def setBackbone(v: String): this.type = {
    this.pyObject.setBackbone(v)
    set(backbone, v)
  }

  def getBackbone(): String = $(backbone)

  val additionalLayersToTrain = new Param[Int](this,
    "additionalLayersToTrain",
    "number of last layers to fine tune for the model, should be between 0 and 3")

  def setAdditionalLayersToTrain(v: Int): this.type = {
    this.pyObject.setAdditionalLayersToTrain(v)
    set(additionalLayersToTrain, v)
  }

  def getAdditionalLayersToTrain(): Int = $(additionalLayersToTrain)

  val numClasses = new Param[Int](this,
    "numClasses",
    "number of target classes")

  def setNumClasses(v: Int): this.type = {
    this.pyObject.setNumClasses(v)
    set(numClasses, v)
  }

  def getNumClasses(): Int = $(numClasses)

  val lossName = new Param[String](this,
    "lossName",
    "string representation of torch.nn.functional loss function for the underlying " +
      "pytorch_lightning model, e.g. binary_cross_entropy")

  def setLossName(v: String): this.type = {
    this.pyObject.setLossName(v)
    set(lossName, v)
  }

  def getLossName(): String = $(lossName)

  val optimizerName = new Param[String](this,
    "optimizerName",
    "string representation of optimizer function for the underlying pytorch_lightning model")

  def setOptimizerName(v: String): this.type = {
    this.pyObject.setOptimizerName(v)
    set(optimizerName, v)
  }

  def getOptimizerName(): String = $(optimizerName)

  val dropoutAUX = new Param[Double](this,
    "dropoutAUX",
    "numeric value that's applied to googlenet InceptionAux module's dropout " +
      "layer only: probability of an element to be zeroed")

  def setDropoutAUX(v: Double): this.type = {
    this.pyObject.setDropoutAUX(v)
    set(dropoutAUX, v)
  }

  def getDropoutAUX(): Double = $(dropoutAUX)

  setDefault(additionalLayersToTrain -> 0,
    optimizerName -> "adam",
    lossName -> "cross_entropy",
    dropoutAUX -> 0.7)

  def setLabelCol(v: String): this.type = {
    this.pyObject.setLabelCol(v)
    set(labelCol, v)
  }

  def setImageCol(v: String): this.type = {
    this.pyObject.setImageCol(v)
    set(imageCol, v)
  }

  def setPredictionCol(v: String): this.type = {
    this.pyObject.setPredictionCol(v)
    set(predictionCol, v)
  }

  val storeParam = new Param[String](this,
    "storeParam",
    "A string representation of the store for horovod training")

  def setStoreParam(v: String): this.type = {
    this.pyObject.setStoreParam(v)
    set(storeParam, v)
  }

  def getStoreParam(): String = $(storeParam)

  val storePrefixPath = new Param[String](this,
    "storePrefixPath",
    "Prefix path used for store_param, should only be used when you use store_param instead of store")

  def setStorePrefixPath(v: String): this.type = {
    this.pyObject.setStorePrefixPath(v)
    set(storePrefixPath, v)
  }

  def getStorePrefixPath(): String = $(storePrefixPath)

  override def fit(dataset: Dataset[_]): DeepVisionModel = {
    logFit({
      this.pyObject.fit(dataset)
      new DeepVisionModel(this.clientServer) //TODO: fix those params set in python side but not scala side yet
    })
  }

  def shutdownPython(): Unit = this.pyObject.shutdownPython()

  def shutdown(): Unit = this.clientServer.shutdown()

  def updateGatewayImports(): Unit = this.pyObject.updateGatewayImports()

  override def copy(extra: ParamMap): Estimator[DeepVisionModel] = defaultCopy(extra)

  override def transformSchema(schema: StructType): StructType = {
    schema.add(getPredictionCol, IntegerType)
  }
}

trait IDeepVisionModel extends PredictionParams {

  def transform(dataset: Dataset[_]): DataFrame

  def shutdownPython(): Unit

  def shutdown(): Unit
}


class DeepVisionModel(override val uid: String, val clientServer: ClientServer)
  extends Model[DeepVisionModel] with IDeepVisionModel
    with ComplexParamsWritable with BasicLogging {

  logClass()

  def this() = this(Identifiable.randomUID("DeepVisionModel"), new ClientServer())

  def this(clientServer: ClientServer) = this(Identifiable.randomUID("DeepVisionModel"), clientServer)

  type ValueType = IDeepVisionModel

  val pyObject: ValueType = this.clientServer.getPythonServerEntryPoint(
    Array(classOf[ValueType])).asInstanceOf[ValueType]

  def setLabelCol(v: String): this.type = {
    this.pyObject.setLabelCol(v)
    set(labelCol, v)
  }

  def setImageCol(v: String): this.type = {
    this.pyObject.setImageCol(v)
    set(imageCol, v)
  }

  def setPredictionCol(v: String): this.type = {
    this.pyObject.setPredictionCol(v)
    set(predictionCol, v)
  }

  override def transform(dataset: Dataset[_]): DataFrame = {
    logTransform({
      this.pyObject.transform(dataset)
    })
  }

  def shutdownPython(): Unit = this.pyObject.shutdownPython()

  def shutdown(): Unit = this.clientServer.shutdown()

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
    Utils.runCmd(Seq("/home/serena/miniconda3/envs/synapseml/bin/python", "DeepVisionClassifier.py", secret),
      new File("/home/serena/repos/SynapseML/deep-learning/src/test/scala/org/apache/spark/dl"))
  }

  test("py4j") {
    val clientServer = new ClientServer.ClientServerBuilder()
      .authToken("832c7b2af7e678d3000fee030090e780f921af308693ed925dce899ce47a1ace")
//      .autoStartJavaServer(false)
      .build()
    val pythonClient = clientServer.getPythonClient
    val javaServer = clientServer.getJavaServer
    val gateway = javaServer.getGateway()
    val pyObject: IDeepVisionClassifier = clientServer.getPythonServerEntryPoint(
      Array(classOf[IDeepVisionClassifier])).asInstanceOf[IDeepVisionClassifier]
    pyObject.setBackbone("resnet50")
  }

  test("deepVisionClassifier") {
    val clientServer = new ClientServer.ClientServerBuilder()
      .authToken("47ff74ae8650732f31b8e644581f591eee1d787d758a420c07ffea1d96160ee7")
      .build()
    val deepVisionClassifier = new DeepVisionClassifier(clientServer)
      .setBackbone("resnet50")
      .setAdditionalLayersToTrain(1)
      .setNumClasses(17)
      .setStoreParam("LocalStore")
      .setStorePrefixPath("./test")

    deepVisionClassifier.updateGatewayImports()

    println(deepVisionClassifier.getNumClasses())
    println(deepVisionClassifier.getLossName())
    println(deepVisionClassifier.getAdditionalLayersToTrain())

    val dfs = generateData()
    val trainDF = dfs._1
    val testDF = dfs._2

    val deepVisionModel = deepVisionClassifier.fit(trainDF)

    deepVisionClassifier.shutdownPython()
    deepVisionClassifier.shutdown()
  }

}
