using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Entities;
using Droplet.Core.Inp.Exceptions;
using System;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The SWMM5 Option that sets the <see cref="ForcemainEquation"/> 
    /// that will be used in the simulation
    /// </summary>
    public class ForcemainEquationOption : InpOption<ForcemainEquation>
    {
        #region Constructors

        /// <summary>
        /// Default Constructor that accepts a <see cref="ForcemainEquation"/> 
        /// that will be used to set the <see cref="InpOption{T}.Value"/> of 
        /// this option.
        /// </summary>
        /// <param name="value">The value that will be used to set the value of 
        /// this option.</param>
        public ForcemainEquationOption(ForcemainEquation value) : base(value) => Name = OptionName;

        /// <summary>
        /// Internal constructor that accepts an <see cref="IInpTableRow"/> and an <see cref="IInpDatabase"/> 
        /// that will be used to construct the option
        /// </summary>
        /// <param name="row">The row that will be used to construct the option</param>
        /// <param name="database">The database that the option belongs to</param>
        internal ForcemainEquationOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
            Value = ParseRow(row);
        }

        #endregion

        #region Internal Members

        /// <summary>
        /// The option name as found in inp files
        /// </summary>
        internal const string OptionName = "FORCE_MAIN_EQUATION";

        /// <summary>
        /// Parse the row that is passed and return a <see cref="ForcemainEquation"/>
        /// </summary>
        /// <param name="row">The row that will be parsed</param>
        /// <returns>Returns: A <see cref="ForcemainEquation"/> from the parsed row</returns>
        protected internal override ForcemainEquation ParseRow(IInpTableRow row)
        {
            _ = row ?? throw new ArgumentNullException(nameof(row));

            return ForcemainEquation.DarcyWeisbach.FromInpString(row[1]);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Public override of the <see cref="InpEntity.ToInpString"/> method
        /// </summary>
        /// <returns>Returns: The name and value of the option formatted for an inp file</returns>
        public override string ToInpString() 
            => Name.PadRight(OptionStringPadding) + Value.ToInpString();

        #endregion
    }

    /// <summary>
    /// The different options for the forcemain equations 
    /// that the SWMM5 engine uses
    /// </summary>
    public enum ForcemainEquation
    {
        /// <summary>
        /// The Hazen–Williams equation is an empirical relationship which 
        /// relates the flow of water in a pipe with the physical properties 
        /// of the pipe and the pressure drop caused by friction.
        /// </summary>
        HazenWilliams,

        /// <summary>
        /// In fluid dynamics, the Darcy–Weisbach equation is an empirical equation, 
        /// which relates the head loss, or pressure loss, due 
        /// to friction along a given length of pipe to the average velocity of the 
        /// fluid flow for an incompressible fluid. 
        /// </summary>
        DarcyWeisbach
    }

    public static class ForcemainEquationExtensions
    {
        /// <summary>
        /// Convert an inp <see cref="string"/> to a <see cref="ForcemainEquation"/>
        /// </summary>
        /// <param name="forcemainEquation">The <see cref="ForcemainEquation"/> that the extension 
        /// will base off of</param>
        /// <param name="inpString">The <see cref="string"/> that will be converted</param>
        /// <exception cref="InpParseException">
        /// Thrown if an unhandled value for the string is passed
        /// </exception>
        /// <returns>Returns: a <see cref="ForcemainEquation"/> that corresponds to the 
        /// correct inp string value</returns>
        public static ForcemainEquation FromInpString(this ForcemainEquation forcemainEquation, 
            string inpString) => inpString switch
        {
            "D-W" => ForcemainEquation.DarcyWeisbach,

            "H-W" => ForcemainEquation.HazenWilliams,

            _ => throw InpParseException.CreateWithStandardMessage(typeof(ForcemainEquationExtensions))
        };

        /// <summary>
        /// Convert the <see cref="ForcemainEquation"/> back into an inp string
        /// </summary>
        /// <param name="forcemainEquation">The forcemain equation that will be converted</param>
        /// <exception cref="InpParseException">Throws if an inhandled 
        /// value is attemped to be converted</exception>
        /// <returns>Returns: A valid inp string from the value of the forcemain equation</returns>
        public static string ToInpString(this ForcemainEquation forcemainEquation) => forcemainEquation switch
        {
            ForcemainEquation.DarcyWeisbach => "D-W",

            ForcemainEquation.HazenWilliams => "H-W",

            _ => throw InpParseException.CreateWithStandardMessage(typeof(ForcemainEquationExtensions))
        };
    }
}
