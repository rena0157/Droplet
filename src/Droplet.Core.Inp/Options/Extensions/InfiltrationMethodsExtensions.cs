// InfiltrationMethodsExtensions.cs
// By: Adam Renaud
// Created: 2019-08-10

using System;

namespace Droplet.Core.Inp.Options.Extensions
{
    /// <summary>
    /// Static class that contains all of the extension methods for InfiltrationMethods Enum
    /// </summary>
    public static class InfiltrationMethodsExtension
    {
        private const string Horton = "HORTON";
        private const string ModifiedHorton = "MODIFIED_HORTON";
        private const string GreenAmpt = "GREEN_AMPT";
        private const string ModifiedGreenAmpt = "MODIFIED_GREEN_AMPT";
        private const string CurveNumber = "CURVE_NUMBER";

        /// <summary>
        /// Extension Method that takes a string and tries to convert it from Inp file strings
        /// to an InfiltrationMethod
        /// </summary>
        /// <returns>Returns: A Tuple where Item1: bool if the operation was successfull and Item2: the value of the parsing</returns>
        public static (bool, InfiltrationMethods) FromInpString(this InfiltrationMethods methods, string value)
        {
            switch (value)
            {
                case Horton: return (true, InfiltrationMethods.Horton);
                case ModifiedHorton: return (true, InfiltrationMethods.ModifiedHorton);
                case GreenAmpt: return (true, InfiltrationMethods.GreenAmpt);
                case ModifiedGreenAmpt: return (true, InfiltrationMethods.ModifiedGreenAmpt);
                case CurveNumber: return (true, InfiltrationMethods.CurveNumber);
                default: return (false, InfiltrationMethods.Horton);
            }
        }

        /// <summary>
        /// Convert the value of this enum to an inp string line
        /// </summary>
        /// <param name="method">The method that will be converted</param>
        /// <returns>Returns: A string that is a valid inp line for this item</returns>
        public static string ToInpString(this InfiltrationMethods method)
        {
            string s;

            switch (method)
            {
                case InfiltrationMethods.Horton:
                    s = Horton;
                    break;
                case InfiltrationMethods.ModifiedHorton:
                    s = ModifiedHorton;
                    break;
                case InfiltrationMethods.GreenAmpt:
                    s = GreenAmpt;
                    break;
                case InfiltrationMethods.ModifiedGreenAmpt:
                    s = ModifiedGreenAmpt;
                    break;
                case InfiltrationMethods.CurveNumber:
                    s = CurveNumber;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(method), method, null);
            }

            return $"INFILTRATION         {s}";
        }
    }
}
