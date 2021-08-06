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
    /// <see cref="Tokenizer"/> implements Tokenizer
    /// </summary>
    public class Tokenizer : ScalaTransformer<Tokenizer>, ScalaMLWritable, ScalaMLReadable<Tokenizer>
    {
        private static readonly string s_tokenizerClassName = "org.apache.spark.ml.feature.Tokenizer";

        /// <summary>
        /// Creates a <see cref="Tokenizer"/> without any parameters.
        /// </summary>
        public Tokenizer() : base(s_tokenizerClassName)
        {
        }

        /// <summary>
        /// Creates a <see cref="Tokenizer"/> with a UID that is used to give the
        /// <see cref="Tokenizer"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public Tokenizer(string uid) : base(s_tokenizerClassName, uid)
        {
        }

        internal Tokenizer(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets inputCol value for <see cref="inputCol"/>
        /// </summary>
        /// <param name="inputCol">
        /// input column name
        /// </param>
        /// <returns> New Tokenizer object </returns>
        public Tokenizer SetInputCol(string value) =>
            WrapAsTokenizer(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets outputCol value for <see cref="outputCol"/>
        /// </summary>
        /// <param name="outputCol">
        /// output column name
        /// </param>
        /// <returns> New Tokenizer object </returns>
        public Tokenizer SetOutputCol(string value) =>
            WrapAsTokenizer(Reference.Invoke("setOutputCol", (object)value));

        /// <summary>
        /// Gets inputCol value for <see cref="inputCol"/>
        /// </summary>
        /// <returns>
        /// inputCol: input column name
        /// </returns>
        public string GetInputCol() =>
            (string)Reference.Invoke("getInputCol");
        
        /// <summary>
        /// Gets outputCol value for <see cref="outputCol"/>
        /// </summary>
        /// <returns>
        /// outputCol: output column name
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");

        /// <summary>
        /// Loads the <see cref="Tokenizer"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="Tokenizer"/> was saved to</param>
        /// <returns>New <see cref="Tokenizer"/> object, loaded from path.</returns>
        public static Tokenizer Load(string path) => WrapAsTokenizer(
            SparkEnvironment.JvmBridge.CallStaticJavaMethod(s_tokenizerClassName, "load", path));
        
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
        public ScalaMLReader<Tokenizer> Read() =>
            new ScalaMLReader<Tokenizer>((JvmObjectReference)Reference.Invoke("read"));

        private static Tokenizer WrapAsTokenizer(object obj) =>
            new Tokenizer((JvmObjectReference)obj);


    }
}

        