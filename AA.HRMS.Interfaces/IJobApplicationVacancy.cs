using System;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IJobApplicationVacancy
    {

        /// <summary>
        /// Gets or sets the job application vacancy identifier.
        /// </summary>
        /// <value>
        /// The job application vacancy identifier.
        /// </value>
        int JobApplicationVacancyId { get; set; }

        /// <summary>
        /// Gets or sets the job application identifier.
        /// </summary>
        /// <value>
        /// The job application identifier.
        /// </value>
        int JobApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int UserId { get; set; }

        /// <summary>
        /// Gets or sets the vacancy identifier.
        /// </summary>
        /// <value>
        /// The vacancy identifier.
        /// </value>
        int VacancyId { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
    }
}