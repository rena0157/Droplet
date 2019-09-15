using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Entities;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// A class that holds the Option Data for an inp option
    /// </summary>
    public class InpOption<T> : InpOption
    {
        /// <summary>
        /// Constructor that passes the arguments to the base class
        /// </summary>
        /// <param name="row">the row that will be used to construct the option</param>
        /// <param name="database">the database that this option belongs to</param>
        public InpOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        /// <summary>
        /// The value of the option
        /// </summary>
        public virtual T Value { get; set; }
    }

    /// <summary>
    /// Base class for the generic <see cref="InpOption{T}"/> class
    /// </summary>
    public class InpOption : InpEntity
    {
        /// <summary>
        /// The header name for the options section
        /// </summary>
        public const string HeaderName = "OPTIONS";

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
        public InpOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
            Database = database;
        }
    }
}
