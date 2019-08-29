using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IMethodOfDelivery
    {
        /// <summary>
        /// Gets or sets the method of delivery training identifier.
        /// </summary>
        /// <value>
        /// The method of delivery training identifier.
        /// </value>
        int MethodOfDeliveryTrainingId { get; set; }
        /// <summary>
        /// Gets or sets the method of delivery training.
        /// </summary>
        /// <value>
        /// The method of delivery training.
        /// </value>
        string MethodOfDeliveryTraining { get; set; }
    }
}
