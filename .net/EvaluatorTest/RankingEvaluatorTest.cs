using System;
using System.Linq;
using System.Collections.Generic;
using mmlspark.test.utils;
using Microsoft.Spark.Sql;
using Microsoft.Spark.Sql.Types;
using Xunit;
using mmlspark.core.recommendation;

namespace EvaluatorTest
{

    public class TestFixture
    {
        public TestFixture()
        {
            SparkFixture = new SparkFixture();
        }

        public SparkFixture SparkFixture { get; private set; }
    }

    public class RankingEvaluatorTests : IClassFixture<TestFixture>
    {
        private readonly SparkSession _spark;
        public RankingEvaluatorTests(TestFixture fixture)
        {
            _spark = fixture.SparkFixture.Spark;
        }

        [Fact]
        public void TestRankingEvaluator()
        {
            DataFrame df = _spark.CreateDataFrame(
                new List<GenericRow>
                {
                    new GenericRow(new object[] {new int[] {1, 2, 3}, new int[] {1, 2, 3}})
                },
                new StructType(new List<StructField>
                {
                    new StructField("prediction", new ArrayType(new IntegerType())),
                    new StructField("label", new ArrayType(new IntegerType()))
                })
            );

            RankingEvaluator rankingEvaluator = new RankingEvaluator()
                .SetK(3)
                .SetNItems(3);
            
            Double result = rankingEvaluator.Evaluate(df);
            
        }
    }
}
