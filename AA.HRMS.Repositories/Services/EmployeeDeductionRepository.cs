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
    public class EmployeeDeductionRepository : IEmployeeDeductionRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeDeductionRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public EmployeeDeductionRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory ?? new DbContextFactory(null); ;
        }

        /// <summary>
        /// Gets the employee deduction by employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Employee Deduction</exception>
        public IEmployeeDeduction GetEmployeeDeductionByEmployeeId(int employeeId, int deductionId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = EmployeeDeductionQueries.getEmployeeDeductionByEmployeeId(dbContext, employeeId, deductionId);
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Employee Deduction", e);
            }
        }

        /// <summary>
        /// Gets the employee deduction.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Employee Deduction</exception>
        public IList<IDeduction> GetEmployeeDeductionByEmployeeId(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = EmployeeDeductionQueries.getEmployeeDeductionByEmployeeId(dbContext, employeeId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Employee Deduction", e);
            }
        }


        public IDeduction GetAllEmployeeDeductionByEmployeeId(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = EmployeeDeductionQueries.getAllEmployeeDeductionByEmployeeId(dbContext, employeeId);
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Employee Deduction", e);
            }
        }

        /// <summary>
        /// Gets the employee deduction by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Employee Deduction By CompanyId</exception>
        public IList<IEmployeeDeduction> GetEmployeeDeductionByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = EmployeeDeductionQueries.getEmployeeDeductionByCompanyId(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Employee Deduction By CompanyId", e);
            }
        }

        /// <summary>
        /// Saves the employee deduction information.
        /// </summary>
        /// <param name="employeeDeduction">The employee deduction.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeDeduction</exception>
        public string SaveEmployeeDeductionInfo(IEmployeeDeductionView employeeDeduction)
        {
            if (employeeDeduction == null)
            {
                throw new ArgumentNullException(nameof(employeeDeduction));
            }

            string result = string.Empty;

            var newReocord = new EmployeeDeduction
            {
                EmployeeId = employeeDeduction.EmployeeId,
                CompanyId = employeeDeduction.CompanyId,
                DeductionId = employeeDeduction.DeductionId,
                EmployeeDeductionId = employeeDeduction.EmployeeDeductionId,
                DateCreated = DateTime.UtcNow,
                IsActive = true,
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.EmployeeDeductions.Add(newReocord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save  Deduction info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }



        public string SaveDeductionInfo(IDeductionViewModel employeeDeduction)
        {
            if (employeeDeduction == null)
            {
                throw new ArgumentNullException(nameof(employeeDeduction));
            }

            string result = string.Empty;

            var newReocord = new Deduction
            {
                EmployeeId = employeeDeduction.EmployeeId,
                CompanyId = employeeDeduction.CompanyId,
                DeductionId = employeeDeduction.DeductionId,
                DeductionName = employeeDeduction.DeductionName,
                DeductionAmount = employeeDeduction.DeductionAmount,
                DateStarted = employeeDeduction.DateStarted,
                IsTerminated = false,
                DateCreated = DateTime.UtcNow,
                IsActive = true,
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Deductions.Add(newReocord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save  Deduction info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }



        /// <summary>
        /// Saves the delete employee deduction.
        /// </summary>
        /// <param name="employeeDeductionId">The employee deduction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeDeductionId</exception>
        public string SaveDeleteEmployeeDeduction(IDeductionViewModel deductionViewModel)
        {
            if(deductionViewModel == null)
            {
                throw new ArgumentNullException(nameof(deductionViewModel));
            }

            var result = string.Empty;

            try
            {
                using (var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var employeeDeduction = dbContext.Deductions.SingleOrDefault(p=>p.DeductionId.Equals(deductionViewModel.DeductionId));
                    employeeDeduction.DateTerminated = DateTime.Now;
                    employeeDeduction.IsTerminated = true;
                    //employeeDeduction.IsActive = false;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Delete Employee Deduction - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets the employee deduction.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">An Error Occurred" + "Get Employee Deduction By employeeId</exception>
        public IList<IEmployeeDeduction> GetEmployeeDeduction (int employeeId)
        {
            try
            {
                using (
                    var dbContext  = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = EmployeeDeductionQueries.getDeductionByEmployeeId(dbContext, employeeId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("An Error Occurred" + "Get Employee Deduction By employeeId", e);
            }
        }

        /// <summary>
        /// Gets the employee deduction by employee deduction identifier.
        /// </summary>
        /// <param name="employeeDeductionId">The employee deduction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// employeeDeductionId
        /// or
        /// Get Employee Deduction By Employee DeductionId
        /// </exception>
        public IEmployeeDeduction GetEmployeeDeductionByEmployeeDeductionId(int employeeDeductionId)
        {
            if (employeeDeductionId <= 0)
            {
                throw new ArgumentNullException(nameof(employeeDeductionId));
            }

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = EmployeeDeductionQueries.getEmployeeDeductionByEmployeeDeductionId(dbContext, employeeDeductionId);

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Employee Deduction By Employee DeductionId", e);
            }
        }


        public IList<IDeduction> GetEmployeeDeductionListByEmployeeDeductionId(int employeeDeductionId)
        {
            if (employeeDeductionId < 0)
            {
                throw new ArgumentNullException(nameof(employeeDeductionId));
            }

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = EmployeeDeductionQueries.getEmployeeDeductionListByEmployeeDeductionId(dbContext, employeeDeductionId).ToList();

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Employee Deduction By Employee DeductionId", e);
            }
        }


        /// <summary>
        /// Gets the employee deduction by identifier.
        /// </summary>
        /// <param name="employeeDeductionId">The employee deduction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// employeeDeductionId
        /// or
        /// Get Employee Deduction By Id
        /// </exception>
        public IList<IEmployeeDeduction> GetEmployeeDeductionById(int employeeDeductionId)
        {
            if (employeeDeductionId <= 0)
            {
                throw new ArgumentNullException(nameof(employeeDeductionId));
            }

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = EmployeeDeductionQueries.getEmployeeDeductionById(dbContext, employeeDeductionId).ToList();

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Employee Deduction By Id", e);
            }
        }

        /// <summary>
        /// Gets the employee deduction by deduction identifier.
        /// </summary>
        /// <param name="deductionId">The deduction identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// deductionId
        /// or
        /// Get Employee Deduction By Id
        /// </exception>
        public IEmployeeDeduction GetEmployeeDeductionByDeductionId(int deductionId)
        {
            if (deductionId <= 0)
            {
                throw new ArgumentNullException(nameof(deductionId));
            }

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = EmployeeDeductionQueries.getEmployeeDeductionByDeductionId(dbContext, deductionId);

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Employee Deduction By Id", e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public IList<IEmployeeDeduction> GetDeductionByCompanyId(int CompanyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = EmployeeDeductionQueries.getDeductionByCompanyId(dbContext, CompanyId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Company Deduction", e);
            }






        }
    }
}

