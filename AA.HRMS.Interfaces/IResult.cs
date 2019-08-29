using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IResult
    {
         int ResultId { get; set; }
         string ResultName { get; set; }
    }
}
