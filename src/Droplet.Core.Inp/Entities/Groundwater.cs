// InpLib
// Groundwater.cs
// 
// ============================================================
// 
// Created: 2019-08-24
// Last Updated: 2019-08-24-11:21 AM
// By: Adam Renaud
// 
// ============================================================

using System;

namespace Droplet.Core.Inp.Entities
{
    /// <summary>
    /// Entity that represents ground water properties
    /// that are tied to an <see cref="Aquifer"/>
    /// </summary>
    public class Groundwater : InpEntityData, IEquatable<Groundwater>
    {
        #region Constructors

        /// <summary>
        /// Default Constructor that initalizes this class
        /// to defaults
        /// </summary>
        public Groundwater()
        {
        }

        #endregion

        #region Inp Attributes

        /// <summary>
        /// Elevation of the ground surface
        /// </summary>
        public double SurfaceElevation { get; set; }

        /// <summary>
        /// The Groundwater Influence Multiplier
        /// </summary>
        public double InfluenceMultiplier { get; set; }

        /// <summary>
        /// The Groundwater Influence Exponent
        /// </summary>
        public double InfluenceExponent { get; set; }

        /// <summary>
        /// The tail water influence multiplier
        /// </summary>
        public double TailWaterInfluenceMultiplier { get; set; }

        /// <summary>
        /// The tail water influence exponent
        /// </summary>
        public double TailWaterInfluenceExponent { get; set; }

        /// <summary>
        /// The combined tail water and ground water exponent
        /// </summary>
        public double CombinedMultiplier { get; set; }

        /// <summary>
        /// The Depth of the surface water above the channel bottom.
        /// The value of 0 will use depth from flow routing
        /// </summary>
        public double SurfaceWaterDepth { get; set; }

        /// <summary>
        /// The Min water table elevation for flow to occur.
        /// If left blank then the value is the node's invert elevation
        /// </summary>
        public double MinWaterTableElevation { get; set; }

        /// <summary>
        /// The elevation of the bottom of the aquifer
        /// </summary>
        public double ElevationOfAquiferBottom { get; set; }

        /// <summary>
        /// The initial water table elevation
        /// </summary>
        public double InitialWaterTableElevation { get; set; }

        /// <summary>
        /// The zone of unsaturated moisture
        /// </summary>
        public double UnsaturatedZoneMoisture { get; set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Property mappings implemented from <see cref="IInptableParseable"/>
        /// </summary>
        public override Action<string>[] PropertyMappings { get; protected set; }

        /// <summary>
        /// The name of the table that this entity belongs to
        /// </summary>
        public override string InpTableName => "GROUNDWATER";

        #endregion

        #region Public Methods

        /// <summary>
        /// Set the default property mappings for this class
        /// </summary>
        public override void SetPropertyMappings()
        {
            PropertyMappings = new Action<string>[]
            {
                // Subcatchment name
                s => ReferencedEntityNames.Add(s),

                // Aquifer name
                s => ReferencedEntityNames.Add(s),

                // Referenced node name
                s => ReferencedEntityNames.Add(s),

                // Other properties
                s => {if (double.TryParse(s, out var surfaceElevation)) SurfaceElevation = surfaceElevation;},
                s => {if (double.TryParse(s, out var a1Coefficient)) InfluenceMultiplier = a1Coefficient;},
                s => {if (double.TryParse(s, out var b1C)) InfluenceExponent = b1C;},
                s => {if (double.TryParse(s, out var a2C)) TailWaterInfluenceMultiplier = a2C;},
                s => {if (double.TryParse(s, out var b2C)) TailWaterInfluenceExponent = b2C;},
                s => {if (double.TryParse(s, out var a3C)) CombinedMultiplier = a3C;},
                s => {if (double.TryParse(s, out var surfaceWaterDepth)) SurfaceWaterDepth = surfaceWaterDepth;},
            };
        }

        /// <summary>
        /// Public override of the Equals method from <see cref="object.Equals(object)"/>.
        /// This equals method will compare the public properties of this object and compare
        /// them to <paramref name="obj"/>
        /// </summary>
        /// <param name="obj">The object that this object will be compared to</param>
        /// <returns>Returns: True if all public properties of this object are equal to 
        /// <paramref name="obj"/></returns>
        public override bool Equals(object obj) => Equals(obj as Groundwater);

        /// <summary>
        /// Implementation of the <see cref="IEquatable{Groundwater}.Equals(Groundwater)"/> method
        /// that will compare this object with <paramref name="other"/>. Note that this
        /// method does include <see cref="PropertyMappings"/> for comparison purposes.
        /// </summary>
        /// <param name="other">The object that this object will be compared to</param>
        /// <returns>Returns: True if all public properties of this object equal
        /// <paramref name="other"/></returns>
        public bool Equals(Groundwater other) => other != null &&
                   SurfaceElevation == other.SurfaceElevation &&
                   InfluenceMultiplier == other.InfluenceMultiplier &&
                   InfluenceExponent == other.InfluenceExponent &&
                   TailWaterInfluenceMultiplier == other.TailWaterInfluenceMultiplier &&
                   TailWaterInfluenceExponent == other.TailWaterInfluenceExponent &&
                   CombinedMultiplier == other.CombinedMultiplier &&
                   SurfaceWaterDepth == other.SurfaceWaterDepth &&
                   MinWaterTableElevation == other.MinWaterTableElevation &&
                   ElevationOfAquiferBottom == other.ElevationOfAquiferBottom &&
                   InitialWaterTableElevation == other.InitialWaterTableElevation &&
                   UnsaturatedZoneMoisture == other.UnsaturatedZoneMoisture;

        /// <summary>
        /// Public override of the <see cref="object.GetHashCode"/> method that will generate
        /// a hash code of all the public properties of this class combined. Note that this
        /// method does not include <see cref="PropertyMappings"/> for hash code calculation purposes
        /// </summary>
        /// <returns>Returns: a combined hash code for all public properties in this type</returns>
        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(SurfaceElevation);
            hash.Add(InfluenceMultiplier);
            hash.Add(InfluenceExponent);
            hash.Add(TailWaterInfluenceMultiplier);
            hash.Add(TailWaterInfluenceExponent);
            hash.Add(CombinedMultiplier);
            hash.Add(SurfaceWaterDepth);
            hash.Add(MinWaterTableElevation);
            hash.Add(ElevationOfAquiferBottom);
            hash.Add(InitialWaterTableElevation);
            hash.Add(UnsaturatedZoneMoisture);
            return hash.ToHashCode();
        }

        #endregion
    }
}
