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
    /// <see cref="NGram"/> implements NGram
    /// </summary>
    public class NGram : ScalaTransformer<NGram>, ScalaMLWritable, ScalaMLReadable<NGram>
    {
        private static readonly string s_nGramClassName = "org.apache.spark.ml.feature.NGram";

        /// <summary>
        /// Creates a <see cref="NGram"/> without any parameters.
        /// </summary>
        public NGram() : base(s_nGramClassName)
        {
        }

        /// <summary>
        /// Creates a <see cref="NGram"/> with a UID that is used to give the
        /// <see cref="NGram"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public NGram(string uid) : base(s_nGramClassName, uid)
        {
        }

        internal NGram(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets inputCol value for <see cref="inputCol"/>
        /// </summary>
        /// <param name="inputCol">
        /// input column name
        /// </param>
        /// <returns> New NGram object </returns>
        public NGram SetInputCol(string value) =>
            WrapAsNGram(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets n value for <see cref="n"/>
        /// </summary>
        /// <param name="n">
        /// number elements per n-gram (>=1)
        /// </param>
        /// <returns> New NGram object </returns>
        public NGram SetN(int value) =>
            WrapAsNGram(Reference.Invoke("setN", (object)value));
        
        /// <summary>
        /// Sets outputCol value for <see cref="outputCol"/>
        /// </summary>
        /// <param name="outputCol">
        /// output column name
        /// </param>
        /// <returns> New NGram object </returns>
        public NGram SetOutputCol(string value) =>
            WrapAsNGram(Reference.Invoke("setOutputCol", (object)value));

        /// <summary>
        /// Gets inputCol value for <see cref="inputCol"/>
        /// </summary>
        /// <returns>
        /// inputCol: input column name
        /// </returns>
        public string GetInputCol() =>
            (string)Reference.Invoke("getInputCol");
        
        /// <summary>
        /// Gets n value for <see cref="n"/>
        /// </summary>
        /// <returns>
        /// n: number elements per n-gram (>=1)
        /// </returns>
        public int GetN() =>
            (int)Reference.Invoke("getN");
        
        /// <summary>
        /// Gets outputCol value for <see cref="outputCol"/>
        /// </summary>
        /// <returns>
        /// outputCol: output column name
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");

        /// <summary>
        /// Loads the <see cref="NGram"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="NGram"/> was saved to</param>
        /// <returns>New <see cref="NGram"/> object, loaded from path.</returns>
        public static NGram Load(string path) => WrapAsNGram(
            SparkEnvironment.JvmBridge.CallStaticJavaMethod(s_nGramClassName, "load", path));
        
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
        public ScalaMLReader<NGram> Read() =>
            new ScalaMLReader<NGram>((JvmObjectReference)Reference.Invoke("read"));

        private static NGram WrapAsNGram(object obj) =>
            new NGram((JvmObjectReference)obj);


    }
}

        