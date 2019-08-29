using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IPayrollEmployeeLoan
    {
        int PayrollEmployeeLoanId { get; set; }
        int PayrollId { get; set; }
        int EmployeeLoanId { get; set; }
        string LoanTypeName { get; set; }
        decimal Amount { get; set; }
        int CompanyId { get; set; }
        string CompanyName { get; set; }
        bool IsActive { get; set; }
        DateTime DateCreated { get; set; }
        decimal InterestRate { get; set; }
        int Tenure { get; set; }
        decimal MonthlyDeduction { get; set; }
    }
}
