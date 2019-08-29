using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface IEmployeeLoanView
    {

        int EmployeeLoanId { get; set; }

        int EmployeeId { get; set; }

        int LoanId { get; set; }

        int Tenure { get; set; }

        int CompanyId { get; set; }

        string LoanName { get; set; }

        decimal LoanAmount { get; set; }

        DateTime? AgreedDate { get; set; }

        DateTime DateCreated { get; set; }

        bool IsActive { get; set; }

        string ProcessingMessage { get; set; }
        
        IList<SelectListItem> CompanyDropDown { get; set; }

        IList<SelectListItem> EmployeeDropDown { get; set; }

        IList<SelectListItem> LoanDropDown { get; set; }
  
        string Reason { get; set; }

        bool? IsApproved { get; set; }

        DateTime? DisburstDate { get; set; }

        DateTime ExpectedDate { get; set; }

        string HRComment { get; set; }

        string URL { get; set; }

        decimal? InterestRate { get; set; }

        int PeriodRemain { get; set; }
    }
}
