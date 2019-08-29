using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    public class TrainingEvaluationRatingModel : ITrainingEvaluationRating
    {
        /// <summary>
        /// Gets or sets the training evaluation rating identifier.
        /// </summary>
        /// <value>
        /// The training evaluation rating identifier.
        /// </value>
        public int TrainingEvaluationRatingId { get; set; }
        /// <summary>
        /// Gets or sets the training evaluation rating1.
        /// </summary>
        /// <value>
        /// The training evaluation rating1.
        /// </value>
        public string TrainingEvaluationRating1 { get; set; }
    }
}
