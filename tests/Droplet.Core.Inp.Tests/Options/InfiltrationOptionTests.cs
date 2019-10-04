﻿using Droplet.Core.Inp.Entities;
using Droplet.Core.Inp.Exceptions;
using Droplet.Core.Inp.Options;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests.Options
{
    /// <summary>
    /// Test class for the <see cref="InfiltrationOption"/> class
    /// </summary>
    public class InfiltrationOptionTests : FileTestsBase
    {
        /// <summary>
        /// Default constructor for this class
        /// </summary>
        /// <param name="logger">A logger that is passed from Xunit</param>
        public InfiltrationOptionTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #region Tests

        /// <summary>
        /// Testing the parsing of the <see cref="InfiltrationOption"/> option
        /// </summary>
        /// <param name="value">The inp string from a file</param>
        /// <param name="method">The expected method from that string</param>
        [Theory]
        [ClassData(typeof(ParserTestData))]
        public void ParserTests_ValidInpString(string value, InfiltrationMethod expectedValue)
            => Assert.Equal(expectedValue, SetupProject(value).Database.GetOption<InfiltrationOption>().Value);

        /// <summary>
        /// Testing the exception that will be thrown if the string passed to the
        /// parser is not a valid string
        /// </summary>
        /// <param name="value">The string that will be passed to the parser</param>
        [Theory]
        [InlineData("[OPTIONS]\nINFILTRATION         GARBAGEDATA\n")]
        public void PaserTests_InvalidInpString(string value)
            => Assert.Throws<InpFileException>(() => SetupProject(value));

        /// <summary>
        /// Testing the <see cref="IInpEntity.ToInpString"/> method
        /// </summary>
        /// <param name="inpString">The expected string</param>
        /// <param name="expectedMethod">The value that will be converted</param>
        [Theory]
        [ClassData(typeof(ParserTestData))]
        public void ToInpString_ValidString_ShouldMatchValue(string inpString, InfiltrationMethod expectedMethod)
            => Assert.Equal(PruneInpString(inpString, OptionsHeader), new InfiltrationOption(expectedMethod).ToInpString());

        #endregion

        #region Test Data

        /// <summary>
        /// Test data for <see cref="ParserTests_ValidInpString(string, InfiltrationMethod)"/>
        /// </summary>
        private class ParserTestData : IEnumerable<object[]>
        {
            /// <summary>
            /// Get Enumerator function that holds the test data
            /// </summary>
            /// <returns>Returns: The inp string that corresponds to the expected
            /// Infiltration method</returns>
            public IEnumerator<object[]> GetEnumerator()
            {
                // Horton
                yield return new object[]
                {
                    @"[OPTIONS]
INFILTRATION         HORTON
",

                    InfiltrationMethod.Horton
                };

                // Modified Horton
                yield return new object[]
{
                    @"[OPTIONS]
INFILTRATION         MODIFIED_HORTON
",

                    InfiltrationMethod.ModifiedHorton
                };

                // Green-Ampt
                yield return new object[]
{
                    @"[OPTIONS]
INFILTRATION         GREEN_AMPT
",

                    InfiltrationMethod.GreenAmpt
                };

                // Modified Green-Ampt
                yield return new object[]
{
                    @"[OPTIONS]
INFILTRATION         MODIFIED_GREEN_AMPT
",

                    InfiltrationMethod.ModifiedGreenAmpt
                };

                // Curve-Number
                yield return new object[]
{
                    @"[OPTIONS]
INFILTRATION         CURVE_NUMBER
",

                    InfiltrationMethod.CurveNumber
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion
    }
}
