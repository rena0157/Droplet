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
    /// Tests for the <see cref="InpDoubleOption"/> class
    /// </summary>
    public class InpDoubleOptionTests : FileTestsBase
    {
        /// <summary>
        /// Default constructor for these tests
        /// </summary>
        /// <param name="logger">A logger that is passed form Xunit</param>
        public InpDoubleOptionTests(ITestOutputHelper logger) : base(logger)
        {

        }

        #region Min Slope Tests

        /// <summary>
        /// Testing the parsing of the <see cref="MinSlopeOption"/>
        /// </summary>
        /// <param name="inpString">the string that will be parsed</param>
        /// <param name="expectedValue">the expected value from the string</param>
        [Theory]
        [ClassData(typeof(MinSlopeParserTestData_ValidStrings))]
        public void MinSlopeParserTests_ValidString(string value, double expectedValue)
            => Assert.Equal(expectedValue, SetupParserTest(value).Database.GetOption<MinSlopeOption>().Value);

        /// <summary>
        /// Test data for <see cref="MinSlopeParserTests_ValidString(string, double)"/> tests
        /// </summary>
        private class MinSlopeParserTestData_ValidStrings : IEnumerable<object[]>
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

        #region Min Surface Area Tests

        /// <summary>
        /// Testing the parsing of the <see cref="MinSurfaceAreaOption"/> option
        /// </summary>
        /// <param name="value">A valid inp string that will be parsed</param>
        /// <param name="expectedValue">The expected value that the parser should produce</param>
        [Theory]
        [ClassData(typeof(MinSurfaceAreaParserTestData_ValidStrings))]
        public void MinSurfaceAreaParserTests_ValidStrings(string value, double expectedValue)
            => Assert.Equal(expectedValue, SetupParserTest(value).Database.GetOption<MinSurfaceAreaOption>().Value);

        /// <summary>
        /// Test data for the <see cref="MinSurfaceAreaParserTests_ValidStrings(string, double)"/> tests
        /// </summary>
        private class MinSurfaceAreaParserTestData_ValidStrings : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    @"[OPTIONS]
MIN_SURFAREA         1.167
",

                    1.167
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion
    }
}
