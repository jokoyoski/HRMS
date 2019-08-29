using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;
using AA.HRMS.Domain.Models;
using AA.HRMS.Domain.Utilities;

namespace AA.HRMS.Domain.Factories
{
    public class DepartmentViewModelFactory : IDepartmentViewModelFactory
    {
        /// <summary>
        /// The department repository
        /// </summary>
        private readonly IDepartmentRepository departmentRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentViewModelFactory"/> class.
        /// </summary>
        /// <param name="departmentRepository">The department repository.</param>
        public DepartmentViewModelFactory(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        /// <summary>
        /// Creates the department view.
        /// </summary>
        /// <param name="departmentCollection">The department collection.</param>
        /// <param name="cacRegistrationNumber">The cac registration number.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">departmentCollection</exception>
        public IDepartmentViews CreateDepartmentView(IList<IDepartment> departmentCollection,
            int companyId)
        {
            //this is different from grade cos we creating a fresh department
            ////
            if (departmentCollection == null) throw new ArgumentNullException(nameof(departmentCollection));

            var departmentDDL = GetDropDownList.DepartmentListItems(departmentCollection, -1);

            var view = new DepartmentView
            {
                CompanyId = companyId,
                ParentDepartmentDropDown = departmentDDL,
                ProcessingMessage = string.Empty
            };

            return view;
        }

        /// <summary>
        /// Creates the edit department view.
        /// </summary>
        /// <param name="departmentInfo">The department information.</param>
        /// <param name="departmentCollection">The department collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// departmentInfo
        /// or
        /// departmentCollection
        /// </exception>
        public IDepartmentViews CreateEditDepartmentView(IDepartment departmentInfo, IList<IDepartment> departmentCollection)
        {
            if (departmentInfo == null) throw new ArgumentNullException(nameof(departmentInfo));

            if (departmentCollection == null) throw new ArgumentNullException(nameof(departmentCollection));

            var departmentDDL = GetDropDownList.DepartmentListItems(departmentCollection, -1);


            var returnDepartment = new DepartmentView
            {
                CompanyId = departmentInfo.CompanyId,
                DepartmentId = departmentInfo.DepartmentId,
                DepartmentName = departmentInfo.DepartmentName,
                Description = departmentInfo.Description,
                ParentDepartmentId = departmentInfo.ParentDepartmentId,
                ParentDepartmentDropDown = departmentDDL,
                IsActive = departmentInfo.IsActive,
            };


            return returnDepartment;
        }




        /// <summary>
        /// Creates the updated department view.
        /// </summary>
        /// <param name="deptInfo">The dept information.</param>
        /// <param name="departmentCollection">The department collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">deptInfo</exception>
        /// <exception cref="System.ArgumentException">departmentCollection</exception>
        public IDepartmentViews CreateUpdatedDepartmentView(IDepartmentViews deptInfo,
            IList<IDepartment> departmentCollection, string processingMessage)
        {
            if (deptInfo == null) throw new ArgumentNullException(nameof(deptInfo));
            if (departmentCollection == null) throw new ArgumentException(nameof(departmentCollection));

            var departmentDDL = GetDropDownList.DepartmentListItems(departmentCollection, deptInfo.ParentDepartmentId);

            deptInfo.ParentDepartmentDropDown = departmentDDL;
            deptInfo.ProcessingMessage = processingMessage;

            return deptInfo;
        }


        /// <summary>
        /// Creates the department ListView.
        /// </summary>
        /// <param name="departmentsCollection">The departments collection.</param>
        /// <param name="companyInfo">The company information.</param>
        /// <returns></returns>
        public IDepartmentListView CreateDepartmentListView(IEnumerable<IDepartment> departmentsCollection,
            ICompanyDetail companyInfo)
        {
            var viewModel = new DepartmentListView
            {
                DepartmentsCollection = departmentsCollection,
                CompanyDetails = companyInfo,
            };

            return viewModel;
        }
    }
}