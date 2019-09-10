using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Options;

namespace Droplet.Core.Inp
{
    /// <summary>
    /// Interface for an InpProject
    /// </summary>
    public interface IInpProject
    {
        /// <summary>
        /// The name of the InpFile
        /// </summary>
        string InpFile { get; }

        /// <summary>
        /// The name of the InpProject
        /// </summary>
        string ProjectName { get; }

        /// <summary>
        /// The entities in this project
        /// </summary>
        IInpDatabase Database { get; }
    }
}
