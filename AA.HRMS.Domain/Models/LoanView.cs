using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    public class LoanView : ILoanView
    {

        public LoanView()
        {
            this.CompanyDropDown = new List<SelectListItem>();
        }

        public int LoanTypeId { get; set; }

        public string LoanType { get; set; }

        public bool IsActive { get; set; }

        public DateTime DateCreated { get; set; }

        public IList<SelectListItem> CompanyDropDown { get; set; }

        public int CompanyId { get; set; }
       
        public string ProcessingMessage { get; set; }
    }
}
