using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Models;
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
    /// <seealso cref="AA.HRMS.Interfaces.ILeaveRequestListView" />
    public class LeaveRequestListView : ILeaveRequestListView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeaveRequestListView"/> class.
        /// </summary>
        public LeaveRequestListView()
        {
            LeaveStatusDropDown = new List<SelectListItem>();
        }
        

        /// <summary>
        /// Gets or sets the leave request model.
        /// </summary>
        /// <value>
        /// The leave request model.
        /// </value>
        public IList<ILeaveRequestModel> LeaveRequestCollection { get; set; }
        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>
        /// The employee.
        /// </value>
        public IEmployee Employee { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string URL { get; set; }
        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        public ICompanyDetail Company { get; set; }

        /// <summary>
        /// Gets or sets the leave status drop down.
        /// </summary>
        /// <value>
        /// The leave status drop down.
        /// </value>
        public IList<SelectListItem> LeaveStatusDropDown { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int employeeId { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

    }
}
