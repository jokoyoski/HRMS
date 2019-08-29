using System.Collections.Generic;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IVacancyListAdminView
    {
        /// <summary>
        /// Gets or sets the search criteria.
        /// </summary>
        /// <value>
        /// The search criteria.
        /// </value>
        IVacancyListFilter SearchCriteria { get; set; }

        /// <summary>
        /// Gets or sets the vacancy applications.
        /// </summary>
        /// <value>
        /// The vacancy applications.
        /// </value>
        IList<IApplicationModel> VacancyApplicationcollection { get; set; }
        /// <summary>
        /// Gets or sets the vacancy detail collection.
        /// </summary>
        /// <value>
        /// The vacancy detail collection.
        /// </value>
        IList<IVacancyDetail> VacancyDetailCollection { get; set; }

        /// <summary>
        /// Gets or sets the department drop down.
        /// </summary>
        /// <value>
        /// The department drop down.
        /// </value>
        IList<SelectListItem> DepartmentDropDownList { get; set; }

        /// <summary>
        /// Gets or sets the job title drop down.
        /// </summary>
        /// <value>
        /// The job title drop down.
        /// </value>
        IList<SelectListItem> JobTitleDropDownList { get; set; }

        /// <summary>
        /// Gets or sets the grades drop down.
        /// </summary>
        /// <value>
        /// The grades drop down.
        /// </value>
        IList<SelectListItem> GradesDropDownList { get; set; }

        /// <summary>
        /// Gets or sets the company drop down.
        /// </summary>
        /// <value>
        /// The company drop down.
        /// </value>
        IList<SelectListItem> CompanyDropDownList { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

    }
}