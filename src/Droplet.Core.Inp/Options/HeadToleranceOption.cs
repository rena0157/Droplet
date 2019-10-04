using Droplet.Core.Inp.Data;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The head tolerance option
    /// </summary>
    public class HeadToleranceOption : InpDoubleOption
    {
        #region Constructors

        /// <summary>
        /// Default constructor for the <see cref="HeadToleranceOption"/> that accept 
        /// a <see cref="double"/> that will be used to set the value of this option.
        /// </summary>
        /// <param name="value">The value that this option's value will be set to</param>
        public HeadToleranceOption(double value) : base(value) => Name = OptionName;

        /// <summary>
        /// Internal constructor that accepts an <see cref="IInpTableRow"/> that will be parsed and 
        /// an <see cref="IInpDatabase"/> that the option will belong to.
        /// </summary>
        /// <param name="row">The row that will set the value of this option</param>
        /// <param name="database">The database that this option will belong to</param>
        internal HeadToleranceOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        #endregion

        #region Internal Members

        /// <summary>
        /// The inp Option Name for this option
        /// </summary>
        internal const string OptionName = "HEAD_TOLERANCE";

        #endregion
    }
}
