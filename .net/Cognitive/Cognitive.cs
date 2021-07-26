using System;
using Microsoft.Spark.Interop;
using Microsoft.Spark.Interop.Ipc;
using mmlspark.dotnet.utils;
using System.Collections.Generic;
using Microsoft.Spark.ML.Feature.Param;

namespace mmlspark.cognitive
{
    public class TextSentiment: Transformer<TextSentiment>
    {
        private static readonly string s_textSentimentClassName = "com.microsoft.ml.spark.cognitive.TextSentiment";

        
        public TextSentiment() : base(s_textSentimentClassName)
        {
            this.SetTextCol("text");
            this.SetLanguage(new List<string> {"en"});
        }

         public TextSentiment(string uid): base(s_textSentimentClassName, uid)
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

         public static TextSentiment Load(string path) =>
            WrapAsTextSentiment(
                SparkEnvironment.JvmBridge.CallStaticJavaMethod(
                    s_textSentimentClassName,
                    "load",
                    path));

        private static TextSentiment WrapAsTextSentiment(object obj) => new TextSentiment((JvmObjectReference)obj);

    }
}
