// Copyright (C) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in project root for information.


using System;
using System.Collections.Generic;
using Microsoft.Spark.Interop;
using Microsoft.Spark.Interop.Ipc;
using Microsoft.Spark.Sql;
using Microsoft.Spark.Sql.Types;
using mmlspark.dotnet.wrapper;
using mmlspark.dotnet.utils;


namespace featurebase
{
    /// <summary>
    /// <see cref="FeatureHasher"/> implements FeatureHasher
    /// </summary>
    public class FeatureHasher : ScalaTransformer<FeatureHasher>, ScalaMLWritable, ScalaMLReadable<FeatureHasher>
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
        public FeatureHasher SetCategoricalCols(string[] value) =>
            WrapAsFeatureHasher(Reference.Invoke("setCategoricalCols", (object)value));
        
        /// <summary>
        /// Sets inputCols value for <see cref="inputCols"/>
        /// </summary>
        /// <param name="inputCols">
        /// input column names
        /// </param>
        /// <returns> New FeatureHasher object </returns>
        public FeatureHasher SetInputCols(string[] value) =>
            WrapAsFeatureHasher(Reference.Invoke("setInputCols", (object)value));
        
        /// <summary>
        /// Sets numFeatures value for <see cref="numFeatures"/>
        /// </summary>
        /// <param name="numFeatures">
        /// Number of features. Should be greater than 0
        /// </param>
        /// <returns> New FeatureHasher object </returns>
        public FeatureHasher SetNumFeatures(int value) =>
            WrapAsFeatureHasher(Reference.Invoke("setNumFeatures", (object)value));
        
        /// <summary>
        /// Sets outputCol value for <see cref="outputCol"/>
        /// </summary>
        /// <param name="outputCol">
        /// output column name
        /// </param>
        /// <returns> New FeatureHasher object </returns>
        public FeatureHasher SetOutputCol(string value) =>
            WrapAsFeatureHasher(Reference.Invoke("setOutputCol", (object)value));

        /// <summary>
        /// Gets categoricalCols value for <see cref="categoricalCols"/>
        /// </summary>
        /// <returns>
        /// categoricalCols: numeric columns to treat as categorical
        /// </returns>
        public string[] GetCategoricalCols() =>
            (string[])Reference.Invoke("getCategoricalCols");
        
        /// <summary>
        /// Gets inputCols value for <see cref="inputCols"/>
        /// </summary>
        /// <returns>
        /// inputCols: input column names
        /// </returns>
        public string[] GetInputCols() =>
            (string[])Reference.Invoke("getInputCols");
        
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
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");

        /// <summary>
        /// Loads the <see cref="FeatureHasher"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="FeatureHasher"/> was saved to</param>
        /// <returns>New <see cref="FeatureHasher"/> object, loaded from path.</returns>
        public static FeatureHasher Load(string path) => WrapAsFeatureHasher(
            SparkEnvironment.JvmBridge.CallStaticJavaMethod(s_featureHasherClassName, "load", path));
        
        /// <summary>
        /// Saves the object so that it can be loaded later using Load. Note that these objects
        /// can be shared with Scala by Loading or Saving in Scala.
        /// </summary>
        /// <param name="path">The path to save the object to</param>
        public void Save(string path) => Reference.Invoke("save", path);
        
        /// <returns>a <see cref="ScalaMLWriter"/> instance for this ML instance.</returns>
        public ScalaMLWriter Write() =>
            new ScalaMLWriter((JvmObjectReference)Reference.Invoke("write"));
        
        /// <returns>an <see cref="ScalaMLReader"/> instance for this ML instance.</returns>
        public ScalaMLReader<FeatureHasher> Read() =>
            new ScalaMLReader<FeatureHasher>((JvmObjectReference)Reference.Invoke("read"));

        private static FeatureHasher WrapAsFeatureHasher(object obj) =>
            new FeatureHasher((JvmObjectReference)obj);


    }
}

        