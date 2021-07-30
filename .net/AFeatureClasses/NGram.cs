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
    /// <see cref="NGram"/> implements NGram
    /// </summary>
    public class NGram : ScalaTransformer<NGram>
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
            WrapAsNGram(Reference.Invoke("setInputCol", value));
        
        /// <summary>
        /// Sets n value for <see cref="n"/>
        /// </summary>
        /// <param name="n">
        /// number elements per n-gram (>=1)
        /// </param>
        /// <returns> New NGram object </returns>
        public NGram SetN(int value) =>
            WrapAsNGram(Reference.Invoke("setN", value));
        
        /// <summary>
        /// Sets outputCol value for <see cref="outputCol"/>
        /// </summary>
        /// <param name="outputCol">
        /// output column name
        /// </param>
        /// <returns> New NGram object </returns>
        public NGram SetOutputCol(string value) =>
            WrapAsNGram(Reference.Invoke("setOutputCol", value));

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
        /// Executes the <see cref="NGram"/> and transforms the DataFrame to include new columns.
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
        /// Loads the <see cref="NGram"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="NGram"/> was saved to</param>
        /// <returns>New <see cref="NGram"/> object, loaded from path.</returns>
        public static NGram Load(string path) => WrapAsNGram(
            SparkEnvironment.JvmBridge.CallStaticJavaMethod(s_nGramClassName, "load", path));

        private static NGram WrapAsNGram(object obj) =>
            new NGram((JvmObjectReference)obj);


    }
}

        