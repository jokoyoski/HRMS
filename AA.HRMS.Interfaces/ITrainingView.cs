using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface ITrainingView
    {
        /// <summary>
        /// 
        /// </summary>
        int TrainingID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string TrainingName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int CompanyID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        bool IsActive { get; set; }
        /// <summary>
        /// 
        /// </summary>
        System.DateTime DateCreated { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string TrainingDescription { get; set; }
        /// <summary>
        /// Gets or sets the company drop down.
        /// </summary>
        /// <value>
        /// The company drop down.
        /// </value>
        IList<SelectListItem> CompanyDropDown { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
