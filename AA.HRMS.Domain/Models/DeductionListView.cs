using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// /
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IDeductionListView" />
    public class DeductionListView : IDeductionListView
    {

        public DeductionListView()
        {
            this.CompanyDropDownList = new List<SelectListItem>();

        }

        public IList<SelectListItem> CompanyDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the deduction collection.
        /// </summary>
        /// <value>
        /// The deduction collection.
        /// </value>
        public IList<IDeduction> DeductionCollection { get; set; }

        public IEmployee Employee { get; set; }
        public IUserDetail User { get; set; }
        public ICompanyDetail Company { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the selected deduction.
        /// </summary>
        /// <value>
        /// The selected deduction.
        /// </value>
        public string SelectedDeduction { get; set; }

        public string URL { get; set; }

    }
}
