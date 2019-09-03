// IInpReader.cs
// By: Adam Renaud
// Created: 2019-08-17

namespace Droplet.Core.Inp.IO
{
    /// <summary>
    /// Interface for an InpReader
    /// </summary>
    public interface IInpReader
    {
        /// <summary>
        /// Read a line from the file
        /// </summary>
        /// <returns>Returns a line from the file</returns>
        string ReadLine();

        /// <summary>
        /// Peek a line from the file. This does not advance
        /// stream
        /// </summary>
        /// <returns>Returns: The next line the in the file</returns>
        string PeekLine();

        /// <summary>
        /// Returns true if this inp reader has reached
        /// the end of the stream that it is reading from
        /// </summary>
        bool EndOfStream { get; }
    }

}
