using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Queries
{
    public class EmployeeQueries
    {
        /// <summary>
        /// Gets the employee by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        internal static IEmployee getEmployeeById(HRMSEntities db, int employeeId)
        {
            var result = (from a in db.Employees
                          where a.EmployeeId.Equals(employeeId)
                          join e in db.Departments on a.DepartmentId equals e.DepartmentId
                          join r in db.Levels on a.LevelId equals r.LevelId
                          join d in db.Grades on a.GradeId equals d.GradeId
                          join w in db.Companies on a.CompanyId equals w.CompanyId
                          join s in db.JobTitles on a.JobTitleId equals s.JobTitleId
                          join b in db.Countries on a.Nationality equals b.CountryId
                          join n in db.States on a.PermanentAddressState equals n.StateId
                          join m in db.States on a.HomeAddressState equals m.StateId
                          join t in db.Genders on a.GenderId equals t.GenderId
                          join z in db.Religions on a.ReligionId equals z.ReligionId
                          join q in db.MaritalStatus on a.MaritalStatusId equals q.MaritalStatusId
                          select new Models.EmployeeModel
                          {
                              EmployeeId = a.EmployeeId,
                              MobileNumber = a.MobileNumber,
                              HomeAddress = a.HomeAddress,
                              HomeAddressCity = a.HomeAddressCity,
                              HomeAddressState = m.Name,
                              Nationality = b.Name,
                              Gender = t.Description,
                              LastName = a.LastName,
                              FirstName = a.FirstName,
                              CompanyId = a.CompanyId,
                              CompanyName = w.CompanyName,
                              PermanentAddress = a.PermanentAddress,
                              PermanentAddressCity = a.PermanentAddressCity,
                              PermanentAddressState = n.Name,
                              Religion = z.Description,
                              MaritalStatus = q.Description,
                              GenderOother = a.GenderOther,
                              Email = a.Email,
                              DepartmentId = a.DepartmentId,
                              Department = e.DepartmentName,
                              Birthday = a.Birthday,
                              DateEmployed = a.DateEmployed,
                              LevelId = a.LevelId,
                              LevelName = r.LevelName,
                              GradeId = a.GradeId,
                              GradeName = d.GradeName,
                              StaffNumber = a.StaffNumber,
                              JobTitle = s.JobTitleName,
                              IsExit = a.IsExit,
                              ReligionOther = a.ReligionOther,
                              PhotoDigitalFileId = a.PhotoDigitalFileId, 
                              SupervisorEmployeeId = a.SupervisorEmployeeId,
                              
                          }).FirstOrDefault();
            return result;
        }

        internal static ISpouseModel GetSpouseByEmployee(HRMSEntities db, int employeeID)
        {
            var result = (from s in db.Spouses
                          where s.SpouseId == employeeID
                          join c in db.Employees on s.EmployeeId equals c.EmployeeId
                          select new Models.SpouseModel
                          {
                              EmployeeId = s.EmployeeId,
                              SpouseId = s.SpouseId,
                              Address = s.Address,
                              SpouseName = s.SpouseName,
                              Mobile = s.Mobile,
                              DateCreated = s.DateCreated,
                              DateModified = s.DateModified,
                              DateOfBirth = s.DateOfBirth,
                              Email = s.Email,
                              IsActive = s.IsActive,
                              IsApproved = s.IsApproved,
                             // employeeName = c.FirstName + " " + c.LastName
                              
                          }).FirstOrDefault();
            return result;
                          
        }


        internal static IEnumerable<ISpouseModel> GetSpouseInfoByEmployee(HRMSEntities db, int employeeID)
        {
            var result = (from s in db.Spouses
                          where s.EmployeeId == employeeID && s.IsActive==true
                          select new Models.SpouseModel
                          {
                              EmployeeId = s.EmployeeId,
                              SpouseId = s.SpouseId,
                              Address = s.Address,
                              SpouseName = s.SpouseName,
                              Mobile = s.Mobile,
                              DateCreated = s.DateCreated,
                              DateModified = s.DateModified,
                              DateOfBirth = s.DateOfBirth,
                              Email = s.Email,
                              IsActive = s.IsActive,
                              IsApproved = s.IsApproved,

                          }).ToList();
            return result;

        }

        internal static IEnumerable<IEmergency> GetEmployeeEmergencyContactById(HRMSEntities db, int employeeId)
        {
            var result = (from s in db.Emergencies
                          where s.EmployeeId == employeeId && s.IsActive.Equals(true)
                          select new Models.EmergencyModel
                          {
                              EmployeeId = s.EmployeeId,
                              EmergencyId = s.EmergencyId,
                              EmergencyName = s.EmergencyName,
                              DateCreated= s.DateCreated,
                              DateModified = s.DateModified,
                              DateOfBirth = s.DateOfBirth,
                              Address = s.Address,
                              Email = s.Email,
                              IsActive = s.IsActive,
                              IsApproved = s.IsApproved,
                              Mobile = s.Mobile,

                          }).ToList();
            return result;
        }
    }
}
