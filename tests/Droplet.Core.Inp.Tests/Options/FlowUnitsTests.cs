// FlowUnitsTests.cs
// By: Adam Renaud
// Created: 2019-08-10

using System;
using System.Collections;
using System.Collections.Generic;
using Droplet.Core.Inp;
using Xunit;
using Droplet.Core.Inp.Options;
using Droplet.Core.Inp.Options.Extensions;
using Droplet.Core.Inp.Parsers;
using Xunit.Abstractions;

namespace InpLibTests.Options
{
    public class FlowUnitsTests : InpFileTests
    {
        public FlowUnitsTests(ITestOutputHelper logger) : base(logger)
        {

        }

        #region Tests

        /// <summary>
        /// Testing the FlowUnits from string extension Method
        /// </summary>
        /// <param name="value">The string value that is passed to the method</param>
        /// <param name="expectedValue">The expected value</param>
        [Theory]
        [InlineData("CMS", FlowUnits.CubicMetersPerSecond)]
        [InlineData("CFS", FlowUnits.CubicFeetPerSecond)]
        [InlineData("GPM", FlowUnits.GallonsPerMinute)]
        [InlineData("MGD", FlowUnits.MillionGallonsPerDay)]
        [InlineData("MLD", FlowUnits.MilltionLitersPerDay)]
        public void FromStringExtensionTest(string value, FlowUnits expectedValue)
        {
            var units = FlowUnits.CubicFeetPerSecond;
            var (result, flowUnits) = units.FromInpString(value);
            Assert.True(result);
            units = flowUnits;
            Assert.Equal(expectedValue, units);
        }

        [Theory]
        [ClassData(typeof(FlowUnitsTestData))]
        public void FlowUnitsParsingTest(string s, FlowUnits expectedFlowUnits)
        {
            FileLinesFromString(s);
            var project = new InpProject();
            var optionsParser = new InpOptionsSection(project);
            optionsParser.ReadSection(this);

            Assert.Equal(expectedFlowUnits, project.FlowUnits);
        }

        #endregion

        #region ClassData

        /// <summary>
        /// Test data for flow units
        /// </summary>
        private class FlowUnitsTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                // Liters per second
                yield return new object[]
                {
                    @"FLOW_UNITS           LPS
                     ",
                    FlowUnits.LitersPerSecond
                };

                // Cubic feet per second
                yield return new object[]
                {
                    @"FLOW_UNITS           CFS
                     ",
                    FlowUnits.CubicFeetPerSecond
                };

                // Gallons per min
                yield return new object[]
                {
                    @"FLOW_UNITS           GPM
                     ",
                    FlowUnits.GallonsPerMinute
                };

                // Million gallons per day
                yield return new object[]
                {
                    @"FLOW_UNITS           MGD
                     ",
                    FlowUnits.MillionGallonsPerDay
                };

                // Cubic meters per second
                yield return new object[]
                {
                    @"FLOW_UNITS           CMS
                     ",
                    FlowUnits.CubicMetersPerSecond
                };

                // Million liters per day
                yield return new object[]
                {
                    @"FLOW_UNITS           MLD
                     ",
                    FlowUnits.MilltionLitersPerDay
                };
            }

            IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        }

        #endregion
    }
}
