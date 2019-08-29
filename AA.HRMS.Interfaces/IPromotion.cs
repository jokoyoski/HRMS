using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IPromotion
    {
        int PromotionId { get; set; }
        int EmployeeId { get; set; }
        int LevelId { get; set; }
        int GradeId { get; set; }
        string LevelName { get; set; }
        string GradeName { get; set; }
        DateTime DateCreated { get; set; }
        DateTime? DateModified { get; set; }
        bool IsActive { get; set; }
        string EmployeeName { get; set; }
        int CompanyId { get; set; }
    }
}
