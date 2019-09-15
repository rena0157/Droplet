using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Exceptions;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The minimum slope option
    /// </summary>
    public class MinSlopeOption : InpOption<double>
    {
        /// <summary>
        /// Default Constructor that initializes the option from a row
        /// and adds a referece to the database that it belongs to
        /// </summary>
        /// <param name="row">The row that will be used to construct this class</param>
        /// <param name="database">The database that this option belongs to</param>
        public MinSlopeOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
            // Try to parse the row
            if (double.TryParse(row[1], out var slope))
                // If it suceeds then assign the value of the parsing
                Value = slope;
            // If it is not sucessful throw an new exception
            else
                throw new InpParseException($"The parsing of {this} was unsucessful due to a double" +
                    $" conversion issue");
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
