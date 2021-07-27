using System;
using System.Linq;
using System.Collections.Generic;
using mmlspark.core.featurize.text;
using mmlspark.test.utils;
using Microsoft.Spark.Sql;
using Microsoft.Spark.Sql.Types;
using Xunit;

namespace EstimatorTest
{

    public class TestFixture
    {
        public TestFixture()
        {
            SparkFixture = new SparkFixture();
        }

        public SparkFixture SparkFixture { get; private set; }
    }

    public class TextFeaturizerTests : IClassFixture<TestFixture>
    {
        private readonly SparkSession _spark;
        public TextFeaturizerTests(TestFixture fixture)
        {
            _spark = fixture.SparkFixture.Spark;
        }

        [Fact]
        public void TestTextFeaturizer()
        {
            DataFrame dfRaw = _spark.CreateDataFrame(
                new List<GenericRow>
                {
                    new GenericRow(new object[] {0, "Hi I"}),
                    new GenericRow(new object[] {1, "I wish for snow today"}),
                    new GenericRow(new object[] {2, "we Cant go to the park, because of the snow!"}),
                    new GenericRow(new object[] {3, ""})
                },
                new StructType(new List<StructField>
                {
                    new StructField("label", new IntegerType()),
                    new StructField("sentence", new StringType())
                })
            );

            TextFeaturizer textFeaturizer = new TextFeaturizer()
                .SetInputCol("sentence")
                .SetOutputCol("features")
                .SetNumFeatures(20);
            
            DataFrame result = textFeaturizer.Fit(dfRaw).Transform(dfRaw);

            result.Show(truncate: 100);
        }
    }
}
