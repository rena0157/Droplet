// DryDaysOption.cs
// By: Adam Renaud
// Created: 2019-09-22

using Droplet.Core.Inp.Data;
using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The number of dry days option
    /// </summary>
    public class DryDaysOption : InpTimeSpanOption
    {
        /// <summary>
        /// The internal constructor that will create the option from a <see cref="IInpTableRow"/> 
        /// and add this option to the <see cref="IInpDatabase"/>
        /// </summary>
        /// <param name="row">The row that will be used to create the option</param>
        /// <param name="database">The database that this option belongs to</param>
        internal DryDaysOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
            Value = ParseRow(row);
        }

        /// <summary>
        /// Override of the <see cref="InpTimeSpanOption.ParseRow(IInpTableRow)"/> option
        /// that parses the <see cref="IInpTableRow"/> into a <see cref="TimeSpan"/> using the
        /// <see cref="TimeSpan.FromDays(double)"/> method.
        /// </summary>
        /// <param name="row">The row that will be parsed</param>
        /// <returns></returns>
        internal protected override TimeSpan ParseRow(IInpTableRow row)
            // Return the value from days
            => TimeSpan.FromDays(double.Parse(row[1]));
    }
}
