using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;
namespace AA.HRMS.Domain.Models
{
    public class NextOfKinView : INextOfKinView
    {
        public int NextOfKinId { get; set; }
        public int EmployeeId { get; set; }
        public string NextOfKinName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Relationship { get; set; }
        public string Mobile { get; set; }
        public string Emial { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsApproved { get; set; }
        public string ProcessingMessages { get; set; }
        public string URL { get; set; }
    }
}
