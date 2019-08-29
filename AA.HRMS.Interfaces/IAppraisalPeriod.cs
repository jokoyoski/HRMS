using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IAppraisalPeriod
    {
        /// <summary>
        /// Gets or sets the appraisal period identifier.
        /// </summary>
        /// <value>
        /// The appraisal period identifier.
        /// </value>
        int AppraisalPeriodId { get; set; }
        /// <summary>
        /// Gets or sets the appraisalperiod1.
        /// </summary>
        /// <value>
        /// The appraisalperiod1.
        /// </value>
        string Appraisalperiod1 { get; set; }
    }
}
