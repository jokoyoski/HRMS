﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface ITypeOfExitView
    {
        /// <summary>
        /// Gets or sets the type of exit identifier.
        /// </summary>
        /// <value>
        /// The type of exit identifier.
        /// </value>
        int TypeOfExitId { get; set; }
        /// <summary>
        /// Gets or sets the name of the type of exit.
        /// </summary>
        /// <value>
        /// The name of the type of exit.
        /// </value>
        string TypeOfExitName { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

        int EmployeeId { get; set; }

        IList<SelectListItem> EmployeeDropDown { get; set; }

        IList<SelectListItem> TypeOfExitDropDown { get; set; }

        IList<SelectListItem> InterViewerDropDown { get; set; }

        IList<SelectListItem> CompanyDropDown { get; set; }

    }
}
