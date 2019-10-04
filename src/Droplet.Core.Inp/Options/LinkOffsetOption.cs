using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Exceptions;
using Droplet.Core.Inp.Entities;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The <see cref="LinkOffset"/> option
    /// </summary>
    public class LinkOffsetOption : InpOption<LinkOffset>
    {

        #region Constructors

        public LinkOffsetOption(LinkOffset linkOffset) : base(linkOffset) 
            => Name = OptionName;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="row">The row that this option will be built from</param>
        /// <param name="database">The database that this option belongs to</param>
        internal LinkOffsetOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
            // Set the value of the option
            Value = Value.FromInpString(row[1]);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Public override of the <see cref="IInpEntity.ToInpString"/> method.
        /// </summary>
        /// <returns>Returns: an inp string that contains the <see cref="Name"/> and <see cref="Value"/> of this option</returns>
        public override string ToInpString() 
            => Name.PadRight(OptionStringPadding) + Value.ToInpString();

        #endregion

        #region Internal Members

        /// <summary>
        /// The option name
        /// </summary>
        internal const string OptionName = "LINK_OFFSETS";

        #endregion

    }

    /// <summary>
    /// Options for the <see cref="LinkOffsetOption"/>
    /// </summary>
    public enum LinkOffset
    {
        /// <summary>
        /// Offset conduits based on elevation
        /// </summary>
        ElevationOffset,

        /// <summary>
        /// Offset conduits based on a relative depth
        /// </summary>
        DepthOffset
    }

    /// <summary>
    /// Extensions class for the <see cref="LinkOffset"/> enumeration
    /// </summary>
    public static class LinkOffsetExtensions
    {
        /// <summary>
        /// Convert from a <see cref="string"/> to a <see cref="LinkOffset"/> option
        /// </summary>
        /// <param name="linkOffset">The this for the extension method to work</param>
        /// <param name="inpString">The string that will be converted</param>
        /// <returns></returns>
        public static LinkOffset FromInpString(this LinkOffset linkOffset, string inpString) => inpString switch
        {
            "DEPTH" => LinkOffset.DepthOffset,
            "ELEVATION" => LinkOffset.ElevationOffset,

            _ => throw InpParseException.CreateWithStandardMessage(typeof(LinkOffsetOption))
        };

        /// <summary>
        /// Convert this <see cref="LinkOffset"/> to an inp string
        /// </summary>
        /// <param name="linkOffset">The link offset that will be converted</param>
        /// <returns>Returns: A string that is a valid inp string</returns>
        public static string ToInpString(this LinkOffset linkOffset) => linkOffset switch
        {
            LinkOffset.DepthOffset => "DEPTH",
            LinkOffset.ElevationOffset => "ELEVATION",
            _ => throw InpParseException.CreateWithStandardMessage(typeof(LinkOffsetOption))
        };
    }

}
