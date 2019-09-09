using System;
using System.Collections.Generic;
using System.Text;
using Droplet.Core.Inp.Data;

namespace Droplet.Core.Inp.Entities
{
    /// <summary>
    /// A class that holds the Option Data for an inp option
    /// </summary>
    public class InpOption : InpEntity
    {
        /// <summary>
        /// The header name for the options section
        /// </summary>
        public const string HeaderName = "OPTIONS";

        /// <summary>
        /// The value of the option
        /// </summary>
        public object Value { get; }

        /// <summary>
        /// Default Constructor for the options type
        /// </summary>
        public InpOption() : base()
        {

        }

        /// <summary>
        /// Constructor from a table row and a database
        /// </summary>
        /// <param name="row">The row that this option will be constructed from</param>
        /// <param name="database">The database that this object will be constructed from</param>
        public InpOption(ITableRow row, IInpDatabase database) : base(row, database)
        {
            Value = row.Values[1];
        }
    }
}
