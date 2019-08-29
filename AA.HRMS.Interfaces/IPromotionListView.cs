using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IPromotionListView
    {
        IList<IPromotion> PromotionCollection { get; set; }
        string ProcessMessage { get; set; }
        int EmployeeId { get; set; }
        string EmployeeName { get; set; }
        int PayScaleId { get; set; }
    }
}
