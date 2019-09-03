// InpSection.cs
// By: Adam Renaud
// Created: 2019-08-09

using System;
using Droplet.Core.Inp.IO;

namespace Droplet.Core.Inp.Parsers
{
    /// <summary>
    /// Base class for a section in an inp file
    /// </summary>
    public class InpSection : IInpSection
    {
        /// <summary>
        /// The project that is being parsed
        /// </summary>
        protected readonly InpProject Project;

        /// <summary>
        /// Constructor fot the Inp Section
        /// </summary>
        /// <param name="project">Project that data will be added to</param>
        protected InpSection(InpProject project)
        {
            Project = project;
        }

        /// <summary>
        /// Read the section and update the project
        /// </summary>
        /// <param name="reader">The reader that holds the file stream</param>
        public virtual void ReadSection(IInpReader reader)
        {
            for (var line = "";
                line != null && !EndOfSection(reader.PeekLine());
                line = reader.ReadLine())
            {
                // If the line is empty, whitespace or is a comment then don't parse it
                // Otherwise if the string parsed successfully then continue as well
                if (string.IsNullOrWhiteSpace(line) ||
                    line.StartsWith(";;") ||
                    ParseLine(line)) continue;

                // If the parsing was not successful for any reason throw
                // the below exception
                throw new InpParserException("The Line was not able to be parsed");
            }
        }

        /// <summary>
        /// Write this section of the inp file to a string that can be
        /// output to a new inp file
        /// </summary>
        /// <returns>Returns: A string that is this section as a part of an inp file</returns>
        public virtual string WriteSectionToInp()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the tokens from the line
        /// </summary>
        /// <param name="line">The line that the tokens will be retrieved from</param>
        /// <returns>Returns: A list of strings that will contain the tokens</returns>
        protected virtual string[] GetTokens(string line)
        {
            return line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Parse the line that is passed from the read section function
        /// </summary>
        /// <param name="line">The line that is to be parsed</param>
        /// <returns>Returns: True if parsing was successful</returns>
        protected virtual bool ParseLine(string line)
        {
            return false;
        }

        /// <summary>
        /// Check to see if the current line matches the 
        /// pattern for a new section
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static bool EndOfSection(string line) => line.StartsWith("[");
    }
}
