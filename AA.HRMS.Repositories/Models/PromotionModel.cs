using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Repositories.Models
{
    public class PromotionModel : IPromotion
    {
        public int PromotionId { get; set; }
        public int EmployeeId { get; set; }
        public int LevelId { get; set; }
        public string LevelName { get; set; }
        public string GradeName { get; set; }
        public int GradeId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsActive { get; set; }
        public string EmployeeName { get; set; }
        public int CompanyId { get; set; }
        public DateTime DatePromoted { get; set; }
    }
}
