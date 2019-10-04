using Droplet.Core.Inp.Data;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The variable time step option
    /// </summary>
    public class VariableStepOption : InpDoubleOption
    {
        /// <summary>
        /// Default constructor that sets the value of the option
        /// </summary>
        /// <param name="value">The value that will be set</param>
        public VariableStepOption(double value) : base(value) => Name = OptionName;

        /// <summary>
        /// The internal constructor that accepts an <see cref="IInpTableRow"/> and 
        /// and <see cref="IInpDatabase"/>.
        /// </summary>
        /// <param name="row">The row that will be parsed</param>
        /// <param name="database">The database that the option belongs to</param>
        internal VariableStepOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        /// <summary>
        /// The inp option name
        /// </summary>
        internal const string OptionName = "VARIABLE_STEP";
    }
}
