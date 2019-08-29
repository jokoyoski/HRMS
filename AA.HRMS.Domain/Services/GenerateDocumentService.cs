using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.Infrastructure.Interfaces;
using iText.Html2pdf;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinqToExcel;
using System.Data;
using Aspose.Cells;
using Border = OfficeOpenXml.Style.Border;
using Newtonsoft.Json;
using System;

namespace AA.HRMS.Domain.Services
{
    public class GenerateDocumentService : IGenerateDocumentService
    {
        private readonly ISessionStateService session;
        private readonly IUsersRepository usersRepository;
        private readonly ILevelRepository levelRepository;
        private readonly ICompanyRepository companyRepository;

        public GenerateDocumentService(ISessionStateService session, IUsersRepository usersRepository, ILevelRepository levelRepository,
            ICompanyRepository companyRepository)
        {
            this.session = session;
            this.usersRepository = usersRepository;
            this.levelRepository = levelRepository;
            this.companyRepository = companyRepository;
        }

        /// <summary>
        /// Generates the excel.
        /// </summary>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        public byte [] GenerateExcel(IEnumerable<IEmployee> employeeCollection, string title)
        {
            int rowIndex = 2;
            ExcelRange cell;
            ExcelFill fill;
            Border border;

            var user = this.usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));
            var company = this.companyRepository.GetCompanyById(user.CompanyId);

            using (var excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Properties.Author = string.Format("{0} {1}", user.LastName, user.FirstName);
                excelPackage.Workbook.Properties.Title = title;
                var sheet = excelPackage.Workbook.Worksheets.Add("AAHRMS Excel");
                sheet.Name = "Sheet " + title;
                sheet.Column(2).Width = 30; //SL;
                sheet.Column(3).Width = 30; //SL;
                sheet.Column(4).Width = 30; //Name;
                sheet.Column(5).Width = 30; //Roll;
                sheet.Column(6).Width = 30; //SL;
                sheet.Column(7).Width = 30; //Name;
                sheet.Column(8).Width = 30; //Roll;
                sheet.Column(9).Width = 30; //SL;

                #region Report Header
                sheet.Cells[rowIndex, 2, rowIndex, 4].Merge = true;
                cell = sheet.Cells[rowIndex, 2];
                cell.Value = company.CompanyName;
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 20;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rowIndex = rowIndex + 1;


                sheet.Cells[rowIndex, 2, rowIndex, 4].Merge = true;
                cell = sheet.Cells[rowIndex, 2];
                cell.Value = string.Format("{0} {1} {2} {3}",company.CompanyAddressLine1, company.CompanyCity, company.CompanyState, company.CompanyCountry);
                cell.Style.Font.Bold = true;
                cell.Style.Font.Size = 15;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rowIndex = rowIndex + 2;

                #endregion
                
                #region Table header
                

                cell = sheet.Cells[rowIndex, 2];
                cell.Value = "Last Name";
                cell.Style.Font.Bold = true;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 3];
                cell.Value = "First Name";
                cell.Style.Font.Bold = true;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 4];
                cell.Value = "Department";
                cell.Style.Font.Bold = true;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 5];
                cell.Value = "Grade";
                cell.Style.Font.Bold = true;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[rowIndex, 6];
                cell.Value = "Level";
                cell.Style.Font.Bold = true;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                cell = sheet.Cells[rowIndex, 7];
                cell.Value = "Gender";
                cell.Style.Font.Bold = true;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                cell = sheet.Cells[rowIndex, 8];
                cell.Value = "Email";
                cell.Style.Font.Bold = true;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightGray);
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                rowIndex = rowIndex + 1;
                #endregion

                #region Table body
                

                if (employeeCollection.Count() > 0 && employeeCollection != null)
                {
                    foreach (var employee in employeeCollection)
                    {

                        cell = sheet.Cells[rowIndex, 2];
                        cell.Value = employee.LastName ;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;



                        cell = sheet.Cells[rowIndex, 3];
                        cell.Value = employee.FirstName;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                        

                        cell = sheet.Cells[rowIndex, 4];
                        cell.Value = employee.Department;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                        

                        cell = sheet.Cells[rowIndex, 5];
                        cell.Value = employee.GradeName;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                        

                        cell = sheet.Cells[rowIndex, 6];
                        cell.Value = employee.LevelName;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                        

                        cell = sheet.Cells[rowIndex, 7];
                        cell.Value = employee.Gender;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                        

                        cell = sheet.Cells[rowIndex, 8];
                        cell.Value = employee.Email;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;


                        rowIndex = rowIndex + 1;
                    }
                }
                #endregion
                return excelPackage.GetAsByteArray();

            }
        }

        /// <summary>
        /// Generates the PDF.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public FileResult GeneratePDF(string content, string name)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                ConverterProperties converterProperties = new ConverterProperties();

                //Converts the string content to pdf
                HtmlConverter.ConvertToPdf(content, stream, converterProperties);
                
                return new FileContentResult(stream.ToArray(), name+"/pdf");
            }
        }

        /// <summary>
        /// Uploads the excel.
        /// </summary>
        /// <param name="excelFile">The excel file.</param>
        /// <returns></returns>
        public string UploadExcel(HttpPostedFileBase excelFile)
        {
            string result = string.Empty;

            var excel = new ExcelQueryFactory();
            excel.FileName = excelFile.FileName;

            var details = from x in excel.Worksheet<LevelView>() select x;
            
            foreach(var level in details)
            {
                int companyId = (int)this.session.GetSessionValue(SessionKey.CompanyId);
                level.CompanyId = companyId;

                result = this.levelRepository.SaveLevelInfo(level);
            }

            return result;
        }

        /// <sumary>
        /// Excels the upload.
        /// </summary>
        /// <param name="excelFile">The excel file.</param>
        /// <returns></returns>
        public DataTable ExcelUpload(HttpPostedFileBase excelFile)
        {
            if (excelFile == null) throw new ArgumentNullException(nameof(excelFile));

            var result = string.Empty;

            // Instantiating a Workbook object
            Workbook workbook = new Workbook(excelFile.InputStream);

            // Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            int rowLength = worksheet.Cells.MaxDataRow+1;

            if (rowLength < 1) throw new ArgumentNullException(nameof(rowLength));

            int columnLength = worksheet.Cells.MaxDataColumn; 

            if (columnLength < 1) throw new ArgumentNullException(nameof(columnLength));
            
            // Exporting the contents of 7 rows and 2 columns starting from 1st cell to DataTable
            DataTable dataTable = worksheet.Cells.ExportDataTableAsString(0, 1, rowLength, columnLength, true);

            if (dataTable == null) throw new ArgumentNullException(nameof(dataTable));
            
            return dataTable;
        }

        /// <summary>
        /// Excels the upload.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="excelFile">The excel file.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public IList<T> ExcelUpload<T>(HttpPostedFileBase excelFile, T model) where T: class
        {

            var result = string.Empty;

            // Instantiating a Workbook object
            Workbook workbook = new Workbook(excelFile.InputStream);

            // Accessing the first worksheet in the Excel file
            Worksheet worksheet = workbook.Worksheets[0];

            int rowLength = worksheet.Cells.MaxDataRow;
            int columnLength = worksheet.Cells.Columns.Count;

            // Exporting the contents of 7 rows and 2 columns starting from 1st cell to DataTable
            DataTable dataTable = worksheet.Cells.ExportDataTableAsString(0, 0, rowLength, columnLength, true);


            var list = JsonConvert.SerializeObject(dataTable.Rows);

            var collection = JsonConvert.DeserializeObject<T[]>(list).ToList();


            return collection;
        }


    }
}