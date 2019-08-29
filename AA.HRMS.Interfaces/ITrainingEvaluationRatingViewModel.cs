using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITrainingEvaluationRatingViewModel
    {
        /// <summary>
        /// Gets or sets the training evaluationrating identifier.
        /// </summary>
        /// <value>
        /// The training evaluationrating identifier.
        /// </value>
        int TrainingEvaluationratingId { get; set; }
        /// <summary>
        /// Gets or sets the trainer evaluation rating.
        /// </summary>
        /// <value>
        /// The trainer evaluation rating.
        /// </value>
        string TrainerEvaluationRating { get; set; }
    }
}
