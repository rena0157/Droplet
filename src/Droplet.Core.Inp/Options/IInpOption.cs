using System;
using System.Collections.Generic;
using System.Text;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// Interface for options in the inp file
    /// </summary>
    public interface IInpOption
    {
        /// <summary>
        /// The name of the option
        /// </summary>
        string OptionName { get; protected set; }

        /// <summary>
        /// The value of the option
        /// </summary>
        object Value { get; protected set; }
    }
}
