using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Exceptions;
using Droplet.Core.Inp.Entities;
using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The Flow Routing Option for an inp project.
    /// </summary>
    public class FlowRoutingOption : InpOption<FlowRouting>
    {
        #region Constructors

        /// <summary>
        /// The default constructor for the <see cref="FlowRoutingOption"/> that accepts 
        /// a <see cref="FlowRouting"/> that the value of this option will be set to. The 
        /// <see cref="Name"/> for this option will be set to the default Inp String Name value.
        /// </summary>
        /// <param name="value">The <see cref="FlowRouting"/> that the value for this option will be set to</param>
        public FlowRoutingOption(FlowRouting value) : base(value) => Name = OptionName;

        /// <summary>
        /// The Default Constructor. Note that the base constructor
        /// will initialize the <see cref="Value"/> field.
        /// </summary>
        /// <param name="row">A row that this object will be created from</param>
        /// <param name="database">The database that this object belongs to</param>
        internal FlowRoutingOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
            // Parse the row
            Value = ParseRow(row);
        }

        #endregion

        #region Internal Members

        /// <summary>
        /// The name of this option
        /// </summary>
        internal const string OptionName = "FLOW_ROUTING";

        /// <summary>
        /// Protected internal override for the <see cref="InpOption{T}.ParseRow(IInpTableRow)"/> Method 
        /// that parses the row and returns a <see cref="FlowRouting"/> option
        /// </summary>
        /// <param name="row">The row that will be parsed</param>
        /// <returns>Returns: The parsed <see cref="FlowRouting"/> value</returns>
        protected internal override FlowRouting ParseRow(IInpTableRow row)
        {
            // Check for null
            _ = row ?? throw new ArgumentNullException(nameof(row));

            // Return the from inp string value
            return FlowRouting.SteadyFlow.FromInpString(row[1]);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Public override of the <see cref="IInpEntity.ToInpString"/> Method 
        /// That will convert this entity to an inp string
        /// </summary>
        /// <returns>Returns: the <see cref="Name"/> of this object and its <see cref="Value"/></returns>
        public override string ToInpString()
            => Name.PadRight(OptionStringPadding) + Value.ToInpString();

        #endregion

    }

    /// <summary>
    /// The different options for the <see cref="FlowRoutingOption"/>
    /// that can be selected
    /// </summary>
    public enum FlowRouting
    {
        /// <summary>
        /// Steady state flow routing
        /// </summary>
        SteadyFlow,

        /// <summary>
        /// Kinematic Wave flow routing
        /// </summary>
        KinematicWave,

        /// <summary>
        /// Dynamic wave flow routing
        /// </summary>
        DynamicWave
    }

    /// <summary>
    /// Static class that contains all of the extension methods for the
    /// <see cref="FlowRouting"/> enumeration.
    /// </summary>
    public static class FlowRoutingExtensions
    {
        /// <summary>
        /// Convert a string <paramref name="s"/> to
        /// a <see cref="FlowRouting"/> value as per the inp spec.
        /// </summary>
        /// <param name="routing">The value for the extension method</param>
        /// <param name="s">The <see cref="string"/> that will be used to create the value</param>
        /// <returns>Returns: The converted value from the string that will be a <see cref="FlowRouting"/> value</returns>
        public static FlowRouting FromInpString(this FlowRouting routing, string s) => s switch
        {
            // Conversion for the steady flow option
            "STEADY" => FlowRouting.SteadyFlow,

            // Conversion for the dynamic wave flow option
            "DYNWAVE" => FlowRouting.DynamicWave,

            // Conversion for the kinematic wave flow option
            "KINWAVE" => FlowRouting.KinematicWave,

            // If the string is not a recognized value then throw an exception
            _ => throw InpParseException.CreateWithStandardMessage(typeof(FlowRoutingOption))
        };

        /// <summary>
        /// Convert the value of this <see cref="FlowRouting"/> enumeration to an inp <see cref="string"/>
        /// </summary>
        /// <param name="routingValue">The this object that will be used for the extension method</param>
        /// <returns>Returns: An inp <see cref="string"/> that corresponds to the value of <paramref name="routingValue"/></returns>
        public static string ToInpString(this FlowRouting routingValue) => routingValue switch
        {
            // Conversion for the Steady Flow Option
            FlowRouting.SteadyFlow => "STEADY",

            // Conversion for the Kinematic Wave Option
            FlowRouting.KinematicWave => "KINWAVE",

            // Conversion for the Dynamic Wave Option
            FlowRouting.DynamicWave => "DYNWAVE",

            // Throw exception if unknown value is passed
            _ => throw InpParseException.CreateWithStandardMessage(typeof(FlowRoutingOption))
        };
    }
}
