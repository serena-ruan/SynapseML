// Copyright (C) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in project root for information.

package com.microsoft.azure.synapse.ml.codegen

import com.microsoft.azure.synapse.ml.core.env.FileUtilities
import com.microsoft.azure.synapse.ml.core.serialize.ComplexParam
import org.apache.commons.lang.StringUtils.capitalize
import org.apache.spark.ml._
import org.apache.spark.ml.evaluation.Evaluator
import org.apache.spark.ml.param._

import java.nio.charset.StandardCharsets
import java.nio.file.Files
import scala.collection.JavaConverters._

// TODO: delete as moved this to dotnet/spark repo
object DotnetHelper {

  def setPipelineStages(pipeline: Pipeline, value: java.util.ArrayList[_ <: PipelineStage]): Pipeline =
    pipeline.setStages(value.asScala.toArray)

  def convertToJavaMap(value: Map[_, _]): java.util.Map[_, _] = value.asJava

  // TODO: support more types for UntypedArrayParam
  def mapScalaToJava(value: java.lang.Object): Any = {
    value match {
      case i: java.lang.Integer => i.toInt
      case d: java.lang.Double => d.toDouble
      case f: java.lang.Float => f.toFloat
      case b: java.lang.Boolean => b.booleanValue()
      case l: java.lang.Long => l.toLong
      case s: java.lang.Short => s.toShort
      case by: java.lang.Byte => by.toByte
      case c: java.lang.Character => c.toChar
      case _ => value
    }
  }
}

trait DotnetWrappable extends BaseWrappable {

  import DefaultParamInfo._
  import GenerationUtils._

  protected lazy val dotnetCopyrightLines: String =
    s"""|// Copyright (C) Microsoft Corporation. All rights reserved.
        |// Licensed under the MIT License. See LICENSE in project root for information.
        |""".stripMargin

  protected lazy val dotnetNamespace: String =
    thisStage.getClass.getName
      .replace("com.microsoft.azure.synapse.ml", "Synapse.ML")
      .replace("org.apache.spark.ml", "Microsoft.Spark.ML")
      .split(".".toCharArray).map(capitalize).dropRight(1).mkString(".")

  protected lazy val dotnetInternalWrapper = false

  protected lazy val dotnetClassName: String = {
    if (dotnetInternalWrapper) {
      "_" + classNameHelper
    } else {
      "" + classNameHelper
    }
  }

  protected def unCapitalize(name: String): String = {
    Character.toLowerCase(name.charAt(0)) + name.substring(1)
  }

  protected lazy val dotnetClassNameString: String = s"s_${unCapitalize(dotnetClassName)}ClassName"

  protected lazy val dotnetClassWrapperName: String = "WrapAs" + dotnetClassName

  protected lazy val dotnetObjectBaseClass: String = {
    thisStage match {
      case _: Estimator[_] => s"JavaEstimator<${companionModelClassName.split(".".toCharArray).last}>"
      case _: Model[_] => s"JavaModel<$dotnetClassName>"
      case _: Transformer => s"JavaTransformer"
      case _: Evaluator => s"JavaEvaluator"
    }
  }

  protected def dotnetMLReadWriteMethods: String = {
    s"""|/// <summary>
        |/// Loads the <see cref=\"$dotnetClassName\"/> that was previously saved using Save(string).
        |/// </summary>
        |/// <param name=\"path\">The path the previous <see cref=\"$dotnetClassName\"/> was saved to</param>
        |/// <returns>New <see cref=\"$dotnetClassName\"/> object, loaded from path.</returns>
        |public static $dotnetClassName Load(string path) => $dotnetClassWrapperName(
        |    SparkEnvironment.JvmBridge.CallStaticJavaMethod($dotnetClassNameString, "load", path));
        |
        |/// <summary>
        |/// Saves the object so that it can be loaded later using Load. Note that these objects
        |/// can be shared with Scala by Loading or Saving in Scala.
        |/// </summary>
        |/// <param name="path">The path to save the object to</param>
        |public void Save(string path) => Reference.Invoke("save", path);
        |
        |/// <returns>a <see cref=\"JavaMLWriter\"/> instance for this ML instance.</returns>
        |public JavaMLWriter Write() =>
        |    new JavaMLWriter((JvmObjectReference)Reference.Invoke("write"));
        |
        |/// <returns>an <see cref=\"JavaMLReader\"/> instance for this ML instance.</returns>
        |public JavaMLReader<$dotnetClassName> Read() =>
        |    new JavaMLReader<$dotnetClassName>((JvmObjectReference)Reference.Invoke("read"));
        |""".stripMargin
  }

  protected def dotnetWrapAsTypeMethod: String = {
    s"""|private static $dotnetClassName $dotnetClassWrapperName(object obj) =>
        |    new $dotnetClassName((JvmObjectReference)obj);
        |""".stripMargin
  }

  def dotnetAdditionalMethods: String = {
    ""
  }

  //noinspection ScalaStyle
  protected def dotnetParamSetter(p: Param[_]): String = {
    val capName = p.name match {
      case "xgboostDartMode" => "XGBoostDartMode"
      case "parallelism" => dotnetClassName match {
        case "VowpalWabbitContextualBandit" => "ParallelismForParamListFit"
        case _ => p.name.capitalize
      }
      case _ => p.name.capitalize
    }
    val docString =
      s"""|/// <summary>
          |/// Sets ${p.name} value for <see cref=\"${p.name}\"/>
          |/// </summary>
          |/// <param name=\"${p.name}\">
          |/// ${p.doc}
          |/// </param>
          |/// <returns> New $dotnetClassName object </returns>""".stripMargin
    p match {
      case sp: ServiceParam[_] =>
        s"""|$docString
            |public $dotnetClassName Set$capName(${getServiceParamInfo(sp).dotnetType} value) =>
            |    $dotnetClassWrapperName(Reference.Invoke(\"set$capName\", (object)value));
            |
            |public $dotnetClassName Set${capName}Col(string value) =>
            |    $dotnetClassWrapperName(Reference.Invoke(\"set${capName}Col\", value));
            |""".stripMargin
      case _: DataTypeParam =>
        s"""|$docString
            |public $dotnetClassName Set$capName(${getParamInfo(p).dotnetType} value) =>
            |    $dotnetClassWrapperName(Reference.Invoke(\"set$capName\",
            |    DataType.FromJson(Reference.Jvm, value.Json)));
            |""".stripMargin
      case _: StringStringMapParam | _: StringIntMapParam =>
        s"""|$docString
            |public $dotnetClassName Set$capName(${getParamInfo(p).dotnetType} value)
            |{
            |    var hashMap = new HashMap(SparkEnvironment.JvmBridge);
            |    foreach (var item in value)
            |    {
            |        hashMap.Put(item.Key, item.Value);
            |    }
            |    return $dotnetClassWrapperName(Reference.Invoke(\"set$capName\", (object)hashMap));
            |}
            |""".stripMargin
      case _: EstimatorParam | _: ModelParam =>
        s"""|$docString
            |public $dotnetClassName Set${capName}<M>(${getParamInfo(p).dotnetType} value) where M : JavaModel<M> =>
            |    $dotnetClassWrapperName(Reference.Invoke(\"set$capName\", (object)value));
            |""".stripMargin
      case _: ArrayParamMapParam | _: TransformerArrayParam | _: EstimatorArrayParam | _: UntypedArrayParam =>
        s"""|$docString
            |public $dotnetClassName Set$capName(${getParamInfo(p).dotnetType} value)
            |    => $dotnetClassWrapperName(Reference.Invoke(\"set$capName\", (object)value.ToJavaArrayList()));
            |""".stripMargin
      case _: ArrayMapParam =>
        s"""|$docString
            |public $dotnetClassName Set$capName(${getParamInfo(p).dotnetType} value)
            |    => $dotnetClassWrapperName(Reference.Invoke(\"set$capName\",
            |        (object)value.Select(_ => _.ToJavaHashMap()).ToArray().ToJavaArrayList()));
            |""".stripMargin
      // TODO: Fix UDF & UDPyF confusion
      case _: UDFParam | _: UDPyFParam =>
        s"""|$docString
            |public $dotnetClassName Set$capName(object value) =>
            |    $dotnetClassWrapperName(Reference.Invoke(\"set$capName\", value));
            |""".stripMargin
      // TODO: Fix these objects
      case _: ParamSpaceParam | _: BallTreeParam | _: ConditionalBallTreeParam =>
        s"""|$docString
            |public $dotnetClassName Set$capName(object value) =>
            |    $dotnetClassWrapperName(Reference.Invoke(\"set$capName\", value));
            |""".stripMargin
      case _ =>
        s"""|$docString
            |public $dotnetClassName Set$capName(${getParamInfo(p).dotnetType} value) =>
            |    $dotnetClassWrapperName(Reference.Invoke(\"set$capName\", (object)value));
            |""".stripMargin
    }
  }

  protected def dotnetParamSetters: String =
    thisStage.params.map(dotnetParamSetter).mkString("\n")

  //noinspection ScalaStyle
  protected def dotnetParamGetter(p: Param[_]): String = {
    val capName = p.name.capitalize
    val docString =
      s"""|/// <summary>
          |/// Gets ${p.name} value for <see cref=\"${p.name}\"/>
          |/// </summary>
          |/// <returns>
          |/// ${p.name}: ${p.doc}
          |/// </returns>""".stripMargin
    p match {
      case sp: ServiceParam[_] =>
        val dType = getGeneralParamInfo(sp).dotnetType
        dType match {
          case "TimeSeriesPoint[]" |
               "TargetInput[]" |
               "TextAndTranslation[]" |
               "TAAnalyzeTask[]" =>
            s"""
               |$docString
               |public $dType Get$capName()
               |{
               |    JvmObjectReference jvmObject = (JvmObjectReference)Reference.Invoke(\"get$capName\");
               |    JvmObjectReference[] jvmObjects = (JvmObjectReference[])jvmObject.Invoke("array");
               |    $dType result =
               |        new ${dType.substring(0, dType.length - 2)}[jvmObjects.Length];
               |    for (int i = 0; i < result.Length; i++)
               |    {
               |        result[i] = new ${dType.substring(0, dType.length - 2)}(jvmObjects[i]);
               |    }
               |    return result;
               |}
               |""".stripMargin
          case _ =>
            s"""
               |$docString
               |public $dType Get$capName() =>
               |    ($dType)Reference.Invoke(\"get$capName\");
               |""".stripMargin
        }
      case _: DataTypeParam =>
        s"""
           |$docString
           |public ${getParamInfo(p).dotnetType} Get$capName()
           |{
           |    JvmObjectReference jvmObject = (JvmObjectReference)Reference.Invoke(\"get$capName\");
           |    string json = (string)jvmObject.Invoke(\"json\");
           |    return DataType.ParseDataType(json);
           |}
           |""".stripMargin
      case _: StringStringMapParam | _: StringIntMapParam =>
        val valType = p match {
          case _: StringStringMapParam => "string"
          case _: StringIntMapParam => "int"
          case _ => throw new Exception(s"unsupported value type $p")
        }
        s"""
           |$docString
           |public ${getParamInfo(p).dotnetType} Get$capName()
           |{
           |    JvmObjectReference jvmObject = (JvmObjectReference)Reference.Invoke(\"get$capName\");
           |    JvmObjectReference hashMap = (JvmObjectReference)SparkEnvironment.JvmBridge.CallStaticJavaMethod(
           |        "org.apache.spark.api.dotnet.DotnetUtils", "convertToJavaMap", jvmObject);
           |    JvmObjectReference[] keySet = (JvmObjectReference[])(
           |        (JvmObjectReference)hashMap.Invoke("keySet")).Invoke("toArray");
           |    ${getParamInfo(p).dotnetType} result = new ${getParamInfo(p).dotnetType}();
           |    foreach (var k in keySet)
           |    {
           |        result.Add((string)k.Invoke("toString"), ($valType)hashMap.Invoke("get", k));
           |    }
           |    return result;
           |}
           |""".stripMargin
      case _: TypedIntArrayParam | _: TypedDoubleArrayParam =>
        s"""
           |$docString
           |public ${getParamInfo(p).dotnetType} Get$capName()
           |{
           |    JvmObjectReference jvmObject = (JvmObjectReference)Reference.Invoke(\"get$capName\");
           |    return (${getParamInfo(p).dotnetType})jvmObject.Invoke(\"array\");
           |}
           |""".stripMargin
      case _: UntypedArrayParam =>
        s"""
           |$docString
           |public ${getParamInfo(p).dotnetType} Get$capName()
           |{
           |    JvmObjectReference[] jvmObjects = (JvmObjectReference[])Reference.Invoke(\"get$capName\");
           |    object[] result = new object[jvmObjects.Length];
           |    for (int i = 0; i < result.Length; i++)
           |    {
           |        result[i] = SparkEnvironment.JvmBridge.CallStaticJavaMethod(
           |            "org.apache.spark.api.dotnet.DotnetUtils", "mapScalaToJava", (object)jvmObjects[i]);
           |    }
           |    return result;
           |}
           |""".stripMargin
      case _: ArrayMapParam =>
        s"""
           |$docString
           |public ${getParamInfo(p).dotnetType} Get$capName()
           |{
           |    JvmObjectReference[] jvmObjects = (JvmObjectReference[])Reference.Invoke(\"get$capName\");
           |    Dictionary<string, object>[] result = new Dictionary<string, object>[jvmObjects.Length];
           |    JvmObjectReference hashMap;
           |    JvmObjectReference[] keySet;
           |    Dictionary<string, object> dic;
           |    object val;
           |    for (int i = 0; i < result.Length; i++)
           |    {
           |        hashMap = (JvmObjectReference)SparkEnvironment.JvmBridge.CallStaticJavaMethod(
           |            "com.microsoft.azure.synapse.ml.codegen.DotnetHelper", "convertToJavaMap", jvmObjects[i]);
           |        keySet = (JvmObjectReference[])(
           |            (JvmObjectReference)hashMap.Invoke("keySet")).Invoke("toArray");
           |        dic = new Dictionary<string, object>();
           |        foreach (var k in keySet)
           |        {
           |            val = SparkEnvironment.JvmBridge.CallStaticJavaMethod(
           |                "org.apache.spark.api.dotnet.DotnetUtils",
           |                "mapScalaToJava", hashMap.Invoke("get", k));
           |            dic.Add((string)k.Invoke("toString"), val);
           |        }
           |        result[i] = dic;
           |    }
           |    return result;
           |}
           |""".stripMargin
      case _: EstimatorParam | _: ModelParam | _: TransformerParam | _: EvaluatorParam | _: PipelineStageParam =>
        s"""
           |$docString
           |public ${p.asInstanceOf[WrappableParam[_]].dotnetReturnType} Get$capName()
           |{
           |    JvmObjectReference jvmObject = (JvmObjectReference)Reference.Invoke(\"get$capName\");
           |    var (constructorClass, methodName) = Helper.GetUnderlyingType(jvmObject);
           |    Type type = Type.GetType(constructorClass);
           |    MethodInfo method = type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static);
           |    return (${p.asInstanceOf[WrappableParam[_]].dotnetReturnType})method.Invoke(
           |        null, new object[] {jvmObject});
           |}
           |""".stripMargin
      case _: ArrayParamMapParam =>
        s"""
           |$docString
           |public ParamMap[] Get$capName()
           |{
           |    JvmObjectReference[] jvmObjects = (JvmObjectReference[])Reference.Invoke(\"get$capName\");
           |    ParamMap[] result = new ParamMap[jvmObjects.Length];
           |    for (int i=0; i < jvmObjects.Length; i++)
           |    {
           |        result[i] = new ParamMap(jvmObjects[i]);
           |    }
           |    return result;
           |}
           |""".stripMargin
      case _: TransformerArrayParam | _: EstimatorArrayParam =>
        val dType = getParamInfo(p).dotnetType.substring(0, getParamInfo(p).dotnetType.length - 2)
        s"""
           |$docString
           |public $dType[] Get$capName()
           |{
           |    JvmObjectReference[] jvmObjects = (JvmObjectReference[])Reference.Invoke(\"get$capName\");
           |    $dType[] result = new $dType[jvmObjects.Length];
           |    for (int i=0; i < jvmObjects.Length; i++)
           |    {
           |        var (constructorClass, methodName) = Helper.GetUnderlyingType(jvmObjects[i]);
           |        Type type = Type.GetType(constructorClass);
           |        MethodInfo method = type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static);
           |        result[i] = ($dType)method.Invoke(null, new object[] {jvmObjects[i]});
           |    }
           |    return result;
           |}
           |""".stripMargin
      case cp: ComplexParam[_] =>
        if (cp.dotnetType == "object") {
          s"""
             |$docString
             |public object Get$capName() => Reference.Invoke(\"get$capName\");
             |""".stripMargin
        } else {
          s"""
             |$docString
             |public ${cp.dotnetType} Get$capName() =>
             |    new ${cp.dotnetType}((JvmObjectReference)Reference.Invoke(\"get$capName\"));
             |""".stripMargin
        }
      case _ =>
        s"""
           |$docString
           |public ${getParamInfo(p).dotnetType} Get$capName() =>
           |    (${getParamInfo(p).dotnetType})Reference.Invoke(\"get$capName\");
           |""".stripMargin
    }
  }

  protected def dotnetParamGetters: String =
    thisStage.params.map(dotnetParamGetter).mkString("\n")

  //noinspection ScalaStyle
  protected def dotnetExtraMethods: String = {
    thisStage match {
      case _: Estimator[_] =>
        s"""|/// <summary>Fits a model to the input data.</summary>
            |/// <param name=\"dataset\">The <see cref=\"DataFrame\"/> to fit the model to.</param>
            |/// <returns><see cref=\"${companionModelClassName.split(".".toCharArray).last}\"/></returns>
            |override public ${companionModelClassName.split(".".toCharArray).last} Fit(DataFrame dataset) =>
            |    new ${companionModelClassName.split(".".toCharArray).last}(
            |        (JvmObjectReference)Reference.Invoke("fit", dataset));
            |""".stripMargin
      case _ =>
        ""
    }
  }

  protected def dotnetExtraEstimatorImports: String = {
    thisStage match {
      case _: Estimator[_] =>
        val companionModelImport = companionModelClassName
          .replaceAllLiterally("com.microsoft.azure.synapse.ml", "Synapse.ML")
          .replaceAllLiterally("org.apache.spark.ml", "Microsoft.Spark.ML")
          .replaceAllLiterally("org.apache.spark", "Microsoft.Spark")
          .split(".".toCharArray)
          .map(capitalize)
          .dropRight(1)
          .mkString(".")
        s"using $companionModelImport;"
      case _ =>
        ""
    }
  }

  //noinspection ScalaStyle
  protected def dotnetClass(): String = {
    s"""|$dotnetCopyrightLines
        |
        |using System;
        |using System.Collections.Generic;
        |using System.Linq;
        |using System.Reflection;
        |using Microsoft.Spark.ML.Feature;
        |using Microsoft.Spark.ML.Feature.Param;
        |using Microsoft.Spark.Interop;
        |using Microsoft.Spark.Interop.Ipc;
        |using Microsoft.Spark.Interop.Internal.Java.Util;
        |using Microsoft.Spark.Sql;
        |using Microsoft.Spark.Sql.Types;
        |using SynapseML.Dotnet.Utils;
        |using Synapse.ML.LightGBM.Param;
        |$dotnetExtraEstimatorImports
        |
        |namespace $dotnetNamespace
        |{
        |    /// <summary>
        |    /// <see cref=\"$dotnetClassName\"/> implements $dotnetClassName
        |    /// </summary>
        |    public class $dotnetClassName : $dotnetObjectBaseClass, IJavaMLWritable, IJavaMLReadable<$dotnetClassName>
        |    {
        |        private static readonly string $dotnetClassNameString = \"${thisStage.getClass.getName}\";
        |
        |        /// <summary>
        |        /// Creates a <see cref=\"$dotnetClassName\"/> without any parameters.
        |        /// </summary>
        |        public $dotnetClassName() : base($dotnetClassNameString)
        |        {
        |        }
        |
        |        /// <summary>
        |        /// Creates a <see cref=\"$dotnetClassName\"/> with a UID that is used to give the
        |        /// <see cref=\"$dotnetClassName\"/> a unique ID.
        |        /// </summary>
        |        /// <param name=\"uid\">An immutable unique ID for the object and its derivatives.</param>
        |        public $dotnetClassName(string uid) : base($dotnetClassNameString, uid)
        |        {
        |        }
        |
        |        internal $dotnetClassName(JvmObjectReference jvmObject) : base(jvmObject)
        |        {
        |        }
        |
        |${indent(dotnetParamSetters, 2)}
        |${indent(dotnetParamGetters, 2)}
        |${indent(dotnetExtraMethods, 2)}
        |${indent(dotnetMLReadWriteMethods, 2)}
        |${indent(dotnetWrapAsTypeMethod, 2)}
        |${indent(dotnetAdditionalMethods, 2)}
        |    }
        |}
        |
        """.stripMargin
  }

  def makeDotnetFile(conf: CodegenConfig): Unit = {
    val importPath = thisStage.getClass.getName.split(".".toCharArray).dropRight(1)
    val srcFolders = importPath.mkString(".")
      .replaceAllLiterally("com.microsoft.azure.synapse.ml", "synapse.ml").split(".".toCharArray)
    val srcDir = FileUtilities.join((Seq(conf.dotnetSrcDir.toString) ++ srcFolders.toSeq): _*)
    srcDir.mkdirs()
    Files.write(
      FileUtilities.join(srcDir, dotnetClassName + ".cs").toPath,
      dotnetClass().getBytes(StandardCharsets.UTF_8))
  }

}
