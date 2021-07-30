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
    /// <see cref="CountVectorizerModel"/> implements CountVectorizerModel
    /// </summary>
    public class CountVectorizerModel : ScalaModel<CountVectorizerModel>
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
            WrapAsCountVectorizerModel(Reference.Invoke("setBinary", value));
        
        /// <summary>
        /// Sets inputCol value for <see cref="inputCol"/>
        /// </summary>
        /// <param name="inputCol">
        /// input column name
        /// </param>
        /// <returns> New CountVectorizerModel object </returns>
        public CountVectorizerModel SetInputCol(string value) =>
            WrapAsCountVectorizerModel(Reference.Invoke("setInputCol", value));
        
        /// <summary>
        /// Sets maxDF value for <see cref="maxDF"/>
        /// </summary>
        /// <param name="maxDF">
        /// Specifies the maximum number of different documents a term could appear in to be included in the vocabulary. A term that appears more than the threshold will be ignored. If this is an integer >= 1, this specifies the maximum number of documents the term could appear in; if this is a double in [0,1), then this specifies the maximum fraction of documents the term could appear in.
        /// </param>
        /// <returns> New CountVectorizerModel object </returns>
        public CountVectorizerModel SetMaxDF(double value) =>
            WrapAsCountVectorizerModel(Reference.Invoke("setMaxDF", value));
        
        /// <summary>
        /// Sets minDF value for <see cref="minDF"/>
        /// </summary>
        /// <param name="minDF">
        /// Specifies the minimum number of different documents a term must appear in to be included in the vocabulary. If this is an integer >= 1, this specifies the number of documents the term must appear in; if this is a double in [0,1), then this specifies the fraction of documents.
        /// </param>
        /// <returns> New CountVectorizerModel object </returns>
        public CountVectorizerModel SetMinDF(double value) =>
            WrapAsCountVectorizerModel(Reference.Invoke("setMinDF", value));
        
        /// <summary>
        /// Sets minTF value for <see cref="minTF"/>
        /// </summary>
        /// <param name="minTF">
        /// Filter to ignore rare words in a document. For each document, terms with frequency/count less than the given threshold are ignored. If this is an integer >= 1, then this specifies a count (of times the term must appear in the document); if this is a double in [0,1), then this specifies a fraction (out of the document's token count). Note that the parameter is only used in transform of CountVectorizerModel and does not affect fitting.
        /// </param>
        /// <returns> New CountVectorizerModel object </returns>
        public CountVectorizerModel SetMinTF(double value) =>
            WrapAsCountVectorizerModel(Reference.Invoke("setMinTF", value));
        
        /// <summary>
        /// Sets outputCol value for <see cref="outputCol"/>
        /// </summary>
        /// <param name="outputCol">
        /// output column name
        /// </param>
        /// <returns> New CountVectorizerModel object </returns>
        public CountVectorizerModel SetOutputCol(string value) =>
            WrapAsCountVectorizerModel(Reference.Invoke("setOutputCol", value));
        
        /// <summary>
        /// Sets vocabSize value for <see cref="vocabSize"/>
        /// </summary>
        /// <param name="vocabSize">
        /// max size of the vocabulary
        /// </param>
        /// <returns> New CountVectorizerModel object </returns>
        public CountVectorizerModel SetVocabSize(int value) =>
            WrapAsCountVectorizerModel(Reference.Invoke("setVocabSize", value));

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
        /// Executes the <see cref="CountVectorizerModel"/> and transforms the DataFrame to include new columns.
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
        /// Loads the <see cref="CountVectorizerModel"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="CountVectorizerModel"/> was saved to</param>
        /// <returns>New <see cref="CountVectorizerModel"/> object, loaded from path.</returns>
        public static CountVectorizerModel Load(string path) => WrapAsCountVectorizerModel(
            SparkEnvironment.JvmBridge.CallStaticJavaMethod(s_countVectorizerModelClassName, "load", path));

        private static CountVectorizerModel WrapAsCountVectorizerModel(object obj) =>
            new CountVectorizerModel((JvmObjectReference)obj);


    }
}

        