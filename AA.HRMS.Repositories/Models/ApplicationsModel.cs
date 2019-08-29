using System;
using System.Collections.Generic;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IApplicationModel" />
    public class ApplicationsModel : IApplicationModel
    {
        /// <summary>
        /// Gets or sets the vacancy application identifier.
        /// </summary>
        /// <value>
        /// The vacancy application identifier.
        /// </value>
        public int VacancyApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the vacancy identifier.
        /// </summary>
        /// <value>
        /// The vacancy identifier.
        /// </value>
        public int VacancyId { get; set; }


        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the job title.
        /// </summary>
        /// <value>
        /// The job title.
        /// </value>
        public string JobTitle { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the company alias.
        /// </summary>
        /// <value>
        /// The company alias.
        /// </value>
        public string CompanyAlias { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the state of the company.
        /// </summary>
        /// <value>
        /// The state of the company.
        /// </value>
        public string CompanyState { get; set; }


        /// <summary>
        /// Gets or sets the application date.
        /// </summary>
        /// <value>
        /// The application date.
        /// </value>
        public DateTime ApplicationDate { get; set; }
    }
}