using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Exceptions;
using System;

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
        internal InpDoubleOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
            Value = ParseRow(row);
        }

        /// <summary>
        /// Protected internal override of the <see cref="InpOption{T}.ParseRow(IInpTableRow)"/> Method
        ///  that parses a <see cref="double"/>
        /// </summary>
        /// <param name="row">The row that will be parsed</param>
        /// <returns>Returns: a <see cref="double"/> that is parsed from the row</returns>
        protected internal override double ParseRow(IInpTableRow row)
        {
            // Check for null
            _ = row ?? throw new ArgumentNullException(nameof(row));

            // Try to parse the row
            if (double.TryParse(row[1], out var value))
                // If it succeeds then assign the value of the parsing
                return value;
            // If it is not successful throw an new exception
            else
                throw new InpParseException($"The parsing of {this} was unsucessful due to a double" +
                    $" conversion issue");
        }
    }
}
