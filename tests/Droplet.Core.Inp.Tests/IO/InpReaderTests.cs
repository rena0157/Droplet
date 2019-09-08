using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Droplet.Core.Inp.IO;
using Droplet.Core.Inp.Tests;
using Xunit;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests.IO
{
    public class InpFileReaderTests : FileTestsBase
    {
        public InpFileReaderTests(ITestOutputHelper logger) : base(logger)
        {
        }

        [Theory]
        [ClassData(typeof(ReadLineTestsData))]
        public void ReadLineTests(string inString, string[] expectedLines)
        {
            // Initialize the stream
            Initialize(inString);

            // The strings the will compared with the expected lines
            var strings = new List<string>(expectedLines.Length);

            // Set up the reader and strings
            using var reader = new InpFileReader(MemoryStream);
            var line = reader.ReadLine();

            Assert.Equal(expectedLines, strings.ToArray());
        }

        /// <summary>
        /// The data class for the <see cref="ReadLineTests(string, string[])"/>
        /// </summary>
        private class ReadLineTestsData : IEnumerable<object[]>
        {
            /// <summary>
            /// Get the data for the tests will return a <see cref="string"/> and
            /// <see cref="string[]"/>
            /// </summary>
            /// <returns></returns>
            public IEnumerator<object[]> GetEnumerator()
            {
                // Testing with just \n chars for the
                // new lines
                yield return new object[]
                {
                    "line1\nline2\nline3\n",

                    new string[]
                    {
                        "line1",
                        "line2",
                        "line3"
                    }
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
