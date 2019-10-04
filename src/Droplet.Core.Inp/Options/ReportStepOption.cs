using Droplet.Core.Inp.Data;
using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The report step option
    /// </summary>
    public class ReportStepOption : InpTimeSpanOption
    {
        #region Constructors

        /// <summary>
        /// The default constructor for the <see cref="ReportStepOption"/> class 
        /// that sets the value to the parameter passed <paramref name="value"/>. The name is 
        /// set to the default inp string name.
        /// </summary>
        /// <param name="value"></param>
        public ReportStepOption(TimeSpan value) : base(value) => Name = OptionName;

        /// <summary>
        /// Constructor that accepts an <see cref="IInpTableRow"/> 
        /// and an <see cref="IInpDatabase"/>.
        /// </summary>
        /// <param name="row">The row that will be used to construct the value</param>
        /// <param name="database">The database that the option will belong to</param>
        internal ReportStepOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        #endregion

        #region Internal Members

        /// <summary>
        /// The name of the option in inp files
        /// </summary>
        internal const string OptionName = "REPORT_STEP";

        #endregion
    }
}
