using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IEducationHistory" />
    public class EducationHistoryModel : IEducationHistory
    {
        /// <summary>
        /// Gets or sets the application education history.
        /// </summary>
        /// <value>
        /// The application education history.
        /// </value>
        public int EducationHistoryId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int EmployeeId { get; set; }


        /// <summary>
        /// Gets or sets the name of the school.
        /// </summary>
        /// <value>
        /// The name of the school.
        /// </value>
        public string SchoolName { get; set; }

        /// <summary>
        /// Gets or sets the degree.
        /// </summary>
        /// <value>
        /// The degree.
        /// </value>
        public string Degree { get; set; }


        /// <summary>
        /// Gets or sets the graduation year.
        /// </summary>
        /// <value>
        /// The graduation year.
        /// </value>
        public int GraduationYear { get; set; }

        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        /// <value>
        /// The note.
        /// </value>
        public string Note { get; set; }


        ///// <summary>
        ///// Gets or sets the date created.
        ///// </summary>
        ///// <value>
        ///// The date created.
        ///// </value>
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}