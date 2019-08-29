using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    public class PromotionView : IPromotionView
    {

        public PromotionView()
        {
            this.PayScaleDropDown = new List<SelectListItem>();
        }
        public int PromotionId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int LevelId { get; set; }
        public int GradeId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsActive { get; set; }
        public string ProcessingMessage { get; set; }
        public IList<SelectListItem> PayScaleDropDown { get; set; }
        public int PayScaleId { get; set; }
        public int CompanyId { get; set; }
    }
}
