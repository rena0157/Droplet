using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Exceptions;
using Droplet.Core.Inp.Utilities;
using System;
using System.Globalization;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The inertial terms option. Effects the way that
    /// the terms of the St. Venant momentum equation will be handled.
    /// </summary>
    public class InertialTermsOption : InpOption<InertialTermsHandling>
    {
        /// <summary>
        /// Constructor that accepts an <see cref="IInpTableRow"/> and an 
        /// <see cref="IInpDatabase"/>
        /// </summary>
        /// <param name="row">The row that will be used to build the option</param>
        /// <param name="database">The database that the option will belong to</param>
        internal InertialTermsOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
            // Parse the row
            Value = ParseRow(row);
        }

        /// <summary>
        /// The inp option name that is found in inp files
        /// </summary>
        internal const string OptionName = "INERTIAL_DAMPING";

        protected internal override InertialTermsHandling ParseRow(IInpTableRow row)
        {
            // Check for null
            _ = row ?? throw new ArgumentNullException(nameof(row));

            // Return the parsed value of the inp string from the
            // From inp string extension method
            return InertialTermsHandling.Dampen.FromInpString(row[1]);
        }
    }

    /// <summary>
    /// How the inertial terms can be handled in SWMM5
    /// </summary>
    public enum InertialTermsHandling
    {
        /// <summary>
        /// Keeps the terms at their full value
        /// </summary>
        Keep,

        /// <summary>
        /// Reduce the terms as flow comes closer to being critical 
        /// and ignores them when the flow is supercritical
        /// </summary>
        Dampen,

        /// <summary>
        /// Ignores these terms outright from the momentum equation.
        /// </summary>
        Ignore
    }

    /// <summary>
    /// Public static class that holds the extension methods for
    /// the <see cref="InertialTermsHandling"/> enumeration
    /// </summary>
    public static class InertialTermsHandlingExtensions
    {
        /// <summary>
        /// Convert this <see cref="InertialTermsHandling"/> object 
        /// into another using a <see cref="string"/> that represents a string 
        /// that is from an inp file
        /// </summary>
        /// <param name="terms">The this for the extensions method</param>
        /// <param name="value">The value of the string that will be converted</param>
        /// <exception cref="ArgumentException">
        /// Thrown if the string passed does not match a prescribed pattern
        /// </exception>
        /// <returns>Returns: A <see cref="InertialTermsHandling"/> value corresponding to the
        ///  correct inp value</returns>
        public static InertialTermsHandling FromInpString(this InertialTermsHandling terms, string value)
            => value switch
        {
            "NONE" => InertialTermsHandling.Keep,
            "FULL" => InertialTermsHandling.Ignore,
            "PARTIAL" => InertialTermsHandling.Dampen,

            // If the string passed does not match the prescribed pattern throw an argument exception
            _ => throw InpParseException.CreateWithStandardMessage(typeof(InertialTermsOption))
        };
    }
}
