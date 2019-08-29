using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface IBenefitModelView
    {
        /// <summary>
        /// Gets or sets the benefit identifier.
        /// </summary>
        /// <value>
        /// The benefit identifier.
        /// </value>
        int BenefitId { get; set; }
        /// <summary>
        /// Gets or sets the name of the benefit.
        /// </summary>
        /// <value>
        /// The name of the benefit.
        /// </value>
        string BenefitName { get; set; }
        /// <summary>
        /// Gets or sets the benefit description.
        /// </summary>
        /// <value>
        /// The benefit description.
        /// </value>
        string BenefitDescription { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is monetized.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is monetized; otherwise, <c>false</c>.
        /// </value>
        bool IsMonetized { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is taxable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is taxable; otherwise, <c>false</c>.
        /// </value>
        bool IsTaxable { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the date modified.
        /// </summary>
        /// <value>
        /// The date modified.
        /// </value>
        DateTime? DateModified { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        string CompanyName { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
        IList<SelectListItem> CompanyDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the period collection.
        /// </summary>
        /// <value>
        /// The period collection.
        /// </value>
        IList<SelectListItem> PeriodCollection { get; set; }
        /// <summary>
        /// Gets or sets the period.
        /// </summary>
        /// <value>
        /// The period.
        /// </value>
        int Period { get; set; }
    }
}
