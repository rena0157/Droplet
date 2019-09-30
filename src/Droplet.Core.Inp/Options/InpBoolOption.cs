// InpBoolOption.cs
// By: Adam Renaud
// Created: 2019-09-16


using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Exceptions;
using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// Option that has a <see cref="bool"/> as its option type
    /// </summary>
    public class InpBoolOption : InpOption<bool>
    {

        #region Constructors

        /// <summary>
        /// Public Default Constructor that accepts a value for the option
        /// </summary>
        /// <param name="value">The value of the option</param>
        public InpBoolOption(bool value) : base(value)
        {
        }

        /// <summary>
        /// Build the option from an <see cref="IInpTableRow"/> and an <see cref="IInpDatabase"/>
        /// </summary>
        /// <param name="row">The row that the <see cref="InpOption{T}"/> will be built from</param>
        /// <param name="database">The database that the option belongs to</param>
        internal InpBoolOption(IInpTableRow row, IInpDatabase database) : base(row, database) => Value = ParseRow(row);

        #endregion

        #region Internal Members

        /// <summary>
        /// Protected internal override the <see cref="InpOption{T}.ParseRow(IInpTableRow)"/> method 
        /// that will convert this <see cref="IInpTableRow"/> to a <see cref="bool"/>
        /// </summary>
        /// <param name="row">The row that will be converted</param>
        /// <returns>Returns: a <see cref="bool"/> that is created from the row</returns>
        protected internal override bool ParseRow(IInpTableRow row) 
            => row == null ? throw new ArgumentNullException(nameof(row)) : FromInpString(row[1]);

        /// <summary>
        /// Public Override of the ToInpString Method that will concatenate the name of 
        /// the option and the value of the <see cref="bool"/> value
        /// </summary>
        /// <returns>Returns: The <see cref="InpBoolOption"/> as a <see cref="string"/></returns>
        public override string ToInpString() 
            => Name.PadRight(OptionStringPadding) + BoolToInpString(Value);

        #endregion

        #region Public Static Helpers

        /// <summary>
        /// Converts a <see cref="string"/> to a <see cref="bool"/>
        /// for inp files that use the convention that "YES" = true and
        /// that "NO" = false
        /// </summary>
        /// <param name="inpString">The <see cref="string"/> that will be converted to a <see cref="bool"/></param>
        /// <returns>Returns: a <see cref="bool"/> that is converted from <paramref name="inpString"/></returns>
        public static bool FromInpString(string inpString) => inpString switch
        {
            // Patterns that the string could match
            "YES" => true,
            "NO" => false,

            // If the string does not match the patterns above
            // throw a parse exception
            _ => throw InpParseException.CreateWithStandardMessage(typeof(InpBoolOption))
        };

        /// <summary>
        /// Converts a <see cref="bool"/> to an inp <see cref="string"/>
        /// </summary>
        /// <returns>Returns: A <see cref="string"/> that is formatted to a YES or a NO</returns>
        public static string BoolToInpString(bool option) => option switch
        {
            true => "YES",
            false => "NO",
        };

        #endregion
    }
}
