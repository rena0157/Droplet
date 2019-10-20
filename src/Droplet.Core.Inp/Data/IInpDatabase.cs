// IInpDatabase.cs
// Created: 2019-09-10
// By: Adam Renaud

using Droplet.Core.Inp.Entities;
using Droplet.Core.Inp.Options;
using System;
using System.Collections.Generic;

namespace Droplet.Core.Inp.Data
{
    /// <summary>
    /// Interface for an inp database object 
    /// </summary>
    public interface IInpDatabase
    {

        #region Get Methods

        /// <summary>
        /// Get an object from the database
        /// </summary>
        /// <param name="id">The id of the object</param>
        IInpDbObject GetObject(Guid id);

        /// <summary>
        /// Get all <see cref="IInpEntity"/> from the database as an <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="T">The <see cref="IInpEntity"/> type that will be returned</typeparam>
        /// <returns>Returns: An enumeration of all entities in the database</returns>
        IEnumerable<T> GetEntities<T>() where T :IInpEntity;

        /// <summary>
        /// Get an option of the type <typeparamref name="T"/> from the database
        /// Note that the <typeparamref name="T"/> must be a derived type of the
        /// <see cref="InpOption"/> class
        /// </summary>
        /// <typeparam name="T">The <see cref="InpOption"/> type that will be returned</typeparam>
        /// <returns>Returns: An option with the type <typeparamref name="T"/></returns>
        public T? GetOption<T>() where T : InpOption;

        /// <summary>
        /// Get an option of the type <paramref name="type"/> from
        /// the database. Note that if the <paramref name="type"/> 
        /// is not a derived type from the <see cref="InpOption"/> class
        /// this will throw an exception.
        /// </summary>
        /// <param name="type">The type of the option that will be returned</param>
        /// <returns>Returns: the specified option from the database</returns>
        public InpOption? GetOption(Type type);

        /// <summary>
        /// Get all entities of the type <typeparamref name="T"/>
        /// from the database.
        /// </summary>
        /// <typeparam name="T">The type must be an <see cref="IInpEntity"/> implementor</typeparam>
        /// <returns>Returns: An <see cref="IInpEntity"/> list</returns>
        IEnumerable<T> GetAllEntities<T>() where T : IInpEntity;

        /// <summary>
        /// Get all entities from the database, in the form of a stream
        /// </summary>
        /// <returns>Returns the entities from the database</returns>
        IEnumerable<IInpEntity> GetAllEntities();

        /// <summary>
        /// Get an <see cref="IInpEntity"/> from its <see cref="IInpEntity.Name"/>
        /// </summary>
        /// <typeparam name="T">The type of the entity</typeparam>
        /// <param name="name">The name of the entity</param>
        /// <returns>Returns: An entity that matches the name provided</returns>
        T? GetEntity<T>(string name) where T : class, IInpEntity;

        /// <summary>
        /// Get the strings from the database that can be written to
        /// an inp file
        /// </summary>
        /// <returns>Returns: The strings from all entities in the database</returns>
        IEnumerable<string> GetInpStrings();

        #endregion

        /// <summary>
        /// Update the database
        /// </summary>
        /// <param name="tables">The tables that make up the database</param>
        void UpdateDatabase(List<IInpTable> tables);

        /// <summary>
        /// Purge the database of any items that contains NULL as their names
        /// </summary>
        void Purge();
    }
}
