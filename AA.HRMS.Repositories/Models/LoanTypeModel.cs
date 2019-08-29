using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    public class LoanTypeModel : ILoan
    {
  
        public int LoanTypeId { get; set; }
     
        public string LoanType { get; set; }
       
        public bool IsActive { get; set; }
      
        public DateTime DateCreated { get; set; }
    
    }
}
