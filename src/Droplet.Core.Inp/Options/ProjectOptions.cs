using System.Collections.Generic;
using System.Linq;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// Class that contains the project options
    /// </summary>
    public class ProjectOptions
    {
        /// <summary>
        /// The backing <see cref="List{InpOption}"/> for holding all of the
        /// options in a project
        /// </summary>
        private List<InpOption> _options { get; }

        /// <summary>
        /// Initialize the project options
        /// </summary>
        public ProjectOptions()
        {
            _options = new List<InpOption>();
        }

        /// <summary>
        /// Get an option from the options database.
        /// </summary>
        /// <typeparam name="T">The type of the option that will be returned.
        /// Note that T can only be <see cref="InpOption"/>s</typeparam>
        /// <returns>Returns: the option from the database</returns>
        public T GetOption<T>() where T : InpOption
            => _options.FirstOrDefault(o => o is T) as T;
    }
}
