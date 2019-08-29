﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDepartmentView
    {
        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        int DepartmentId { get; set; }

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
        /// Gets or sets the name of the department.
        /// </summary>
        /// <value>
        /// The name of the department.
        /// </value>
        string DepartmentName { get; set; }



        /// <summary>
        /// Gets or sets the parent department identifier.
        /// </summary>
        /// <value>
        /// The parent department identifier.
        /// </value>
        int? ParentDepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime? DateCreated { get; set; }


        /// <summary>
        /// Gets or sets the parent department drop down.
        /// </summary>
        /// <value>
        /// The parent department drop down.
        /// </value>
        IList<SelectListItem> ParentDepartmentDropDown { get; set; }

        /// <summary>
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
        IList<SelectListItem> CompanyDropDownList { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}