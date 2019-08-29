using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    public class BeneficiariesView : IBeneficiariesView
    {
        public int BeneficiaryId { get; set; }
        public int EmployeeId { get; set; }
        public string BeneficiaryName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsApproved { get; set; }
        public string ProcessingMessage { get; set; }
        public string URL { get; set; }
    }
}
