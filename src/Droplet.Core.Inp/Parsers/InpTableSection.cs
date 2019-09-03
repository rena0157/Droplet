// InpLib
// InpTableSection.cs
// 
// ============================================================
// 
// Created: 2019-08-11
// Last Updated: 2019-08-11-02:07 PM
// By: Adam Renaud
// 
// ============================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Droplet.Core.Inp.Entities;
using Droplet.Core.Inp.IO;
using Droplet.Core.Inp.Options;

namespace Droplet.Core.Inp.Parsers
{
    /// <summary>
    /// Inp Data Table Section
    /// </summary>
    public class InpTableSection : InpSection
    {
        /// <summary>
        /// A Queue where all description data is stored
        /// </summary>
        private readonly StringBuilder _description;

        /// <summary>
        /// The entity type that the table is creating
        /// </summary>
        private readonly Type _tableDataType;

        /// <summary>
        /// The entity data that is extracted from the table
        /// </summary>
        private readonly List<(IInpTableParseable, string[])> _tableEntityData;

        /// <summary>
        /// Construct the InpTableSection
        /// </summary>
        /// <param name="project"></param>
        /// <param name="sectionName">The name of the section that will be parsed</param>
        public InpTableSection(InpProject project, string sectionName) : base(project)
        {
            _description = new StringBuilder();
            _tableEntityData = new List<(IInpTableParseable, string[])>();
            _tableDataType = GetDataType(sectionName);
        }

        /// <summary>
        /// Override of the read section function. This function will
        /// read the section passed to it and place the inp entities into the
        /// project database
        /// </summary>
        /// <param name="reader">The reader for the project</param>
        public override void ReadSection(IInpReader reader)
        {
            base.ReadSection(reader);

            // Build all of the entities from the table data
            foreach (var (entity, data) in _tableEntityData)
            {
                // Build the entity from the data from the inp table
                entity?.BuildFromTable(data);
                if (entity == null) continue;

                switch (entity)
                {
                    // Add the entity to the project
                    case InpEntity inpEntity:
                    {
                        Project.Entities.Add(inpEntity);
                    }
                        break;
                    
                    // Add the entity data to the entities that are referenced
                    case InpEntityData entityData:
                    {
                        foreach (var entityName in entityData.ReferencedEntityNames)
                            Project.Entities
                                .FirstOrDefault(e => e.Name == entityName)
                                ?.AddEntityData(entityData);
                    }
                        break;
                }
            }
        }

        /// <summary>
        /// Override of the Parse line function for a data table that will read the line
        /// and break it up into the tokens. It will place the data of this 
        /// line into the table data list for further processing
        /// </summary>s
        /// <param name="line">The line that will be parsed</param>
        /// <returns>Returns: true if the parse was successful</returns>
        protected override bool ParseLine(string line)
        {
            // Parse the description for the entity
            if (line.StartsWith(";") && !line.Contains(";;"))
            {
                // Trim the starting ; and the trailing white space from the string
                _description.AppendLine(line.Trim(new char[]{ ';', '\n', '\r' }));
                return true;
            }

            // If the line contains a comment then return false
            if (line.Contains(";;")) return false;
            
            // Get the tokens from the line
            var tokens = GetTokens(line);

            // Make sure that there is at least 1 token
            if (tokens.Length < 1) return false;

            // Create the entity from the table data type
            var entity = (IInpTableParseable)Activator.CreateInstance(_tableDataType);

            // If the entity is an InpEntity then add the 
            // description to it if there is one that was captured
            // Then remove the description from the string builder
            if (entity is InpEntity inpEntity)
            {
                inpEntity.Description = _description.ToString();
                _description.Clear();
            }

            // Add the entity to the table data list
            _tableEntityData.Add((entity, tokens));

            // If we get this far then the parsing was successful
            return true;
        }

        /// <summary>
        /// Get the data type of the InpTable
        /// </summary>
        /// <param name="sectionName">The section name</param>
        /// <returns>Returns: The Table type</returns>
        private Type GetDataType(string sectionName)
        {
            switch (sectionName)
            {
                case "SUBCATCHMENTS": return typeof(Subcatchment);
                case "SUBAREAS": return typeof(SubArea);
                case "AQUIFERS" : return typeof(Aquifer);
                case "GROUNDWATER" : return typeof(Groundwater);
                case "INFILTRATION":
                    {
                        switch (Project.InfiltrationMethod)
                        {
                            case InfiltrationMethods.Horton: return typeof(HortonInfiltration);
                            case InfiltrationMethods.ModifiedHorton: return typeof(HortonInfiltration);
                            case InfiltrationMethods.GreenAmpt: return typeof(GreenAmptInfiltration);
                            case InfiltrationMethods.ModifiedGreenAmpt: return typeof(GreenAmptInfiltration);
                            case InfiltrationMethods.CurveNumber: return typeof(CurveNumberInfiltration);
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }

                default:
                    throw new ArgumentOutOfRangeException($"{sectionName} was unrecognized");
            }
        }
    }
}
