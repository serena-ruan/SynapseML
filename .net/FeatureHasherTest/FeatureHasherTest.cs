using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Spark.ML.Feature;
using Microsoft.Spark.ML.Feature.Param;
using Microsoft.Spark.Sql;
using Microsoft.Spark.Sql.Types;
using Xunit;
using mmlspark.test.utils;
using org.apache.spark.ml.feature;

namespace org.apache.spark.ml.feature.test
{

    public class FeatureHasherFixture
    {
        public FeatureHasherFixture()
        {
            SparkFixture = new SparkFixture();
        }

        public SparkFixture SparkFixture { get; private set; }
    }

    public class FeatureHasherTests : IClassFixture<FeatureHasherFixture>
    {
        private readonly SparkSession _spark;
        public FeatureHasherTests(FeatureHasherFixture fixture)
        {
            _spark = fixture.SparkFixture.Spark;
        }

        [Fact]
        public void TestFeatureHasher()
        {
            DataFrame dataFrame = _spark.CreateDataFrame(
                new List<GenericRow>
                {
                    new GenericRow(new object[] { 2.0D, true, "1", "foo" }),
                    new GenericRow(new object[] { 3.0D, false, "2", "bar" })
                },
                new StructType(new List<StructField>
                {
                    new StructField("real", new DoubleType()),
                    new StructField("bool", new BooleanType()),
                    new StructField("stringNum", new StringType()),
                    new StructField("string", new StringType())
                }));

            FeatureHasher hasher = new FeatureHasher()
                .SetInputCols(new List<string>() { "real", "bool", "stringNum", "string" })
                .SetOutputCol("features")
                .SetCategoricalCols(new List<string>() { "real", "string" })
                .SetNumFeatures(10);

            Assert.IsType<string>(hasher.GetOutputCol());
            Assert.IsType<string[]>(hasher.GetInputCols());
            Assert.IsType<string[]>(hasher.GetCategoricalCols());
            Assert.IsType<int>(hasher.GetNumFeatures());
            Assert.IsType<StructType>(hasher.TransformSchema(dataFrame.Schema()));
            Assert.IsType<DataFrame>(hasher.Transform(dataFrame));

            // TestFeatureBase(hasher, "numFeatures", 1000);
            Assert.NotEmpty(hasher.ExplainParams());
            
            Param param = hasher.GetParam("numFeatures");
            Assert.NotEmpty(param.Doc);
            Assert.NotEmpty(param.Name);
            Assert.Equal(param.Parent, hasher.Uid());

            Assert.NotEmpty(hasher.ExplainParam(param));
            hasher.Set(param, 1000);
            Assert.IsAssignableFrom<Identifiable>(hasher.Clear(param));

            Assert.IsType<string>(hasher.Uid());
        }

    }
}
