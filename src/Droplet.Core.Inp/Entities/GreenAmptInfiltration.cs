// InpLib
// GreenAmptInfiltration.cs
// 
// ============================================================
// 
// Created: 2019-08-13
// Last Updated: 2019-08-13-06:20 PM
// By: Adam Renaud
// 
// ============================================================

using System;

namespace Droplet.Core.Inp.Entities
{
    /// <summary>
    /// Class that holds data for the Green Ampt Infiltration method
    /// </summary>
    public class GreenAmptInfiltration : InfiltrationData, IEquatable<GreenAmptInfiltration>
    {
        #region Constructors

        /// <summary>
        /// Default Constructor that initializes all data objects to defaults
        /// </summary>
        public GreenAmptInfiltration()
        {
            SuctionHead = 0;
            HydraulicConductivity = 0;
            InternalDeficit = 0;
        }

        #endregion

        #region Inp Attributes

        /// <summary>
        /// Soil Capillary action suction head (in or mm)
        /// </summary>
        public double SuctionHead { get; set; }

        /// <summary>
        /// The hydraulic conductivity of the soil
        /// in (in/hr or mm/hr)
        /// </summary>
        public double HydraulicConductivity { get; set; }

        /// <summary>
        /// The difference between soil porosity and initial
        /// moisture content (a fraction)
        /// </summary>
        public double InternalDeficit { get; set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Inp property mappings for this class
        /// </summary>
        public override Action<string>[] PropertyMappings { get; protected set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Set the property mappings for this class
        /// </summary>
        public override void SetPropertyMappings()
        {
            PropertyMappings = new Action<string>[]
            {
                s => ReferencedEntityNames.Add(s),
                s => {if (double.TryParse(s, out var suction)) SuctionHead = suction;},
                s => {if (double.TryParse(s, out var kSat)) HydraulicConductivity = kSat;},
                s => {if (double.TryParse(s, out var imd)) InternalDeficit = imd;}
            };
        }

        /// <summary>
        /// Base Equals override that passes to the <see cref="GreenAmptInfiltration.Equals(GreenAmptInfiltration)"/>
        /// which is in implemented from the <see cref="IEquatable{GreenAmptInfiltration}"/> interface
        /// </summary>
        /// <param name="obj">The object that is being compared</param>
        /// <returns>Returns: True if all public properties of this class match that of the object passed</returns>
        public override bool Equals(object obj)
            => Equals(obj as GreenAmptInfiltration);

        /// <summary>
        /// The Equals method that is implemented from the <see cref="IEquatable{GreenAmptInfiltration}"/> interface.
        /// </summary>
        /// <param name="other">The other <see cref="GreenAmptInfiltration"/> object that is being compared</param>
        /// <returns>Returns: True if all public properties match those of <paramref name="other"/></returns>
        public bool Equals(GreenAmptInfiltration other)
            => other != null && SuctionHead == other.SuctionHead &&
               HydraulicConductivity == other.HydraulicConductivity &&
               InternalDeficit == other.InternalDeficit;

        /// <summary>
        /// Base override of the <see cref="object.GetHashCode"/> method that returns the combined hash code
        /// of all of the public properties of this object
        /// </summary>
        /// <returns>Returns: The combined hash code of all the public properties of this object</returns>
        public override int GetHashCode()
            => HashCode.Combine(SuctionHead, HydraulicConductivity, InternalDeficit);

        #endregion
    }
}
