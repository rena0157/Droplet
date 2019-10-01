using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Exceptions;
using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The conduit lengthening step option.
    /// </summary>
    public class ConduitLengtheningStepOption : InpTimeSpanOption
    {

        #region Constructors

        /// <summary>
        /// Creates a new <see cref="ConduitLengtheningStepOption"/> using 
        /// an <see cref="int"/> that represents the number of seconds passed for the step
        /// <param name="timeInSeconds">The time in seconds for the <see cref="ConduitLengtheningStepOption"/></param>
        /// </summary>
        public ConduitLengtheningStepOption(int timeInSeconds) : base(TimeSpan.FromSeconds(timeInSeconds))
        {
            Name = OptionName;
        }

        /// <summary>
        /// Internal Constructor for building the <see cref="ConduitLengtheningStepOption"/> from 
        /// and <see cref="IInpTableRow"/> and add it to the <see cref="IInpDatabase"/> supplied.
        /// </summary>
        /// <param name="row">The row that will be used to build the option</param>
        /// <param name="database">The database that the option belongs to</param>
        internal ConduitLengtheningStepOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        #endregion

        #region Internal Members

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

        #endregion

        #region Public Methods

        /// <summary>
        /// Public Override of the ToInpString Method for the <see cref="ConduitLengtheningStepOption"/> class
        /// </summary>
        /// <returns>Returns: The name of the option followed by the <see cref="TimeSpan.Seconds"/> from the <see cref="Value"/></returns>
        public override string ToInpString()
            => Name.PadRight(OptionStringPadding) + Value.Seconds;

        #endregion
    }
}
