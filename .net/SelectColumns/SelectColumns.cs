// Copyright (C) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in project root for information.

using System.Collections.Generic;
using Microsoft.Spark.Interop;
using Microsoft.Spark.Interop.Ipc;
using Microsoft.Spark.ML.Feature;
using Microsoft.Spark.Sql;
using Microsoft.Spark.Sql.Types;

namespace mmlspark.stages
{

    /// <summary>
    /// <see cref="SelectColumns"/> implements SelectColumns
    /// </summary>
    public class SelectColumns : Identifiable, IJvmObjectReferenceProvider
    {
        private static readonly string s_selectColumnsClassName = "com.microsoft.ml.spark.stages.SelectColumns";

        /// <summary>
        /// Creates a <see cref="SelectColumns"/> without any parameters.
        /// </summary>
        public SelectColumns() : this(SparkEnvironment.JvmBridge.CallConstructor(s_selectColumnsClassName))
        {
            // Reference = SparkEnvironment.JvmBridge.CallConstructor(s_selectColumnsClassName, null);
        }

        /// <summary>
        /// Creates a <see cref="SelectColumns"/> with a UID that is used to give the
        /// <see cref="SelectColumns"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public SelectColumns(string uid): this(SparkEnvironment.JvmBridge.CallConstructor(s_selectColumnsClassName, uid))
        {
            // Reference = SparkEnvironment.JvmBridge.CallConstructor(s_selectColumnsClassName, uid);
        }

        internal SelectColumns(JvmObjectReference jvmObject)
        {
            Reference = jvmObject;
        }

        public JvmObjectReference Reference { get; private set; }

        public string Uid() => (string)Reference.Invoke("uid");

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

        /// <summary>
        /// Executes the <see cref="SelectColumns"/> and transforms the DataFrame to include the new column.
        /// </summary>
        /// <param name="dataset">The DataFrame to transform</param>
        /// <returns>
        /// New <see cref="DataFrame"/> object with the source <see cref="DataFrame"/> transformed.
        /// </returns>
        public DataFrame Transform(DataFrame dataset) =>
            new DataFrame((JvmObjectReference)Reference.Invoke("transform", dataset));

        /// <summary>
        /// Executes the <see cref="SelectColumns"/> and transforms the schema.
        /// </summary>
        /// <param name="schema">The Schema to be transformed</param>
        /// <returns>
        /// New <see cref="StructType"/> object with the schema <see cref="StructType"/> transformed.
        /// </returns>
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