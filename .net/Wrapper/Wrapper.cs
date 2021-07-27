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
    /// <see cref="Transformer"/> Abstract class for transformers that transform one dataset into another.
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

        public abstract DataFrame Transform(DataFrame dataset);

    }

    /// <summary>
    /// <see cref="Estimator"/> Abstract class for estimators that fit models to data.
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

        public Boolean IsLargerBetter() => true;

    }

}
