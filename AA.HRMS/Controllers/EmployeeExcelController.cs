using AA.HRMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AA.HRMS.Domain.Services;
using AA.HRMS.Repositories.Models;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Controllers
{
    public class EmployeeExcelController : Controller
    {

        private readonly IGenerateDocumentService generateDocument;

        public EmployeeExcelController(IGenerateDocumentService generateDocument)
        {
            this.generateDocument = generateDocument;
        }

        /// <summary>
        /// Excels the specified employee collection.
        /// </summary>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Excel(List<EmployeeModel> employeeCollection)
        {

            var title = "Report";
            
            Response.ClearContent();
            Response.BinaryWrite(generateDocument.GenerateExcel(employeeCollection, title));
            Response.AddHeader("content-disposition", "attachment; filename=ExcelDocument.xlsx");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.Flush();
            Response.End();

            return RedirectToAction("GenerateReport", "Employee");

        }
    }
}