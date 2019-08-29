using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    public class PayrollEmployeeRewardModel : IPayrollEmployeeReward
    {
        public int PayrollEmployeeRewardId { get; set; }
        public int PayrollId { get; set; }
        public int EmployeeRewardId { get; set; }
        public string RewardName { get; set; }
        public decimal Amount { get; set; }
        public int CompanyId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public string CompanyName { get; set; }
    }
}
