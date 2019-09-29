// InpBoolOptionTests.cs
// By: Adam Renaud
// Created: 2019-09-16

using Droplet.Core.Inp.Exceptions;
using Droplet.Core.Inp.IO;
using Droplet.Core.Inp.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests.Options
{
    /// <summary>
    /// Tests for <see cref="InpBoolOption"/> options
    /// and inheritors
    /// </summary>
    public class InpBoolOptionTests : FileTestsBase
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="logger">A logger that is passed form Xunit</param>
        public InpBoolOptionTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #region Generic Tests

        /// <summary>
        /// Testing the parsing from a <see cref="string"/> to a <see cref="bool"/>
        /// using the <see cref="InpBoolOption.FromInpString(string)"/> Method
        /// </summary>
        /// <param name="value">The string value being tested</param>
        /// <param name="expectedValue">The expected boolean value</param>
        [Theory]
        [InlineData("YES", true)]
        [InlineData("NO", false)]
        public void BoolParserTests_ValidInpString(string value, bool expectedValue) 
            => Assert.Equal(expectedValue, InpBoolOption.FromInpString(value));

        /// <summary>
        /// Testing the parsing of garbage data. This should throw the <see cref="InpParseException"/>
        /// </summary>
        /// <param name="value">The garbage data that will be passed</param>
        [Theory]
        [InlineData("Some Garbage data")]
        public void BoolParserTests_InvalidInpString(string value)
            => Assert.Throws<InpParseException>(() => InpBoolOption.FromInpString(value));

        #endregion  

        #region Allow Ponding Tests

        /// <summary>
        /// String that contains the Allow Ponding option and the true value
        /// </summary>
        private const string AllowPondingTrue = @"[OPTIONS]
ALLOW_PONDING        YES
";

        /// <summary>
        /// String that contains the allow ponding option for the false value
        /// </summary>
        private const string AllowPondingFalse = @"[OPTIONS]
ALLOW_PONDING        NO
";

        /// <summary>
        /// Testing the parsing of the <see cref="AllowPondingOption"/>
        /// </summary>
        /// <param name="value">A string value from an inp file</param>
        /// <param name="expectedValue">The expected value of the option</param>
        [Theory]
        [InlineData(AllowPondingTrue, true)]
        [InlineData(AllowPondingFalse, false)]
        public void AllowPondingParserTests_ValidInpString(string value, bool expectedValue)
            => Assert
                .Equal(expectedValue, 
                SetupParserTest(value).Database.GetOption<AllowPondingOption>().Value);

        /// <summary>
        /// Testing the ToInpString Method for the <see cref="AllowPondingOption"/>
        /// </summary>
        /// <param name="value">The option string</param>
        [Theory]
        [InlineData(AllowPondingTrue)]
        public void AllowPondingToInpStringTests(string value)
            => Assert.Contains(SetupParserTest(value).Database.GetOption<AllowPondingOption>().ToInpString(),
                value);

        #endregion

        #region Skip Steady State Tests

        /// <summary>
        /// The <see cref="SkipSteadyStateOption"/> true <see cref="string"/> value
        /// </summary>
        private const string SkipSSTrue = @"[OPTIONS]
SKIP_STEADY_STATE    YES
";

        /// <summary>
        /// The <see cref="SkipSteadyStateOption"/> false <see cref="string"/> value
        /// </summary>
        private const string SkipSSFalse = @"[OPTIONS]
SKIP_STEADY_STATE    NO
";

        /// <summary>
        /// Testing the parsing of the <see cref="SkipSteadyStateOption"/>
        /// </summary>
        /// <param name="value">A string from an inp file</param>
        /// <param name="expectedValue">The expected option</param>
        [Theory]
        [InlineData(SkipSSTrue, true)]
        [InlineData(SkipSSFalse, false)]
        public void SkipSteadyStateParserTests(string value, bool expectedValue)
            => Assert
            .Equal(expectedValue,
                SetupParserTest(value).Database.GetOption<SkipSteadyStateOption>().Value);


        #endregion
    }
}
