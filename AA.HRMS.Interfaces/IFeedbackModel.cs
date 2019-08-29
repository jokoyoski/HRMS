using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IFeedbackModel
    {
          int FeedbackId { get; set; }
          int YearId { get; set; }
          int CompanyId { get; set; }
          DateTime DateCreated { get; set; }
          bool IsActive { get; set; }
          bool IsLock { get; set; }
        string CompanyName { get; set; }
        string years { get; set; }
       int noOfFeedbacks { get; set; }
    }
}
