using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Exceptions;
using Droplet.Core.Inp.Entities;
using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The normal flow option
    /// </summary>
    public class NormalFlowOption : InpOption<NormalFlowCriterion>
    {
        /// <summary>
        /// Default Constructor that accepts a <see cref="NormalFlowCriterion"/> that will 
        /// be used to set the value of this option
        /// </summary>
        /// <param name="value"></param>
        public NormalFlowOption(NormalFlowCriterion value) : base(value) 
            => Name = OptionName;

        /// <summary>
        /// The internal constructor that will build this option from 
        /// an <see cref="IInpTableRow"/> and place it in the <see cref="IInpDatabase"/> passed
        /// </summary>
        /// <param name="row">The row that will be used to build the option</param>
        /// <param name="database">The database that the option belongs to</param>
        internal NormalFlowOption(IInpTableRow row, IInpDatabase database) : base(row, database)
            => Value = ParseRow(row);

        /// <summary>
        /// The name of the option inp string
        /// </summary>
        internal const string OptionName = "NORMAL_FLOW_LIMITED";

        /// <summary>
        /// Parse the row that is passed to this method into a <see cref="NormalFlowCriterion"/>
        /// </summary>
        /// <param name="row">The row that will be parsed</param>
        /// <returns>Returns: A valid <see cref="NormalFlowCriterion"/></returns>
        protected internal override NormalFlowCriterion ParseRow(IInpTableRow row)
        {
            _ = row ?? throw new ArgumentNullException(nameof(row));
            return NormalFlowCriterionExtensions.FromInpString(row[1]);
        }

        /// <summary>
        /// Public override of the <see cref="InpEntity.ToInpString"/>
        /// </summary>
        /// <returns>Returns: A formatted inp string</returns>
        public override string ToInpString()
            => Name.PadRight(OptionStringPadding) + Value.ToInpString();
    }

    /// <summary>
    /// The different Normal Flow Criterion for 
    /// the <see cref="NormalFlowOption"/>
    /// </summary>
    public enum NormalFlowCriterion
    {
        Slope,

        Froude,

        SlopeAndFroude
    }

    public static class NormalFlowCriterionExtensions
    {
        /// <summary>
        /// Method that converts this <see cref="NormalFlowCriterion"/> into an inp string
        /// </summary>
        /// <param name="flowCriterion">This normal flow criterion option</param>
        /// <returns>Returns: An inp string that corresponds to this value</returns>
        public static string ToInpString(this NormalFlowCriterion flowCriterion) => flowCriterion switch
        {
            NormalFlowCriterion.Froude => "FROUDE",

            NormalFlowCriterion.Slope => "SLOPE",

            NormalFlowCriterion.SlopeAndFroude => "BOTH",

            _ => throw InpParseException.CreateWithStandardMessage(typeof(NormalFlowCriterionExtensions))
        };

        /// <summary>
        /// Converts a inp string into a <see cref="NormalFlowCriterion"/>
        /// </summary>
        /// <param name="value">The string that will be converted</param>
        /// <returns>Returns: the <see cref="NormalFlowCriterion"/> that corresponds to the parsed string</returns>
        public static NormalFlowCriterion FromInpString(string value) => value switch
        {

            "FROUDE" => NormalFlowCriterion.Froude,

            "SLOPE" => NormalFlowCriterion.Slope,

            "BOTH" => NormalFlowCriterion.SlopeAndFroude,

            _ => throw InpParseException.CreateWithStandardMessage(typeof(NormalFlowCriterionExtensions))
        };
    }
}
