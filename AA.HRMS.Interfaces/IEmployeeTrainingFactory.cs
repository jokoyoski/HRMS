using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{ 

    public interface IEmployeeTrainingFactory
    {

        /// <summary>
        /// Creates the employee training view.
        /// </summary>
        /// <param name="employeeTrainingModel">The employee training model.</param>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="training">The training.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="trainingReport">The training report.</param>
        /// <returns></returns>
        IEmployeeTrainingView CreateEmployeeTrainingView(IList<IEmployeeTrainingModel> employeeTrainingModel, ICompanyDetail companyInfo, IList<ITraining> training, IList<IEmployee> employee, IList<ITrainingReport> trainingReport);

        /// <summary>
        /// Gets the trainee ListView.
        /// </summary>
        /// <param name="selectedCompanyid">The selected companyid.</param>
        /// <param name="selectedTraining">The selected training.</param>
        /// <param name="employeeTrainingCollection">The employee training collection.</param>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="trainingCollection">The training collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="trainigReport">The trainig report.</param>
        /// <returns></returns>
        IEmployeeTrainingListView GetTraineeListView(int? selectedCompanyid, int? selectedTraining, IList<IEmployeeTrainingModel> employeeTrainingCollection,  ICompanyDetail companyInfo, IList<ITraining> trainingCollection, string processingMessage,  IList<ITrainingReport> trainigReport);

        /// <summary>
        /// Creates the edit employee training view.
        /// </summary>
        /// <param name="employeeTrainingModel">The employee training model.</param>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="trainingCollection">The training collection.</param>
        /// <returns></returns>
        IEmployeeTrainingView CreateEditEmployeeTrainingView(IEmployeeTrainingModel employeeTrainingModel, ICompanyDetail companyInfo, IList<IEmployee> employeeCollection, IList<ITraining> trainingCollection);

        /// <summary>
        /// Creates the employee training view.
        /// </summary>
        /// <param name="employeeTrainingInfo">The employee training information.</param>
        /// <param name="training">The training.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="trainingReport">The training report.</param>
        /// <returns></returns>
        IEmployeeTrainingView CreateEmployeeTrainingView(IEmployeeTrainingView employeeTrainingInfo, IList<ITraining> training, 
            IList<IEmployee> employee, string processingMessage, IList<ITrainingReport> trainingReport);

        /// <summary>
        /// Creates the specific employee training view.
        /// </summary>
        /// <param name="selectedEmployeeId">The selected employee identifier.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="company">The company.</param>
        /// <param name="trainingCollection">The training collection.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeTrainingListView CreateSpecificEmployeeTrainingView(int? selectedEmployeeId, IEmployee employee, ICompanyDetail company, IList<IEmployeeTrainingModel> trainingCollection, IList<ICompanyDetail> companyCollection, string processingMessage);

        /// <summary>
        /// Creates the employee training request view.
        /// </summary>
        /// <param name="employeeTrainingModel">The employee training model.</param>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="training">The training.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="employeeMOdel">The employee m odel.</param>
        /// <returns></returns>
        IEmployeeTrainingView CreateEmployeeTrainingRequestView(IList<IEmployeeTrainingModel> employeeTrainingModel, ICompanyDetail companyInfo, IList<ITraining> training, IList<IEmployee> employee, IEmployee employeeMOdel);

    }
}
