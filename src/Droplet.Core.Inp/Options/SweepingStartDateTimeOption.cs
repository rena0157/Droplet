// SweepingStartDateTimeOption.cs
// By: Adam Renaud
// Created: 2019-09-21

using Droplet.Core.Inp.Data;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The starting time for street sweeping
    /// </summary>
    public class SweepingStartDateTimeOption : InpDateTimeOption
    {
        /// <summary>
        /// Constructor that accepts an <see cref="IInpTableRow"/> 
        /// and an <see cref="IInpDatabase"/>
        /// </summary>
        /// <param name="row">The row that will be used to construct the
        ///  option</param>
        /// <param name="database">The database that the option will belong to</param>
        internal SweepingStartDateTimeOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
            // Construction will happen in the base class
        }

        /// <summary>
        /// The name of the date option in an inp file
        /// </summary>
        internal const string OptionName = "SWEEP_START";
    }
}
