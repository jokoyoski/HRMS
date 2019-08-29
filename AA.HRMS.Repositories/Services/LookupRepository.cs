using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AA.HRMS.Repositories.Services
{
    public class LookupRepository : ILookupRepository
    {
        
        private readonly IDbContextFactory dbContextFactory;
        
        public LookupRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Gets the about us source collection.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAboutUsSourceCollection</exception>
        public IList<IHowSource> GetAboutUsSourceCollection()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getAboutUsSourceCollection(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAboutUsSourceCollection", e);
            }
        }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetResult</exception>
        public IList<IResult> GetResult()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getResult(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetResult", e);
            }
        }
        
        /// <summary>
        /// Gets the gender collection.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetGenderCollection</exception>
        public IList<IYourGender> GetGenderCollection()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getGenderCollection(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetGenderCollection", e);
            }
        }
       
        /// <summary>
        /// Gets the department us source collection
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository DepartmentCollection</exception>
        public IList<IDepartment> GetDepartmentCollectionByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getDepartmentCollectionByCompanyId(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetDepartmentCollectionByCompanyId", e);
            }
        }

        /// <summary>
        /// Gets the department collection.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository DepartmentCollection</exception>
        public IList<IDepartment> GetDepartmentCollection()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getDepartmentCollection(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository DepartmentCollection", e);
            }
        }

        /// <summary>
        /// Gets the award collection.
        /// </summary>
        /// <param name="awardId">The award identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository AwardCollection</exception>
        public IList<IAward> GetAwardCollection(int awardId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.awardCollection(dbContext, awardId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository AwardCollection", e);
            }
        }

        /// <summary>
        /// Gets the company collection.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetCompanyCollection</exception>
        public IList<ICompanyDetail> GetCompanyCollection()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getCompanyCollection(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                var a = e;

                throw new ApplicationException("Repository GetCompanyCollection", e);
            }
        }

        /// <summary>
        /// Gets the active company collection.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetActiveCompanyCollection</exception>
        public IList<ICompanyDetail> GetActiveCompanyCollection()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getActiveCompanyCollection(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                var a = e;

                throw new ApplicationException("Repository GetActiveCompanyCollection", e);
            }
        }

        /// <summary>
        /// Gets the job title collection.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository getJobTitleCollection</exception>
        public IList<IJobTitle> GetJobTitleCollectionByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getJobTitleCollectionByCompanyId(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                var a = e;

                throw new ApplicationException("Repository getJobTitleCollection", e);
            }
        }

        /// <summary>
        /// Gets the job title collection.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository getJobTitleCollection</exception>
        public IList<IJobTitle> GetJobTitleCollection()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getJobTitleCollection(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                var a = e;

                throw new ApplicationException("Repository getJobTitleCollection", e);
            }
        }

        /// <summary>
        /// Gets the grades collection.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository getJobTitleCollectiona</exception>
        public IList<IGrade> GetGradesCollectionByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getGradesCollectionByCompanyId(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                var a = e;

                throw new ApplicationException("Repository getGradesCollectionByCompanyId", e);
            }
        }

        /// <summary>
        /// Gets the grades collection.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository getJobTitleCollectiona</exception>
        public IList<IGrade> GetGradesCollection()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getGradesCollection(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                var a = e;

                throw new ApplicationException("Repository getJobTitleCollectiona", e);
            }
        }

        /// <summary>
        /// Gets the industry collection.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository getIndustryCollection</exception>
        /// <exception cref="System.ApplicationException">Repository getIndustryCollection</exception>
        public IList<IIndustry> GetIndustryCollection()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getIndustryCollection(dbContext).ToList();

                    return list;
                }
            }
            catch(Exception e)
            {
                var a = e;

                throw new ApplicationException("Repository getIndustryCollection", e);
            }
        }

        /// <summary>
        /// Gets the experience collection.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository getExperienceCollection</exception>
        /// <exception cref="System.ApplicationException">Repository getExperienceCollection</exception>
        public IList<IExperience> GetExperienceCollection()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getExperienceCollection(dbContext).ToList();

                    return list;
                }
            }
            catch(Exception e)
            {
                throw new ApplicationException("Repository getExperienceCollection", e);
            }
        }

        /// <summary>
        /// Gets the benefit by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetBenefitByCompanyId</exception>
        public IList<IBenefit> GetBenefitByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getBenefitByCompanyId(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetBenefitByCompanyId", e);
            }
        }

        /// <summary>
        /// Gets all year.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Lookup repository GetAllYear</exception>
        public IList<IYear> GetAllYears()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getYear(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Lookup repository GetAllYear", e);
            }
        }

        /// <summary>
        /// Gets all months.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Lookup Repository GEtAllMOnth</exception>
        public IList<IMonth> GetAllMonths()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getMonth(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Lookup Repository GEtAllMOnth", e);
            }
        }

        /// <summary>
        /// Gets the employee loan by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get EmployeeLoan by CompanyId</exception>
        public IList<IEmployeeLoan> GetEmployeeLoanByEmployeeId(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getEmployeeLoanByEmployeeId(dbContext, employeeId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get EmployeeLoan by CompanyId", e);
            }
        }

        /// <summary>
        /// Gets the employee loan by employee identifier period zero.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get EmployeeLoan by CompanyId</exception>
        public IList<IEmployeeLoan> GetEmployeeLoanByEmployeeIdPeriodZero(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getEmployeeLoanByEmployeeIdPeriodZero(dbContext, employeeId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get EmployeeLoan by CompanyId", e);
            }
        }

        /// <summary>
        /// Gets the employee reward by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Gt EmployeeReward by CompanyId</exception>
        public IList<IEmployeeReward> GetEmployeeRewardByEmployeeId(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getEmployeeRewardByEmployeeId(dbContext, employeeId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get EmployeeReward by CompanyId", e);
            }
        }

        /// <summary>
        /// Gets the employee reward list by employee identifier.
        /// </summary>
        /// <param name="employeeRewardId">The employee reward identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get EmployeeReward by CompanyId</exception>
        public IList<IEmployeeReward> getEmployeeRewardListByEmployeeId(int employeeRewardId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getEmployeeRewardListByEmployeeId(dbContext, employeeRewardId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get EmployeeReward by CompanyId", e);
            }
        }

        /// <summary>
        /// Gets the employee by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Employee by CompanyId</exception>
        public IList<IEmployee> GetEmployeeByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getEmployeeByCompanyId(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Employee by CompanyId", e);
            }
        }

        /// <summary>
        /// Gets the loan by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Loan By CompanyId</exception>
        public IList<ILoan> GetLoan()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getLoanByCompanyId(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Loan By CompanyId", e);
            }
        }

        /// <summary>
        /// Gets the level by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Loan By CompanyId</exception>
        public IList<ILevel> GetLevelByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getLevelByCompanyId(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Level By CompanyId", e);
            }
        }

        /// <summary>
        /// Gets the reward by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Level By CompanyId</exception>
        public IList<IReward> GetRewardByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getRewardByCompanyId(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Level By CompanyId", e);
            }
        }

        /// <summary>
        /// Gets the deduction by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Level By CompanyId</exception>
        public IList<IDeduction> GetDeductionByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getDeductionByCompanyId(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Level By CompanyId", e);
            }
        }

        /// <summary>
        /// Gets the religion collection.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetReligionCollection</exception>
        public IList<IReligion> GetReligionCollection()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getReligionCollection(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetReligionCollection", e);
            }
        }

        /// <summary>
        /// Gets the marital status collection.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetMaritalStatusCollection</exception>
        public IList<IMaritalStatus> GetMaritalStatusCollection()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getMaritalStatusCollection(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetMaritalStatusCollection", e);
            }
        }

        /// <summary>
        /// Gets the application role.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">GetAppRole</exception>
        public IList<IAppRole> GetAppRole()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getAppRole(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("GetAppRole", e);
            }
        }

        /// <summary>
        /// Gets the user application role.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">GetUserAppRole</exception>
        public IList<IUserAppRole> GetUserAppRole()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getUserAppRole(dbContext).ToList();

                    return list;
                }
            }
            catch(Exception e)
            {
                throw new ArgumentNullException("GetUserAppRole", e);
            }

        }

        /// <summary>
        /// Gets the user application role by username.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">GetUsErAppRoleByUsername</exception>
        public IList<IUserAppRole> GetUserAppRoleByUsername(string userName)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.GetUserAppRoleByUsername(dbContext, userName).ToList();

                    return list;
                }
            }
            catch(Exception e)
            {
                throw new ArgumentNullException("GetUsErAppRoleByUsername", e);
            }
        }
        
        /// <summary>
        /// Getusers the aoo role by role idand username.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="AppRoleId">The application role identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">GetuserAooRoleByRoleIdandUsername</exception>
        public IUserAppRole GetuserAooRoleByRoleIdandUsername(string userName, int AppRoleId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var userAppRole = LookupQueries.getuserAppRoleByRoleIdandUsername(dbContext, AppRoleId, userName);

                    return userAppRole;
                }
            }catch(Exception e)
            {
                throw new ArgumentNullException("GetuserAooRoleByRoleIdandUsername", e);
            }
        }
        
        /// <summary>
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Trainging By CompanyId</exception>
        /// a method that call query for list of training by company
        public IList<ITraining> GetTrainingByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getTrainingByCompanyId(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Trainging By CompanyId", e);
            }
        }

        /// <summary>
        /// Gets the training request by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Trainging By CompanyId</exception>
        public IList<IEmployeeTrainingModel> GetTrainingRequestByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getTrainingRequestByCompanyId(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Trainging By CompanyId", e);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Trainging By CompanyId</exception>
        public IList<ITraining> GetTrainingInCalendarByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getTrainingInCalendarByCompanyId(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Trainging By CompanyId", e);
            }
        }


        /// <summary>
        /// Gets the discipline by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Trainging By CompanyId</exception>
        public IList<IDiscipline> GetDisciplineByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getDisciplineByCompanyID(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Trainging By CompanyId", e);
            }
        }

        /// <summary>
        /// Gets the discipline by company idand employee identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Get Trainging By CompanyId</exception>
        public IList<IDiscipline> GetDisciplineByCompanyIdandEmployeeId(int companyId, int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getDisciplineByCompanyIdandEmployeeId(dbContext, companyId, employeeId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Trainging By CompanyId", e);
            }
        }

        /// <summary>
        /// Gets the discipline by company idand employee identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Trainging By CompanyId</exception>
        public IList<IDiscipline> GetDisciplineByCompanyIdandEmployeeId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getDisciplineByCompanyIdandEmployeeId(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Trainging By CompanyId", e);
            }
        }

        /// <summary>
        /// Gets the type of exit by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">GetTypeOfExitByCompanyId {0}</exception>
        public IList<ITypeOfExit> GetTypeOfExitByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getTypeOfExitByCompanyId(dbContext, companyId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("GetTypeOfExitByCompanyId {0}", e);
            }
        }

        /// <summary>
        /// Gets all tax.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">GetTypeOfExitByCompanyId {0}</exception>
        public IList<ITax> GetAllTax()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getTaxes(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("GetTypeOfExitByCompanyId {0}", e);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Get TraingingNeedAnalysis By CompanyId</exception>
        public IList<ITrainingNeedAnalysis> GetTrainingNeedAnalysisByCompanyID(int companyId)
        {
            
                try
                {
                    using (
                        var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                    {
                        var list = LookupQueries.GetTrainingNeedAnalysisByCompanyID(dbContext, companyId).ToList();

                        return list;
                    }
                }
                catch (Exception e)
                {
                    throw new ArgumentNullException("Get TraingingNeedAnalysis By CompanyId", e);
                }
            
        }

        /// <summary>
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get EmployeeExit By CompanyId</exception>
        public IList<IEmployeeExit> GetEmployeeExitByCompanyID(int companyId)
        {

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.GetEmployeeExitByCompanyID(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get EmployeeExit By CompanyId", e);
            }

        }
        
        /// <summary>
        /// Gets the evaluationratings.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Training Evaluation By ID</exception>
        public IList<ITrainingEvaluationRating> GetEvaluationratings()
        {
            try
            {
                using (
                    var dbcontext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getEvaluationRatingById(dbcontext).ToList();
                    return list;
                }
            }catch (Exception e)
            {
                throw new ArgumentNullException("Get Training Evaluation By ID", e);
            }
        }

        /// <summary>
        /// Gets the training report by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get TraingingNeedAnalysis By CompanyId</exception>
        public IList<ITrainingReport> GetTrainingReportByCompanyID(int companyId)
        {

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.GetTrainingReportByCompanyID(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get TraingingNeedAnalysis By CompanyId", e);
            }

        }

        /// <summary>
        /// </summary>
        /// <param name="trainingReportId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get TraingingNeedAnalysis By CompanyId</exception>
        public IList<ITrainingReport> GetTrainingReportByReportID(int trainingReportId)
        {

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.GetTrainingReportByReportID(dbContext, trainingReportId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get TraingingNeedAnalysis By CompanyId", e);
            }

        }

        /// <summary>
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Query By CompanyId</exception>
        public IList<IQuery> GetQueryByCompanyId(int companyId)
        {

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getQueryByCompanyId(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Query By CompanyId", e);
            }

        }
        
        /// <summary>
        /// Gets the training status.
        /// </summary>
        /// <returns></returns>
        public IList<ITrainingStatus> GetTrainingStatus()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = LookupQueries.getTrainingStatus(dbContext).ToList();
                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Training Status {0}", e);
            }
        }

        /// <summary>
        /// Gets the frequency of distribution by company identifier.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Get Frequency Of Distribution By CompanyId {0}</exception>
        public IList<IFrequencyOfDeliveryModel> GetFrequencyOfDistribution()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = LookupQueries.getFrequencyOfDeliveryByCompanyId(dbContext).ToList();
                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Frequency Of Distribution By CompanyId {0}", e);
            }
        }

        /// <summary>
        /// Gets the currency.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Get Currency {0}</exception>
        public IList<ICurrency> GetCurrency()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = LookupQueries.getCurrency(dbContext).ToList();
                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Currency {0}", e);
            }
        }

        /// <summary>
        /// Gets the method of delivery.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Get Method Of Delivery {0}</exception>
        public IList<IMethodOfDelivery> GetMethodOfDelivery()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = LookupQueries.getMethodOfDelivery(dbContext).ToList();
                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Method Of Delivery {0}", e);
            }
        }

        /// <summary>
        /// Gets the query status.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Method Of Delivery {0}</exception>
        public IList<IQueryStatus> GetQueryStatus()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = LookupQueries.getQueryStatus(dbContext).ToList();
                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Method Of Delivery {0}", e);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetSuspensionByCompanyId</exception>
        public IList<ISuspension> GetSuspensionByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getSuspensionByCompanyId(dbContext, companyId).ToList(); ;

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetSuspensionByCompanyId", e);
            }
        }

        /// <summary>
        /// Gets the appraisal by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAppraisalByCompanyId</exception>
        public IList<IAppraisal> GetAppraisalByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getAppraisalByCompanyId(dbContext, companyId).ToList(); ;

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAppraisalByCompanyId", e);
            }
        }

        /// <summary>
        /// Gets the action taken.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Method Of Delivery {0}</exception>
        public IList<IActionTaken> GetActionTaken()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = LookupQueries.getActionTaken(dbContext).ToList();
                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Method Of Delivery {0}", e);
            }
        }

        /// <summary>
        /// Gets the appraisal period.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Method Of Delivery {0}</exception>
        public IList<IAppraisalPeriod> GetAppraisalPeriod()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = LookupQueries.getAppraisalPeriod(dbContext).ToList();

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Method Of Delivery {0}", e);
            }
        }

        /// <summary>
        /// Gets the country collection.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Get Method Of Delivery {0}</exception>
        public IList<ICountry> GetCountryCollection()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = LookupQueries.getCountryCollection(dbContext).ToList();

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Method Of Delivery {0}", e);
            }
        }
        
        /// <summary>
        /// Gets the state collection.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Get Method Of Delivery {0}</exception>
        public IList<IState> GetStateCollection()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = LookupQueries.getStateCollection(dbContext).ToList();

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Method Of Delivery {0}", e);
            }
        }

        /// <summary>
        /// getEmployeeDeductionByCompanyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Error Ocurred" + "Get Employee deduction</exception>
        public IList<IEmployeeReward> getEmployeeDeductionByCompanyId(int companyId)
        {
            try
            {
               using ( 
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = LookupQueries.getEmployeeRewardByCompanyId(dbContext, companyId).ToList();

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Error Ocurred" + "Get Employee deduction", e);
            }
             
        }

        /// <summary>
        /// get employee Deduction
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Employee Deduction by CompanyId</exception>
        public IList<IEmployeeDeduction> GetEmployeeDeductionByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getEmployeeDeductionByCompanyId(dbContext, companyId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Employee Deduction by CompanyId", e);
            }
        }

        /// <summary>
        /// Gets all deduction by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Employee Deduction by CompanyId</exception>
        public IList<IDeduction> GetAllDeductionByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getAllDeductionByCompanyId(dbContext, companyId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Employee Deduction by CompanyId", e);
            }
        }
        
        /// <summary>
        /// Gets the employment types.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Employment Types {0}</exception>
        public IList<IEmploymentType> GetEmploymentTypes()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LookupQueries.getEmploymentTypes(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Employment Types {0}", e);
            }
        }

        /// <summary>
        /// Gets the next of kin.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Method Of Delivery {0}</exception>
        public IList<INextOfKin> GetNextOfKin()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = LookupQueries.getNextOfKin(dbContext).ToList();

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Method Of Delivery {0}", e);
            }
        }

        /// <summary>
        /// Gets the next of kin description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetApconDescriptionByValue</exception>
        public INextOfKin GetNextOfKinDescriptionByValue(string description)
        {
            try
            {
                var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS);
                {

                    var aRecord = LookupQueries.getNextofKinDescriptionByValue(dbContext, description);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetApconDescriptionByValue", e);
            }

        }

        /// <summary>
        /// Gets the next of kin by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Method Of Delivery {0}</exception>
        public INextOfKin GetNextOfKinById(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = LookupQueries.getNextOfKinById(dbContext, employeeId);

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Method Of Delivery {0}", e);
            }
        }

        /// <summary>
        /// Gets the next of kin list by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Method Of Delivery {0}</exception>
        public IList<INextOfKin> GetNextOfKinListById(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = LookupQueries.getNextOfKinListById(dbContext, employeeId).ToList();

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Method Of Delivery {0}", e);
            }
        }

        /// <summary>
        /// Gets the beneficiaries description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetBeneficiariesDescriptionByValue</exception>
        public IBeneficiariesModel GetBeneficiariesDescriptionByValue(string description)
        {
            try
            {
                var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS);
                {

                    var aRecord = LookupQueries.getBeneficiariesDescriptionByValue(dbContext, description);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetBeneficiariesDescriptionByValue", e);
            }

        }

        /// <summary>
        /// Gets the beneficiaries list by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetBeneficiariesDescriptionByValue</exception>
        public IList<IBeneficiariesModel> GetBeneficiariesListById(int employeeId)
        {
            try
            {
                var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS);
                {

                    var aRecord = LookupQueries.GetBeneficiariesById(dbContext, employeeId).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetBeneficiariesDescriptionByValue", e);
            }

        }

        /// <summary>
        /// Gets the beneficiaries by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Method Of Delivery {0}</exception>
        public IBeneficiariesModel GetBeneficiariesById(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = LookupQueries.getBeneficiariesById(dbContext, employeeId);

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Method Of Delivery {0}", e);
            }
        }

        /// <summary>
        /// Gets the emergency contact description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetEmergencyContactDescriptionByValue</exception>
        public IEmergency GetEmergencyContactDescriptionByValue(string description)
        {
            try
            {
                var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS);
                {

                    var aRecord = LookupQueries.getEmergencyContactDescriptionByValue(dbContext, description);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetEmergencyContactDescriptionByValue", e);
            }

        }

        /// <summary>
        /// Gets the emergency contact description by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Method Of Delivery {0}</exception>
        public IEmergency GetEmergencyContactDescriptionById(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = LookupQueries.getEmergencyContactDescriptionById(dbContext, employeeId);

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Method Of Delivery {0}", e);
            }
        }

        /// <summary>
        /// Gets the employee emergency contact by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Method Of Delivery {0}</exception>
        public IList<IEmergency> GetEmployeeEmergencyContactById(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = EmployeeQueries.GetEmployeeEmergencyContactById(dbContext, employeeId).ToList();

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Method Of Delivery {0}", e);
            }
        }
        
        /// <summary>
        /// Gets the children information description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetChildrenInformationDescriptionByValue</exception>
        public IChildrenModel GetChildrenInformationDescriptionByValue(string description)
        {
            try
            {
                var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS);
                {

                    var aRecord = LookupQueries.getChildrenInformationDescriptionByValue(dbContext, description);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetChildrenInformationDescriptionByValue", e);
            }

        }

        /// <summary>
        /// Gets the children information description by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Method Of Delivery {0}</exception>
        public IChildrenModel GetChildrenInformationDescriptionById(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = LookupQueries.getChildrenInformationDescriptionById(dbContext, employeeId);

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Method Of Delivery {0}", e);
            }
        }

        /// <summary>
        /// Gets the children information list by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Method Of Delivery {0}</exception>
        public IList<IChildrenModel> GetChildrenInformationListById(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = LookupQueries.GetChildrenInformationListById(dbContext, employeeId).ToList();

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Method Of Delivery {0}", e);
            }
        }

        /// <summary>
        /// Gets the calendar events.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Calendar Events {0}</exception>
        public IList<ICalendarEvent> GetCalendarEvents()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = LookupQueries.getCalendarEvents(dbContext).ToList();

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Calendar Events {0}", e);
            }
        }

        /// <summary>
        /// Gets the calendar events by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Calendar Events {0}</exception>
        public IList<ICalendarEvent> GetCalendarEventsByUserId(int userId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = LookupQueries.getCalendarEventsByUserId(dbContext, userId).ToList();

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Calendar Events {0}", e);
            }
        }

        /// <summary>
        /// Gets the calendar event.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Calendar Event {0}</exception>
        public ICalendarEvent GetCalendarEvent(DateTime start, DateTime end)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = LookupQueries.getCalendarEvent(dbContext, start, end);

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Calendar Event {0}", e);
            }
        }

        /// <summary>
        /// Gets the days.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Days {0}</exception>
        public IList<IDay> GetDays()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = LookupQueries.getDays(dbContext).ToList();

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Days {0}", e);
            }
        }

        /// <summary>
        /// Gets the weeks.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Days {0}</exception>
        public IList<IWeek> GetWeeks()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = LookupQueries.getWeeks(dbContext).ToList();

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Weeks {0}", e);
            }
        }

        /// <summary>
        /// Gets the schedules.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Weeks {0}</exception>
        public IList<ISchedule> GetSchedules()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = LookupQueries.getSchedules(dbContext).ToList();

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Weeks {0}", e);
            }
        }

        /// <summary>
        /// Gets the schedules by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Weeks {0}</exception>
        public IList<ISchedule> GetSchedulesByUserId(int userId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = LookupQueries.getSchedulesByCompanyId(dbContext, userId).ToList();

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Weeks {0}", e);
            }
        }
    }
}
