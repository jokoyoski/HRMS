using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    public class EmployeeAppraisalViewModel : IEmployeeAppraisalView
    {
        public int EmployeeAppraisalId { get; set; }
        public int? SupervisorId { get; set; }
        public int AppraisalId { get; set; }
        public int EmployeeId { get; set; }
        public int HRId { get; set; }
        public DateTime? DateApproved { get; set; }
        public DateTime? DateAgreed { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
