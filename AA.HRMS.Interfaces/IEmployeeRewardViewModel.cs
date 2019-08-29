using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface IEmployeeRewardViewModel
    {
        int EmployeeRewardId { get; set; }

        int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the reward identifier.
        /// </summary>
        /// <value>
        /// The reward identifier.
        /// </value>
        int RewardId { get; set; }
        
      
        int EmployeeId { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        decimal Amount { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
         DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
         bool IsActive { get; set; }

         IList<SelectListItem> CompanyDropDownList { get; set; }
         IList<SelectListItem> EmployeeDropDownList { get; set; }
         IList<SelectListItem> RewardDropdownList { set; get; }

         string ProcessingMessage { set; get; }
    }
}
