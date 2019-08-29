
using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Queries
{
    internal static class EmployeeRewardQueries
    {
        /// <summary>
        /// Gets the employee reward by employee identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IEmployeeReward> getEmployeeRewardByEmployeeId(HRMSEntities db, int employeeId)
        {
            var result = (from d in db.EmployeeRewards
                          join s in db.Rewards on d.RewardId equals s.RewardId
                          join r in db.Employees on d.EmployeeId equals r.EmployeeId
                          join w in db.Companies on d.CompanyId equals w.CompanyId
                          where d.EmployeeId.Equals(employeeId)
                          select new EmployeeRewardModel
                          {
                              EmployeeRewardId = d.EmployeeRewardId,
                              CompanyId=d.CompanyId,
                              EmployeeId=d.EmployeeId,
                              RewardId=d.RewardId,
                              DateCreated = d.DateCreated,
                              IsActive=d.IsActive,
                              companyName = w.CompanyName,
                              employeeName = r.FirstName + "" + r.LastName,
                              rewardName = s.RewardName
                              
                          }).ToList();
            return result;
        }
    }
}
