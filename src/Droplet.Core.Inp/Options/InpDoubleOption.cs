using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Exceptions;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// Implementation for <see cref="InpOption{double}"/> that holds
    /// common code for this class
    /// </summary>
    public class InpDoubleOption : InpOption<double>
    {
        /// <summary>
        /// Constructor that sets the value from the <paramref name="row"/> data
        /// and sets the database that the option belongs to
        /// </summary>
        /// <param name="row"></param>
        /// <param name="database"></param>
        public InpDoubleOption(IInpTableRow row, IInpDatabase database) : base(row, database)
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
    }
}
