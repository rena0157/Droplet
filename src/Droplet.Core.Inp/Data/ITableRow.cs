using Droplet.Core.Inp.Entities;
using System.Collections.Generic;

namespace Droplet.Core.Inp.Data
{
    /// <summary>
    /// An row from the table.
    /// </summary>
    public interface ITableRow
    {
        /// <summary>
        /// The key for the table
        /// </summary>
        string Key { get; }

        /// <summary>
        /// The Comment on the row
        /// </summary>
        string Comment { get; }

        /// <summary>
        /// The values from the table entry. The columns for this row
        /// </summary>
        List<string> Values { get; }


        /// <summary>
        /// The table that this row belongs to
        /// </summary>
        IInpTable InpTable { get; }

        /// <summary>
        /// Convert this Table row to an entity
        /// </summary>
        /// <returns>Returns: An <see cref="IInpEntity"/> that represents this table row</returns>
        IInpEntity ToInpEntity(IInpDatabase database);
    }
}
