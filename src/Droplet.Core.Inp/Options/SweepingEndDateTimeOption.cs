﻿// SweepingEndDateTimeOption.cs
// By: Adam Renaud
// Created: 2019-09-22

using Droplet.Core.Inp.Data;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The end date for steet sweeping option
    /// </summary>
    public class SweepingEndDateTimeOption : InpDateTimeOption
    {
        /// <summary>
        /// Constructor that accepts an <see cref="IInpTableRow"/> 
        /// and an <see cref="IInpDatabase"/>.
        /// </summary>
        /// <param name="row">The row that will be used to construct the option</param>
        /// <param name="database">The database that the option will belong to</param>
        public SweepingEndDateTimeOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        /// <summary>
        /// The option name for the <see cref="SweepingEndDateTimeOption"/> 
        /// in inp files
        /// </summary>
        internal const string OptionName = "SWEEP_END";
    }
}
