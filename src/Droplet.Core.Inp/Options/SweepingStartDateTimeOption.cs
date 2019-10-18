// SweepingStartDateTimeOption.cs
// By: Adam Renaud
// Created: 2019-09-21

using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Entities;
using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The starting time for street sweeping
    /// </summary>
    public class SweepingStartDateTimeOption : InpDateTimeOption
    {
        #region Constructors

        /// <summary>
        /// Default constructor for the <see cref="SweepingStartDateTimeOption"/>
        /// </summary>
        /// <param name="value">Used to set the <see cref="Value"/> of this option</param>
        public SweepingStartDateTimeOption(DateTime value) : base(value) => Name = OptionName;

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

        #endregion

        #region Internal Members

        /// <summary>
        /// The name of the date option in an inp file
        /// </summary>
        internal const string OptionName = "SWEEP_START";

        #endregion

        #region Public Methods

        /// <summary>
        /// Public override of the <see cref="IInpEntity.ToInpString"/> method
        /// </summary>
        /// <returns>Returns: a formatted inp string that contains the name and value 
        /// for this option.</returns>
        public override string ToInpString()
            => Name.PadRight(OptionStringPadding) + $"{Value:MM'/'dd}";


        #endregion
    }
}
