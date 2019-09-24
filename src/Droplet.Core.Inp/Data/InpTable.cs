using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private Dictionary<string, IInpTableRow> _tableDictionary;

        /// <summary>
        /// Default Constructor that will initialize the inp tables
        /// entities
        /// </summary>
        public InpTable()
        {
            Headers = "";
            Name = "";
            _tableDictionary = new Dictionary<string, IInpTableRow>();
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
        public IEnumerable<IInpTableRow> Rows => _tableDictionary.Values;

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
        public void AddRow(IInpTableRow row)
        {
            // Check to see if the table already contains this 
            // entry and if it does then append the values to it
            // Note that we don't read the key value to the values array
            if (_tableDictionary.ContainsKey(row.Key))
            {
                // Using the range 1..^0 grabs the second value to the last value
                _tableDictionary[row.Key].Values.AddRange(row.Values.ToArray()[1..^0]);
                return;
            }

            // Else add this item to the table
            _tableDictionary.Add(row.Key, row);
        }
    }
}
