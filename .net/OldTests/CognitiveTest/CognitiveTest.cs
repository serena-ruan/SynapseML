using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Spark.Sql;
using Microsoft.Spark.Sql.Types;
using Xunit;
using mmlspark.test.utils;

namespace mmlspark.cognitive.test
{

    public class TestFixture
    {
        public TestFixture()
        {
            SparkFixture = new SparkFixture();
        }

        public SparkFixture SparkFixture { get; private set; }
    }

    public class TextSentimentTests : IClassFixture<TestFixture>
    {

        private readonly SparkSession _spark;
        public TextSentimentTests(TestFixture fixture)
        {
            _spark = fixture.SparkFixture.Spark;
        }

        [Fact]
        public void TestTextSentiment()
        {
            DataFrame df = _spark.CreateDataFrame(
                new List<GenericRow>
                {
                    new GenericRow(new object[] {"en", "Hello world. This is some input text that I love."}),
                    new GenericRow(new object[] {"fr", "Bonjour tout le monde"}),
                    new GenericRow(new object[] {null, "ich bin ein berliner"}),
                    new GenericRow(new object[] {null, null}),
                    new GenericRow(new object[] {"en", null})
                },
                new StructType(new List<StructField>
                {
                    new StructField("lang", new StringType()),
                    new StructField("text", new StringType())
                })
            );

            TextSentiment textSentiment = new TextSentiment()
                .SetSubscriptionKey("df74b0018d394ca0ab2173f3623ca7a1")
                .SetLocation("eastus")
                .SetLanguageCol("lang")
                .SetModelVersion("latest")
                .SetShowStats(true)
                .SetOutputCol("replies");
            
            DataFrame result = textSentiment
                .Transform(df)
                .Select("replies")
                .Alias("scoredDocuments");

            result.Show();
            
            List<Row> rows = result.Collect().ToList();

            Assert.True(rows[3].Get(0) == null);
            Assert.True(rows[4].Get(0) == null);
        }

    }

}
