using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    public class TrainingNeedAnalysisViewModel 
    {
        public int TrainingNeedAnalysisID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int JobID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TrainingID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CompanyID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TrainingDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MethodOfDelivery { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TrainingProvider { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsProviderApproved { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal ApprovedBudget { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ApprovedBudgetCurrency { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FrequencyOfDeliveryID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal TrainingDuration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CertificateIssued { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime DateCreated { get; set; }
    }
}
