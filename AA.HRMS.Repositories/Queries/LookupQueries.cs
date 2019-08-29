using System.Linq;
using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.DataAccess;
using System.Collections.Generic;
using AA.HRMS.Repositories.Models;
using System;

namespace AA.HRMS.Repositories.Queries
{
    internal static class LookupQueries
    {
        internal static IEnumerable<IHowSource> getAboutUsSourceCollection(HRMSEntities db)
        {
            var result = (from d in db.AboutUsSources
                select new Models.HowSource
                {
                    AboutUsSourceId = d.AboutUsSourceId,
                    Description = d.Description
                }).OrderBy(x => x.Description);

            return result;
        }

        internal static IEnumerable<IResult> getResult(HRMSEntities db)
        {
            var result = (from d in db.Results
                          select new Models.ResultModel
                          {
                              ResultId = d.ResultId,
                              ResultName = d.Result1
                          }).OrderBy(x => x.ResultId);

            return result;
        }
        
        internal static IEnumerable<IYourGender> getGenderCollection(HRMSEntities db)
        {
            var result = (from d in db.Genders
                select new Models.YourGender
                {
                    GenderId = d.GenderId,
                    Description = d.Description
                }).OrderBy(x => x.Description);

            return result;
        }
        
        internal static IEnumerable<IDepartment> getDepartmentCollection(HRMSEntities db)
        {
            var result = (from d in db.Departments
                select new Models.DepartmentModel
                {
                    DepartmentId = d.DepartmentId,
                    CompanyId = d.CompanyId,
                    DepartmentName = d.DepartmentName,
                    ParentDepartmentId = d.ParentDepartmentID,
                    Description = d.Description,
                    IsActive = d.IsActive,
                    DateCreated = d.DateCreated
                }).OrderBy(x => x.DepartmentName);

            return result;
        }
        
        internal static IEnumerable<IDepartment> getDepartmentCollectionByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.Departments
                    select new Models.DepartmentModel

                    {
                        DepartmentId = d.DepartmentId,
                        CompanyId = d.CompanyId,
                        DepartmentName = d.DepartmentName,
                        ParentDepartmentId = d.ParentDepartmentID,
                        Description = d.Description,
                        IsActive = d.IsActive,
                        DateCreated = d.DateCreated
                    }).Where(x => x.CompanyId == companyId && x.IsActive == true)
                .OrderBy(x => x.DepartmentName);

            return result;
        }
        
        internal static IEnumerable<IAward> awardCollection(HRMSEntities db, int awardId)
        {
            var result = (from d in db.Awards
                    select new Models.AwardModel

                    {
                        AwardId = d.AwardId,
                        UserId = d.UserId,
                        AwardName = d.AwardName,
                        AwardYear = d.AwardYear,
                        IsActive = d.IsActive,
                        DateCreated = d.DateCreated
                    }).Where(x => x.AwardId == awardId)
                .OrderBy(x => x.AwardName);

            return result;
        }
        
        internal static IEnumerable<ICompanyDetail> getCompanyCollection(HRMSEntities db)
        {
            var result = (from d in db.Companies
                select new Models.CompanyRegistrationModel
                {
                    CompanyId = d.CompanyId,
                    CACRegistrationNumber = d.CACRegistrationNumber,
                    CompanyName = d.CompanyName,
                    CompanyAddressLine1 = d.CompanyAddressLine1,
                    CompanyAddressLine2 = d.CompanyAddressLine2,
                    CompanyCity = d.CompanyCity,
                    CompanyState = d.CompanyState,
                    CompanyCountryId = d.CompanyCountryId,
                    CompanyZipCode = d.CompanyZipCode,
                    CompanyEmail = d.CompanyEmail,
                    CompanyPhone = d.CompanyPhone,
                    CompanyWebsite = d.CompanyWebsite,
                    LogoDigitalFileId = d.LogoDigitalFileId,
                    ParentCompanyId = d.ParentCompanyId,
                    IsActive = d.IsActive,
                    CompanyAlias = d.CompanyAlias,
                    DateCreated = d.DateCreated
                }).OrderBy(x => x.CompanyName);

            return result;
        }
        
        internal static IEnumerable<ICompanyDetail> getActiveCompanyCollection(HRMSEntities db)
        {
            var result = (from d in db.Companies
                where d.IsActive
                select new Models.CompanyRegistrationModel
                {
                    CompanyId = d.CompanyId,
                    CACRegistrationNumber = d.CACRegistrationNumber,
                    CompanyName = d.CompanyName,
                    CompanyAddressLine1 = d.CompanyAddressLine1,
                    CompanyAddressLine2 = d.CompanyAddressLine2,
                    CompanyCity = d.CompanyCity,
                    CompanyState = d.CompanyState,
                    CompanyCountryId = d.CompanyCountryId,
                    CompanyZipCode = d.CompanyZipCode,
                    CompanyEmail = d.CompanyEmail,
                    CompanyPhone = d.CompanyPhone,
                    CompanyWebsite = d.CompanyWebsite,
                    LogoDigitalFileId = d.LogoDigitalFileId,
                    ParentCompanyId = d.ParentCompanyId,
                    IsActive = d.IsActive,
                    DateCreated = d.DateCreated,
                    CompanyAlias = d.CompanyAlias,
                }).OrderBy(x => x.CompanyName);

            return result;
        }

        internal static IEnumerable<IJobTitle> getJobTitleCollectionByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.JobTitles
                          join c in db.Companies on d.CompanyId equals c.CompanyId
                    select new Models.JobTitleModel

                    {
                        CompanyId = d.CompanyId,
                        JobTitleName = d.JobTitleName,
                        JobDefinition = d.JobDefinition,
                        JobFunction = d.JobFunction,
                        JobTitleId = d.JobTitleId,
                        DateCreated = d.DateCreated,
                        IsActive = d.IsActive,
                        CompanyName = c.CompanyName,
                    }).Where(x => x.CompanyId == companyId && x.IsActive.Equals(true))
                .OrderBy(x => x.JobTitleName);

            return result;
        }
        
        internal static IEnumerable<IJobTitle> getJobTitleCollection(HRMSEntities db)
        {
            var result = (from d in db.JobTitles
                select new Models.JobTitleModel

                {
                    CompanyId = d.CompanyId,
                    JobTitleName = d.JobTitleName,
                    JobDefinition = d.JobDefinition,
                    JobFunction = d.JobFunction,
                    JobTitleId = d.JobTitleId,
                    DateCreated = d.DateCreated,
                    IsActive = d.IsActive,
                }).OrderBy(x => x.JobTitleName);

            return result;
        }
        
        internal static IEnumerable<IGrade> getGradesCollectionByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.Grades
                          join a in db.Companies on d.CompanyId equals a.CompanyId
                          where d.CompanyId.Equals(companyId) && d.IsActive.Equals(true)
                    select new Models.GradeModel
                    {
                        GradeId = d.GradeId,
                        IsActive = d.IsActive,
                        CompanyId = d.CompanyId,
                        GradeName = d.GradeName,
                        GradeDescription = d.GradeDescription,
                        CompanyName = a.CompanyName,
                        DateCreated = d.DateCreated
                    })
                .OrderBy(x => x.GradeName);

            return result;
        }

        internal static IEnumerable<IGrade> getGradesCollection(HRMSEntities db)
        {
            var result = (from d in db.Grades
                select new Models.GradeModel
                {
                    GradeId = d.GradeId,
                    IsActive = d.IsActive,
                    CompanyId = d.CompanyId,
                    GradeName = d.GradeName,
                    DateCreated = d.DateCreated
                }).OrderBy(x => x.GradeName);

            return result;
        }
        
        internal static IEnumerable<IIndustry> getIndustryCollection(HRMSEntities db)
        {
            var result = (from d in db.Industries
                select new Models.IndustryModel
                {
                    IndustryId = d.IndustryId,
                    IndustryName = d.IndustryName,
                    DateCreated = d.DateCreated,
                    IsActive = d.IsActive
                }).OrderBy(x => x.IndustryName);

            return result;
        }

        internal static IEnumerable<IExperience> getExperienceCollection(HRMSEntities db)
        {
            var result = (from d in db.Experiences
                select new Models.ExperienceModel
                {
                    ExperienceId = d.ExperienceId,
                    Experience = d.ExperienceName,
                    IsActive = d.IsActive,
                });
            return result;
        }
        
        internal static IEnumerable<IBenefit> getBenefitByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.Benefits
                where d.CompanyId.Equals(companyId) && d.IsActive.Equals(true)
                join e in db.Companies on d.CompanyId equals e.CompanyId
                select new Models.BenefitModel
                {
                    BenefitId = d.BenefitId,
                    BenefitName = d.BenefitName,
                    BenefitDescription = d.BenefitDescription,
                    IsActive = d.IsActive,
                    IsMonetized = d.IsMonetized,
                    IsTaxable = d.IsTaxable,
                    CompanyId = d.CompanyId,
                    DateCreated = d.DateCreated,
                    CompanyName = e.CompanyName
                });

            return result;
        }
        
        internal static IEnumerable<IMonth> getMonth(HRMSEntities db)
        {
            var result = (from d in db.Months
                select new Models.MonthModel
                {
                    MonthCode = d.MonthCode,
                    MonthName = d.MonthName,
                    DateCreated = d.DateCreated,
                    IsActive = d.IsActive
                }).OrderBy(x => x.MonthCode);

            return result;
        }
        
        internal static IEnumerable<IYear> getYear(HRMSEntities db)
        {
            var result = (from d in db.Years
                select new Models.YearModel
                {
                    YearId = d.YearId,
                    Year = d.Year1,
                    DateCreated = d.DateCreated,
                    IsActive = d.IsActive
                }).OrderBy(x => x.YearId);

            return result;
        }
        
        internal static IEnumerable<IEmployeeLoan> getEmployeeLoanByEmployeeId(HRMSEntities db, int employeeId)
        {
            var result = (from d in db.EmployeeLoans
                where d.EmployeeId == employeeId && d.IsActive == true && d.IsApproved == true
               join e in db.LoanTypes on d.LoanTypeId equals e.LoanTypeId
               join w in db.Employees on d.EmployeeId equals w.EmployeeId
               join s in db.Companies on d.CompanyId equals s.CompanyId
                select new Models.EmployeeLoanModel
                {
                    EmployeeLoanId = d.EmployeeLoanId,
                    EmployeeId = d.EmployeeId,
                    LoanTypeId = d.LoanTypeId,
                    
                    Tenure = d.Tenure,
                    AgreedDate = d.AgreedDate,
                    IsActive = d.IsActive,
                    CompanyId = d.CompanyId,
                    EmployeeName = w.FirstName + " " + w.LastName,
                    Amount = d.Amount,
                    LoanName = e.LoanType1,
                    DateCreated = d.DateCreated,
                    IsApproved = d.IsApproved,
                    HRComment = d.HRComment,
                    Reason = d.Reason,
                    DateDisburst = d.DateDisburst,
                    InterestRate = d.InterestRate,
                    PeriodRemain = d.PeriodRemain,
                    ExpectedDate = d.ExpectedDate,
                    CompanyName = s.CompanyName

                }).OrderBy(x => x.EmployeeLoanId);
            return result;
        }
        
        internal static IEnumerable<IEmployeeLoan> getEmployeeLoanByEmployeeIdPeriodZero(HRMSEntities db, int employeeId)
        {
            var result = (from d in db.EmployeeLoans
                          where d.EmployeeId == employeeId && d.IsActive == true && d.IsApproved == true && d.PeriodRemain > 0
                          join e in db.LoanTypes on d.LoanTypeId equals e.LoanTypeId
                          join w in db.Employees on d.EmployeeId equals w.EmployeeId
                          join s in db.Companies on d.CompanyId equals s.CompanyId
                          select new Models.EmployeeLoanModel
                          {
                              EmployeeLoanId = d.EmployeeLoanId,
                              EmployeeId = d.EmployeeId,
                              LoanTypeId = d.LoanTypeId,

                              Tenure = d.Tenure,
                              AgreedDate = d.AgreedDate,
                              IsActive = d.IsActive,
                              CompanyId = d.CompanyId,
                              EmployeeName = w.FirstName + " " + w.LastName,
                              Amount = d.Amount,
                              LoanName = e.LoanType1,
                              DateCreated = d.DateCreated,
                              IsApproved = d.IsApproved,
                              HRComment = d.HRComment,
                              Reason = d.Reason,
                              DateDisburst = d.DateDisburst,
                              InterestRate = d.InterestRate,
                              PeriodRemain = d.PeriodRemain,
                              ExpectedDate = d.ExpectedDate,
                              CompanyName = s.CompanyName

                          }).OrderBy(x => x.EmployeeLoanId);
            return result;
        }
        
        internal static IEnumerable<IEmployeeReward> getEmployeeRewardByEmployeeId(HRMSEntities db, int employeeId)
        {
            var result = (from d in db.EmployeeRewards
                where d.EmployeeId.Equals(employeeId) && d.IsActive.Equals(true)
                join w in db.Rewards on d.RewardId equals w.RewardId
                select new Models.EmployeeRewardModel
                {
                    EmployeeRewardId = d.EmployeeRewardId,
                    RewardName = w.RewardName,
                    EmployeeId = d.EmployeeId,
                    RewardId = d.RewardId,
                    Amount = w.Amount,
                    IsActive = d.IsActive,
                    DateCreated = d.DateCreated
                }).OrderBy(x => x.DateCreated);

            return result;
        }

        internal static IEnumerable<IEmployeeReward> getEmployeeRewardListByEmployeeId(HRMSEntities db, int employeeRewardId)
        {
            var result = (from d in db.EmployeeRewards
                          where d.EmployeeRewardId.Equals(employeeRewardId)
                          join w in db.Rewards on d.RewardId equals w.RewardId
                          select new Models.EmployeeRewardModel
                          {
                              EmployeeRewardId = d.EmployeeRewardId,
                              RewardName = w.RewardName,
                              EmployeeId = d.EmployeeId,
                              RewardId = d.RewardId,
                              Amount = w.Amount,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated
                          }).OrderBy(x => x.DateCreated);

            return result;
        }
        
        internal static IEnumerable<IEmployee> getEmployeeByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from q in db.Employees
                          join w in db.Companies on q.CompanyId equals w.CompanyId
                          join e in db.Departments on q.DepartmentId equals e.DepartmentId
                          join a in db.Levels on q.LevelId equals a.LevelId
                          join c in db.Grades on q.GradeId equals c.GradeId
                          join b in db.Genders on q.GenderId equals b.GenderId
                          join n in db.Religions on q.ReligionId equals n.ReligionId
                where q.CompanyId.Equals(companyId)
                select new Models.EmployeeModel
                {
                    EmployeeId = q.EmployeeId,
                    FirstName = q.FirstName,
                    LastName = q.LastName,
                    CompanyId = q.CompanyId,
                    LevelId = q.LevelId,
                    GradeId = q.GradeId,
                    Email = q.Email,
                    StaffNumber = q.StaffNumber,
                    IsActive = q.IsActive,
                    MobileNumber =q.MobileNumber,
                    About =q.About,
                    HomeAddress = q.HomeAddress,
                    IsLocked = q.IsLocked,
                    IsExit = q.IsExit,
                    CompanyName = w.CompanyName,
                    Department = e.DepartmentName,
                    GradeName = c.GradeName,
                    LevelName = a.LevelName,
                    PhotoDigitalFileId = q.PhotoDigitalFileId,
                    GenderId = q.GenderId,
                    EmploymentTypeId = q.EmploymentTypeId,
                    NationalityId = q.Nationality,
                    PermanentAddressStateId = q.PermanentAddressState,
                    HomeAddressStateId = q.HomeAddressState,
                    DateExited = q.DateExited,
                    DateEmployed = q.DateEmployed,
                    Birthday = q.Birthday,
                    DepartmentId = q.DepartmentId,
                    ReligionId = q.ReligionId,
                    SupervisorId = q.SupervisorEmployeeId,
                    Religion = (n.Description == "Others") ? q.ReligionOther : n.Description,
                    Gender = (b.Description == "Others") ? q.GenderOther : b.Description,


                }).OrderBy(x => x.StaffNumber);

            return result;
        }
        
        internal static IEnumerable<ILoan> getLoanByCompanyId(HRMSEntities db)
        {
            var result = (from a in db.LoanTypes
                          
                select new Models.LoanTypeModel
                {
                  LoanTypeId = a.LoanTypeId,
                  DateCreated = a.DateCreated,
                  LoanType = a.LoanType1,
                  IsActive = a.IsActive

                }).OrderBy(p => p.DateCreated);

            return result;
        }
        
        internal static IEnumerable<ILevel> getLevelByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from a in db.Levels
                          join x in db.Companies on a.CompanyId equals x.CompanyId
                where a.CompanyId.Equals(companyId) && a.IsActive.Equals(true)
                select new Models.LevelModel
                {
                    LevelId = a.LevelId,
                    LevelName = a.LevelName,
                    LevelDescription = a.LevelDescription,
                    CompanyId = a.CompanyId,
                    DateCreated = a.DateCreated,
                    DateModified = a.DateModified,
                    IsActive = a.IsActive,
                    CompanyName = x.CompanyName
                }).Where(x => x.IsActive == true).OrderBy(p => p.LevelName);

            return result;
        }
        
        internal static IEnumerable<IReward> getRewardByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from a in db.Rewards
                          join v in db.Companies on a.CompanyId equals v.CompanyId
                where a.CompanyId.Equals(companyId) && a.IsActive.Equals(true)
                select new Models.RewardModel
                {
                    RewardId = a.RewardId,
                    RewardName = a.RewardName,
                    Amount = a.Amount,
                    CompanyId = a.CompanyId,
                    DateCreated = a.DateCreated,
                    CompanyName = v.CompanyName,
                    IsActive_ = a.IsActive,
                    
                }).OrderBy(p => p.DateCreated);

            return result;
        }
        
        internal static IEnumerable<IDeduction> getDeductionByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from a in db.Deductions
                          join b in db.Companies on a.CompanyId equals b.CompanyId
                where a.DeductionId.Equals(companyId) && a.IsActive.Equals(true)
                select new Models.DeductionModel
                {
                    DeductionId = a.DeductionId,
                    DeductionAmount = a.DeductionAmount,
                    DeductionName = a.DeductionName,
                    CompanyId = a.CompanyId,
                    DateCreated = a.DateCreated,
                    IsActive = a.IsActive,
                    CompanyName = b.CompanyName
                }).Where(x => x.IsActive == true).OrderBy(p => p.DateCreated);

            return result;
        }
        
        internal static IEnumerable<IReligion> getReligionCollection(HRMSEntities db)
        {
            var result = (from d in db.Religions
                          where d.IsActive.Equals(true)
                select new Models.ReligionModel
                {
                    ReligionId = d.ReligionId,
                    Description = d.Description
                }).OrderBy(x => x.Description);

            return result;
        }
        
        internal static IEnumerable<IMaritalStatus> getMaritalStatusCollection(HRMSEntities db)
        {
            var result = (from d in db.MaritalStatus
                          where d.IsActive.Equals(true)
                select new Models.MaritalStatusModel
                {
                    MaritalStatusId = d.MaritalStatusId,
                    Description = d.Description
                }).OrderBy(x => x.Description);

            return result;
        }
        
        internal static IEnumerable<IEmployee> getOnBoardingCollectionByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.Employees
                    select new Models.EmployeeModel

                    {
                        LastName = d.LastName,
                        FirstName = d.FirstName,
                        MiddleName = d.MiddleName,
                        Email = d.Email,
                        CompanyId = d.CompanyId,
                        LevelId = d.LevelId,
                        GradeId = d.GradeId,
                        MobileNumber = d.MobileNumber,
                        PermanentAddress = d.PermanentAddress,
                        PermanentAddressCity = d.PermanentAddressCity,
                        PermanentAddressStateId = d.PermanentAddressState,
                        HomeAddress = d.HomeAddress,
                        HomeAddressCity = d.HomeAddressCity,
                        HomeAddressStateId = d.HomeAddressState,
                        OtherEmail = d.OtherEmail,
                        Birthday = d.Birthday,
                        MartialStatusId = d.MaritalStatusId,
                        GenderId = d.GenderId,
                        StaffNumber = d.StaffNumber,
                        DateEmployed = d.DateEmployed,
                        About = d.About,
                        DateExited = d.DateExited,
                        SkillSet = d.SkillSet,
                        SupervisorEmployeeId = d.SupervisorEmployeeId,
                        SeatingLocation = d.SeatingLocation,
                        DepartmentId = d.DepartmentId,
                        MaidenName = d.MaidenName,
                        PhotoDigitalFileId = d.PhotoDigitalFileId,
                        ReligionId = d.ReligionId,
                        NationalityId = d.Nationality,
                        DateCreated = d.DateCreated,
                        EmployeeId = d.EmployeeId,
                        IsActive = d.IsActive,
                    }).Where(x => x.CompanyId == companyId)
                .Where(x => x.IsActive == true).OrderBy(x => x.LastName);

            return result;
        }

        internal static IEnumerable<IAppRole> getAppRole(HRMSEntities db)
        {
            var result = (from d in db.AppRoles
                select new Models.AppRoleModel
                {
                    AppRoleId = d.AppRoleId,
                    Action = d.Action,
                    Description = d.Description,
                }).OrderBy(p => p.AppRoleId);

            return result;
        }
        
        internal static IEnumerable<IUserAppRole> getUserAppRole(HRMSEntities db)
        {
            var result = (from d in db.UserAppRoles
                select new Models.UserAppRoleModel
                {
                    AppRoleId = d.AppRoleId,
                    Username = d.Username,
                    CreateByUsername = d.CreateByUsername,
                    DateCreated = d.DateCreated,
                }).OrderBy(p => p.DateCreated);

            return result;
        }
        
        internal static IEnumerable<IUserAppRole> GetUserAppRoleByUsername(HRMSEntities db, string userName)
        {
            var result = (from d in db.UserAppRoles
                where d.Username.Equals(userName)
                join e in db.AppRoles on d.AppRoleId equals e.AppRoleId
                select new Models.UserAppRoleModel
                {
                    UserAppRoleId = d.UserAppRoleId,
                    AppRoleId = d.AppRoleId,
                    Username = d.Username,
                    CreateByUsername = d.CreateByUsername,
                    DateCreated = d.DateCreated,
                    RoleName = e.Action,
                }).OrderBy(p => p.DateCreated);
            return result;
        }
        
        internal static IUserAppRole getuserAppRoleByRoleIdandUsername(HRMSEntities db, int roleId, string userName)
        {
            var result = (from d in db.UserAppRoles
                where d.AppRoleId.Equals(roleId) && d.Username.Equals(userName)
                select new Models.UserAppRoleModel
                {
                    AppRoleId = d.AppRoleId,
                    Username = d.Username,
                    DateCreated = d.DateCreated,
                    CreateByUsername = d.CreateByUsername
                }).FirstOrDefault();

            return result;
        }
        
        internal static IEnumerable<ITraining> getTrainingByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from a in db.Trainings
                join e in db.Companies on a.CompanyID equals e.CompanyId
                          where a.CompanyID.Equals(companyId) && a.IsActive.Equals(true)
                          select new Models.TrainingModel
                          {
                              TrainingID = a.TrainingID,
                              TrainingName = a.TrainingName,
                              CompanyID = a.CompanyID,
                              CompanyName = e.CompanyName,
                              DateCreated = a.DateCreated,
                              TrainingDescription = a.TrainingDescription
                          }).OrderBy(p => p.DateCreated);

            return result;
        }
        
        internal static IEnumerable<IEmployeeTrainingModel> getTrainingRequestByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from a in db.EmployeeTrainings
                          join e in db.Companies on a.CompanyId equals e.CompanyId
                          join r in db.Trainings on a.TrainingId equals r.TrainingID
                          where a.CompanyId.Equals(companyId)
                          select new Models.EmployeeTrainingModel
                          {
                              EmployeeId = a.EmployeeId,
                              TrainingName = r.TrainingName,
                              TrainingId = a.TrainingId,
                              TrainingReportId = a.TrainingReportId,
                              SupervisorId = a.SupervisorId,
                              IsApproved = a.IsApproved,
                              DateApproved = a.DateApproved,

                              CompanyId = a.CompanyId,
                              CompanyName = e.CompanyName,
                              DateCreated = a.DateCreated,
                              IsActive = a.IsActive,
                          }).OrderBy(p => p.DateCreated);

            return result;
        }
        
        internal static IEnumerable<ITraining> getTrainingInCalendarByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from a in db.Trainings
                          join e in db.Companies on a.CompanyID equals e.CompanyId
                          join v in db.TrainingCalenders on a.TrainingID equals v.TrainingId
                          where a.CompanyID.Equals(companyId)
                          select new Models.TrainingModel
                          {
                              TrainingID = a.TrainingID,
                              TrainingName = a.TrainingName,
                              CompanyID = a.CompanyID,
                              CompanyName = e.CompanyName,
                              DateCreated = a.DateCreated,
                              IsActive = a.IsActive,
                              TrainingDescription = a.TrainingDescription
                          }).OrderBy(p => p.DateCreated);

            return result;
        }
        
        internal static IEnumerable<IDiscipline> getDisciplineByCompanyID(HRMSEntities db, int companyId)
        {
            var result = (from a in db.Disciplines
                          join b in db.Companies on a.CompanyId equals b.CompanyId
                          join c in db.Employees on a.EmployeeId equals c.EmployeeId
                          join d in db.ActionTakens on a.ActionTakenId equals d.ActionTakenId
                          join e in db.QueryStatus on a.QueryStatusId equals e.QueryStatusId
                          where a.CompanyId.Equals(companyId)
                          select new Models.DisciplineModel
                          {
                              DisciplineId = a.DisciplineId,
                              EmployeeId = a.EmployeeId,
                              EmployeeName = c.FirstName + " " + c.LastName,
                              QueryDate = a.QueryDate,
                              Offence = a.Offence,
                              QueryInitiator = a.QueryInitiator,
                              InvestigatorReport = a.InvestigatorReport,
                              Response = a.Response,
                              QueryStatusId = a.QueryStatusId,
                              QueryStatusName = e.QueryStatusName,
                              Investigator = a.Investigator,
                              RecommendedSanction = a.RecommendedSanction,
                              DisciplineCommitteeRecommendation = a.DisciplineCommitteeRecommendation,
                              ActionTakenId = a.ActionTakenId,
                              ActionTakenName = d.ActionTakenName,
                              EvidenceDigitalFileId = a.EvidenceDigitalFileId,
                              DateCreated = a.DateCreated,
                              IsActive = a.IsActive,
                              CompanyId = a.CompanyId,
                              CompanyName = b.CompanyName,
                          }).OrderBy(p => p.CompanyName);

            return result;
        }
        
        internal static IEnumerable<IDiscipline> getDisciplineByCompanyIdandEmployeeId(HRMSEntities db, int companyId)
        {
            var result = (from a in db.Disciplines
                          join b in db.Companies on a.CompanyId equals b.CompanyId
                          join c in db.Employees on a.EmployeeId equals c.EmployeeId
                          join d in db.ActionTakens on a.ActionTakenId equals d.ActionTakenId
                          join e in db.QueryStatus on a.QueryStatusId equals e.QueryStatusId
                          where a.DisciplineId.Equals(companyId) 
                          select new Models.DisciplineModel
                          {
                              DisciplineId = a.DisciplineId,
                              EmployeeId = a.EmployeeId,
                              EmployeeName = c.FirstName + " " + c.LastName,
                              QueryDate = a.QueryDate,
                              Offence = a.Offence,
                              QueryInitiator = a.QueryInitiator,
                              InvestigatorReport = a.InvestigatorReport,
                              Response = a.Response,
                              QueryStatusId = a.QueryStatusId,
                              QueryStatusName = e.QueryStatusName,
                              Investigator = a.Investigator,
                              RecommendedSanction = a.RecommendedSanction,
                              DisciplineCommitteeRecommendation = a.DisciplineCommitteeRecommendation,
                              ActionTakenId = a.ActionTakenId,
                              ActionTakenName = d.ActionTakenName,
                              EvidenceDigitalFileId = a.EvidenceDigitalFileId,
                              DateCreated = a.DateCreated,
                              IsActive = a.IsActive,
                              CompanyId = a.CompanyId,
                              CompanyName = b.CompanyName,
                          }).OrderBy(p => p.CompanyName);

            return result;
        }

        internal static IEnumerable<IDiscipline> getDisciplineByCompanyIdandEmployeeId(HRMSEntities db, int companyId, int employeeId)
        {
            var result = (from a in db.Disciplines
                          join b in db.Companies on a.CompanyId equals b.CompanyId
                          join c in db.Employees on a.EmployeeId equals c.EmployeeId
                          join d in db.ActionTakens on a.ActionTakenId equals d.ActionTakenId
                          join e in db.QueryStatus on a.QueryStatusId equals e.QueryStatusId
                          where a.DisciplineId.Equals(companyId) && a.EmployeeId== employeeId
                          select new Models.DisciplineModel
                          {
                              DisciplineId = a.DisciplineId,
                              EmployeeId = a.EmployeeId,
                              EmployeeName = c.FirstName + " " + c.LastName,
                              QueryDate = a.QueryDate,
                              Offence = a.Offence,
                              QueryInitiator = a.QueryInitiator,
                              InvestigatorReport = a.InvestigatorReport,
                              Response = a.Response,
                              QueryStatusId = a.QueryStatusId,
                              QueryStatusName = e.QueryStatusName,
                              Investigator = a.Investigator,
                              RecommendedSanction = a.RecommendedSanction,
                              DisciplineCommitteeRecommendation = a.DisciplineCommitteeRecommendation,
                              ActionTakenId = a.ActionTakenId,
                              ActionTakenName = d.ActionTakenName,
                              EvidenceDigitalFileId = a.EvidenceDigitalFileId,
                              DateCreated = a.DateCreated,
                              IsActive = a.IsActive,
                              CompanyId = a.CompanyId,
                              CompanyName = b.CompanyName,
                          }).OrderBy(p => p.CompanyName);

            return result;
        }
        
        internal static IEnumerable<ITypeOfExit> getTypeOfExitByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from a in db.TypeOfExits
                          where a.CompanyId.Equals(companyId) && a.IsActive.Equals(true)
                          join e in db.Companies on a.CompanyId equals e.CompanyId
                          select new Models.TypeOfExitModel
                          {
                              TypeOfExitId = a.TypeOFExitId,
                              TypeOfExitName = a.TypeOFExitName,
                              CompanyId = a.CompanyId,
                              CompanyName = e.CompanyName,
                              IsActive = a.IsActive
                          }).OrderBy(p=>p.TypeOfExitName);

            return result;
        }
        
        internal static IEnumerable<IQuery> getQueryByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from a in db.Queries
                          where a.CompanyId.Equals(companyId)
                          select new Models.QueryModel
                          {
                              QueryId = a.QueryId,
                              QueryName = a.QueryName,
                              CompanyId = a.CompanyId,
                              IsActive = a.IsActive,
                              DateCreated = a.DateCreated,
                              Consequences = a.Consequences
                          }).OrderBy(p => p.QueryName);

            return result;
        }
        
        internal static IEnumerable<ITrainingNeedAnalysis> GetTrainingNeedAnalysisByCompanyID(HRMSEntities db, int companyId)
        {
            var result = (from a in db.TrainingNeedAnalysis
                          join f in db.Companies on a.CompanyId equals f.CompanyId
                          join e in db.Trainings on a.TrainingId equals e.TrainingID
                          join r in db.JobTitles on a.JobId equals r.JobTitleId
                          where a.CompanyId.Equals(companyId) && a.IsActive.Equals(true)
                          select new Models.TrainingNeedAnalysisModel
                          {
                              TrainingNeedAnaylsisId = a.TrainingNeedAnaylsisId,
                              JobId = a.JobId,
                              JobTitle = r.JobTitleName,
                              TrainingName = e.TrainingName,
                              CompanyName = f.CompanyName,
                              CompanyId = a.CompanyId,
                              DateCreated = a.DateCreated,
                              TrainingId = a.TrainingId,
                              MethodOfDelivery = a.MethodOfDelivery,
                              IsProviderApproved = a.IsProviderApproved,
                              Cost = a.Cost,
                              CurrencyId = a.CurrencyId,
                              Location = a.Location,
                              ApprovedBudget = a.ApprovedBudget,
                              ApprovedBudgetCurrency = a.ApprovedBudgetCurrency,
                              FrequecyOfDeliveryId = a.FrequecyOfDeliveryId,
                              CertificateIssued = a.CertificateIssued,
                              TrainingDescription = a.TrainingDescription,
                              IsActive = a.IsActive,
                          }).OrderBy(p => p.TrainingNeedAnaylsisId);

            return result;
        }
        
        internal static IEnumerable<IEmployeeExit> GetEmployeeExitByCompanyID(HRMSEntities db, int companyId)
        {
            var result = (from a in db.EmployeeExits
                          join pdept in db.EmployeeExits on a.EmployeeExitId equals pdept.EmployeeExitId into gj
                          join q in db.Employees on a.EmployeeId equals q.EmployeeId
                          join z in db.Companies on a.CompanyId equals z.CompanyId
                          join s in db.TypeOfExits on a.TypeOfExitId equals s.TypeOFExitId
                          where a.CompanyId.Equals(companyId)
                          select new Models.EmployeeExitModel
                          {
                              EmployeeExitId = a.EmployeeExitId,
                              EmployeeName = q.FirstName + " " + q.LastName,
                              CompanyName = z.CompanyName,
                              EmployeeId = a.EmployeeId,
                              CompanyId = a.CompanyId,
                              DateCreated = a.DateCreated,
                              Interviewer = a.Interviewer,
                              TypeOfExitId = a.TypeOfExitId,
                              Reason = a.Reason,
                              InterviewDate = a.InterviewDate,
                              DateRequested = a.DateRequested,
                              ExitInterViewSummary = a.ExitInterViewSummary,
                              IsActive = a.IsActive
                          }).OrderBy(p => p.EmployeeExitId);

            return result;
        }
        
        internal static IEnumerable<ITax> getTaxes(HRMSEntities db)
        {
            var result = (from a in db.Taxes
                          select new Models.TaxModel
                          {
                              TaxId = a.TaxId,
                              TaxRate = a.TaxRate,
                              AnnualIncome = a.AnnualIncome
                          }).OrderBy(p => p.AnnualIncome);

            return result;
        }
        
        internal static IEnumerable<ITrainingEvaluationRating> getEvaluationRatingById(HRMSEntities db)
        {
            var result = (from a in db.TrainingEvaluationRatings
                         
                          select new TrainingEvaluationRatingModel
                          {
                              TrainingEvaluationRating1 = a.TrainingEvaluationRating1,
                              TrainingEvaluationRatingId = a.TrainingEvaluationRatingId
                          }).OrderBy(p => p.TrainingEvaluationRatingId);
            return result;
        }
        
        internal static IEnumerable<ITrainingStatus> getTrainingStatus(HRMSEntities db)
        {
            var result = (from a in db.TrainingStatus
                          select new Models.TrainingStatusModel
                          {
                              TrainingStatusId = a.TrainingStatusId,
                              Status = a.Status,
                          }).OrderBy(p => p.Status);

            return result;
        }
        
        internal static IEnumerable<IFrequencyOfDeliveryModel> getFrequencyOfDeliveryByCompanyId(HRMSEntities db)
        {
            var result = (from a in db.FrequencyOfDeliveries
                          select new Models.FrequencyOfDeliveryModel
                          {
                              FrequencyOfDeliveryId = a.FrequencyOfDeliveryId,
                              FrequencyOfDelivery1 = a.FrequencyOfDelivery1,
                          }).OrderBy(p => p.FrequencyOfDelivery1);

            return result;
        }
        
        internal static IEnumerable<ICurrency> getCurrency(HRMSEntities db)
        {
            var result = (from a in db.Currencies
                          select new Models.CurrencyModel
                          {
                              CurrencyId = a.CurrencyId,
                              Currency1 = a.Currency1,
                          }).OrderBy(p => p.Currency1);

            return result;
        }
        
        internal static IEnumerable<IMethodOfDelivery> getMethodOfDelivery(HRMSEntities db)
        {
            var result = (from a in db.MethodOfDeliveries
                          select new Models.MethodOfDeliveryModel
                          {
                              MethodOfDeliveryTraining = a.MethodOfDeliveryTraining,
                              MethodOfDeliveryTrainingId = a.MethodOfDeliveryTrainingId,
                          }).OrderBy(p => p.MethodOfDeliveryTraining);

            return result;
        }
        
        internal static IEnumerable<IActionTaken> getActionTaken(HRMSEntities db)
        {
            var result = (from a in db.ActionTakens
                          select new Models.ActionTakenModel
                          {
                              ActionTakenDescription = a.ActionTakenDescription,
                              ActionTakenId = a.ActionTakenId,
                              ActionTakenName = a.ActionTakenName

                          }).OrderBy(p => p.ActionTakenName);

            return result;
        }
        
        internal static IEnumerable<IQueryStatus> getQueryStatus(HRMSEntities db)
        {
            var result = (from a in db.QueryStatus
                          select new Models.QueryStatusModel
                          {
                              QueryStatusId = a.QueryStatusId,
                              QueryStatusDescription = a.QueryStatusDescription,
                              QueryStatusName = a.QueryStatusName,
                          }).OrderBy(p => p.QueryStatusName);

            return result;
        }
        
        internal static IEnumerable<ITrainingReport> GetTrainingReportByCompanyID(HRMSEntities db, int companyId)
        {
            var result = (from a in db.TrainingReports
                          join c in db.Companies on a.CompanyId equals c.CompanyId
                          join q in db.TrainingEvaluationRatings on a.TrainerEvaluationRating equals q.TrainingEvaluationRatingId
                          join v in db.Trainings on a.TrainingId equals v.TrainingID
                          join x in db.TrainingCalenders on a.TrainingCalendarId equals x.TrainingCalenderId
                          join z in db.Employees on a.EmployeeId equals z.EmployeeId
                          where a.CompanyId.Equals(companyId)
                          select new Models.TrainingReportModel
                          {
                              TrainingReportId = a.TrainingReportId,
                              TrainingName = v.TrainingName,
                              EmployeeName = z.FirstName + " " + z.LastName,
                              CompanyName = c.CompanyName,
                              DateCreated = a.DateCreated,
                              TrainingId = a.TrainingId,
                              CompanyId = a.CompanyId,
                              EmployeeId = a.EmployeeId,
                              TrainingCalendarId = a.TrainingCalendarId,
                              TrainerName = a.TrainerName,
                              TrainerEvaluationRating = a.TrainerEvaluationRating,
                              TrainerRating = q.TrainingEvaluationRating1,
                              TrainerEvaluationComment = a.TrainerEvaluationComment,
                              TrainingEvaluationRating = a.TrainingEvaluationRating,
                              TrainingEvaluationComment = a.TrainerEvaluationComment
                          }).OrderBy(p => p.TrainingReportId);

            return result;
        }
        
        internal static IEnumerable<ISuspension> getSuspensionByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from a in db.Suspensions
                          join x in db.Queries on a.QueryId equals x.QueryId
                          where a.CompanyId.Equals(companyId)
                          select new Models.SuspensionModel
                          {
                              SuspensionId = a.SuspensionId,
                              EmployeeId = a.EmployeeId,
                              QueryId = a.QueryId,
                              QueryName = x.QueryName,
                              StartDate = a.StartDate,
                              EndDate = a.EndDate,
                              Percentage = a.Percentage,
                              CompanyId = a.CompanyId,
                              IsActive = a.IsActive,
                              DateCreated = DateTime.Now

                          }).OrderBy(p => p.SuspensionId);

            return result;
        }
        
        internal static IEnumerable<IAppraisal> getAppraisalByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.Appraisals
                          where d.CompanyId.Equals(companyId) && d.IsActive.Equals(true)

                          select new Models.AppraisalModel
                          {
                              AppraisalId = d.AppraisalId,
                              AppraisalPeriodId = d.AppraisalPeriodId,
                              AppraisalYearId = d.AppraisalYearId,
                              IsActive = d.IsActive,
                              IsOpened = d.IsOpened,
                              CompanyId = d.CompanyId,
                              DateInitiated = d.DateInitiated,
                              DateModified = d.DateModified,

                          }).OrderBy(p => p.AppraisalId);

            return result;
        }
        
        internal static IEnumerable<ITrainingReport> GetTrainingReportByReportID(HRMSEntities db, int ReportId)
        {
            var result = (from a in db.TrainingReports
                          join c in db.Companies on a.CompanyId equals c.CompanyId
                          join q in db.TrainingEvaluationRatings on a.TrainerEvaluationRating equals q.TrainingEvaluationRatingId
                          join v in db.Trainings on a.TrainingId equals v.TrainingID
                          join x in db.TrainingCalenders on a.TrainingCalendarId equals x.TrainingCalenderId
                          join z in db.Employees on a.EmployeeId equals z.EmployeeId
                          where a.TrainingReportId.Equals(ReportId)
                          select new Models.TrainingReportModel
                          {
                              TrainingReportId = a.TrainingReportId,
                              TrainingName = v.TrainingName,
                              EmployeeName = z.FirstName + " " + z.LastName,
                              CompanyName = c.CompanyName,
                              DateCreated = a.DateCreated,
                              TrainingId = a.TrainingId,
                              CompanyId = a.CompanyId,
                              EmployeeId = a.EmployeeId,
                              TrainingCalendarId = a.TrainingCalendarId,
                              TrainerName = a.TrainerName,
                              TrainerEvaluationRating = a.TrainerEvaluationRating,
                              TrainerRating = q.TrainingEvaluationRating1,
                              TrainerEvaluationComment = a.TrainerEvaluationComment,
                              TrainingEvaluationRating = a.TrainingEvaluationRating,
                              TrainingEvaluationComment = a.TrainerEvaluationComment
                          }).OrderBy(p => p.TrainingReportId);

            return result;
        }
        
        internal static IEnumerable<IAppraisalPeriod> getAppraisalPeriod(HRMSEntities db)
        {
            var result = (from a in db.AppraisalPeriods
                          select new Models.AppraisalPeriodModel
                          {
                              Appraisalperiod1 = a.Appraisalperiod1,
                              AppraisalPeriodId = a.AppraisalPeriodId

                          }).OrderBy(p =>p.AppraisalPeriodId);

            return result;
        }
        
        internal static IEnumerable<ICountry> getCountryCollection(HRMSEntities db)
        {
            var result = (from a in db.Countries
                          select new Models.CountryModel
                          {
                              CountryId = a.CountryId,
                              Code = a.Code,
                              Name = a.Name

                          }).OrderBy(p => p.CountryId);

            return result;
        }
        
        internal static IEnumerable<IState> getStateCollection(HRMSEntities db)
        {
            var result = (from a in db.States
                          select new Models.StateModel
                          {
                              StateId = a.StateId,
                              Code = a.Code,
                              Name = a.Name

                          }).OrderBy(p => p.StateId);

            return result;
        }
        
        internal static IEnumerable<IEmployeeDeduction> getEmployeeDeductionByCompanyId (HRMSEntities db, int companyId)
        {
            var deductionView = (from d in db.EmployeeDeductions
                                 where d.CompanyId.Equals(companyId) && d.IsActive.Equals(true)
                                 join s in db.Employees on d.EmployeeId equals s.EmployeeId
                                 join a in db.Deductions on d.DeductionId equals a.DeductionId
                                 select new Models.EmployeeDeductionModel
                                 {
                                     EmployeeDeductionId = d.EmployeeDeductionId,
                                     EmployeeId = d.EmployeeId,
                                     CompanyId= d.CompanyId,
                                     DeductionId = d.DeductionId,
                                     IsActive = d.IsActive,
                                     DateCreated = d.DateCreated,
                                     EmployeeName = s.LastName + " " + s.FirstName,
                                     DeductionAmount = a.DeductionAmount,
                                     DeductionName = a.DeductionName
                                     

                                 }).ToList();
                  return deductionView;
        }
        
        internal static IEnumerable<IDeduction> getAllDeductionByCompanyId(HRMSEntities db, int companyId)
        {
            var deductionView = (from d in db.Deductions
                                 where d.CompanyId.Equals(companyId) && d.IsActive.Equals(true)
                                 join s in db.Employees on d.EmployeeId equals s.EmployeeId
                                 
                                 select new Models.DeductionModel
                                 {
                                    DeductionId = d.DeductionId,
                                     EmployeeId = d.EmployeeId,
                                     CompanyId = d.CompanyId,
                                     DateStarted = d.DateStarted,
                                     IsActive = d.IsActive,
                                     DateCreated = d.DateCreated,
                                    EemployeeName = s.LastName + " " + s.FirstName,
                                     DeductionAmount = d.DeductionAmount,
                                     DeductionName = d.DeductionName,
                                     DateTerminated = d.DateTerminated,
                                     IsTerminated = d.IsTerminated

                                 }).ToList();
            return deductionView;
        }
        
        internal static IEnumerable<IEmployeeReward> getEmployeeRewardByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.EmployeeRewards
                          
                          where d.CompanyId.Equals(companyId)
                          select new Models.EmployeeRewardModel
                          {
                              RewardId = d.RewardId,
                              EmployeeRewardId = d.EmployeeRewardId,
                              EmployeeId = d.EmployeeId,
                              CompanyId = d.CompanyId,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive
                          }).OrderBy(p=>p.EmployeeRewardId);
            return result;
        }
        
        internal static IEnumerable<IEmploymentType> getEmploymentTypes(HRMSEntities db)
        {
            var result = (from d in db.EmploymentTypes
                          select new Models.EmploymentTypeModel
                          {
                              EmploymentTypeId = d.EmploymentTypeId,
                              Name = d.Name,
                              Description = d.Description,
                              
                          }).OrderBy(p=>p.EmploymentTypeId);

            return result;
        }
        
        internal static IEnumerable<INextOfKin> getNextOfKin(HRMSEntities db)
        {
            var result = (from a in db.NextOfKins
                          select new Models.NextOfKinModel
                          {
                              EmployeeId = a.EmployeeId,
                              NextOfKinId = a.NextOfKinId,
                              NextOfKinName = a.NextOfKinName,
                              DateOfBirth = a.DateOfBirth,
                              Emial = a.Emial,
                              Address = a.Address,
                              Mobile = a.Mobile,
                              DateCreated = a.DateCreated,
                              DateModified = a.DateModified,
                              IsActive = a.IsActive,
                              IsApproved = a.IsApproved

                          }).OrderBy(p => p.EmployeeId);

            return result;
        }
        
        internal static INextOfKin getNextofKinDescriptionByValue(HRMSEntities db, string description)
        {
            var result = (from d in db.NextOfKins
                          where d.NextOfKinName.Equals(description)
                          select new Models.NextOfKinModel
                          {
                              IsActive = d.IsActive,
                              NextOfKinName= d.NextOfKinName

                          }).FirstOrDefault();
            return result;
        }
        
        internal static  INextOfKin getNextOfKinById(HRMSEntities db, int employeeId)
        {
            var result = (from a in db.NextOfKins
                          where a.NextOfKinId.Equals(employeeId)
                          select new Models.NextOfKinModel
                          {
                              
                              EmployeeId = a.EmployeeId,
                              NextOfKinId = a.NextOfKinId,
                              NextOfKinName = a.NextOfKinName,
                              DateOfBirth = a.DateOfBirth,
                              Emial = a.Emial,
                              Address = a.Address,
                              Mobile = a.Mobile,
                              DateCreated = a.DateCreated,
                              DateModified = a.DateModified,
                              IsActive = a.IsActive,
                              IsApproved = a.IsApproved

                          }).SingleOrDefault();

            return result;
        }

        internal static IEnumerable<INextOfKin> getNextOfKinListById(HRMSEntities db, int employeeId)
        {
            var result = (from a in db.NextOfKins
                          where a.EmployeeId.Equals(employeeId) && a.IsActive==true
                          select new Models.NextOfKinModel
                          {
                              EmployeeId = a.EmployeeId,
                              NextOfKinId = a.NextOfKinId,
                              NextOfKinName = a.NextOfKinName,
                              DateOfBirth = a.DateOfBirth,
                              Emial = a.Emial,
                              Address = a.Address,
                              Mobile = a.Mobile,
                              DateCreated = a.DateCreated,
                              DateModified = a.DateModified,
                              IsActive = a.IsActive,
                              IsApproved = a.IsApproved

                          }).ToList();

            return result;
        }
        
        internal static IBeneficiariesModel getBeneficiariesDescriptionByValue(HRMSEntities db, string description)
        {
            var result = (from d in db.Beneficiaries
                          where d.BeneficiaryName.Equals(description)
                          select new Models.BeneficiariesModel
                          {
                              IsActive = d.IsActive,
                              BeneficiaryName = d.BeneficiaryName

                          }).FirstOrDefault();
            return result;
        }
        
        internal static IBeneficiariesModel getBeneficiariesById(HRMSEntities db, int employeeId)
        {
            var result = (from a in db.Beneficiaries
                          where a.BeneficiaryId.Equals(employeeId)
                          select new Models.BeneficiariesModel
                          {
                              EmployeeId = a.EmployeeId,
                              BeneficiaryId = a.BeneficiaryId,
                              BeneficiaryName = a.BeneficiaryName,
                              DateOfBirth = a.DateOfBirth,
                              Email = a.Email,
                              Address = a.Address,
                              Mobile = a.Mobile,
                              DateCreated = a.DateCreated,
                              DateModified = a.DateModified,
                              IsActive = a.IsActive,
                              IsApproved = a.IsApproved

                          }).SingleOrDefault();

            return result;
        }

        internal static IEnumerable<IBeneficiariesModel> GetBeneficiariesById(HRMSEntities db, int employeeId)
        {
            var result = (from a in db.Beneficiaries
                          where a.EmployeeId.Equals(employeeId) && a.IsActive==true
                          select new Models.BeneficiariesModel
                          {
                              EmployeeId = a.EmployeeId,
                              BeneficiaryId = a.BeneficiaryId,
                              BeneficiaryName = a.BeneficiaryName,
                              DateOfBirth = a.DateOfBirth,
                              Email = a.Email,
                              Address = a.Address,
                              Mobile = a.Mobile,
                              DateCreated = a.DateCreated,
                              DateModified = a.DateModified,
                              IsActive = a.IsActive,
                              IsApproved = a.IsApproved

                          }).ToList();

            return result;
        }
        
        internal static IEmergency getEmergencyContactDescriptionByValue(HRMSEntities db, string description)
        {
            var result = (from d in db.Emergencies
                          where d.EmergencyName.Equals(description)
                          select new  Models.EmergencyModel
                          {
                              IsActive = d.IsActive,
                              EmergencyName = d.EmergencyName

                          }).FirstOrDefault();
            return result;
        }
        
        internal static IEmergency getEmergencyContactDescriptionById(HRMSEntities db, int employeeId)
        {
            var result = (from a in db.Emergencies
                          where a.EmergencyId.Equals(employeeId)
                          select new Models.EmergencyModel
                          {
                              EmployeeId = a.EmployeeId,
                              EmergencyId = a.EmergencyId,
                              EmergencyName = a.EmergencyName,
                              DateOfBirth = a.DateOfBirth,
                              Email = a.Email,
                              Address = a.Address,
                              Mobile = a.Mobile,
                              DateCreated = a.DateCreated,
                              DateModified = a.DateModified,
                              IsActive = a.IsActive,
                              IsApproved = a.IsApproved

                          }).SingleOrDefault();

            return result;
        }
        
        internal static IChildrenModel getChildrenInformationDescriptionByValue(HRMSEntities db, string description)
        {
            var result = (from d in db.Children
                          where d.ChildName.Equals(description)
                          select new Models.ChildrenModel
                          {
                              IsActive = d.IsActive,
                              ChildName = d.ChildName

                          }).FirstOrDefault();
            return result;
        }
        
        internal static IChildrenModel getChildrenInformationDescriptionById(HRMSEntities db, int employeeId)
        {
            var result = (from a in db.Children
                          where a.ChildrenId.Equals(employeeId)
                          select new Models.ChildrenModel
                          {
                              EmployeeId = a.EmployeeId,
                              ChildrenId = a.ChildrenId,
                              ChildName = a.ChildName,
                              DateOfBirth = a.DateOfBirth,
                              Email = a.Email,
                              Address = a.Address,
                              Mobile = a.Mobile,
                              DateCreated = a.DateCreated,
                              DateModified = a.DateModified,
                              IsActive = a.IsActive,
                              IsApproved = a.IsApproved

                          }).SingleOrDefault();

            return result;
        }

        internal static IEnumerable<IChildrenModel> GetChildrenInformationListById(HRMSEntities db, int employeeId)
        {
            var result = (from a in db.Children 
                          where a.EmployeeId.Equals(employeeId) && a.IsActive==true
                          select new Models.ChildrenModel
                          {
                              EmployeeId = a.EmployeeId,
                              ChildrenId = a.ChildrenId,
                              ChildName = a.ChildName,
                              DateOfBirth = a.DateOfBirth,
                              Email = a.Email,
                              Address = a.Address,
                              Mobile = a.Mobile,
                              DateCreated = a.DateCreated,
                              DateModified = a.DateModified,
                              IsActive = a.IsActive,
                              IsApproved = a.IsApproved

                          }).ToList();

            return result;
        }

        internal static IEnumerable<ICalendarEvent> getCalendarEvents(HRMSEntities db)
        {
            var result = (from a in db.CalendarEvents
                          select new Models.CalendarEventModel
                          {
                              EventId = a.EventId,
                              Start = a.Start,
                              End = a.End,
                              Description = a.Description,
                              IsFullDay = a.IsFullDay,
                              Subject = a.Subject,
                              ThemeColor = a.ThemeColor,
                              IsEditable = a.IsEditable,
                              DateCreated = a.DateCreated,
                              IsActive = a.IsActive,
                              UserId = a.UserId

                          }).OrderByDescending(p=>p.EventId);

            return result;
        }

        internal static IEnumerable<ICalendarEvent> getCalendarEventsByUserId(HRMSEntities db, int userId)
        {
            var result = (from a in db.CalendarEvents
                          where a.UserId.Equals(userId)
                          select new Models.CalendarEventModel
                          {
                              EventId = a.EventId,
                              Start = a.Start,
                              End = a.End,
                              Description = a.Description,
                              IsFullDay = a.IsFullDay,
                              Subject = a.Subject,
                              ThemeColor = a.ThemeColor,
                              IsActive = a.IsActive,
                              IsEditable = a.IsEditable,
                              DateCreated = a.DateCreated,
                              UserId = a.UserId
                              
                          }).OrderByDescending(p => p.EventId);

            return result;
        }

        internal static ICalendarEvent getCalendarEvent(HRMSEntities db, DateTime start, DateTime end)
        {
            var result = (from a in db.CalendarEvents
                          where a.Start.Equals(start) && a.End.Equals(end)
                          select new Models.CalendarEventModel
                          {
                              EventId = a.EventId,
                              Start = a.Start,
                              End = a.End,
                              Description = a.Description,
                              IsFullDay = a.IsFullDay,
                              Subject = a.Subject,
                              ThemeColor = a.ThemeColor,
                              IsActive = a.IsActive,
                              IsEditable = a.IsEditable,
                              UserId = a.UserId,
                              DateCreated = a.DateCreated

                          }).SingleOrDefault();

            return result;
        }

        internal static IEnumerable<IDay> getDays(HRMSEntities db)
        {
            var result = (from a in db.Days
                          select new Models.DayModel
                          {
                              DayId = a.DayId,
                              DayName = a.DayName,
                              IsActive = a.IsActive
                          }).OrderByDescending(p => p.DayId);

            return result;
        }

        internal static IEnumerable<IWeek> getWeeks(HRMSEntities db)
        {
            var result = (from a in db.Weeks
                          select new Models.WeekModel
                          {
                              WeekId = a.WeekId,
                              WeekName = a.WeekName,
                              IsActive = a.IsActive
                          }).OrderByDescending(p => p.WeekId);

            return result;
        }

        internal static IEnumerable<ISchedule> getSchedules(HRMSEntities db)
        {
            var result = (from a in db.Schedules
                          join c in db.Users on a.UserId equals c.UserId
                          join v in db.Days on a.DayId equals v.DayId
                          join b in db.Weeks on a.WeekId equals b.WeekId
                          select new Models.ScheduleModel
                          {
                              ScheduleId = a.ScheduleId,
                              ScheduleName = a.ScheduleName,
                              DayId = a.DayId,
                              DayName = v.DayName,
                              WeekId = a.WeekId,
                              WeekName = b.WeekName,
                              DateCreated = a.DateCreated,
                              IsActive = a.IsActive,
                              UserId = a.UserId,
                              Email = c.Email
                          }).OrderByDescending(p => p.WeekId);

            return result;
        }

        internal static IEnumerable<ISchedule> getSchedulesByCompanyId(HRMSEntities db, int userId)
        {
            var result = (from a in db.Schedules
                          where a.UserId.Equals(userId)
                          join c in db.Users on a.UserId equals c.UserId
                          join v in db.Days on a.DayId equals v.DayId
                          join b in db.Weeks on a.WeekId equals b.WeekId
                          select new Models.ScheduleModel
                          {
                              ScheduleId = a.ScheduleId,
                              ScheduleName = a.ScheduleName,
                              DayId = a.DayId,
                              DayName = v. DayName,
                              WeekId = a.WeekId,
                              WeekName = b.WeekName,
                              DateCreated = a.DateCreated,
                              IsActive = a.IsActive,
                              UserId = a.UserId,
                              Email = c.Email
                          }).OrderByDescending(p => p.ScheduleId);

            return result;
        }


    }
}