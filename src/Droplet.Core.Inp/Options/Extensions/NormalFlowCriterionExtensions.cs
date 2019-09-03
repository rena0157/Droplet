// InpLib
// NormalFlowCriterionExtensions.cs
// 
// ============================================================
// 
// Created: 2019-08-11
// Last Updated: 2019-08-11-09:46 AM
// By: Adam Renaud
// 
// ============================================================

using System;

namespace Droplet.Core.Inp.Options.Extensions
{
    /// <summary>
    /// Extensions for the NormalFlowCriterion Enum
    /// </summary>
    public static class NormalFlowCriterionExtensions
    {
        private const string Slope = "SLOPE";
        private const string Froude = "FROUDE";
        private const string SlopeAndFroude = "BOTH";

        /// <summary>
        /// Parse a normal flow criterion from an inp string
        /// </summary>
        /// <param name="nfc">The object that is passed</param>
        /// <param name="value">The value of the string that is to be parsed</param>
        /// <returns>Returns: (True if the operation is successful, the value)</returns>
        public static (bool, NormalFlowCriterion) FromInpString(this NormalFlowCriterion nfc, string value)
        {
            switch (value)
            {
                case Froude: return (true, NormalFlowCriterion.Froude);
                case Slope: return (true, NormalFlowCriterion.Slope);
                case SlopeAndFroude: return (true, NormalFlowCriterion.SlopeAndFroude);
                default: return (false, NormalFlowCriterion.SlopeAndFroude);
            }
        }

        /// <summary>
        /// Convert this value to an inp string
        /// </summary>
        /// <param name="value">The value that will be converted</param>
        /// <returns>Returns: An inp string with the value</returns>
        public static string ToInpString(this NormalFlowCriterion value)
        {
            string s;
            switch (value)
            {
                case NormalFlowCriterion.Slope:
                    s = Slope;
                    break;
                case NormalFlowCriterion.Froude:
                    s = Froude;
                    break;
                case NormalFlowCriterion.SlopeAndFroude:
                    s = SlopeAndFroude;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }

            return $"NORMAL_FLOW_LIMITED  {s}";
        }
    }
}
