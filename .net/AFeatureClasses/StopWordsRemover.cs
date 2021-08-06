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
    /// <see cref="StopWordsRemover"/> implements StopWordsRemover
    /// </summary>
    public class StopWordsRemover : ScalaTransformer<StopWordsRemover>, ScalaMLWritable, ScalaMLReadable<StopWordsRemover>
    {
        private static readonly string s_stopWordsRemoverClassName = "org.apache.spark.ml.feature.StopWordsRemover";

        /// <summary>
        /// Creates a <see cref="StopWordsRemover"/> without any parameters.
        /// </summary>
        public StopWordsRemover() : base(s_stopWordsRemoverClassName)
        {
        }

        /// <summary>
        /// Creates a <see cref="StopWordsRemover"/> with a UID that is used to give the
        /// <see cref="StopWordsRemover"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public StopWordsRemover(string uid) : base(s_stopWordsRemoverClassName, uid)
        {
        }

        internal StopWordsRemover(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets caseSensitive value for <see cref="caseSensitive"/>
        /// </summary>
        /// <param name="caseSensitive">
        /// whether to do a case-sensitive comparison over the stop words
        /// </param>
        /// <returns> New StopWordsRemover object </returns>
        public StopWordsRemover SetCaseSensitive(bool value) =>
            WrapAsStopWordsRemover(Reference.Invoke("setCaseSensitive", (object)value));
        
        /// <summary>
        /// Sets inputCol value for <see cref="inputCol"/>
        /// </summary>
        /// <param name="inputCol">
        /// input column name
        /// </param>
        /// <returns> New StopWordsRemover object </returns>
        public StopWordsRemover SetInputCol(string value) =>
            WrapAsStopWordsRemover(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets inputCols value for <see cref="inputCols"/>
        /// </summary>
        /// <param name="inputCols">
        /// input column names
        /// </param>
        /// <returns> New StopWordsRemover object </returns>
        public StopWordsRemover SetInputCols(string[] value) =>
            WrapAsStopWordsRemover(Reference.Invoke("setInputCols", (object)value));
        
        /// <summary>
        /// Sets locale value for <see cref="locale"/>
        /// </summary>
        /// <param name="locale">
        /// Locale of the input for case insensitive matching. Ignored when caseSensitive is true.
        /// </param>
        /// <returns> New StopWordsRemover object </returns>
        public StopWordsRemover SetLocale(string value) =>
            WrapAsStopWordsRemover(Reference.Invoke("setLocale", (object)value));
        
        /// <summary>
        /// Sets outputCol value for <see cref="outputCol"/>
        /// </summary>
        /// <param name="outputCol">
        /// output column name
        /// </param>
        /// <returns> New StopWordsRemover object </returns>
        public StopWordsRemover SetOutputCol(string value) =>
            WrapAsStopWordsRemover(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets outputCols value for <see cref="outputCols"/>
        /// </summary>
        /// <param name="outputCols">
        /// output column names
        /// </param>
        /// <returns> New StopWordsRemover object </returns>
        public StopWordsRemover SetOutputCols(string[] value) =>
            WrapAsStopWordsRemover(Reference.Invoke("setOutputCols", (object)value));
        
        /// <summary>
        /// Sets stopWords value for <see cref="stopWords"/>
        /// </summary>
        /// <param name="stopWords">
        /// the words to be filtered out
        /// </param>
        /// <returns> New StopWordsRemover object </returns>
        public StopWordsRemover SetStopWords(string[] value) =>
            WrapAsStopWordsRemover(Reference.Invoke("setStopWords", (object)value));

        /// <summary>
        /// Gets caseSensitive value for <see cref="caseSensitive"/>
        /// </summary>
        /// <returns>
        /// caseSensitive: whether to do a case-sensitive comparison over the stop words
        /// </returns>
        public bool GetCaseSensitive() =>
            (bool)Reference.Invoke("getCaseSensitive");
        
        /// <summary>
        /// Gets inputCol value for <see cref="inputCol"/>
        /// </summary>
        /// <returns>
        /// inputCol: input column name
        /// </returns>
        public string GetInputCol() =>
            (string)Reference.Invoke("getInputCol");
        
        /// <summary>
        /// Gets inputCols value for <see cref="inputCols"/>
        /// </summary>
        /// <returns>
        /// inputCols: input column names
        /// </returns>
        public string[] GetInputCols() =>
            (string[])Reference.Invoke("getInputCols");
        
        /// <summary>
        /// Gets locale value for <see cref="locale"/>
        /// </summary>
        /// <returns>
        /// locale: Locale of the input for case insensitive matching. Ignored when caseSensitive is true.
        /// </returns>
        public string GetLocale() =>
            (string)Reference.Invoke("getLocale");
        
        /// <summary>
        /// Gets outputCol value for <see cref="outputCol"/>
        /// </summary>
        /// <returns>
        /// outputCol: output column name
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets outputCols value for <see cref="outputCols"/>
        /// </summary>
        /// <returns>
        /// outputCols: output column names
        /// </returns>
        public string[] GetOutputCols() =>
            (string[])Reference.Invoke("getOutputCols");
        
        /// <summary>
        /// Gets stopWords value for <see cref="stopWords"/>
        /// </summary>
        /// <returns>
        /// stopWords: the words to be filtered out
        /// </returns>
        public string[] GetStopWords() =>
            (string[])Reference.Invoke("getStopWords");

        /// <summary>
        /// Loads the <see cref="StopWordsRemover"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="StopWordsRemover"/> was saved to</param>
        /// <returns>New <see cref="StopWordsRemover"/> object, loaded from path.</returns>
        public static StopWordsRemover Load(string path) => WrapAsStopWordsRemover(
            SparkEnvironment.JvmBridge.CallStaticJavaMethod(s_stopWordsRemoverClassName, "load", path));
        
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
        public ScalaMLReader<StopWordsRemover> Read() =>
            new ScalaMLReader<StopWordsRemover>((JvmObjectReference)Reference.Invoke("read"));

        private static StopWordsRemover WrapAsStopWordsRemover(object obj) =>
            new StopWordsRemover((JvmObjectReference)obj);


    }
}

        