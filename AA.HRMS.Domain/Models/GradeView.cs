using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    public class GradeView : IGradeView
    {

        public GradeView()
        {
            DateCreated = DateTime.UtcNow;
            this.CompanyDropDownList = new List<SelectListItem>();
        }
        
        /// <summary>
        /// Gets or sets the company drop down list.
        /// </summary>
        /// <value>
        /// The company drop down list.
        /// </value>
        public IList<SelectListItem> CompanyDropDownList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<SelectListItem> BenefitDropDownList { get; set; }

        /// <summary>
        /// Gets or sets the grade identifier.
        /// </summary>
        /// <value>
        /// The grade identifier.
        /// </value>
        public int GradeId { get; set; }
        /// <summary>
        /// Gets or sets the grade description.
        /// </summary>
        /// <value>
        /// The grade description.
        /// </value>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Grade Name is required")]
        [MinLength(2, ErrorMessage ="Minimum Length is two characters")]
        public string GradeName { get; set; }
        /// <summary>
        /// Gets or sets the grade description.
        /// </summary>
        /// <value>
        /// The grade description.
        /// </value>
        public string GradeDescription { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }
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
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the duration of the annual leave.
        /// </summary>
        /// <value>
        /// The duration of the annual leave.
        /// </value>
        public int AnnualLeaveDuration { get; set; }
    }
}