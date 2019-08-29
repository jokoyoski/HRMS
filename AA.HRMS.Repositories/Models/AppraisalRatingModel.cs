﻿using System;
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
    /// <seealso cref="AA.HRMS.Interfaces.IAppraisalRating" />
    public class AppraisalRatingModel : IAppraisalRating
    {
        /// <summary>
        /// Gets or sets the appraisal rating identifier.
        /// </summary>
        /// <value>
        /// The appraisal rating identifier.
        /// </value>
        public int AppraisalRatingId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the name of the appraisal rating.
        /// </summary>
        /// <value>
        /// The name of the appraisal rating.
        /// </value>
        public string AppraisalRatingName { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }
    }
}