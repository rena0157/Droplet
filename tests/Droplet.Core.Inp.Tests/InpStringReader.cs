// InpStringReader.cs
// By: Adam Renaud
// Created: 2019-09-04 @ 8:00pm

using Droplet.Core.Inp.IO;
using System;
using System.Collections.Generic;

namespace Droplet.Core.Inp.Tests
{
    /// <summary>
    /// Class that simulates a StreamReader for InpStrings.
    /// This class will store the inpstring as lines in a local property from
    /// which data can be read. This simulation of data is used for testing purposes
    /// only.
    /// </summary>
    public class InpStringReader : IInpReader
    {
        #region Protected Properties

        /// <summary>
        /// The container that will hold the lines
        /// of the strings from the inp file
        /// </summary>
        protected string[] StringLines { get; set; }

        /// <summary>
        /// The current line index that simulates
        /// the streams position
        /// </summary>
        protected int LineIndex { get; set; }

        /// <summary>
        /// The queue that is used to store a line that
        /// is peeked but not read
        /// </summary>
        protected Queue<string> LineQueue { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the class and sets public properties
        /// to their defaults
        /// </summary>
        public InpStringReader()
        {
            // Setting the default values for the
            // properties of this class
            LineQueue = new Queue<string>();
            LineIndex = 0;
        }

        /// <summary>
        /// Constructor that accepts a string
        /// that represents data from an inp file.
        /// </summary>
        /// <param name="inpString">The string from an inp file</param>
        public InpStringReader(string inpString) : this()
        {
            SetData(inpString);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Returns true if the end of the stream has been reached
        /// </summary>
        public bool EndOfStream => !(LineIndex < StringLines.Length);

        #endregion

        #region Public Methods

        /// <summary>
        /// Set the value of the Stream
        /// </summary>
        /// <param name="inpString">The inp String that will be used to set the value</param>
        public void SetData(string inpString)
        {
            // Populate the stringlines array with the inp string
            StringLines = inpString.Split(new[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Peeks the next line in the stream without
        /// consuming the index to the next line.
        /// </summary>
        /// <returns>Returns: A string that is the next line in the Stream</returns>
        public string PeekLine()
        {
            // If reading the next line would be out of bounds
            // of the array then let the user know
            if (EndOfStream)
                throw new ArgumentOutOfRangeException("Reading past the end of the stream " +
                    $"Trying to read the index {LineIndex + 1} " +
                    $"value of an array of length {StringLines.Length}");

            // Get the next line from the StringLines Array
            // but do not increment the line index
            var line = StringLines[LineIndex];

            // Enqueue the line for future use and then return it
            LineQueue.Enqueue(line);
            return line;
        }

        /// <summary>
        /// Read the next line from the stream.
        /// </summary>
        /// <returns>Returns: the next line from the stream</returns>
        public string ReadLine()
        {
            // If there is a line that is queued then
            // read that line and return
            if (LineQueue.Count != 0)
                return LineQueue.Dequeue();

            // If we are trying to read past the end of the array
            // will throw the following exception
            if (EndOfStream)
                throw new ArgumentOutOfRangeException("Reading past the end of the stream " +
                    $"Trying to read the index {LineIndex} " +
                    $"value of an array of length {StringLines.Length}");

            // Otherwise return the next line in the array
            // and increment the line index to the next value
            return StringLines[LineIndex++];
        }

        #endregion
    }
}
