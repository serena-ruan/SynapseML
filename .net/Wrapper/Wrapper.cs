using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;
using Microsoft.Spark;
using Microsoft.Spark.Sql;
using Microsoft.Spark.Sql.Types;
using Microsoft.Spark.ML.Feature;
using Microsoft.Spark.ML.Feature.Param;
using Microsoft.Spark.Interop;
using Microsoft.Spark.Interop.Ipc;

namespace mmlspark.dotnet.utils
{

    /// <summary>
    /// <see cref="ScalaTransformer"/> Abstract class for transformers that transform one dataset into another.
    /// </summary>
    public abstract class ScalaTransformer<T> : FeatureBase<T>
    {
        public ScalaTransformer(string className) : base(className)
        {
        }

        public ScalaTransformer(string className, string uid) : base(className, uid)
        {
        }

        public ScalaTransformer(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Transforms the dataset with optional parameters
        /// </summary>
        /// <param name=\"dataset\">input dataset</param>
        /// <returns>
        /// <see cref=\"DataFrame\"/>transformed dataset.
        /// </returns>
        public abstract DataFrame Transform(DataFrame dataset);

    }

    /// <summary>
    /// <see cref="ScalaEstimator"/> Abstract class for estimators that fit models to data.
    /// </summary>
    public abstract class ScalaEstimator<E, T> : FeatureBase<E> where T : ScalaTransformer<T>
    {

        public ScalaEstimator(string className) : base(className)
        {
        }

        public ScalaEstimator(string className, string uid) : base(className, uid)
        {
        }

        public ScalaEstimator(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        public abstract T Fit(DataFrame dataset);

    }

    /// <summary>
    /// <see cref="ScalaModel"/> Abstract class for models that are fitted by estimators.
    /// </summary>
    public abstract class ScalaModel<T> : ScalaTransformer<T> where T : ScalaModel<T>
    {
        public ScalaModel(string className) : base(className)
        {
        }

        public ScalaModel(string className, string uid) : base(className, uid)
        {
        }

        public ScalaModel(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

    }

    /// <summary>
    /// <see cref="ScalaEvaluator"/> Abstract class for evaluators that compute metrics from predictions.
    /// </summary>
    public abstract class ScalaEvaluator<T> : FeatureBase<T>
    {

        public ScalaEvaluator(string className) : base(className)
        {
        }

        public ScalaEvaluator(string className, string uid) : base(className, uid)
        {
        }

        public ScalaEvaluator(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        public abstract Double Evaluate(DataFrame dataset);

        public Boolean IsLargerBetter => true;

    }

}
