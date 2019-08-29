using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IEmployeeLoan
    {
         int EmployeeLoanId { get; set; }
         int EmployeeId { get; set; }
         int LoanTypeId { get; set; }
         decimal Amount { get; set; }
         string Reason { get; set; }
        int Tenure { get; set; }
        int CompanyId { get; set; }
         DateTime DateCreated { get; set; }
         bool IsActive { get; set; }
         bool? IsApproved { get; set; }
         string HRComment { get; set; }
         DateTime? DateDisburst { get; set; }
         DateTime? AgreedDate { get; set; }
        string EmployeeName { get; set; }
        string CompanyName { get; set; }
        string LoanName { get; set; }
        DateTime ExpectedDate { get; set; }
        decimal? InterestRate { get; set; }
        int PeriodRemain { get; set; }
        decimal MonthlyDeduction { get; set; }
    }
}
