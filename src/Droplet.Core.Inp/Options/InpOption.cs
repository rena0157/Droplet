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

        /// <summary>
        /// Create an <see cref="InpOption"/> from the <paramref name="optionName"/>, a <see cref="IInpTableRow"/>,
        /// and a <see cref="IInpDatabase"/> reference.
        /// </summary>
        /// <param name="optionName">The name of the option that will be created</param>
        /// <param name="database">The <see cref="IInpDatabase"/> that the option will belong to</param>
        /// <param name="row">The <see cref="IInpTableRow"/> that will be used to build the <see cref="InpOption"/></param>
        /// <returns>Returns: an option that is refered to by the <paramref name="optionName"/> that is passed</returns>
        internal static InpOption CreateFromOptionName(string optionName, IInpTableRow row, IInpDatabase database) => optionName switch
        {
            FlowUnitsOption.OptionName => new FlowUnitsOption(row, database),
            InfiltrationOption.OptionName => new InfiltrationOption(row, database),
            FlowRoutingOption.OptionName => new FlowRoutingOption(row, database),
            LinkOffsetOption.OptionName => new LinkOffsetOption(row, database),
            MinSlopeOption.OptionName => new MinSlopeOption(row, database),
            AllowPondingOption.OptionName => new AllowPondingOption(row, database),
            SkipSteadyStateOption.OptionName => new SkipSteadyStateOption(row, database),

            // TODO: Add exception here "Option Not Recognized"
            _ => new InpOption()
        };
    }
}
