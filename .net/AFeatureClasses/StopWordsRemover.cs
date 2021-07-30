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
    /// <see cref="StopWordsRemover"/> implements StopWordsRemover
    /// </summary>
    public class StopWordsRemover : ScalaTransformer<StopWordsRemover>
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
            WrapAsStopWordsRemover(Reference.Invoke("setCaseSensitive", value));
        
        /// <summary>
        /// Sets inputCol value for <see cref="inputCol"/>
        /// </summary>
        /// <param name="inputCol">
        /// input column name
        /// </param>
        /// <returns> New StopWordsRemover object </returns>
        public StopWordsRemover SetInputCol(string value) =>
            WrapAsStopWordsRemover(Reference.Invoke("setInputCol", value));
        
        /// <summary>
        /// Sets inputCols value for <see cref="inputCols"/>
        /// </summary>
        /// <param name="inputCols">
        /// input column names
        /// </param>
        /// <returns> New StopWordsRemover object </returns>
        public StopWordsRemover SetInputCols(IEnumerable<string> value) =>
            WrapAsStopWordsRemover(Reference.Invoke("setInputCols", value));
        
        /// <summary>
        /// Sets locale value for <see cref="locale"/>
        /// </summary>
        /// <param name="locale">
        /// Locale of the input for case insensitive matching. Ignored when caseSensitive is true.
        /// </param>
        /// <returns> New StopWordsRemover object </returns>
        public StopWordsRemover SetLocale(string value) =>
            WrapAsStopWordsRemover(Reference.Invoke("setLocale", value));
        
        /// <summary>
        /// Sets outputCol value for <see cref="outputCol"/>
        /// </summary>
        /// <param name="outputCol">
        /// output column name
        /// </param>
        /// <returns> New StopWordsRemover object </returns>
        public StopWordsRemover SetOutputCol(string value) =>
            WrapAsStopWordsRemover(Reference.Invoke("setOutputCol", value));
        
        /// <summary>
        /// Sets outputCols value for <see cref="outputCols"/>
        /// </summary>
        /// <param name="outputCols">
        /// output column names
        /// </param>
        /// <returns> New StopWordsRemover object </returns>
        public StopWordsRemover SetOutputCols(IEnumerable<string> value) =>
            WrapAsStopWordsRemover(Reference.Invoke("setOutputCols", value));
        
        /// <summary>
        /// Sets stopWords value for <see cref="stopWords"/>
        /// </summary>
        /// <param name="stopWords">
        /// the words to be filtered out
        /// </param>
        /// <returns> New StopWordsRemover object </returns>
        public StopWordsRemover SetStopWords(IEnumerable<string> value) =>
            WrapAsStopWordsRemover(Reference.Invoke("setStopWords", value));

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
        public IEnumerable<string> GetInputCols() =>
            (IEnumerable<string>)Reference.Invoke("getInputCols");
        
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
        public IEnumerable<string> GetOutputCols() =>
            (IEnumerable<string>)Reference.Invoke("getOutputCols");
        
        /// <summary>
        /// Gets stopWords value for <see cref="stopWords"/>
        /// </summary>
        /// <returns>
        /// stopWords: the words to be filtered out
        /// </returns>
        public IEnumerable<string> GetStopWords() =>
            (IEnumerable<string>)Reference.Invoke("getStopWords");

        /// <summary>
        /// Executes the <see cref="StopWordsRemover"/> and transforms the DataFrame to include new columns.
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
        /// Loads the <see cref="StopWordsRemover"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="StopWordsRemover"/> was saved to</param>
        /// <returns>New <see cref="StopWordsRemover"/> object, loaded from path.</returns>
        public static StopWordsRemover Load(string path) => WrapAsStopWordsRemover(
            SparkEnvironment.JvmBridge.CallStaticJavaMethod(s_stopWordsRemoverClassName, "load", path));

        private static StopWordsRemover WrapAsStopWordsRemover(object obj) =>
            new StopWordsRemover((JvmObjectReference)obj);


    }
}

        