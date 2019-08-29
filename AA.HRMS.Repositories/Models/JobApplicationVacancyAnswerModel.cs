using System;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IJobApplicationVacancyAnswer" />
    public class JobApplicationVacancyAnswerModel : IJobApplicationVacancyAnswer
    {
        /// <summary>
        /// Gets or sets the job application vacancy answer identifier.
        /// </summary>
        /// <value>
        /// The job application vacancy answer identifier.
        /// </value>
        public int JobApplicationVacancyAnswerId { get; set; }

        /// <summary>
        /// Gets or sets the vacancy question identifier.
        /// </summary>
        /// <value>
        /// The vacancy question identifier.
        /// </value>
        public int VacancyQuestionId { get; set; }

        /// <summary>
        /// Gets or sets the job application vacancy identifier.
        /// </summary>
        /// <value>
        /// The job application vacancy identifier.
        /// </value>
        public int JobApplicationVacancyId { get; set; }

        /// <summary>
        /// Gets or sets the answer.
        /// </summary>
        /// <value>
        /// The answer.
        /// </value>
        public string Answer { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }
    }
}