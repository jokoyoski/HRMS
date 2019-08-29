using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    public class TaxListView : ITaxListView 
    {
        /// <summary>
        /// Gets or sets the tax collection.
        /// </summary>
        /// <value>
        /// The tax collection.
        /// </value>
        public IList<ITax> TaxCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }


    }
}
