// InpLib
// InertialTermsExtensions.cs
// 
// ============================================================
// 
// Created: 2019-08-11
// Last Updated: 2019-08-11-09:28 AM
// By: Adam Renaud
// 
// ============================================================

using System;

namespace Droplet.Core.Inp.Options.Extensions
{
    /// <summary>
    /// Class for holding all of the extensions for inertial terms
    /// </summary>
    public static class InertialTermsExtensions
    {
        /// <summary>
        /// Try and parse inertial terms from a string that comes
        /// from an inp file
        /// </summary>
        /// <param name="terms">The terms that are passed</param>
        /// <param name="value">The value of the string passed from the inp file</param>
        /// <returns></returns>
        public static (bool, InertialTerms) FromInpString(this InertialTerms terms, string value)
        {
            switch (value)
            {
                case "PARTIAL": return (true, InertialTerms.Dampen);
                case "FULL": return (true, InertialTerms.Ignore);
                case "NONE": return (true, InertialTerms.Keep);
                default: return (false, InertialTerms.Dampen);
            }
        }

        /// <summary>
        /// Convert the inertial terms to an inp string
        /// </summary>
        /// <param name="terms">The terms that will be converted</param>
        /// <returns>Returns: a valid inp string that can go into an inp file</returns>
        public static string ToInpString(this InertialTerms terms)
        {
            string s;
            switch (terms)
            {
                case InertialTerms.Dampen:
                    s = "PARTIAL";
                    break;
                case InertialTerms.Keep:
                    s = "NONE";
                    break;
                case InertialTerms.Ignore:
                    s = "FULL";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(terms), terms, null);
            }

            return $"INERTIAL_DAMPING     {s}";
        }
    }
}
