
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    public class TrainingEvaluationRatingViewModel : ITrainingEvaluationRatingViewModel
    {
        public int TrainingEvaluationratingId { get; set; }
        public string TrainerEvaluationRating { get; set; }
    }
}
