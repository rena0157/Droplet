﻿// InpTableRow.cs
// By: Adam Renaud
// Created: 2019-09-10

using Droplet.Core.Inp.Entities;
using Droplet.Core.Inp.Options;
using System.Collections.Generic;

namespace Droplet.Core.Inp.Data
{
    /// <summary>
    /// A table row in an inp table
    /// </summary>
    /// <typeparam name="T">The row type</typeparam>
    public sealed class InpTableRow : IInpTableRow
    {
        /// <summary>
        /// Default Constructor for the table row. This constructor requires the key of the row
        /// the values that the row contains (This generally includes the key), any comments on the row
        /// and the table that this row belongs to.
        /// <param name="key">The key for the row</param>
        /// <param name="values">The values associated with the row</param>
        /// <param name="table">The table that this row belongs to</param>
        public InpTableRow(string key, string[] values, string comments, IInpTable table)
        {
            Key = key;
            Values = new List<string>(values);
            Comment = comments;
            InpTable = table;
        }

        /// <summary>
        /// The key for the table row.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// The values associated with the row (The row values)
        /// </summary>
        public List<string> Values { get; }

        /// <summary>
        /// Get an indexed value from the <see cref="Values"/> list
        /// </summary>
        /// <returns>Returns: a string from the list at the index that is passed</returns>
        string IInpTableRow.this[int index] => Values[index];

        /// <summary>
        /// The comment for the row.
        /// </summary>
        public string Comment { get; }

        /// <summary>
        /// The table that this row belongs to
        /// </summary>
        public IInpTable InpTable { get; }

        /// <summary>
        /// Convert this table row to an <see cref="IInpEntity"/>. This method will using the 
        /// constructor of an entity which has the following signature <see cref="InpEntity(IInpTableRow, IInpDatabase)"/>
        /// </summary>
        /// <returns>Returns: An <see cref="IInpEntity"/> that is created from this table data</returns>
        public IInpEntity ToInpEntity(IInpDatabase database) => InitializeEntity(database);

        /// <summary>
        /// Initializes the entities that this table is associated with
        /// </summary>
        /// <returns>Returns: an <see cref="IInpEntity"/> that is initialized with this row
        /// and the database</returns>
        private IInpEntity InitializeEntity(IInpDatabase database) => InpTable.Name switch
        {
            InpOption.HeaderName => InpOption.CreateFromOptionName(Key, this, database),

            // TODO: Add exception here
            _                    => new InpEntity()
        };
    }
}
