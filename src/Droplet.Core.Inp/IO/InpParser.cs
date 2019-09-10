using Droplet.Core.Inp.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Droplet.Core.Inp.IO
{
    /// <summary>
    /// Parser for Inp Files
    /// </summary>
    public class InpParser : IInpParser
    {
        /// <summary>
        /// The start section header string opening bracket
        /// </summary>
        protected const string StartHeaderString = "[";

        /// <summary>
        /// The start section header string closing bracket
        /// </summary>
        protected const string EndHeaderString = "]";

        /// <summary>
        /// A list of all the tables in this parser
        /// </summary>
        protected List<IInpTable> InpTables { get; set;}

        /// <summary>
        /// Default Constructor that initializes the values for this
        /// class
        /// </summary>
        public InpParser()
        {
            InpTables = new List<IInpTable>();
        }

        /// <summary>
        /// Parse the file supplied with the reader and construct the
        /// project
        /// </summary>
        /// <param name="inpProject">The project that will be updated</param>
        /// <param name="reader">The reader that will be used to read the file</param>
        public void ParseFile(IInpProject inpProject, IInpReader reader)
        {
            while(!reader.EndOfStream)
            {
                // Read the next line from the stream
                var line = reader.ReadLine();

                // if the current string is the start of a section
                // read the section name from the string
                var sectionName = string.Empty;
                if (line.Contains(StartHeaderString))
                    sectionName = line.Trim((StartHeaderString + EndHeaderString).ToCharArray());

                // If the sectionName is empty then continue on to the next string
                if (sectionName == string.Empty) continue;

                // Add this table to the tables list
                InpTables.Add(BuildTable(reader, sectionName));
            }

            // Update the database from the tables created above
            inpProject.Database.UpdateDatabase(InpTables);
        }

        /// <summary>
        /// Build the table from the supplied reader and the table name supplied
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="tableName">The table name</param>
        protected virtual InpTable BuildTable(IInpReader reader, string tableName)
        {
            var table = new InpTable(tableName);
            var comments = new StringBuilder();

            // While the reader is not at the end of a section and the
            // reader is not at the end of the stream build the table
            while(!reader.EndOfStream && !EndOfSection(reader.PeekLine()))
            {
                // Get the next line from the reader
                var line = reader.ReadLine();

                // If the line contains a comment append it
                // to the comments strings builder
                if (IsComment(line))
                {
                    comments.Append(line);
                    continue;
                }

                // Get the tokens from the string and 
                // add them to the table
                var tokens = GetTokens(line);
                if (tokens.Length > 0) 
                    table.AddRow(new InpTableRow(tokens[0], tokens, comments.ToString(), table));
            }

            return table;
        }

        /// <summary>
        /// Returns True if the current line signifies the end of a section
        /// </summary>
        /// <param name="line">The line that will be tested</param>
        /// <returns>Returns: True if the end of the section is reached</returns>
        protected virtual bool EndOfSection(string line) 
            => line != null && line.Contains(StartHeaderString);

        /// <summary>
        /// Get the tokens from the current line using ' ' as the separator
        /// </summary>
        /// <param name="line">The line that the tokes will come from</param>
        /// <returns>Returns: A string array that contains all of the tokens from this line</returns>
        protected virtual string[] GetTokens(string line) 
            => line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        /// <summary>
        /// Check to see if the line is a comment
        /// </summary>
        /// <param name="line">The line that will be tested</param>
        /// <returns>Returns: True if the line contains a comment</returns>
        protected virtual bool IsComment(string line)
            => line.StartsWith(";;");
    }
}
