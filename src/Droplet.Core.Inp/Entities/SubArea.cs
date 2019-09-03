// InpLib
// SubArea.cs
// 
// ============================================================
// 
// Created: 2019-08-11
// Last Updated: 2019-08-11-08:52 PM
// By: Adam Renaud
// 
// ============================================================

using System;
using Droplet.Core.Inp.Parsers;

namespace Droplet.Core.Inp.Entities
{
    /// <summary>
    /// The subarea entity data object.
    /// </summary>
    public class SubArea : InpEntityData
    {
        #region Constructors

        public SubArea()
        {
        }

        #endregion

        #region Inp Attributes

        /// <summary>
        /// Manning's N for impervious areas
        /// </summary>
        public double ManningNImpervious { get; set; }

        /// <summary>
        /// Manning's N for pervious areas
        /// </summary>
        public double ManningNPervious { get; set; }

        /// <summary>
        /// Slope of impervious areas
        /// </summary>
        public double SlopeOfImpervious { get; set; }

        /// <summary>
        /// Slope of pervious areas
        /// </summary>
        public double SlopeOfPervious { get; set; }

        /// <summary>
        /// Percent of impervious area with no depression storage
        /// </summary>
        public double PercentZero { get; set; }

        // TODO: Add an enum for this item
        public string RouteTo { get; set; }

        /// <summary>
        /// The percent of this subarea is routed to the routing option
        /// </summary>
        public double PercentRouted { get; set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Property Mappings for inp data to this class
        /// </summary>
        public override Action<string>[] PropertyMappings { get; protected set; }

        /// <summary>
        /// The name of the table that this entity data belongs to
        /// </summary>
        public override string InpTableName => "SUBAREAS";

        #endregion

        #region Public Methods

        /// <summary>
        /// Set the default Property Mappings for this class
        /// </summary>
        public override void SetPropertyMappings()
        {
            // The Default Property mappings
            PropertyMappings = new Action<string>[]
            {
                s => ReferencedEntityNames.Add(s),
                s => {if (double.TryParse(s, out var nImperv)) ManningNImpervious = nImperv;},
                s => {if (double.TryParse(s, out var nPerv)) ManningNPervious = nPerv;},
                s => {if (double.TryParse(s, out var sImperv)) SlopeOfImpervious = sImperv;},
                s => {if (double.TryParse(s, out var sPerv)) SlopeOfPervious = sPerv;},
                s => {if (double.TryParse(s, out var pctZero)) PercentZero = pctZero;},
                s => RouteTo = s,
                s => {if (double.TryParse(s, out var pctRouted)) PercentRouted = pctRouted;}
            };
        }

        /// <summary>
        /// Public override of the Equals Method that compares
        /// an object to this subarea object.
        /// If the obj is not the same type as this obj this will return false.
        /// Otherwise it will compare the two objects and will return true if all public properties
        /// are equal.
        /// </summary>
        /// <param name="obj">The object that we are comparing this object to</param>
        /// <returns>Returns: True if all properties of this object are the same as
        /// the one that is passed to this method. Otherwise false</returns>
        public override bool Equals(object obj)
        {
            // Check to see if all properties match eachother
            if (obj is SubArea subarea)
                return subarea.ManningNImpervious == ManningNImpervious &&
                       subarea.ManningNPervious == ManningNPervious &&
                       subarea.PercentRouted == PercentRouted &&
                       subarea.PercentZero == PercentZero &&
                       subarea.RouteTo == RouteTo &&
                       subarea.SlopeOfImpervious == SlopeOfImpervious &&
                       subarea.SlopeOfPervious == SlopeOfPervious;
            
            // if the obj is not a subarea then return false
            return false;
        }

        /// <summary>
        /// Public override of the <see cref="object.GetHashCode"/> method
        /// that combines the hash codes of all of the public properties of this class.
        /// </summary>
        /// <returns>Returns: A hash code</returns>
        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(ManningNImpervious);
            hash.Add(ManningNPervious);
            hash.Add(PercentRouted);
            hash.Add(PercentZero);
            hash.Add(RouteTo);
            hash.Add(SlopeOfImpervious);
            hash.Add(SlopeOfPervious);

            return hash.ToHashCode();
        }

        /// <summary>
        /// The To String Method for this entity
        /// </summary>
        /// <returns>Returns: a string that represents this entity</returns>
        public override string ToString()
        {
            return base.ToString();
        }

        #endregion
    }
}
