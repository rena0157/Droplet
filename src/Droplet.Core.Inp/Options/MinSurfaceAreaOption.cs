using Droplet.Core.Inp.Data;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The min surface area option
    /// </summary>
    public class MinSurfaceAreaOption : InpDoubleOption
    {
        /// <summary>
        /// Internal Constructor that accepts an <see cref="IInpTableRow"/> and 
        /// an <see cref="IInpDatabase"/>
        /// </summary>
        /// <param name="row">The row that will be used to build the option</param>
        /// <param name="database">The database that the option belongs to</param>
        internal MinSurfaceAreaOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        /// <summary>
        /// The name of the option in an inp file
        /// </summary>
        internal const string OptionName = "MIN_SURFAREA";
    }
}
