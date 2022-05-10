// Copyright (C) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in project root for information.

package com.microsoft.azure.synapse.ml.core.serialize

import org.apache.hadoop.fs.Path
import org.apache.spark.ml.Serializer
import org.apache.spark.ml.param.{Param, Params, WrappableParam}
import org.apache.spark.sql.SparkSession

import scala.reflect.runtime.universe.{TypeTag, typeTag}

abstract class ComplexParam[T: TypeTag](parent: Params, name: String, doc: String, isValid: T => Boolean)
  extends Param[T](parent, name, doc, isValid) with WrappableParam[T] {

  def ttag: TypeTag[T] = typeTag[T]

  def save(obj: T, sparkSession: SparkSession, path: Path, overwrite: Boolean): Unit = {
    Serializer.typeToSerializer[T](ttag.tpe, sparkSession).write(obj, path, overwrite)
  }

  def load(sparkSession: SparkSession, path: Path): T = {
    Serializer.typeToSerializer[T](ttag.tpe, sparkSession).read(path)
  }

  override def jsonEncode(value: T): String = {
    throw new NotImplementedError("The parameter is a ComplexParam and cannot be JSON encoded.")
  }

  override def jsonDecode(json: String): T = {
    throw new NotImplementedError("The parameter is a ComplexParam and cannot be JSON decoded.")
  }

  override def dotnetTestValue(v: T): String =
    throw new NotImplementedError("No translation found for complex parameter")

  override def dotnetType: String = "object"

  override def dotnetGetter(capName: String): String = {
    dotnetType match {
      case "object" =>
        s"""public object Get$capName() => Reference.Invoke(\"get$capName\");""".stripMargin
      case _ =>
        s"""|public $dotnetReturnType Get$capName() =>
            |    new $dotnetReturnType((JvmObjectReference)Reference.Invoke(\"get$capName\"));
            |""".stripMargin
    }
  }

}
