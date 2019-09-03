// InfiltrationMethodsTests.cs
// By: Adam Renaud
// Created: 2019-08-10

using System;
using System.Collections;
using System.Collections.Generic;
using Droplet.Core.Inp;
using Droplet.Core.Inp.Options;
using Droplet.Core.Inp.Options.Extensions;
using Droplet.Core.Inp.Parsers;
using Xunit;
using Xunit.Abstractions;

namespace InpLibTests.Options
{
    public class InfiltrationMethodsTests : InpFileTests
    {

        public InfiltrationMethodsTests(ITestOutputHelper logger) : base(logger)
        {
        }
        /// <summary>
        /// Testing the from String extension method for the Infiltration Methods
        /// </summary>
        /// <param name="value">The value of the string</param>
        /// <param name="expectedValue">The expected value of the Infiltration method</param>
        [Theory]
        [InlineData("HORTON", InfiltrationMethods.Horton)]
        [InlineData("MODIFIED_HORTON", InfiltrationMethods.ModifiedHorton)]
        [InlineData("GREEN_AMPT", InfiltrationMethods.GreenAmpt)]
        [InlineData("MODIFIED_GREEN_AMPT", InfiltrationMethods.ModifiedGreenAmpt)]
        [InlineData("CURVE_NUMBER", InfiltrationMethods.CurveNumber)]
        public void FromInpStringTest(string value, InfiltrationMethods expectedValue)
        {
            var method = InfiltrationMethods.Horton;
            var (result, infiltrationMethods) = method.FromInpString(value);
            Assert.True(result);
            method = infiltrationMethods;
            Assert.Equal(method, expectedValue);
        }

        /// <summary>
        /// Test the parser for Infiltration methods using the test
        /// data provided in <see cref="TestData"/>
        /// </summary>
        /// <param name="s">The string that is passed from the test data class</param>
        /// <param name="expectedMethod">What the expected method is</param>
        [Theory]
        [ClassData(typeof(TestData))]
        public void ParserTest(string s, InfiltrationMethods expectedMethod)
        {
            // Fill out the File lines strings
            FileLinesFromString(s);

            // Create a project and a parser
            var project = new InpProject();
            var parser = new InpOptionsSection(project);

            // Make the parser read the section
            parser.ReadSection(this);

            // Assert that the results are equal to the expected results
            Assert.Equal(expectedMethod, project.InfiltrationMethod);
        }

        #region TestData

        /// <summary>
        /// The test data for the Infiltration methods tests
        /// </summary>
        private class TestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                // Green Ampt
                yield return new object[]
                {
                    @"INFILTRATION         GREEN_AMPT
                     ",
                    InfiltrationMethods.GreenAmpt
                };

                // Horton 
                yield return new object[]
                {
                    @"INFILTRATION         HORTON
                     ",
                    InfiltrationMethods.Horton
                };

                // Modified Horton
                yield return new object[]
                {
                    @"INFILTRATION         MODIFIED_HORTON
                     ",
                    InfiltrationMethods.ModifiedHorton
                };

                // Modified Green Ampt
                yield return new object[]
                {
                    @"INFILTRATION         MODIFIED_GREEN_AMPT
                     ",
                    InfiltrationMethods.ModifiedGreenAmpt
                };

                // Curve Number
                yield return new object[]
                {
                    @"INFILTRATION         CURVE_NUMBER
                     ",
                    InfiltrationMethods.CurveNumber
                };
            }

            IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        }

        #endregion

    }
}
