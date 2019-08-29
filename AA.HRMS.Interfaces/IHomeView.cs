using System.Collections.Generic;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHomeView
    {
        /// <summary>
        /// Gets or sets the vacancy list.
        /// </summary>
        /// <value>
        /// The vacancy list.
        /// </value>
        IList<IVacancyInThreeColumns> VacancyList { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the company drop down.
        /// </summary>
        /// <value>
        /// The company drop down.
        /// </value>
        IList<SelectListItem> CompanyDropDown { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        IUserDetail User { get; set; }


        /// <summary>
        /// Gets or sets the company collection.
        /// </summary>
        /// <value>
        /// The company collection.
        /// </value>
        IList<ICompanyDetail> CompanyCollection { get; set; }

        /// <summary>
        /// Gets or sets the registration.
        /// </summary>
        /// <value>
        /// The registration.
        /// </value>
        IRegistrationView Registration { get; set; }

        /// <summary>
        /// Gets or sets the log on.
        /// </summary>
        /// <value>
        /// The log on.
        /// </value>
        ILogOnView LogOn { get; set; }

        /// <summary>
        /// Gets or sets the change password.
        /// </summary>
        /// <value>
        /// The change password.
        /// </value>
        IChangePasswordView ChangePassword { get; set; }

        /// <summary>
        /// Gets or sets the search value.
        /// </summary>
        /// <value>
        /// The search value.
        /// </value>
        string SearchValue { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        string URL { get; set; }
    }
}