// InpParser.cs
// By: Adam Renaud
// Created: 2019-08-09

using System;
using Droplet.Core.Inp.IO;

namespace Droplet.Core.Inp.Parsers
{
    /// <summary>
    /// Main Parsing class for Inp Files
    /// </summary>
    public class InpParser
    {
        #region Private Fields

        /// <summary>
        /// The reader that will be used by this parser
        /// </summary>
        private readonly IInpReader _reader;

        #endregion

        #region Constructorwss

        /// <summary>
        /// Default Constructor for the InpParser
        /// </summary>
        /// <param name="reader">The reader th</param>
        public InpParser(IInpReader reader)
        {
            _reader = reader;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get the sectionType from the section name that is passed
        /// </summary>
        /// <param name="sectionName">The section name</param>
        /// <returns>Returns: A type that corresponds to the correct section</returns>
        private static Type GetSectionType(string sectionName)
        {
            Type sectionType;
            switch (sectionName)
                {
                    case "OPTIONS":
                        sectionType = typeof(InpOptionsSection);
                        break;
                    
                    // Table Sections - each case will fall into the
                    // next switch block
                    case "SUBCATCHMENTS":
                    case "GROUNDWATER":
                    case "SUBAREAS":
                    case "INFILTRATION":
                    case "AQUIFERS":
                        sectionType = typeof(InpTableSection);
                        break;
                    default:
                        sectionType = null;
                        break;
                }
            return sectionType;
        }

        /// <summary>
        /// Initialize the section from the section type and the section string passed to this function
        /// </summary>
        /// <param name="sectionType">The section type that will determine what type of section will be initialized</param>
        /// <param name="project">The project that will be passed to the initialized section</param>
        /// <param name="sectionName">The name of the section if required</param>
        /// <returns>Returns: An initialized section</returns>
        private static IInpSection InitializeSection(Type sectionType, InpProject project, string sectionName = "")
        {
            if (sectionType == typeof(InpOptionsSection))
                return new InpOptionsSection(project);

            if (sectionType == typeof(InpTableSection) || !string.IsNullOrEmpty(sectionName))
                return new InpTableSection(project, sectionName);

            return null;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Read the project from the reader and parse it into the
        /// given project parameters
        /// </summary>
        /// <param name="project">The project</param>
        public void ParseProject(InpProject project)
        {
            // Make sure that the project passed is not null
            if (project == null)
                throw new NullReferenceException("InpProject Cannot be Null");

            for (var line = ""; !_reader.EndOfStream && line != null; line = _reader.ReadLine())
            {
                // If the current line is a section name parse that section
                if (!line.StartsWith("[")) continue;

                // Get the section name
                var sectionName = line.Trim('[', ']');

                // Get the section type
                var sectionType = GetSectionType(sectionName);

                // If the section type is not known then continue
                if (sectionType == null) continue;

                // Initialize the section with the appropriate type
                var section = InitializeSection(sectionType, project, sectionName);

                // If the section is not null read the section
                section?.ReadSection(_reader);
            }
        }

        #endregion
    }
}
