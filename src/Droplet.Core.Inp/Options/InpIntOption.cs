using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Entities;
using Droplet.Core.Inp.Exceptions;
using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// Base class for options that wish to have their values as an <see cref="int"/> type.
    /// </summary>
    public class InpIntOption : InpOption<int>
    {

        #region Constructors

        /// <summary>
        /// Constructor for the <see cref="InpIntOption"/> that forwards 
        /// the value to the base constructor (<see cref="InpOption{T}.InpOption(T)"/>)
        /// </summary>
        /// <param name="value">The value that will be passed to the base constructor</param>
        public InpIntOption(int value) : base(value)
        {
        }


        /// <summary>
        /// Internal Constructor that accepts a <see cref="IInpTableRow"/> and an <see cref="IInpDatabase"/> 
        /// the constructor will <see cref="ParseRow(IInpTableRow)"/> and set the <see cref="Value"/> using the row
        /// </summary>
        /// <param name="row"></param>
        /// <param name="database"></param>
        internal InpIntOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
            Value = ParseRow(row);
        }

        #endregion

        #region Internal Members

        /// <summary>
        /// Override of the <see cref="InpOption{T}.ParseRow(IInpTableRow)"/> method 
        /// that will convert the value from the row into an int.
        /// </summary>
        /// <param name="row">The row that will be parsed</param>
        /// <returns>Returns: an <see cref="int"/> that is parsed from the second element in the row</returns>
        protected internal override int ParseRow(IInpTableRow row)
        {
            _ = row ?? throw new ArgumentNullException(nameof(row));

            if (int.TryParse(row[1], out var value))
                return value;
            else
                throw InpParseException.CreateWithStandardMessage(typeof(InpIntOption));
        }

        #endregion

        /// <summary>
        /// Public override of the <see cref="IInpEntity.ToInpString"/> method
        /// </summary>
        /// <returns>Returns: the name and the value of this option</returns>
        public override string ToInpString() 
            => Name.PadRight(OptionStringPadding) + Value;
    }
}
