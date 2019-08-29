using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface IGenerateDocumentService
    {
        /// <summary>
        /// Generates the excel.
        /// </summary>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        byte[] GenerateExcel(IEnumerable<IEmployee> employeeCollection, string title);

        /// <summary>
        /// Generates the PDF.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        FileResult GeneratePDF(string content, string name);

        /// <summary>
        /// Excels the upload.
        /// </summary>
        /// <param name="excelFile">The excel file.</param>
        /// <returns></returns>
        DataTable ExcelUpload(HttpPostedFileBase excelFile);

        /// <summary>
        /// Excels the upload.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="excelFile">The excel file.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        IList<T> ExcelUpload<T>(HttpPostedFileBase excelFile, T model) where T : class;
    }
}
