using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    public class FeedbackModel : IFeedbackModel
    {
        public int FeedbackId { get; set; }
        public int YearId { get; set; }
        public int CompanyId { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
        public bool IsLock { get; set; }
        public string  CompanyName { get; set; }
        public string years { get; set; }
        public int noOfFeedbacks { get; set; }
    }
}
