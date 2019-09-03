// InpLib
// InpEntity.cs
// 
// ============================================================
// 
// Created: 2019-08-11
// Last Updated: 2019-08-11-01:04 PM
// By: Adam Renaud
// 
// ============================================================

using System;
using Droplet.Core.Inp.Parsers;

namespace Droplet.Core.Inp.Entities
{
    /// <summary>
    /// Abstract class that defines an InpEntity
    /// </summary>
    public abstract class InpEntity : IInpTableParseable
    {
        #region Constructors

        /// <summary>
        /// Default Constructor that will initialize the
        /// InpEntity
        /// </summary>
        public InpEntity()
        {
            SetPropertyMappings();
            Name = "";
            Description = "";
            Tag = "";
        }

        #endregion

        #region Inp Attributes

        /// <summary>
        /// The name/ID of the entity
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Description that was given to the entity
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The Tag of the entity
        /// </summary>
        public string Tag { get; set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// The property mappings for inp entities
        /// </summary>
        public abstract Action<string>[] PropertyMappings { get; protected set; }

        /// <summary>
        /// The name of the table that this entity belongs to
        /// </summary>
        public abstract string InpTableName { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Build this entity from an Inp Table data string
        /// </summary>
        /// <param name="data">The data string</param>
        public virtual void BuildFromTable(string[] data)
        {
            for (var i = 0; i < data.Length && i < PropertyMappings.Length; i++)
                PropertyMappings[i](data[i]);
        }

        /// <summary>
        /// Add Entity Data
        /// </summary>
        /// <param name="entityData">The entity data that will be added</param>
        public abstract void AddEntityData(InpEntityData entityData);

        /// <summary>
        /// Setting the property mappings from a passed in mappings array
        /// </summary>
        /// <param name="mappings">The array that will be set</param>
        public void SetPropertyMappings(Action<string>[] mappings) => PropertyMappings = mappings;

        /// <summary>
        /// Abstract SetProperty mappings method
        /// </summary>
        public abstract void SetPropertyMappings();

        /// <summary>
        /// Write this entity to an inp string. That is formatted
        /// to be added to an inp table
        /// </summary>
        /// <returns>Returns: A formatted InpString</returns>
        public abstract string ToInpString();

        #endregion
    }
}
