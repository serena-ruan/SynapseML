// Copyright (C) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in project root for information.


using System;
using System.Collections.Generic;
using Microsoft.Spark.Interop;
using Microsoft.Spark.Interop.Ipc;
// using Microsoft.Spark.ML.Feature;
using Microsoft.Spark.Sql;
using Microsoft.Spark.Sql.Types;
using mmlspark.dotnet.utils;


namespace featurebase
{
    /// <summary>
    /// <see cref="SQLTransformer"/> implements SQLTransformer
    /// </summary>
    public class SQLTransformer : ScalaTransformer<SQLTransformer>
    {
        private static readonly string s_sQLTransformerClassName = "org.apache.spark.ml.feature.SQLTransformer";

        /// <summary>
        /// Creates a <see cref="SQLTransformer"/> without any parameters.
        /// </summary>
        public SQLTransformer() : base(s_sQLTransformerClassName)
        {
        }

        /// <summary>
        /// Creates a <see cref="SQLTransformer"/> with a UID that is used to give the
        /// <see cref="SQLTransformer"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public SQLTransformer(string uid) : base(s_sQLTransformerClassName, uid)
        {
        }

        internal SQLTransformer(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets statement value for <see cref="statement"/>
        /// </summary>
        /// <param name="statement">
        /// SQL statement
        /// </param>
        /// <returns> New SQLTransformer object </returns>
        public SQLTransformer SetStatement(string value) =>
            WrapAsSQLTransformer(Reference.Invoke("setStatement", value));

        /// <summary>
        /// Gets statement value for <see cref="statement"/>
        /// </summary>
        /// <returns>
        /// statement: SQL statement
        /// </returns>
        public string GetStatement() =>
            (string)Reference.Invoke("getStatement");

        /// <summary>
        /// Executes the <see cref="SQLTransformer"/> and transforms the DataFrame to include new columns.
        /// </summary>
        /// <param name="dataset">The Dataframe to be transformed.</param>
        /// <returns>
        /// <see cref="DataFrame"/> containing the original data and new columns.
        /// </returns>
        override public DataFrame Transform(DataFrame dataset) =>
            new DataFrame((JvmObjectReference)Reference.Invoke("transform", dataset));
        
        /// <summary>
        /// Check transform validity and derive the output schema from the input schema.
        ///
        /// We check validity for interactions between parameters during transformSchema
        /// and raise an exception if any parameter value is invalid.
        ///
        /// Typical implementation should first conduct verification on schema change and
        /// parameter validity, including complex parameter interaction checks.
        /// </summary>
        /// <param name="schema">
        /// The <see cref="StructType"/> of the <see cref="DataFrame"/> which will be transformed.
        /// </param>
        /// </returns>
        /// The <see cref="StructType"/> of the output schema that would have been derived from the
        /// input schema, if Transform had been called.
        /// </returns>
        public StructType TransformSchema(StructType schema) =>
            new StructType(
                (JvmObjectReference)Reference.Invoke(
                    "transformSchema",
                    DataType.FromJson(Reference.Jvm, schema.Json)));

        /// <summary>
        /// Loads the <see cref="SQLTransformer"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="SQLTransformer"/> was saved to</param>
        /// <returns>New <see cref="SQLTransformer"/> object, loaded from path.</returns>
        public static SQLTransformer Load(string path) => WrapAsSQLTransformer(
            SparkEnvironment.JvmBridge.CallStaticJavaMethod(s_sQLTransformerClassName, "load", path));

        private static SQLTransformer WrapAsSQLTransformer(object obj) =>
            new SQLTransformer((JvmObjectReference)obj);


    }
}

        