using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IAppraisalQualitativeMetricView
    {
         int AppraisalQualitativeMetricId { get; set; }
         int AppraisalGoalId { get; set; }
         string Target { get; set; }
         int ResultId { get; set; }
         int CompanyId { get; set; }
         bool IsActive { get; set; }
         DateTime DateCreated { get; set; }
         string ProcessingMessage { get; set; }
    }
}
