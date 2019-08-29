using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface IDeductionListView
    {
        IList<SelectListItem> CompanyDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the deduction collection.
        /// </summary>
        /// <value>
        /// The deduction collection.
        /// </value>
        IList<IDeduction> DeductionCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

        IEmployee Employee { get; set; }

        IUserDetail User { get; set; }

        ICompanyDetail Company { get; set; }

        /// <summary>
        /// Gets or sets the selected deduction.
        /// </summary>
        /// <value>
        /// The selected deduction.
        /// </value>
        string SelectedDeduction { get; set; }

         string  URL { get; set; }
    }
}
