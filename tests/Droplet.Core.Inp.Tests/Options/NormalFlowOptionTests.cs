using Droplet.Core.Inp.Exceptions;
using Droplet.Core.Inp.Options;
using Xunit;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests.Options
{
    public class NormalFlowOptionTests : FileTestsBase
    {
        #region Constructor

        public NormalFlowOptionTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #endregion

        #region Tests

        private const string ValidInpString_Froude = @"[OPTIONS]
NORMAL_FLOW_LIMITED  FROUDE
";

        private const string ValidInpString_Slope = @"[OPTIONS]
NORMAL_FLOW_LIMITED  SLOPE
";

        private const string ValidInpString_Both = @"[OPTIONS]
NORMAL_FLOW_LIMITED  BOTH
";

        private const string InvalidString = @"[OPTIONS]
NORMAL_FLOW_LIMITED  INVALIDDATA
";

        [Theory]
        [InlineData(ValidInpString_Froude, NormalFlowCriterion.Froude)]
        [InlineData(ValidInpString_Slope, NormalFlowCriterion.Slope)]
        [InlineData(ValidInpString_Both, NormalFlowCriterion.SlopeAndFroude)]
        public void ParserTest_ValidInpString_ShouldMatchValue(string inpString, NormalFlowCriterion expectedValue)
            => Assert.Equal(expectedValue, SetupProject(inpString).Database.GetOption<NormalFlowOption>().Value);

        [Theory]
        [InlineData(InvalidString)]
        public void ParserTest_InvalidString_ShouldThrowInpFileException(string inpString)
            => Assert.Throws<InpFileException>(() => SetupProject(inpString));

        [Theory]
        [InlineData(ValidInpString_Froude, NormalFlowCriterion.Froude)]
        [InlineData(ValidInpString_Slope, NormalFlowCriterion.Slope)]
        [InlineData(ValidInpString_Both, NormalFlowCriterion.SlopeAndFroude)]
        public void ToInpString_ValidString_ShouldMatchValue(string expectedString, NormalFlowCriterion value)
            => Assert.Equal(PruneInpString(expectedString, OptionsHeader), new NormalFlowOption(value).ToInpString());

        #endregion
    }
}
