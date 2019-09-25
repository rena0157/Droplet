using System;
using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Exceptions;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The conduit lengthening step option.
    /// </summary>
    public class ConduitLengtheningStepOption : InpTimeSpanOption
    {
        /// <summary>
        /// Internal Constructor for building the <see cref="ConduitLengtheningStepOption"/> from 
        /// and <see cref="IInpTableRow"/> and add it to the <see cref="IInpDatabase"/> supplied.
        /// </summary>
        /// <param name="row">The row that will be used to build the option</param>
        /// <param name="database">The database that the option belongs to</param>
        internal ConduitLengtheningStepOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        /// <summary>
        /// The option name that is used in inp files
        /// </summary>
        internal const string OptionName = "LENGTHENING_STEP";

        /// <summary>
        /// Internal Override of the <see cref="InpOption{T}.ParseRow(IInpTableRow)"/> method
        /// </summary>
        /// <param name="row">The row that will be parsed</param>
        /// <returns>Returns: the rows value to a <see cref="TimeSpan"/> to seconds</returns>
        protected internal override TimeSpan ParseRow(IInpTableRow row)
        {
            _ = row ?? throw new ArgumentNullException(nameof(row));

            // If able to parse the row return the from seconds method
            if (double.TryParse(row[1], out var result))
                return TimeSpan.FromSeconds(result);
            // Else throw an exception
            else
                throw new InpParseException($"Unable to parse {typeof(ConduitLengtheningStepOption)}");
        }
    }
}
