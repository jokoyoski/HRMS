using System.Collections.Generic;
using System.Web.Mvc;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IHomeView" />
    public class HomeModelView : IHomeView
    {

        public HomeModelView()
        {
            this.CompanyDropDown = new List<SelectListItem>();
        }
        /// <summary>
        /// Gets or sets the vacancy list.
        /// </summary>
        /// <value>
        /// The vacancy list.
        /// </value>
        public IList<IVacancyInThreeColumns> VacancyList { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the company drop down.
        /// </summary>
        /// <value>
        /// The company drop down.
        /// </value>
        public IList<SelectListItem> CompanyDropDown { get; set; }

        /// <summary>
        /// Gets or sets the company collection.
        /// </summary>
        /// <value>
        /// The company collection.
        /// </value>
        public IList<ICompanyDetail> CompanyCollection { get; set; }

        /// <summary>
        /// Gets or sets the registration.
        /// </summary>
        /// <value>
        /// The registration.
        /// </value>
        public IRegistrationView Registration { get; set; }

        /// <summary>
        /// Gets or sets the log on.
        /// </summary>
        /// <value>
        /// The log on.
        /// </value>
        public ILogOnView LogOn { get; set; }


        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public IUserDetail User { get; set; }

        /// <summary>
        /// Gets or sets the change password.
        /// </summary>
        /// <value>
        /// The change password.
        /// </value>
        public IChangePasswordView ChangePassword { get; set; }


        /// <summary>
        /// Gets or sets the search value.
        /// </summary>
        /// <value>
        /// The search value.
        /// </value>
        public string SearchValue { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string URL { get; set; }
    }
}