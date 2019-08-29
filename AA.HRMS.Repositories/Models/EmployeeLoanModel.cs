using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    public class EmployeeLoanModel : IEmployeeLoan
    {
        public int EmployeeLoanId { get; set; }
        public int EmployeeId { get; set; }
        public int LoanTypeId { get; set; }
        public decimal Amount { get; set; }
        public string Reason { get; set; }
        public int CompanyId { get; set; }
        public int Tenure { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
        public bool? IsApproved { get; set; }
        public string HRComment { get; set; }
        public DateTime? DateDisburst { get; set; }
        public DateTime? AgreedDate { get; set; }
        public string EmployeeName { get; set; }
        public string CompanyName { get; set; }
        public string LoanName { get; set; }
        public DateTime ExpectedDate { get; set; }
        public decimal? InterestRate { get; set; }
        public int PeriodRemain { get; set; }
        public decimal MonthlyDeduction { get; set; }
    }
}
