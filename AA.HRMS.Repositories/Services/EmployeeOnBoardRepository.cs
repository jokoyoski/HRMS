using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Factories;
using AA.HRMS.Repositories.Queries;

namespace AA.HRMS.Repositories.Services
{
    public class EmployeeOnBoardRepository : IEmployeeOnBoardRepository
    {
        private readonly IDbContextFactory dbContextFactory;
        
        public EmployeeOnBoardRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory ?? new DbContextFactory(null);
        }

        /// <summary>
        /// Gets the on boarder by company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="lastName">The last name.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository Get OnBoarding by Company</exception>
        public IEmployee GetOnBoarderByCompany(int? companyId, string lastName)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = EmployeeOnBoardQueries.getOnBoarderByCompany(dbContext, companyId, lastName);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get OnBoarding by Company", e);
            }
        }

        /// <summary>
        /// Gets the on boarder by email and staff number.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="email">The email.</param>
        /// <param name="staffNumber">The staff number.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository Get OnBoarding by Company</exception>
        public IEmployee GetOnBoarderByEmailAndStaffNumber(int? companyId, string email, string staffNumber)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = EmployeeOnBoardQueries.getOnBoarderByCompanyAndEmailAndStaffNumber(dbContext, companyId, email, staffNumber);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get OnBoarding by Company {0}", e);
            }
        }

        /// <summary>
        /// Gets the employee by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository Get Employee by email {0}</exception>
        public IEmployee GetEmployeeByEmail(string email)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = EmployeeOnBoardQueries.getEmployeeByEmail(dbContext, email);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get Employee by email {0}", e);
            }
        }

        /// <summary>
        /// Saves the Promotion information.
        /// </summary>
        /// <param name="onboardInfo">The onboard information.</param>
        /// <returns></returns>
        public string SavePromotionInfo(IPromotionView promotion)
        {
            if (promotion == null)
            {
                throw new ArgumentNullException(nameof(promotion));
            }

            var result = string.Empty;

            var newpromotion = new Promotion
            {
                EmployeeId = promotion.EmployeeId,
                LevelId = promotion.LevelId,
                GradeId = promotion.GradeId,
                CompanyId = promotion.CompanyId,
                IsActive = true,
                DateCreated = DateTime.Now
            };
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Promotions.Add(newpromotion);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Promotion Info - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Saves the on boarding information.
        /// </summary>
        /// <param name="onboardInfo">The onboard information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onboardInfo</exception>
        public string SaveOnBoardingInfo(IEmployeeOnBoardView onboardInfo)
        {
            if (onboardInfo == null)
            {
                throw new ArgumentNullException(nameof(onboardInfo));
            }

            var result = string.Empty;
            
            var newRecord = new Employee
            {
                CompanyId = onboardInfo.CompanyID,
                EmployeeId = onboardInfo.EmployeeID,
                EmploymentTypeId = onboardInfo.EmploymentTypeId,
                StaffNumber = onboardInfo.StaffNumber,
                LastName = onboardInfo.LastName,
                FirstName = onboardInfo.FirstName,
                MiddleName = onboardInfo.MiddleName,
                Email = onboardInfo.Email,
                LevelId = onboardInfo.LevelID,
                GradeId = onboardInfo.GradeID,
                JobTitleId = onboardInfo.JobTitleID,
                MobileNumber = onboardInfo.MobileNumber,
                PermanentAddress = onboardInfo.PermanentAddress,
                PermanentAddressCity = onboardInfo.PermanentAddressCity,
                PermanentAddressState = onboardInfo.PermanentAddressStateId,
                HomeAddress = onboardInfo.HomeAddress,
                HomeAddressCity = onboardInfo.HomeAddressCity,
                HomeAddressState = onboardInfo.HomeAddressStateId,
                OtherEmail = onboardInfo.OtherEmail,
                Birthday = onboardInfo.Birthday,
                MaritalStatusId = onboardInfo.MaritalStatusId,
                GenderId = onboardInfo.GenderId,
                DateExited = DateTime.Now,
                About = onboardInfo.About,
                SkillSet = onboardInfo.SkillSet,
                SupervisorEmployeeId = onboardInfo.SupervisorEmployeeId,
                SeatingLocation = onboardInfo.SeatingLocation,
                DepartmentId = onboardInfo.DepartmentId,
                MaidenName = onboardInfo.MaidenName,
                PhotoDigitalFileId = onboardInfo.PhotoDigitalFileId,
                ReligionId = onboardInfo.ReligionId,
                Nationality = onboardInfo.NationalityId,
                IsActive = true,
                DateCreated = DateTime.Now,
                IsLocked = false,
                IsExit = false,
                GenderOther = onboardInfo.GenderOther,
                ReligionOther = onboardInfo.ReligionOther,
                IsApproved = true
                
            };
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Employees.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save OnBoarding Info - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets the on boarder by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetOnBoardingById</exception>
        public IEmployee GetOnBoarderById(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord =
                        EmployeeOnBoardQueries.getOnBoardingById(dbContext, employeeId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetOnBoardingById", e);
            }
        }

        /// <summary>
        /// Updates the on boarding information.
        /// </summary>
        /// <param name="onBoardingViewInfo">The on boarding view information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">onBoardingViewInfo</exception>
        public string UpdateOnBoardingInfo(IEmployeeOnBoardView onBoardingViewInfo)
        {
            if (onBoardingViewInfo == null)
                throw new ArgumentNullException(nameof(onBoardingViewInfo));

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var newOnBoarding = dbContext.Employees.Find(onBoardingViewInfo.EmployeeID);
                    
                    newOnBoarding.StaffNumber = onBoardingViewInfo.StaffNumber;
                    newOnBoarding.LastName = onBoardingViewInfo.LastName;
                    newOnBoarding.FirstName = onBoardingViewInfo.FirstName;
                    newOnBoarding.MiddleName = onBoardingViewInfo.MiddleName;
                    newOnBoarding.Email = onBoardingViewInfo.Email;
                    newOnBoarding.MobileNumber = onBoardingViewInfo.MobileNumber;
                    newOnBoarding.PermanentAddress = onBoardingViewInfo.PermanentAddress;
                    newOnBoarding.PermanentAddressCity = onBoardingViewInfo.PermanentAddressCity;
                    newOnBoarding.PermanentAddressState = onBoardingViewInfo.PermanentAddressStateId;
                    newOnBoarding.HomeAddress = onBoardingViewInfo.HomeAddress;
                    newOnBoarding.HomeAddressCity = onBoardingViewInfo.HomeAddressCity;
                    newOnBoarding.HomeAddressState = onBoardingViewInfo.HomeAddressStateId;
                    newOnBoarding.OtherEmail = onBoardingViewInfo.OtherEmail;
                    newOnBoarding.Birthday = onBoardingViewInfo.Birthday;
                    newOnBoarding.MaritalStatusId = onBoardingViewInfo.MaritalStatusId;
                    newOnBoarding.GenderId = onBoardingViewInfo.GenderId;
                    newOnBoarding.About = onBoardingViewInfo.About;
                    newOnBoarding.SkillSet = onBoardingViewInfo.SkillSet;
                    newOnBoarding.SeatingLocation = onBoardingViewInfo.SeatingLocation;
                    newOnBoarding.MaidenName = onBoardingViewInfo.MaidenName;
                    newOnBoarding.ReligionId = onBoardingViewInfo.ReligionId;
                    newOnBoarding.JobTitleId = onBoardingViewInfo.JobTitleID;
                    newOnBoarding.Nationality = onBoardingViewInfo.NationalityId;
                    newOnBoarding.SupervisorEmployeeId = onBoardingViewInfo.SupervisorEmployeeId;
                    
                    newOnBoarding.DepartmentId = onBoardingViewInfo.DepartmentId;
                    newOnBoarding.CompanyId = onBoardingViewInfo.CompanyID;
                    if (onBoardingViewInfo.PhotoDigitalFileId > 0)
                    {
                        newOnBoarding.PhotoDigitalFileId = onBoardingViewInfo.PhotoDigitalFileId;
                    }
                    newOnBoarding.IsLocked = onBoardingViewInfo.IsLocked;
                    newOnBoarding.EmploymentTypeId = onBoardingViewInfo.EmploymentTypeId;
                    newOnBoarding.GenderOther = onBoardingViewInfo.GenderOther;
                    newOnBoarding.ReligionOther = onBoardingViewInfo.ReligionOther;
                    newOnBoarding.IsApproved = onBoardingViewInfo.IsApproved;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("UpdateOnBoardingInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Updates the promotion.
        /// </summary>
        /// <param name="promoteView">The promote view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">promoteView</exception>
        public string UpdatePromotion(IPromotionView promoteView)
        {
            if (promoteView == null)
                throw new ArgumentNullException(nameof(promoteView));

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var newPromotion = dbContext.Employees.Find(promoteView.EmployeeId);

                    newPromotion.LevelId = promoteView.LevelId;
                    newPromotion.GradeId = promoteView.GradeId;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("UpdatePromotions - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        
        /// <summary>
        /// Updates the employee photo identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="photoId">The photo identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// employeeId
        /// or
        /// photoId
        /// </exception>
        public string UpdateEmployeePhotoId(IEmployee employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee));
            
            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var newOnBoarding = dbContext.Employees.Find(employee.EmployeeId);

                    newOnBoarding.PhotoDigitalFileId = employee.PhotoDigitalFileId;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("UpdateOnBoardingInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Updates the on boarding lock information.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employee</exception>
        public string UpdateOnBoardingLockInfo(IEmployee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = dbContext.Employees.FirstOrDefault(x => x.EmployeeId.Equals(employee.EmployeeId));
                    aRecord.IsLocked = employee.IsLocked;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                var a = e;

                result = string.Format("Update Employee Lock Info - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Deletes the on boarding.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// employeeId
        /// or
        /// jobTitleId
        /// </exception>
        public string DeleteOnBoarding(int employeeId)
        {
            if (employeeId < 1)
                throw new ArgumentNullException("employeeId");

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var onBorderData =
                        dbContext.Employees.SingleOrDefault(p => p.EmployeeId.Equals(employeeId));
                    if (onBorderData == null) throw new ArgumentNullException("jobTitleId");


                    onBorderData.IsActive = false;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete Onboarding Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets all employee.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository Get Employee List {0}</exception>
        public IList<IEmployee> GetAllEmployee()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = EmployeeOnBoardQueries.getOnBoardingList(dbContext).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get Employee List {0}", e);
            }
        }

        /// <summary>
        /// Gets the promotions by employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Get Promotions By EmployeeId {0}</exception>
        public IList<IPromotion> GetPromotionsByEmployeeId(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = EmployeeOnBoardQueries.getPromotionsByEmployeeId(dbContext, employeeId).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Get Promotions By EmployeeId {0}", e);
            }
        }

        /// <summary>
        /// Gets the promotions by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Get Promotions By CompanyId {0}</exception>
        public IList<IPromotion> GetPromotionsByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = EmployeeOnBoardQueries.getPromotionsByCompanyId(dbContext, companyId).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Get Promotions By CompanyId {0}", e);
            }
        }
    }
}
