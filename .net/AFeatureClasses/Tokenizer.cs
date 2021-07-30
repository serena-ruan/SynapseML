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
    /// <see cref="Tokenizer"/> implements Tokenizer
    /// </summary>
    public class Tokenizer : ScalaTransformer<Tokenizer>
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
            WrapAsTokenizer(Reference.Invoke("setInputCol", value));
        
        /// <summary>
        /// Sets outputCol value for <see cref="outputCol"/>
        /// </summary>
        /// <param name="outputCol">
        /// output column name
        /// </param>
        /// <returns> New Tokenizer object </returns>
        public Tokenizer SetOutputCol(string value) =>
            WrapAsTokenizer(Reference.Invoke("setOutputCol", value));

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
        /// Executes the <see cref="Tokenizer"/> and transforms the DataFrame to include new columns.
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
        /// Loads the <see cref="Tokenizer"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="Tokenizer"/> was saved to</param>
        /// <returns>New <see cref="Tokenizer"/> object, loaded from path.</returns>
        public static Tokenizer Load(string path) => WrapAsTokenizer(
            SparkEnvironment.JvmBridge.CallStaticJavaMethod(s_tokenizerClassName, "load", path));

        private static Tokenizer WrapAsTokenizer(object obj) =>
            new Tokenizer((JvmObjectReference)obj);


    }
}

        