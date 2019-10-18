// InpDateTimeOption.cs
// By: Adam Renaud
// Created: 2019-09-18

using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Exceptions;
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
        #region Constructors

        /// <summary>
        /// Default constructor for the <see cref="InpDateTimeOption"/> that 
        /// accepts a <see cref="DateTime"/> that the value will be set to.
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> that the value will be set to</param>
        public InpDateTimeOption(DateTime dateTime) : base(dateTime)
        {
        }

        /// <summary>
        /// Constructor that accepts a <see cref="IInpTableRow"/> and an <see cref="IInpDatabase"/>
        /// to build the object
        /// </summary>
        /// <param name="row">The row that will be used to construct the value</param>
        /// <param name="database">The database that the date time belongs to</param>
        internal InpDateTimeOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
            // Convert the row into a DateTime and
            // store it in the value property
            Value = ParseRow(row);
        }

        #endregion

        #region Internal Members

        /// <summary>
        /// Parse the <see cref="IInpTableRow"/> that is passed and return it.
        /// </summary>
        /// <param name="row">The row that will be parsed an returned</param>
        /// <exception cref="ArgumentNullException">
        /// Will Throw if <paramref name="row"/> is <see cref="null"/>
        /// </exception>
        /// <exception cref="InpParseException">
        /// Will Throw if <see cref="DateTime.TryParse(ReadOnlySpan{char}, out DateTime)"/> fails
        /// </exception>
        /// <returns>Returns: The <see cref="DateTime"/> that is parsed from the row</returns>
        protected internal override DateTime ParseRow(IInpTableRow row) 
            => row == null ? throw new ArgumentNullException(nameof(row)) :
            DateTime.TryParse(row[1], out var result) ? result : 
            throw InpParseException.CreateWithStandardMessage(typeof(InpDateTimeOption));

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

        #endregion
    }
}
