// InpLib
// HortonInfiltration.cs
// 
// ============================================================
// 
// Created: 2019-08-12
// Last Updated: 2019-08-12-07:48 PM
// By: Adam Renaud
// 
// ============================================================

using System;

namespace Droplet.Core.Inp.Entities
{
    /// <summary>
    /// Infiltration Entity Data for Subcatchments
    /// </summary>
    public class HortonInfiltration : InfiltrationData, IEquatable<HortonInfiltration>
    {
        #region Constructors

        /// <summary>
        /// Default Constructor for this class that default all public properties
        /// </summary>
        public HortonInfiltration()
        {
            MaxRate = 0;
            MinRate = 0;
            Decay = 0;
            DryTime = new TimeSpan();
            MaxInfiltrationVolume = 0;
        }

        #endregion

        #region Inp Attributes

        /// <summary>
        /// Max rate on the Horton Infiltration Curve (in/hr or mm/hr)
        /// </summary>
        public double MaxRate { get; set; }

        /// <summary>
        /// Min rate on the Horton Infiltration Curve (in/hr or mm/hr)
        /// </summary>
        public double MinRate { get; set; }

        /// <summary>
        /// The decay constant for the Horton Infiltration
        /// Curve (1/hr)
        /// </summary>
        public double Decay { get; set; }

        /// <summary>
        /// The Time for fully saturated soil to completely dry (Days)
        /// </summary>
        public TimeSpan DryTime { get; set; }

        /// <summary>
        /// The Maximum volume possible (inches or mm)
        /// </summary>
        public double MaxInfiltrationVolume { get; set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Property Mappings Array for reading inp files
        /// </summary>
        public override Action<string>[] PropertyMappings { get; protected set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Set the default property mappings for this class
        /// </summary>
        public override void SetPropertyMappings()
        {
            PropertyMappings = new Action<string>[]
            {
                s => ReferencedEntityNames.Add(s),
                s => {if (double.TryParse(s, out var maxRate)) MaxRate = maxRate;},
                s => {if (double.TryParse(s, out var minRate)) MinRate = minRate;},
                s => {if (double.TryParse(s, out var decay)) Decay = decay;},
                s => {if (double.TryParse(s, out var dryTime)) DryTime = TimeSpan.FromDays(dryTime);},
                s => {if (double.TryParse(s, out var maxVolume)) MaxInfiltrationVolume = maxVolume;}
            };
        }

        /// <summary>
        /// Base override of the <see cref="object.Equals(object)"/> method that passed the object to
        /// <see cref="Equals(HortonInfiltration)"/> method.
        /// </summary>
        /// <param name="obj">The object that will be compared</param>
        /// <returns>Returns: true if all public properties of this class are equal to the public properties of
        /// <paramref name="obj"/></returns>
        public override bool Equals(object obj) => Equals(obj as HortonInfiltration);

        /// <summary>
        /// Implementation of the Equals method from <see cref="IEquatable{HortonInfiltration}"/> interface
        /// </summary>
        /// <param name="other">The object that this object will be compared to</param>
        /// <returns>Returns: True if all public properties of this object match that of <paramref name="other"/></returns>
        public bool Equals(HortonInfiltration other)
                => other != null &&
                   MaxRate == other.MaxRate &&
                   MinRate == other.MinRate &&
                   Decay == other.Decay &&
                   DryTime.Equals(other.DryTime) &&
                   MaxInfiltrationVolume == other.MaxInfiltrationVolume;

        /// <summary>
        /// Generates a combined hash code from the public properties of this class
        /// </summary>
        /// <returns>Returns: A combined hash code for the public properties of this class</returns>
        public override int GetHashCode()
            => HashCode.Combine(MaxRate, MinRate, Decay, DryTime, MaxInfiltrationVolume);

        #endregion
    }
}
