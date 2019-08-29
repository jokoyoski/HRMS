using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IChildrenInformationView
    {
         int ChildrenId { get; set; }
         int EmployeeId { get; set; }
         string ChildName { get; set; }
         string Email { get; set; }
         DateTime DateOfBirth { get; set; }
         string Address { get; set; }
         string Mobile { get; set; }
         bool IsActive { get; set; }
         DateTime DateCreated { get; set; }
         DateTime DateModified { get; set; }
         bool IsApproved { get; set; }
        string ProcessingMessage { get; set; }
        string URL { get; set; }
    }
}
