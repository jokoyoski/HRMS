using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PagedList;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Encoding = System.Text.Encoding;

namespace AA.HRMS.Domain.Services
{
    public class PdfBuilder : IPdfBuilder
    {
        private readonly IEnumerable<IEmployee> _post;

        private readonly string _file;

        public PdfBuilder(IEnumerable<IEmployee> post, string file)
        {
            this._post = post;
            this._file = file;
        }

        public FileContentResult GetPdf()
        {
            var html = GetHtml();
            Byte[] bytes;
            using (var ms = new MemoryStream())
            {
                using (var doc = new Document())
                {
                    using (var writer = PdfWriter.GetInstance(doc, ms))
                    {
                        doc.Open();
                        try
                        {
                            using (var msHtml = new MemoryStream(Encoding.UTF8.GetBytes(html)))
                            {
                                iTextSharp.tool.xml.XMLWorkerHelper.GetInstance()
                                    .ParseXHtml(writer, doc, msHtml, Encoding.UTF8);
                            }
                        }
                        finally
                        {
                            doc.Close();
                        }
                    }
                }
                bytes = ms.ToArray();
            }
            return new FileContentResult(bytes, "Report/pdf");
        }

        private string GetHtml()
        {
            var html = File.ReadAllText(_file);
            return Razor.Parse(html, _post);
        }
    }
}
