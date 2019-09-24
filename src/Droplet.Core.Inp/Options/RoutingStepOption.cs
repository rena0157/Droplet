using Droplet.Core.Inp.Data;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The Routing Time Step Option
    /// </summary>
    public class RoutingStepOption : InpTimeSpanOption
    {
        /// <summary>
        /// Internal Constructor that accepts an <see cref="IInpTableRow"/> 
        /// and an <see cref="IInpDatabase"/>
        /// </summary>
        /// <param name="row">The row that will be used to construct the value</param>
        /// <param name="database">The database that the option will belong to</param>
        internal RoutingStepOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        /// <summary>
        /// The option name in inp files
        /// </summary>
        internal const string OptionName = "ROUTING_STEP";
    }
}
