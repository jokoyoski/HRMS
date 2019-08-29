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
    public class TypeOfExitViewModelFactory : ITypeOfExitViewModelFactory
    {

        /// <summary>
        /// </summary>
        /// <param name="typeOfExitCollection"></param>
        /// <param name="companyInfo"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// typeOfExitCollection
        /// or
        /// companyInfo
        /// </exception>
        public ITypeOfExitListView CreateTypeOfExitListView(IList<ITypeOfExit> typeOfExitCollection, ICompanyDetail companyInfo, string processingMessage)
        {
            if(typeOfExitCollection==null)
            {
                throw new ArgumentNullException("typeOfExitCollection");

            }
            if (companyInfo == null)
            {
                throw new ArgumentNullException("companyInfo");
            }
         
            var typeOfExitListView = new TypeOfExitListView
            {
                TypeOfExitCollection=typeOfExitCollection,
                Company=companyInfo,
                ProcessingMessage=processingMessage,        
            };
            return typeOfExitListView;
        }

        /// <summary>
        /// </summary>
        /// <param name="companyCollection"></param>
        /// <param name="typeOfExitCollection"></param>
        /// <param name="employeeCollection"></param>
        /// <param name="typeOfExitInfo"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public ITypeOfExitView CreateTypeOfExitView(int companyId, IList<ITypeOfExit> typeOfExitCollection, IList<IEmployee> employeeCollection, ITypeOfExit typeOfExitInfo, string message)
        {
            //if (typeOfExitId == null) throw new ArgumentNullException(nameof(typeOfExitId));
            
            var employeeDDL = GetDropDownList.EmployeeListitems(employeeCollection, -1);
            var typeOfExitDDL = GetDropDownList.TypeOfExitListItems(typeOfExitCollection, -1);
            
            var viewModel = new TypeOfExitView
            {
                EmployeeDropDown = employeeDDL,
                InterViewerDropDown = employeeDDL,
                ProcessingMessage = string.Empty,
                CompanyId = companyId
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the type of exit view.
        /// </summary>
        /// <param name="typeOfExitView">The type of exit view.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="typeOfExitCollection">The type of exit collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// typeOfExitView
        /// or
        /// employeeCollection
        /// or
        /// typeOfExitCollection
        /// </exception>
        public ITypeOfExitView CreateTypeOfExitView(ITypeOfExitView typeOfExitView, IList<IEmployee> employeeCollection, IList<ITypeOfExit> typeOfExitCollection)
        {

            if (typeOfExitView == null)
            {
                throw new ArgumentNullException(nameof(typeOfExitView));
            }

            if (employeeCollection == null)
            {
                throw new ArgumentNullException(nameof(employeeCollection));
            }

            if (typeOfExitCollection == null)
            {
                throw new ArgumentNullException(nameof(typeOfExitCollection));
            }
            var employeeDDL = GetDropDownList.EmployeeListitems(employeeCollection, typeOfExitView.EmployeeId);
            var typeOfExitDDL = GetDropDownList.TypeOfExitListItems(typeOfExitCollection, typeOfExitView.TypeOfExitId);
            var interViewerDDL = GetDropDownList.EmployeeListitems(employeeCollection, typeOfExitView.EmployeeId);

            typeOfExitView.EmployeeDropDown = employeeDDL;
            typeOfExitView.TypeOfExitDropDown = typeOfExitDDL;
            typeOfExitView.InterViewerDropDown = interViewerDDL;
            
            return typeOfExitView;
        }

        /// <summary>
        /// Creates the edit type of exit view.
        /// </summary>
        /// <param name="typeOfExit">The type of exit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">typeOfExit</exception>
        public ITypeOfExitView CreateEditTypeOfExitView(ITypeOfExit typeOfExit)
        {
            if (typeOfExit == null)
            {
                throw new ArgumentNullException(nameof(typeOfExit));
            }

            var viewResult = new TypeOfExitView
            {
                TypeOfExitId = typeOfExit.TypeOfExitId,
                TypeOfExitName = typeOfExit.TypeOfExitName,
                CompanyId = typeOfExit.CompanyId,
                IsActive = typeOfExit.IsActive
            };

            return viewResult;


        }

        /// <summary>
        /// Creates the type of exit update view.
        /// </summary>
        /// <param name="TypeOfExit">The type of exit.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">TypeOfExit</exception>
        public ITypeOfExitView CreateTypeOfExitUpdateView(ITypeOfExitView TypeOfExit, string processingMessage)
        {
            if (TypeOfExit == null)
            {
                throw new ArgumentNullException(nameof(TypeOfExit));
            }

            TypeOfExit.ProcessingMessage = processingMessage;

            return TypeOfExit;
        }

    }
}
