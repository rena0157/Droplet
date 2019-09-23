using Droplet.Core.Inp.Data;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The report step option
    /// </summary>
    public class ReportStepOption : InpTimeSpanOption
    {
        #region Internal Members

        /// <summary>
        /// Constructor that accepts an <see cref="IInpTableRow"/> 
        /// and an <see cref="IInpDatabase"/>.
        /// </summary>
        /// <param name="row">The row that will be used to construct the value</param>
        /// <param name="database">The database that the option will belong to</param>
        internal ReportStepOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        /// <summary>
        /// The name of the option in inp files
        /// </summary>
        internal const string OptionName = "REPORT_STEP";

        #endregion
    }
}
