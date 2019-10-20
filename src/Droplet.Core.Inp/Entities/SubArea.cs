using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Exceptions;
using System;
using System.Globalization;

namespace Droplet.Core.Inp.Entities
{
    /// <summary>
    /// A SubArea Entity Data class
    /// </summary>
    public class SubArea : InpEntityData
    {

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public SubArea()
        {
        }

        /// <summary>
        /// Internal constructor that accepts an <see cref="IInpTableRow"/> that will be used to build 
        /// the entity 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="database"></param>
        internal SubArea(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
            if (row.Values.Count < 7)
                throw InpParseException.CreateWithStandardMessage(typeof(SubArea));

            try
            {
                // double options
                NImperv = double.Parse(row[1], CultureInfo.InvariantCulture);
                NPerv = double.Parse(row[2], CultureInfo.InvariantCulture);
                SlopeImperv = double.Parse(row[3], CultureInfo.InvariantCulture);
                SlopePerv = double.Parse(row[4], CultureInfo.InvariantCulture);
                PercentZero = double.Parse(row[5], CultureInfo.InvariantCulture);

                // enumeration options
                RouteTo = RouteToOptionExtensions.FromInpString(row[6]);

                // Optional parameters
                PercentRouted = row.Values.Count == 8 ? 
                    double.Parse(row[7], CultureInfo.InvariantCulture) : 0;
            }
            catch(FormatException e)
            {
                throw InpParseException.CreateWithStandardMessage(typeof(SubArea), e);
            }

            // Get the entity from the database and add this entity data to it
            (Database?.GetEntity<Subcatchment>(Name) as IEntityDataHost<SubArea>)?.AddEntityData(this);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The name that is given to the table that holds <see cref="SubArea"/>s
        /// </summary>
        internal const string InpName = "SUBAREAS";

        /// <summary>
        /// Manning's N for impervious
        /// </summary>
        public double NImperv { get; set; }

        /// <summary>
        /// Manning's N for Pervious
        /// </summary>
        public double NPerv { get; set; }

        /// <summary>
        /// Slope of Impervious
        /// </summary>
        public double SlopeImperv { get; set; }

        /// <summary>
        /// Slope of Pervious
        /// </summary>
        public double SlopePerv { get; set; }

        /// <summary>
        /// Percent Zero 
        /// </summary>
        public double PercentZero { get; set; }

        /// <summary>
        /// Choice of internal routing between the different <see cref="RouteToOption"/>
        /// </summary>
        public RouteToOption RouteTo { get; set; }

        /// <summary>
        /// Percent of runoff routed between sub-areas
        /// </summary>
        public double PercentRouted { get; set; }

        #endregion

        #region Public Methods

        public override string ToInpString()
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    /// Different Options for the 
    /// </summary>
    public enum RouteToOption
    {
        /// <summary>
        /// Route to the outlet
        /// </summary>
        Outlet,

        /// <summary>
        /// Route to the Impervious SubArea
        /// </summary>
        Impervious,

        /// <summary>
        /// Route to the Pervious SubArea
        /// </summary>
        Pervious
    }

    /// <summary>
    /// Extension class for the <see cref="RouteToOption"/> enumeration
    /// </summary>
    public static class RouteToOptionExtensions
    {
        /// <summary>
        /// Convert from an inp string to a <see cref="RouteToOption"/> using the standard inp strings
        /// </summary>
        /// <param name="inpString">The inp string that will be converted</param>
        /// <returns>Returns: A <see cref="RouteToOption"/> that refers to the formatted inp string</returns>
        public static RouteToOption FromInpString(string inpString) => inpString switch
        {
            "OUTLET" => RouteToOption.Outlet,

            "IMPERVIOUS" => RouteToOption.Impervious,

            "PERVIOUS" => RouteToOption.Pervious,

            _ => throw InpParseException.CreateWithStandardMessage(typeof(RouteToOptionExtensions))
        };

        // TODO: Add the ToInpString Method
    }
}
