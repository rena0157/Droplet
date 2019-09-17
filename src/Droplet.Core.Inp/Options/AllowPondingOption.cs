// AllowPondingOption.cs
// By: Adam Renaud
// Created: 2019-09-156

using Droplet.Core.Inp.Data;

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
        public AllowPondingOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        /// <summary>
        /// The name of the option as defined in inp files
        /// </summary>
        public const string OptionName = "ALLOW_PONDING";

        /// <summary>
        /// Public override of the name property that returns
        /// the <see cref="OptionName"/> constant
        /// </summary>
        public override string Name => OptionName;
    }
}
