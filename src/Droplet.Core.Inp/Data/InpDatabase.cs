// InpDatabase.cs
// Created: 2019-09-10
// By: Adam Renaud

using Droplet.Core.Inp.Entities;
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
        /// whos key is a <see cref="Guid"/> that is created at the objects creation
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
            // Initialize the backing store for the database
            _objectDictionary = new Dictionary<Guid, IInpDbObject>();
        }

        /// <summary>
        /// Constructor that builds the database from the tables
        /// supplied from an inp file.
        /// </summary>
        /// <param name="tables">The tables that will be used to build the database</param>
        public InpDatabase(List<IInpTable> tables) : this()
        {
            // Set the tables provided
            _inpTables = tables;

            // Update the database from the tables provided
            UpdateDatabase(tables);
        }

        #endregion

        #region IInpDatabase Implementation

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
        public T GetOption<T>() where T: InpOption
        {
            return _objectDictionary.Values.FirstOrDefault(o => o is T) as T;
        }

        /// <summary cref="IInpDatabase.GetOption(Type)">
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Will throw if the type is not an <see cref="InpOption"/>
        /// </exception>
        public InpOption GetOption(Type type)
        {
            // Throw an exception if the type is not an InpOption
            if (type != typeof(InpOption))
                throw new ArgumentException($"The type passed must be an inheritor of {typeof(InpOption)}");

            // Returns the first type that matches
            return _objectDictionary.Values.FirstOrDefault(o => o.GetType() == type) as InpOption;
        }

        /// <summary>
        /// Get all entities of the type <typeparamref name="T"/>
        /// from the database.
        /// </summary>
        /// <typeparam name="T">The type must be an <see cref="IInpEntity"/> implementer</typeparam>
        /// <returns>Returns: An <see cref="IInpEntity"/> list</returns>
        public List<T> GetAllEntities<T>() where T : IInpEntity
        {
            // TODO: Find a better way of doing this

            // Create a return list
            var returnList = new List<T>();

            // Foreach entity in the database add
            // the entities if it matches the type provided
            foreach(var e in _objectDictionary.Values)
            {
                if (e is T et)
                    returnList.Add(et);
            }

            return returnList;
        }

        /// <summary>
        /// Update the database from the supplied tables. This method
        /// will effectively rebuild the database from the tables.
        /// </summary>
        /// <param name="tables">The tables that the database will be updated from</param>
        public void UpdateDatabase(List<IInpTable> tables)
        {
            foreach(var table in tables)
            {
                foreach (var row in table.Rows)
                {
                    var entity = row.ToInpEntity(this);
                    _objectDictionary.Add(entity.ID, entity);
                }
            }
        }

        #endregion
    }
}
