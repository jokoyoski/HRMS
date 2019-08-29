using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IPayrollEmployeeReward
    {
        int PayrollEmployeeRewardId { get; set; }
        int PayrollId { get; set; }
        int EmployeeRewardId { get; set; }
        string RewardName { get; set; }
        decimal Amount { get; set; }
        int CompanyId { get; set; }
        bool IsActive { get; set; }
        DateTime DateCreated { get; set; }
        string CompanyName { get; set; }
    }
}
