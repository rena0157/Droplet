using Droplet.Core.Inp.IO;
using Droplet.Core.Inp.Options;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests.Options
{
    /// <summary>
    /// Test class for the <see cref="InfiltrationOption"/> class
    /// </summary>
    public class InfiltrationOptionTests : FileTestsBase
    {
        /// <summary>
        /// Default constructor for this class
        /// </summary>
        /// <param name="logger">A logger that is passed from Xunit</param>
        public InfiltrationOptionTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #region Tests

        /// <summary>
        /// Testing the parsing of the <see cref="InfiltrationOption"/> option
        /// </summary>
        /// <param name="value">The inp string from a file</param>
        /// <param name="method">The expected method from that string</param>
        [Theory]
        [ClassData(typeof(ParserTestData))]
        public void ParserTests(string value, InfiltrationMethods method)
        {
            Initialize(value);
            var project = new InpProject();
            var parser = new InpParser();
            var reader = new InpFileReader(stream: MemoryStream);
            parser.ParseFile(inpProject: project, reader: reader);

            var option = project.Database.GetOption<InfiltrationOption>();

            Assert.Equal(method, (InfiltrationMethods)option.Value);
        }

        #endregion

        #region Test Data

        /// <summary>
        /// Test data for <see cref="InfiltrationOptionTests.ParserTests(string, InfiltrationMethods)"/>
        /// </summary>
        private class ParserTestData : IEnumerable<object[]>
        {
            /// <summary>
            /// Get Enumerator function that holds the test data
            /// </summary>
            /// <returns>Returns: The inp string that corresponds to the expected
            /// Infiltration method</returns>
            public IEnumerator<object[]> GetEnumerator()
            {
                // Horton
                yield return new object[]
                {
                    @"[OPTIONS]
INFILTRATION         HORTON
",

                    InfiltrationMethods.Horton
                };

                // Modified Horton
                yield return new object[]
{
                    @"[OPTIONS]
INFILTRATION         MODIFIED_HORTON
",

                    InfiltrationMethods.ModifiedHorton
                };

                // Green-Ampt
                yield return new object[]
{
                    @"[OPTIONS]
INFILTRATION         GREEN_AMPT
",

                    InfiltrationMethods.GreenAmpt
                };

                // Modified Green-Ampt
                yield return new object[]
{
                    @"[OPTIONS]
INFILTRATION         MODIFIED_GREEN_AMPT
",

                    InfiltrationMethods.ModifiedGreenAmpt
                };

                // Curve-Number
                yield return new object[]
{
                    @"[OPTIONS]
INFILTRATION         CURVE_NUMBER
",

                    InfiltrationMethods.CurveNumber
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion
    }
}
