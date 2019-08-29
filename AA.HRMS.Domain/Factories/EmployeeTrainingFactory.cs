using AA.HRMS.Domain.Models;
using AA.HRMS.Domain.Utilities;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Factories
{

    public class EmployeeTrainingFactory : IEmployeeTrainingFactory
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
        public IEmployeeTrainingView CreateEmployeeTrainingView(IList<IEmployeeTrainingModel> employeeTrainingModel, ICompanyDetail companyInfo, IList<ITraining> training, IList<IEmployee> employee, IList<ITrainingReport> trainingReport)
        {

            var TrainingDDL = GetDropDownList.TrainingListItems(training, -1);
            var EmployeeDDL = GetDropDownList.EmployeeListitems(employee, -1);


            var model = new EmployeeTrainingView
            {
                TrainingDropDownList = TrainingDDL,
                EmployeeDropDownList = EmployeeDDL,
                ProcessingMessage = string.Empty,
                CompanyId = companyInfo.CompanyId

            };
            return model;
        }

        /// <summary>
        /// Creates the employee training view.
        /// </summary>
        /// <param name="employeeTrainingInfo">The employee training information.</param>
        /// <param name="training">The training.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="trainingReport">The training report.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// employeeTrainingInfo
        /// or
        /// employeeTrainingInfo
        /// or
        /// training
        /// </exception>
        public IEmployeeTrainingView CreateEmployeeTrainingView(IEmployeeTrainingView employeeTrainingInfo, IList<ITraining> training, IList<IEmployee> employee, string processingMessage, IList<ITrainingReport> trainingReport)
        {

            if (employeeTrainingInfo == null) throw new ArgumentNullException(nameof(employeeTrainingInfo));

            if (employeeTrainingInfo == null) throw new ArgumentNullException(nameof(employeeTrainingInfo));

            if (training == null) throw new ArgumentNullException(nameof(training));

            var TrainingDDL = GetDropDownList.TrainingListItems(training, employeeTrainingInfo.TrainingId);
            var EmployeeDDL = GetDropDownList.EmployeeListitems(employee, employeeTrainingInfo.EmployeeId);
            
            employeeTrainingInfo.EmployeeDropDownList = EmployeeDDL;
            employeeTrainingInfo.TrainingDropDownList = TrainingDDL;
         
            employeeTrainingInfo.ProcessingMessage = processingMessage;

            return employeeTrainingInfo;
        }

        /// <summary>
        /// Gets the trainee ListView.
        /// </summary>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="selectedTrainingId">The selected training identifier.</param>
        /// <param name="TraineeView">The trainee view.</param>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="trainingCollection">The training collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <param name="trainigReport">The trainig report.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// TraineeView
        /// or
        /// trainingCollection
        /// </exception>
        public IEmployeeTrainingListView GetTraineeListView(int? selectedCompanyId, int? selectedTrainingId, IList<IEmployeeTrainingModel> TraineeView, ICompanyDetail companyInfo, IList<ITraining> trainingCollection, string processingMessage, IList<ITrainingReport> trainigReport)
        {
            if (TraineeView == null)
            {
                throw new ArgumentNullException(nameof(TraineeView));
            }

            if (trainingCollection == null)
            {
                throw new ArgumentNullException(nameof(trainingCollection));
            }
            


            var trainingDDL = GetDropDownList.TrainingListItems(trainingCollection, -1);
          

            var filteredList = TraineeView
                .Where(x => x.CompanyId.Equals(selectedCompanyId < 1 ? x.CompanyId : selectedCompanyId)).ToList();

            filteredList = filteredList
                .Where(x => x.TrainingId.Equals(selectedTrainingId < 1 ? x.TrainingId : selectedTrainingId)).ToList();


            var view = new EmployeeTrainingListView
            {
                employeeTrainingView = filteredList,
                Company = companyInfo,
                TrainingDropDownList = trainingDDL,
                ProcessingMessage = processingMessage ?? ""
            };

            return view;
        }

        /// <summary>
        /// Creates the edit employee training view.
        /// </summary>
        /// <param name="employeeTrainingModel">The employee training model.</param>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="trainingCollection">The training collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// employeeTrainingModel
        /// or
        /// companyCollecction
        /// or
        /// trainingCollection
        /// or
        /// companyCollecction
        /// </exception>
        public IEmployeeTrainingView CreateEditEmployeeTrainingView (IEmployeeTrainingModel employeeTrainingModel, ICompanyDetail companyInfo ,IList<IEmployee> employeeCollection, IList<ITraining> trainingCollection)
        {
            if (employeeTrainingModel == null)
            {
                throw new ArgumentNullException(nameof(employeeTrainingModel));
            }
            

            if (trainingCollection == null) throw new ArgumentNullException(nameof(trainingCollection));

            if (employeeCollection == null) throw new ArgumentNullException(nameof(employeeCollection));
            
            var trainingDDL = GetDropDownList.TrainingListItems(trainingCollection, employeeTrainingModel.TrainingId);
            var employeeDDL = GetDropDownList.EmployeeListitems(employeeCollection, employeeTrainingModel.EmployeeId);

            var viewModel = new EmployeeTrainingView
            {
                EmployeeTrainingId = employeeTrainingModel.EmployeeTrainingId,
                TrainingId = employeeTrainingModel.TrainingId,
                SupervisorId = employeeTrainingModel.SupervisorId,
                EmployeeId = employeeTrainingModel.EmployeeId,
                DateApproved = employeeTrainingModel.DateApproved,
                CompanyId = employeeTrainingModel.CompanyId,
                DateCreated = employeeTrainingModel.DateCreated,
                EmployeeDropDownList = employeeDDL,
                TrainingDropDownList = trainingDDL,
                ProcessingMessage = string.Empty,
            };
            return viewModel;
        }

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
        /// <exception cref="ArgumentNullException">
        /// trainingCollection
        /// or
        /// companyCollection
        /// or
        /// trainingCollection
        /// or
        /// trainingCollection
        /// </exception>
        public IEmployeeTrainingListView CreateSpecificEmployeeTrainingView(int? selectedEmployeeId, IEmployee employee, ICompanyDetail company, IList<IEmployeeTrainingModel> trainingCollection, IList<ICompanyDetail> companyCollection, string processingMessage)
        {
            if (trainingCollection == null)
            {
                throw new ArgumentNullException(nameof(trainingCollection));
            }

            if (companyCollection == null) throw new ArgumentNullException(nameof(companyCollection));

            if (trainingCollection == null) throw new ArgumentNullException(nameof(trainingCollection));

            if (trainingCollection == null) throw new ArgumentNullException(nameof(trainingCollection));

            var companyDDL = GetDropDownList.CompanyListItems(companyCollection, -1);
            var employeeTrainingDDL = GetDropDownList.EmployeeTrainingListItems(trainingCollection, -1);

            var viewModel = new EmployeeTrainingListView
            {

                CompanyDropDownList = companyDDL,
                employeeTrainingView = trainingCollection,
                ProcessingMessage = processingMessage,
                Employee = employee,
                Company = company,
     
            }; 
            return viewModel;
        }

        /// <summary>
        /// Creates the employee training request view.
        /// </summary>
        /// <param name="employeeTrainingModel">The employee training model.</param>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="training">The training.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="employeeModel">The employee model.</param>
        /// <returns></returns>
        public IEmployeeTrainingView CreateEmployeeTrainingRequestView(IList<IEmployeeTrainingModel> employeeTrainingModel, ICompanyDetail companyInfo, IList<ITraining> training, IList<IEmployee> employee, IEmployee employeeModel)
        {

            var TrainingDDL = GetDropDownList.TrainingListItems(training, -1);
            var EmployeeDDL = GetDropDownList.EmployeeListitems(employee, -1);


            var model = new EmployeeTrainingView
            {
               
                TrainingDropDownList = TrainingDDL,
                EmployeeDropDownList = EmployeeDDL,
                ProcessingMessage = string.Empty,
                EmployeeId = employeeModel.EmployeeId,
                CompanyId = companyInfo.CompanyId,


            };
            return model;
        }

    }
}
