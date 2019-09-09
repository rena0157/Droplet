using System;

namespace Droplet.Core.Inp.Options
{
    public static class OptionsExtensions
    {
        /// <summary>
        /// Get the Database name for the Option
        /// </summary>
        /// <param name="option">The option</param>
        /// <returns></returns>
        public static string GetDbName(this FlowUnits u) => "FLOW_UNITS";

        /// <summary>
        /// Convert an inp string to a <see cref="FlowUnits"/> enumeration
        /// </summary>
        /// <param name="units">The units that this is extending</param>
        /// <param name="s">The inp string</param>
        /// <returns></returns>
        public static FlowUnits FromInpString(this FlowUnits u, string s) => s switch
        {
            "LPS" => FlowUnits.LitersPerSecond,
            "CMS" => FlowUnits.CubicMetersPerSecond,
            "CFS" => FlowUnits.CubicFeetPerSecond,
            "GPM" => FlowUnits.GallonsPerMinute,
            "MLD" => FlowUnits.MilltionLitersPerDay,
            "MGD" => FlowUnits.MillionGallonsPerDay,
            _     => throw new ArgumentOutOfRangeException($"The string {s} could not be matched to a flow unts")
        };

        /// <summary>
        /// Convert the flow units to an inp string
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        public static string ToInpString(this FlowUnits units) => units switch
        {
            FlowUnits.LitersPerSecond => "LPS"
        };
    }
}
