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
        /// Constructor that requires a row from an inp file,
        /// and the database that the option will belong to
        /// </summary>
        /// <param name="row">The row that contains the data for the option</param>
        /// <param name="database">The database that the option belongs to</param>
        public SkipSteadyStateOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Public override of the Name Property that will
        /// return the <see cref="OptionName"/> of this class
        /// </summary>
        public override string Name => OptionName;

        /// <summary>
        /// The name of the option in inp files
        /// </summary>
        public const string OptionName = "SKIP_STEADY_STATE";

        #endregion
    }
}
