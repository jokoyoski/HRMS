using AA.HRMS.Interfaces;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    public class AppraisalQualitativeMetricModel : IAppraisalQualitativeMetric
    {
        public int AppraisalQualitativeMetricId { get; set; }
        public int EmployeeAppraisalId { get; set; }
        public string Target { get; set; }
        public int ResultId { get; set; }
        public IList<SelectListItem> ResultDropDown { get; set; }
        public string Goal { get; set; }
        public int CompanyId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
