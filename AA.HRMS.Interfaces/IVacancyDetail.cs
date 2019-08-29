using System;
using System.Collections.Generic;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IVacancyDetail
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
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the state of the company.
        /// </summary>
        /// <value>
        /// The state of the company.
        /// </value>
        string CompanyState { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        /// <value>
        /// The department.
        /// </value>
        string Department { get; set; }

        /// <summary>
        /// Gets or sets the job title identifier.
        /// </summary>
        /// <value>
        /// The job title identifier.
        /// </value>
        int JobTitleId { get; set; }

        /// <summary>
        /// Gets or sets the job title.
        /// </summary>
        /// <value>
        /// The job title.
        /// </value>
        string JobTitle { get; set; }

        /// <summary>
        /// Gets or sets the grade identifier.
        /// </summary>
        /// <value>
        /// The grade identifier.
        /// </value>
        int GradeId { get; set; }

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
        /// Gets or sets the question collection.
        /// </summary>
        /// <value>
        /// The question collection.
        /// </value>
        IList<IVacancyQuestion> QuestionCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the company alias.
        /// </summary>
        /// <value>
        /// The company alias.
        /// </value>
        string CompanyAlias { get; set; }

        /// <summary>
        /// Gets or sets the has applied.
        /// </summary>
        /// <value>
        /// The has applied.
        /// </value>
        bool HasApplied { get; set; }
    }
}