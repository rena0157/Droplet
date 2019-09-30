using Droplet.Core.Inp.Exceptions;
using Droplet.Core.Inp.IO;
using Droplet.Core.Inp.Options;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests.Options
{
    /// <summary>
    /// Class that contains tests for the <see cref="FlowUnitsOption"/>
    /// </summary>
    public class FlowUnitsTests : FileTestsBase
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="logger">Logger that is passed from Xunit</param>
        public FlowUnitsTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #region Tests

        /// <summary>
        /// Testing the parsing of <see cref="FlowUnitsOption"/> from
        /// a mock INPFile
        /// </summary>
        /// <param name="value">A substring from an inp file that
        /// contains the option and its value</param>
        /// <param name="expectedValue">The expected value</param>
        [Theory]
        [ClassData(typeof(ParserTestData))]
        public void ParserTests_ValidInpString(string value, FlowUnit expectedValue)
            => Assert.Equal(expectedValue, SetupProject(value).Database.GetOption<FlowUnitsOption>().Value);

        /// <summary>
        /// Testing this option if garbage data is sent to it what will happen
        /// </summary>
        /// <param name="value">The string that contains this option and garbage data</param>
        [Theory]
        [InlineData("[OPTIONS]\nFLOW_UNITS           GARBAGEDATA\n")]
        public void ParserTests_InvalidInpString(string value)
            => Assert.Throws<InpFileException>(() => SetupProject(value));

        /// <summary>
        /// Testing what happens if an empty string is passed to the reader
        /// </summary>
        /// <param name="value">The value of the string</param>
        [Theory]
        [InlineData("[OPTIONS]\nFLOW_UNITS  \n")]
        public void ParserTest_EmptyString(string value)
            => Assert.Throws<InpFileException>(() => SetupProject(value));

        #endregion

        #region Test Data

        /// <summary>
        /// Class that stores the data for the <see cref="ParserTests_ValidInpString(string, FlowUnit)"/>
        /// </summary>
        private class ParserTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                // Cubic Feet Per Second
                yield return new object[]
                {
                    @"[OPTIONS]
FLOW_UNITS           CFS
",
                    FlowUnit.CubicFeetPerSecond
                };

                // liters per second
                yield return new object[]
                {
                    @"[OPTIONS]
FLOW_UNITS           LPS
",
                    FlowUnit.LitersPerSecond
                };

                // Gallons per min
                yield return new object[]
                {
                    @"[OPTIONS]
FLOW_UNITS           GPM
",
                    FlowUnit.GallonsPerMinute
                };

                // Million Gallons per day
                yield return new object[]
                {
                    @"[OPTIONS]
FLOW_UNITS           MGD
",
                    FlowUnit.MillionGallonsPerDay
                };

                // Gallons per min
                yield return new object[]
                {
                    @"[OPTIONS]
FLOW_UNITS           CMS
",
                    FlowUnit.CubicMetersPerSecond
                };

                // Gallons per min
                yield return new object[]
                {
                    @"[OPTIONS]
FLOW_UNITS           MLD
",
                    FlowUnit.MillionLitersPerDay
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion
    }
}
