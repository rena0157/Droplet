using Droplet.Core.Inp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Droplet.Core.Services
{
    /// <summary>
    /// Inp Project Services
    /// </summary>
    public class InpProjectsService
    {
        /// <summary>
        /// Private backing field for all open projects
        /// </summary>
        private Dictionary<string, IInpProject> _projects;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public InpProjectsService()
        {
            _projects = new Dictionary<string, IInpProject>();
        }

        /// <summary>
        /// Opens a project and places it into the project dictionary
        /// </summary>
        /// <param name="pathToFile">Path to the project</param>
        /// <returns>Returns: The added project</returns>
        public IInpProject OpenProject(string pathToFile)
        {
            IInpProject project = null;
            try
            {
                project = new InpProject(pathToFile);

                if (_projects.ContainsKey(project.ProjectName))
                    _projects[project.ProjectName] = project;
                else
                    _projects.Add(project.ProjectName, project);
            }
            catch
            {
            }

            if (project is { })
                return project;
            else
                throw new Exception();
        }

        /// <summary>
        /// Close a project and remove it from the project dictionary
        /// </summary>
        /// <param name="projectName">The project name that will be closed</param>
        public void CloseProject(string projectName)
        {
            if (_projects.ContainsKey(projectName))
                _projects.Remove(projectName);
        }

        /// <summary>
        /// Close a project and remove it from the project dictionary 
        /// </summary>
        /// <param name="project">The project that will be removed</param>
        public void CloseProject(IInpProject project)
        {
            if (_projects.ContainsKey(project.ProjectName))
                _projects.Remove(project.ProjectName);
        }

        /// <summary>
        /// Checks to see if a project is contained in the project dictionary
        /// </summary>
        /// <param name="projectName">The project's name</param>
        /// <returns>Returns: true if the project is contained in the dictionary</returns>
        public bool ContainsProject(string projectName) 
            => _projects.ContainsKey(projectName);

        /// <summary>
        /// Get a project from the project dictionary
        /// </summary>
        /// <param name="projectName">The project name</param>
        /// <returns>Returns: The project from the dictionary</returns>
        public IInpProject this[string projectName]
        {
            get => _projects[projectName];
        }

        /// <summary>
        /// Get the projects from the project dictionary
        /// </summary>
        public IEnumerable<IInpProject> Projects 
            => _projects.Values;
    }
}
