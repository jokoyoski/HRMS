using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface IAnnualAssessingPerformanceView
    {
         int AnnualAssessingPerformanceId { get; set; }
        int YearId { get; set; }
        IList<SelectListItem> YearDropDown { get; set; }
        string Year { get; set; }
        int CompanyId { get; set; }
        string CompanyName { get; set; }
         bool IsActive { get; set; }
         DateTime DateCreated { get; set; }
         DateTime? DateModified { get; set; }
         string ProcessingMessage { get; set; }
        IUserDetail User { get; set; }
        bool IsOpen { get; set; }
    }
}
