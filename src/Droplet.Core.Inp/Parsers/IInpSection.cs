// IInpSection.cs
// By: Adam Renaud
// Created: 2019-08-09

using System;
using System.Collections.Generic;
using System.IO;
using Droplet.Core.Inp.IO;

namespace Droplet.Core.Inp.Parsers
{
    /// <summary>
    /// The public interface for inp sections
    /// </summary>
    public interface IInpSection
    {
        /// <summary>
        /// Read the section from the file and update the properties in
        /// the project
        /// </summary>
        /// <param name="reader">The reader that will be used to build the section</param>
        void ReadSection(IInpReader reader);

        /// <summary>
        /// Write the section to an InpString
        /// </summary>
        /// <returns>Returns: the section as a section of an inp file</returns>
        string WriteSectionToInp();

    }
}
