using AA.HRMS.Repositories.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.ITraining" />
    public class TrainingModel : ITraining
    {
        public int TrainingID { get; set; }
        /// <summary>
        /// </summary>
        public string TrainingName { get; set; }
        /// <summary>
        /// </summary>
        public int CompanyID { get; set; }
        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        public string CompanyName { get; set; }
        /// <summary>
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// </summary>
        public System.DateTime DateCreated { get; set; }
        /// <summary>
        /// </summary>
        public string TrainingDescription { get; set; }

    }

   
}

