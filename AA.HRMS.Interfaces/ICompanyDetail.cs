using System;

namespace AA.HRMS.Interfaces
{
    public interface ICompanyDetail
    {
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the cac registration number.
        /// </summary>
        /// <value>
        /// The cac registration number.
        /// </value>
        string CACRegistrationNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the company alias.
        /// </summary>
        /// <value>
        /// The company alias.
        /// </value>
        string CompanyAlias { get; set; }

        /// <summary>
        /// Gets or sets the company address line1.
        /// </summary>
        /// <value>
        /// The company address line1.
        /// </value>
        string CompanyAddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the company address line2.
        /// </summary>
        /// <value>
        /// The company address line2.
        /// </value>
        string CompanyAddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the company city.
        /// </summary>
        /// <value>
        /// The company city.
        /// </value>
        string CompanyCity { get; set; }

        /// <summary>
        /// Gets or sets the state of the company.
        /// </summary>
        /// <value>
        /// The state of the company.
        /// </value>
        string CompanyState { get; set; }


        /// <summary>
        /// Gets or sets the company country identifier.
        /// </summary>
        /// <value>
        /// The company country identifier.
        /// </value>
        int CompanyCountryId { get; set; }

        /// <summary>
        /// Gets or sets the company country.
        /// </summary>
        /// <value>
        /// The company country.
        /// </value>
        string CompanyCountry { get; set; }

        /// <summary>
        /// Gets or sets the company zip code.
        /// </summary>
        /// <value>
        /// The company zip code.
        /// </value>
        int? CompanyZipCode { get; set; }

        /// <summary>
        /// Gets or sets the comapy email.
        /// </summary>
        /// <value>
        /// The comapy email.
        /// </value>
        string CompanyEmail { get; set; }

        /// <summary>
        /// Gets or sets the company phone.
        /// </summary>
        /// <value>
        /// The company phone.
        /// </value>
        string CompanyPhone { get; set; }

        /// <summary>
        /// Gets or sets the company website.
        /// </summary>
        /// <value>
        /// The company website.
        /// </value>
        string CompanyWebsite { get; set; }

        /// <summary>
        /// Gets or sets the logo digital file identifier.
        /// </summary>
        /// <value>
        /// The logo digital file identifier.
        /// </value>
        int? LogoDigitalFileId { get; set; }

        /// <summary>
        /// Gets or sets the parent company identifier.
        /// </summary>
        /// <value>
        /// The parent company identifier.
        /// </value>
        int? ParentCompanyId { get; set; }

        /// <summary>
        /// Gets or sets the industry identifier.
        /// </summary>
        /// <value>
        /// The industry identifier.
        /// </value>
        int IndustryId { get; set; }

        /// <summary>
        /// Gets or sets the name of the industry.
        /// </summary>
        /// <value>
        /// The name of the industry.
        /// </value>
        string IndustryName { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the company logo.
        /// </summary>
        /// <value>
        /// The company logo.
        /// </value>
        IDigitalFile CompanyLogo { get; set; }
    }
}