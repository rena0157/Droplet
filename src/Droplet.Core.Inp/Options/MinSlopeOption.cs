using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Exceptions;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The minimum slope option
    /// </summary>
    public class MinSlopeOption : InpDoubleOption
    {
        /// <summary>
        /// Default Constructor that initializes the option from a row
        /// and adds a referece to the database that it belongs to
        /// </summary>
        /// <param name="row">The row that will be used to construct this class</param>
        /// <param name="database">The database that this option belongs to</param>
        public MinSlopeOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        /// <summary>
        /// Returns the <see cref="OptionName"/> for  this option
        /// </summary>
        public override string Name => OptionName;

        /// <summary>
        /// The inp Option name
        /// </summary>
        public const string OptionName = "MIN_SLOPE";
    }
}
