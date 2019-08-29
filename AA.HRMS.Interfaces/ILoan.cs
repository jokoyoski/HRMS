using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ILoan
    {
   
        int LoanTypeId { get; set; }
   
        string LoanType { get; set; }
   
        bool IsActive { get; set; }
    
        DateTime DateCreated { get; set; }
      
    }
}
