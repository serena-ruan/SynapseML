using System;
using System.Collections.Generic;
using Microsoft.Spark.Interop;
using Microsoft.Spark.Interop.Ipc;
using Microsoft.Spark.ML.Feature;
using mmlspark.dotnet.utils;
using Microsoft.Spark.Sql;
using Microsoft.Spark.Utils;

namespace mmlspark.core.recommendation
{
    public class RankingEvaluator : ScalaEvaluator<RankingEvaluator>
    {

        private static readonly string s_rankingEvaluatorClassName = "com.microsoft.ml.spark.recommendation.RankingEvaluator";

        public RankingEvaluator() : base(s_rankingEvaluatorClassName)
        {
        }

        public RankingEvaluator(string uid) : base(s_rankingEvaluatorClassName, uid)
        {
        }

        internal RankingEvaluator(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        public RankingEvaluator SetNItems(long value) =>
            WrapAsRankingEvaluator(Reference.Invoke("setNItems", value));

        public RankingEvaluator SetK(int value) =>
            WrapAsRankingEvaluator(Reference.Invoke("setK", value));

        override public Double Evaluate(DataFrame dataset) =>
            (Double)Reference.Invoke("evaluate", dataset);

        public static RankingEvaluator Load(string path) =>
           WrapAsRankingEvaluator(
               SparkEnvironment.JvmBridge.CallStaticJavaMethod(
                   s_rankingEvaluatorClassName,
                   "load",
                   path));

        private static RankingEvaluator WrapAsRankingEvaluator(object obj) => new RankingEvaluator((JvmObjectReference)obj);


    }

}
