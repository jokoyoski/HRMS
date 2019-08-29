using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AA.HRMS.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IDepartmentView" />
    public class DepartmentView : IDepartmentView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentView"/> class.
        /// </summary>
        public DepartmentView()
        {
            IsActive = true;
            DateCreated = DateTime.UtcNow;
            this.ParentDepartmentDropDown = new List<SelectListItem>();
            this.CompanyDropDownList = new List<SelectListItem>();
        }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public int DepartmentId { get; set; }

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
        /// Gets or sets the name of the department.
        /// </summary>
        /// <value>
        /// The name of the department.
        /// </value>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string DepartmentName { get; set; }

        /// <summary>
        /// Gets or sets the parent department identifier.
        /// </summary>
        /// <value>
        /// The parent department identifier.
        /// </value>
        public int? ParentDepartmentId { get; set; }



        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime? DateCreated { get; set; }


        /// <summary>
        /// Gets or sets the parent drop down.
        /// </summary>
        /// <value>
        /// The parent drop down.
        /// </value>
        public IList<SelectListItem> ParentDepartmentDropDown { get; set; }

        /// <summary>
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
        public IList<SelectListItem> CompanyDropDownList { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}