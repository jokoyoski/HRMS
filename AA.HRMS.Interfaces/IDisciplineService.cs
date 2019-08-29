using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IDisciplineService
    {
        /// <summary>
        /// Creates the discipline list.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="selectedCompanyid">The selected companyid.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IDisciplineListView CreateDisciplineList(int? selectedCompanyid, string message);

        /// <summary>
        /// Creates the employee discipline list.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IDisciplineListView CreateEmployeeDisciplineList(int? selectedCompanyId, string message);

        /// <summary>
        /// Gets the discipline view.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IDisciplineView GetDisciplineView(int employeeId);

        /// <summary>
        /// Creates the employee discipline list.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IDisciplineListView CreateEmployeeDisciplineList(int employeeId, int? selectedCompanyId, string message);

        /// <summary>
        /// Gets the discipline view.
        /// </summary>
        /// <param name="disciplineView">The discipline view.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IDisciplineView GetDisciplineView(IDisciplineView disciplineView, string processingMessage);

        /// <summary>
        /// Processes the discipline information.
        /// </summary>
        /// <param name="disciplineView">The discipline view.</param>
        /// <returns></returns>
        string ProcessDisciplineInfo(IDisciplineView disciplineView);

        /// <summary>
        /// Gets the discipline edit view.
        /// </summary>
        /// <param name="disciplineId">The discipline identifier.</param>
        /// <returns></returns>
        IDisciplineView GetDisciplineEditView(int disciplineId);

        /// <summary>
        /// Processes the edit discipline information.
        /// </summary>
        /// <param name="disciplineInfo">The discipline information.</param>
        /// <returns></returns>
        string ProcessEditDisciplineInfo(IDisciplineView disciplineInfo);

        /// <summary>
        /// Processes the delte discipline information.
        /// </summary>
        /// <param name="disciplineId">The discipline identifier.</param>
        /// <returns></returns>
        string ProcessDelteDisciplineInfo(int disciplineId);

    }
}
