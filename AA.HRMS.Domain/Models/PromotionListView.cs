using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    public class PromotionListView : IPromotionListView
    {
        public IList<IPromotion> PromotionCollection { get; set; }
        public string ProcessMessage { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int PayScaleId { get; set; }
    }
}
