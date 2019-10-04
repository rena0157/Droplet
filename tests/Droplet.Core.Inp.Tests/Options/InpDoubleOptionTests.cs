using Droplet.Core.Inp.Entities;
using Droplet.Core.Inp.Exceptions;
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
            => Assert.Equal(expectedValue, SetupProject(value).Database.GetOption<MinSlopeOption>().Value);

        /// <summary>
        /// Testing the ToInpString Method for the <see cref="MinSlopeOption"/>
        /// </summary>
        /// <param name="value"></param>
        [Theory]
        [InlineData(MinSlopeValidString, 0.15)]
        public void MinSlopeToInpStringTest(string inpString, double value)
            => Assert.Equal(PruneInpString(inpString, OptionsHeader), new MinSlopeOption(value).ToInpString());

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
            => Assert.Equal(expectedValue, SetupProject(value).Database.GetOption<MinSurfaceAreaOption>().Value);

        /// <summary>
        /// Testing the ToInpString Method for the <see cref="MinSurfaceAreaOption"/> option
        /// </summary>
        /// <param name="value">The string value that has a valid string</param>
        [Theory]
        [InlineData(MinSurfaceAreaValidString, 1.167)]
        public void MinSurfaceAreaToInpStringTest(string inpString, double value)
            => Assert.Equal(PruneInpString(inpString, OptionsHeader), new MinSurfaceAreaOption(value).ToInpString());

        #endregion

        #region Head Tolerance Tests

        /// <summary>
        /// Valid string for the <see cref="HeadToleranceOption"/>
        /// </summary>
        private const string HeadTolerance_ValidString = @"[OPTIONS]
HEAD_TOLERANCE       0.0015";

        /// <summary>
        /// Invalid string for the <see cref="HeadToleranceOption"/>
        /// </summary>
        private const string HeadTolderance_InvalidString = @"[OPTIONS]
HEAD_TOLERANCE       INVALIDSTRING
";

        /// <summary>
        /// Testing the parsing of <see cref="HeadToleranceOption"/> with a valid <see cref="string"/>
        /// </summary>
        /// <param name="inpString">The valid string that contains the <see cref="HeadToleranceOption"/></param>
        /// <param name="value">The value that is expected from the parser</param>
        [Theory]
        [InlineData(HeadTolerance_ValidString, 0.0015)]
        public void HeadToleranceParser_ValidString_ShouldMatchValue(string inpString, double value)
            => Assert.Equal(value, SetupProject(inpString).Database.GetOption<HeadToleranceOption>().Value);

        /// <summary>
        /// Testing the parsing of <see cref="HeadToleranceOption"/> with an invalid string.
        /// </summary>
        /// <param name="inpString">The invalid string</param>
        [Theory]
        [InlineData(HeadTolderance_InvalidString)]
        public void HeadToleranceParser_InvalidString_ShouldThrowInpFileException(string inpString)
            => Assert.Throws<InpFileException>(() => SetupProject(inpString));

        /// <summary>
        /// Testing the <see cref="IInpEntity.ToInpString"/> method as overridden for the 
        /// <see cref="HeadToleranceOption"/>
        /// </summary>
        /// <param name="expected">The expected <see cref="string"/></param>
        /// <param name="value">The value that will create a new <see cref="HeadToleranceOption"/></param>
        [Theory]
        [InlineData(HeadTolerance_ValidString, 0.0015)]
        public void HeadTolerance_ToInpString_ShouldMatchExpected(string expected, double value)
            => Assert.Equal(PruneInpString(expected, OptionsHeader), new HeadToleranceOption(value).ToInpString());

        #endregion

        #region Variable Step Tests



        #endregion
    }
}
