// ReportStartDateTimeOption.cs
// By: Adam Renaud
// Created: 2019-09-19

using Droplet.Core.Inp.Data;
using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The Report Start Date and Time
    /// </summary>
    public class ReportStartDateTimeOption : InpDateTimeOption
    {

        #region Constructors

        /// <summary>
        /// Default constructor for the <see cref="ReportStartDateTimeOption"/> that sets the value of 
        /// the option to the <see cref="DateTime"/> passed.
        /// </summary>
        /// <param name="value">The value that the option will be set to.</param>
        public ReportStartDateTimeOption(DateTime value) : base(value)
        {
        }

        /// <summary>
        /// Constructor that takes in an <see cref="IInpTableRow"/> and an <see cref="IInpDatabase"/>.
        /// The value of the Option will be constructed from the <see cref="IInpTableRow"/> that is passed
        /// </summary>
        /// <param name="row">The row that will construct the value for this option</param>
        /// <param name="database">The database that this option belongs to</param>
        internal ReportStartDateTimeOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        #endregion

        #region Internal Constants

        /// <summary>
        /// The date name of the option
        /// </summary>
        internal const string DateOptionName = "REPORT_START_DATE";

        /// <summary>
        /// The time name of the option
        /// </summary>
        internal const string TimeOptionName = "REPORT_START_TIME";

        #endregion

        #region Public Methods

        /// <summary>
        /// Public override of the <see cref="IInpEntity.ToInpString"/> Method 
        /// that will return both the date and the time option names and associated values
        /// </summary>
        /// <returns>Returns: The Report Date Option name and value followed by the Report Time Option name and value</returns>
        public override string ToInpString()
        {
            var dateString = DateOptionName.PadRight(OptionStringPadding) + $"{Value:MM'/'dd'/'yyyy}";
            var timeString = TimeOptionName.PadRight(OptionStringPadding) + $"{Value.TimeOfDay}";

            return dateString + Environment.NewLine + timeString;
        }

        #endregion

    }
}
