using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IAppraisalPeriod" />
    public class AppraisalPeriodModel : IAppraisalPeriod
    {
        /// <summary>
        /// Gets or sets the appraisal period identifier.
        /// </summary>
        /// <value>
        /// The appraisal period identifier.
        /// </value>
        public int AppraisalPeriodId { get; set; }
        /// <summary>
        /// Gets or sets the appraisalperiod1.
        /// </summary>
        /// <value>
        /// The appraisalperiod1.
        /// </value>
        public string Appraisalperiod1 { get; set; }
    }
}
