using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
   public  interface IEmployeeFeedbackModel
    {
         int EmployeeFeedbackId { get; set; }
          int? EmployeeId { get; set; }
          int CompanyId { get; set; }
          int? FeedbackOnEmployeeId { get; set; }
        string FeedbackOnEmployee { get; set; }
        DateTime DateCreated { get; set; }
          DateTime? DateOfFeedback { get; set; }
          int FeedbackId { get; set; }
          string InWhatContext { get; set; }
          string ProvideOverview { get; set; }
          string Experience { get; set; }
          string WhatAreas { get; set; }
        bool IsActive { get; set; }
        string CompanyName { get; set; }
          string year { get; set; }
         string employeeName { get; set; }
    }
}
