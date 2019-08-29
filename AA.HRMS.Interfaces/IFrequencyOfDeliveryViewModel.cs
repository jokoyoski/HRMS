using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
   public interface IFrequencyOfDeliveryViewModel
    {
        /// <summary>
        /// Gets or sets the frequency of delivery identifier.
        /// </summary>
        /// <value>
        /// The frequency of delivery identifier.
        /// </value>
        int FrequencyOfDeliveryId { get; set; }
        /// <summary>
        /// Gets or sets the frequency of delivery1.
        /// </summary>
        /// <value>
        /// The frequency of delivery1.
        /// </value>
        string FrequencyOfDelivery1 { get; set; }
    }
}
