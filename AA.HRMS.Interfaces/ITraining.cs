using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ITraining
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
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        string CompanyName { get; set; }
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
    }
}
