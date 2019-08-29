using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ITrainingEvaluationRating
    {
        /// <summary>
        /// Gets or sets the training evaluation rating identifier.
        /// </summary>
        /// <value>
        /// The training evaluation rating identifier.
        /// </value>
        int TrainingEvaluationRatingId { get; set; }
        /// <summary>
        /// Gets or sets the training evaluation rating1.
        /// </summary>
        /// <value>
        /// The training evaluation rating1.
        /// </value>
        string TrainingEvaluationRating1 { get; set; }
    }
}
