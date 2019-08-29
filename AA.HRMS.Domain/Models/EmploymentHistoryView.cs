﻿using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IEmploymentHistoryView" />
    public class EmploymentHistoryView : IEmploymentHistoryView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmploymentHistoryView"/> class.
        /// </summary>
        public EmploymentHistoryView()
        {
            DateCreated = DateTime.UtcNow;
        }
        /// <summary>
        /// Gets or sets the employment history identifier.
        /// </summary>
        /// <value>
        /// The employment history identifier.
        /// </value>
        public int EmploymentHistoryId { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeId { get; set; }
        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        public string CompanyName { get; set; }
        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Gets or sets the reason exit.
        /// </summary>
        /// <value>
        /// The reason exit.
        /// </value>
        public string ReasonExit { get; set; }
        /// <summary>
        /// Gets or sets the level on exit.
        /// </summary>
        /// <value>
        /// The level on exit.
        /// </value>
        public string LevelOnExit { get; set; }
        /// <summary>
        /// Gets or sets the job function.
        /// </summary>
        /// <value>
        /// The job function.
        /// </value>
        public string JobFunction { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string URL { get; set; }
    }
}
