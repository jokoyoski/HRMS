using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IJobTitleView" />
    public class JobTitleView : IJobTitleView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobTitleView"/> class.
        /// </summary>
        public JobTitleView()
        {
          
            this.ProcessingMessage = string.Empty;
            this.CompanyDropDownList = new List<SelectListItem>();
        }

        /// <summary>
        /// Gets or sets the job title identifier.
        /// </summary>
        /// <value>
        /// The job title identifier.
        /// </value>
        public int JobTitleId { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }

        
        /// <summary>
        /// Gets or sets the job title1.
        /// </summary>
        /// <value>
        /// The job title1.
        /// </value>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string JobTitleName { get; set; }

        /// <summary>
        /// Gets or sets the job definition.
        /// </summary>
        /// <value>
        /// The job definition.
        /// </value>
        public string JobDefinition { get; set; }

        /// <summary>
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
        public IList<SelectListItem> CompanyDropDownList { get; set; }

        /// <summary>
        /// Gets or sets the job function.
        /// </summary>
        /// <value>
        /// The job function.
        /// </value>
        public string JobFunction { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }


        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}