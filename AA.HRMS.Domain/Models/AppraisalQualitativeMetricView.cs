using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    public class AppraisalQualitativeMetricView : IAppraisalQualitativeMetricView
    {
        public int AppraisalQualitativeMetricId { get; set; }
        public int AppraisalGoalId { get; set; }
        public string Target { get; set; }
        public int ResultId { get; set; }
        public int CompanyId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public string ProcessingMessage { get; set; }
    }
}
