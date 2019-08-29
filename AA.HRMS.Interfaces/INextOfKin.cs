using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
   public interface INextOfKin
    {
         int NextOfKinId { get; set; }
         int EmployeeId { get; set; }
         string NextOfKinName { get; set; }
        DateTime DateOfBirth { get; set; }
         string Address { get; set; }
        string Relationship { get; set; }
        string Mobile { get; set; }
         string Emial { get; set; }
         bool IsActive { get; set; }
         DateTime DateCreated { get; set; }
        DateTime DateModified { get; set; }
         bool IsApproved { get; set; }
    }
}
