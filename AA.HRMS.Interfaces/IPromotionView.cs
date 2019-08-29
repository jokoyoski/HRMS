using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface IPromotionView
    {
        int PromotionId { get; set; }
        int EmployeeId { get; set; }
        string EmployeeName { get; set; }
        int LevelId { get; set; }
        int GradeId { get; set; }
        DateTime DateCreated { get; set; }
        DateTime? DateModified { get; set; }
        bool IsActive { get; set; }
        string ProcessingMessage { get; set; }
        IList<SelectListItem> PayScaleDropDown { get; set; }
        int PayScaleId { get; set; }
        int CompanyId { get; set; }
    }
}
