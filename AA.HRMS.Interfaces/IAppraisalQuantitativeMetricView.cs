using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IAppraisalQuantitativeMetricView
    {
         int AppraisalQuantitativeMetricId { get; set; }
         int AppraisalGoalId { get; set; }
         string Description { get; set; }
         string PrimaryTarget { get; set; }
         string PrimaryActual { get; set; }
         string SecondaryTarget { get; set; }
         string SecondaryActual { get; set; }
         int? ResultId { get; set; }
         int CompanyId { get; set; }
         bool IsActive { get; set; }
         DateTime DateCreated { get; set; }
         DateTime? DateModified { get; set; }
         string ProcessingMessage { get; set; }
    }
}
