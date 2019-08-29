using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    public class TrainingReportModel : ITrainingReport
    {
        /// <summary>
        /// Gets or sets the training report identifier.
        /// </summary>
        /// <value>
        /// The training report identifier.
        /// </value>
        public int TrainingReportId { get; set; }

        /// <summary>
        /// Gets or sets the training identifier.
        /// </summary>
        /// <value>
        /// The training identifier.
        /// </value>
        public int TrainingId { get; set; }

        /// <summary>
        /// Gets or sets the name of the training.
        /// </summary>
        /// <value>
        /// The name of the training.
        /// </value>
        public string TrainingName { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        /// <value>
        /// The name of the employee.
        /// </value>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the training calendar identifier.
        /// </summary>
        /// <value>
        /// The training calendar identifier.
        /// </value>
        public int TrainingCalendarId { get; set; }

        /// <summary>
        /// Gets or sets the name of the trainer.
        /// </summary>
        /// <value>
        /// The name of the trainer.
        /// </value>
        public string TrainerName { get; set; }
        /// <summary>
        /// Gets or sets the trainer evaluation comment.
        /// </summary>
        /// <value>
        /// The trainer evaluation comment.
        /// </value>
        public string TrainerEvaluationComment { get; set; }
        /// <summary>
        /// Gets or sets the trainer evaluation rating.
        /// </summary>
        /// <value>
        /// The trainer evaluation rating.
        /// </value>
        public int TrainerEvaluationRating { get; set; }
        /// <summary>
        /// Gets or sets the trainer rating.
        /// </summary>
        /// <value>
        /// The trainer rating.
        /// </value>
        public string TrainerRating { get; set; }
        /// <summary>
        /// Gets or sets the training evaluation comment.
        /// </summary>
        /// <value>
        /// The training evaluation comment.
        /// </value>
        public string TrainingEvaluationComment { get; set; }
        /// <summary>
        /// Gets or sets the training evaluation rating.
        /// </summary>
        /// <value>
        /// The training evaluation rating.
        /// </value>
        public int TrainingEvaluationRating { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the training start.
        /// </summary>
        /// <value>
        /// The training start.
        /// </value>
        public DateTime TrainingStarts { get; set; }
        /// <summary>
        /// Gets or sets the training ends.
        /// </summary>
        /// <value>
        /// The training ends.
        /// </value>
        public DateTime TrainingEnds { get; set; }
        /// <summary>
        /// Gets or sets the trainer evaluation rating.
        /// </summary>
        /// <value>
        /// The trainer evaluation rating.
        /// </value>
        public string TrainerEvaluationRatingName { get; set; }
        /// <summary>
        /// Gets or sets the name of the training evaluation rating.
        /// </summary>
        /// <value>
        /// The name of the training evaluation rating.
        /// </value>
        public string TrainingEvaluationRatingName { get; set; }
    }
}
