using System.Resources;

namespace Droplet.Core.Inp.Utilities
{
    /// <summary>
    /// Class that inherits from the <see cref="ResourceManager"/> class
    /// and implements some default methods
    /// </summary>
    public class InpResourceManager : ResourceManager
    {
        /// <summary>
        /// The resource Name
        /// </summary>
        private const string ResourceName = "Droplet.Core.Inp.Resources.Strings";

        /// <summary>
        /// Default Constructor that returns the default Strings Resource
        /// </summary>
        public InpResourceManager() : base(ResourceName, typeof(InpResourceManager).Assembly)
        {
        }
    }
}
