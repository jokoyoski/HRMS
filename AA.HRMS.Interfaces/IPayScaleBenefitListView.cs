using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IPayScaleBenefitListView
    {
        /// <summary>
        /// Gets or sets the pay s cale benefit collection.
        /// </summary>
        /// <value>
        /// The pay s cale benefit collection.
        /// </value>
        IList<IPayScaleBenefit> PaySCaleBenefitCollection { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
