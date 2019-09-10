using Droplet.Core.Inp.Data;
using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// Options class for <see cref="FlowUnits"/>
    /// </summary>
    public class FlowUnitsOption : InpOption
    {
        #region Private Members

        /// <summary>
        /// Backing enum value for this option
        /// </summary>
        private FlowUnits _enumValue;

        #endregion

        #region Constants

        /// <summary>
        /// 
        /// </summary>
        public const string OptionName = "FLOW_UNITS";

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor that calls to the base constructor
        /// </summary>
        /// <param name="row">The row that will be used to create this option</param>
        /// <param name="database">The database that this option will belong to</param>
        public FlowUnitsOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        #endregion

        #region Overriden Base Members

        /// <summary>
        /// Public Override of the Flow Units Option
        /// </summary>
        public override string Name => "FlowUnits";

        /// <summary>
        /// Sets the value of this option from either a string
        /// that is an inp string or a <see cref="FlowUnits"/> enum
        /// </summary>
        public override object Value
        {
            get => _enumValue;
            protected set
            {
                if (value is string)
                    _enumValue = _enumValue.FromInpString(value as string);
                else if (value is FlowUnits)
                    _enumValue = (FlowUnits)value;
                else
                    throw new ArgumentException($"The type for value should be either " +
                        $"{typeof(FlowUnits)} or {typeof(string)}");

            }
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
    public enum FlowUnits
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
    /// class and extends the <see cref="FlowUnits"/> enumeration
    /// </summary>
    public static class FlowUnitsExtensions
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
            "MLD" => FlowUnits.MillionLitersPerDay,
            "MGD" => FlowUnits.MillionGallonsPerDay,

            _ => throw new ArgumentOutOfRangeException($"The string {s} could not be matched to a flow unts")
        };

        /// <summary>
        /// Convert the flow units to an inp string
        /// </summary>
        /// <param name="units">The units that will be converted</param>
        /// <returns>Returns: An inp string</returns>
        public static string ToInpString(this FlowUnits units) => units switch
        {
            FlowUnits.LitersPerSecond => "LPS",
            FlowUnits.CubicMetersPerSecond => "CMS",
            FlowUnits.CubicFeetPerSecond => "CFS",
            FlowUnits.GallonsPerMinute => "GPM",
            FlowUnits.MillionGallonsPerDay => "MGD",
            FlowUnits.MillionLitersPerDay => "MLD",

            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
