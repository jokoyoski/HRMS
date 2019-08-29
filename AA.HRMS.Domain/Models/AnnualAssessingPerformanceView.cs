using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    public class AnnualAssessingPerformanceView : IAnnualAssessingPerformanceView
    {

        public AnnualAssessingPerformanceView()
        {
            this.YearDropDown = new List<SelectListItem>();
        }

        public int AnnualAssessingPerformanceId { get; set; }
        public int YearId { get; set; }
        public IList<SelectListItem> YearDropDown { get; set; }
        public string Year { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string ProcessingMessage { get; set; }
        public IUserDetail User { get; set; }
        public bool IsOpen { get; set; }
    }
}
