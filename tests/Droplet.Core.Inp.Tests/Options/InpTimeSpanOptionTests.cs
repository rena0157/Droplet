// InpTimeSpanOptionTests.cs
// By: Adam Renaud
// Created: 2019-09-22

using Droplet.Core.Inp.Options;
using Droplet.Core.Inp.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using Droplet.Core.Inp.Exceptions;

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
        /// Valid Inp String that contains a <see cref="DryDaysOption"/> in it
        /// </summary>
        private const string DryDaysValidString = @"[OPTIONS]
DRY_DAYS             5
";

        /// <summary>
        /// An invalid inp string for the <see cref="DryDaysOption"/>
        /// </summary>
        private const string DryDaysInvalidString = @"[OPTIONS]
DRY_DAYS             INVALIDSTRING
";

        /// <summary>
        /// Tests for the parsing of the <see cref="DryDaysOption"/> option
        /// </summary>
        /// <param name="value">A <see cref="string"/> from an inp file that contains
        /// the option that will be parsed</param>
        /// <param name="expectedValue">The expected <see cref="TimeSpan"/> that the parser should 
        /// produce</param>
        [Theory]
        [ClassData(typeof(DryDaysOptionParserTestData))]
        public void DryDaysOptionParser_ValidString_ShouldMatchExpected(string value, TimeSpan expectedValue)
            => Assert.Equal(expectedValue,
                SetupProject(value).Database.GetOption<DryDaysOption>().Value);

        /// <summary>
        /// Testing the parser when an invalid string is passed for the <see cref="DryDaysOption"/>. 
        /// This test should throw an <see cref="InpFileException"/>
        /// </summary>
        /// <param name="value">The invalid <see cref="string"/></param>
        [Theory]
        [InlineData(DryDaysInvalidString)]
        public void DryDaysOptionParser_InvalidString_ShouldThrowInpFileException(string value)
            => Assert.Throws<InpFileException>(() => SetupProject(value));

        /// <summary>
        /// Tests the <see cref="IInpEntity.ToInpString"/> method as overridden for the <see cref="DryDaysOption"/> class
        /// </summary>
        /// <param name="value">The string that the method will be testing against.</param>
        [Theory]
        [InlineData(DryDaysValidString)]
        public void DryDaysToInpString_ValidString_ShouldMatchValue(string value)
            => Assert.Equal(PruneInpString(value, OptionsHeader), new DryDaysOption(5).ToInpString());

        /// <summary>
        /// Test data for the <see cref="DryDaysOptionParser_ValidString_ShouldMatchExpected(string, TimeSpan)"/> tests
        /// </summary>
        private class DryDaysOptionParserTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    DryDaysValidString,
                    TimeSpan.FromDays(5)
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion

        #region Report Step Option

        /// <summary>
        /// Valid Inp String that contains a <see cref="ReportStepOption"/>. 
        /// The option value is 00:15:00
        /// </summary>
        private const string ReportStepValidString = @"[OPTIONS]
REPORT_STEP          00:15:00
";

        private const string ReportStepInvalidString = @"[OPTIONS]
REPORT_STEP          NOTVALID
";

        /// <summary>
        /// Tests for the parsing of the <see cref="ReportStepOption"/>
        /// </summary>
        /// <param name="value">An inp <see cref="string"/> that contains the value that
        /// is to be parsed</param>
        /// <param name="expectedValue">The expected <see cref="TimeSpan"/> that the parser should
        /// create</param>
        [Theory]
        [ClassData(typeof(ReportStepOptionParserTestData))]
        public void ReportStepOptionParserTests_ValidString(string value, TimeSpan expectedValue)
            => Assert.Equal(expectedValue, SetupProject(value).Database.GetOption<ReportStepOption>().Value);

        /// <summary>
        /// Tests for the parsing of the <see cref="ReportStepOption"/> where an invalid string is passed. This 
        /// should throw an <see cref="InpFileException"/>
        /// </summary>
        /// <param name="value">An invalid inp string</param>
        [Theory]
        [InlineData(ReportStepInvalidString)]
        public void ReportStepOptionParserTests_InvalidString(string value)
            => Assert.Throws<InpFileException>(() => SetupProject(value));

        /// <summary>
        /// Tests for <see cref="IInpEntity.ToInpString"/> method as overridden for the <see cref="ReportStepOption"/>
        /// </summary>
        /// <param name="value">A vaild inp string that will be used to test against</param>
        [Theory]
        [InlineData(ReportStepValidString)]
        public void ReportStepToInpStringTest(string value)
            => Assert.Contains(SetupProject(value).Database.GetOption<ReportStepOption>().ToInpString(), value);

        /// <summary>
        /// Data class for the <see cref="ReportStepOptionParserTests_ValidString(string, TimeSpan)"/> tests
        /// </summary>
        private class ReportStepOptionParserTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    ReportStepValidString,
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
            => Assert.Equal(expectedValue, SetupProject(value).Database
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
            => Assert.Equal(expectedValue, SetupProject(value).Database
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
            => Assert.Equal(expectedValue, SetupProject(value).Database.GetOption<RoutingStepOption>().Value);

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

        #region Rule Step Option

        /// <summary>
        /// A valid string for the <see cref="ControlRuleStepOption"/>
        /// </summary>
        private const string RuleStepOptionValidInpString = @"[OPTIONS]
RULE_STEP            00:00:00
";

        /// <summary>
        /// Testing the parsing of the <see cref="ControlRuleStepOption"/> class
        /// </summary>
        /// <param name="value">The inp string that will be tested</param>
        /// <param name="expectedValue">The expected <see cref="TimeSpan"/> that 
        /// the parser should produce</param>
        [Theory]
        [ClassData(typeof(ControlRuleStepOptionParserTestData))]
        public void ControlRuleStepOptionParserTests(string value, TimeSpan expectedValue)
            => Assert.Equal(expectedValue, SetupProject(value).Database.GetOption<ControlRuleStepOption>().Value);

        /// <summary>
        /// Passing an invalid inp string to the <see cref="ControlRuleStepOption"/> parser
        /// </summary>
        /// <param name="value">The invalid string</param>
        [Theory]
        [InlineData("[OPTIONS]\nRULE_STEP            INVALID_DATA\n")]
        public void ControlRuleStepOptionParserTests_InvalidString_ShouldThrowInpFileException(string value)
            => Assert.Throws<InpFileException>(() => SetupProject(value));

        /// <summary>
        /// Tests the <see cref="IInpEntity.ToInpString"/> method as implemented for the <see cref="ControlRuleStepOption"/>
        /// </summary>
        /// <param name="value">The string that will be parsed</param>
        [Theory]
        [InlineData(RuleStepOptionValidInpString)]
        public void ControlRuleStepOptionToInpString_ValidString_ShouldMatchValue(string value)
            => Assert.Equal(PruneInpString(value, OptionsHeader), new ControlRuleStepOption(new TimeSpan()).ToInpString());

        /// <summary>
        /// Test data for the <see cref="ControlRuleStepOptionParserTests(string, TimeSpan)"/> tests
        /// </summary>
        private class ControlRuleStepOptionParserTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    RuleStepOptionValidInpString,
                    new TimeSpan()
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion

        #region Lengthening Step Option

        /// <summary>
        /// Valid string that contains a <see cref="ConduitLengtheningStepOption"/> with the 
        /// value 10 seconds
        /// </summary>
        private const string LengtheningStepInpString = @"[OPTIONS]
LENGTHENING_STEP     10
";

        /// <summary>
        /// Testing the parsing of the <see cref="ConduitLengtheningStepOption"/> class
        /// </summary>
        /// <param name="value">A string that contains the option that will be parsed</param>
        /// <param name="expectedValue">The expected <see cref="TimeSpan"/> that will be parsed</param>
        [Theory]
        [ClassData(typeof(ConduitLengtheningStepOptionParserTestData))]
        public void ConduitLengtheningStepOptionParserTests(string value, TimeSpan expectedValue)
            => Assert.Equal(expectedValue, SetupProject(value).Database.GetOption<ConduitLengtheningStepOption>().Value);

        /// <summary>
        /// Test the ToInpString Method for the <see cref="ConduitLengtheningStepOption"/> option class
        /// </summary>
        /// <param name="value">The valid string that will be parsed and then tested against</param>
        [Theory]
        [InlineData(LengtheningStepInpString)]
        public void ConduitLengtheningStepToInpString_ValidString_ShouldMatchValue(string value)
            => Assert.Equal(PruneInpString(value, OptionsHeader), new ConduitLengtheningStepOption(10).ToInpString());

        /// <summary>
        /// Test data for the <see cref="ConduitLengtheningStepOptionParserTests(string, TimeSpan)"/> tests
        /// </summary>
        private class ConduitLengtheningStepOptionParserTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    LengtheningStepInpString,
                    TimeSpan.FromSeconds(10)
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion
    }
}
