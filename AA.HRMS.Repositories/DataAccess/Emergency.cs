//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AA.HRMS.Repositories.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Emergency
    {
        public int EmergencyId { get; set; }
        public int EmployeeId { get; set; }
        public string EmergencyName { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public bool IsApproved { get; set; }
    }
}
