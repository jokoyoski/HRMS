using System;
using System.Collections.Generic;
using System.Linq;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Queries;

namespace AA.HRMS.Repositories.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IDepartmentRepository" />
    public class DepartmentRepository : IDepartmentRepository
    {
        /// <summary>
        /// The database context factory
        /// </summary>
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public DepartmentRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }


        /// <summary>
        /// Gets the name of the department by.
        /// </summary>
        /// <param name="departmentName">Name of the department.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetDepartmentByName</exception>
        public IDepartment GetCompanyDepartmentByName(string departmentName, int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = DepartmentQueries.getDepartmentByName(dbContext, departmentName, companyId);
                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetDepartmentByName", e);
            }
        }

        /// <summary>
        /// Gets the company department by identifier.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetDepartmentByName</exception>
        public IDepartment GetCompanyDepartmentById(int departmentId, int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = DepartmentQueries.getDepartmentById(dbContext, departmentId, companyId);
                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetDepartmentByName", e);
            }
        }

        /// <summary>
        /// Gets all department.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetDepartmentAll Department</exception>
        public IList<IDepartment> GetAllDepartment()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = DepartmentQueries.getAllDepartments(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAllDepartment", e);
            }
        }


        /// <summary>
        /// Saves the department information.
        /// </summary>
        /// <param name="deptInfo">The dept information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">deptInfo</exception>
        /// <exception cref="System.ArgumentNullException">deptInfo</exception>
        public string SaveDepartmentInfo(IDepartmentView deptInfo)
        {
            if (deptInfo == null) throw new ArgumentNullException(nameof(deptInfo));

            var result = string.Empty;

            var newRecord = new Department
            {
                Description = deptInfo.Description,
                DepartmentId = deptInfo.DepartmentId,
                IsActive = deptInfo.IsActive,
                DepartmentName = deptInfo.DepartmentName,
                ParentDepartmentID = deptInfo.ParentDepartmentId,
                CompanyId = deptInfo.CompanyId,
                DateCreated = deptInfo.DateCreated
            };
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Departments.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveRegistrationInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Updates the department information.
        /// </summary>
        /// <param name="deptInfo">The dept information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">deptInfo</exception>
        /// <exception cref="ApplicationException">departmentData</exception>
        public string UpdateDepartmentInfo(IDepartmentView deptInfo)
        {
            if (deptInfo == null) throw new ArgumentNullException(nameof(deptInfo));

            var result = string.Empty;
            
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var departmentData =
                        dbContext.Departments.SingleOrDefault(m => m.DepartmentId.Equals(deptInfo.DepartmentId));
                    if (departmentData == null)
                    {
                        throw new ApplicationException(nameof(departmentData));
                    }

                    departmentData.Description = deptInfo.Description;
                    departmentData.DepartmentName = deptInfo.DepartmentName;
                    departmentData.ParentDepartmentID = deptInfo.ParentDepartmentId;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Update Department Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets the department by identifier.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetDepartmentById</exception>
        public IDepartment GetDepartmentById(int departmentId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord =
                        DepartmentQueries.GetDepartmentById(dbContext, departmentId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetDepartmentById", e);
            }
        }

        /// <summary>
        /// Deletes the department information.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">departmentId</exception>
        /// <exception cref="ApplicationException">departmentId</exception>
        public string DeleteDepartmentInfo(int departmentId)
        {
            if (departmentId < 1)
            {
                throw new ArgumentOutOfRangeException("departmentId");
            }

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var departmentData =  dbContext.Departments.SingleOrDefault(m => m.DepartmentId.Equals(departmentId));

                    if (departmentData == null)
                    {
                        throw new ApplicationException("departmentId");
                    }

                    departmentData.IsActive = false;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete Department Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Gets all my departments.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAllDepartment</exception>
        public IList<IDepartment> GetAllMyDepartments(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = DepartmentQueries.getMyAllDepartments(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAllDepartment", e);
            }
        }
    }
}