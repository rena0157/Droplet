using Droplet.Core.Inp.Exceptions;
using Droplet.Core.Inp.Options;
using Droplet.Core.Inp.Entities;
using Xunit;
using Xunit.Abstractions;
using System;

namespace Droplet.Core.Inp.Tests.Options
{
    /// <summary>
    /// Test class for <see cref="FlowRoutingOption"/>
    /// </summary>
    public class FlowRoutingOptionTests : FileTestsBase
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="logger">A logger that is passed from <see cref="Xunit"/></param>
        public FlowRoutingOptionTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #endregion

        #region Tests

        /// <summary>
        /// Flow Routing Inp String for the <see cref="FlowRouting.SteadyFlow"/> value
        /// </summary>
        private const string FlowRoutingValidInpStringSteady = @"[OPTIONS]
FLOW_ROUTING         STEADY
";

        /// <summary>
        /// <see cref="FlowRouting"/> Inp String for the <see cref="FlowRouting.DynamicWave"/> value
        /// </summary>
        private const string FlowRoutingValidInpStringDynamic = @"[OPTIONS]
FLOW_ROUTING         DYNWAVE
";

        /// <summary>
        /// <see cref="FlowRouting"/> Inp <see cref="string"/> for the <see cref="FlowRouting.KinematicWave"/> value
        /// </summary>
        private const string FlowRoutingValidInpStringKynwave = @"[OPTIONS]
FLOW_ROUTING         KINWAVE
";

        /// <summary>
        /// A string that contains garbage data for the <see cref="FlowRoutingOption"/>
        /// </summary>
        private const string FlowRoutingInvalidString = @"[OPTIONS]
FLOW_ROUTING        GARBAGE DATA
";

        /// <summary>
        /// Test the parsing of the <see cref="FlowRoutingOption"/>
        /// option from an inp file
        /// </summary>
        /// <param name="value">The Inp string value</param>
        /// <param name="exectedValue">The expected value from the parser</param>
        [Theory]
        [InlineData(FlowRoutingValidInpStringSteady, FlowRouting.SteadyFlow)]
        [InlineData(FlowRoutingValidInpStringDynamic, FlowRouting.DynamicWave)]
        [InlineData(FlowRoutingValidInpStringKynwave, FlowRouting.KinematicWave)]
        public void ParserTests_ValidInpString_ShouldMatchExpectedValue(string value, FlowRouting expectedValue)
            => Assert.Equal(expectedValue, SetupProject(value).Database.GetOption<FlowRoutingOption>().Value);

        /// <summary>
        /// Testing what happens if an invalid string is passed to the parser
        /// </summary>
        /// <param name="value">The invalid string</param>
        [Theory]
        [InlineData(FlowRoutingInvalidString)]
        public void ParserTests_InvalidInpString_ShouldThrowInpFileException(string value)
            => Assert.Throws<InpFileException>(() => SetupProject(value));

        /// <summary>
        /// Testing the <see cref="IInpEntity.ToInpString"/> method as implemented for the 
        /// <see cref="FlowRoutingOption"/> class
        /// </summary>
        /// <param name="value"></param>
        [Theory]
        [InlineData(FlowRoutingValidInpStringSteady)]
        [InlineData(FlowRoutingValidInpStringDynamic)]
        [InlineData(FlowRoutingValidInpStringKynwave)]
        public void ToInpString_ValidString_ShouldMatchPassedString(string value)
        {
            // Arrange: Set up the project
            var project = SetupProject(value);

            // Act: Get the actual value of the string
            var actualValue = project.Database.GetOption<FlowRoutingOption>().ToInpString();

            // Assert: The string must match the value that is passed without the [OPTIONS] and new lines
            Assert.Equal(value.Replace("[OPTIONS]", "").Replace(Environment.NewLine,""), actualValue);
        }

        #endregion
    }
}
