// InpEntity.cs
// Created: 2019-09-10
// By: Adam Renaud

using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Utilities;
using System;
using System.Globalization;

namespace Droplet.Core.Inp.Entities
{
    /// <summary>
    /// Base class for all entities
    /// </summary>
    public class InpEntity : IInpEntity
    {

        #region Constructors

        /// <summary>
        /// Default Constructor that initializes this entity
        /// </summary>
        public InpEntity()
        {
            ID = Guid.NewGuid();
            var resources = new InpResourceManager();
            Name = Description = Tag = resources.GetString("DefaultProperty", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Initializes this entity from a table row and
        /// a database.
        /// </summary>
        /// <param name="row">The row that will be used to initialize this entity</param>
        /// <param name="database">The database that will be used to initialize this entity</param>
        public InpEntity(IInpTableRow row, IInpDatabase database) : this()
        {
            // Check if the argument is null
            _ = row ?? throw new ArgumentNullException(nameof(row));
            _ = database ?? throw new ArgumentNullException(nameof(database));

            // Check to see if the row has a name
            // and if it does set it
            if (row.Values.Count > 1)
                Name = row[0];

            // Set the database for the 
            Database = database;
        }

        #endregion

        /// <summary>
        /// The name of the entity
        /// </summary>
        public virtual string Name { get; protected set; }

        /// <summary>
        /// The description of the entity
        /// </summary>
        public string Description { get; protected set;}

        /// <summary>
        /// The Tag of the entity
        /// </summary>
        public string Tag { get; protected set; }

        /// <summary>
        /// The ID of the <see cref="IInpDatabase"/> object
        /// </summary>
        public Guid ID { get; protected set; }

        /// <summary>
        /// The <see cref="IInpDatabase"/> that this entity belongs to
        /// </summary>
        public IInpDatabase? Database {get; protected set; } 
    }
}
