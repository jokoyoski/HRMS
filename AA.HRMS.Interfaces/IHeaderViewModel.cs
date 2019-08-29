using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IHeaderViewModel
    {
        /// <summary>
        /// Gets or sets the digital.
        /// </summary>
        /// <value>
        /// The digital.
        /// </value>
        IDigitalFile CompanyLogo { get; set; }
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        IUserDetail User { get; set; }
        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        ICompanyDetail Company { get; set; }
    }
}
