// InpDateTimeOption.cs
// By: Adam Renaud
// Created: 2019-09-18

using Droplet.Core.Inp.Data;
using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// An <see cref="InpOption{DateTime}"/> class that implements
    /// the basic functions for options that have <see cref="DateTime"/> as
    /// their type
    /// </summary>
    public class InpDateTimeOption : InpOption<DateTime>
    {
        /// <summary>
        /// Constructor that accepts a <see cref="IInpTableRow"/> and an <see cref="IInpDatabase"/>
        /// to build the object
        /// </summary>
        /// <param name="row">The row that will be used to construct the value</param>
        /// <param name="database">The database that the date time belongs to</param>
        public InpDateTimeOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
            // Convert the row into a DateTime and
            // store it in the value property
            Value = DateTime.Parse(row[1]);
        }

        /// <summary>
        /// Internal Method that is used to add a <see cref="TimeSpan"/>
        ///  to this objects value and return it
        /// </summary>
        /// <param name="timeSpan">The <see cref="TimeSpan"/> that will be added to the value</param>
        /// <returns>Returns: <see cref="this"/> to the caller</returns>
        internal virtual InpDateTimeOption AddTime(TimeSpan timeSpan)
        {
            // Set the value with the new timespan
            Value = new DateTime(Value.Year, Value.Month, Value.Day, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            return this;
        }
    }
}
