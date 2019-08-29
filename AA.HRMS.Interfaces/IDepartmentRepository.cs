using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDepartmentRepository
    {

        /// <summary>
        /// Gets the name of the company department by.
        /// </summary>
        /// <param name="departmentName">Name of the department.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IDepartment GetCompanyDepartmentByName(string departmentName, int companyId);

        /// <summary>
        /// Gets the company department by identifier.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IDepartment GetCompanyDepartmentById(int departmentId, int companyId);

        /// <summary>
        /// Saves the department information.
        /// </summary>
        /// <param name="deptInfo">The dept information.</param>
        /// <returns></returns>
        string SaveDepartmentInfo(IDepartmentView deptInfo);

        /// <summary>
        /// Updates the department information.
        /// </summary>
        /// <param name="deptInfo">The dept information.</param>
        /// <returns></returns>
        string UpdateDepartmentInfo(IDepartmentView deptInfo);

        /// <summary>
        /// Deletes the department information.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns></returns>
        string DeleteDepartmentInfo(int departmentId);

        /// <summary>
        /// Gets all department.
        /// </summary>
        /// <returns></returns>
        IList<IDepartment> GetAllDepartment();

        /// <summary>
        /// Gets the department by identifier.
        /// </summary>
        /// <param name="department">The department.</param>
        /// <returns></returns>
        IDepartment GetDepartmentById(int department);

        /// <summary>
        /// Gets all my departments.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IDepartment> GetAllMyDepartments(int companyId);
    }
}