using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface IAppraisalQualitativeMetric
    {
         int AppraisalQualitativeMetricId { get; set; }
        int EmployeeAppraisalId { get; set; }
        string Target { get; set; }
         int ResultId { get; set; }
        IList<SelectListItem> ResultDropDown { get; set; }
         string Goal { get; set; }
        int CompanyId { get; set; }
         bool IsActive { get; set; }
         DateTime DateCreated { get; set; }
    }
}
