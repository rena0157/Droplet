// InfiltrationOption.cs
// Created: 2019-09-10
// By: Adam Renaud

using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Exceptions;
using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The <see cref="InfiltrationMethod"/> option
    /// </summary>
    public class InfiltrationOption : InpOption<InfiltrationMethod>
    {
        /// <summary>
        /// The name of the option
        /// </summary>
        internal const string OptionName = "INFILTRATION";

        /// <summary>
        /// Default Constructor for this option
        /// </summary>
        /// <param name="row"></param>
        /// <param name="database"></param>
        internal InfiltrationOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
            Value = Value.FromInpString(row[1]);
        }
    }

    /// <summary>
    /// Different Infiltration Methods that the SWMM5 engine provides
    /// </summary>
    public enum InfiltrationMethod
    {
        Horton,

        ModifiedHorton,

        GreenAmpt,

        ModifiedGreenAmpt,

        CurveNumber
    }

    /// <summary>
    /// Container class that holds all of the extension methods for the infiltration
    /// methods option enum <see cref="InfiltrationMethod"/>
    /// </summary>
    public static class InfiltrationMethodsExtensions
    {
        /// <summary>
        /// Converts a <see cref="string"/> to
        /// an <see cref="InfiltrationMethod"/> value using the prescribed
        /// conversions set out in the inp file standard
        /// </summary>
        /// <param name="i">The infiltration method</param>
        /// <param name="inpString">The string that will be used</param>
        /// <returns>Returns: the <see cref="InfiltrationMethod"/> corresponding to the string passed</returns>
        public static InfiltrationMethod FromInpString(this InfiltrationMethod i, string inpString) => inpString switch
        {
            "HORTON" => InfiltrationMethod.Horton,
            "MODIFIED_HORTON" => InfiltrationMethod.ModifiedHorton,
            "GREEN_AMPT" => InfiltrationMethod.GreenAmpt,
            "MODIFIED_GREEN_AMPT" => InfiltrationMethod.ModifiedGreenAmpt,
            "CURVE_NUMBER" => InfiltrationMethod.CurveNumber,
            _ => throw InpParseException.CreateWithStandardMessage(typeof(InfiltrationOption))
        };
    }
}
