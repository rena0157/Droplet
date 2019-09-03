// SubAreaTests.cs
// By: Adam Renaud
// Created: 2019-08-21

using System;
using Xunit;
using Xunit.Abstractions;
using Droplet.Core.Inp.Entities;
using Droplet.Core.Inp.Parsers;
using System.Collections.Generic;
using System.Collections;
using Droplet.Core.Inp;

namespace InpLibTests.Entities
{
    /// <summary>
    /// Tests for the <see cref="SubArea"/> class
    /// </summary>
    public class SubAreaTests : InpFileTests
    {
        /// <summary>
        /// Default constructor that takes in a logger from xunit
        /// </summary>
        /// <param name="logger">The logger that is passed from xunit</param>
        public SubAreaTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #region Tests

        /// <summary>
        /// Tests for the parser of the subarea class
        /// </summary>
        /// <param name="s">The string that represents the string from an inp file</param>
        /// <param name="expectedSubArea">The expected subarea from the string provided</param>
        [Theory]
        [ClassData(typeof(ParserTestData))]
        public void ParserTests(string s, SubArea expectedSubArea)
        {
            FileLinesFromString(s);
            var project = new InpProject();
            var subcatchment = new Subcatchment()
            {
                Name = "1"
            };
            project.Entities.Add(subcatchment);

            var parser = new InpTableSection(project, "SUBAREAS");
            parser.ReadSection(this);

            Assert.Equal(expectedSubArea, subcatchment.SubArea);
        }

        #endregion

        #region TestData

        /// <summary>
        /// The data that will be used for the parser tests
        /// </summary>
        private class ParserTestData : IEnumerable<object[]>
        {
            /// <summary>
            /// Get Enumerator function for the parser data tests
            /// </summary>
            /// <returns>
            /// Returns a string that represents a line from an inp file
            /// and returns a subarea that represents the expected subarea to be generated from
            /// the string that is provided
            /// </returns>
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    // The subarea that will be parsed
                    @"1                0.01       0.1        0.05       0.05       100        IMPERVIOUS 50        
                    ",

                    // The expected subarea
                    new SubArea
                    {
                        ManningNImpervious = 0.01,
                        ManningNPervious = 0.1,
                        SlopeOfImpervious = 0.05,
                        SlopeOfPervious = 0.05,
                        PercentZero = 100,
                        RouteTo = "IMPERVIOUS",
                        PercentRouted = 50,
                        ReferencedEntityNames = new List<string>{"1"}
                    }
                };
            }

            /// <summary>
            /// Get the enumerator for this class
            /// </summary>
            /// <returns></returns>
            IEnumerator IEnumerable.GetEnumerator() 
                => GetEnumerator();
        }

        #endregion
    }
}
