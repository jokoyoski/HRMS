using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    public class EmployeeFeedbackViewModel : IEmployeeFeedbackViewModel
    {
        public int EmployeeFeedbackId { get; set; }
        public int? EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int? FeedbackOnEmployeeId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateOfFeedback { get; set; }
        public int FeedbackId { get; set; }
        public string InWhatContext { get; set; }
        public string ProvideOverview { get; set; }
        public string Experience { get; set; }
        public string WhatAreas { get; set; }
        public bool IsActive { get; set; }
        public IList<SelectListItem> EmployeeList { get; set; }
        public string ProcessingMessage { get; set; }        
    }
}
