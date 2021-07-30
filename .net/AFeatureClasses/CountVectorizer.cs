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
    /// <see cref="CountVectorizer"/> implements CountVectorizer
    /// </summary>
    public class CountVectorizer : ScalaEstimator<CountVectorizer, CountVectorizerModel>
    {
        private static readonly string s_countVectorizerClassName = "org.apache.spark.ml.feature.CountVectorizer";

        /// <summary>
        /// Creates a <see cref="CountVectorizer"/> without any parameters.
        /// </summary>
        public CountVectorizer() : base(s_countVectorizerClassName)
        {
        }

        /// <summary>
        /// Creates a <see cref="CountVectorizer"/> with a UID that is used to give the
        /// <see cref="CountVectorizer"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public CountVectorizer(string uid) : base(s_countVectorizerClassName, uid)
        {
        }

        internal CountVectorizer(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets binary value for <see cref="binary"/>
        /// </summary>
        /// <param name="binary">
        /// If True, all non zero counts are set to 1.
        /// </param>
        /// <returns> New CountVectorizer object </returns>
        public CountVectorizer SetBinary(bool value) =>
            WrapAsCountVectorizer(Reference.Invoke("setBinary", value));
        
        /// <summary>
        /// Sets inputCol value for <see cref="inputCol"/>
        /// </summary>
        /// <param name="inputCol">
        /// input column name
        /// </param>
        /// <returns> New CountVectorizer object </returns>
        public CountVectorizer SetInputCol(string value) =>
            WrapAsCountVectorizer(Reference.Invoke("setInputCol", value));
        
        /// <summary>
        /// Sets maxDF value for <see cref="maxDF"/>
        /// </summary>
        /// <param name="maxDF">
        /// Specifies the maximum number of different documents a term could appear in to be included in the vocabulary. A term that appears more than the threshold will be ignored. If this is an integer >= 1, this specifies the maximum number of documents the term could appear in; if this is a double in [0,1), then this specifies the maximum fraction of documents the term could appear in.
        /// </param>
        /// <returns> New CountVectorizer object </returns>
        public CountVectorizer SetMaxDF(double value) =>
            WrapAsCountVectorizer(Reference.Invoke("setMaxDF", value));
        
        /// <summary>
        /// Sets minDF value for <see cref="minDF"/>
        /// </summary>
        /// <param name="minDF">
        /// Specifies the minimum number of different documents a term must appear in to be included in the vocabulary. If this is an integer >= 1, this specifies the number of documents the term must appear in; if this is a double in [0,1), then this specifies the fraction of documents.
        /// </param>
        /// <returns> New CountVectorizer object </returns>
        public CountVectorizer SetMinDF(double value) =>
            WrapAsCountVectorizer(Reference.Invoke("setMinDF", value));
        
        /// <summary>
        /// Sets minTF value for <see cref="minTF"/>
        /// </summary>
        /// <param name="minTF">
        /// Filter to ignore rare words in a document. For each document, terms with frequency/count less than the given threshold are ignored. If this is an integer >= 1, then this specifies a count (of times the term must appear in the document); if this is a double in [0,1), then this specifies a fraction (out of the document's token count). Note that the parameter is only used in transform of CountVectorizerModel and does not affect fitting.
        /// </param>
        /// <returns> New CountVectorizer object </returns>
        public CountVectorizer SetMinTF(double value) =>
            WrapAsCountVectorizer(Reference.Invoke("setMinTF", value));
        
        /// <summary>
        /// Sets outputCol value for <see cref="outputCol"/>
        /// </summary>
        /// <param name="outputCol">
        /// output column name
        /// </param>
        /// <returns> New CountVectorizer object </returns>
        public CountVectorizer SetOutputCol(string value) =>
            WrapAsCountVectorizer(Reference.Invoke("setOutputCol", value));
        
        /// <summary>
        /// Sets vocabSize value for <see cref="vocabSize"/>
        /// </summary>
        /// <param name="vocabSize">
        /// max size of the vocabulary
        /// </param>
        /// <returns> New CountVectorizer object </returns>
        public CountVectorizer SetVocabSize(int value) =>
            WrapAsCountVectorizer(Reference.Invoke("setVocabSize", value));

        /// <summary>
        /// Gets binary value for <see cref="binary"/>
        /// </summary>
        /// <returns>
        /// binary: If True, all non zero counts are set to 1.
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
        /// Gets maxDF value for <see cref="maxDF"/>
        /// </summary>
        /// <returns>
        /// maxDF: Specifies the maximum number of different documents a term could appear in to be included in the vocabulary. A term that appears more than the threshold will be ignored. If this is an integer >= 1, this specifies the maximum number of documents the term could appear in; if this is a double in [0,1), then this specifies the maximum fraction of documents the term could appear in.
        /// </returns>
        public double GetMaxDF() =>
            (double)Reference.Invoke("getMaxDF");
        
        /// <summary>
        /// Gets minDF value for <see cref="minDF"/>
        /// </summary>
        /// <returns>
        /// minDF: Specifies the minimum number of different documents a term must appear in to be included in the vocabulary. If this is an integer >= 1, this specifies the number of documents the term must appear in; if this is a double in [0,1), then this specifies the fraction of documents.
        /// </returns>
        public double GetMinDF() =>
            (double)Reference.Invoke("getMinDF");
        
        /// <summary>
        /// Gets minTF value for <see cref="minTF"/>
        /// </summary>
        /// <returns>
        /// minTF: Filter to ignore rare words in a document. For each document, terms with frequency/count less than the given threshold are ignored. If this is an integer >= 1, then this specifies a count (of times the term must appear in the document); if this is a double in [0,1), then this specifies a fraction (out of the document's token count). Note that the parameter is only used in transform of CountVectorizerModel and does not affect fitting.
        /// </returns>
        public double GetMinTF() =>
            (double)Reference.Invoke("getMinTF");
        
        /// <summary>
        /// Gets outputCol value for <see cref="outputCol"/>
        /// </summary>
        /// <returns>
        /// outputCol: output column name
        /// </returns>
        public string GetOutputCol() =>
            (string)Reference.Invoke("getOutputCol");
        
        /// <summary>
        /// Gets vocabSize value for <see cref="vocabSize"/>
        /// </summary>
        /// <returns>
        /// vocabSize: max size of the vocabulary
        /// </returns>
        public int GetVocabSize() =>
            (int)Reference.Invoke("getVocabSize");

        /// <summary>Fits a model to the input data.</summary>
        /// <param name="dataset">The <see cref="DataFrame"/> to fit the model to.</param>
        /// <returns><see cref="CountVectorizerModel"/></returns>
        override public CountVectorizerModel Fit(DataFrame dataset) =>
            new CountVectorizerModel((JvmObjectReference)Reference.Invoke("fit", dataset));

        /// <summary>
        /// Loads the <see cref="CountVectorizer"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="CountVectorizer"/> was saved to</param>
        /// <returns>New <see cref="CountVectorizer"/> object, loaded from path.</returns>
        public static CountVectorizer Load(string path) => WrapAsCountVectorizer(
            SparkEnvironment.JvmBridge.CallStaticJavaMethod(s_countVectorizerClassName, "load", path));

        private static CountVectorizer WrapAsCountVectorizer(object obj) =>
            new CountVectorizer((JvmObjectReference)obj);


    }
}

        