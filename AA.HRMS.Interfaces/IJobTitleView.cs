using System;
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
    public interface IJobTitleView
    {
        /// <summary>
        /// Gets or sets the job title identifier.
        /// </summary>
        /// <value>
        /// The job title identifier.
        /// </value>
        int JobTitleId { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
        IList<SelectListItem> CompanyDropDownList { get; set; }


        /// <summary>
        /// Gets or sets the job title1.
        /// </summary>
        /// <value>
        /// The job title1.
        /// </value>
        string JobTitleName { get; set; }

        /// <summary>
        /// Gets or sets the job definition.
        /// </summary>
        /// <value>
        /// The job definition.
        /// </value>
        string JobDefinition { get; set; }

        /// <summary>
        /// Gets or sets the job function.
        /// </summary>
        /// <value>
        /// The job function.
        /// </value>
        string JobFunction { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }




        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
    }
}