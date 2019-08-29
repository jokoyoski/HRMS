using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ITaxListView
    {
        /// <summary>
        /// Gets or sets the tax collection.
        /// </summary>
        /// <value>
        /// The tax collection.
        /// </value>
        IList<ITax> TaxCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

    }
}
