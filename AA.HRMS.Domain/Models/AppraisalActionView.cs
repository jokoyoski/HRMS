using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IAppraisalActionView" />
    public class AppraisalActionView : IAppraisalActionView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppraisalActionView"/> class.
        /// </summary>
        public AppraisalActionView()
        {
            this.CompanyDropDownList = new List<SelectListItem>();
        }
        /// <summary>
        /// Gets or sets the appraisal action identifier.
        /// </summary>
        /// <value>
        /// The appraisal action identifier.
        /// </value>
        public int AppraisalActionId { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the name of the appraisal action.
        /// </summary>
        /// <value>
        /// The name of the appraisal action.
        /// </value>
        public string AppraisalActionName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
        public IList<SelectListItem> CompanyDropDownList { get; set; }


        /// <summary>
        /// Gets or sets the company detail.
        /// </summary>
        /// <value>
        /// The company detail.
        /// </value>
        public IList<ICompanyDetail> companyDetail { get; set; }
        /// <summary>
        /// Gets or sets the appraisal.
        /// </summary>
        /// <value>
        /// The appraisal.
        /// </value>
        public IList<IAppraisalAction> appraisal { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
