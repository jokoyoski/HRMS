using System;
using System.Collections.Generic;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IVacancyDetail" />
    public class VacancyDetail : IVacancyDetail
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VacancyDetail" /> class.
        /// </summary>
        public VacancyDetail()
        {
            this.QuestionCollection = new List<IVacancyQuestion>();
        }

        /// <summary>
        /// Gets or sets the vacancy identifier.
        /// </summary>
        /// <value>
        /// The vacancy identifier.
        /// </value>
        public int VacancyId { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the state of the company.
        /// </summary>
        /// <value>
        /// The state of the company.
        /// </value>
        public string CompanyState { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        /// <value>
        /// The department.
        /// </value>
        public string Department { get; set; }

        /// <summary>
        /// Gets or sets the job title identifier.
        /// </summary>
        /// <value>
        /// The job title identifier.
        /// </value>
        public int JobTitleId { get; set; }

        /// <summary>
        /// Gets or sets the job title.
        /// </summary>
        /// <value>
        /// The job title.
        /// </value>
        public string JobTitle { get; set; }

        /// <summary>
        /// Gets or sets the grade identifier.
        /// </summary>
        /// <value>
        /// The grade identifier.
        /// </value>
        public int GradeId { get; set; }

        /// <summary>
        /// Gets or sets the qualification.
        /// </summary>
        /// <value>
        /// The qualification.
        /// </value>
        public string Qualification { get; set; }

        /// <summary>
        /// Gets or sets the experience.
        /// </summary>
        /// <value>
        /// The experience.
        /// </value>
        public string Experience { get; set; }

        /// <summary>
        /// Gets or sets the number to employ.
        /// </summary>
        /// <value>
        /// The number to employ.
        /// </value>
        public int NumberToEmploy { get; set; }

        /// <summary>
        /// Gets or sets the open date.
        /// </summary>
        /// <value>
        /// The open date.
        /// </value>
        public DateTime OpenDate { get; set; }

        /// <summary>
        /// Gets or sets the closedate.
        /// </summary>
        /// <value>
        /// The closedate.
        /// </value>
        public DateTime Closedate { get; set; }

        /// <summary>
        /// Gets or sets the job definition.
        /// </summary>
        /// <value>
        /// The job definition.
        /// </value>
        public string JobDefinition { get; set; }

        /// <summary>
        /// Gets or sets the job function.
        /// </summary>
        /// <value>
        /// The job function.
        /// </value>
        public string JobFunction { get; set; }

        /// <summary>
        /// Gets or sets the question collection.
        /// </summary>
        /// <value>
        /// The question collection.
        /// </value>
        public IList<IVacancyQuestion> QuestionCollection { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the has applied.
        /// </summary>
        /// <value>
        /// The has applied.
        /// </value>
        public bool HasApplied { get; set; }

        /// <summary>
        /// Gets or sets the company alas.
        /// </summary>
        /// <value>
        /// The company alas.
        /// </value>
        public string CompanyAlias { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}

















