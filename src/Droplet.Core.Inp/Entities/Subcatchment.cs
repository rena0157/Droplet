using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Exceptions;
using System;
using System.Globalization;

namespace Droplet.Core.Inp.Entities
{
    /// <summary>
    /// A subcatchment Entity
    /// </summary>
    public class Subcatchment : InpEntity, INode, IEquatable<Subcatchment>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Subcatchment()
        {
        }

        /// <summary>
        /// Internal constructor that builds a subcatchment from a subcatchment row
        /// </summary>
        /// <param name="row">The row that will be used to build the subcatchment</param>
        /// <param name="database">The database that the subcatchment will belong to</param>
        internal Subcatchment(IInpTableRow row, IInpDatabase database) : base(row, database)
        {

            if (row.Values.Count < 8 && row.Values.Count > 9)
                throw InpParseException.CreateWithStandardMessage(typeof(Subcatchment));

            RainGageName = row[1];
            OutletName = row[2];

            try
            {
                Area = double.Parse(row[3], CultureInfo.InvariantCulture);
                PercentImperv = double.Parse(row[4], CultureInfo.InvariantCulture);
                Width = double.Parse(row[5], CultureInfo.InvariantCulture);
                PercentSlope = double.Parse(row[6], CultureInfo.InvariantCulture);
                CurbLength = double.Parse(row[7], CultureInfo.InvariantCulture);
            }
            catch (FormatException e)
            {
                throw InpParseException.CreateWithStandardMessage(typeof(Subcatchment), e);
            }

            if (!string.IsNullOrEmpty(row[8])) SnowPack = row[8]; 
        }

        #region Public Properties

        /// <summary>
        /// The Inp name for this entity
        /// </summary>
        public const string InpName = "SUBCATCHMENTS";

        /// <summary>
        /// The X Coordinate of the Subcatchment
        /// </summary>
        public double X { get; set; } = 0;

        /// <summary>
        /// The Y Coordinate of the Subcatchment
        /// </summary>
        public double Y { get; set; } = 0;

        /// <summary>
        /// The Z coordinate of the subcatchment
        /// </summary>
        public double Z { get; set; } = 0;

        /// <summary>
        /// The rain gage assigned to this subcatchment
        /// </summary>
        public string RainGage { get; set; } = "*";

        /// <summary>
        /// The name of the referenced <see cref="RainGage"/>
        /// </summary>
        public string RainGageName { get; set; } = "*";

        /// <summary>
        /// The node or other subcatchment that receives runoff
        /// </summary>
        public string Outlet { get; set; } = "*";

        /// <summary>
        /// The name of the referenced <see cref="Outlet"/>
        /// </summary>
        public string OutletName { get; set; } = "*";

        /// <summary>
        /// Area of the subcatchment (ha)
        /// </summary>
        public double Area { get; set; }

        /// <summary>
        /// With of overland flow path (m)
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Average surface slope (%)
        /// </summary>
        public double PercentSlope { get; set; }

        /// <summary>
        /// Percent of impervious area (%)
        /// </summary>
        public double PercentImperv { get; set; }

        /// <summary>
        /// Manning's N for impervious area
        /// </summary>
        public double NImperv { get; set; }

        /// <summary>
        /// Manning's N for pervious area
        /// </summary>
        public double NPerv { get; set; }

        /// <summary>
        /// Depth of depression storage on impervious area
        /// </summary>
        public double DStoreImperv { get; set; }

        /// <summary>
        /// Depth of depression storage on pervious area
        /// </summary>
        public double DStorePerv { get; set; }

        /// <summary>
        /// Percent of impervious area with no depression storage (%)
        /// </summary>
        public double PercentZeroImperv { get; set; }

        /// <summary>
        /// Choice of internal routing between pervious and impervious sub-areas
        /// </summary>
        public string SubAreaRouting { get; set; } = "*";

        /// <summary>
        /// Percent of runoff routed between sub-areas
        /// </summary>
        public double PercentRouted { get; set; }

        /// <summary>
        /// Infiltration Parameters
        /// </summary>
        public string InfiltrationData { get; set; } = "*";

        /// <summary>
        /// Groundwater flow parameters
        /// </summary>
        public string Groundwater { get; set; } = "*";

        /// <summary>
        /// Name of snow pack parameters
        /// </summary>
        public string SnowPack { get; set; } = "*";

        /// <summary>
        /// Low impact development controls
        /// </summary>
        public string LIDControls { get; set; } = "*";

        /// <summary>
        /// Assignment of land uses to subcatchment
        /// </summary>
        public string LandUses { get; set; } = "*";

        /// <summary>
        /// Initial pollutant buildup on subcatchment
        /// </summary>
        public string InitialBuildUp { get; set; } = "*";

        /// <summary>
        /// The curb length for this subcatchment
        /// </summary>
        public double CurbLength { get; set; }

        /// <summary>
        /// Optional Monthly pattern that adjusts <see cref="NPerv"/>
        /// </summary>
        public string NPervPattern { get; set; } = "*";

        /// <summary>
        /// Optional Monthly pattern that adjusts Depression Storage
        /// </summary>
        public string DStorePattern { get; set; } = "*";

        /// <summary>
        /// Optional monthly pattern that adjusts infiltration rate
        /// </summary>
        public string InfiltrationPattern { get; set; } = "*";

        #endregion

        #region Public Methods

        /// <summary>
        /// Public override of the <see cref="Object.Equals(object)"/> method for 
        /// the <see cref="Subcatchment"/> class
        /// </summary>
        /// <param name="obj">The object that will be compared</param>
        /// <returns>Returns: the value of <see cref="IEquatable{Subcatchment}.Equals(Subcatchment)"/></returns>
        public override bool Equals(object? obj)
        {
            var subcatchment = obj as Subcatchment;
            
            if (subcatchment == null) 
                return false;

            return Equals(subcatchment);
        }

        /// <summary>
        /// Test to see if two <see cref="Subcatchment"/>s are equal. This tests all of their non-inherited 
        /// public properties
        /// </summary>
        /// <param name="other">The other subcatchment</param>
        /// <returns>Returns: True if all public properties of this subcatchment match the <paramref name="other"/></returns>
        public bool Equals(Subcatchment other)
        {
            return other != null &&
                   X == other.X &&
                   Y == other.Y &&
                   Z == other.Z &&
                   RainGage == other.RainGage &&
                   RainGageName == other.RainGageName &&
                   Outlet == other.Outlet &&
                   OutletName == other.OutletName &&
                   Area == other.Area &&
                   Width == other.Width &&
                   PercentSlope == other.PercentSlope &&
                   PercentImperv == other.PercentImperv &&
                   NImperv == other.NImperv &&
                   NPerv == other.NPerv &&
                   DStoreImperv == other.DStoreImperv &&
                   DStorePerv == other.DStorePerv &&
                   PercentZeroImperv == other.PercentZeroImperv &&
                   SubAreaRouting == other.SubAreaRouting &&
                   PercentRouted == other.PercentRouted &&
                   InfiltrationData == other.InfiltrationData &&
                   Groundwater == other.Groundwater &&
                   SnowPack == other.SnowPack &&
                   LIDControls == other.LIDControls &&
                   LandUses == other.LandUses &&
                   InitialBuildUp == other.InitialBuildUp &&
                   CurbLength == other.CurbLength &&
                   NPervPattern == other.NPervPattern &&
                   DStorePattern == other.DStorePattern &&
                   InfiltrationPattern == other.InfiltrationPattern;
        }

        /// <summary>
        /// Generate a hash code for this entities using all public properties
        /// </summary>
        /// <returns>Returns: A hash code that encompasses all public properties of this entity</returns>
        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(base.GetHashCode());
            hash.Add(X);
            hash.Add(Y);
            hash.Add(Z);
            hash.Add(RainGage);
            hash.Add(RainGageName);
            hash.Add(Outlet);
            hash.Add(OutletName);
            hash.Add(Area);
            hash.Add(Width);
            hash.Add(PercentSlope);
            hash.Add(PercentImperv);
            hash.Add(NImperv);
            hash.Add(NPerv);
            hash.Add(DStoreImperv);
            hash.Add(DStorePerv);
            hash.Add(PercentZeroImperv);
            hash.Add(SubAreaRouting);
            hash.Add(PercentRouted);
            hash.Add(InfiltrationData);
            hash.Add(Groundwater);
            hash.Add(SnowPack);
            hash.Add(LIDControls);
            hash.Add(LandUses);
            hash.Add(InitialBuildUp);
            hash.Add(CurbLength);
            hash.Add(NPervPattern);
            hash.Add(DStorePattern);
            hash.Add(InfiltrationPattern);
            return hash.ToHashCode();
        }


        #endregion

    }
}
