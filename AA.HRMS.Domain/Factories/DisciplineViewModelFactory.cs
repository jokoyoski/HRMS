using AA.HRMS.Domain.Models;
using AA.HRMS.Domain.Utilities;
using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Factories
{
    public class DisciplineViewModelFactory : IDisciplineViewModelFactory
    {
        /// <summary>
        /// Creates the discipline ListView.
        /// </summary>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="disciplineCollection">The discipline collection.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// companyCollection
        /// or
        /// disciplineCollection
        /// </exception>
        public IDisciplineListView CreateDisciplineListView(int? selectedCompanyId, ICompanyDetail company, IList<IDiscipline> disciplineCollection, string message)
        {

            if (disciplineCollection == null) throw new ArgumentNullException(nameof(disciplineCollection));

            var filteredList = disciplineCollection.Where(x => x.CompanyId.Equals(selectedCompanyId < 1 ? x.CompanyId : selectedCompanyId)).ToList();

            var returnModel = new DisciplineListView
            {
                DisciplineCollection = filteredList,
                Company = company,
                ProcessingMessage = message
            };

            return returnModel;
        }

        /// <summary>
        /// Creates the discipline ListView.
        /// </summary>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="disciplineCollection">The discipline collection.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// companyCollection
        /// or
        /// disciplineCollection
        /// </exception>
        public IDisciplineListView CreateEmployeeDisciplineListView(int? selectedCompanyId, IList<IDiscipline> disciplineCollection, IEmployee employee, ICompanyDetail company, string message)
        {
            

            if (disciplineCollection == null) throw new ArgumentNullException(nameof(disciplineCollection));
            

            var filteredList = disciplineCollection.Where(x => x.CompanyId.Equals(selectedCompanyId < 1 ? x.CompanyId : selectedCompanyId)).ToList();

            var returnModel = new DisciplineListView
            {
                DisciplineCollection = filteredList,
                Employee = employee,
                ProcessingMessage = message
            };

            return returnModel;
        }

        /// <summary>
        /// Creates the discipline view.
        /// </summary>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="queryStatus">The query status.</param>
        /// <param name="actionTaken">The action taken.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// companyCollection
        /// or
        /// queryStatus
        /// or
        /// actionTaken
        /// </exception>
        public IDisciplineView CreateDisciplineView(int employeeId, int companyId, IList<IEmployee> employeeCollection, IList<IQueryStatus> queryStatus, IList<IActionTaken> actionTaken)
        {

            if (queryStatus == null) throw new ArgumentNullException(nameof(queryStatus));

            if (actionTaken == null) throw new ArgumentNullException(nameof(actionTaken));

            if (employeeCollection == null) throw new ArgumentNullException(nameof(employeeCollection));

            var queryDDL = GetDropDownList.QueryStatusListItem(queryStatus, -1);

            var actionTakenDDL = GetDropDownList.ActionTakenListItem(actionTaken, -1);

            var employeeDDL = GetDropDownList.EmployeeListitems(employeeCollection, -1);
            var result = new DisciplineView
            {
                QueryDropDown = queryDDL,
                ActionTakenDropDown = actionTakenDDL,
                EmployeeDropDown = employeeDDL,
                EmployeeId = employeeId,
                CompanyId = companyId,
                ProcessingMessage = string.Empty
            };

            return result;


        }

        /// <summary>
        /// Creates the discipline view.
        /// </summary>
        /// <param name="disciplineView">The discipline view.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="queryStatus">The query status.</param>
        /// <param name="actionTaken">The action taken.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// companyCollection
        /// or
        /// queryStatus
        /// or
        /// actionTaken
        /// </exception>
        public IDisciplineView CreateDisciplineView(IDisciplineView disciplineView, IList<IEmployee> employeeCollection, IList<IQueryStatus> queryStatus, IList<IActionTaken> actionTaken, string processingMessage)
        {

            if (queryStatus == null) throw new ArgumentNullException(nameof(queryStatus));

            if (actionTaken == null) throw new ArgumentNullException(nameof(actionTaken));

            if (employeeCollection == null) throw new ArgumentNullException(nameof(employeeCollection));

            var employeeDDL = GetDropDownList.EmployeeListitems(employeeCollection, -1);
            

            var queryDDL = GetDropDownList.QueryStatusListItem(queryStatus, disciplineView.QueryStatusId);

            var actionTakenDDL = GetDropDownList.ActionTakenListItem(actionTaken, disciplineView.ActionTakenId);

            disciplineView.ProcessingMessage = processingMessage;
            disciplineView.ActionTakenDropDown = actionTakenDDL;
            disciplineView.EmployeeDropDown = employeeDDL;
            disciplineView.QueryDropDown = queryDDL;

            return disciplineView;
        }

        /// <summary>
        /// Creates the edit discipling view.
        /// </summary>
        /// <param name="discipline">The discipline.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="queryStatusCollecction">The query status collecction.</param>
        /// <param name="actionTaken">The action taken.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// queryStatusCollecction
        /// or
        /// actionTaken
        /// or
        /// employeeCollection
        /// </exception>
        public IDisciplineView CreateEditDisciplingView(IDiscipline discipline, IList<IEmployee> employeeCollection, IList<IQueryStatus> queryStatusCollecction, IList<IActionTaken> actionTaken)
        {

            if (queryStatusCollecction == null) throw new ArgumentNullException(nameof(queryStatusCollecction));

            if (actionTaken == null) throw new ArgumentNullException(nameof(actionTaken));

            if (employeeCollection == null) throw new ArgumentNullException(nameof(employeeCollection));
            

            var queryDDL = GetDropDownList.QueryStatusListItem(queryStatusCollecction, discipline.QueryStatusId);

            var actionTakenDDL = GetDropDownList.ActionTakenListItem(actionTaken, discipline.ActionTakenId);

            var employeeDDL = GetDropDownList.EmployeeListitems(employeeCollection, discipline.EmployeeId);

            var result = new DisciplineView
            {
                DisciplineId = discipline.DisciplineId,
                EmployeeId = discipline.EmployeeId,
                QueryStatusId = discipline.QueryStatusId,
                QueryDate = discipline.QueryDate,
                Offence = discipline.Offence,
                QueryInitiator = discipline.QueryInitiator,
                Investigator = discipline.Investigator,
                Response = discipline.Response,
                InvestigatorReport = discipline.InvestigatorReport,
                RecommendedSanction = discipline.RecommendedSanction,
                DisciplineCommitteeRecommendation = discipline.DisciplineCommitteeRecommendation,
                ActionTakenId = discipline.ActionTakenId,
                EvidenceDigitalFileId = discipline.EvidenceDigitalFileId,
                DateCreated = discipline.DateCreated,
                CompanyId = discipline.CompanyId,
                QueryDropDown = queryDDL,
                ActionTakenDropDown = actionTakenDDL,
                EmployeeDropDown = employeeDDL,
                ProcessingMessage = string.Empty
            };

            return result;
        }
    }
}
