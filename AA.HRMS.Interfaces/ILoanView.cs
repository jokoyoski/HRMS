using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface ILoanView
    {

         int LoanTypeId { get; set; }

         string LoanType { get; set; }

         bool IsActive { get; set; }

         DateTime DateCreated { get; set; }

        IList<SelectListItem> CompanyDropDown { get; set; }

        string ProcessingMessage { get; set; }

        int CompanyId { get; set; }
    }
}
