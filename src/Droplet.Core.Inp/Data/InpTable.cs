using System;
using System.Collections.Generic;
using System.Text;

namespace Droplet.Core.Inp.Data
{
    /// <summary>
    /// An Inp Table
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InpTable : IInpTable
    {
        /// <summary>
        /// The backing dictionary
        /// </summary>
        protected Dictionary<string, ITableRow> _tableDictionary;

        /// <summary>
        /// Default Constructor that will initialize the inptables
        /// entities
        /// </summary>
        public InpTable()
        {
            Rows = new List<ITableRow>();
            Headers = "";
            Name = "";
        }

        /// <summary>
        /// Constructor that recieves a name for the table
        /// </summary>
        /// <param name="name">The name of the table</param>
        public InpTable(string name) : this()
        {
            Name = name;
        }

        /// <summary>
        /// The name of the table
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The rows associated with the table
        /// </summary>
        public List<ITableRow> Rows { get; }

        /// <summary>
        /// The headers for the table
        /// </summary>
        public string Headers { get; }

        /// <summary>
        /// Add a row to the table.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// This will throw if the row is already in the table
        /// </exception>
        /// <param name="row">The row that is to be added</param>
        public void AddRow(ITableRow row)
        {
            // Check to see if the table already contains this 
            // entry and if it does then throw an exception
            if (_tableDictionary.ContainsKey(row.Key))
                throw new ArgumentException($"The row {row} with key {row.Key} already exists" +
                    $" in this table");

            // Else add this item to the table
            _tableDictionary.Add(row.Key, row);
        }
    }
}
