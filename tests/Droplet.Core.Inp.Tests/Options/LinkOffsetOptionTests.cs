using Droplet.Core.Inp.IO;
using Droplet.Core.Inp.Options;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests.Options
{
    /// <summary>
    /// Class that contains all of the tests for the
    /// <see cref="LinkOffsetOption"/> option
    /// </summary>
    public class LinkOffsetOptionTests : FileTestsBase
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="logger">Sets the logger for this class from Xunit</param>
        public LinkOffsetOptionTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #region Tests

        /// <summary>
        /// Test the parsing of the <see cref="LinkOffsetOption"/>
        /// </summary>
        /// <param name="inpString">An inp string that could be from a file</param>
        /// <param name="expectedLinkOffset">The expected <see cref="LinkOffset"/> that the
        /// parser should generate</param>
        [Theory]
        [ClassData(typeof(ParserTestData))]
        public void ParserTests(string inpString, LinkOffset expectedLinkOffset)
        {
            Initialize(inpString);
            InpProject project = new InpProject();
            InpFileReader reader = new InpFileReader(MemoryStream);
            InpParser parser = new InpParser();
            parser.ParseFile(project, reader);

            LinkOffsetOption option = project.Database.GetOption<LinkOffsetOption>();

            Assert.Equal(expectedLinkOffset, option.Value);
        }

        #endregion  

        #region Test Data

        /// <summary>
        /// Test data for the <see cref="ParserTests(string, LinkOffset)"/>
        /// </summary>
        private class ParserTestData : IEnumerable<object[]>
        {
            /// <summary>
            /// Get Enumerator implementation for the <see cref="IEnumerable{Object}"/> class
            /// that will return the data for the tests
            /// </summary>
            /// <returns>Returns: An inpString and the expected <see cref="LinkOffset"/> that
            /// the parser should return</returns>
            public IEnumerator<object[]> GetEnumerator()
            {
                // Depth
                yield return new object[]
                {
                    @"[OPTIONS]
LINK_OFFSETS         DEPTH
",

                    LinkOffset.DepthOffset
                };

                // Elevation
                yield return new object[]
                {
                    @"[OPTIONS]
LINK_OFFSETS         ELEVATION
",

                    LinkOffset.ElevationOffset
                };
            }

            /// <summary>
            /// Implementation of the <see cref="IEnumerable{T}.GetEnumerator"/> method
            /// that calls <see cref="GetEnumerator"/>
            /// </summary>
            /// <returns>The same as <see cref="GetEnumerator"/></returns>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        #endregion
    }
}
