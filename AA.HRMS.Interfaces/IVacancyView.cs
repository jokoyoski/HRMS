using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IVacancyView
    {
        /// <summary>
        /// Gets or sets the vacancy identifier.
        /// </summary>
        /// <value>
        /// The vacancy identifier.
        /// </value>
        int VacancyId { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        int CompanyId { get; set; }


        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        string CACRegistrationNumber { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the job title identifier.
        /// </summary>
        /// <value>
        /// The job title identifier.
        /// </value>
        int JobTitleId { get; set; }

        /// <summary>
        /// Gets or sets the grade identifier.
        /// </summary>
        /// <value>
        /// The grade identifier.
        /// </value>
        int GradeId { get; set; }


        /// <summary>
        /// Gets or sets the job title.
        /// </summary>
        /// <value>
        /// The job title.
        /// </value>
        string JobTitle { get; set; }


        /// <summary>
        /// Gets or sets the job function.
        /// </summary>
        /// <value>
        /// The job function.
        /// </value>
        string JobFunction { get; set; }

        /// <summary>
        /// Gets or sets the qualification.
        /// </summary>
        /// <value>
        /// The qualification.
        /// </value>
        string Qualification { get; set; }

        /// <summary>
        /// Gets or sets the experience.
        /// </summary>
        /// <value>
        /// The experience.
        /// </value>
        string Experience { get; set; }

        /// <summary>
        /// Gets or sets the number to employ.
        /// </summary>
        /// <value>
        /// The number to employ.
        /// </value>
        int NumberToEmploy { get; set; }

        /// <summary>
        /// Gets or sets the open date.
        /// </summary>
        /// <value>
        /// The open date.
        /// </value>
        DateTime OpenDate { get; set; }

        /// <summary>
        /// Gets or sets the closedate.
        /// </summary>
        /// <value>
        /// The closedate.
        /// </value>
        DateTime Closedate { get; set; }

        /// <summary>
        /// Gets or sets the company drop down.
        /// </summary>
        /// <value>
        /// The company drop down.
        /// </value>
        IList<SelectListItem> CompanyDropDown { get; set; }

        /// <summary>
        /// Gets or sets the department drop down.
        /// </summary>
        /// <value>
        /// The department drop down.
        /// </value>
        IList<SelectListItem> DepartmentDropDown { get; set; }

        /// <summary>
        /// Gets or sets the job title drop down.
        /// </summary>
        /// <value>
        /// The job title drop down.
        /// </value>
        IList<SelectListItem> JobTitleDropDown { get; set; }


        /// <summary>
        /// Gets or sets the grades drop down.
        /// </summary>
        /// <value>
        /// The grades drop down.
        /// </value>
        IList<SelectListItem> GradesDropDown { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}