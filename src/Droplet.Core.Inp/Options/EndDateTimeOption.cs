// EndDateTimeOption.cs
// By: Adam Renaud
// Created: 2019-09-21

using Droplet.Core.Inp.Data;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// Option for the Ending Date Time for the simulation
    /// </summary>
    public class EndDateTimeOption : InpDateTimeOption
    {
        /// <summary>
        /// Constructor the the class that accepts an <see cref="IInpTableRow"/>
        /// and a <see cref="IInpDatabase"/>.
        /// </summary>
        /// <param name="row">The row that the option will be created from</param>
        /// <param name="database">The database that the option will belong to</param>
        internal EndDateTimeOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
            // Everything is constructed in the base class
        }

        /// <summary>
        /// The name of the inp option that holds the date 
        /// information for this class
        /// </summary>
        internal const string DateOptionName = "END_DATE";

        /// <summary>
        /// The name of the inp option that holds the time information 
        /// for this class
        /// </summary>
        internal const string TimeOptionName = "END_TIME";


    }
}
