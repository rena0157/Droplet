// InpReader.cs
// By: Adam Renaud
// Created: 2019-09-08

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Droplet.Core.Inp.IO
{
    /// <summary>
    /// InpReader class that inherites from the streareader class
    /// </summary>
    public class InpReader : StreamReader, IInpReader
    {
        #region Private Fields

        /// <summary>
        /// The Queue where lines are stored after a Peek
        /// </summary>
        public Queue<string> _lineQueue;

        #endregion

        #region Constructors

        public InpReader(Stream stream) : base(stream)
        {
            _lineQueue = new Queue<string>();
        }

        public InpReader(string path) : base(path)
        {
            _lineQueue = new Queue<string>();
        }

        public InpReader(Stream stream, bool detectEncodingFromByteOrderMarks) :
            base(stream, detectEncodingFromByteOrderMarks)
        {
            _lineQueue = new Queue<string>();
        }

        public InpReader(Stream stream, Encoding encoding) :
            base(stream, encoding)
        {
            _lineQueue = new Queue<string>();
        }

        public InpReader(string path, bool detectEncodingFromByteOrderMarks) :
            base(path, detectEncodingFromByteOrderMarks)
        {
            _lineQueue = new Queue<string>();
        }

        public InpReader(string path, Encoding encoding) :
            base(path, encoding)
        {
            _lineQueue = new Queue<string>();
        }

        public InpReader(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks) :
            base(stream, encoding, detectEncodingFromByteOrderMarks)
        {
            _lineQueue = new Queue<string>();
        }

        public InpReader(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks) :
            base(path, encoding, detectEncodingFromByteOrderMarks)
        {
            _lineQueue = new Queue<string>();
        }

        public InpReader(Stream stream, Encoding encoding,
            bool detectEncodingFromByteOrderMarks, int bufferSize) :
            base(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize)
        {
            _lineQueue = new Queue<string>();
        }

        public InpReader(string path, Encoding encoding,
            bool detectEncodingFromByteOrderMarks, int bufferSize) :
            base(path, encoding, detectEncodingFromByteOrderMarks, bufferSize)
        {
            _lineQueue = new Queue<string>();
        }

        public InpReader(Stream stream, Encoding encoding,
            bool detectEncodingFromByteOrderMarks, int bufferSize, bool leaveOpen) :
            base(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize, leaveOpen)
        {
            _lineQueue = new Queue<string>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Read a line from the stream
        /// </summary>
        /// <returns>Returns: A string that is a line from the stream</returns>
        public override string ReadLine()
        {
            if (_lineQueue.Count == 0)
                return base.ReadLine();
            else
                return _lineQueue.Dequeue();
        }

        /// <summary>
        /// Peek a line from the stream without advancing it to the
        /// next line
        /// </summary>
        /// <returns>Returns: a line from the stream</returns>
        public string PeekLine()
        {
            var line = base.ReadLine();
            _lineQueue.Enqueue(line);
            return line;
        }

        #endregion
    }
}
