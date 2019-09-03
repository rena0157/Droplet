// InpFileTests.cs
// By: Adam Renaud
// Created: 2019-08-17

using System;
using System.IO;
using Droplet.Core.Inp.IO;
using Xunit;
using Xunit.Abstractions;
using Droplet.Core.Inp.Parsers;

namespace InpLibTests
{
    /// <summary>
    /// A testing class that inherits from <see cref="IInpReader"/> so that
    /// it can be passed to the <see cref="InpParser"/> and the contents
    /// of the filelines can be read
    /// </summary>
    public class InpFileTests : TestBase, IInpReader
    {
        /// <summary>
        /// The filelines that will be read by the <see cref="InpParser"/>
        /// </summary>
        protected string[] FileLines;

        /// <summary>
        /// The line pointer that points to the current index of the
        /// <see cref="InpFileTests.FileLines"/>
        /// </summary>
        private int _linePointer;

        /// <summary>
        /// The root folder for test files
        /// </summary>
        private const string _rootFolder = @".\TestFiles\";

        /// <summary>
        /// The default constructor for the <see cref="InpFileTests"/> class
        /// </summary>
        /// <param name="logger">The logger that is passed for Xunit</param>
        public InpFileTests(ITestOutputHelper logger) : base(logger)
        {
        }

        /// <summary>
        /// Read a file from the file name provided
        /// </summary>
        /// <param name="filename">The filename provided that will be read</param>
        protected void ReadFile(string filename)
        {
            var path = Path.Combine(_rootFolder, filename);
            Assert.True(File.Exists(Path.Combine(_rootFolder, filename)));
            FileLines = File.ReadAllLines(path);
            _linePointer = 0;
        }

        /// <summary>
        /// Populate the <see cref="FileLines"/> field from a string
        /// </summary>
        /// <param name="s">The string that will be used to populate the filelines array</param>
        protected void FileLinesFromString(string s)
            => FileLines = s.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        /// <summary>
        /// Returns True if the stream has reached its end
        /// </summary>
        public bool EndOfStream => _linePointer >= FileLines.Length;

        /// <summary>
        /// Peek a line without advancing the stream
        /// </summary>
        /// <returns>Returns: A string</returns>
        public string PeekLine()
        {
            if (_linePointer < FileLines.Length && FileLines.Length > 0)
                return FileLines[_linePointer];
            else
                return "";
        }

        /// <summary>
        /// Read the next line
        /// </summary>
        /// <returns>Returns: The next line in the stream</returns>
        public string ReadLine()
        {
            if (_linePointer < FileLines.Length && FileLines.Length > 0)
                return FileLines[_linePointer++];
            else
                return null;
        }

    }
}
