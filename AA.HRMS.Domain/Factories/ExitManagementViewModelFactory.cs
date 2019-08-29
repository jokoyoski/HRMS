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
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IExitManagementViewModelFactory" />
    public class ExitManagementViewModelFactory : IExitManagementViewModelFactory
    {
        /// <summary>
        /// Creates the employee exit ListView.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="selectedEmployeeExitID">The selected employee exit identifier.</param>
        /// <param name="employeeExitCollection">The employee exit collection.</param>
        /// <param name="company">The company.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IEmployeeExitListView CreateEmployeeExitListView(int companyId, int? selectedEmployeeExitID, IList<IEmployeeExit> employeeExitCollection, ICompanyDetail company, string processingMessage)
        {
            var viewModel = new  EmployeeExitListView
            {
                employeeExitCollection = employeeExitCollection,
                SelectedCompanyID = companyId,
                ProcessingMessage = processingMessage
            };

            return viewModel;
        }
        /// <summary>
        /// Creates the exit management update view.
        /// </summary>
        /// <param name="employeeExitView">The employee exit view.</param>
        /// <param name="typeOfExitCollection">The type of exit collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// employeeExitView
        /// or
        /// typeOfExitCollection
        /// </exception>
        public IEmployeeExitView CreateExitManagementUpdateView(IEmployeeExitView employeeExitView, IList<ITypeOfExit> typeOfExitCollection, string message)
        {

            if (employeeExitView == null) throw new ArgumentNullException(nameof(employeeExitView));

            if (typeOfExitCollection == null)
            {
                throw new ArgumentNullException(nameof(typeOfExitCollection));
            }

            var typeOfExitDDL = GetDropDownList.TypeOfExitListItems(typeOfExitCollection, employeeExitView.TypeOfExitId);

            employeeExitView.TypeOfExitDropDown = typeOfExitDDL;
            employeeExitView.ProcessingMessage = message;


            return employeeExitView;
        }
        /// <summary>
        /// Creates the exit management view.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="typeOfExitCollection">The type of exit collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// employeeId
        /// or
        /// companyId
        /// or
        /// typeOfExitCollection
        /// </exception>
        public IEmployeeExitView CreateExitManagementView(IEmployee employee, ICompanyDetail company, IList<ITypeOfExit> typeOfExitCollection)
        {

            if(employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            if(company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }

            if(typeOfExitCollection == null)
            {
                throw new ArgumentNullException(nameof(typeOfExitCollection));
            }
            
            var typeOfExitDDL = GetDropDownList.TypeOfExitListItems(typeOfExitCollection, -1);

            var result = new EmployeeExitView
            {
                TypeOfExitDropDown = typeOfExitDDL,
                ProcessingMessage = string.Empty,
                Employee = employee,
                Company = company,
            };

            return result;
        }
        /// <summary>
        /// Creates the exit management view.
        /// </summary>
        /// <param name="employeeExitView">The employee exit view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IEmployeeExitView CreateExitManagementView(IEmployeeExitView employeeExitView, IList<ICompanyDetail> companyCollection, IList<IEmployee> employeeCollection, IList<ITypeOfExit> typeOfExitCollection, string processingMessage)
        {
            if(employeeExitView == null)
            {
                throw new ArgumentNullException(nameof(employeeExitView));
            }

            if (companyCollection == null)
            {
                throw new ArgumentNullException(nameof(companyCollection));
            }

            if (employeeCollection == null)
            {
                throw new ArgumentNullException(nameof(employeeCollection));
            }

            if (typeOfExitCollection == null)
            {
                throw new ArgumentNullException(nameof(typeOfExitCollection));
            }

            var companyDDL = GetDropDownList.CompanyListItems(companyCollection, employeeExitView.CompanyId);
            var employeeDDL = GetDropDownList.EmployeeListitems(employeeCollection, employeeExitView.EmployeeId);
            var typeOfExitDDL = GetDropDownList.TypeOfExitListItems(typeOfExitCollection, employeeExitView.TypeOfExitId);

            employeeExitView.CompanyDropDown = companyDDL;
            employeeExitView.EmployeeDropDown = employeeDDL;
            employeeExitView.TypeOfExitDropDown = typeOfExitDDL;
            employeeExitView.ProcessingMessage = processingMessage;

            return employeeExitView;
        }
    }
}
