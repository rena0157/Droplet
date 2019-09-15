using Droplet.Core.Inp.Data;
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
        /// The Default Constructor. Note that the base constructor
        /// will initialize the <see cref="Value"/> field.
        /// </summary>
        /// <param name="row">A row that this object will be created from</param>
        /// <param name="database">The database that this object belongs to</param>
        public FlowRoutingOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
            Value = Value.FromInpString(row[1]);
        }

        #endregion

        #region Public Members

        /// <summary>
        /// The name of this option
        /// </summary>
        public const string OptionName = "FLOW_ROUTING";

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
    /// <see cref="FlowRouting"/> enum.
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

            // If the string is not a regcongnized value then throw an exception
            _ => throw new ArgumentException($"The string {s} is not a valid inp string that" +
                $"can be converted to the type {typeof(FlowRouting)}")
        };
    }
}
