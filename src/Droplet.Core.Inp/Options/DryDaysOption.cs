// DryDaysOption.cs
// By: Adam Renaud
// Created: 2019-09-22

using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Exceptions;
using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The number of dry days option
    /// </summary>
    public class DryDaysOption : InpTimeSpanOption
    {
        #region Internal Members

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
        /// Constant <see cref="string"/> that is the name of the option in inp files
        /// </summary>
        internal const string OptionName = "DRY_DAYS";

        /// <summary>
        /// Override of the <see cref="InpTimeSpanOption.ParseRow(IInpTableRow)"/> option
        /// that parses the <see cref="IInpTableRow"/> into a <see cref="TimeSpan"/> using the
        /// <see cref="TimeSpan.FromDays(double)"/> method.
        /// </summary>
        /// <param name="row">The row that will be parsed</param>
        /// <returns></returns>
        internal protected override TimeSpan ParseRow(IInpTableRow row)
        {
            // Check for null
            _ = row ?? throw new ArgumentNullException(nameof(row));

            // If not null try and parse the row, if the parse is successful return it 
            // from days. If not throw a new InpParseException
            return TimeSpan.FromDays(double.TryParse(row[1], out var result) ? result 
                : throw new InpParseException(typeof(DryDaysOption).Name));
        }

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Public Override of the ToInpString Method that will return the <see cref="Name"/> and the 
        /// <see cref="Value"/> for this <see cref="string"/>. The value that is returned is the number of days.
        /// </summary>
        /// <returns>Returns: the <see cref="Name"/> and number of days from the <see cref="TimeSpan.Days"/></returns>
        public override string ToInpString()
            => Name.PadRight(OptionStringPadding) + Value.Days;

        #endregion
    }
}
