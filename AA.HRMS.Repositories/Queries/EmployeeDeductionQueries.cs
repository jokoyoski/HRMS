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
    internal static class EmployeeDeductionQueries
    {
        /// <summary>
        /// Gets the deduction by employee identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IEmployeeDeduction> getDeductionByEmployeeId(HRMSEntities db, int employeeId)
        {
            var result = (from a in db.EmployeeDeductions
                          where a.EmployeeId.Equals(employeeId) && a.IsActive.Equals(true)
                          join b in db.Deductions on a.DeductionId equals b.DeductionId
                          select new EmployeeDeductionModel
                          {
                              EmployeeDeductionId = a.EmployeeDeductionId,
                              DeductionId = a.DeductionId,
                              CompanyId = a.CompanyId,
                              DeductionAmount = b.DeductionAmount,
                              DeductionName = b.DeductionName,
                              IsActive = a.IsActive,
                              DateCreated = a.DateCreated,
                              EmployeeId = a.EmployeeId

                          }).OrderBy(p => p.DateCreated);

            return result;
        }


       

        internal static IEnumerable<IDeduction> getEmployeeDeductionByEmployeeId(HRMSEntities db, int employeeId)
        {
            var result = (from d in db.Deductions
                          where d.EmployeeId.Equals(employeeId) && d.IsActive.Equals(true) /*&& d.IsTerminated == false*/
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
                              IsTerminated = d.IsTerminated,
                          }).OrderBy(p => p.DateCreated);

            return result;
        }



        internal static IDeduction getAllEmployeeDeductionByEmployeeId(HRMSEntities db, int employeeId)
        {
            var result = (from d in db.Deductions
                          where d.EmployeeId.Equals(employeeId) && d.IsActive.Equals(true)
                          join s in db.Employees on d.EmployeeId equals s.EmployeeId

                          select new Models.DeductionModel
                          {
                              DeductionId = d.DeductionId,
                              EmployeeId = d.EmployeeId,
                              CompanyId = d.CompanyId,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              EemployeeName = s.LastName + " " + s.FirstName,
                              DeductionAmount = d.DeductionAmount,
                              DeductionName = d.DeductionName
                          }).OrderBy(p => p.DateCreated).FirstOrDefault();

            return result;
        }



        /// <summary>
        /// Gets the employee deduction by employee identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        internal static IEmployeeDeduction getEmployeeDeductionByEmployeeId(HRMSEntities db, int employeeId, int deductionId)
        {
            var result = (from a in db.EmployeeDeductions
                          where a.EmployeeId.Equals(employeeId) && a.DeductionId.Equals(deductionId) && a.IsActive.Equals(true)
                          select new EmployeeDeductionModel
                          {
                              EmployeeDeductionId = a.EmployeeDeductionId,
                              DeductionId = a.DeductionId,
                              CompanyId = a.CompanyId,
                              IsActive = a.IsActive,
                              DateCreated = a.DateCreated,
                              EmployeeId = a.EmployeeId

                          }).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Gets the employee deduction by company identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IEmployeeDeduction> getEmployeeDeductionByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from a in db.EmployeeDeductions
                          join x in db.Companies on a.CompanyId equals x.CompanyId
                          where a.CompanyId.Equals(companyId) && a.IsActive.Equals(true)
                          select new Models.EmployeeDeductionModel
                          {
                              EmployeeDeductionId = a.EmployeeDeductionId,
                              DeductionId = a.DeductionId,
                              EmployeeId = a.EmployeeId,
                              CompanyId = a.CompanyId,
                              DateCreated = a.DateCreated,
                              IsActive = a.IsActive,

                          }).OrderBy(p => p.EmployeeDeductionId);

            return result;
        }

        /// <summary>
        /// Gets all my employee deductions.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IEmployeeDeduction> getAllMyEmployeeDeductions(HRMSEntities db, int companyId)
        {
            var result = (from d in db.EmployeeDeductions
                          where d.CompanyId == companyId && d.IsActive.Equals(true)
                          join e in db.Companies on d.CompanyId equals e.CompanyId
                          join pdept in db.EmployeeDeductions on d.EmployeeDeductionId equals pdept.EmployeeDeductionId into gj
                          from f in gj.DefaultIfEmpty()
                          select new EmployeeDeductionModel
                          {
                              EmployeeDeductionId = d.EmployeeDeductionId,
                              EmployeeId = d.EmployeeId,
                              CompanyId = e.CompanyId,
                              DeductionId = d.DeductionId,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,

                          }).OrderBy(p => p.EmployeeDeductionId);

            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        internal static IEnumerable<IEmployeeDeduction> getDeductionByCompanyId(HRMSEntities db, int CompanyId)
        {
            var result = (from a in db.EmployeeDeductions
                          where a.CompanyId.Equals(CompanyId) && a.IsActive.Equals(true)
                          join b in db.Deductions on a.DeductionId equals b.DeductionId
                          select new EmployeeDeductionModel
                          {
                              EmployeeDeductionId = a.EmployeeDeductionId,
                              DeductionId = a.DeductionId,
                              CompanyId = a.CompanyId,
                              DeductionAmount = b.DeductionAmount,
                              DeductionName = b.DeductionName,
                              IsActive = a.IsActive,
                              DateCreated = a.DateCreated,
                              EmployeeId = a.EmployeeId

                          }).OrderBy(p => p.DateCreated);

            return result;
        }



        /// <summary>
        /// Gets the employee deduction by deduction identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="deductionId">The deduction identifier.</param>
        /// <returns></returns>
        internal static IEmployeeDeduction getEmployeeDeductionByDeductionId(HRMSEntities db, int deductionId)
        {
            var result = (from s in db.EmployeeDeductions
                          where s.DeductionId.Equals(deductionId) && s.IsActive.Equals(true)
                          select new Models.EmployeeDeductionModel
                          {
                              EmployeeDeductionId = s.EmployeeDeductionId,
                              EmployeeId = s.EmployeeId,
                              CompanyId = s.CompanyId,
                              DeductionId = s.DeductionId,
                              IsActive = s.IsActive,
                              DateCreated = s.DateCreated,

                          }).FirstOrDefault();

            return result;
        }



        /// <summary>
        /// Gets the employee deduction by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="employeeDeductionId">The employee deduction identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IEmployeeDeduction> getEmployeeDeductionById(HRMSEntities db, int employeeDeductionId)
        {
            var result = (from s in db.EmployeeDeductions
                          where s.EmployeeDeductionId.Equals(employeeDeductionId) && s.IsActive.Equals(true)
                          select new Models.EmployeeDeductionModel
                          {
                              EmployeeDeductionId = s.EmployeeDeductionId,
                              EmployeeId = s.EmployeeId,
                              CompanyId = s.CompanyId,
                              DeductionId = s.DeductionId,
                              IsActive = s.IsActive,
                              DateCreated = s.DateCreated,

                          }).OrderBy(p => p.EmployeeDeductionId);

            return result;
        }

        /// <summary>
        /// Gets the employee deduction by employee deduction identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="employeeDeductionId">The employee deduction identifier.</param>
        /// <returns></returns>
        internal static IEmployeeDeduction getEmployeeDeductionByEmployeeDeductionId(HRMSEntities db, int employeeDeductionId)
        {
            var result = (from s in db.EmployeeDeductions
                          where s.EmployeeDeductionId.Equals(employeeDeductionId) && s.IsActive.Equals(true)
                          select new Models.EmployeeDeductionModel
                          {
                              EmployeeDeductionId = s.EmployeeDeductionId,
                              EmployeeId = s.EmployeeId,
                              CompanyId = s.CompanyId,
                              DeductionId = s.DeductionId,
                              IsActive = s.IsActive,
                              DateCreated = s.DateCreated,

                          }).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Gets the employee deduction list by employee deduction identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="employeeDeductionId">The employee deduction identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IDeduction> getEmployeeDeductionListByEmployeeDeductionId(HRMSEntities db, int employeeDeductionId)
        {
            var result = (from s in db.Deductions
                          where s.DeductionId.Equals(employeeDeductionId) 
                          select new Models.DeductionModel
                          {
                              DeductionAmount = s.DeductionAmount,
                              DateStarted = s.DateStarted,
                              DateTerminated = s.DateTerminated,
                              DeductionName= s.DeductionName,
                              IsTerminated = s.IsTerminated,

                              EmployeeId = s.EmployeeId,
                              CompanyId = s.CompanyId,
                              DeductionId = s.DeductionId,
                              IsActive = s.IsActive,
                              DateCreated = s.DateCreated,

                          }).OrderBy(p=>p.DeductionId);

            return result;
        }

        
    }
}
