using AA.HRMS.Domain.Attributes;
using AA.HRMS.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Controllers
{
    [Authorize]
    [CheckUserLogin()]
    public class PayrollController : Controller
    {
        
        private readonly IPayrollServices payrollService;
        private readonly IGenerateDocumentService generateDocumentService;
        
        public PayrollController(IPayrollServices payrollService, IGenerateDocumentService generateDocumentService)
        {
            this.payrollService = payrollService;
            this.generateDocumentService = generateDocumentService;
        }

        /// <summary>
        /// Indexes the specified company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="selectedMonth">The selected month.</param>
        /// <param name="selectedYear">The selected year.</param>
        /// <param name="submitButton">The submit button.</param>
        /// <returns></returns>
        public ActionResult Index(string selectedMonth, int? selectedYear, string submitButton, string message)
        {
            var viewModel = this.payrollService.GetPayrollHistoryList(selectedMonth, selectedYear ?? -1, message);

            return View("Index", viewModel);
        }

        /// <summary>
        /// Indexes the company.
        /// </summary>
        /// <param name="selectedMonth">The selected month.</param>
        /// <param name="selectedYear">The selected year.</param>
        /// <param name="submitButton">The submit button.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult PayrollList(int payrollHistoryId, string selectedMonth, int? selectedYear, string submitButton, string message)
        {

            var viewModel = this.payrollService.GetPayrollList(payrollHistoryId, selectedMonth, selectedYear ?? -1, message);

            return View("IndexCompany", viewModel);
        }

        /// <summary>
        /// Indexes the employee.
        /// </summary>
        /// <param name="selectedMonth">The selected month.</param>
        /// <param name="selectedYear">The selected year.</param>
        /// <param name="submitButton">The submit button.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult IndexEmployee(string selectedMonth, int? selectedYear, string submitButton, string message)
        {

            var viewModel = this.payrollService.GetPayrollEmployeeList(selectedMonth, selectedYear ?? -1, message);

            return View("EmployeePayroll", viewModel);
        }

        /// <summary>
        /// Employees the payroll.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="selectedMonth">The selected month.</param>
        /// <param name="selectedYear">The selected year.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult EmployeePayroll(int employeeId, string selectedMonth, int? selectedYear, string message)
        {
            var viewModel = this.payrollService.GetEmployeePayrollList(employeeId, selectedMonth, selectedYear ?? -1, message);

            return this.View("EmployeePayroll", viewModel);
        }

        /// <summary>
        /// Generates the payroll.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// companyId
        /// or
        /// month
        /// or
        /// year
        /// </exception>
        [HttpPost]
        public async Task<ActionResult> GeneratePayroll(string month, int year)
        {

            if (month == null)
            {
                throw new ArgumentNullException(nameof(month));
            }

            if (year <= 0)
            {
                throw new ArgumentNullException(nameof(year));
            }

            var viewModel = await this.payrollService.GeneratePay(month, year);

            if (!string.IsNullOrEmpty(viewModel))
            {
                return RedirectToAction("Index", new { message = viewModel });
            }

            viewModel = string.Format("New Payroll Generated for {0} {1}", month, year);

            return this.RedirectToAction("Index", "Payroll", new { message = viewModel });
        }

        /// <summary>
        /// Gets the payroll.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public ActionResult GetPayroll()
        {

            //Get payroll for all the employee in the company
            var viewModel = this.payrollService.GetPayrollView();

            return this.PartialView("GetPayroll", viewModel);
        }

        /// <summary>
        /// Gets the pay slip.
        /// </summary>
        /// <param name="payrollId">The payroll identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">payrollId</exception>
        public ActionResult GetPaySlip(int payrollId)
        {
            if (payrollId <= 0)
            {
                throw new ArgumentNullException(nameof(payrollId));
            }

            var viewModel = this.payrollService.GetPaySlipView(payrollId);

            return this.View("GetPaySlip", viewModel);
        }

        /// <summary>
        /// Exports the specified export data.
        /// </summary>
        /// <param name="ExportData">The export data.</param>
        /// <returns></returns>
        [HttpPost, ValidateInput(false)]
        public FileResult Export(string ExportData, string PdfName)
        {
            return this.generateDocumentService.GeneratePDF(ExportData, PdfName); 
        }
    }
}