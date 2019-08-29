using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IPayrollEmployeeDeduction
    {
        int PayrollEmployeeDeductionId { get; set; }
        int PayrollId { get; set; }
        int EmployeeDeductionId { get; set; }
        string DeductionName { get; set; }
        decimal Amount { get; set; }
        int CompanyId { get; set; }
        string CompanyName { get; set; }
        DateTime DateCreated { get; set; }
        bool IsActive { get; set; }
    }
}
