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
    /// <see cref="VectorAssembler"/> implements VectorAssembler
    /// </summary>
    public class VectorAssembler : ScalaTransformer<VectorAssembler>, ScalaMLWritable, ScalaMLReadable<VectorAssembler>
    {
        private static readonly string s_vectorAssemblerClassName = "org.apache.spark.ml.feature.VectorAssembler";

        /// <summary>
        /// Creates a <see cref="VectorAssembler"/> without any parameters.
        /// </summary>
        public VectorAssembler() : base(s_vectorAssemblerClassName)
        {
        }

        /// <summary>
        /// Creates a <see cref="VectorAssembler"/> with a UID that is used to give the
        /// <see cref="VectorAssembler"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public VectorAssembler(string uid) : base(s_vectorAssemblerClassName, uid)
        {
        }

        internal VectorAssembler(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets handleInvalid value for <see cref="handleInvalid"/>
        /// </summary>
        /// <param name="handleInvalid">
        /// Param for how to handle invalid data (NULL and NaN values). Options are 'skip' (filter out rows with invalid data), 'error' (throw an error), or 'keep' (return relevant number of NaN in the output). Column lengths are taken from the size of ML Attribute Group, which can be set using `VectorSizeHint` in a pipeline before `VectorAssembler`. Column lengths can also be inferred from first rows of the data since it is safe to do so but only in case of 'error' or 'skip'.
        /// </param>
        /// <returns> New VectorAssembler object </returns>
        public VectorAssembler SetHandleInvalid(string value) =>
            WrapAsVectorAssembler(Reference.Invoke("setHandleInvalid", (object)value));
        
        /// <summary>
        /// Sets inputCols value for <see cref="inputCols"/>
        /// </summary>
        /// <param name="inputCols">
        /// input column names
        /// </param>
        /// <returns> New VectorAssembler object </returns>
        public VectorAssembler SetInputCols(string[] value) =>
            WrapAsVectorAssembler(Reference.Invoke("setInputCols", (object)value));
        
        /// <summary>
        /// Sets outputCol value for <see cref="outputCol"/>
        /// </summary>
        /// <param name="outputCol">
        /// output column name
        /// </param>
        /// <returns> New VectorAssembler object </returns>
        public VectorAssembler SetOutputCol(string value) =>
            WrapAsVectorAssembler(Reference.Invoke("setOutputCol", (object)value));

        /// <summary>
        /// Gets handleInvalid value for <see cref="handleInvalid"/>
        /// </summary>
        /// <returns>
        /// handleInvalid: Param for how to handle invalid data (NULL and NaN values). Options are 'skip' (filter out rows with invalid data), 'error' (throw an error), or 'keep' (return relevant number of NaN in the output). Column lengths are taken from the size of ML Attribute Group, which can be set using `VectorSizeHint` in a pipeline before `VectorAssembler`. Column lengths can also be inferred from first rows of the data since it is safe to do so but only in case of 'error' or 'skip'.
        /// </returns>
        public string GetHandleInvalid() =>
            (string)Reference.Invoke("getHandleInvalid");
        
        /// <summary>
        /// Gets inputCols value for <see cref="inputCols"/>
        /// </summary>
        /// <returns>
        /// inputCols: input column names
        /// </returns>
        public string[] GetInputCols() =>
            (string[])Reference.Invoke("getInputCols");
        
        /// <summary>
        /// Gets outputCol value for <see cref="outputCol"/>
        /// </summary>
        /// <returns>
        /// outputCol: output column name
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");

        /// <summary>
        /// Loads the <see cref="VectorAssembler"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="VectorAssembler"/> was saved to</param>
        /// <returns>New <see cref="VectorAssembler"/> object, loaded from path.</returns>
        public static VectorAssembler Load(string path) => WrapAsVectorAssembler(
            SparkEnvironment.JvmBridge.CallStaticJavaMethod(s_vectorAssemblerClassName, "load", path));
        
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
        public ScalaMLReader<VectorAssembler> Read() =>
            new ScalaMLReader<VectorAssembler>((JvmObjectReference)Reference.Invoke("read"));

        private static VectorAssembler WrapAsVectorAssembler(object obj) =>
            new VectorAssembler((JvmObjectReference)obj);


    }
}

        