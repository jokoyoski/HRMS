using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    public class ResultModel : IResult
    {
        public int ResultId { get; set; }
        public string ResultName { get; set; }
    }
}
