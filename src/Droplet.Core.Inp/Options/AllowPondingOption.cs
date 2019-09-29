// AllowPondingOption.cs
// By: Adam Renaud
// Created: 2019-09-156

using Droplet.Core.Inp.Data;
using System;
using System.Globalization;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// Sets the policy for allowing ponding or not
    /// </summary>
    public class AllowPondingOption : InpBoolOption
    {
        /// <summary>
        /// Constructor that accepts a <see cref="IInpTableRow"/> and a <see cref="IInpDatabase"/>
        /// </summary>
        /// <param name="row">The row that will be used to construct the option</param>
        /// <param name="database">The database that the option belongs to</param>
        internal AllowPondingOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {

        }

        /// <summary>
        /// The name of the option as defined in inp files
        /// </summary>
        internal const string OptionName = "ALLOW_PONDING";
    }
}
