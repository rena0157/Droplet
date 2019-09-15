using Droplet.Core.Inp.IO;
using Droplet.Core.Inp.Options;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests.Options
{
    public class FlowUnitsTests : FileTestsBase
    {
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
        public void ParserTests(string value, FlowUnits expectedValue)
        {
            Initialize(value);
            using var reader = new InpFileReader(MemoryStream);
            var parser = new InpParser();
            var project = new InpProject();
            parser.ParseFile(project, reader);

            var option = project.Database.GetOption<FlowUnitsOption>().Value;

            Assert.Equal(expectedValue, option);
        }

        #endregion

        #region Test Data

        /// <summary>
        /// Class that contains the test data for all of the possible combos for
        /// Flow Units
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
                    FlowUnits.CubicFeetPerSecond
                };

                // liters per second
                yield return new object[]
                {
                    @"[OPTIONS]
FLOW_UNITS           LPS
",
                    FlowUnits.LitersPerSecond
                };

                // Gallons per min
                yield return new object[]
                {
                    @"[OPTIONS]
FLOW_UNITS           GPM
",
                    FlowUnits.GallonsPerMinute
                };

                // Million Gallons per day
                yield return new object[]
                {
                    @"[OPTIONS]
FLOW_UNITS           MGD
",
                    FlowUnits.MillionGallonsPerDay
                };

                // Gallons per min
                yield return new object[]
                {
                    @"[OPTIONS]
FLOW_UNITS           CMS
",
                    FlowUnits.CubicMetersPerSecond
                };

                // Gallons per min
                yield return new object[]
                {
                    @"[OPTIONS]
FLOW_UNITS           MLD
",
                    FlowUnits.MillionLitersPerDay
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion
    }
}
