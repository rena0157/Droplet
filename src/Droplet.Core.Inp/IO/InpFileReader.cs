using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Droplet.Core.Inp.IO
{
    /// <summary>
    /// A reader for inp files that implements the <see cref="IInpReader"/> interface
    /// and inherits from the <see cref="StreamReader"/> class
    /// </summary>
    public class InpFileReader : StreamReader, IInpReader
    {
        #region Constructors

        public InpFileReader(Stream stream) : base(stream)
        {
        }

        public InpFileReader(string path) : base(path)
        {
        }

        public InpFileReader(Stream stream, bool detectEncodingFromByteOrderMarks) : base(stream, detectEncodingFromByteOrderMarks)
        {
        }

        public InpFileReader(Stream stream, Encoding encoding) : base(stream, encoding)
        {
        }

        public InpFileReader(string path, bool detectEncodingFromByteOrderMarks) : base(path, detectEncodingFromByteOrderMarks)
        {
        }

        public InpFileReader(string path, Encoding encoding) : base(path, encoding)
        {
        }

        public InpFileReader(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks) : base(stream, encoding, detectEncodingFromByteOrderMarks)
        {
        }

        public InpFileReader(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks) : base(path, encoding, detectEncodingFromByteOrderMarks)
        {
        }

        public InpFileReader(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize) : base(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize)
        {
        }

        public InpFileReader(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize) : base(path, encoding, detectEncodingFromByteOrderMarks, bufferSize)
        {
        }

        public InpFileReader(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize, bool leaveOpen) : base(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize, leaveOpen)
        {
        }

        #endregion

        /// <summary>
        /// The queue that holds the previous line if a line was
        /// peeked
        /// </summary>
        protected Queue<string> LineQueue { get; }

        /// <summary>
        /// Peek the next line without consuming the position
        /// of the stream
        /// </summary>
        /// <returns>Returns: The next line of the stream</returns>
        public string PeekLine()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Read the next line of the stream
        /// </summary>
        /// <returns>Returns: </returns>
        public override string ReadLine()
        {
            throw new NotImplementedException();
        }
    }
}
