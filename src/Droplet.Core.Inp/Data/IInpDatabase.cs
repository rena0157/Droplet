using System;
using System.Collections.Generic;

namespace Droplet.Core.Inp.Data
{
    public interface IInpDatabase
    {
        /// <summary>
        /// Get an object from the database
        /// </summary>
        /// <param name="id">The id of the object</param>
        IInpDbObject GetObject(Guid id);

        /// <summary>
        /// Update the database
        /// </summary>
        /// <param name="tables">The tables that make up the database</param>
        void UpdateDatabase(List<IInpTable> tables);
    }
}
