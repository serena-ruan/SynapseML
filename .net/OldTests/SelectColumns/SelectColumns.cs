// Copyright (C) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in project root for information.

using System.Collections.Generic;
using Microsoft.Spark.Interop;
using Microsoft.Spark.Interop.Ipc;
using Microsoft.Spark.ML.Feature;
using Microsoft.Spark.Sql;
using Microsoft.Spark.Sql.Types;
using mmlspark.dotnet.wrapper;

namespace mmlspark.stages
{

    /// <summary>
    /// <see cref="SelectColumns"/> implements SelectColumns
    /// </summary>
    public class SelectColumns : ScalaTransformer<SelectColumns>
    {
        private static readonly string s_selectColumnsClassName = "com.microsoft.ml.spark.stages.SelectColumns";

        /// <summary>
        /// Creates a <see cref="SelectColumns"/> without any parameters.
        /// </summary>
        public SelectColumns() : base(s_selectColumnsClassName)
        {
        }

        /// <summary>
        /// Creates a <see cref="SelectColumns"/> with a UID that is used to give the
        /// <see cref="SelectColumns"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public SelectColumns(string uid): base(s_selectColumnsClassName, uid)
        {
        }

        internal SelectColumns(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets cols value for <see cref="cols"/>
        /// </summary>
        /// <param name="value">cols value</param>
        /// <returns>New <see cref="cols"/> object</returns>
        public SelectColumns SetCols(IEnumerable<string> value) => WrapAsSelectColumns(Reference.Invoke("setCols", value));

        /// <summary>
        /// Sets col value for <see cref="cols"/>
        /// </summary>
        /// <param name="value">col value</param>
        /// <returns>New <see cref="cols"/> object</returns>
        public SelectColumns SetCol(string value) => WrapAsSelectColumns(Reference.Invoke("setCol", value));

        /// <summary>
        /// Gets cols value for <see cref="cols"/>
        /// </summary>
        /// <returns>List of cols </returns>
        public IEnumerable<string> GetCols() => (string[])Reference.Invoke("getCols");
        
        override public DataFrame Transform(DataFrame dataset) =>
            new DataFrame((JvmObjectReference)Reference.Invoke("transform", dataset));
        
        public StructType TransformSchema(StructType schema) =>
            new StructType(
                (JvmObjectReference)Reference.Invoke(
                    "transformSchema",
                    DataType.FromJson(Reference.Jvm, schema.Json)));

        /// <summary>
        /// Loads the <see cref="SelectColumns"/> that was previously saved using Save.
        /// </summary>
        /// <param name="path">The path the previous <see cref="SelectColumns"/> was saved to</param>
        /// <returns>New <see cref="SelectColumns"/> object, loaded from path</returns>
        public static SelectColumns Load(string path) =>
            WrapAsSelectColumns(
                SparkEnvironment.JvmBridge.CallStaticJavaMethod(
                    s_selectColumnsClassName,
                    "load",
                    path));

        private static SelectColumns WrapAsSelectColumns(object obj) => new SelectColumns((JvmObjectReference)obj);
    }
}
