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
    }
}
