using Droplet.Core.Inp.Data;
using System;
using System.Text;

namespace Droplet.Core.Inp.Entities
{
    /// <summary>
    /// Base class for all entities
    /// </summary>
    public class InpEntity : IInpEntity
    {

        public InpEntity()
        {
            ID = Guid.NewGuid();
        }

        public InpEntity(ITableRow row, IInpDatabase database) : this()
        {

        }

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
        public IInpDatabase Database {get; protected set; } 
    }
}
