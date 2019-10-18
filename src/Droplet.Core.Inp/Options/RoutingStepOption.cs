using Droplet.Core.Inp.Data;
using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The Routing Time Step Option
    /// </summary>
    public class RoutingStepOption : InpTimeSpanOption
    {

        #region Constructors

        /// <summary>
        /// The default constructor for the <see cref="RoutingStepOption"/>.
        /// </summary>
        /// <param name="value">The value that will be used to set the <see cref="Value"/> of 
        /// this class</param>
        public RoutingStepOption(TimeSpan value) : base(value) => Name = OptionName;


        /// <summary>
        /// Internal Constructor that accepts an <see cref="IInpTableRow"/> 
        /// and an <see cref="IInpDatabase"/>
        /// </summary>
        /// <param name="row">The row that will be used to construct the value</param>
        /// <param name="database">The database that the option will belong to</param>
        internal RoutingStepOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        #endregion

        #region Internal Members

        /// <summary>
        /// The option name in inp files
        /// </summary>
        internal const string OptionName = "ROUTING_STEP";

        #endregion
    }
}
