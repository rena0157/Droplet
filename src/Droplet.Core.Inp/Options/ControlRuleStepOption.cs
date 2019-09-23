using Droplet.Core.Inp.Data;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The Control Rule Time Step Option
    /// </summary>
    public class ControlRuleStepOption : InpTimeSpanOption
    {
        #region Internal Members

        /// <summary>
        /// Internal Constructor that builds the option from an <see cref="IInpTableRow"/> 
        /// and places the option into the <see cref="IInpDatabase"/>
        /// </summary>
        /// <param name="row">The row that will be used to build the option</param>
        /// <param name="database">The database that the option belongs to</param>
        internal ControlRuleStepOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        /// <summary>
        /// The name of the option in inp files
        /// </summary>
        internal const string OptionName = "RULE_STEP";

        #endregion
    }
}
