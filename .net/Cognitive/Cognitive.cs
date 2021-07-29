using System;
using Microsoft.Spark.Interop;
using Microsoft.Spark.Interop.Ipc;
using mmlspark.dotnet.utils;
using System.Collections.Generic;
using Microsoft.Spark.Sql;
using Microsoft.Spark.Sql.Types;
using Microsoft.Spark.ML.Feature.Param;

namespace mmlspark.cognitive
{
    public class TextSentiment : ScalaTransformer<TextSentiment>
    {
        private static readonly string s_textSentimentClassName = "com.microsoft.ml.spark.cognitive.TextSentiment";


        public TextSentiment() : base(s_textSentimentClassName)
        {
        }

        public TextSentiment(string uid) : base(s_textSentimentClassName, uid)
        {
        }
        internal TextSentiment(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        public TextSentiment SetShowStats(bool value) =>
            WrapAsTextSentiment(Reference.Invoke("setShowStats", value));

        public TextSentiment SetModelVersion(string value) =>
            WrapAsTextSentiment(Reference.Invoke("setModelVersion", value));

        public TextSentiment SetLanguage(IEnumerable<string> value) =>
            WrapAsTextSentiment(Reference.Invoke("setLanguage", value));

        public TextSentiment SetLanguage(string value) =>
            WrapAsTextSentiment(Reference.Invoke("setLanguage", value));

        public TextSentiment SetLanguageCol(string value) =>
            WrapAsTextSentiment(Reference.Invoke("setLanguageCol", value));

        public TextSentiment SetLocation(string value) =>
            WrapAsTextSentiment(Reference.Invoke("setLocation", value));

        public TextSentiment SetSubscriptionKey(string value) =>
            WrapAsTextSentiment(Reference.Invoke("setSubscriptionKey", value));

        public TextSentiment SetOutputCol(string value) =>
            WrapAsTextSentiment(Reference.Invoke("setOutputCol", value));

        public TextSentiment SetTextCol(string value) =>
            WrapAsTextSentiment(Reference.Invoke("setTextCol", value));

        public IEnumerable<string> GetLanguage() => (string[])Reference.Invoke("getLanguage");

        override public DataFrame Transform(DataFrame dataset) =>
            new DataFrame((JvmObjectReference)Reference.Invoke("transform", dataset));
        
        public StructType TransformSchema(StructType schema) =>
            new StructType(
                (JvmObjectReference)Reference.Invoke(
                    "transformSchema",
                    DataType.FromJson(Reference.Jvm, schema.Json)));

        public static TextSentiment Load(string path) =>
           WrapAsTextSentiment(
               SparkEnvironment.JvmBridge.CallStaticJavaMethod(
                   s_textSentimentClassName,
                   "load",
                   path));

        private static TextSentiment WrapAsTextSentiment(object obj) => new TextSentiment((JvmObjectReference)obj);

    }
}
