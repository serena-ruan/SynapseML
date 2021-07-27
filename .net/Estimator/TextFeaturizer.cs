using System;
using Microsoft.Spark.Interop;
using Microsoft.Spark.Interop.Ipc;
using Microsoft.Spark.ML.Feature;
using mmlspark.dotnet.utils;
using Microsoft.Spark.Sql;

namespace mmlspark.core.featurize.text
{

    public class PipelineModel : ScalaModel<PipelineModel>
    {
        private static readonly string s_pipelineModelClassName = "org.apache.spark.ml.PipelineModel";

        public PipelineModel() : base(s_pipelineModelClassName)
        {
        }

        public PipelineModel(string uid) : base(s_pipelineModelClassName, uid)
        {
        }

        internal PipelineModel(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        override public DataFrame Transform(DataFrame dataset) =>
            new DataFrame((JvmObjectReference)Reference.Invoke("transform", dataset));

    }

    public class TextFeaturizer : ScalaEstimator<TextFeaturizer, PipelineModel>
    {
        private static readonly string s_textFeaturizerClassName = "com.microsoft.ml.spark.featurize.text.TextFeaturizer";


        public TextFeaturizer() : base(s_textFeaturizerClassName)
        {
        }

        public TextFeaturizer(string uid) : base(s_textFeaturizerClassName, uid)
        {
        }

        internal TextFeaturizer(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        public TextFeaturizer SetUseTokenizer(bool value) =>
            WrapAsTextFeaturizer(Reference.Invoke("setUseTokenizer", value));

        public TextFeaturizer SetInputCol(string value) =>
            WrapAsTextFeaturizer(Reference.Invoke("setInputCol", value));

        public TextFeaturizer SetOutputCol(string value) =>
            WrapAsTextFeaturizer(Reference.Invoke("setOutputCol", value));

        public TextFeaturizer SetNumFeatures(int value) =>
            WrapAsTextFeaturizer(Reference.Invoke("setNumFeatures", value));

        override public PipelineModel Fit(DataFrame dataset) =>
            new PipelineModel((JvmObjectReference)Reference.Invoke("fit", dataset));

        public static TextFeaturizer Load(string path) =>
           WrapAsTextFeaturizer(
               SparkEnvironment.JvmBridge.CallStaticJavaMethod(
                   s_textFeaturizerClassName,
                   "load",
                   path));

        private static TextFeaturizer WrapAsTextFeaturizer(object obj) => new TextFeaturizer((JvmObjectReference)obj);

    }
}
