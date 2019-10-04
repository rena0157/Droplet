// SweepingEndDateTimeOption.cs
// By: Adam Renaud
// Created: 2019-09-22

using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Entities;
using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The end date for street sweeping option
    /// </summary>
    public class SweepingEndDateTimeOption : InpDateTimeOption
    {

        #region Constructors

        /// <summary>
        /// The default constructor for the <see cref="SweepingEndDateTimeOption"/> class
        /// </summary>
        /// <param name="value">Used to set the value of this option</param>
        public SweepingEndDateTimeOption(DateTime value) : base(value) => Name = OptionName;

        /// <summary>
        /// Constructor that accepts an <see cref="IInpTableRow"/> 
        /// and an <see cref="IInpDatabase"/>.
        /// </summary>
        /// <param name="row">The row that will be used to construct the option</param>
        /// <param name="database">The database that the option will belong to</param>
        internal SweepingEndDateTimeOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        #endregion

        #region Internal Members

        /// <summary>
        /// The option name for the <see cref="SweepingEndDateTimeOption"/> 
        /// in inp files
        /// </summary>
        internal const string OptionName = "SWEEP_END";

        #endregion

        /// <summary>
        /// Public override of the <see cref="IInpEntity.ToInpString"/> method
        /// </summary>
        /// <returns>Returns: the name and the value of the option formatted 
        /// as a valid inp string</returns>
        public override string ToInpString() 
            => Name.PadRight(OptionStringPadding) + $"{Value:MM'/'dd}";
    }
}
