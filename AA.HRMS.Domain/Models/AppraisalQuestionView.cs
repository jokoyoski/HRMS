﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Domain.Models
{
    public class AppraisalQuestionView : IAppraisalQuestionView
    {
        public AppraisalQuestionView()
        {
            IsActive = true;
            DateCreated = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets or sets the appraisal question identifier.
        /// </summary>
        /// <value>
        /// The appraisal question identifier.
        /// </value>
        public int AppraisalQuestionId { get; set; }

        /// <summary>
        /// Gets or sets the question.
        /// </summary>
        /// <value>
        /// The question.
        /// </value>
        public string Question { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public System.DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date modified.
        /// </summary>
        /// <value>
        /// The date modified.
        /// </value>
        public Nullable<System.DateTime> DateModified { get; set; }

        /// <summary>
        /// Gets or sets the appraisalquestion.
        /// </summary>
        /// <value>
        /// The appraisalquestion.
        /// </value>
        public IList<IAppraisalQuestion> appraisalquestion { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
