// SkipSteadyStateOption.cs
// By: Adam Renaud
// Created: 2019-09-18

using Droplet.Core.Inp.Data;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The Skip Steady State Option
    /// </summary>
    public class SkipSteadyStateOption : InpBoolOption
    {

        #region Constructors

        /// <summary>
        /// The default constructor for the <see cref="SkipSteadyStateOption"/>
        /// </summary>
        /// <param name="value">Used to set the value of this option</param>
        public SkipSteadyStateOption(bool value) : base(value) => Name = OptionName;

        /// <summary>
        /// Constructor that requires a row from an inp file,
        /// and the database that the option will belong to
        /// </summary>
        /// <param name="row">The row that contains the data for the option</param>
        /// <param name="database">The database that the option belongs to</param>
        internal SkipSteadyStateOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        #endregion

        #region Internal Members

        /// <summary>
        /// The name of the option in inp files
        /// </summary>
        public const string OptionName = "SKIP_STEADY_STATE";

        #endregion
    }
}
