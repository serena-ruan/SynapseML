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
    /// <see cref="CountVectorizerModel"/> implements CountVectorizerModel
    /// </summary>
    public class CountVectorizerModel : ScalaModel<CountVectorizerModel>, ScalaMLWritable, ScalaMLReadable<CountVectorizerModel>
    {
        private static readonly string s_countVectorizerModelClassName = "org.apache.spark.ml.feature.CountVectorizerModel";

        /// <summary>
        /// Creates a <see cref="CountVectorizerModel"/> without any parameters.
        /// </summary>
        public CountVectorizerModel() : base(s_countVectorizerModelClassName)
        {
        }

        /// <summary>
        /// Creates a <see cref="CountVectorizerModel"/> with a UID that is used to give the
        /// <see cref="CountVectorizerModel"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public CountVectorizerModel(string uid) : base(s_countVectorizerModelClassName, uid)
        {
        }

        internal CountVectorizerModel(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets binary value for <see cref="binary"/>
        /// </summary>
        /// <param name="binary">
        /// If True, all non zero counts are set to 1.
        /// </param>
        /// <returns> New CountVectorizerModel object </returns>
        public CountVectorizerModel SetBinary(bool value) =>
            WrapAsCountVectorizerModel(Reference.Invoke("setBinary", (object)value));
        
        /// <summary>
        /// Sets inputCol value for <see cref="inputCol"/>
        /// </summary>
        /// <param name="inputCol">
        /// input column name
        /// </param>
        /// <returns> New CountVectorizerModel object </returns>
        public CountVectorizerModel SetInputCol(string value) =>
            WrapAsCountVectorizerModel(Reference.Invoke("setInputCol", (object)value));
        
        /// <summary>
        /// Sets maxDF value for <see cref="maxDF"/>
        /// </summary>
        /// <param name="maxDF">
        /// Specifies the maximum number of different documents a term could appear in to be included in the vocabulary. A term that appears more than the threshold will be ignored. If this is an integer >= 1, this specifies the maximum number of documents the term could appear in; if this is a double in [0,1), then this specifies the maximum fraction of documents the term could appear in.
        /// </param>
        /// <returns> New CountVectorizerModel object </returns>
        public CountVectorizerModel SetMaxDF(double value) =>
            WrapAsCountVectorizerModel(Reference.Invoke("setMaxDF", (object)value));
        
        /// <summary>
        /// Sets minDF value for <see cref="minDF"/>
        /// </summary>
        /// <param name="minDF">
        /// Specifies the minimum number of different documents a term must appear in to be included in the vocabulary. If this is an integer >= 1, this specifies the number of documents the term must appear in; if this is a double in [0,1), then this specifies the fraction of documents.
        /// </param>
        /// <returns> New CountVectorizerModel object </returns>
        public CountVectorizerModel SetMinDF(double value) =>
            WrapAsCountVectorizerModel(Reference.Invoke("setMinDF", (object)value));
        
        /// <summary>
        /// Sets minTF value for <see cref="minTF"/>
        /// </summary>
        /// <param name="minTF">
        /// Filter to ignore rare words in a document. For each document, terms with frequency/count less than the given threshold are ignored. If this is an integer >= 1, then this specifies a count (of times the term must appear in the document); if this is a double in [0,1), then this specifies a fraction (out of the document's token count). Note that the parameter is only used in transform of CountVectorizerModel and does not affect fitting.
        /// </param>
        /// <returns> New CountVectorizerModel object </returns>
        public CountVectorizerModel SetMinTF(double value) =>
            WrapAsCountVectorizerModel(Reference.Invoke("setMinTF", (object)value));
        
        /// <summary>
        /// Sets outputCol value for <see cref="outputCol"/>
        /// </summary>
        /// <param name="outputCol">
        /// output column name
        /// </param>
        /// <returns> New CountVectorizerModel object </returns>
        public CountVectorizerModel SetOutputCol(string value) =>
            WrapAsCountVectorizerModel(Reference.Invoke("setOutputCol", (object)value));
        
        /// <summary>
        /// Sets vocabSize value for <see cref="vocabSize"/>
        /// </summary>
        /// <param name="vocabSize">
        /// max size of the vocabulary
        /// </param>
        /// <returns> New CountVectorizerModel object </returns>
        public CountVectorizerModel SetVocabSize(int value) =>
            WrapAsCountVectorizerModel(Reference.Invoke("setVocabSize", (object)value));

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

        /// <summary>
        /// Loads the <see cref="CountVectorizerModel"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="CountVectorizerModel"/> was saved to</param>
        /// <returns>New <see cref="CountVectorizerModel"/> object, loaded from path.</returns>
        public static CountVectorizerModel Load(string path) => WrapAsCountVectorizerModel(
            SparkEnvironment.JvmBridge.CallStaticJavaMethod(s_countVectorizerModelClassName, "load", path));
        
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
        public ScalaMLReader<CountVectorizerModel> Read() =>
            new ScalaMLReader<CountVectorizerModel>((JvmObjectReference)Reference.Invoke("read"));

        private static CountVectorizerModel WrapAsCountVectorizerModel(object obj) =>
            new CountVectorizerModel((JvmObjectReference)obj);


    }
}

        