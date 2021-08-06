// Copyright (C) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in project root for information.

using System;
using System.Collections.Generic;
using Microsoft.Spark.Sql;
using Microsoft.Spark.Sql.Types;
using Xunit;
using mmlspark.test.utils;

namespace mmlspark.stages.test
{
    public class SelectColumnsFixture
    {
        public SelectColumnsFixture()
        {
            SparkFixture = new SparkFixture();
        }

        public SparkFixture SparkFixture { get; private set; }
    }

    // [Collection("SelectColumns Test")]
    public class SelectColumnsTests : IClassFixture<SelectColumnsFixture>
    {
        private readonly SparkSession _spark;
        public SelectColumnsTests(SelectColumnsFixture fixture)
        {
            _spark = fixture.SparkFixture.Spark;
        }

        /// <summary>
        /// Create a <see cref="DataFrame"/>, create a <see cref="SelectColumns"/> and test the
        /// available methods. Test the SelectColumns methods using <see cref="SelectColumnsTests"/>.
        /// </summary>
        [Fact]
        public void TestSelectColumns()
        {
            
            DataFrame input = _spark.CreateDataFrame(
                new List<GenericRow>
                {
                    new GenericRow(new object[] {0, 0.0D, "guitars", "drums", 1L, true}),
                    new GenericRow(new object[] {1, 1.0D, "piano", "trumpet", 2L, false}),
                    new GenericRow(new object[] {2, 2.0D, "bass", "cymbals", 3L, true})
                },
                new StructType(new List<StructField>
                {
                    new StructField("numbers", new IntegerType()),
                    new StructField("doubles", new DoubleType()),
                    new StructField("words", new StringType()),
                    new StructField("more", new StringType()),
                    new StructField("longs", new LongType()),
                    new StructField("booleans", new BooleanType())
                })
            );

            SelectColumns selectColumns = new SelectColumns()
                .SetCols(new List<string> {"numbers", "doubles", "words", "more", "longs", "booleans"});
            
            DataFrame result = selectColumns.Transform(input);
            
            Assert.IsType<string[]>(selectColumns.GetCols());
            Assert.True(String.Join(",", selectColumns.GetCols()) == String.Join(",", new string[]{"numbers", "doubles", "words", "more", "longs", "booleans"}));
            Assert.Equal<int>(3, (int)result.Count());
            Assert.Equal<int>(6, result.Schema().Fields.Count);
        }

    }

}
