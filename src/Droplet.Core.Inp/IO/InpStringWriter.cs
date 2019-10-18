using Droplet.Core.Inp.Data;
using Droplet.Core.Inp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Droplet.Core.Inp.IO
{
    /// <summary>
    /// Class that holds utilities for combining inp entities to
    /// an inp file
    /// </summary>
    public class InpStringWriter
    {

        private readonly IInpDatabase _database;

        public InpStringWriter(IInpDatabase database)
        {
            _database = database;
        }

        /// <summary>
        /// Convert the database to strings where each string is 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> DatabaseToStrings()
        {
            foreach(var entity in _database.GetAllEntities<InpEntity>())
                yield return entity.ToInpString();
        }
    }
}
