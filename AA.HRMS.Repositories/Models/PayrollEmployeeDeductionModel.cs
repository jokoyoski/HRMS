using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    public class PayrollEmployeeDeductionModel : IPayrollEmployeeDeduction
    {
        public int PayrollEmployeeDeductionId { get; set; }
        public int PayrollId { get; set; }
        public int EmployeeDeductionId { get; set; }
        public string DeductionName { get; set; }
        public decimal Amount { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
    }
}
