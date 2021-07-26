using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;
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
    public class Transformer<T> : FeatureBase<T>
    {
        public Transformer(string className) : base(className)
        {
        }

        public Transformer(string className, string uid) : base(className, uid)
        {
        }

        public Transformer(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        public DataFrame Transform(DataFrame dataset) =>
            new DataFrame((JvmObjectReference)Reference.Invoke("transform", dataset));

        public StructType TransformSchema(StructType schema) =>
            new StructType(
                (JvmObjectReference)Reference.Invoke(
                    "transformSchema",
                    DataType.FromJson(Reference.Jvm, schema.Json)));

    }

}
