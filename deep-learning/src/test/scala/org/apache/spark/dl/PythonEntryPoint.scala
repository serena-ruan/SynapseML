// Copyright (C) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in project root for information.

package org.apache.spark.dl

import com.microsoft.azure.synapse.ml.core.test.base.TestBase
import org.apache.spark.util.{Utils => SparkUtils}
import py4j.ClientServer

import java.io.File
import scala.collection.JavaConverters._

trait IPythonEntryPoint {
  /** Create object with className and return objectID in string format */
  def createObject(className: String): String

  def callMethod(uid: String, methodName: String, methodValue: java.util.HashMap[String, _]): Any

  def getObject(uid: String): Any

  def shutdownPython(): Unit

  def updateGatewayImports(): Unit
}

class PythonEntryPoint(val clientServer: ClientServer) extends IPythonEntryPoint {

  type ValueType = IPythonEntryPoint

  val pyObject: ValueType = this.clientServer.getPythonServerEntryPoint(
    Array(classOf[ValueType])).asInstanceOf[ValueType]

  def createObject(className: String): String = this.pyObject.createObject(className)

  def callMethod(uid: String, methodName: String, methodValue: java.util.HashMap[String, _]): Any = {
    this.pyObject.callMethod(uid, methodName, methodValue)
  }

  def getObject(uid: String): Any = this.pyObject.getObject(uid)

  def shutdownPython(): Unit = this.pyObject.shutdownPython()

  def shutdown(): Unit = this.clientServer.shutdown()

  def updateGatewayImports(): Unit = this.pyObject.updateGatewayImports()

}

class SimpleHello(val pyEntryPoint: PythonEntryPoint) {

  var uid: String = null

  def init(): this.type = {
    this.uid = this.pyEntryPoint.createObject(this.getClass.getSimpleName)
    this
  }

  def sayHello(name: String, greetings: String): Unit = {
    val methodValue = new java.util.HashMap[String, Any]()
    methodValue.put("name", name)
    methodValue.put("greetings", greetings)
    this.pyEntryPoint.callMethod(this.uid, "sayHello", methodValue)
  }

}

object runPython extends App {
  val Secret = "e0a9a8940de4584b55557f921bedbf7b77b68dba90dcedeaed435570054628be"

  Utils.runCmd(Seq("/home/serena/miniconda3/envs/synapseml/bin/python", "PythonEntryPoint.py", Secret),
    new File("/home/serena/repos/SynapseML/deep-learning/src/test/scala/org/apache/spark/dl"))
}

object TestHello extends App {
  val ClientServerObj = new ClientServer.ClientServerBuilder()
    .authToken("e0a9a8940de4584b55557f921bedbf7b77b68dba90dcedeaed435570054628be")
    .build()

  val PyEntryPoint = new PythonEntryPoint(ClientServerObj)

  val SimpleHelloObj = new SimpleHello(PyEntryPoint).init()

  SimpleHelloObj.sayHello("S", "How are you?")

  PyEntryPoint.shutdownPython()
  PyEntryPoint.shutdown()
}

