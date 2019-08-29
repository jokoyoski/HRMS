using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Services
{
    public class ExitManagementRepository : IExitManagementRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExitManagementRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public ExitManagementRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Gets the employee exit by employee identifier.
        /// </summary>
        /// <param name="employeeeId">The employeee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">GetEmployeeExitByEmployeeId</exception>
        public IEmployeeExit GetEmployeeExitByEmployeeId(int employeeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = ExitManagementQueries.getEmployeeExitByEmployeeId(dbContext, employeeeId);

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("GetEmployeeExitByEmployeeId", e);
            }
        }

        /// <summary>
        /// Gets all my employee exit.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAllMyEmployeeExit</exception>
        public IList<IEmployeeExit> GetAllMyEmployeeExit(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = ExitManagementQueries.getAllMyEmployeeExit(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAllMyEmployeeExit", e);
            }
        }

        /// <summary>
        /// Saves the employee exit information.
        /// </summary>
        /// <param name="employeeExitInfo">The employee exit information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeExitInfo</exception>
        public string SaveEmployeeExitInfo(IEmployeeExitView employeeExitInfo)
        {

            if(employeeExitInfo == null)
            {
                throw new ArgumentNullException(nameof(employeeExitInfo));
            }

            var result = string.Empty;

            var newRecord = new EmployeeExit
            {
                CompanyId = employeeExitInfo.CompanyId,
                EmployeeId = employeeExitInfo.EmployeeId, 
                DateCreated = DateTime.Now,
                IsActive = true,
                Reason = employeeExitInfo.Reason,
                Interviewer = employeeExitInfo.Interviewer,
                TypeOfExitId = employeeExitInfo.TypeOfExitId,
                InterviewDate = employeeExitInfo.InterviewDate,
                DateRequested = employeeExitInfo.DateRequested,
                ExitInterViewSummary = employeeExitInfo.ExitInterViewSummary
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var employee = dbContext.Employees.SingleOrDefault(p => p.EmployeeId.Equals(employeeExitInfo.EmployeeId));

                    employee.IsExit = true;

                    dbContext.EmployeeExits.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveEmployeeExitInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
    }
}
