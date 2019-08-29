using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    public class PayScaleBenefitListView : IPayScaleBenefitListView
    {
        /// <summary>
        /// Gets or sets the pay s cale benefit collection.
        /// </summary>
        /// <value>
        /// The pay s cale benefit collection.
        /// </value>
        public IList<IPayScaleBenefit> PaySCaleBenefitCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
