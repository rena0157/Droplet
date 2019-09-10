using Droplet.Core.Inp.Entities;
using Droplet.Core.Inp.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Droplet.Core.Inp.Data
{
    /// <summary>
    /// A database that holds all of the data from
    /// an inp file
    /// </summary>
    public class InpDatabase : IInpDatabase
    {
        #region Private Members

        /// <summary>
        /// database backing store
        /// </summary>
        private Dictionary<Guid, IInpDbObject> _objectDictionary;


        private List<IInpTable> _inpTables { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public InpDatabase()
        {
            _objectDictionary = new Dictionary<Guid, IInpDbObject>();
        }

        /// <summary>
        /// Constructor that builds the database from the tables
        /// supplied
        /// </summary>
        /// <param name="tables">The tables that will be used to build the database</param>
        public InpDatabase(List<IInpTable> tables) : this()
        {
            _inpTables = tables;
            UpdateDatabase(tables);
        }

        #endregion

        #region IInpDatabase Implementation

        /// <summary>
        /// Get an object from the database. Note that if the object is not in
        /// the dictionary this will throw an exception.
        /// </summary>
        /// <param name="id">The id of the object that will be returned</param>
        /// <returns>Returns: An object in the database</returns>
        public IInpDbObject GetObject(Guid id)
        {
            // If the object is not in the database throw an exception
            if (!_objectDictionary.ContainsKey(id))
                throw new ArgumentOutOfRangeException($"The object with id {id} could not be found");

            return _objectDictionary[id];
        }

        /// <summary>
        /// Return an option from the database given the <see cref="InpOption"/> derived
        /// type
        /// </summary>
        /// <typeparam name="T">The option type that will be returned</typeparam>
        /// <returns>Returns: An option from the database</returns>
        public T GetOption<T>() where T : InpOption 
            => _objectDictionary.Values.FirstOrDefault(o => o is T) as T;

        /// <summary>
        /// Get all entities of the type <typeparamref name="T"/>
        /// from the database.
        /// </summary>
        /// <typeparam name="T">The type must be an <see cref="IInpEntity"/> implementor</typeparam>
        /// <returns>Returns: An <see cref="IInpEntity"/> list</returns>
        public List<T> GetAllEntities<T>() where T : IInpEntity
        {
            var returnList = new List<T>();
            foreach(var e in _objectDictionary.Values)
            {
                if (e is T et)
                    returnList.Add(et);
            }

            return returnList;
        }

        /// <summary>
        /// Update the database from the supplied tables
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
