using Droplet.Core.Inp.Exceptions;
using Droplet.Core.Inp.Options;
using Xunit;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests.Options
{
    /// <summary>
    /// Class that holds the tests for the <see cref="ThreadCountOption"/>
    /// </summary>
    public class ThreadCountOptionTests : FileTestsBase
    {
        public ThreadCountOptionTests(ITestOutputHelper logger) : base(logger)
        {
        }

        private const string ValidString = @"[OPTIONS]
THREADS              8
";

        private const string InvalidString = @"[OPTIONS]
THREADS              INVALIDSTRING";

        [Theory]
        [InlineData(ValidString, 8)]
        public void ParserTest_ValidString_ShouldMatchValue(string inpString, int value)
            => Assert.Equal(value, SetupProject(inpString).Database.GetOption<ThreadCountOption>().Value);

        [Theory]
        [InlineData(InvalidString)]
        public void ParserTest_InvalidString_ShouldThrowInpFileException(string inpString)
            => Assert.Throws<InpFileException>(() => SetupProject(inpString));

        [Theory]
        [InlineData(ValidString, 8)]
        public void ToInpString_ValidString_ShouldMatchValue(string expectedString, int value)
            => Assert.Equal(PruneInpString(expectedString, OptionsHeader), new ThreadCountOption(value).ToInpString());
    }
}
