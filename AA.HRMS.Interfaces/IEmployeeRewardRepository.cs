using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IEmployeeRewardRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeRewardViewModel"></param>
        /// <returns></returns>
        string saveEmployeeReward(IEmployeeRewardViewModel employeeRewardViewModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeRewardId"></param>
        /// <returns></returns>
        IList<IEmployeeReward> GetEmployeeRewardByEmployeeId(int employeeId);
    }
}
