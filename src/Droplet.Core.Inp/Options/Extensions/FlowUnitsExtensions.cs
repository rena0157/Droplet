// FlowUnitsExtension.cs
// By: Adam Renaud
// Created: 2019-09-10

using System;

namespace Droplet.Core.Inp.Options.Extensions
{
    /// <summary>
    /// Flow Units Extensions Class
    /// </summary>
    public static class FlowUnitsExtensions
    {
        /// <summary>
        /// Extension method for the Flow Units type that parses a string from input. It then
        /// returns a bool indicating the success of the operation and the value.
        /// </summary>
        /// <param name="units">The units value that is required for the extension method</param>
        /// <param name="value">The string value that is to be parsed</param>
        /// <returns>Returns: a bool indicating the success of the parsing and the parsed value</returns>
        public static (bool, FlowUnits) FromInpString(this FlowUnits units, string value)
        {
            switch (value)
            {
                case "CFS": return (true, FlowUnits.CubicFeetPerSecond);
                case "CMS": return (true, FlowUnits.CubicMetersPerSecond);
                case "GPM": return (true, FlowUnits.GallonsPerMinute);
                case "MGD": return (true, FlowUnits.MillionGallonsPerDay);
                case "MLD": return (true, FlowUnits.MilltionLitersPerDay);
                case "LPS": return (true, FlowUnits.LitersPerSecond);
                default: return (false, FlowUnits.CubicFeetPerSecond);

            }
        }

        /// <summary>
        /// Write the flow units back to an inp string
        /// </summary>
        /// <param name="units">The units that will be written</param>
        /// <returns>Returns: a string that is a valid inp string</returns>
        public static string ToInpString(this FlowUnits units)
        {
            string s;
            switch (units)
            {
                case FlowUnits.LitersPerSecond:
                    s = "LPS";
                    break;
                case FlowUnits.GallonsPerMinute:
                    s = "GPM";
                    break;
                case FlowUnits.MillionGallonsPerDay:
                    s = "MGD";
                    break;
                case FlowUnits.CubicMetersPerSecond:
                    s = "CMS";
                    break;
                case FlowUnits.MilltionLitersPerDay:
                    s = "MLD";
                    break;

                case FlowUnits.CubicFeetPerSecond:
                    s = "CFS";
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(units), units, null);
            }

            return $"FLOW_UNITS           {s}";
        }
    }
}
