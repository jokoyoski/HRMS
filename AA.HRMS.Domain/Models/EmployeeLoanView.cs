using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IEmployeeLoanView" />
    public class EmployeeLoanView : IEmployeeLoanView
    {
        public EmployeeLoanView()
        {
            this.CompanyDropDown = new List<SelectListItem>();
            this.EmployeeDropDown = new List<SelectListItem>();
            this.LoanDropDown = new List<SelectListItem>();
        }

        public int EmployeeLoanId { get; set; }

        public int EmployeeId { get; set; }

        public int LoanId { get; set; }

        public IList<SelectListItem> CompanyDropDown { get; set; }

        public IList<SelectListItem> EmployeeDropDown { get; set; }

        public IList<SelectListItem> LoanDropDown { get; set; }

        public int Tenure { get; set; }

        public int CompanyId { get; set; }

        public string LoanName { get; set; }

        public decimal LoanAmount { get; set; }

        public DateTime? AgreedDate { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime ExpectedDate { get; set; }

        public bool IsActive { get; set; }
          
        public string ProcessingMessage { get; set; }
      
        public string Reason { get; set; }

        public bool? IsApproved { get; set; }

        public string HRComment { get; set; }

        public DateTime? DisburstDate { get; set; }

        public string URL { get; set; }

        public decimal? InterestRate { get; set; }

        public int PeriodRemain { get; set; }

    }
}
