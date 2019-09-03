// InpLib
// ======================================
// Outfall.cs
// By: Adam Renaud
// Created: 2019-09-02
// ======================================

using System;

namespace Droplet.Core.Inp.Entities
{
    /// <summary>
    /// The outfall entity
    /// </summary>
    public class Outfall : InpEntity, IInpNode
    {
        #region Constructors

        /// <summary>
        /// Default Constructor for the Outfall class
        /// </summary>
        public Outfall()
        {
        }

        #endregion

        #region Inp Attributes

        /// <summary>
        /// The x-coordinate of the <see cref="Outfall"/>
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// The y-coordinate of the <see cref="Outfall"/>
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// External infows that this outfall is expected to
        /// recieve. 
        /// </summary>
        public string InflowOptions { get; set; }

        /// <summary>
        /// Pollutant removal that is suppiled by
        /// this outfall
        /// </summary>
        public string TreatmentOptions { get; set;}

        /// <summary>
        /// The invert elevation of this outfall. "Elevation" in inp files
        /// </summary>
        public double InvertElevation { get; set; }

        /// <summary>
        /// True if this outfall contains a tidal gate to 
        /// prevent backflow. "Gated" in inp files
        /// </summary>
        public bool TideGate { get; set; }

        /// <summary>
        /// The subcatchment that this outfall is routed to. "Routed To" in inp files
        /// </summary>
        public string SubcatchmentNameRoutedTo { get; set; }

        /// <summary>
        /// The outfall boundary conditions. "Type" in inp files
        /// </summary>
        public OutfallBoundaryConditions BoundaryCondition { get; set; }

        /// <summary>
        /// Water elevation for a <see cref="OutfallBoundaryConditions.Fixed"/> boundary
        /// condition. "Stage Data" in inp files
        /// </summary>
        public double WaterElevationFixed { get; set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Property mappings for this class and inp files
        /// </summary>
        public override Action<string>[] PropertyMappings { get; protected set; }

        /// <summary>
        /// The Name of the table that this entity belongs to
        /// </summary>
        public override string InpTableName => "OUTFALLS";

        #endregion

        #region Public Methods

        /// <summary>
        /// Write this entity to a formatted Inp String
        /// </summary>
        /// <returns>Returns: A formatted Inp String</returns>
        public override string ToInpString()
        {
            // TODO: Finish this method
            throw new NotImplementedException();
        }

        /// <summary>
        /// Override of the <see cref="InpEntity.AddEntityData(InpEntityData)"/>
        /// which adds <see cref="InpEntityData"/> data to this class if applicable
        /// </summary>
        /// <param name="entityData">The entity data that will be added to this class</param>
        public override void AddEntityData(InpEntityData entityData)
        {
            // TODO: Finish this method
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the default <see cref="PropertyMappings"/> for this class
        /// </summary>
        public override void SetPropertyMappings()
        {
            PropertyMappings = new Action<string>[]
            {
                s => Name = s,
            };
        }

        #endregion
    }
}
