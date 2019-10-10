using System;
using System.Collections.Generic;
using System.Text;
using Droplet.Core.Inp.Data;

namespace Droplet.Core.Inp.Options
{
    /// <summary>
    /// The thread count option
    /// </summary>
    public class ThreadCountOption : InpIntOption
    {

        #region Constructors

        /// <summary>
        /// Default Constructor that accepts the value that the option will be set to
        /// </summary>
        /// <param name="value">The value that the option will be set to</param>
        public ThreadCountOption(int value) : base(value) => Name = OptionName;

        /// <summary>
        /// Internal constructor that accepts a row and a database
        /// </summary>
        /// <param name="row">The row that will be used to construct the option</param>
        /// <param name="database">The database that the option belongs to</param>
        internal ThreadCountOption(IInpTableRow row, IInpDatabase database) : base(row, database)
        {
        }

        #endregion

        #region Internal Members

        /// <summary>
        /// The name of inp option
        /// </summary>
        internal const string OptionName = "THREADS";

        #endregion
    }
}
