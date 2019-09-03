// InpLib
// InpEntityData.cs
// 
// ============================================================
// 
// Created: 2019-08-12
// Last Updated: 2019-08-12-06:56 PM
// By: Adam Renaud
// 
// ============================================================

using System;
using System.Collections.Generic;
using Droplet.Core.Inp.Parsers;

namespace Droplet.Core.Inp.Entities
{
    /// <summary>
    /// A type that is not an entity in of itself but holds extra entity data
    /// </summary>
    public abstract class InpEntityData : IInpTableParseable
    {
        #region Constructors

        /// <summary>
        /// Default Constructor that initializes the class
        /// </summary>
        public InpEntityData()
        {
            ReferencedEntityNames = new List<string>();
            SetPropertyMappings();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The referenced Entity's Name
        /// </summary>
        public List<string> ReferencedEntityNames { get; set; }

        /// <summary>
        /// Property mappings for the <see cref="InpEntityData"/> class
        /// </summary>
        public abstract Action<string>[] PropertyMappings { get; protected set;}

        /// <summary>
        /// The name of the table that this entity data belongs to
        /// </summary>
        public abstract string InpTableName { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// An InpEntityData type is built from an inp table
        /// </summary>
        /// <param name="data">The data that is passed from the table</param>
        public virtual void BuildFromTable(string[] data)
        {
            // Iterate through the data array and the property mappings array,
            // and invoke the actions in the property mappings array
            for (var i = 0; i < data.Length && i < PropertyMappings.Length; i++)
                PropertyMappings[i](data[i]);
        }

        /// <summary>
        /// Set the property mappings from an array of mappings
        /// </summary>
        /// <param name="mappings">That mappings that will be set</param>
        public void SetPropertyMappings(Action<string>[] mappings)
        {
            PropertyMappings = mappings;
        }

        /// <summary>
        /// Abstract class for setting property mappings
        /// that must be handeled in derived classes
        /// </summary>
        public abstract void SetPropertyMappings();

        #endregion
    }
}
