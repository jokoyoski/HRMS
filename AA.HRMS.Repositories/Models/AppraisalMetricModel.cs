using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    public class AppraisalMetricModel : IAppraisalMetric
    {
        public int AppraisalMetricId { get; set; }
        public int ApprasialGoalId { get; set; }
        public string Target { get; set; }
        public int ResultId { get; set; }
        public string Things_I_did_Well { get; set; }
        public string Things_I_did_not_do_so_Well { get; set; }
        public string My_Development_Plan { get; set; }
        public int CompanyId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
