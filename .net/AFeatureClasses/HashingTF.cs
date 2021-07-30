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
    /// <see cref="HashingTF"/> implements HashingTF
    /// </summary>
    public class HashingTF : ScalaTransformer<HashingTF>
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
            WrapAsHashingTF(Reference.Invoke("setBinary", value));
        
        /// <summary>
        /// Sets inputCol value for <see cref="inputCol"/>
        /// </summary>
        /// <param name="inputCol">
        /// input column name
        /// </param>
        /// <returns> New HashingTF object </returns>
        public HashingTF SetInputCol(string value) =>
            WrapAsHashingTF(Reference.Invoke("setInputCol", value));
        
        /// <summary>
        /// Sets numFeatures value for <see cref="numFeatures"/>
        /// </summary>
        /// <param name="numFeatures">
        /// Number of features. Should be greater than 0
        /// </param>
        /// <returns> New HashingTF object </returns>
        public HashingTF SetNumFeatures(int value) =>
            WrapAsHashingTF(Reference.Invoke("setNumFeatures", value));
        
        /// <summary>
        /// Sets outputCol value for <see cref="outputCol"/>
        /// </summary>
        /// <param name="outputCol">
        /// output column name
        /// </param>
        /// <returns> New HashingTF object </returns>
        public HashingTF SetOutputCol(string value) =>
            WrapAsHashingTF(Reference.Invoke("setOutputCol", value));

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
        /// Executes the <see cref="HashingTF"/> and transforms the DataFrame to include new columns.
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
        /// Loads the <see cref="HashingTF"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="HashingTF"/> was saved to</param>
        /// <returns>New <see cref="HashingTF"/> object, loaded from path.</returns>
        public static HashingTF Load(string path) => WrapAsHashingTF(
            SparkEnvironment.JvmBridge.CallStaticJavaMethod(s_hashingTFClassName, "load", path));

        private static HashingTF WrapAsHashingTF(object obj) =>
            new HashingTF((JvmObjectReference)obj);


    }
}

        