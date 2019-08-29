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
    public class EmployeeTrainingQueries
    {
        /// <summary>
        /// Gets the employee training by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="EmpTraining">The emp training.</param>
        /// <returns></returns>
        internal static IEmployeeTrainingModel GetEmployeeTrainingById (HRMSEntities db, int EmpTraining)
        {
            var result = (from d in db.EmployeeTrainings
                          where d.EmployeeTrainingId.Equals(EmpTraining)
                          select new EmployeeTrainingModel
                          {
                              TrainingId = d.TrainingId,
                              EmployeeId = d.EmployeeId,
                              SupervisorId = d.SupervisorId,
                              IsApproved = d.IsApproved,
                              IsActive = d.IsActive,
                              DateApproved = d.DateApproved,
                              DateCreated = DateTime.Now
                          }).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the employee training list.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="EmployeeId">The employee identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IEmployeeTrainingModel> getEmployeeTrainingList(HRMSEntities db, int EmployeeId)
        {
            // get the company Ids that are associated with the HR username
            var EmployeeIds = (from d in db.EmployeeTrainings
                              where d.EmployeeId == EmployeeId
                              select d.EmployeeTrainingId).ToList();

            var EmployeeList = new List<IEmployeeTrainingModel>();

            // get the company and child company details for each companyId in the companyIds list
            foreach (int employeeId in EmployeeIds)
            {
                EmployeeList.AddRange(GetEmployeeTraining(db, employeeId).ToList());
            }

            return EmployeeList;
        }


        /// <summary>
        /// Gets the employee training.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IEmployeeTrainingModel> GetEmployeeTraining(HRMSEntities db, int companyId)
        {
            var result = (from d in db.EmployeeTrainings
                          join w in db.Companies on d.CompanyId equals w.CompanyId
                          join q in db.Employees on d.EmployeeId equals q.EmployeeId
                          join r in db.Employees on d.SupervisorId equals r.EmployeeId
                          join s in db.Trainings on d.TrainingId equals s.TrainingID
                          where d.CompanyId.Equals(companyId)
                          select new EmployeeTrainingModel
                          {
                              EmployeeTrainingId = d.EmployeeTrainingId,
                              CompanyId = d.CompanyId,
                              TrainingId = d.TrainingId,
                              EmployeeId = d.EmployeeId,
                              SupervisorId = d.SupervisorId,
                              SupervisorName = r.LastName + " " + r.FirstName,
                              IsApproved = d.IsApproved,
                              IsActive = d.IsActive,
                              DateApproved = d.DateApproved,
                              DateCreated = d.DateCreated,
                              CompanyName = w.CompanyName,
                              EmployeeName = q.FirstName + " " + q.LastName,
                              TrainingName = s.TrainingName,
                              TrainingReportId = d.TrainingReportId,
                          }).OrderBy(p=>p.CompanyName);
            return result;
        }

        /// <summary>
        /// Gets all my employee trainings.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        internal static IEmployeeTrainingModel getAllMyEmployeeTrainings (HRMSEntities db, int id)
        {
            var result = (from d in db.EmployeeTrainings
                          where d.EmployeeTrainingId.Equals(id)
                          select new Models.EmployeeTrainingModel
                          {
                              EmployeeTrainingId = d.EmployeeTrainingId,
                              EmployeeId = d.EmployeeId,
                              SupervisorId = d.SupervisorId,
                              IsActive = d.IsActive,
                              IsApproved = d.IsApproved,
                              DateApproved = d.DateApproved,
                              DateCreated = d.DateCreated,
                              TrainingId = d.TrainingId,
                              CompanyId = d.CompanyId



                          }).FirstOrDefault();
            return result;
        }
        /// <summary>
        /// Gets the employee by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="EmployeeID">The employee identifier.</param>
        /// <returns></returns>
        internal static IEmployeeTrainingModel getEmployeeById (HRMSEntities db, int EmployeeID)
        {
            var result = (from d in db.EmployeeTrainings
                          join w in db.Companies on d.CompanyId equals w.CompanyId
                          join q in db.Employees on d.EmployeeId equals q.EmployeeId
                          join s in db.Trainings on d.TrainingId equals s.TrainingID
                          where d.EmployeeId.Equals(EmployeeID)
                          select new EmployeeTrainingModel
                          {
                              EmployeeTrainingId = d.EmployeeTrainingId,
                              CompanyId = d.CompanyId,
                              TrainingId = d.TrainingId,
                              EmployeeId = d.EmployeeId,
                              SupervisorId = d.SupervisorId,
                              IsApproved = d.IsApproved,
                              IsActive = d.IsActive,
                              DateApproved = d.DateApproved,
                              DateCreated = d.DateCreated,
                              CompanyName = w.CompanyName,
                              EmployeeName = q.FirstName + " " + q.LastName,
                              TrainingName = s.TrainingName
                          }).FirstOrDefault();
            return result;
        }

    }
}
