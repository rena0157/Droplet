// InpBoolOption.cs
// By: Adam Renaud
// Created: 2019-09-16


using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Exceptions;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// Option that has a <see cref="bool"/> as its option type
    /// </summary>
    public class InpBoolOption : InpOption<bool>
    {

        #region Constructors

        /// <summary>
        /// Build the option from an <see cref="IInpTableRow"/> and an <see cref="IInpDatabase"/>
        /// </summary>
        /// <param name="row">The row that the <see cref="InpOption{T}"/> will be built from</param>
        /// <param name="database">The database that the option belongs to</param>
        public InpBoolOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
            // Set the value from the helper method
            Value = FromInpString(row[1]);
        }

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
            _ => throw new InpParseException($"The string {inpString} does not" +
                $" match a prescribed pattern to convert to a {typeof(bool)}")
        };

        #endregion
    }
}
