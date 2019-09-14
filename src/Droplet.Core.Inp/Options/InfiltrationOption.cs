// InfiltrationOption.cs
// Created: 2019-09-10
// By: Adam Renaud

using Droplet.Core.Inp.Data;
using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The <see cref="InfiltrationMethods"/> option
    /// </summary>
    public class InfiltrationOption : InpOption
    {
        /// <summary>
        /// Backing field for the enumeration type for this option
        /// </summary>
        private InfiltrationMethods _enumValue;

        /// <summary>
        /// The name of the option
        /// </summary>
        public const string OptionName = "INFILTRATION";

        /// <summary>
        /// Default Constructor for this option
        /// </summary>
        /// <param name="row"></param>
        /// <param name="database"></param>
        public InfiltrationOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
            Value = row[1];
        }

        /// <summary>
        /// The name of this option
        /// </summary>
        public override string Name => "INFILTRATION";

        /// <summary>
        /// Public override of the <see cref="InpOption.Value"/> property
        /// that is specific to this option. This value will return an <see cref="InfiltrationMethods"/>
        /// enum value as an object that can be casted.
        /// </summary>
        public override object Value
        {
            // Get the enum value
            get => _enumValue;

            // Otherwise set the value
            // If it is a string convert that string to an enum
            set
            {
                if (value is InfiltrationMethods v)
                    _enumValue = v;
                else if (value is string s)
                    _enumValue = _enumValue.FromInpString(s);
                else
                    throw new ArgumentException($"The type for value should be either " +
                        $"{typeof(InfiltrationMethods)} or {typeof(string)}");
            }
        }
    }

    /// <summary>
    /// Different Infiltration Methods that the SWMM5 engine provides
    /// </summary>
    public enum InfiltrationMethods
    {
        Horton,

        ModifiedHorton,

        GreenAmpt,

        ModifiedGreenAmpt,

        CurveNumber
    }

    /// <summary>
    /// Container class that holds all of the extension methods for the infiltration
    /// methods option enum <see cref="InfiltrationMethods"/>
    /// </summary>
    public static class InfiltrationMethodsExtensions
    {
        /// <summary>
        /// Converts a <see cref="string"/> to
        /// an <see cref="InfiltrationMethods"/> value using the prescribed
        /// conversions set out in the inp file standard
        /// </summary>
        /// <param name="i">The infiltration method</param>
        /// <param name="inpString">The string that will be used</param>
        /// <returns>Returns: the <see cref="InfiltrationMethods"/> corresponding to the string passed</returns>
        public static InfiltrationMethods FromInpString(this InfiltrationMethods i, string inpString) => inpString switch
        {
            "HORTON" => InfiltrationMethods.Horton,
            "MODIFIED_HORTON" => InfiltrationMethods.ModifiedHorton,
            "GREEN_AMPT" => InfiltrationMethods.GreenAmpt,
            "MODIFIED_GREEN_AMPT" => InfiltrationMethods.ModifiedGreenAmpt,
            "CURVE_NUMBER" => InfiltrationMethods.CurveNumber,
            _ => throw new ArgumentException($"The string {inpString} is not a valid {typeof(InfiltrationMethods)}")
        };
    }
}
