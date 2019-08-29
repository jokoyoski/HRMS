using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Factories;
using AA.HRMS.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IEmployeeRewardRepository" />
    public class EmployeeRewardRepository : IEmployeeRewardRepository
    {

        private readonly IDbContextFactory dbContextFactory;

        public EmployeeRewardRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory ?? new DbContextFactory(null);
        }
        /// <summary>
        /// </summary>
        /// <param name="employeeRewardViewModel"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeRewardViewModel</exception>
        public string saveEmployeeReward(IEmployeeRewardViewModel employeeRewardViewModel)
        {
            if (employeeRewardViewModel == null)
            {
                throw new ArgumentNullException(nameof(employeeRewardViewModel));
            }

            var result = string.Empty;
            var reward = new EmployeeReward
            {
                RewardId = employeeRewardViewModel.RewardId,
                CompanyId = employeeRewardViewModel.CompanyId,
                EmployeeId = employeeRewardViewModel.EmployeeId,
                IsActive = true,
                DateCreated = DateTime.Now,
            };
            try
            {
                using (

                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.EmployeeRewards.Add(reward);
                    dbContext.SaveChanges();
                }

            }
            catch (Exception e)
            {
                result = string.Format("SaveEmployeeReward(s) - {0} , {1}", e.Message,
                                   e.InnerException != null ? e.InnerException.Message : "");
            }
            return result;
        }
        /// <summary>
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository employeeRewardId</exception>
        public IList<IEmployeeReward> GetEmployeeRewardByEmployeeId(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord =
                        EmployeeRewardQueries.getEmployeeRewardByEmployeeId(dbContext, employeeId).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository employeeRewardId", e);
            }

        }
    }
}
