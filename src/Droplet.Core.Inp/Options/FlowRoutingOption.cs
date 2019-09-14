using Droplet.Core.Inp.Data;
using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The Flow Routing Option for an inp project.
    /// </summary>
    public class FlowRoutingOption : InpOption
    {
        #region Private Members

        /// <summary>
        /// The backing enum value for this option
        /// </summary>
        private FlowRouting _enumValue;

        #endregion

        #region Constructors

        /// <summary>
        /// The Default Constructor
        /// </summary>
        /// <param name="row">A row that this object will be created from</param>
        /// <param name="database">The database that this object belongs to</param>
        public FlowRoutingOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        #endregion

        #region Public Members

        /// <summary>
        /// The name of this option
        /// </summary>
        public const string OptionName = "FLOW_ROUTING";

        /// <summary>
        /// Get the value of this option. Will return
        /// a <see cref="object"/> that can be casted to
        /// a <see cref="FlowRouting"/> value. Also, this property can
        /// take a <see cref="string"/> and convert it to a <see cref="FlowRouting"/>
        /// value.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// The property will throw this exception if a value is passed to the
        /// setter that is not a <see cref="String"/> or a <see cref="FlowRouting"/>.
        /// </exception>
        public override object Value
        {
            // Get the enum value from the backing field
            get => _enumValue;

            // Set the backing field from the passed value
            // this set method will convert a string to a flow routing value if required.
            set
            {
                // if the value passed is string convert it to a flow routing
                if (value is string s)
                    _enumValue = _enumValue.FromInpString(s);
                
                // If the value passed is a flow routing just set the value
                else if (value is FlowRouting f)
                    _enumValue = f;

                // If it is an unrecognized type then throw an exception
                else
                    throw new ArgumentException($"The value of {value.GetType()}" +
                        $"is incompatible with the conversion to the type {typeof(FlowRouting)}");
            }
        }

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
