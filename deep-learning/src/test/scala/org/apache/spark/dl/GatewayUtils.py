# Copyright (C) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See LICENSE in project root for information.

class GatewayUtils:

    def setGateway(self, value):
        self.gateway = value

    def getGateway(self):
        return self.gateway
    
    def _get_active_spark_context(self):
        import logging
        from pyspark.conf import SparkConf
        from pyspark.context import SparkContext

        sparkContext = self.gateway.jvm.SparkSession.getActiveSession().get().sparkContext()
        jconf = sparkContext.getConf()
        logging.debug(f"java spark conf: {jconf}")
        sparkConf = SparkConf(_jconf=jconf)
        jsc = self.gateway.jvm.JavaSparkContext(sparkContext)
        logging.debug(f"java spark context: {jsc}")
        sparkContext = SparkContext(conf=sparkConf, gateway=self.gateway, jsc=jsc)
        logging.debug(f"Spark Context: {sparkContext}")

        return sparkContext
    
    # should only be called after the jvm is booted up
    def updateGatewayImports(self):
        from py4j.java_gateway import java_import
        # Add namespaces
        java_import(self.gateway.jvm, "org.apache.spark.SparkConf")
        java_import(self.gateway.jvm, "org.apache.spark.api.java.*")
        java_import(self.gateway.jvm, "org.apache.spark.api.python.*")
        java_import(self.gateway.jvm, "org.apache.spark.ml.python.*")
        java_import(self.gateway.jvm, "org.apache.spark.mllib.api.python.*")
        java_import(self.gateway.jvm, "org.apache.spark.resource.*")
        java_import(self.gateway.jvm, "org.apache.spark.sql.*")
        java_import(self.gateway.jvm, "org.apache.spark.sql.api.python.*")
        java_import(self.gateway.jvm, "org.apache.spark.sql.hive.*")
        java_import(self.gateway.jvm, "scala.Tuple2")
    
    def shutdownPython(self):
        self.gateway.shutdown()
