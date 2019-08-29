using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IEmergency
    {
         int EmergencyId { get; set; }
         int EmployeeId { get; set; }
         string EmergencyName { get; set; }
         DateTime DateOfBirth { get; set; }
         string Address { get; set; }
         string Mobile { get; set; }
          string Email { get; set; }
          bool IsActive { get; set; }
          DateTime DateCreated { get; set; }
          DateTime DateModified { get; set; }
          bool IsApproved { get; set; }
    }
}
