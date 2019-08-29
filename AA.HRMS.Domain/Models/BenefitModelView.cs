using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IBenefitModelView" />
    public class BenefitModelView : IBenefitModelView
    {
        public BenefitModelView()
        {
            this.CompanyDropDownList = new List<SelectListItem>();
            this.PeriodCollection = new List<SelectListItem>();
        }

        /// <summary>
        /// Gets or sets the benefit identifier.
        /// </summary>
        /// <value>
        /// The benefit identifier.
        /// </value>
        public int BenefitId { get; set; }
        /// <summary>
        /// Gets or sets the name of the benefit.
        /// </summary>
        /// <value>
        /// The name of the benefit.
        /// </value>
        public string BenefitName { get; set; }
        /// <summary>
        /// Gets or sets the benefit description.
        /// </summary>
        /// <value>
        /// The benefit description.
        /// </value>
        public string BenefitDescription { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is monetized.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is monetized; otherwise, <c>false</c>.
        /// </value>
        public bool IsMonetized { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is taxable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is taxable; otherwise, <c>false</c>.
        /// </value>
        public bool IsTaxable { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the date modified.
        /// </summary>
        /// <value>
        /// The date modified.
        /// </value>
        public DateTime? DateModified { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        public string CompanyName { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
        public IList<SelectListItem> CompanyDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the period collection.
        /// </summary>
        /// <value>
        /// The period collection.
        /// </value>
        public IList<SelectListItem> PeriodCollection { get; set; }
        /// <summary>
        /// Gets or sets the period.
        /// </summary>
        /// <value>
        /// The period.
        /// </value>
        public int Period { get; set; }
    }
}
