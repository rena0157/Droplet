using Droplet.Core.Inp.Data;
using System;


namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The Control Rule Time Step Option
    /// </summary>
    public class ControlRuleStepOption : InpTimeSpanOption
    {
        #region Constructors

        /// <summary>
        /// Default constructor that accepts a <see cref="TimeSpan"/> for its value. 
        /// This constructor also sets the name for the option to the default value.
        /// </summary>
        /// <param name="timespan"></param>
        public ControlRuleStepOption(TimeSpan timespan) : base(timespan)
        {
            Name = OptionName;
        }

        /// <summary>
        /// Internal Constructor that builds the option from an <see cref="IInpTableRow"/> 
        /// and places the option into the <see cref="IInpDatabase"/>
        /// </summary>
        /// <param name="row">The row that will be used to build the option</param>
        /// <param name="database">The database that the option belongs to</param>
        internal ControlRuleStepOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        #endregion

        #region Internal Members

        /// <summary>
        /// The name of the option in inp files
        /// </summary>
        internal const string OptionName = "RULE_STEP";

        #endregion
    }
}
