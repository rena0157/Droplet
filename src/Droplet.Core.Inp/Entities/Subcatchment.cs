// InpLib
// Subcatchment.cs
// 
// ============================================================
// 
// Created: 2019-08-11
// Last Updated: 2019-08-11-01:02 PM
// By: Adam Renaud
// 
// ============================================================

using System;
using System.Collections.Generic;
using System.Text;
using Droplet.Core.Inp.Parsers;

namespace Droplet.Core.Inp.Entities
{
    /// <summary>
    /// The Subcatchment entity
    /// </summary>
    public class Subcatchment : InpEntity, IInpNode, IInpTableParseable, IEquatable<Subcatchment>
    {

        #region Constructors

        /// <summary>
        /// Default Constructor for a subcatchment that initializes
        /// all public properties to their defaults
        /// </summary>
        public Subcatchment()
        {
            RainGaugeName = "";
            OutletName = "";
        }

        #endregion

        #region Inp Attributes

        /// <summary>
        /// The X Position of the subcatchment
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// The Y Position of the subcatchment
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// The name of the rain gauge that will rain
        /// on this subcatchment
        /// </summary>
        public string RainGaugeName { get; set; }

        /// <summary>
        /// The name of the outlet for this subcatchment
        /// </summary>
        public string OutletName { get; set; }

        /// <summary>
        /// The area of the subcatchment
        /// </summary>
        public double Area { get; set; }

        /// <summary>
        /// The percent that this subcatchment is impervious
        /// </summary>
        public double PercentImpervious { get; set; }

        /// <summary>
        /// The width of the flow path of the subcatchment
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// The slope of the flow path of the subcatchment
        /// </summary>
        public double Slope { get; set; }

        /// <summary>
        /// Curb length (if needed for pollutant buildup functions)
        /// </summary>
        public double CurbLength { get; set; }

        /// <summary>
        /// The name of the snow pack parameter set (for snow melt analysis)
        /// </summary>
        public string SnowPack { get; set; }

        /// <summary>
        /// Sub area data set
        /// </summary>
        public SubArea SubArea { get; set; }

        /// <summary>
        /// Infiltration options data set that is one the following classes
        /// <see cref="CurveNumberInfiltration"/>, <see cref="GreenAmptInfiltration"/>,
        /// or <see cref="HortonInfiltration"/>
        /// </summary>
        public InfiltrationData InfiltrationOptions { get; set; }

        /// <summary>
        /// Groundwater data for this subcatchment
        /// </summary>
        public Groundwater GroundwaterData { get; set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// The property mappings for the subcatchment entity
        /// </summary>
        public override Action<string>[] PropertyMappings { get; protected set; }

        /// <summary>
        /// Returns the inp tablename for this entity
        /// </summary>
        public override string InpTableName => "SUBCATCHMENTS";

        #endregion

        #region Public Methods

        /// <summary>
        /// Convert this entity to an inp string that can be placed
        /// into the subcatchmets table in an inp file
        /// </summary>
        /// <returns>Returns: an inp string</returns>
        public override string ToInpString()
        {
            // Create a new String builder that
            // will be used to append all lines of the string
            var s = new StringBuilder();

            // Build the inp string
            s.AppendLine($";;{Description}");
            s.Append(Name.PadRight(20));
            s.Append(RainGaugeName.PadRight(20));
            s.Append(OutletName.PadRight(20));
            s.Append(Area.ToString().PadRight(10));
            s.Append(PercentImpervious.ToString().PadRight(10));
            s.Append(Width.ToString().PadRight(10));
            s.Append(Slope.ToString().PadRight(10));
            s.Append(CurbLength.ToString().PadRight(10));

            // Return the string builder
            return s.ToString();
        }

        /// <summary>
        /// Set the property mappings for this class
        /// </summary>
        public override void SetPropertyMappings()
        {
            PropertyMappings = new Action<string>[]
            {
                s => Name = s,
                s => RainGaugeName = s,
                s => OutletName = s,
                s => {if (double.TryParse(s, out var area)) {Area = area;}},
                s => {if (double.TryParse(s, out var imperv)) {PercentImpervious = imperv;}},
                s => {if (double.TryParse(s, out var width)) {Width = width;}},
                s => {if (double.TryParse(s, out var slope)) {Slope = slope;}},
                s => {if (double.TryParse(s, out var curblen)) {CurbLength = curblen;}},
            };
        }

        /// <summary>
        /// Add Entity Data from an entity data type
        /// </summary>
        /// <param name="entityData"></param>
        public override void AddEntityData(InpEntityData entityData)
        {
            switch (entityData)
            {
                // SubAreas
                case SubArea subArea:
                    SubArea = subArea;
                    break;

                // Infiltration Data
                case HortonInfiltration hortonInfiltration:
                    InfiltrationOptions = hortonInfiltration;
                    break;
                case GreenAmptInfiltration greenAmptInfiltration:
                    InfiltrationOptions = greenAmptInfiltration;
                    break;
                case CurveNumberInfiltration curveNumberInfiltration:
                    InfiltrationOptions = curveNumberInfiltration;
                    break;

                // Ground water data
                case Groundwater groundwater:
                    GroundwaterData = groundwater;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// public override of <see cref="object.Equals(object)"/>
        /// that will pass this object to the <see cref="Equals(Subcatchment)"/>
        /// method to test equality
        /// </summary>
        /// <param name="obj">The object that is being compared</param>
        /// <returns>Returns: true if all public properties of this object
        /// are equal to the public properties of <paramref name="obj"/></returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Subcatchment);
        }

        /// <summary>
        /// Implementation of the <see cref="IEquatable{Subcatchment}"/>
        /// interface
        /// </summary>
        /// <param name="other">The object that will be compared</param>
        /// <returns>Returns: true if all public properties of this object are equal to the public
        /// properties of <paramref name="other"/></returns>
        public bool Equals(Subcatchment other)
        {
            return other != null &&
                              X == other.X &&
                              Y == other.Y &&
                              RainGaugeName == other.RainGaugeName &&
                              OutletName == other.OutletName &&
                              Area == other.Area &&
                              PercentImpervious == other.PercentImpervious &&
                              Width == other.Width &&
                              Slope == other.Slope &&
                              CurbLength == other.CurbLength &&
                              SnowPack == other.SnowPack &&
                              EqualityComparer<SubArea>.Default
                               .Equals(SubArea, other.SubArea) &&
                              EqualityComparer<InfiltrationData>.Default
                               .Equals(InfiltrationOptions, other.InfiltrationOptions) &&
                              EqualityComparer<Groundwater>.Default
                               .Equals(GroundwaterData, other.GroundwaterData);
        }

        /// <summary>
        /// Public override of the get hash code for this class.
        /// </summary>
        /// <returns>Returns: a hash code that combines all hashes of all public properties</returns>
        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(X);
            hash.Add(Y);
            hash.Add(RainGaugeName);
            hash.Add(OutletName);
            hash.Add(Area);
            hash.Add(PercentImpervious);
            hash.Add(Width);
            hash.Add(Slope);
            hash.Add(CurbLength);
            hash.Add(SnowPack);
            hash.Add(SubArea);
            hash.Add(InfiltrationOptions);
            hash.Add(GroundwaterData);
            return hash.ToHashCode();
        }

        #endregion
    }
}
