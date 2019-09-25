// InpProject.cs
// By: Adam Renaud
// Created: 2019-08-09

using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.IO;
using Droplet.Core.Inp.Utilities;
using System.IO;
using System.Resources;

namespace Droplet.Core.Inp
{
    /// <summary>
    /// Class that represents an inp project or the entire
    /// context of an inp file
    /// </summary>
    public class InpProject : IInpProject
    {
        #region Constructors

        /// <summary>
        /// Default Constructor that
        /// initializes all objects in the class to their
        /// default values. All other constructors will call this class
        /// </summary>
        public InpProject()
        {
            InpFile = "<NO FILE PROVIDED>";
            ProjectName = "<NO NAME PROVIDED>";
            Database = new InpDatabase();
        }

        /// <summary>
        /// Constructor that reads a file that is supplied from the path that is
        /// from the parameter: <paramref name="inpfile"/>
        /// </summary>
        /// <param name="inpfile">The supplied path to the file that will be used</param>
        public InpProject(string inpfile) : this()
        {
            // Validate that this file exits and set the full path
            // to the file
            InpFile = FileValitation(inpfile);

            // Set the project name to the filename without extension
            ProjectName = Path.GetFileNameWithoutExtension(InpFile);

            // Create a new file stream for the file and an new InpFileReader
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

        #region IInpProject Implementation

        /// <summary>
        /// The full path to the file
        /// </summary>
        public string InpFile { get; }

        /// <summary>
        /// The name of the inp project, this is the same
        /// as the file name of the inp file
        /// </summary>
        public string ProjectName { get; }

        /// <summary>
        /// The database that contains all of the projects
        /// entities
        /// </summary>
        public IInpDatabase Database { get; }

        #endregion
    }
}
