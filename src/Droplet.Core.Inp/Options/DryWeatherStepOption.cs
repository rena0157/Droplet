using Droplet.Core.Inp.Data;
using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The Dry Weather Step Option
    /// </summary>
    public class DryWeatherStepOption : InpTimeSpanOption
    {
        #region Constructors

        /// <summary>
        /// Default constructor for the <see cref="DryWeatherStepOption"/> that accepts a 
        /// <see cref="TimeSpan"/> that will set the value of this option. The constructor 
        /// will also set the Name for this option to the inp default value.
        /// </summary>
        /// <param name="timespan"></param>
        public DryWeatherStepOption(TimeSpan timespan) : base(timespan)
        {
            Name = OptionName;
        }

        /// <summary>
        /// Constructor that accepts an <see cref="IInpTableRow"/>
        ///  and an <see cref="IInpDatabase"/>
        /// </summary>
        /// <param name="row">The row that will be used to construct the value</param>
        /// <param name="database">The database that the option belongs to</param>
        internal DryWeatherStepOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        #endregion

        /// <summary>
        /// The name of the option in inp files
        /// </summary>
        internal const string OptionName = "DRY_STEP";
    }
}
