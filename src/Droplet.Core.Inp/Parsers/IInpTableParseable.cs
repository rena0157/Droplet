// InpLib
// IInpTableParseable.cs
// 
// ============================================================
// 
// Created: 2019-08-11
// Last Updated: 2019-08-11-08:48 PM
// By: Adam Renaud
// 
// ============================================================

using System;

namespace Droplet.Core.Inp.Parsers
{
    /// <summary>
    /// Interface that states that an entity can be built from a table
    /// </summary>
    public interface IInpTableParseable
    {
        /// <summary>
        /// Build the data from a row from an inp table
        /// </summary>
        /// <param name="data">The data</param>
        void BuildFromTable(string[] data);

        /// <summary>
        /// Set the property mappings from a passed array of mappings
        /// </summary>
        /// <param name="mappings">The mappings that are passed</param>
        void SetPropertyMappings(Action<string>[] mappings);

        /// <summary>
        /// Set property mappings
        /// </summary>
        void SetPropertyMappings();

        /// <summary>
        /// Property Mappings for an object that implements
        /// this interface. This maps the data from <see cref="BuildFromTable(string[])"/>
        /// with the properties of the class
        /// </summary>
        Action<string>[] PropertyMappings { get;}

        /// <summary>
        /// The name of the table that this entity belongs to
        /// </summary>
        string InpTableName { get; }
    }
}
