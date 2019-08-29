using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
  public  class TrainingAnalysisViewModel : ITrainingAnalysisViewModel
    {
        public TrainingAnalysisViewModel()
        {
            this.CompanyDropdownList = new List<SelectListItem>();
            this.TrainingDropDownList = new List<SelectListItem>();
            this.FrequencyOfDeliveryDropDownList = new List<SelectListItem>();
            this.JobDropDownList = new List<SelectListItem>();
        }



        public int TrainingNeedAnalysisID { get; set; }
        public int JobID { get; set; }
        public int TrainingID { get; set; }
        public int CompanyID { get; set; }
        public string TrainingDescription { get; set; }
        public string MethodOfDelivery { get; set; }
        public string TrainingProvider { get; set; }
        public decimal Cost { get; set; }
        public string Location { get; set; }
        public bool IsProviderApproved { get; set; }
        public decimal ApprovedBudget { get; set; }
        public int FrequencyOfDeliveryID { get; set; }
        public decimal TrainingDuration { get; set; }
        public string CertificateIssued { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string Currency { get; set; }
        public string ApprovedBudgetCurrency { get; set; }



        public IList<SelectListItem> CompanyDropdownList { get; set; }
       public  IList<SelectListItem> TrainingDropDownList { get; set; }
       public  IList<SelectListItem> FrequencyOfDeliveryDropDownList { set; get; }
       public  IList<SelectListItem> JobDropDownList { get; set; }
        public string ProcessingMessage { get; set; }
    }
}
