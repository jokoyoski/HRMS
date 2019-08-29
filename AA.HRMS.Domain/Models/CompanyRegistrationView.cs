using System;
using AA.HRMS.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.ICompanyRegistrationView" />
    public class CompanyRegistrationView : ICompanyRegistrationView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyRegistrationView"/> class.
        /// </summary>
        public CompanyRegistrationView()
        {
            this.ParentCompanyDropDownList = new List<SelectListItem>();
            this.IndustryDropDownList = new List<SelectListItem>();
            this.CountryDropDownList = new List<SelectListItem>();
            this.ProcessingMessage = string.Empty;
            this.IsActive = true;
        }

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
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string CACRegistrationNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the company alias.
        /// </summary>
        /// <value>
        /// The company alias.
        /// </value>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string CompanyAlias { get; set; }


        /// <summary>
        /// Gets or sets the company address line1.
        /// </summary>
        /// <value>
        /// The company address line1.
        /// </value>
        [Required]
        [StringLength(150, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string CompanyAddressLine1 { get; set; }


        /// <summary>
        /// Gets or sets the company address line2.
        /// </summary>
        /// <value>
        /// The company address line2.
        /// </value>
        [StringLength(150, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string CompanyAddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the company city.
        /// </summary>
        /// <value>
        /// The company city.
        /// </value>
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string CompanyCity { get; set; }

        /// <summary>
        /// Gets or sets the state of the company.
        /// </summary>
        /// <value>
        /// The state of the company.
        /// </value>
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string CompanyState { get; set; }

        /// <summary>
        /// Gets or sets the company country.
        /// </summary>
        /// <value>
        /// The company country.
        /// </value>
        [Required]
        [Range(1, Int64.MaxValue, ErrorMessage = "Please select a valid country")]
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
        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string CompanyEmail { get; set; }

        /// <summary>
        /// Gets or sets the company phone.
        /// </summary>
        /// <value>
        /// The company phone.
        /// </value>
        [Required]
        [Phone]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string CompanyPhone { get; set; }

        /// <summary>
        /// Gets or sets the company website.
        /// </summary>
        /// <value>
        /// The company website.
        /// </value>
        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
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
        [Required]
        [Range(1, Int64.MaxValue, ErrorMessage = "Please select a valid company")]
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
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the parent company drop down list.
        /// </summary>
        /// <value>
        /// The parent company drop down list.
        /// </value>
        public IList<SelectListItem> ParentCompanyDropDownList { get; set; }

        /// <summary>
        /// Gets or sets the industry drop down list.
        /// </summary>
        /// <value>
        /// The industry drop down list.
        /// </value>
        public IList<SelectListItem> IndustryDropDownList { get; set; }

        /// <summary>
        /// Gets or sets the country drop down list.
        /// </summary>
        /// <value>
        /// The country drop down list.
        /// </value>
        public IList<SelectListItem> CountryDropDownList { get; set; }

        /// <summary>
        /// </summary>
        public IDigitalFile CompanyLogo { get; set; }
    }
}