using System;
using System.Collections.Generic;
using System.Text;
using Droplet.Core.Inp.Data;

namespace Droplet.Core.Inp.Options
{
    public class MaxTrialsOption : InpDoubleOption
    {

        #region Constructors

        public MaxTrialsOption(double value) : base(value)
        {
        }

        /// <summary>
        /// Internal constructor that constructs this option from a <see cref="IInpTableRow"/> 
        /// and adds a reference to the database that it belongs to.
        /// </summary>
        /// <param name="row">The row that will be used to construct this option</param>
        /// <param name="database">The database that this option belongs to</param>
        internal MaxTrialsOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        #endregion

        #region Internal Members

        /// <summary>
        /// The inp string option name
        /// </summary>
        internal const string OptionName = "";

        #endregion
    }
}
