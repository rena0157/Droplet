using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Exceptions;
using Droplet.Core.Inp.Utilities;
using System;
using System.Globalization;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// Options class for <see cref="FlowUnit"/>
    /// </summary>
    public class FlowUnitsOption : InpOption<FlowUnit>
    {
        #region Constants

        /// <summary>
        /// The name of the option
        /// </summary>
        internal const string OptionName = "FLOW_UNITS";

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor that calls to the base constructor
        /// </summary>
        /// <param name="row">The row that will be used to create this option</param>
        /// <param name="database">The database that this option will belong to</param>
        internal FlowUnitsOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
            Value = Value.FromInpString(row[1]);
        }

        #endregion
    }

    /// <summary>
    /// The different possible flow units that can be used in the
    /// simultaion and results
    /// 
    /// US Units.
    /// CFS: cubic feet per second 
    /// GPM: gallons per minutes
    /// MGD: million gallons per day
    ///
    /// SI Units.
    /// CMS: cubic meters per second
    /// LPS: liters per second
    /// MLD: million liters per day 
    /// </summary>
    public enum FlowUnit
    {
        LitersPerSecond,

        CubicFeetPerSecond,

        GallonsPerMinute,

        MillionGallonsPerDay,

        CubicMetersPerSecond,

        MillionLitersPerDay
    }

    /// <summary>
    /// Public static class that holds extension methods for the <see cref="FlowUnitsOption"/>
    /// class and extends the <see cref="FlowUnit"/> enumeration
    /// </summary>
    public static class FlowUnitsExtensions
    {
        /// <summary>
        /// Get the Database name for the Option
        /// </summary>
        /// <param name="option">The option</param>
        /// <returns></returns>
        public static string GetDbName(this FlowUnit u) => "FLOW_UNITS";

        /// <summary>
        /// Convert an inp string to a <see cref="FlowUnit"/> enumeration
        /// </summary>
        /// <param name="units">The units that this is extending</param>
        /// <param name="s">The inp string</param>
        /// <returns></returns>
        public static FlowUnit FromInpString(this FlowUnit u, string s) => s switch
        {
            "LPS" => FlowUnit.LitersPerSecond,
            "CMS" => FlowUnit.CubicMetersPerSecond,
            "CFS" => FlowUnit.CubicFeetPerSecond,
            "GPM" => FlowUnit.GallonsPerMinute,
            "MLD" => FlowUnit.MillionLitersPerDay,
            "MGD" => FlowUnit.MillionGallonsPerDay,

            _ => throw new ArgumentOutOfRangeException($"The string {s} could not be matched to a flow unts")
        };

        /// <summary>
        /// Convert the flow units to an inp string
        /// </summary>
        /// <param name="units">The units that will be converted</param>
        /// <returns>Returns: An inp string</returns>
        public static string ToInpString(this FlowUnit units) => units switch
        {
            FlowUnit.LitersPerSecond => "LPS",
            FlowUnit.CubicMetersPerSecond => "CMS",
            FlowUnit.CubicFeetPerSecond => "CFS",
            FlowUnit.GallonsPerMinute => "GPM",
            FlowUnit.MillionGallonsPerDay => "MGD",
            FlowUnit.MillionLitersPerDay => "MLD",

            _ => throw new ArgumentException(new InpResourceManager()
                .GetString("ToInpString.ArgumentException", CultureInfo.CurrentCulture))
        };
    }
}
