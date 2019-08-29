using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAppraisal
    {
        int AppraisalId { get; set; }
        DateTime DateInitiated { get; set; }
        int AppraisalYearId { get; set; }
        string AppraisalYearName { get; set; }
        int AppraisalPeriodId { get; set; }
        string AppraisalPeriodName { get; set; }
        int CompanyId { get; set; }
        string CompanyName { get; set; }
        bool IsActive { get; set; }
        DateTime? DateModified { get; set; }
        bool IsOpened { get; set; }
        DateTime? DateApproved { get; set; }
        DateTime? DateAgreed { get; set; }

         string AppraiseeComment { get; set; }
         string AppraiserComment { get; set; }
         string HRComment { get; set; }
    }
}
