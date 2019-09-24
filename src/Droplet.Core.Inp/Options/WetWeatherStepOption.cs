using Droplet.Core.Inp.Data;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The wet weather step option
    /// </summary>
    public class WetWeatherStepOption : InpTimeSpanOption
    {
        /// <summary>
        /// Internal Constructor that accepts an <see cref="IInpTableRow"/> 
        /// and an <see cref="IInpDatabase"/>
        /// </summary>
        /// <param name="row">The row that will be used to construct the value</param>
        /// <param name="database">The database that the option belongs to</param>
        internal WetWeatherStepOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        /// <summary>
        /// The Option Name in inp files
        /// </summary>
        internal const string OptionName = "WET_STEP";
    }
}
