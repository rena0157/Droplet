// InpTimeSpanOptionTests.cs
// By: Adam Renaud
// Created: 2019-09-22

using Droplet.Core.Inp.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests.Options
{
    /// <summary>
    /// Class that contains all of the tests for classes that
    ///  inherit from the <see cref="InpTimeSpanOption"/> class
    /// </summary>
    public class InpTimeSpanOptionTests : FileTestsBase
    {
        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="logger">A logger that is passed from XUnit</param>
        public InpTimeSpanOptionTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #endregion

        #region Dry Days Option

        /// <summary>
        /// Tests for the parsing of the <see cref="DryDaysOption"/> option
        /// </summary>
        /// <param name="value">A <see cref="string"/> from an inp file that contains
        /// the option that will be parsed</param>
        /// <param name="expectedValue">The expected <see cref="TimeSpan"/> that the parser shoud 
        /// produce</param>
        [Theory]
        [ClassData(typeof(DryDaysOptionParserTestData))]
        public void DryDaysOptionParserTests(string value, TimeSpan expectedValue)
            => Assert.Equal(expectedValue,
                SetupParserTest(value).Database.GetOption<DryDaysOption>().Value);

        /// <summary>
        /// Test data for the <see cref="DryDaysOptionParserTests(string, TimeSpan)"/> tests
        /// </summary>
        private class DryDaysOptionParserTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    @"[OPTIONS]
DRY_DAYS             5
",

                    TimeSpan.FromDays(5)
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion

        #region Report Step Option

        /// <summary>
        /// Tests for the parsing of the <see cref="ReportStepOption"/>
        /// </summary>
        /// <param name="value">An inp <see cref="string"/> that contains the value that
        /// is to be parsed</param>
        /// <param name="expectedValue">The expected <see cref="TimeSpan"/> that the parser should
        /// create</param>
        [Theory]
        [ClassData(typeof(ReportStepOptionParserTestData))]
        public void ReportStepOptionParserTests(string value, TimeSpan expectedValue)
            => Assert.Equal(expectedValue, SetupParserTest(value).Database.GetOption<ReportStepOption>().Value);

        /// <summary>
        /// Data class for the <see cref="ReportStepOptionParserTests(string, TimeSpan)"/> tests
        /// </summary>
        private class ReportStepOptionParserTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    @"[OPTIONS]
REPORT_STEP          00:15:00
",

                    new TimeSpan(0, 15, 0)
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion

        #region Wet Step Option

        /// <summary>
        /// Tests for the parsing of the <see cref="WetWeatherStepOption"/> option
        /// </summary>
        /// <param name="value">A <see cref="string"/> that contains the value that 
        /// Will be parsed</param>
        /// <param name="expectedValue">The expected <see cref="TimeSpan"/> that the 
        /// Parser should produce</param>
        [Theory]
        [ClassData(typeof(WetWeatherOptionParserTestData))]
        public void WetWeatherOptionParserTests(string value, TimeSpan expectedValue)
            => Assert.Equal(expectedValue, SetupParserTest(value).Database
                .GetOption<WetWeatherStepOption>().Value);

        /// <summary>
        /// Test data for the <see cref="WetWeatherOptionParserTests(string, TimeSpan)"/> tests
        /// </summary>
        private class WetWeatherOptionParserTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    @"[OPTIONS]
WET_STEP             00:05:00
",

                    new TimeSpan(0, 5, 0)
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion

        #region Dry Step Option

        /// <summary>
        /// Testing the parsing of the <see cref="DryWeatherStepOption"/>
        /// </summary>
        /// <param name="value">A <see cref="string"/> that contains a <see cref="DryWeatherStepOption"/>
        ///  that the parser will parse into a <see cref="TimeSpan"/></param>
        /// <param name="expectedValue">The expected <see cref="TimeSpan"/></param>
        [Theory]
        [ClassData(typeof(DryWeatherStepOptionParserTestData))]
        public void DryWeatherStepOptionParserTests(string value, TimeSpan expectedValue)
            => Assert.Equal(expectedValue, SetupParserTest(value).Database
                .GetOption<DryWeatherStepOption>().Value);

        /// <summary>
        /// Test data for the <see cref="DryWeatherStepOptionParserTests(string, TimeSpan)"/> tests
        /// </summary>
        private class DryWeatherStepOptionParserTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    @"[OPTIONS]
DRY_STEP             01:00:00
",

                    new TimeSpan(1, 0, 0)
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion

        #region Routing Step Option

        /// <summary>
        /// Testing the parsing of the <see cref="RoutingStepOption"/>
        /// </summary>
        /// <param name="value">The string that will be parsed</param>
        /// <param name="expectedValue">The expected <see cref="TimeSpan"/> that the string 
        /// will contain</param>
        [Theory]
        [ClassData(typeof(RoutingStepOptionParserTestData))]
        public void RoutingStepOptionParserTests(string value, TimeSpan expectedValue)
            => Assert.Equal(expectedValue, SetupParserTest(value).Database.GetOption<RoutingStepOption>().Value);

        /// <summary>
        /// Test data for the <see cref="RoutingStepOptionParserTests(string, TimeSpan)"/> tests
        /// </summary>
        private class RoutingStepOptionParserTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    @"[OPTIONS]
ROUTING_STEP         0:00:30
",

                    new TimeSpan(0, 0, 30)
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion
    }
}
