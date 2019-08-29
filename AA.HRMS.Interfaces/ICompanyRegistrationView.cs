using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.ICompanyDetail" />
    public interface ICompanyRegistrationView : ICompanyDetail
    {
        /// <summary>
        /// Gets or sets the parent company drop down list.
        /// </summary>
        /// <value>
        /// The parent company drop down list.
        /// </value>
        IList<SelectListItem> ParentCompanyDropDownList { get; set; }

        /// <summary>
        /// Gets or sets the industry drop down list.
        /// </summary>
        /// <value>
        /// The industry drop down list.
        /// </value>
        IList<SelectListItem> IndustryDropDownList { get; set; }

        /// <summary>
        /// Gets or sets the country drop down list.
        /// </summary>
        /// <value>
        /// The country drop down list.
        /// </value>
        IList<SelectListItem> CountryDropDownList { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
