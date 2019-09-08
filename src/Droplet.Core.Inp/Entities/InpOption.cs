using System;
using System.Collections.Generic;
using System.Text;
using Droplet.Core.Inp.Data;

namespace Droplet.Core.Inp.Entities
{
    public class InpOption : InpEntity
    {
        public const string HeaderName = "OPTIONS";

        public InpOption() : base()
        {

        }

        public InpOption(ITableRow row, IInpDatabase database) : base(row, database)
        {

        }
    }
}
