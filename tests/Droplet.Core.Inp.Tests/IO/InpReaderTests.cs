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

        #region Tests

        /// <summary>
        /// Testing the <see cref="InpFileReader.ReadLine()"/> method
        /// that is to read a line from the file.
        /// </summary>
        /// <param name="inString">The input string</param>
        /// <param name="expectedLines">The expected output</param>
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

            // Read all of the lines in the stream
            while(!reader.EndOfStream)
                strings.Add(reader.ReadLine());

            // Assert that the lines from the stream are
            // equal to the expected lines
            Assert.Equal(expectedLines, strings.ToArray());
        }

        /// <summary>
        /// Test the <see cref="InpFileReader.PeekLine"/> method
        /// which should return the next line in the stream or null if the
        /// end of the stream has been reached
        /// </summary>
        /// <param name="inString">The input string</param>
        /// <param name="expectedLines">The expected lines that will be read</param>
        [Theory]
        [ClassData(typeof(PeekedLineTestData))]
        public void PeekedLineTests(string inString, string[] expectedLines)
        {
            // Initialize the stream
            Initialize(inString);

            // The array that the lines will be added to
            var stringArray = new List<string>(expectedLines.Length);

            // The reader which will be used for this test
            using var reader = new InpFileReader(MemoryStream);

            // The peeked line should be the first line in the
            // expected array
            Assert.Equal(expectedLines[0], reader.PeekLine());

            // Read the fist line into the array
            stringArray.Add(reader.ReadLine());

            // Now peek the second line
            Assert.Equal(expectedLines[1], reader.PeekLine());

            // read the second line
            stringArray.Add(reader.ReadLine());

            // Now peek the final line
            Assert.Equal(expectedLines[2], reader.PeekLine());

            // Read the final line into the array
            stringArray.Add(reader.ReadLine());

            // Reading past the end of the stream should return null
            Assert.Null(reader.PeekLine());

            // Finally the expected lines should match the
            // outputed string array
            Assert.Equal(expectedLines, stringArray);
        }

        #endregion

        #region Test Data

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
                // String that contains \n as the
                // new line char
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

                // String that contains \r\n as the 
                // new line chars
                yield return new object[]
                {
                    "line1\r\nline2\r\nline3\r\n",

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

        /// <summary>
        /// The data class for the <see cref="PeekedLineTests(string, string[])"/> tests
        /// </summary>
        private class PeekedLineTestData : IEnumerable<object[]>
        {
            // Returns: An initial line, the first line and the
            // final expected string
            public IEnumerator<object[]> GetEnumerator()
            {
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

        #endregion
    }
}
