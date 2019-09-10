// IInpParser.cs
// Created: 2019-09-10
// By: Adam Renaud

namespace Droplet.Core.Inp.IO
{
    /// <summary>
    /// A top level parser for inp files
    /// </summary>
    public interface IInpParser
    {
        /// <summary>
        /// Parse the file using the reader supplied and place the
        /// data into the project
        /// </summary>
        /// <param name="inpProject">The project that will be updated</param>
        /// <param name="reader">The reader that will be used to read the file</param>
        void ParseFile(IInpProject inpProject, IInpReader reader);
    }
}
