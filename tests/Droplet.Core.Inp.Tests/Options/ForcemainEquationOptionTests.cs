using Droplet.Core.Inp.Exceptions;
using Droplet.Core.Inp.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests.Options
{
    /// <summary>
    /// Test class that contains the tests for the <see cref="ForcemainEquationOption"/>
    /// </summary>
    public class ForcemainEquationOptionTests : FileTestsBase
    {
        public ForcemainEquationOptionTests(ITestOutputHelper logger) : base(logger)
        {
        }

        private const string DarcyWeisbachString = @"[OPTIONS]
FORCE_MAIN_EQUATION  D-W
";

        private const string HazenWilliamsString = @"[OPTIONS]
FORCE_MAIN_EQUATION  H-W
";

        private const string InvalidInpString = @"[OPTIONS]
FORCE_MAIN_EQUATION  GARBAGEDATA";

        [Theory]
        [InlineData(DarcyWeisbachString, ForcemainEquation.DarcyWeisbach)]
        [InlineData(HazenWilliamsString, ForcemainEquation.HazenWilliams)]
        public void ParseTests_ValidString_ShouldMatchValue(string inpString, ForcemainEquation expectedValue)
            => Assert.Equal(expectedValue, SetupProject(inpString).Database.GetOption<ForcemainEquationOption>().Value);

        [Theory]
        [InlineData(InvalidInpString)]
        public void ParseTests_InvalidString_ShouldThrowInpFileException(string inpString)
            => Assert.Throws<InpFileException>(() => SetupProject(inpString));

        [Theory]
        [InlineData(DarcyWeisbachString, ForcemainEquation.DarcyWeisbach)]
        [InlineData(HazenWilliamsString, ForcemainEquation.HazenWilliams)]
        public void ToInpString_ValidString_ShouldMatchValue(string expectedValue, ForcemainEquation equation)
            => Assert.Equal(PruneInpString(expectedValue, OptionsHeader), new ForcemainEquationOption(equation).ToInpString());
    }
}
