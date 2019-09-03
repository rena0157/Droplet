// InpLib
// Groundwater.cs
// 
// ============================================================
// 
// Created: 2019-08-19
// By: Adam Renaud
// 
// ============================================================

using System;
using System.Text;
using Droplet.Core.Inp.Parsers;

namespace Droplet.Core.Inp.Entities
{
    /// <summary>
    /// Class that represents an inp aquifer
    /// </summary>
    public class Aquifer : InpEntity, IEquatable<Aquifer>
    {

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Aquifer()
        {
        }

        #endregion

        #region Inp Attributes

        /// <summary>
        /// The porosity (volume of the void / total volume of soil)
        /// of the soil of the aquifer. "Por" in inp files
        /// </summary>
        public double Porosity { get; set; }

        /// <summary>
        /// The residual moisture content of completely dry soil.
        /// "WP" in inp files
        /// </summary>
        public double WiltingPoint { get; set; }

        /// <summary>
        /// The soils moisture content after all of the free water
        /// has been drained off. "FC" in inp files
        /// </summary>
        public double FieldCapacity { get; set; }

        /// <summary>
        /// The soil's saturated hydraulic conductivity. ksat 
        /// in inp files
        /// </summary>
        /// <remarks>
        /// Unit: in/hr (US) or mm/hr (SI)
        /// </remarks>
        public double Conductivity { get; set; }

        /// <summary>
        /// The slope of the function log(conductivity) versus
        /// the soil moisture deficit curve. "Kslope" in inp files
        /// </summary>
        public double ConductivitySlope { get; set; }

        /// <summary>
        /// The slope of the function: soil tension versus 
        /// soil moisture content curve
        /// </summary>
        public double TensionSlope { get; set; }

        /// <summary>
        /// Fraction of total evaporation available for upper
        /// unsaturated zone. "ETu" in inp files
        /// </summary>
        public double UpperEvaportationFraction { get; set; }

        /// <summary>
        /// Depth into saturated zone over which evaporation
        /// can occur. "ETs" in inp files
        /// </summary>
        /// <remarks>
        /// Unit: ft (US) or m (SI)
        /// </remarks>
        public double LowerEvaporationDepth { get; set; }

        /// <summary>
        /// Rate of seepage to deep ground water when the
        /// <see cref="Aquifer"/> is completely saturated.
        /// "Seep" in inp files
        /// </summary>
        /// <remarks>
        /// Unit: in/hr (US) or mm/hr (SI)
        /// </remarks>
        public double LowerGroundWaterLossRate { get; set; }

        /// <summary>
        /// Elevation of the bottom of the aquifer. "Ebot" in
        /// inp files
        /// </summary>
        /// <remarks>
        /// Unit: ft (US) or m (SI)
        /// </remarks>
        public double BottomElevation { get; set; }

        /// <summary>
        /// The initial Elevation of the water table. "Egw" in
        /// inp files
        /// </summary>
        public double WaterTableElevation { get; set; }

        /// <summary>
        /// Initial Moisture Content of the unsaturated upper
        /// zone (fraction), "Umc" in inp files.
        /// </summary>
        /// <value></value>
        public double UnsaturatedZoneMoisture { get; set; }

        // TODO: Implement this optional Parameter
        /// <summary>
        /// (OPTIONAL PARAMETER) that is a montly pattern
        /// of adjustments to upper evaporation fraction
        /// </summary>
        public string UpperEvaporationPattern { get; set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Property mappings
        /// </summary>
        public override Action<string>[] PropertyMappings { get; protected set; }

        /// <summary>
        /// The name of the table that this entity belongs to
        /// </summary>
        public override string InpTableName => "AQUIFERS";

        #endregion

        #region Public Methods

        /// <summary>
        /// Public override of the <see cref="InpEntity.ToInpString"/> method
        /// that converts this object to an inp string that can be appened to
        /// the <see cref="Aquifer"/> table.
        /// </summary>
        /// <returns>Returns: a string formatted with all of the public properties of this
        /// object with space padding them appart as per the inp formatting.</returns>
        public override string ToInpString()
        {
            // The string builder that will be used
            // to build the return string
            var s = new StringBuilder();

            // Default Padding for this class
            const int propertyPadding = 10;
            const int namePadding = 20;

            // Add all of the entities to the string and all padding to their
            // rights.
            s.Append(Name.PadRight(namePadding));
            s.Append(Porosity.ToString().PadRight(propertyPadding));
            s.Append(WiltingPoint.ToString().PadRight(propertyPadding));
            s.Append(FieldCapacity.ToString().PadRight(propertyPadding));
            s.Append(Conductivity.ToString().PadRight(propertyPadding));
            s.Append(ConductivitySlope.ToString().PadRight(propertyPadding));
            s.Append(TensionSlope.ToString().PadRight(propertyPadding));
            s.Append(UpperEvaportationFraction.ToString().PadRight(propertyPadding));
            s.Append(LowerEvaporationDepth.ToString().PadRight(propertyPadding));
            s.Append(LowerGroundWaterLossRate.ToString().PadRight(propertyPadding));
            s.Append(BottomElevation.ToString().PadRight(propertyPadding));
            s.Append(WaterTableElevation.ToString().PadRight(propertyPadding));
            s.Append(UnsaturatedZoneMoisture.ToString().PadRight(propertyPadding));

            // Return the string builder and convert it back to a string
            return s.ToString();
        }

        /// <summary>
        /// Override of the <see cref="IInpTableParseable.SetPropertyMappings"/> Method
        /// that sets the mappings for <see cref="InpEntity"/>s
        /// </summary>
        public override void SetPropertyMappings()
        {
            PropertyMappings = new Action<string>[]
            {
                s => Name = s,
                s => {if (double.TryParse(s, out var porosity)) { Porosity = porosity; } },
                s => {if (double.TryParse(s, out var wp)) { WiltingPoint = wp; } },
                s => {if (double.TryParse(s, out var fc)) { FieldCapacity = fc; } },
                s => {if (double.TryParse(s, out var kSat)) { Conductivity = kSat; } },
                s => {if (double.TryParse(s, out var kSlope)) { ConductivitySlope = kSlope; } },
                s => {if (double.TryParse(s, out var tSlope)) { TensionSlope = tSlope; } },
                s => {if (double.TryParse(s, out var eTu)) { UpperEvaportationFraction = eTu; } },
                s => {if (double.TryParse(s, out var eTs)) { LowerEvaporationDepth = eTs; } },
                s => {if (double.TryParse(s, out var seep)) { LowerGroundWaterLossRate = seep; } },
                s => {if (double.TryParse(s, out var eBot)) { BottomElevation = eBot; } },
                s => {if (double.TryParse(s, out var eGw)) { WaterTableElevation = eGw; } },
                s => {if (double.TryParse(s, out var umc)) { UnsaturatedZoneMoisture = umc; } }
            };
        }

        /// <summary>
        /// Adds Entity Data to this entity
        /// </summary>
        /// <param name="entityData"></param>
        public override void AddEntityData(InpEntityData entityData)
        {
        }

        /// <summary>
        /// Public override of the <see cref="object.Equals(object)"/> method
        /// that passes <paramref name="obj"/> to the implemented <see cref="IEquatable{Aquifer}"/>
        /// method that compares the object with this object.
        /// </summary>
        /// <param name="obj">The object that this object will be compared to</param>
        /// <returns>Returns: true if <paramref name="obj"/> has equal public properties to 
        /// this object</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Aquifer);
        }

        /// <summary>
        /// Implementation of the <see cref="IEquatable{Aquifer}"/> interface
        /// that tests if this object is equal to <paramref name="other"/> (The object that is passed to this function)
        /// </summary>
        /// <param name="other">The object that this object will be compared to</param>
        /// <returns>Returns: true if this object has equal public properties to <paramref name="other"/></returns>
        public bool Equals(Aquifer other)
        {
            return other != null &&
                    Porosity == other.Porosity &&
                    WiltingPoint == other.WiltingPoint &&
                    FieldCapacity == other.FieldCapacity &&
                    Conductivity == other.Conductivity &&
                    ConductivitySlope == other.ConductivitySlope &&
                    TensionSlope == other.TensionSlope &&
                    UpperEvaportationFraction == other.UpperEvaportationFraction &&
                    LowerEvaporationDepth == other.LowerEvaporationDepth &&
                    LowerGroundWaterLossRate == other.LowerGroundWaterLossRate &&
                    BottomElevation == other.BottomElevation &&
                    WaterTableElevation == other.WaterTableElevation &&
                    UnsaturatedZoneMoisture == other.UnsaturatedZoneMoisture &&
                    UpperEvaporationPattern == other.UpperEvaporationPattern;
        }

        /// <summary>
        /// Public override of the <see cref="object.GetHashCode"/> method
        /// that returns a combined hash code for all properties of this type
        /// </summary>
        /// <returns>Returns: a combined hash code for all properties in the object</returns>
        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Porosity);
            hash.Add(WiltingPoint);
            hash.Add(FieldCapacity);
            hash.Add(Conductivity);
            hash.Add(ConductivitySlope);
            hash.Add(TensionSlope);
            hash.Add(UpperEvaportationFraction);
            hash.Add(LowerEvaporationDepth);
            hash.Add(LowerGroundWaterLossRate);
            hash.Add(BottomElevation);
            hash.Add(WaterTableElevation);
            hash.Add(UnsaturatedZoneMoisture);
            hash.Add(UpperEvaporationPattern);
            return hash.ToHashCode();
        }

        #endregion

    }
}
