// EndDateTimeOption.cs
// By: Adam Renaud
// Created: 2019-09-21

using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Entities;
using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// Option for the Ending Date Time for the simulation
    /// </summary>
    public class EndDateTimeOption : InpDateTimeOption
    {

        #region Constructors

        public EndDateTimeOption(DateTime dateTime) : base(dateTime)
        {
        }

        /// <summary>
        /// Constructor the class that accepts an <see cref="IInpTableRow"/>
        /// and a <see cref="IInpDatabase"/>.
        /// </summary>
        /// <param name="row">The row that the option will be created from</param>
        /// <param name="database">The database that the option will belong to</param>
        internal EndDateTimeOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
            // Everything is constructed in the base class
        }

        #endregion

        #region Internal Members

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

        #endregion

        #region Public Methods

        /// <summary>
        /// Public override of the <see cref="IInpEntity.ToInpString"/> Method 
        /// that will return both the date and the time option names and associated values
        /// </summary>
        /// <returns>Returns: The End Date Option name and value followed by the End Time Option name and value</returns>
        public override string ToInpString()
        {
            var dateString = DateOptionName.PadRight(OptionStringPadding) + $"{Value:dd'/'MM'/'yyyy}";
            var timeString = TimeOptionName.PadRight(OptionStringPadding) + $"{Value.TimeOfDay}";

            return dateString + Environment.NewLine + timeString;
        }

        #endregion

    }
}
