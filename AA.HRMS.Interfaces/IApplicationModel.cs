using System;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IApplicationModel
    {
        /// <summary>
        /// Gets or sets the vacancy application identifier.
        /// </summary>
        /// <value>
        /// The vacancy application identifier.
        /// </value>
        int VacancyApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the vacancy identifier.
        /// </summary>
        /// <value>
        /// The vacancy identifier.
        /// </value>
        int VacancyId { get; set; }


        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int UserId { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        string LastName { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the job title.
        /// </summary>
        /// <value>
        /// The job title.
        /// </value>
        string JobTitle { get; set; }


        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        string CompanyName { get; set; }


        /// <summary>
        /// Gets or sets the company alias.
        /// </summary>
        /// <value>
        /// The company alias.
        /// </value>
        string CompanyAlias { get; set; }


        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        int CompanyId { get; set; }


        /// <summary>
        /// Gets or sets the state of the company.
        /// </summary>
        /// <value>
        /// The state of the company.
        /// </value>
        string CompanyState { get; set; }


        /// <summary>
        /// Gets or sets the application date.
        /// </summary>
        /// <value>
        /// The application date.
        /// </value>
        DateTime ApplicationDate { get; set; }
    }
}