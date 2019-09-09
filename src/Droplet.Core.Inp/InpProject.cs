// InpProject.cs
// By: Adam Renaud
// Created: 2019-08-09

using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Entities;
using Droplet.Core.Inp.IO;
using Droplet.Core.Inp.Options;
using System;
using System.Collections.Generic;
using System.IO;

namespace Droplet.Core.Inp
{
    /// <summary>
    /// The main Project class for an Inp Project
    /// </summary>
    public class InpProject : IInpProject
    {
        #region Constructors

        /// <summary>
        /// Default Constructor that
        /// initializes all objects in the class to their
        /// default values. All other constructors will class this class
        /// </summary>
        public InpProject()
        {
            InpFile = "<NO FILE PROVIDED>";
            ProjectName = "<NO NAME PROVIDED>";
        }

        /// <summary>
        /// Constructor that reads a file that is supplied from the
        /// <paramref name="inpfile"/> path
        /// </summary>
        /// <param name="inpfile">The supplied path to the file</param>
        public InpProject(string inpfile) : this()
        {
            // Validate that this file exits and set the full path
            // to the file
            InpFile = FileValitation(inpfile);

            // Set the project name to the filename without extension
            ProjectName = Path.GetFileNameWithoutExtension(InpFile);

            // Create a new filestream for the file and an new InpFileReader
            using var fs = new FileStream(InpFile, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var reader = new InpFileReader(fs);

            // Create a new parser and parse the file supplied
            new InpParser().ParseFile(this, reader);
        }

        #endregion

        #region Constructor Helpers

        /// <summary>
        /// Checks to see if the file exists, has the right extension and returns
        /// the full path to the file
        /// </summary>
        /// <param name="inpFile">The inpfile path</param>
        /// <returns>Returns: The full path to the file</returns>
        private string FileValitation(string inpFile)
        {
            // Check to see if the file exists
            if (!File.Exists(inpFile))
                throw new FileNotFoundException($"The supplied File {inpFile} could not be found.");

            // Check to make sure that the file extension matches
            if (Path.GetExtension(inpFile) != ".inp")
                throw new FileNotFoundException($"The extension {Path.GetExtension(inpFile)} does not match" +
                    $" the prescribed extension *.inp");

            // Return the full path to the file
            return Path.GetFullPath(inpFile);
        }

        #endregion

        #region Options

        public FlowUnits FlowUnits;

        #endregion  

        #region IInpProject Implementation

        /// <summary>
        /// The full path to the file
        /// </summary>
        public string InpFile { get; }

        /// <summary>
        /// The name of the inp project
        /// </summary>
        public string ProjectName { get; }

        public IInpDatabase Database => throw new NotImplementedException();

        public ProjectOptions Options => throw new NotImplementedException();

        #endregion
    }
}
