using Droplet.Core.Inp.IO;
using Droplet.Core.Inp.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests.Options
{
    /// <summary>
    /// Tests for the <see cref="MinSlopeOption"/> class
    /// </summary>
    public class MinSlopeOptionTests : FileTestsBase
    {
        /// <summary>
        /// Default constructor for these tests
        /// </summary>
        /// <param name="logger">A logger that is passed form Xunit</param>
        public MinSlopeOptionTests(ITestOutputHelper logger) : base(logger)
        {

        }

        #region Tests

        /// <summary>
        /// Testing the parsing of the <see cref="MinSlopeOption"/>
        /// </summary>
        /// <param name="inpString">the string that will be parsed</param>
        /// <param name="expectedValue">the expected value from the string</param>
        [Theory]
        [ClassData(typeof(ParserTestData))]
        public void ParserTests(string inpString, double expectedValue)
        {
            Initialize(inpString);
            var project = new InpProject();
            var reader = new InpFileReader(MemoryStream);
            var parser = new InpParser();
            parser.ParseFile(project, reader);

            var option = project.Database.GetOption<MinSlopeOption>();

            Assert.Equal(expectedValue, option.Value);
        }

        #endregion

        #region Test Data

        /// <summary>
        /// Test data for <see cref="ParserTests(string, double)"/> tests
        /// </summary>
        private class ParserTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                // Testing a double value
                yield return new object[]
                {
                    @"[OPTIONS]
MIN_SLOPE            0.15
",

                    0.15
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion
    }
}
