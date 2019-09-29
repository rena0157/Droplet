using Droplet.Core.Inp.Options;
using Xunit;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests.Options
{
    /// <summary>
    /// Tests for the <see cref="InpDoubleOption"/> class
    /// </summary>
    public class InpDoubleOptionTests : FileTestsBase
    {
        /// <summary>
        /// Default constructor for these tests
        /// </summary>
        /// <param name="logger">A logger that is passed form <see cref="Xunit"/></param>
        public InpDoubleOptionTests(ITestOutputHelper logger) : base(logger)
        {

        }

        #region Min Slope Tests

        /// <summary>
        /// Valid <see cref="MinSlopeOption"/> string that contains the 
        /// value 0.15
        /// </summary>
        private const string MinSlopeValidString = @"[OPTIONS]
MIN_SLOPE            0.15
";

        /// <summary>
        /// Testing the parsing of the <see cref="MinSlopeOption"/>
        /// </summary>
        /// <param name="inpString">the string that will be parsed</param>
        /// <param name="expectedValue">the expected value from the string</param>
        [Theory]
        [InlineData(MinSlopeValidString, 0.15)]
        public void MinSlopeParserTests_ValidString(string value, double expectedValue)
            => Assert.Equal(expectedValue, SetupParserTest(value).Database.GetOption<MinSlopeOption>().Value);

        /// <summary>
        /// Testing the ToInpString Method for the <see cref="MinSlopeOption"/>
        /// </summary>
        /// <param name="value"></param>
        [Theory]
        [InlineData(MinSlopeValidString)]
        public void MinSlopeToInpStringTest(string value)
            => Assert.Contains(SetupParserTest(value).Database.GetOption<MinSlopeOption>().ToInpString(),
                value);

        #endregion

        #region Min Surface Area Tests

        /// <summary>
        /// String that contains a valid inp string for the <see cref="MinSurfaceAreaOption"/> 
        /// that has the value 1.167
        /// </summary>
        private const string MinSurfaceAreaValidString = @"[OPTIONS]
MIN_SURFAREA         1.167
";

        /// <summary>
        /// Testing the parsing of the <see cref="MinSurfaceAreaOption"/> option
        /// </summary>
        /// <param name="value">A valid inp string that will be parsed</param>
        /// <param name="expectedValue">The expected value that the parser should produce</param>
        [Theory]
        [InlineData(MinSurfaceAreaValidString, 1.167)]
        public void MinSurfaceAreaParserTests_ValidStrings(string value, double expectedValue)
            => Assert.Equal(expectedValue, SetupParserTest(value).Database.GetOption<MinSurfaceAreaOption>().Value);

        /// <summary>
        /// Testing the ToInpString Method for the <see cref="MinSurfaceAreaOption"/> option
        /// </summary>
        /// <param name="value">The string value that has a valid string</param>
        [Theory]
        [InlineData(MinSurfaceAreaValidString)]
        public void MinSurfaceAreaToInpStringTest(string value)
            => Assert.Contains(SetupParserTest(value).Database.GetOption<MinSurfaceAreaOption>().ToInpString(),
                value);

        #endregion
    }
}
