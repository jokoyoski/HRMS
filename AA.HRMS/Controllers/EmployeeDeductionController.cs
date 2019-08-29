using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AA.HRMS.Domain.Attributes;
using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.Infrastructure.Interfaces;

namespace AA.HRMS.Controllers
{
    [Authorize]
    [CheckUserLogin()]
    public class EmployeeDeductionController : Controller
    {
        private readonly ICompanySetupServices companySetupServices;
        
        public EmployeeDeductionController(ICompanySetupServices companySetupServices)
        {
            this.companySetupServices = companySetupServices;
        }
        
        /// <summary>
        /// Employees the deduction.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeId</exception>
        public ActionResult EmployeeDeduction(int employeeId)
        {
            if (employeeId <= 0)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }

            var viewModel = this.companySetupServices.GetEmployeeDeduction(employeeId);

            return this.View("EmployeeDeduction", viewModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedCompanyId"></param>
        /// <param name="selectedEmployeeName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public ActionResult EmployeeDeductionList(int? selectedCompanyId, string selectedEmployeeName, string processingMessage)
        {
            var viewModel = this.companySetupServices.GetAllDeductionByCompanyId(selectedEmployeeName, selectedCompanyId ?? -1, processingMessage);

            return this.View("EmployeeDeductionList", viewModel);
        }
    }
}