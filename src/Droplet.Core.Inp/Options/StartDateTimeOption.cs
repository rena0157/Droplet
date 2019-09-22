using Droplet.Core.Inp.Data;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The Start Date Time Option. This option encompasses the
    /// start date and the start time of the simulation
    /// </summary>
    public class StartDateTimeOption : InpDateTimeOption
    {
        /// <summary>
        /// Constructor that builds this entity from an <see cref="IInpTableRow"/>
        /// and an <see cref="IInpDatabase"/>.
        /// </summary>
        /// <param name="row">The row that will be used to build the option</param>
        /// <param name="database">The database that the option belongs to</param>
        internal StartDateTimeOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        /// <summary>
        /// The option name that holds the date component 
        /// of the datetime
        /// </summary>
        internal const string StartDateName = "START_DATE";

        /// <summary>
        /// The option name that holds the time component
        /// of datetime
        /// </summary>
        internal const string StartTimeName = "START_TIME";



    }
}
