﻿// InpTimeSpanOption.cs
// By: Adam Renaud
// Created: 2019-09-22

using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Exceptions;
using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// Base class for all <see cref="InpOption{TimeSpan}"/> types that use 
    /// <see cref="TimeSpan"/> as their <see cref="InpOption{T}.Value"/> type
    /// </summary>
    public class InpTimeSpanOption : InpOption<TimeSpan>
    {

        #region Constructors

        /// <summary>
        /// Default Constructor that accepts a <see cref="TimeSpan"/> value
        /// </summary>
        /// <param name="value">The value that will be set</param>
        public InpTimeSpanOption(TimeSpan value) : base(value)
        {
        }

        /// <summary>
        /// Default Constructor that accepts a row and 
        /// parses it into a <see cref="TimeSpan"/> which is then stored in the 
        /// <see cref="InpOption{TimeSpan}.Value"/> property
        /// </summary>
        /// <param name="row">The row that will be used to create the value</param>
        /// <param name="database">The database that the option belongs to</param>
        internal InpTimeSpanOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
            Value = ParseRow(row);
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Parse the <see cref="IInpTableRow"/> to the <see cref="Value"/> 
        /// for the <see cref="TimeSpan"/> type
        /// </summary>
        /// <param name="row">The row that will be parsed</param>
        /// <returns>Returns: The parsed value</returns>
        internal protected override TimeSpan ParseRow(IInpTableRow row)
        {
            // Check for null
            _ = row ?? throw new ArgumentNullException(nameof(row));

            // Try and parse the row as a time span
            if (TimeSpan.TryParse(row[1], out var value))
                return value;
            // If it fails then throw an exception
            else
                throw InpParseException.CreateWithStandardMessage(typeof(InpTimeSpanOption));
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Public override for the <see cref="InpTimeSpanOption"/> class 
        /// that returns the <see cref="Name"/> and the <see cref="Value"/> formatted as an inp <see cref="string"/>
        /// </summary>
        /// <returns>Returns: A formatted Inp <see cref="string"/></returns>
        public override string ToInpString()
            => Name.PadRight(OptionStringPadding) + Value.ToString();

        #endregion
    }
}
