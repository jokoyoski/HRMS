using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Repositories.Models
{
    public class CompanyRegistrationModel : ICompanyDetail
    {
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the cac registration number.
        /// </summary>
        /// <value>
        /// The cac registration number.
        /// </value>
        public string CACRegistrationNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the company alias.
        /// </summary>
        /// <value>
        /// The company alias.
        /// </value>
        public string CompanyAlias { get; set; }

        /// <summary>
        /// Gets or sets the company address line1.
        /// </summary>
        /// <value>
        /// The company address line1.
        /// </value>
        public string CompanyAddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the company address line2.
        /// </summary>
        /// <value>
        /// The company address line2.
        /// </value>
        public string CompanyAddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the company city.
        /// </summary>
        /// <value>
        /// The company city.
        /// </value>
        public string CompanyCity { get; set; }

        /// <summary>
        /// Gets or sets the state of the company.
        /// </summary>
        /// <value>
        /// The state of the company.
        /// </value>
        public string CompanyState { get; set; }

        /// <summary>
        /// Gets or sets the company country identifier.
        /// </summary>
        /// <value>
        /// The company country identifier.
        /// </value>
        public int CompanyCountryId { get; set; }

        /// <summary>
        /// Gets or sets the company country.
        /// </summary>
        /// <value>
        /// The company country.
        /// </value>
        public string CompanyCountry { get; set; }

        /// <summary>
        /// Gets or sets the company zip code.
        /// </summary>
        /// <value>
        /// The company zip code.
        /// </value>
        public int? CompanyZipCode { get; set; }

        /// <summary>
        /// Gets or sets the comapy email.
        /// </summary>
        /// <value>
        /// The comapy email.
        /// </value>
        public string CompanyEmail { get; set; }

        /// <summary>
        /// Gets or sets the company phone.
        /// </summary>
        /// <value>
        /// The company phone.
        /// </value>
        public string CompanyPhone { get; set; }

        /// <summary>
        /// Gets or sets the company website.
        /// </summary>
        /// <value>
        /// The company website.
        /// </value>
        public string CompanyWebsite { get; set; }

        /// <summary>
        /// Gets or sets the logo digital file identifier.
        /// </summary>
        /// <value>
        /// The logo digital file identifier.
        /// </value>
        public int? LogoDigitalFileId { get; set; }

        /// <summary>
        /// Gets or sets the parent company identifier.
        /// </summary>
        /// <value>
        /// The parent company identifier.
        /// </value>
        public int? ParentCompanyId { get; set; }

        /// <summary>
        /// Gets or sets the industry identifier.
        /// </summary>
        /// <value>
        /// The industry identifier.
        /// </value>
        public int IndustryId { get; set; }

        /// <summary>
        /// Gets or sets the name of the industry.
        /// </summary>
        /// <value>
        /// The name of the industry.
        /// </value>
        public string IndustryName { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the company logo.
        /// </summary>
        /// <value>
        /// The company logo.
        /// </value>
        public IDigitalFile CompanyLogo { get; set; }
    }
}