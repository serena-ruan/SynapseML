// Copyright (C) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in project root for information.


using System;
using System.Collections.Generic;
using Microsoft.Spark.Interop;
using Microsoft.Spark.Interop.Ipc;
using Microsoft.Spark.ML.Feature;
using Microsoft.Spark.Sql;
using Microsoft.Spark.Sql.Types;
using mmlspark.dotnet.wrapper;


namespace org.apache.spark.ml.feature
{
    /// <summary>
    /// <see cref="FeatureHasher"/> implements FeatureHasher
    /// </summary>
    public class FeatureHasher : ScalaTransformer<FeatureHasher>
    {
        private static readonly string s_featureHasherClassName = "org.apache.spark.ml.feature.FeatureHasher";

        /// <summary>
        /// Creates a <see cref="FeatureHasher"/> without any parameters.
        /// </summary>
        public FeatureHasher() : base(s_featureHasherClassName)
        {
        }

        /// <summary>
        /// Creates a <see cref="FeatureHasher"/> with a UID that is used to give the
        /// <see cref="FeatureHasher"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public FeatureHasher(string uid) : base(s_featureHasherClassName, uid)
        {
        }

        internal FeatureHasher(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets categoricalCols value for <see cref="categoricalCols"/>
        /// </summary>
        /// <param name="categoricalCols">
        /// numeric columns to treat as categorical
        /// </param>
        /// <returns> New FeatureHasher object </returns>
        public FeatureHasher SetCategoricalCols(IEnumerable<string> value) =>
            WrapAsFeatureHasher(Reference.Invoke("setCategoricalCols", value));
        
        /// <summary>
        /// Sets inputCols value for <see cref="inputCols"/>
        /// </summary>
        /// <param name="inputCols">
        /// input column names
        /// </param>
        /// <returns> New FeatureHasher object </returns>
        public FeatureHasher SetInputCols(IEnumerable<string> value) =>
            WrapAsFeatureHasher(Reference.Invoke("setInputCols", value));
        
        /// <summary>
        /// Sets numFeatures value for <see cref="numFeatures"/>
        /// </summary>
        /// <param name="numFeatures">
        /// Number of features. Should be greater than 0
        /// </param>
        /// <returns> New FeatureHasher object </returns>
        public FeatureHasher SetNumFeatures(int value) =>
            WrapAsFeatureHasher(Reference.Invoke("setNumFeatures", value));
        
        /// <summary>
        /// Sets outputCol value for <see cref="outputCol"/>
        /// </summary>
        /// <param name="outputCol">
        /// output column name
        /// </param>
        /// <returns> New FeatureHasher object </returns>
        public FeatureHasher SetOutputCol(object value) =>
            WrapAsFeatureHasher(Reference.Invoke("setOutputCol", value));

        /// <summary>
        /// Gets categoricalCols value for <see cref="categoricalCols"/>
        /// </summary>
        /// <returns>
        /// categoricalCols: numeric columns to treat as categorical
        /// </returns>
        public IEnumerable<string> GetCategoricalCols() =>
            (IEnumerable<string>)Reference.Invoke("getCategoricalCols");
        
        /// <summary>
        /// Gets inputCols value for <see cref="inputCols"/>
        /// </summary>
        /// <returns>
        /// inputCols: input column names
        /// </returns>
        public IEnumerable<string> GetInputCols() =>
            (IEnumerable<string>)Reference.Invoke("getInputCols");
        
        /// <summary>
        /// Gets numFeatures value for <see cref="numFeatures"/>
        /// </summary>
        /// <returns>
        /// numFeatures: Number of features. Should be greater than 0
        /// </returns>
        public int GetNumFeatures() =>
            (int)Reference.Invoke("getNumFeatures");
        
        /// <summary>
        /// Gets outputCol value for <see cref="outputCol"/>
        /// </summary>
        /// <returns>
        /// outputCol: output column name
        /// </returns>
        public object GetOutputCol() =>
            (object)Reference.Invoke("getOutputCol");

        /// <summary>
        /// Executes the <see cref="FeatureHasher"/> and transforms the DataFrame to include new columns.
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
        /// Loads the <see cref="FeatureHasher"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="FeatureHasher"/> was saved to</param>
        /// <returns>New <see cref="FeatureHasher"/> object, loaded from path.</returns>
        public static FeatureHasher Load(string path) => WrapAsFeatureHasher(
            SparkEnvironment.JvmBridge.CallStaticJavaMethod(s_featureHasherClassName, "load", path));

        private static FeatureHasher WrapAsFeatureHasher(object obj) =>
            new FeatureHasher((JvmObjectReference)obj);


    }
}

