// InpLib
// CurveNumberInfiltration.cs
// 
// ============================================================
// 
// Created: 2019-08-13
// Last Updated: 2019-08-13-06:27 PM
// By: Adam Renaud
// 
// ============================================================

using System;
using Droplet.Core.Inp.Parsers;

namespace Droplet.Core.Inp.Entities
{
    /// <summary>
    /// Infiltration options for SCS curve numbers
    /// </summary>
    public class CurveNumberInfiltration : InfiltrationData, IEquatable<CurveNumberInfiltration>
    {
        #region Constructors

        /// <summary>
        /// Default Constructor that initializes the data of this type
        /// </summary>
        public CurveNumberInfiltration()
        {
            CurveNumber = 0;
            DryingTime = new TimeSpan();
        }

        #endregion

        #region Inp Attributes

        /// <summary>
        /// The SCS runoff curve number
        /// </summary>
        public double CurveNumber { get; set; }

        /// <summary>
        /// Time for fully saturated soil to completely dry out
        /// </summary>
        public TimeSpan DryingTime { get; set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// The Property Mappings for this class from inpfiles
        /// </summary>
        public override Action<string>[] PropertyMappings { get; protected set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Set the Property mappings for this class
        /// </summary>
        public override void SetPropertyMappings()
        {
            PropertyMappings =  new Action<string>[]
            {
                s => ReferencedEntityNames.Add(s),
                s => {if (double.TryParse(s, out var curveNum)) {CurveNumber = curveNum;}},
                s => {}, // note that data[2] is ignored because its use is deprecated
                s => {if (double.TryParse(s, out var dryingTime)) {DryingTime = TimeSpan.FromDays(dryingTime);}},
            };
        }

        /// <summary>
        /// Build from table override from the <see cref="IInpTableParseable"/> interface.
        /// </summary>
        /// <param name="data">The data that is from the inp table</param>
        public override void BuildFromTable(string[] data)
        {
            if (data.Length < 4)
                throw new ArgumentOutOfRangeException();

            ReferencedEntityNames.Add(data[0]);
            if (double.TryParse(data[1], out var curveNumber)) CurveNumber = curveNumber;

            // Note that data[2] is ignored here because its use is deprecated
            if (double.TryParse(data[3], out var dryingTime))
                DryingTime = TimeSpan.FromDays(dryingTime);

        }

        /// <summary>
        /// Override of the equals class for this type. This method
        /// will return true if all public properties are equal
        /// </summary>
        /// <param name="obj">The object that this type will be compared to</param>
        /// <returns>Returns: True if all public properties are equal</returns>
        public override bool Equals(object obj)
        {
            // If the types match are all properties are the same
            // then return true
            if (obj != null && obj is CurveNumberInfiltration infiltration)
                return infiltration.CurveNumber == CurveNumber
                    && infiltration.DryingTime == DryingTime;

            // Else return false
            return false;
        }

        /// <summary>
        /// The implementation of the <see cref="IEquatable{CurveNumberInfiltration}"/>
        /// interface.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(CurveNumberInfiltration other) 
                   => other != null &&
                   CurveNumber == other.CurveNumber &&
                   DryingTime.Equals(other.DryingTime);

        /// <summary>
        /// Returns the Hash code for this type
        /// </summary>
        /// <returns>Returns: the combined hash code for the public properties of this type</returns>
        public override int GetHashCode() => HashCode.Combine(CurveNumber, DryingTime);

        #endregion
    }
}
