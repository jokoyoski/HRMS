using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    public class HeaderViewModel : IHeaderViewModel
    {
        /// <summary>
        /// Gets or sets the digital.
        /// </summary>
        /// <value>
        /// The digital.
        /// </value>
        public IDigitalFile CompanyLogo { get; set; }
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public IUserDetail User { get; set; }
        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        public ICompanyDetail Company { get; set; }
    }
}
