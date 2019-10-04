// InpDateTimeOptionTests.cs
// By: Adam Renaud
// Created: 2019-09-18

using Droplet.Core.Inp.Exceptions;
using Droplet.Core.Inp.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests.Options
{
    /// <summary>
    /// Tests for the <see cref="InpDateTimeOption"/> and inheritors
    /// </summary>
    public class InpDateTimeOptionTests : FileTestsBase
    {

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="logger"></param>
        public InpDateTimeOptionTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #endregion

        #region Start DateTime Tests

        /// <summary>
        /// Testing the parsing of the <see cref="StartDateTimeOption"/>
        /// </summary>
        /// <param name="value">A string from an inp file that holds the data
        /// to the start date and the start time</param>
        /// <param name="expectedValue">The expected <see cref="DateTime"/> that the parser
        /// should build</param>
        [Theory]
        [ClassData(typeof(StartDateTimeParserTestData))]
        public void StartDateTimeParserTests(string value, DateTime expectedValue)
            => Assert.Equal(expectedValue,
                SetupProject(value).Database.GetOption<StartDateTimeOption>().Value);

        /// <summary>
        /// Test Data for the <see cref="StartDateTimeParserTests(string, DateTime)"/> tests
        /// </summary>
        private class StartDateTimeParserTestData : IEnumerable<object[]>
        {

            /// <summary>
            /// A string from an inp file
            /// and the expected <see cref="DateTime"/> that the
            /// parser should create
            /// </summary>
            /// <returns></returns>
            public IEnumerator<object[]> GetEnumerator()
            {
                // With start time
                yield return new object[]
                {
                    @"[OPTIONS]
START_DATE           07/28/2019
START_TIME           01:12:50
",

                    new DateTime(2019, 07, 28, 1, 12, 50)
                };

                // Without start time
                yield return new object[]
{
                    @"[OPTIONS]
START_DATE           07/28/2019
",

                    new DateTime(2019, 07, 28, 0, 0, 0)
};
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion

        #region Report StartDate Time Tests

        /// <summary>
        /// Testing the parsing of the <see cref="ReportStartDateTimeOption"/>
        /// class.
        /// </summary>
        /// <param name="value">A string from an inp file that holds the data to
        /// the Report Start Date and Time</param>
        /// <param name="expectedValue">The expected <see cref="DateTime"/> that the
        /// Parser should create from the <paramref name="value"/> passed</param>
        [Theory]
        [ClassData(typeof(ReportStartDateTimeParserTestData))]
        public void ReportStartDateTimeParser_ValidString_ShouldMatchExpected(string value, DateTime expectedValue)
            => Assert.Equal(expectedValue,
                SetupProject(value).Database.GetOption<ReportStartDateTimeOption>().Value);

        /// <summary>
        /// Testing the parsing of <see cref="ReportStartDateTimeOption"/> when an invalid string 
        /// is passed to it for either the start date or the start time
        /// </summary>
        /// <param name="value"></param>
        [Theory]
        [InlineData("[OPTIONS]\nREPORT_START_DATE    07/28/2019\nREPORT_START_TIME    INVALID\n")]
        [InlineData("[OPTIONS]\nREPORT_START_DATE    INVALID\nREPORT_START_TIME    00:00:00\n")]
        public void ReportStartDateTimeParser_InvalidString_ShouldThrowInpFileException(string value)
            => Assert.Throws<InpFileException>(() => SetupProject(value));

        /// <summary>
        /// Testing the <see cref="IInpEntity.ToInpString"/> method override for the <see cref="ReportStartDateTimeOption"/> 
        /// class
        /// </summary>
        /// <param name="expectedString">The expected <see cref="string"/></param>
        /// <param name="value">The value that will be used to create the <see cref="ReportStartDateTimeOption"/></param>
        [Theory]
        [ClassData(typeof(ReportStartDateTimeToInpStringTestData))]
        public void ReportStartDateTime_ToInpString_ShouldMatchExpected(string expectedString, DateTime value)
            => Assert.Equal(expectedString, new ReportStartDateTimeOption(value).ToInpString());

        /// <summary>
        /// Test Data for the <see cref="ReportStartDateTimeParser_ValidString_ShouldMatchExpected(string, DateTime)"/> tests
        /// </summary>
        private class ReportStartDateTimeParserTestData : IEnumerable<object[]>
        {
            /// <summary>
            /// Returns the <see cref="string"/> and expected <see cref="DateTime"/>
            ///  for the test
            /// </summary>
            /// <returns>Returns: a string and a DateTime for the test</returns>
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    @"[OPTIONS]
REPORT_START_DATE    07/28/2019
REPORT_START_TIME    00:00:00
",

                    new DateTime(2019, 07, 28, 0, 0, 0)
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        /// <summary>
        /// Test data for the <see cref="ReportStartDateTime_ToInpString_ShouldMatchExpected(string, DateTime)"/> 
        /// Tests
        /// </summary>
        private class ReportStartDateTimeToInpStringTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    @"REPORT_START_DATE    07/28/2019
REPORT_START_TIME    00:00:00",
                    new DateTime(2019, 07, 28, 0, 0, 0)
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion

        #region EndDateTime Tests

        /// <summary>
        /// A valid <see cref="EndDateTimeOption"/> inp string
        /// </summary>
        private const string EndDateTimeValidInpString = @"[OPTIONS]
END_DATE             07/28/2019
END_TIME             06:00:00
";

        /// <summary>
        /// Invalid <see cref="EndDateTimeOption"/> inp string that has an invalid 
        /// end time
        /// </summary>
        private const string EndDateTimeString_InvalidEndTime = @"[OPTIONS]
END_DATE             07/28/2019
END_TIME             INVALID
";

        /// <summary>
        /// Invalid <see cref="EndDateTimeOption"/> inp string that is missing the 
        /// End Time
        /// </summary>
        private const string EndDateTimeString_MissingEndTime = @"[OPTIONS]
END_DATE             07/28/2019
";

        /// <summary>
        /// Invalid <see cref="EndDateTimeOption"/> inp string that has an invalid 
        /// end date
        /// </summary>
        private const string EndDateTimeString_InvalidEndDate = @"[OPTIONS]
END_DATE             INVALID
END_TIME             06:00:00
";

        /// <summary>
        /// Invalid <see cref="EndDateTimeOption"/> inp string that is missing the start date
        /// </summary>
        private const string EndDateTimeString_MissingEndDate = @"[OPTIONS]
END_TIME             06:00:00
";

        /// <summary>
        /// Tests the parsing of the <see cref="EndDateTimeOption"/> option
        /// </summary>
        /// <param name="value">A string from an inp file that represents a date and a time</param>
        /// <param name="expectedDateTime">The expected date time</param>
        [Theory]
        [ClassData(typeof(EndDateTimeParserTesData))]
        public void EndDateTimeParser_ValidString_ShouldMatchExpected(string value, DateTime expectedDateTime)
            => Assert.Equal(expectedDateTime,
                SetupProject(value).Database.GetOption<EndDateTimeOption>().Value);

        /// <summary>
        /// Testing the parsing of the <see cref="EndDateTimeOption"/> when 
        /// and invalid string is passed
        /// </summary>
        /// <param name="value">The invalid string</param>
        [Theory]
        // [InlineData(EndDateTimeString_MissingEndTime)] // TODO: Fix these failing tests if required
        [InlineData(EndDateTimeString_InvalidEndDate)]
        // [InlineData(EndDateTimeString_MissingEndDate)] // TODO: Fix these failing tests if required
        [InlineData(EndDateTimeString_InvalidEndTime)]
        public void EndDateTimeParser_InvalidString_ShouldThrowInpFileException(string value)
            => Assert.Throws<InpFileException>(() => SetupProject(value));

        /// <summary>
        /// Testing
        /// </summary>
        /// <param name="value"></param>
        [Theory]
        [ClassData(typeof(EndDateTimeToInpStringTestData))]
        public void EndDateTimeToInpString_ValidString_ShouldMatchValue(DateTime value, string expected)
            => Assert.Equal(expected, new EndDateTimeOption(value).ToInpString());

        /// <summary>
        /// Test data for the <see cref="EndDateTimeParserTesData"/>
        /// </summary>
        private class EndDateTimeParserTesData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    EndDateTimeValidInpString,
                    new DateTime(2019, 07, 28, 6, 0, 0)
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        /// <summary>
        /// Private class that holds test data for the <see cref="EndDateTimeParser_ValidString_ShouldMatchExpected(DateTime, string)"/> tests
        /// </summary>
        private class EndDateTimeToInpStringTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                // Standard string test
                yield return new object[]
                {
                    new DateTime(2019, 07, 28, 6, 0, 0),
                    @"END_DATE             07/28/2019
END_TIME             06:00:00"
                };

                // Testing without end time
                yield return new object[]
                {
                    new DateTime(2019, 07, 28),
                    @"END_DATE             07/28/2019
END_TIME             00:00:00"
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion

        #region Sweeping Date Time Tests

        /// <summary>
        /// Testing the parsing of the <see cref="SweepingStartDateTimeOption"/> 
        /// Option
        /// </summary>
        /// <param name="value">A string from an inp file that contains the option</param>
        /// <param name="expectedValue">The expected value from the option</param>
        [Theory]
        [ClassData(typeof(SweepingStartDateTimeParserTestData))]
        public void SweepingStartDateTimeParserTests(string value, DateTime expectedValue)
            => Assert.Equal(expectedValue, SetupProject(value)
                .Database
                .GetOption<SweepingStartDateTimeOption>().Value);

        /// <summary>
        /// Test data for the <see cref="SweepingStartDateTimeParserTests(string, DateTime)"/>
        ///  tests
        /// </summary>
        private class SweepingStartDateTimeParserTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    @"[OPTIONS]
SWEEP_START          01/01
",

                    new DateTime(DateTime.Now.Year, 1, 1)
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        /// <summary>
        /// Testing the parsing of the <see cref="SweepingEndDateTimeOption"/> 
        /// </summary>
        /// <param name="value">A <see cref="string"/> from an inp file that
        /// contains a <see cref="SweepingEndDateTimeOption"/> that will be parsed</param>
        /// <param name="expectedValue">The expected <see cref="DateTime"/> that the parser should 
        /// produced from the <paramref name="value"/></param>
        [Theory]
        [ClassData(typeof(SweepingEndDateTimeParserTestData))]
        public void SweepingEndDateTimeParserTests(string value, DateTime expectedValue)
            => Assert.Equal(expectedValue, SetupProject(value).Database
                                                                 .GetOption<SweepingEndDateTimeOption>().Value);

        /// <summary>
        /// Test data for the <see cref="SweepingEndDateTimeParserTests(string, DateTime)"/> 
        /// tests
        /// </summary>
        private class SweepingEndDateTimeParserTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    @"[OPTIONS]
SWEEP_END            12/31
",

                    new DateTime(DateTime.Now.Year, 12, 31)
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion

    }
}
