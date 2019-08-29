using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IAppraisal" />
    public class AppraisalModel : IAppraisal
    {
        /// <summary>
        /// Gets or sets the appraisal identifier.
        /// </summary>
        /// <value>
        /// The appraisal identifier.
        /// </value>
        public int AppraisalId { get; set; }
        /// <summary>
        /// Gets or sets the date initiated.
        /// </summary>
        /// <value>
        /// The date initiated.
        /// </value>
        public DateTime DateInitiated { get; set; }
        public int AppraisalYearId { get; set; }
        public string AppraisalYearName { get; set; }
        public int AppraisalPeriodId { get; set; }
        public string AppraisalPeriodName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsOpened { get; set; }
        public DateTime? DateApproved { get; set; }
        public DateTime? DateAgreed { get; set; }


        public string AppraiseeComment { get; set; }
        public string AppraiserComment { get; set; }
        public string HRComment { get; set; }
    }
}
