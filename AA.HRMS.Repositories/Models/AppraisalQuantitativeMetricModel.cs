using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Repositories.Models
{
    public class AppraisalQuantitativeMetricModel : IAppraisalQuantitativeMetric
    {
        public int AppraisalQuantitativeMetricId { get; set; }
        public int EmployeeAppraisalId { get; set; }
        public string PrimaryTarget { get; set; }
        public string PrimaryActual { get; set; }
        public string SecondaryTarget { get; set; }
        public string SecondaryActual { get; set; }
        public IList<SelectListItem> ResultDropDown { get; set; }
        public string Goal { get; set; }
        public int ResultId { get; set; }
        public int CompanyId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
