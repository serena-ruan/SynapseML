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
    /// <see cref="HashingTF"/> implements HashingTF
    /// </summary>
    public class HashingTF : ScalaTransformer<HashingTF>, ScalaMLWritable, ScalaMLReadable<HashingTF>
    {
        private static readonly string s_hashingTFClassName = "org.apache.spark.ml.feature.HashingTF";

        /// <summary>
        /// Creates a <see cref="HashingTF"/> without any parameters.
        /// </summary>
        public HashingTF() : base(s_hashingTFClassName)
        {
        }

        /// <summary>
        /// Creates a <see cref="HashingTF"/> with a UID that is used to give the
        /// <see cref="HashingTF"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public HashingTF(string uid) : base(s_hashingTFClassName, uid)
        {
        }

        internal HashingTF(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets binary value for <see cref="binary"/>
        /// </summary>
        /// <param name="binary">
        /// If true, all non zero counts are set to 1. This is useful for discrete probabilistic models that model binary events rather than integer counts
        /// </param>
        /// <returns> New HashingTF object </returns>
        public HashingTF SetBinary(bool value) =>
            WrapAsHashingTF(Reference.Invoke("setBinary", (object)value));
        
        /// <summary>
        /// Sets inputCol value for <see cref="inputCol"/>
        /// </summary>
        /// <param name="inputCol">
        /// input column name
        /// </param>
        /// <returns> New HashingTF object </returns>
        public HashingTF SetInputCol(string value) =>
            WrapAsHashingTF(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets numFeatures value for <see cref="numFeatures"/>
        /// </summary>
        /// <param name="numFeatures">
        /// Number of features. Should be greater than 0
        /// </param>
        /// <returns> New HashingTF object </returns>
        public HashingTF SetNumFeatures(int value) =>
            WrapAsHashingTF(Reference.Invoke("setNumFeatures", (object)value));
        
        /// <summary>
        /// Sets outputCol value for <see cref="outputCol"/>
        /// </summary>
        /// <param name="outputCol">
        /// output column name
        /// </param>
        /// <returns> New HashingTF object </returns>
        public HashingTF SetOutputCol(string value) =>
            WrapAsHashingTF(Reference.Invoke("setOutputCol", (object)value));

        /// <summary>
        /// Gets binary value for <see cref="binary"/>
        /// </summary>
        /// <returns>
        /// binary: If true, all non zero counts are set to 1. This is useful for discrete probabilistic models that model binary events rather than integer counts
        /// </returns>
        public bool GetBinary() =>
            (bool)Reference.Invoke("getBinary");
        
        /// <summary>
        /// Gets inputCol value for <see cref="inputCol"/>
        /// </summary>
        /// <returns>
        /// inputCol: input column name
        /// </returns>
        public string GetInputCol() =>
            (string)Reference.Invoke("getInputCol");
        
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
        /// Loads the <see cref="HashingTF"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="HashingTF"/> was saved to</param>
        /// <returns>New <see cref="HashingTF"/> object, loaded from path.</returns>
        public static HashingTF Load(string path) => WrapAsHashingTF(
            SparkEnvironment.JvmBridge.CallStaticJavaMethod(s_hashingTFClassName, "load", path));
        
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
        public ScalaMLReader<HashingTF> Read() =>
            new ScalaMLReader<HashingTF>((JvmObjectReference)Reference.Invoke("read"));

        private static HashingTF WrapAsHashingTF(object obj) =>
            new HashingTF((JvmObjectReference)obj);


    }
}

        