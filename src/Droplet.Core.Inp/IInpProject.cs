using Droplet.Core.Inp.Data;

namespace Droplet.Core.Inp
{
    /// <summary>
    /// Interface for an InpProject
    /// </summary>
    public interface IInpProject
    {
        /// <summary>
        /// The full path to the inp that this project
        /// is reading
        /// </summary>
        string InpFile { get; }

        /// <summary>
        /// The name of the InpProject, which is the same as the filename
        /// </summary>
        string ProjectName { get; }

        /// <summary>
        /// The context database for the inp file
        /// </summary>
        IInpDatabase Database { get; }
    }
}
