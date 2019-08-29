using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEducationHistoryView
    {
        /// <summary>
        /// Gets or sets the education history identifier.
        /// </summary>
        /// <value>
        /// The education history identifier.
        /// </value>
        int EducationHistoryId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the school.
        /// </summary>
        /// <value>
        /// The name of the school.
        /// </value>
        string SchoolName { get; set; }

        /// <summary>
        /// Gets or sets the degree.
        /// </summary>
        /// <value>
        /// The degree.
        /// </value>
        string Degree { get; set; }


        /// <summary>
        /// Gets or sets the graduation year.
        /// </summary>
        /// <value>
        /// The graduation year.
        /// </value>
        int GraduationYear { get; set; }

        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        /// <value>
        /// The note.
        /// </value>
        string Note { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        string URL { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
    }
}
