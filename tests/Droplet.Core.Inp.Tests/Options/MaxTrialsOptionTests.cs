using Droplet.Core.Inp.Entities;
using Droplet.Core.Inp.Exceptions;
using Droplet.Core.Inp.Options;
using Xunit;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests.Options
{
    /// <summary>
    /// Class that holds the tests for the <see cref="MaxTrialsOption"/>
    /// </summary>
    public class MaxTrialsOptionTests : FileTestsBase
    {

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="logger">Logger from <see cref="Xunit"/></param>
        public MaxTrialsOptionTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #endregion

        #region Tests

        /// <summary>
        /// A valid inp string that contains the <see cref="MaxTrialsOption"/> and the value 8
        /// </summary>
        private const string ValidInpString = @"[OPTIONS]
MAX_TRIALS           8
";

        /// <summary>
        /// An invalid inp string that contains the <see cref="MaxTrialsOption"/>
        /// </summary>
        private const string InvalidInpString = @"[OPTIONS]
MAX_TRIALS           INVALIDSTRING
";


        /// <summary>
        /// Testing the parsing of the <see cref="MaxTrialsOption"/>
        /// </summary>
        /// <param name="inpString">The string being parsed</param>
        /// <param name="expectedValue">The expected value from the parser</param>
        [Theory]
        [InlineData(ValidInpString, 8)]
        public void Parser_ValidString_ShouldMatchExpected(string inpString, int expectedValue)
            => Assert.Equal(expectedValue, SetupProject(inpString).Database.GetOption<MaxTrialsOption>().Value);


        /// <summary>
        /// Tests that an <see cref="InpFileException"/> will be thrown if an unexpected value is sent 
        /// to the parser
        /// </summary>
        /// <param name="value">The unexpected value</param>
        [Theory]
        [InlineData(InvalidInpString)]
        public void Parser_InvalidString_ShouleThrowInpFileException(string value)
            => Assert.Throws<InpFileException>(() => SetupProject(value));

        /// <summary>
        /// Testing the <see cref="IInpEntity.ToInpString"/> method override 
        /// for the <see cref="MaxTrialsOption"/>
        /// </summary>
        /// <param name="expectedString">The expected <see cref="string"/></param>
        /// <param name="value">The value of the option</param>
        [Theory]
        [InlineData(ValidInpString, 8)]
        public void ToInpString_ValidString_ShouldMatchValue(string expectedString, int value)
            => Assert.Equal(PruneInpString(expectedString, OptionsHeader), new MaxTrialsOption(value).ToInpString());

        #endregion

    }
}
