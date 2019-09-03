// InpLib
// ForcemainEquationsExtensions.cs
// 
// ============================================================
// 
// Created: 2019-08-11
// Last Updated: 2019-08-11-09:55 AM
// By: Adam Renaud
// 
// ============================================================

using System;

namespace Droplet.Core.Inp.Options.Extensions
{
    public static class ForcemainEquationsExtensions
    {
        public static (bool, ForcemainEquations) FromInpString(this ForcemainEquations eq, string value)
        {
            switch (value)
            {
                case "D-W": return (true, ForcemainEquations.DarcyWeisbach);
                case "H-W": return (true, ForcemainEquations.HazenWilliams);
                default: return (false, ForcemainEquations.DarcyWeisbach);
            }
        }

        /// <summary>
        /// Convert the Forcemain equation back into an Inp String
        /// </summary>
        /// <param name="eq">The equation</param>
        /// <returns>Returns: a string that is a valid inp string</returns>
        public static string ToInpString(this ForcemainEquations eq)
        {
            string s;
            switch (eq)
            {
                case ForcemainEquations.HazenWilliams:
                    s = "H-W";
                    break;
                case ForcemainEquations.DarcyWeisbach:
                    s = "D-W";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(eq), eq, null);
            }

            return $"FORCE_MAIN_EQUATION  {s}";
        }
    }
}
