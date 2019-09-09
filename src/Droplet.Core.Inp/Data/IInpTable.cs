using System.Collections.Generic;

namespace Droplet.Core.Inp.Data
{
    /// <summary>
    /// Interface for Inp Tables
    /// </summary>
    public interface IInpTable
    {
        /// <summary>
        /// The name of the table
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The headers for the table
        /// </summary>
        string Headers { get; }

        /// <summary>
        /// A list of the rows in the table
        /// </summary>
        IEnumerable<ITableRow> Rows { get; }

        /// <summary>
        /// Add a row to the table
        /// </summary>
        /// <param name="row"></param>
        void AddRow(ITableRow row);
    }
}
