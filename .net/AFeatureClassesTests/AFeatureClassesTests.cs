using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Spark.ML.Feature;
using Microsoft.Spark.ML.Feature.Param;
using Microsoft.Spark.Sql;
using Microsoft.Spark.Sql.Types;
using Xunit;
using mmlspark.test.utils;
using Microsoft.Spark.Interop.Ipc;
using featurebase;
using org.apache.spark.ml.feature;

namespace org.apache.spark.ml.feature.test
{

    public class FeaturesFixture
    {
        public FeaturesFixture()
        {
            sparkFixture = new SparkFixture();
        }

        public SparkFixture sparkFixture { get; private set; }
    }

    public class FeaturesTests : IClassFixture<FeaturesFixture>
    {
        private readonly SparkSession _spark;
        private readonly IJvmBridge _jvm;
        public FeaturesTests(FeaturesFixture fixture)
        {
            _spark = fixture.sparkFixture.Spark;
            _jvm = fixture.sparkFixture.Jvm;
        }

        [Fact]
        public void TestBucketizer()
        {
            var expectedSplits =
                new double[] { double.MinValue, 0.0, 10.0, 50.0, double.MaxValue };

            string expectedHandle = "skip";
            string expectedUid = "uid";
            string expectedInputCol = "input_col";
            string expectedOutputCol = "output_col";

            var bucketizer = new featurebase.Bucketizer(expectedUid);
            bucketizer.SetInputCol(expectedInputCol)
                .SetOutputCol(expectedOutputCol)
                .SetHandleInvalid(expectedHandle)
                .SetSplits(expectedSplits);
            
            bucketizer.Write().Overwrite().Save("D:\\repos\\mmlspark\\.net\\AFeatureClassesTests\\models\\bucketizer.model");

            Assert.Equal(expectedHandle, bucketizer.GetHandleInvalid());

            Assert.Equal(expectedUid, bucketizer.Uid());

            DataFrame input = _spark.Sql("SELECT ID as input_col from range(100)");

            DataFrame output = bucketizer.Transform(input);
            Assert.Contains(output.Schema().Fields, (f => f.Name == expectedOutputCol));

            Assert.Equal(expectedInputCol, bucketizer.GetInputCol());
            Assert.Equal(expectedOutputCol, bucketizer.GetOutputCol());
            Assert.Equal(expectedSplits, bucketizer.GetSplits());
            
            using (var tempDirectory = new TemporaryDirectory())
            {
                string savePath = Path.Join(tempDirectory.Path, "bucket");
                bucketizer.Save(savePath);
                
                featurebase.Bucketizer loadedBucketizer = featurebase.Bucketizer.Load(savePath);
                Assert.Equal(bucketizer.Uid(), loadedBucketizer.Uid());
            }
            
            Assert.NotEmpty(bucketizer.ExplainParams());
            
            Param param = bucketizer.GetParam("handleInvalid");
            Assert.NotEmpty(param.Doc);
            Assert.NotEmpty(param.Name);
            Assert.Equal(param.Parent, bucketizer.Uid());

            Assert.NotEmpty(bucketizer.ExplainParam(param));
            bucketizer.Set(param, "keep");
            Assert.IsAssignableFrom<Identifiable>(bucketizer.Clear(param));

            Assert.IsType<string>(bucketizer.Uid());
        }

        [Fact]
        public void TestBucketizer_MultipleColumns()
        {
            var expectedSplitsArray = new double[][]
            {
                new[] { double.MinValue, 0.0, 10.0, 50.0, double.MaxValue},
                new[] { double.MinValue, 0.0, 10000.0, double.MaxValue}
            };

            string expectedHandle = "keep";

            var expectedInputCols = new List<string>() { "input_col_a", "input_col_b" };
            var expectedOutputCols = new List<string>() { "output_col_a", "output_col_b" };

            var bucketizer = new featurebase.Bucketizer();
            bucketizer.SetInputCols(expectedInputCols)
                .SetOutputCols(expectedOutputCols)
                .SetHandleInvalid(expectedHandle)
                .SetSplitsArray(expectedSplitsArray);

            Assert.Equal(expectedHandle, bucketizer.GetHandleInvalid());

            DataFrame input =
                _spark.Sql("SELECT ID as input_col_a, ID as input_col_b from range(100)");

            DataFrame output = bucketizer.Transform(input);
            Assert.Contains(output.Schema().Fields, (f => f.Name == "output_col_a"));
            Assert.Contains(output.Schema().Fields, (f => f.Name == "output_col_b"));

            Assert.Equal(expectedInputCols, bucketizer.GetInputCols());
            Assert.Equal(expectedOutputCols, bucketizer.GetOutputCols());
            Assert.Equal(expectedSplitsArray, bucketizer.GetSplitsArray());
        }

        [Fact]
        public void TestCountVectorizer()
        {
            DataFrame input = _spark.Sql("SELECT array('hello', 'I', 'AM', 'a', 'string', 'TO', " +
                "'TOKENIZE') as input from range(100)");

            const string inputColumn = "input";
            const string outputColumn = "output";
            const double minDf = 1;
            const double minTf = 10;
            const int vocabSize = 10000;
            const bool binary = false;
            
            var countVectorizer = new featurebase.CountVectorizer();
            
            countVectorizer
                .SetInputCol(inputColumn)
                .SetOutputCol(outputColumn)
                .SetMinDF(minDf)
                .SetMinTF(minTf)
                .SetVocabSize(vocabSize);
                
            Assert.IsType<featurebase.CountVectorizerModel>(countVectorizer.Fit(input));
            Assert.Equal(inputColumn, countVectorizer.GetInputCol());
            Assert.Equal(outputColumn, countVectorizer.GetOutputCol());
            Assert.Equal(minDf, countVectorizer.GetMinDF());
            Assert.Equal(minTf, countVectorizer.GetMinTF());
            Assert.Equal(vocabSize, countVectorizer.GetVocabSize());
            Assert.Equal(binary, countVectorizer.GetBinary());

            using (var tempDirectory = new TemporaryDirectory())
            {
                string savePath = Path.Join(tempDirectory.Path, "countVectorizer");
                countVectorizer.Save(savePath);
                
                featurebase.CountVectorizer loadedVectorizer = featurebase.CountVectorizer.Load(savePath);
                Assert.Equal(countVectorizer.Uid(), loadedVectorizer.Uid());
            }
            
            Assert.NotEmpty(countVectorizer.ExplainParams());
            Assert.NotEmpty(countVectorizer.ToString());
            
            Assert.NotEmpty(countVectorizer.ExplainParams());
            
            Param param = countVectorizer.GetParam("minDF");
            Assert.NotEmpty(param.Doc);
            Assert.NotEmpty(param.Name);
            Assert.Equal(param.Parent, countVectorizer.Uid());

            Assert.NotEmpty(countVectorizer.ExplainParam(param));
            countVectorizer.Set(param, 0.4);
            Assert.IsAssignableFrom<Identifiable>(countVectorizer.Clear(param));

            Assert.IsType<string>(countVectorizer.Uid());
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

            featurebase.FeatureHasher hasher = new featurebase.FeatureHasher()
                .SetInputCols(new List<string>() { "real", "bool", "stringNum", "string" })
                .SetOutputCol("features")
                .SetCategoricalCols(new string[] { "real", "string" })
                .SetNumFeatures(10);

            Assert.IsType<string>(hasher.GetOutputCol());
            Assert.IsType<string[]>(hasher.GetInputCols());
            Assert.IsType<string[]>(hasher.GetCategoricalCols());
            Assert.IsType<int>(hasher.GetNumFeatures());
            Assert.IsType<StructType>(hasher.TransformSchema(dataFrame.Schema()));
            Assert.IsType<DataFrame>(hasher.Transform(dataFrame));


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

        [Fact]
        public void TestHashingTF()
        {
            string expectedInputCol = "input_col";
            string expectedOutputCol = "output_col";
            int expectedFeatures = 10;

            Assert.IsType<featurebase.HashingTF>(new featurebase.HashingTF());
            
            featurebase.HashingTF hashingTf = new featurebase.HashingTF("my-unique-id")
                .SetNumFeatures(expectedFeatures)
                .SetInputCol(expectedInputCol)
                .SetOutputCol(expectedOutputCol);

            Assert.Equal(expectedFeatures, hashingTf.GetNumFeatures());
            Assert.Equal(expectedInputCol, hashingTf.GetInputCol());
            Assert.Equal(expectedOutputCol, hashingTf.GetOutputCol());

            DataFrame input = _spark.Sql("SELECT array('this', 'is', 'a', 'string', 'a', 'a')" +
                " as input_col");

            DataFrame output = hashingTf.Transform(input);
            DataFrame outputVector = output.Select(expectedOutputCol);
            
            Assert.Contains(expectedOutputCol, outputVector.Columns());
       
            using (var tempDirectory = new TemporaryDirectory())
            {
                string savePath = Path.Join(tempDirectory.Path, "hashingTF");
                hashingTf.Save(savePath);
                
                featurebase.HashingTF loadedHashingTf = featurebase.HashingTF.Load(savePath);
                Assert.Equal(hashingTf.Uid(), loadedHashingTf.Uid());
            }

            hashingTf.SetBinary(true);
            Assert.True(hashingTf.GetBinary());
            
            Assert.NotEmpty(hashingTf.ExplainParams());
            
            Param param = hashingTf.GetParam("numFeatures");
            Assert.NotEmpty(param.Doc);
            Assert.NotEmpty(param.Name);
            Assert.Equal(param.Parent, hashingTf.Uid());

            Assert.NotEmpty(hashingTf.ExplainParam(param));
            hashingTf.Set(param, 1000);
            Assert.IsAssignableFrom<Identifiable>(hashingTf.Clear(param));

            Assert.IsType<string>(hashingTf.Uid());
        }

        [Fact]
        public void TestNGram()
        {
            string expectedUid = "theUid";
            string expectedInputCol = "input_col";
            string expectedOutputCol = "output_col";
            int expectedN = 2;

            DataFrame input = _spark.Sql("SELECT split('Hi I heard about Spark', ' ') as input_col");

            featurebase.NGram nGram = new featurebase.NGram(expectedUid)
                .SetInputCol(expectedInputCol)
                .SetOutputCol(expectedOutputCol)
                .SetN(expectedN);

            StructType outputSchema = nGram.TransformSchema(input.Schema());

            DataFrame output = nGram.Transform(input);

            Assert.Contains(output.Schema().Fields, (f => f.Name == expectedOutputCol));
            Assert.Contains(outputSchema.Fields, (f => f.Name == expectedOutputCol));
            Assert.Equal(expectedInputCol, nGram.GetInputCol());
            Assert.Equal(expectedOutputCol, nGram.GetOutputCol());
            Assert.Equal(expectedN, nGram.GetN());

            using (var tempDirectory = new TemporaryDirectory())
            {
                string savePath = Path.Join(tempDirectory.Path, "NGram");
                nGram.Save(savePath);

                featurebase.NGram loadedNGram = featurebase.NGram.Load(savePath);
                Assert.Equal(nGram.Uid(), loadedNGram.Uid());
            }

            Assert.Equal(expectedUid, nGram.Uid());

            Assert.NotEmpty(nGram.ExplainParams());
            
            Param param = nGram.GetParam("inputCol");
            Assert.NotEmpty(param.Doc);
            Assert.NotEmpty(param.Name);
            Assert.Equal(param.Parent, nGram.Uid());

            Assert.NotEmpty(nGram.ExplainParam(param));
            nGram.Set(param, "input_col");
            Assert.IsAssignableFrom<Identifiable>(nGram.Clear(param));

            Assert.IsType<string>(nGram.Uid());
        }

        [Fact]
        public void TestSQLTransformer()
        {
            DataFrame input = _spark.CreateDataFrame(
                new List<GenericRow>
                {
                    new GenericRow(new object[] { 0, 1.0, 3.0 }),
                    new GenericRow(new object[] { 2, 2.0, 5.0 })
                },
                new StructType(new List<StructField>
                {
                    new StructField("id", new IntegerType()),
                    new StructField("v1", new DoubleType()),
                    new StructField("v2", new DoubleType())
                }));

            string expectedUid = "theUid";
            string inputStatement = "SELECT *, (v1 + v2) AS v3, (v1 * v2) AS v4 FROM __THIS__";

            featurebase.SQLTransformer sqlTransformer = new featurebase.SQLTransformer(expectedUid)
                .SetStatement(inputStatement);

            string outputStatement = sqlTransformer.GetStatement();

            DataFrame output = sqlTransformer.Transform(input);
            StructType outputSchema = sqlTransformer.TransformSchema(input.Schema());

            Assert.Contains(output.Schema().Fields, (f => f.Name == "v3"));
            Assert.Contains(output.Schema().Fields, (f => f.Name == "v4"));
            Assert.Contains(outputSchema.Fields, (f => f.Name == "v3"));
            Assert.Contains(outputSchema.Fields, (f => f.Name == "v4"));
            Assert.Equal(inputStatement, outputStatement);

            using (var tempDirectory = new TemporaryDirectory())
            {
                string savePath = Path.Join(tempDirectory.Path, "SQLTransformer");
                sqlTransformer.Save(savePath);

                featurebase.SQLTransformer loadedsqlTransformer = featurebase.SQLTransformer.Load(savePath);
                Assert.Equal(sqlTransformer.Uid(), loadedsqlTransformer.Uid());
            }
            Assert.Equal(expectedUid, sqlTransformer.Uid());
        }

        [Fact]
        public void TestSignaturesV2_3_X()
        {
            string expectedUid = "theUidWithOutLocale";
            string expectedInputCol = "input_col";
            string expectedOutputCol = "output_col";
            bool expectedCaseSensitive = false;
            var expectedStopWords = new string[] { "test1", "test2" };

            DataFrame input = _spark.Sql("SELECT split('Hi I heard about Spark', ' ') as input_col");

            featurebase.StopWordsRemover stopWordsRemover = new featurebase.StopWordsRemover(expectedUid)
                .SetInputCol(expectedInputCol)
                .SetOutputCol(expectedOutputCol)
                .SetCaseSensitive(expectedCaseSensitive)
                .SetStopWords(expectedStopWords);

            Assert.Equal(expectedUid, stopWordsRemover.Uid());
            Assert.Equal(expectedInputCol, stopWordsRemover.GetInputCol());
            Assert.Equal(expectedOutputCol, stopWordsRemover.GetOutputCol());
            Assert.Equal(expectedCaseSensitive, stopWordsRemover.GetCaseSensitive());
            Assert.Equal(expectedStopWords, stopWordsRemover.GetStopWords());
            // Assert.NotEmpty(featurebase.StopWordsRemover.LoadDefaultStopWords("english"));

            using (var tempDirectory = new TemporaryDirectory())
            {
                string savePath = Path.Join(tempDirectory.Path, "StopWordsRemover");
                stopWordsRemover.Save(savePath);

                featurebase.StopWordsRemover loadedStopWordsRemover = featurebase.StopWordsRemover.Load(savePath);
                Assert.Equal(stopWordsRemover.Uid(), loadedStopWordsRemover.Uid());
            }

            Assert.IsType<StructType>(stopWordsRemover.TransformSchema(input.Schema()));
            Assert.IsType<DataFrame>(stopWordsRemover.Transform(input));

            Assert.NotEmpty(stopWordsRemover.ExplainParams());
            
            Param param = stopWordsRemover.GetParam("inputCol");
            Assert.NotEmpty(param.Doc);
            Assert.NotEmpty(param.Name);
            Assert.Equal(param.Parent, stopWordsRemover.Uid());

            Assert.NotEmpty(stopWordsRemover.ExplainParam(param));
            stopWordsRemover.Set(param, "input_col");
            Assert.IsAssignableFrom<Identifiable>(stopWordsRemover.Clear(param));

            Assert.IsType<string>(stopWordsRemover.Uid());
        }

        [Fact]
        public void TestTokenizer()
        {
            string expectedUid = "theUid";
            string expectedInputCol = "input_col";
            string expectedOutputCol = "output_col";
            
            DataFrame input = _spark.Sql("SELECT 'hello I AM a string TO, TOKENIZE' as input_col" +
                " from range(100)");
            
            featurebase.Tokenizer tokenizer = new featurebase.Tokenizer(expectedUid)
                .SetInputCol(expectedInputCol)
                .SetOutputCol(expectedOutputCol);
            
            DataFrame output = tokenizer.Transform(input);
            
            Assert.Contains(output.Schema().Fields, (f => f.Name == expectedOutputCol));
            Assert.Equal(expectedInputCol, tokenizer.GetInputCol());
            Assert.Equal(expectedOutputCol, tokenizer.GetOutputCol());
            
            using (var tempDirectory = new TemporaryDirectory())
            {
                string savePath = Path.Join(tempDirectory.Path, "Tokenizer");
                tokenizer.Save(savePath);
                
                featurebase.Tokenizer loadedTokenizer = featurebase.Tokenizer.Load(savePath);
                Assert.Equal(tokenizer.Uid(), loadedTokenizer.Uid());
            }
            
            Assert.Equal(expectedUid, tokenizer.Uid());
            
            Assert.NotEmpty(tokenizer.ExplainParams());
            
            Param param = tokenizer.GetParam("inputCol");
            Assert.NotEmpty(param.Doc);
            Assert.NotEmpty(param.Name);
            Assert.Equal(param.Parent, tokenizer.Uid());

            Assert.NotEmpty(tokenizer.ExplainParam(param));
            tokenizer.Set(param, "input_col");
            Assert.IsAssignableFrom<Identifiable>(tokenizer.Clear(param));

            Assert.IsType<string>(tokenizer.Uid());
        }

    }
}
