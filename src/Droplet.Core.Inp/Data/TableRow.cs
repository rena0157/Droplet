using Droplet.Core.Inp.Entities;
using System;
using System.Collections.Generic;

namespace Droplet.Core.Inp.Data
{
    /// <summary>
    /// A table row in an inp table
    /// </summary>
    /// <typeparam name="T">The row type</typeparam>
    public class TableRow : ITableRow
    {
        /// <summary>
        /// Default Constructor for the table row
        /// </summary>
        /// <param name="key">The key for the row</param>
        /// <param name="values">The values associated with the row</param>
        public TableRow(string key, string[] values, string comments, IInpTable table)
        {
            Key = key;
            Values = new List<string>(values);
            Comment = comments;
            InpTable = table;
        }

        /// <summary>
        /// The key for the table row
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// The values associated with the row (The column values)
        /// </summary>
        public List<string> Values { get; }

        /// <summary>
        /// The comment for the row.
        /// </summary>
        public string Comment { get; }

        /// <summary>
        /// The table that this row belongs to
        /// </summary>
        public IInpTable InpTable { get; }

        /// <summary>
        /// Convert this table row to an <see cref="IInpEntity"/>
        /// </summary>
        /// <returns>Returns: An <see cref="IInpEntity"/> that is created from this table data</returns>
        public IInpEntity ToInpEntity(IInpDatabase database) => InitializeEntity(database);

        /// <summary>
        /// Get the type that this row referes to
        /// </summary>
        /// <returns></returns>
        private IInpEntity InitializeEntity(IInpDatabase database) => InpTable.Name switch
        {
            InpOption.HeaderName => new InpOption(this, database)
        };
    }
}
