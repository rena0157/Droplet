using System;
using System.Collections.Generic;
using System.Text;
using Droplet.Core.Inp.Data;

namespace Droplet.Core.Inp.Options
{
    public class SkipSteadyStateOption : InpBoolOption
    {
        public SkipSteadyStateOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }
    }
}
