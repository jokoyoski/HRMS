using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ITrainingReport
    {
        /// <summary>
        /// Gets or sets the training report identifier.
        /// </summary>
        /// <value>
        /// The training report identifier.
        /// </value>
        int TrainingReportId { get; set; }
        /// <summary>
        /// Gets or sets the training identifier.
        /// </summary>
        /// <value>
        /// The training identifier.
        /// </value>
        int TrainingId { get; set; }
        /// <summary>
        /// Gets or sets the name of the training.
        /// </summary>
        /// <value>
        /// The name of the training.
        /// </value>
        string TrainingName { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        int CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        string CompanyName { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        int EmployeeId { get; set; }
        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        /// <value>
        /// The name of the employee.
        /// </value>
        string EmployeeName { get; set; }
        /// <summary>
        /// Gets or sets the training calendar identifier.
        /// </summary>
        /// <value>
        /// The training calendar identifier.
        /// </value>
        int TrainingCalendarId { get; set; }
        /// <summary>
        /// Gets or sets the name of the trainer.
        /// </summary>
        /// <value>
        /// The name of the trainer.
        /// </value>
        string TrainerName { get; set; }
        /// <summary>
        /// Gets or sets the trainer evaluation comment.
        /// </summary>
        /// <value>
        /// The trainer evaluation comment.
        /// </value>
        string TrainerEvaluationComment { get; set; }
        /// <summary>
        /// Gets or sets the trainer evaluation rating.
        /// </summary>
        /// <value>
        /// The trainer evaluation rating.
        /// </value>
        int TrainerEvaluationRating { get; set; }
        /// <summary>
        /// Gets or sets the trainer rating.
        /// </summary>
        /// <value>
        /// The trainer rating.
        /// </value>
        string TrainerRating { get; set; }
        /// <summary>
        /// Gets or sets the training evaluation comment.
        /// </summary>
        /// <value>
        /// The training evaluation comment.
        /// </value>
        string TrainingEvaluationComment { get; set; }
        /// <summary>
        /// Gets or sets the training evaluation rating.
        /// </summary>
        /// <value>
        /// The training evaluation rating.
        /// </value>
        int TrainingEvaluationRating { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the training start.
        /// </summary>
        /// <value>
        /// The training start.
        /// </value>
        DateTime TrainingStarts { get; set; }
        /// <summary>
        /// Gets or sets the training ends.
        /// </summary>
        /// <value>
        /// The training ends.
        /// </value>
        DateTime TrainingEnds { get; set; }
        /// <summary>
        /// Gets or sets the trainer evaluation rating.
        /// </summary>
        /// <value>
        /// The trainer evaluation rating.
        /// </value>
        string TrainerEvaluationRatingName { get; set; }
        /// <summary>
        /// Gets or sets the name of the training evaluation rating.
        /// </summary>
        /// <value>
        /// The name of the training evaluation rating.
        /// </value>
        string TrainingEvaluationRatingName { get; set; }
    }
}
