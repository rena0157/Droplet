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
                SetupParserTest(value).Database.GetOption<StartDateTimeOption>().Value);

        /// <summary>
        /// Testing the expected behavior if the start time is there but the start date is not.
        /// The expected behavior in this case is to throw the <see cref="InpParseException"/>
        /// </summary>
        /// <param name="value">The string value</param>
        [Theory]
        [InlineData("[OPTIONS]\nSTART_TIME           01:12:50\n")]
        public void StartDateTimeParserTests_WithoutStartDate(string value)
            => Assert.Throws<InpParseException>(() => SetupParserTest(value));

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
        public void ReportStartDateTimeParserTests(string value, DateTime expectedValue)
            => Assert.Equal(expectedValue,
                SetupParserTest(value).Database.GetOption<ReportStartDateTimeOption>().Value);

        #endregion

        #region EndDateTime Tests

        /// <summary>
        /// Tests the parsing of the <see cref="EndDateTimeOption"/> option
        /// </summary>
        /// <param name="value">A string from an inp file that represents a date and a time</param>
        /// <param name="expectedDateTime">The expected date time</param>
        [Theory]
        [ClassData(typeof(EndDateTimeParserTesData))]
        public void EndDateTimeParserTests(string value, DateTime expectedDateTime)
            => Assert.Equal(expectedDateTime,
                SetupParserTest(value).Database.GetOption<EndDateTimeOption>().Value);

        /// <summary>
        /// Test data for the <see cref="EndDateTimeParserTesData"/>
        /// </summary>
        private class EndDateTimeParserTesData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    @"[OPTIONS]
END_DATE             07/28/2019
END_TIME             06:00:00
",

                    new DateTime(2019, 07, 28, 6, 0, 0)
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion

        #region Test Data

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

        /// <summary>
        /// Test Data for the <see cref="ReportStartDateTimeParserTests(string, DateTime)"/> tests
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

        #endregion
    }
}
