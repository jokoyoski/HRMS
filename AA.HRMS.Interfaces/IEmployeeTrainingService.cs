using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
   public  interface IEmployeeTrainingService
   {
        /// <summary>
        /// Gets all requested training by company.
        /// </summary>
        /// <param name="selectedEmployeeId">The selected employee identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeTrainingListView GetAllRequestedTrainingByCompany(int? selectedEmployeeId, string processingMessage);

        /// <summary>
        /// Gets the employee every training.
        /// </summary>
        /// <param name="selectedEmployeeId">The selected employee identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeTrainingListView GetEmployeeEveryTraining(int? selectedEmployeeId, string processingMessage);

        /// <summary>
        /// Gets the employee training view.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        IEmployeeTrainingView GetEmployeeTrainingView(int Id);

        /// <summary>
        /// Gets the create employee training.
        /// </summary>
        /// <param name="employeeTrainingInfo">The employee training information.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeTrainingView GetCreateEmployeeTraining(IEmployeeTrainingView employeeTrainingInfo, string processingMessage);


        /// <summary>
        /// Gets the create employee training by user identifier.
        /// </summary>
        /// <param name="reportId">The report identifier.</param>
        /// <returns></returns>
        IEmployeeTrainingView GetCreateEmployeeTrainingByUserId(int reportId);

        /// <summary>
        /// Saves the employee training.
        /// </summary>
        /// <param name="SaveEmployeeTraining">The save employee training.</param>
        /// <returns></returns>
        string SaveEmployeeTraining(IEmployeeTrainingView SaveEmployeeTraining, ITrainingView trainingView);

        /// <summary>
        /// Processes the edit employee training.
        /// </summary>
        /// <param name="employeeTrainingView">The employee training view.</param>
        /// <returns></returns>
        string ProcessEditEmployeeTraining(IEmployeeTrainingView employeeTrainingView);

        /// <summary>
        /// Processes the delete employee training information.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        string ProcessDeleteEmployeeTrainingInfo(int employeeTrainingId);

        /// <summary>
        /// Gets the employee training.
        /// </summary>
        /// <param name="selectedCompanyid">The selected companyid.</param>
        /// <param name="selectedTraining">The selected training.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="trainingReportId">The training report identifier.</param>
        /// <returns></returns>
        IEmployeeTrainingListView GetEmployeeTraining(int? selectedCompanyid, int? selectedTraining, string processingMessage,int trainingReportId);

        /// <summary>
        /// Gets the employee every training.
        /// </summary>
        /// <param name="selectedEmployeeId">The selected employee identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IEmployeeTrainingListView GetEmployeeEveryTraining(int? selectedEmployeeId, string processingMessage, int employeeId);

        /// <summary>
        /// Gets the create employee training by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IEmployeeTrainingView GetCreateEmployeeTrainingById(int employeeId);
   }
}
