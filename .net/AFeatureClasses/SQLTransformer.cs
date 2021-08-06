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
    /// <see cref="SQLTransformer"/> implements SQLTransformer
    /// </summary>
    public class SQLTransformer : ScalaTransformer<SQLTransformer>, ScalaMLWritable, ScalaMLReadable<SQLTransformer>
    {
        private static readonly string s_sQLTransformerClassName = "org.apache.spark.ml.feature.SQLTransformer";

        /// <summary>
        /// Creates a <see cref="SQLTransformer"/> without any parameters.
        /// </summary>
        public SQLTransformer() : base(s_sQLTransformerClassName)
        {
        }

        /// <summary>
        /// Creates a <see cref="SQLTransformer"/> with a UID that is used to give the
        /// <see cref="SQLTransformer"/> a unique ID.
        /// </summary>
        /// <param name="uid">An immutable unique ID for the object and its derivatives.</param>
        public SQLTransformer(string uid) : base(s_sQLTransformerClassName, uid)
        {
        }

        internal SQLTransformer(JvmObjectReference jvmObject) : base(jvmObject)
        {
        }

        /// <summary>
        /// Sets statement value for <see cref="statement"/>
        /// </summary>
        /// <param name="statement">
        /// SQL statement
        /// </param>
        /// <returns> New SQLTransformer object </returns>
        public SQLTransformer SetStatement(string value) =>
            WrapAsSQLTransformer(Reference.Invoke("setStatement", (object)value));

        /// <summary>
        /// Gets statement value for <see cref="statement"/>
        /// </summary>
        /// <returns>
        /// statement: SQL statement
        /// </returns>
        public string GetStatement() =>
            (string)Reference.Invoke("getStatement");

        /// <summary>
        /// Loads the <see cref="SQLTransformer"/> that was previously saved using Save(string).
        /// </summary>
        /// <param name="path">The path the previous <see cref="SQLTransformer"/> was saved to</param>
        /// <returns>New <see cref="SQLTransformer"/> object, loaded from path.</returns>
        public static SQLTransformer Load(string path) => WrapAsSQLTransformer(
            SparkEnvironment.JvmBridge.CallStaticJavaMethod(s_sQLTransformerClassName, "load", path));
        
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
        public ScalaMLReader<SQLTransformer> Read() =>
            new ScalaMLReader<SQLTransformer>((JvmObjectReference)Reference.Invoke("read"));

        private static SQLTransformer WrapAsSQLTransformer(object obj) =>
            new SQLTransformer((JvmObjectReference)obj);


    }
}

        