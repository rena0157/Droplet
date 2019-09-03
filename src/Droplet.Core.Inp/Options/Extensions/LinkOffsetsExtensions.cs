// LinkOffsetsExtensions.cs
// By: Adam Renaud
// Created: 2019-08-10

using System;

namespace Droplet.Core.Inp.Options.Extensions
{
    /// <summary>
    /// Extensions Class for LinkOffsets
    /// </summary>
    public static class LinkOffsetsExtensions
    {
        private const string Depth = "DEPTH";
        private const string Elevation = "ELEVATION";

        /// <summary>
        /// Parse an Inp string to a link offsets enum
        /// </summary>
        /// <returns>Returns: a tuple containing the success of the operation and the value</returns>
        public static (bool, LinkOffsets) FromInpString(this LinkOffsets offsets, string value)
        {
            switch (value)
            {
                case Depth: return (true, LinkOffsets.Depth);
                case Elevation: return (true, LinkOffsets.Elevation);
                default: return (false, LinkOffsets.Depth);
            }
        }

        /// <summary>
        /// Convert this value to an inp string with title
        /// </summary>
        /// <param name="value">The value that will be converted</param>
        /// <returns>Returns: an inp string</returns>
        public static string ToInpString(this LinkOffsets value)
        {
            string s;

            switch (value)
            {
                case LinkOffsets.Depth:
                    s = Depth;
                    break;
                case LinkOffsets.Elevation:
                    s = Elevation;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }

            return $"LINK_OFFSETS         {s}";
        }
    }
}
