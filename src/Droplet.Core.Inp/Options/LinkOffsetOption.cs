using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Utilities;
using System;
using System.Globalization;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The <see cref="LinkOffset"/> option
    /// </summary>
    public class LinkOffsetOption : InpOption<LinkOffset>
    {
        /// <summary>
        /// The option name
        /// </summary>
        internal const string OptionName = "LINK_OFFSETS";

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

            _ => throw new ArgumentException(new InpResourceManager()
                .GetString("FromInpString.ArgumentException", CultureInfo.CurrentCulture) + nameof(LinkOffset))
        };

        /// <summary>
        /// Convert this <see cref="LinkOffset"/> to an inp string
        /// </summary>
        /// <param name="linkOffset">The link offset that will be converted</param>
        /// <returns>Returns: A string that is a valid inp string</returns>
        public static string ToInpString(this LinkOffset linkOffset)
        {
            throw new NotImplementedException();
        }
    }

}
