using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Models;

namespace AA.HRMS.Repositories.Queries
{
    public class EmployeeOnBoardQueries
    {
        internal static IEmployee getOnBoarderByCompany(HRMSEntities db, int? companyId, string lastName)
        {
            var result = (from d in db.Employees
                          where d.CompanyId == companyId
                          where d.LastName.Equals(lastName)
                          select new EmployeeModel
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
                              IsLocked = d.IsLocked,
                              EmploymentTypeId = d.EmploymentTypeId
                          }).FirstOrDefault();

            return result;
        }
        
        internal static IEmployee getOnBoarderByCompanyAndEmailAndStaffNumber(HRMSEntities db, int? companyId, string email, string staffNumber)
        {
            var result = (from d in db.Employees
                          where d.CompanyId == companyId && d.Email == email && d.StaffNumber == staffNumber
                          select new EmployeeModel
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
                              IsLocked = d.IsLocked
                          }).FirstOrDefault();

            return result;
        }
        
        internal static IEmployee getEmployeeByEmail(HRMSEntities db, string email)
        {
            var result = (from d in db.Employees
                          where d.Email.Equals(email)
                          join a in db.Genders on d.GenderId equals a.GenderId
                          join b in db.Levels on d.LevelId equals b.LevelId
                          join o in db.Grades on d.GradeId equals o.GradeId
                          join v in db.Countries on d.Nationality equals v.CountryId
                          join n in db.JobTitles on d.JobTitleId equals n.JobTitleId
                          select new EmployeeModel
                          {
                              LastName = d.LastName,
                              FirstName = d.FirstName,
                              MiddleName = d.MiddleName,
                              JobTitleId = d.JobTitleId,
                              JobTitle = n.JobTitleName,
                              Email = d.Email,
                              CompanyId = d.CompanyId,
                              LevelId = d.LevelId,
                              LevelName = b.LevelName,
                              GradeName = o.GradeName,
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
                              IsLocked = d.IsLocked,
                              Gender = a.Description,
                              Nationality = v.Name,
                          }).FirstOrDefault();

            return result;
        }
        
        internal static IEmployee getOnBoardingById(HRMSEntities db, int employeeId)
        {
            var result = (from d in db.Employees
                          join a in db.Companies on d.CompanyId equals a.CompanyId
                          join m in db.Countries on d.Nationality equals m.CountryId
                          join n in db.States on d.HomeAddressState equals n.StateId
                          join f in db.States on d.PermanentAddressState equals f.StateId
                          join c in db.Levels on d.LevelId equals c.LevelId
                          join z in db.Grades on d.GradeId equals z.GradeId
                          join w in db.JobTitles on d.JobTitleId equals w.JobTitleId
                          join q in db.Genders on d.GenderId equals q.GenderId
                          join e in db.Departments on d.DepartmentId equals e.DepartmentId
                          select new EmployeeModel
                          {
                              LastName = d.LastName,
                              FirstName = d.FirstName,
                              MiddleName = d.MiddleName,
                              Email = d.Email,
                              CompanyId = d.CompanyId,
                              CompanyName = a.CompanyName,
                              LevelId = d.LevelId,
                              LevelName = c.LevelName,
                              GradeId = d.GradeId,
                              GradeName = z.GradeName,
                              MobileNumber = d.MobileNumber,
                              PermanentAddress = d.PermanentAddress,
                              PermanentAddressCity = d.PermanentAddressCity,
                              PermanentAddressStateId = d.PermanentAddressState,
                              PermanentAddressState = f.Name,
                              HomeAddressState = n.Name,
                              Nationality = m.Name,
                              HomeAddress = d.HomeAddress,
                              HomeAddressCity = d.HomeAddressCity,
                              HomeAddressStateId = d.HomeAddressState,
                              OtherEmail = d.OtherEmail,
                              Birthday = d.Birthday,
                              MartialStatusId = d.MaritalStatusId,
                              GenderId = d.GenderId,
                              Gender = q.Description,
                              StaffNumber = d.StaffNumber,
                              DateEmployed = d.DateEmployed,
                              About = d.About,
                              DateExited = d.DateExited,
                              SkillSet = d.SkillSet,
                              SupervisorEmployeeId = d.SupervisorEmployeeId,
                              SeatingLocation = d.SeatingLocation,
                              DepartmentId = d.DepartmentId,
                              Department = e.DepartmentName,
                              MaidenName = d.MaidenName,
                              PhotoDigitalFileId = d.PhotoDigitalFileId,
                              ReligionId = d.ReligionId,
                              NationalityId = d.Nationality,
                              DateCreated = d.DateCreated,
                              EmployeeId = d.EmployeeId,
                              JobTitleId = d.JobTitleId,
                              JobTitle = w.JobTitleName,
                              IsLocked = d.IsLocked,
                              IsActive = d.IsActive,
                              IsExit = d.IsExit,
                              EmploymentTypeId = d.EmploymentTypeId,
                              
                          }).Where(d => d.EmployeeId == employeeId).FirstOrDefault();

            return result;
        }
        
        internal static IEnumerable<IEmployee> getOnBoardingList(HRMSEntities db)
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
                              IsLocked = d.IsLocked,

                          }).OrderBy(x => x.LastName);

            return result;
        }

        internal static IEnumerable<IPromotion> getPromotionsByEmployeeId(HRMSEntities db, int employeeId)
        {
            var result = (from d in db.Promotions
                          where d.EmployeeId.Equals(employeeId)
                          join a in db.Employees on d.EmployeeId equals a.EmployeeId
                          join b in db.Levels on d.LevelId equals b.LevelId
                          join c in db.Grades on d.GradeId equals c.GradeId
                          select new Models.PromotionModel
                          {
                              PromotionId = d.PromotionId,
                              EmployeeId = d.EmployeeId,
                              LevelId = d.LevelId,
                              GradeId = d.GradeId,
                              LevelName = b.LevelName,
                              GradeName = c.GradeName,
                              DateCreated = d.DateCreated,
                              DatePromoted = d.DatePromoted,
                              EmployeeName = a.LastName + " " + a.FirstName,
                              IsActive = d.IsActive,
                              CompanyId = d.CompanyId
                              
                          }).OrderBy(x => x.PromotionId);

            return result;
        }
        
        internal static IEnumerable<IPromotion> getPromotionsByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.Promotions
                          where d.CompanyId.Equals(companyId)
                          join a in db.Employees on d.EmployeeId equals a.EmployeeId
                          join b in db.Levels on d.LevelId equals b.LevelId
                          join c in db.Grades on d.GradeId equals c.GradeId
                          select new Models.PromotionModel
                          {
                              PromotionId = d.PromotionId,
                              EmployeeId = d.EmployeeId,
                              LevelId = d.LevelId,
                              GradeId = d.GradeId,
                              LevelName = b.LevelName,
                              GradeName = c.GradeName,
                              DateCreated = d.DateCreated,
                              DatePromoted = d.DatePromoted,
                              EmployeeName = a.LastName + " " + a.FirstName,
                              IsActive = d.IsActive,
                              CompanyId = d.CompanyId,
                              
                          }).OrderBy(x => x.PromotionId);

            return result;
        }

    }
}
