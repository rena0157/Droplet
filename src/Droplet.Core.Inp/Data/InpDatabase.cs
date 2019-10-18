// InpDatabase.cs
// Created: 2019-09-10
// By: Adam Renaud

using Droplet.Core.Inp.Entities;
using Droplet.Core.Inp.Exceptions;
using Droplet.Core.Inp.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Droplet.Core.Inp.Data
{
    /// <summary>
    /// A database that holds the entire context of
    /// and inp file. This includes entities, options and
    /// geometry.
    /// </summary>
    public class InpDatabase : IInpDatabase
    {
        #region Private Members

        /// <summary>
        /// The database backing store, that holds objects in a dictionary
        /// who's key is a <see cref="Guid"/> that is created at the objects creation
        /// </summary>
        private Dictionary<Guid, IInpDbObject> _objectDictionary;

        /// <summary>
        /// The tables that are created from an inp file
        /// </summary>
        private List<IInpTable> _inpTables { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor that initializes the backing store
        /// for the database.
        /// </summary>
        public InpDatabase()
        {
            _inpTables = new List<IInpTable>();

            // Initialize the backing store for the database
            _objectDictionary = new Dictionary<Guid, IInpDbObject>();
        }

        /// <summary>
        /// Constructor that builds the database from the tables
        /// supplied from an inp file.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Throws if <paramref name="tables"/> is <see cref="null"/>
        /// </exception>
        /// <param name="tables">The tables that will be used to build the database</param>
        public InpDatabase(List<IInpTable> tables) : this()
        {
            // If null throw exception
            if (tables == null)
                throw new ArgumentNullException(nameof(tables));

            // Set the tables provided
            _inpTables = tables;

            // Update the database from the tables provided
            UpdateDatabase(tables);
        }

        #endregion

        #region Get Methods

        /// <summary>
        /// Get an object from the database. Note that if the object is not in
        /// the dictionary this will throw an exception.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the key is not
        /// a part of the dictionary</exception>
        /// <param name="id">The <see cref="IInpDbObject.ID"/> of the object that will be returned</param>
        /// <returns>Returns: An object in the database whose ID matches the one provided</returns>
        public IInpDbObject GetObject(Guid id)
        {
            // TODO: Add a way for the user to check if something is in the dictionary
            // If the object is not in the database throw an exception
            if (!_objectDictionary.ContainsKey(id))
                throw new ArgumentOutOfRangeException($"The object with id {id} could not be found");

            // Otherwise return the object
            return _objectDictionary[id];
        }

        /// <summary>
        /// Return an option from the database given the <see cref="InpOption"/> derived
        /// type. Note that if there are no objects that match the type of <typeparamref name="T"/>
        /// this method will return <see cref="null"/>.
        /// </summary>
        /// <typeparam name="T">The type of the option that will be returned</typeparam>
        /// <returns>Returns: An option from the database whose type matches <typeparamref name="T"/></returns>
        public T? GetOption<T>() where T: InpOption
        {
            return _objectDictionary.Values.FirstOrDefault(o => o is T) as T;
        }

        /// <summary cref="IInpDatabase.GetOption(Type)">
        /// </summary>
        /// <exception cref="NullReferenceException">
        /// Will throw if <paramref name="type"/> is <see cref="null"/>
        /// </exception>
        public InpOption? GetOption(Type type)
        {
            // If the type is null throw an exception
            if (type == null)
                throw new NullReferenceException();

            // TODO: Find a way to throw an exception if the type is not an inheritor of InpOption

            // Returns the first type that matches
            return _objectDictionary.Values.FirstOrDefault(o => o.GetType() == type) as InpOption;
        }

        /// <summary>
        /// Get all entities of the type <typeparamref name="T"/>
        /// from the database.
        /// </summary>
        /// <typeparam name="T">The type must be an <see cref="IInpEntity"/> implementer</typeparam>
        /// <returns>Returns: An <see cref="IEnumerable{IInpEntity}"/> list</returns>
        public IEnumerable<T> GetAllEntities<T>() where T : IInpEntity
        {
            // For each entity in the database, if the entity
            // matches the type that is passed then convert it and
            // return it
            foreach(var e in _objectDictionary.Values)
            {
                if (e is T et)
                    yield return et;
            }
        }

        /// <summary>
        /// Returns all of the entities from the database
        /// </summary>
        /// <returns>Returns: All entities from the database</returns>
        public IEnumerable<IInpEntity> GetAllEntities()
        {
            foreach(var entity in _objectDictionary.Values)
                if (entity is IInpEntity e)
                    yield return e;
        }

        public IEnumerable<string> GetInpStrings()
        {
            foreach(var s in GetTitleStrings())
                yield return s;

            foreach (var s in GetOptionStrings())
                yield return s;
        }

        #endregion

        #region Private Helper Methods

        private IEnumerable<string> GetTitleStrings()
        {
            yield return $"[TITLE]{Environment.NewLine};;Project Title/Notes";
        }

        private IEnumerable<string> GetOptionStrings()
        {
            yield return $"[OPTIONS]{Environment.NewLine};;Option             Value";

            foreach(var entity in GetAllEntities<InpOption>())
                yield return entity.ToInpString();
        }

        #endregion

        #region Update Methods

        /// <summary>
        /// Update the database from the supplied tables. This method
        /// will effectively rebuild the database from the tables.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Throws if <paramref name="tables"/> is null
        /// </exception>
        /// <param name="tables">The tables that the database will be updated from</param>
        public void UpdateDatabase(List<IInpTable> tables)
        {
            // If null throw exception
            if (tables == null)
                throw new ArgumentNullException(nameof(tables));

            // Iterate through all tables
            foreach(var table in tables)
            {
                // Iterate through all rows in this table
                foreach (var row in table.Rows)
                {
                    // Create the entity from the row
                    var entity = row.ToInpEntity(this);

                    // Add the entity to the dictionary only if it is not already in it
                    if (!_objectDictionary.ContainsKey(entity.ID))
                        _objectDictionary.Add(entity.ID, entity);
                }
            }

            Purge();
        }

        /// <summary>
        /// Remove any items from the dictionary that contain
        /// NULL in their names
        /// </summary>
        public void Purge()
        {
            foreach(var item in _objectDictionary.Values)
                if (item is IInpEntity entity && entity.Name == "<NULL>")
                    _objectDictionary.Remove(entity.ID);
        }

        #endregion

    }
}
