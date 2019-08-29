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

    public class SuspensionViewModelFactory : ISuspensionViewModelFactory
    {

        /// <summary>
        /// Creates the edit suspension view.
        /// </summary>
        /// <param name="suspensionInfo">The suspension information.</param>
        /// <param name="companyInfo">The company information.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="queryCollection">The query collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// suspensionInfo
        /// or
        /// employeeCollection
        /// or
        /// queryCollection
        /// </exception>
        public ISuspensionView CreateEditSuspensionView(ISuspension suspensionInfo, int companyId, IList<IEmployee> employeeCollection, IList<IQuery> queryCollection)
        {

            if (suspensionInfo == null) throw new ArgumentNullException(nameof(suspensionInfo));
            
            if (employeeCollection == null)
            {
                throw new ArgumentNullException(nameof(employeeCollection));
            }

            if (queryCollection == null)
            {
                throw new ArgumentNullException(nameof(queryCollection));
            }
            
            var employeeDDL = GetDropDownList.EmployeeListitems(employeeCollection, -1);
            var queryDDL = GetDropDownList.QueryListItems(queryCollection, -1);

            var returnSuspension = new SuspensionView
            {
                SuspensionId = suspensionInfo.SuspensionId,
                EmployeeId = suspensionInfo.EmployeeId,
                QueryId = suspensionInfo.QueryId,
                StartDate = suspensionInfo.StartDate,
                EndDate = suspensionInfo.EndDate,
                Percentage = suspensionInfo.EmployeeId,
                IsActive = suspensionInfo.IsActive,
                DateCreated = suspensionInfo.DateCreated,
                CompanyId = companyId,
                EmployeeDropDown = employeeDDL,
                QueryDropDown = queryDDL,
                QueryName = suspensionInfo.QueryName

            };

            return returnSuspension;
        }

        /// <summary>
        /// </summary>
        /// <param name="selectedCompanyId"></param>
        /// <param name="queryCollection"></param>
        /// <param name="suspensionCollection"></param>
        /// <param name="employeeCollection"></param>
        /// <param name="companyCollection"></param>
        /// <param name="company"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        public ISuspensionListView CreateSuspensionListView(int? selectedCompanyId, IList<IQuery> queryCollection, IList<ISuspension> suspensionCollection, IList<IEmployee> employeeCollection, ICompanyDetail company, string processingMessage)
        {
            //Create a Compny drop down for the filter at the list view
            var employeeDDL = GetDropDownList.EmployeeListitems(employeeCollection, -1);
            var queryDDL = GetDropDownList.QueryListItems(queryCollection, -1);
            //Filter by companyId 
            var filteredList = suspensionCollection
                .Where(x => x.CompanyId.Equals(selectedCompanyId < 1 ? x.CompanyId : selectedCompanyId)).ToList();



            //Create a return view model of type suspensionListView
            var viewModel = new SuspensionListView
            {
                SuspensionCollection = filteredList,
                
                Company = company,
                ProcessingMessage = processingMessage
            };

            return viewModel;

        }

        /// <summary>
        /// Creates the suspension update view.
        /// </summary>
        /// <param name="suspensionInfo">The suspension information.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="queryCollection">The query collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">suspensionInfo</exception>
        public ISuspensionView CreateSuspensionUpdateView(ISuspensionView suspensionInfo, IList<IEmployee> employeeCollection, IList<IQuery> queryCollection, string processingMessage)
        {
            //Throw exception for null companyCollection
            if (suspensionInfo == null) throw new ArgumentNullException(nameof(suspensionInfo));
            

            var employeeDDL = GetDropDownList.EmployeeListitems(employeeCollection, -1);
            var queryDDL = GetDropDownList.QueryListItems(queryCollection, -1);

            //Assigning processingMessage if any back to the view
            suspensionInfo.ProcessingMessage = processingMessage;

            return suspensionInfo;
        }

        /// <summary>
        /// Creates the suspension view.
        /// </summary>
        /// <param name="suspensionView">The suspension view.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="queryCollection">The query collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyId</exception>
        public ISuspensionView CreateSuspensionView(IList<ISuspension> suspensionView, int companyId, IList<IEmployee> employeeCollection, IList<IQuery> queryCollection)
        {
            //throw an exception if the companyCollection is null
            if (companyId <= 0) throw new ArgumentNullException(nameof(companyId));
            

            var employeeDDL = GetDropDownList.EmployeeListitems(employeeCollection, -1);
            var queryDDL = GetDropDownList.QueryListItems(queryCollection, -1);

            var viewModel = new SuspensionView
            {
                //Assigning the drop down to the View model
                CompanyId = companyId,
                EmployeeDropDown = employeeDDL,
                QueryDropDown = queryDDL,
            };

            return viewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="suspensionInfo"></param>
        /// <param name="companyCollection"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">suspensionInfo</exception>
        public ISuspensionView CreateUpdatedSuspensionView(ISuspensionView suspensionInfo, int companyId, string processingMessage)
        {
            if (suspensionInfo == null) throw new ArgumentNullException(nameof(suspensionInfo));

            var trainingView = new SuspensionView
            {
                SuspensionId = suspensionInfo.SuspensionId,
                EmployeeId = suspensionInfo.EmployeeId,
                QueryId = suspensionInfo.QueryId,
                StartDate = suspensionInfo.StartDate,
                EndDate = suspensionInfo.EndDate,
                Percentage = suspensionInfo.EmployeeId,
                IsActive = suspensionInfo.IsActive,
                DateCreated = suspensionInfo.DateCreated,
                CompanyId = companyId
            };

            return trainingView;
        }
    }
}
