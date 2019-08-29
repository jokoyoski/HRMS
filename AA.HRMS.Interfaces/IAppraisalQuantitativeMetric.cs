using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface IAppraisalQuantitativeMetric
    {
         int AppraisalQuantitativeMetricId { get; set; }
        int EmployeeAppraisalId { get; set; }
         string PrimaryTarget { get; set; }
         string PrimaryActual { get; set; }
         string SecondaryTarget { get; set; }
         string SecondaryActual { get; set; }
         int ResultId { get; set; }
        IList<SelectListItem> ResultDropDown { get; set; }
        string Goal { get; set; }
        int CompanyId { get; set; }
         bool IsActive { get; set; }
         DateTime DateCreated { get; set; }
         DateTime? DateModified { get; set; }
    }
}
