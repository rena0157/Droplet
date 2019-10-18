using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Entities;
using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The Start Date Time Option. This option encompasses the
    /// start date and the start time of the simulation
    /// </summary>
    public class StartDateTimeOption : InpDateTimeOption
    {

        #region Constructors

        public StartDateTimeOption(DateTime value) : base(value)
        {
        }

        /// <summary>
        /// Constructor that builds this entity from an <see cref="IInpTableRow"/>
        /// and an <see cref="IInpDatabase"/>.
        /// </summary>
        /// <param name="row">The row that will be used to build the option</param>
        /// <param name="database">The database that the option belongs to</param>
        internal StartDateTimeOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        #endregion

        #region Internal Members

        /// <summary>
        /// The option name that holds the date component 
        /// of the <see cref="DateTime"/>
        /// </summary>
        internal const string StartDateName = "START_DATE";

        /// <summary>
        /// The option name that holds the time component
        /// of <see cref="DateTime"/>
        /// </summary>
        internal const string StartTimeName = "START_TIME";

        #endregion

        #region Public Methods

        /// <summary>
        /// Public override of the <see cref="IInpEntity.ToInpString"/> method
        /// </summary>
        /// <returns>Returns: The start date and start time names and their values 
        /// formatted as an inp string</returns>
        public override string ToInpString()
        {
            var dateString = StartDateName.PadRight(OptionStringPadding) + $"{Value:MM'/'dd'/'yyyy}";
            var timeString = StartTimeName.PadRight(OptionStringPadding) + $"{Value.TimeOfDay}";

            return dateString + Environment.NewLine + timeString;
        }

        #endregion

    }
}
