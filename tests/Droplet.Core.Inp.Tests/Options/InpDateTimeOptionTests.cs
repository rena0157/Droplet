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

        #region Tests

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

        #endregion
    }
}
