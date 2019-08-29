using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    public class AppraisalQuantitativeMetricView : IAppraisalQuantitativeMetricView
    {
        public int AppraisalQuantitativeMetricId { get; set; }
        public int AppraisalGoalId { get; set; }
        public string Description { get; set; }
        public string PrimaryTarget { get; set; }
        public string PrimaryActual { get; set; }
        public string SecondaryTarget { get; set; }
        public string SecondaryActual { get; set; }
        public int? ResultId { get; set; }
        public int CompanyId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string ProcessingMessage { get; set; }
    }
}
