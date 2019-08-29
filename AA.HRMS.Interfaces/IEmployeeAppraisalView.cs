using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IEmployeeAppraisalView
    {
         int EmployeeAppraisalId { get; set; }
         int? SupervisorId { get; set; }
         int AppraisalId { get; set; }
         int EmployeeId { get; set; }
         int HRId { get; set; }
         DateTime? DateApproved { get; set; }
         DateTime? DateAgreed { get; set; }
         DateTime DateCreated { get; set; }
         DateTime? DateModified { get; set; }
         bool IsActive { get; set; }
         int CompanyId { get; set; }
        string Status { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
