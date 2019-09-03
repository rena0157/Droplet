// InpBoolExtension.cs
// By: Adam Renaud
// Created: 2019-08-10

using System;
namespace Droplet.Core.Inp.Options.Extensions
{
    /// <summary>
    /// Extension library for the <see cref="Boolean"/> type
    /// </summary>
    public static class InpBoolExtension
    {
        private const string Yes = "YES";
        private const string No = "NO";

        /// <summary>
        /// Set a bool value from an inp string
        /// </summary>
        /// <param name="value">The string</param>
        /// <returns></returns>
        public static (bool, bool) FromInpString(this bool inputValue, string value)
        {
            switch (value)
            {
                case Yes: return (true, true);
                case No: return (true, false);
                default: return (false, true);
            }
        }

        /// <summary>
        /// Convert a boolean to an inp string value yes or no.
        /// Note that this does not include the whole inp line
        /// </summary>
        /// <param name="value">The value that will be converted</param>
        /// <returns>Returns: yes for true and no for false</returns>
        public static string ToInpString(this bool value)
        {
            string s;
            switch (value)
            {
                case true:
                    s = Yes;
                    break;
                default:
                    s = No;
                    break;
            }
            return s;
        }
    }
}
