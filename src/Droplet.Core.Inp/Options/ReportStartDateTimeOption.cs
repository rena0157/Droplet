// ReportStartDateTimeOption.cs
// By: Adam Renaud
// Created: 2019-09-19

using Droplet.Core.Inp.Data;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The Report Start Date and Time
    /// </summary>
    public class ReportStartDateTimeOption : InpDateTimeOption
    {

        #region Constructors

        /// <summary>
        /// Constructor that takes in an <see cref="IInpTableRow"/> and an <see cref="IInpDatabase"/>.
        /// The value of the Option will be constructed from the <see cref="IInpTableRow"/> that is passed
        /// </summary>
        /// <param name="row">The row that will construct the value for this option</param>
        /// <param name="database">The database that this option belongs to</param>
        public ReportStartDateTimeOption(IInpTableRow row, IInpDatabase database) : base(row, database)
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

    }
}
