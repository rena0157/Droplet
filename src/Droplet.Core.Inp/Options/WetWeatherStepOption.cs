using Droplet.Core.Inp.Data;
using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The wet weather step option
    /// </summary>
    public class WetWeatherStepOption : InpTimeSpanOption
    {

        #region Constructors

        /// <summary>
        /// Default constructor for the <see cref="WetWeatherStepOption"/>
        /// </summary>
        /// <param name="value">Used to set the value for this option</param>
        public WetWeatherStepOption(TimeSpan value) : base(value) => Name = OptionName;

        /// <summary>
        /// Internal Constructor that accepts an <see cref="IInpTableRow"/> 
        /// and an <see cref="IInpDatabase"/>
        /// </summary>
        /// <param name="row">The row that will be used to construct the value</param>
        /// <param name="database">The database that the option belongs to</param>
        internal WetWeatherStepOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        #endregion

        #region Internal Members

        /// <summary>
        /// The Option Name in inp files
        /// </summary>
        internal const string OptionName = "WET_STEP";

        #endregion

    }
}
