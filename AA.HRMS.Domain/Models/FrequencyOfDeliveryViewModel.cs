using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IFrequencyOfDeliveryViewModel" />
    class FrequencyOfDeliveryViewModel : IFrequencyOfDeliveryViewModel
    {
        public int FrequencyOfDeliveryId { get; set; }
        /// <summary>
        /// Gets or sets the frequency of delivery1.
        /// </summary>
        /// <value>
        /// The frequency of delivery1.
        /// </value>
        public string FrequencyOfDelivery1 { get; set; }
    }
}
