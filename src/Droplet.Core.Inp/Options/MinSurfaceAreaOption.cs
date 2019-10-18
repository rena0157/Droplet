using Droplet.Core.Inp.Data;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The min surface area option
    /// </summary>
    public class MinSurfaceAreaOption : InpDoubleOption
    {
        #region Constructors

        /// <summary>
        /// The default constructor for the <see cref="MinSurfaceAreaOption"/> that accepts a 
        /// <see cref="double"/> that the value for this option will be set to. The name for this option 
        /// will be set to the default inp <see cref="string"/>.
        /// </summary>
        /// <param name="value"></param>
        public MinSurfaceAreaOption(double value) : base(value) => Name = OptionName;

        /// <summary>
        /// Internal Constructor that accepts an <see cref="IInpTableRow"/> and 
        /// an <see cref="IInpDatabase"/>
        /// </summary>
        /// <param name="row">The row that will be used to build the option</param>
        /// <param name="database">The database that the option belongs to</param>
        internal MinSurfaceAreaOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        #endregion

        #region Internal Members

        /// <summary>
        /// The name of the option in an inp file
        /// </summary>
        internal const string OptionName = "MIN_SURFAREA";

        #endregion
    }
}
