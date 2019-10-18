// InfiltrationOption.cs
// Created: 2019-09-10
// By: Adam Renaud

using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Exceptions;
using Droplet.Core.Inp.Entities;
using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The <see cref="InfiltrationMethod"/> option
    /// </summary>
    public class InfiltrationOption : InpOption<InfiltrationMethod>
    {

        #region Constructors

        /// <summary>
        /// Default constructor that accepts an <see cref="InfiltrationMethod"/> that will 
        /// be set as the value for this option. This constructor also sets the <see cref="Name"/> 
        /// of this option to its default inp string value.
        /// </summary>
        /// <param name="infiltrationMethod">The method that the value will be set to</param>
        public InfiltrationOption(InfiltrationMethod infiltrationMethod) : base(infiltrationMethod) => Name = OptionName;

        /// <summary>
        /// Default Constructor for this option
        /// </summary>
        /// <param name="row"></param>
        /// <param name="database"></param>
        internal InfiltrationOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
            Value = Value.FromInpString(row[1]);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Public override of <see cref="IInpEntity.ToInpString"/>
        /// </summary>
        /// <returns>Returns: a formatted string that has the <see cref="Name"/> and <see cref="Value"/> of this option</returns>
        public override string ToInpString() 
            => Name.PadRight(OptionStringPadding) + Value.ToInpString();

        #endregion

        #region Internal Members

        /// <summary>
        /// The name of the option
        /// </summary>
        internal const string OptionName = "INFILTRATION";

        #endregion

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
    /// methods option enumeration <see cref="InfiltrationMethod"/>
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

        /// <summary>
        /// Converts a <see cref="InfiltrationMethod"/> to its inp string value
        /// </summary>
        /// <param name="method">The method that will be used to convert to a <see cref="string"/></param>
        /// <returns>Returns: the inp value of <paramref name="method"/></returns>
        public static string ToInpString(this InfiltrationMethod method) => method switch
        {
            InfiltrationMethod.Horton => "HORTON",
            InfiltrationMethod.ModifiedHorton => "MODIFIED_HORTON",
            InfiltrationMethod.GreenAmpt => "GREEN_AMPT",
            InfiltrationMethod.ModifiedGreenAmpt => "MODIFIED_GREEN_AMPT",
            InfiltrationMethod.CurveNumber => "CURVE_NUMBER",

            _ => throw InpParseException.CreateWithStandardMessage(typeof(InfiltrationOption))
        };

    }
}
