using Droplet.Core.Inp.IO;
using Droplet.Core.Inp.Options;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests.Options
{
    /// <summary>
    /// Test class for
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
        /// Test the parsing of the <see cref="FlowRoutingOption"/>
        /// option from an inp file
        /// </summary>
        /// <param name="value">The Inp string value</param>
        /// <param name="exectedValue">The expected value from the parser</param>
        [Theory]
        [ClassData(typeof(ParserTestData))]
        public void ParserTests(string value, FlowRouting expectedValue)
            => Assert.Equal(expectedValue, SetupParserTest(value).Database.GetOption<FlowRoutingOption>().Value);

        #endregion

        #region Test Data

        /// <summary>
        /// Test data for the <see cref="ParserTests(string, FlowRouting)"/>
        /// tests
        /// </summary>
        public class ParserTestData : IEnumerable<object[]>
        {
            /// <summary>
            /// Gets a <see cref="string"/> that represents an inp string
            /// and a <see cref="FlowRouting"/> option that 
            /// should be parsed from the string.
            /// </summary>
            /// <returns>Returns: a <see cref="string"/> and a <see cref="FlowRouting"/> option</returns>
            public IEnumerator<object[]> GetEnumerator()
            {
                // Steady flow
                yield return new object[]
                {
                    @"[OPTIONS]
FLOW_ROUTING         STEADY
",

                    FlowRouting.SteadyFlow
                };

                // Kinematic Wave
                yield return new object[]
                {
                    @"[OPTIONS]
FLOW_ROUTING         KINWAVE
",

                    FlowRouting.KinematicWave
                };

                // Dynamic Wave
                yield return new object[]
                {
                    @"[OPTIONS]
FLOW_ROUTING         DYNWAVE
",

                    FlowRouting.DynamicWave
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion
    }
}
