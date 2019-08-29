using System;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IJobApplicationVacancyAnswer
    {
        /// <summary>
        /// Gets or sets the job application vacancy answer identifier.
        /// </summary>
        /// <value>
        /// The job application vacancy answer identifier.
        /// </value>
        int JobApplicationVacancyAnswerId { get; set; }

        /// <summary>
        /// Gets or sets the vacancy question identifier.
        /// </summary>
        /// <value>
        /// The vacancy question identifier.
        /// </value>
        int VacancyQuestionId { get; set; }

        /// <summary>
        /// Gets or sets the job application vacancy identifier.
        /// </summary>
        /// <value>
        /// The job application vacancy identifier.
        /// </value>
        int JobApplicationVacancyId { get; set; }

        /// <summary>
        /// Gets or sets the answer.
        /// </summary>
        /// <value>
        /// The answer.
        /// </value>
        string Answer { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }
    }
}