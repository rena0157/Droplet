using Droplet.Core.Inp.Data;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The minimum slope option
    /// </summary>
    public class MinSlopeOption : InpDoubleOption
    {

        #region Constructors

        /// <summary>
        /// Default Constructor that initializes the option from a row
        /// and adds a reference to the database that it belongs to
        /// </summary>
        /// <param name="row">The row that will be used to construct this class</param>
        /// <param name="database">The database that this option belongs to</param>
        internal MinSlopeOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        #endregion

        #region Internal Members

        /// <summary>
        /// The inp Option name
        /// </summary>
        internal const string OptionName = "MIN_SLOPE";

        #endregion
    }
}
