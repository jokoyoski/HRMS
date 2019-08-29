using System.Collections.Generic;
using System.Linq;
using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Models;

namespace AA.HRMS.Repositories.Queries
{
    /// <summary>
    /// 
    /// </summary>
    internal static class DepartmentQueries
    {
        /// <summary>
        /// Gets the name of the department by.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="departmentName">Name of the department.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IDepartment getDepartmentByName(HRMSEntities db, string departmentName, int companyId)
        {
            var result = (from d in db.Departments
                where d.DepartmentName.Equals(departmentName) && d.CompanyId == companyId
                select new DepartmentModel
                {
                    Description = d.Description,
                    DepartmentId = d.DepartmentId,
                    IsActive = d.IsActive,
                    DepartmentName = d.DepartmentName,
                    ParentDepartmentId = d.ParentDepartmentID,
                    CompanyId = d.CompanyId,
                    DateCreated = d.DateCreated
                }).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the department by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IDepartment getDepartmentById(HRMSEntities db, int departmentId, int companyId)
        {
            var result = (from d in db.Departments
                where d.DepartmentId.Equals(departmentId) && d.CompanyId == companyId
                select new DepartmentModel
                {
                    Description = d.Description,
                    DepartmentId = d.DepartmentId,
                    IsActive = d.IsActive,
                    DepartmentName = d.DepartmentName,
                    ParentDepartmentId = d.ParentDepartmentID,
                    CompanyId = d.CompanyId,
                    DateCreated = d.DateCreated
                }).FirstOrDefault();
            return result;
        }
        /// <summary>
        /// Gets all departments.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IDepartment> getAllDepartments(HRMSEntities db)
        {
            var result = (from d in db.Departments
                          join e in db.Companies on d.CompanyId equals e.CompanyId
                          join pdept in db.Departments on d.ParentDepartmentID equals pdept.DepartmentId into gj
                          from f in gj.DefaultIfEmpty()
                          select new DepartmentModel
                          {
                              Description = d.Description,
                              DepartmentId = d.DepartmentId,
                              IsActive = d.IsActive,
                              DepartmentName = d.DepartmentName,
                              ParentDepartmentId = d.ParentDepartmentID,
                              CompanyId = d.CompanyId,
                              DateCreated = d.DateCreated,
                              CompanyName = e.CompanyName,
                              ParentDepartmentName = f.DepartmentName
                          }).Where(x=>x.IsActive ==true).OrderBy(m => m.CompanyName);

            return result;
        }

        /// <summary>
        /// Gets all departments.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IDepartment> getMyAllDepartments(HRMSEntities db, int companyId)
        {
            var result = (from d in db.Departments
                join e in db.Companies on d.CompanyId equals e.CompanyId
                join pdept in db.Departments on d.ParentDepartmentID equals pdept.DepartmentId into gj
                from f in gj.DefaultIfEmpty()
                select new DepartmentModel
                {
                    Description = d.Description,
                    DepartmentId = d.DepartmentId,
                    IsActive = d.IsActive,
                    DepartmentName = d.DepartmentName,
                    ParentDepartmentId = d.ParentDepartmentID,
                    CompanyId = d.CompanyId,
                    DateCreated = d.DateCreated,
                    CompanyName = e.CompanyName,
                    ParentDepartmentName = f.DepartmentName
                }).Where(c=>c.CompanyId.Equals(companyId) && c.IsActive.Equals(true))
                .OrderBy(m=>m.CompanyName);

            return result;
        }

        /// <summary>
        /// Gets the department by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns></returns>
        internal static IDepartment GetDepartmentById(HRMSEntities db, int departmentId)
        {
            var result = (from d in db.Departments
                join e in db.Companies on d.CompanyId equals e.CompanyId
                join pdept in db.Departments on d.ParentDepartmentID equals pdept.DepartmentId into gj
                from f in gj.DefaultIfEmpty()
                where d.DepartmentId == departmentId
                select new DepartmentModel
                {
                    Description = d.Description,
                    DepartmentId = d.DepartmentId,
                    IsActive = d.IsActive,
                    DepartmentName = d.DepartmentName,
                    ParentDepartmentId = d.ParentDepartmentID,
                    CompanyId = d.CompanyId,
                    DateCreated = d.DateCreated,
                    CompanyName = e.CompanyName,
                    ParentDepartmentName = f.DepartmentName
                }).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Gets all my asset.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IDepartment> getAllMyAsset(HRMSEntities db, int companyId)
        {
            var result = (from d in db.Departments
                where d.CompanyId == companyId
                join e in db.Companies on d.CompanyId equals e.CompanyId
                join pdept in db.Departments on d.ParentDepartmentID equals pdept.DepartmentId into gj
                from f in gj.DefaultIfEmpty()
                select new DepartmentModel
                {
                    Description = d.Description,
                    DepartmentId = d.DepartmentId,
                    IsActive = d.IsActive,
                    DepartmentName = d.DepartmentName,
                    ParentDepartmentId = d.ParentDepartmentID,
                    CompanyId = d.CompanyId,
                    DateCreated = d.DateCreated,
                    CompanyName = e.CompanyName,
                    ParentDepartmentName = f.DepartmentName
                }).ToList();

            return result;
        }
    }
}