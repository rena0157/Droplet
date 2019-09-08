using System;

namespace Droplet.Core.Inp.Data
{
    /// <summary>
    /// Object that belongs to an <see cref="IInpDatabase"/>
    /// </summary>
    public interface IInpDbObject
    {
        /// <summary>
        /// The ID of the object
        /// </summary>
        Guid ID { get;}

        /// <summary>
        /// The database that the object belongs to
        /// </summary>
        IInpDatabase Database { get; }
    }
}
