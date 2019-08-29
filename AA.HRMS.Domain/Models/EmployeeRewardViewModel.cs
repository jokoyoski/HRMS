using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IEmployeeRewardViewModel" />
    public class EmployeeRewardViewModel : IEmployeeRewardViewModel
    {
        public EmployeeRewardViewModel()
        {
            this.CompanyDropDownList = new List<SelectListItem>();
            this.EmployeeDropDownList = new List<SelectListItem>();
            this.RewardDropdownList = new List<SelectListItem>();
        }

        /// <summary>
        /// Gets or sets the employee reward identifier.
        /// </summary>
        /// <value>
        /// The employee reward identifier.
        /// </value>
        public int EmployeeRewardId { get; set; }

        public int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the reward identifier.
        /// </summary>
        /// <value>
        /// The reward identifier.
        /// </value>
        public int RewardId { get; set; }
        /// <summary>
        /// Gets or sets the name of the reward.
        /// </summary>
        /// <value>
        /// The name of the reward.
        /// </value>
    
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeId { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        public IList<SelectListItem> CompanyDropDownList { get; set; }
        public IList<SelectListItem> EmployeeDropDownList { get; set; }
        public IList<SelectListItem> RewardDropdownList { set; get; }

        public string ProcessingMessage { set; get; }
    }
}
