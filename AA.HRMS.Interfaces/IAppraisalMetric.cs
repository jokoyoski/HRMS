using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IAppraisalMetric
    {
         int AppraisalMetricId { get; set; }
         int ApprasialGoalId { get; set; }
         string Target { get; set; }
         int ResultId { get; set; }
         string Things_I_did_Well { get; set; }
         string Things_I_did_not_do_so_Well { get; set; }
         string My_Development_Plan { get; set; }
         int CompanyId { get; set; }
         bool IsActive { get; set; }
         DateTime DateCreated { get; set; }
    }
}
