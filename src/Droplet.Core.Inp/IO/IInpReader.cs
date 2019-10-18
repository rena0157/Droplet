// IInpReader.cs
// Created: 2019-09-10
// By: Adam Renaud

namespace Droplet.Core.Inp.IO
{
    /// <summary>
    /// Interface for Inp Readers
    /// </summary>
    public interface IInpReader
    {
        /// <summary>
        /// Returns true if the reader has reached the end of the stream
        /// </summary>
        bool EndOfStream { get; }

        /// <summary>
        /// Reads the next line in the inp stream
        /// </summary>
        /// <returns>Returns: The Next line in the Inp Stream</returns>
        string ReadLine();

        /// <summary>
        /// Peeks the next line in the inp stream
        /// </summary>
        /// <returns>Returns: The next line in the inp stream without consuming
        /// the current index</returns>
        string? PeekLine();
    }
}
