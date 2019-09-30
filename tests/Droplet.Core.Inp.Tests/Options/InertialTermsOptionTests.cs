using Droplet.Core.Inp.Exceptions;
using Droplet.Core.Inp.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests.Options
{
    /// <summary>
    /// Test class for <see cref="InertialTermsOption"/>
    /// </summary>
    public class InertialTermsOptionTests : FileTestsBase
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="logger">Logger passed form Xunit</param>
        public InertialTermsOptionTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #region Tests

        /// <summary>
        /// Testing the parsing of the <see cref="InertialTermsOption"/>
        /// </summary>
        /// <param name="value">A <see cref="string"/> that is from an inp file that contains
        /// the option</param>
        /// <param name="expectedValue">The expected value that the parser should create from the string passed in</param>
        [Theory]
        [ClassData(typeof(InertialTermsParserTestData))]
        public void ParserTests_ValidInpString(string value, InertialTermsHandling expectedValue)
            => Assert.Equal(expectedValue, SetupProject(value).Database.GetOption<InertialTermsOption>().Value);

        /// <summary>
        /// Testing this class under the circumstance that garbage data is in the place
        /// of the expected data
        /// </summary>
        /// <param name="value">The string that contains the data</param>
        [Theory]
        [InlineData("[OPTIONS]\nINERTIAL_DAMPING     GARBAGEDATA\n")]
        public void ParserTests_InvalidInpString(string value)
            => Assert.Throws<InpFileException>(() => SetupProject(value));

        /// <summary>
        /// Test data for the <see cref="ParserTests_ValidInpString(string, InertialTermsHandling)"/> tests
        /// </summary>
        private class InertialTermsParserTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                // Dampen
                yield return new object[]
                {
                    @"[OPTIONS]
INERTIAL_DAMPING     PARTIAL
",
                    InertialTermsHandling.Dampen
                };

                // Keep
                yield return new object[]
                {
                    @"[OPTIONS]
INERTIAL_DAMPING     NONE
",
                    InertialTermsHandling.Keep
                };

                // Ignore
                yield return new object[]
                {
                    @"[OPTIONS]
INERTIAL_DAMPING     FULL
",
                    InertialTermsHandling.Ignore
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion
    }
}
