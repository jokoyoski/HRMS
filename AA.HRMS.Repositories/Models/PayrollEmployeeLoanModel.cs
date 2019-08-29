
using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    public class PayrollEmployeeLoanModel : IPayrollEmployeeLoan
    {
        public int PayrollEmployeeLoanId { get; set; }
        public int PayrollId { get; set; }
        public int EmployeeLoanId { get; set; }
        public decimal Amount { get; set; }
        public string LoanTypeName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal InterestRate { get; set; }
        public int Tenure { get; set; }
        public decimal MonthlyDeduction { get; set; }
    }
}
