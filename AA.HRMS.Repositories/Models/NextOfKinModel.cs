﻿using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
   public  class NextOfKinModel : INextOfKin
    {
        public int NextOfKinId { get; set; }
        public int EmployeeId { get; set; }
        public string NextOfKinName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Emial { get; set; }
        public string Relationship { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsApproved { get; set; }
    }
}
