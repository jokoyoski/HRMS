using System;
using AA.HRMS.Interfaces;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IVacancyView" />
    public class VacancyView : IVacancyView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VacancyView"/> class.
        /// </summary>
        public VacancyView()
        {
            //Department, Job Title and Grade Set to Default -1
            DepartmentId = -1;
            JobTitleId = -1;
            GradeId = -1;
        }

        /// <summary>
        /// </summary>
        public int VacancyId { get; set; }


        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        [Required]
        [Range(0, Int64.MaxValue, ErrorMessage = "You must select a company.")]
        public int CompanyId { get; set; }


       //
        public string CACRegistrationNumber { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>

        public int DepartmentId { get; set; }



        /// <summary>
        /// Gets or sets the job title identifier.
        /// </summary>
        /// <value>
        /// The job title identifier.
        /// </value>
        public int JobTitleId { get; set; }


        /// <summary>
        /// Gets or sets the grade identifier.
        /// </summary>
        /// <value>
        /// The grade identifier.
        /// </value>
        public int GradeId { get; set; }


        /// <summary>
        /// Gets or sets the job title.
        /// </summary>
        /// <value>
        /// The job title.
        /// </value>
        [Required]
        public string JobTitle { get; set; }


        /// <summary>
        /// Gets or sets the job function.
        /// </summary>
        /// <value>
        /// The job function.
        /// </value>
        [Required]
        [AllowHtml]
        public string JobFunction { get; set; }

        /// <summary>
        /// Gets or sets the qualification.
        /// </summary>
        /// <value>
        /// The qualification.
        /// </value>
        [Required]
        [AllowHtml]
        public string Qualification { get; set; }

        /// <summary>
        /// Gets or sets the experience.
        /// </summary>
        /// <value>
        /// The experience.
        /// </value>
        [Required]
        [AllowHtml]
        public string Experience { get; set; }

        /// <summary>
        /// Gets or sets the number to employ.
        /// </summary>
        /// <value>
        /// The number to employ.
        /// </value>
        [Required]
        [Range(0, Int64.MaxValue, ErrorMessage = "Number to employ must more than 0")]
        public int NumberToEmploy { get; set; }

        /// <summary>
        /// Gets or sets the open date.
        /// </summary>
        /// <value>
        /// The open date.
        /// </value>
        [Required]
        public DateTime OpenDate { get; set; }

        /// <summary>
        /// Gets or sets the closedate.
        /// </summary>
        /// <value>
        /// The closedate.
        /// </value>
        [Required]
        public DateTime Closedate { get; set; }


        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the company drop down.
        /// </summary>
        /// <value>
        /// The company drop down.
        /// </value>
        public IList<SelectListItem> CompanyDropDown { get; set; }

        /// <summary>
        /// Gets or sets the department drop down.
        /// </summary>
        /// <value>
        /// The department drop down.
        /// </value>
        public IList<SelectListItem> DepartmentDropDown { get; set; }


        /// <summary>
        /// Gets or sets the job title drop down.
        /// </summary>
        /// <value>
        /// The job title drop down.
        /// </value>
        public IList<SelectListItem> JobTitleDropDown { get; set; }

        /// <summary>
        /// Gets or sets the grades drop down.
        /// </summary>
        /// <value>
        /// The grades drop down.
        /// </value>
        public IList<SelectListItem> GradesDropDown { get; set; }
    }
}