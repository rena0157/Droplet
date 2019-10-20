using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Utilities;
using System;
using System.Globalization;

namespace Droplet.Core.Inp.Entities
{
    /// <summary>
    /// Class that represents added data to an entity. For example the sub-area entity is added 
    /// data to the subcatchment entity.
    /// </summary>
    abstract public class InpEntityData : IInpEntity
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public InpEntityData()
        {
            ID = Guid.NewGuid();
            var resources = new InpResourceManager();
            Name = Description = Tag = resources.GetString("DefaultProperty", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Internal constructor that accepts a <see cref="IInpTableRow"/> and an <see cref="IInpDatabase"/> 
        /// that will be used to construct the data and set the database for this entity. This constructor sets 
        /// the <see cref="Name"/> as the first element in the row and creates a <see cref="Guid.NewGuid"/> for its 
        /// <see cref="ID"/>.
        /// </summary>
        /// <param name="row">The row that will be used to construct this entity data</param>
        /// <param name="database">The database that this entity belongs to</param>
        internal InpEntityData(IInpTableRow row, IInpDatabase database)
        {
            _ = row ?? throw new ArgumentNullException(nameof(row));
            _ = database ?? throw new ArgumentNullException(nameof(database));

            var resources = new InpResourceManager();

            Name = row[0];
            Database = database;
            ID = Guid.NewGuid();
            Description = Tag = resources.GetString("DefaultProperty", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// The name of the reference Entity
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The optional Description for the entity
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// The optional Tag for the entity
        /// </summary>
        public string Tag { get; }

        /// <summary>
        /// The database Guid for the entity
        /// </summary>
        public Guid ID { get; }

        /// <summary>
        /// The database that the entity belongs to
        /// </summary>
        public IInpDatabase? Database { get; }

        /// <summary>
        /// Abstract method that converts this entity to an inp string
        /// </summary>
        /// <returns>Returns: A formatted inp string</returns>
        public abstract string ToInpString();
    }
}
