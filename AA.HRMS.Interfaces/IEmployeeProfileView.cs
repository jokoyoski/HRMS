using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface IEmployeeProfileView
    {

          IEnumerable<ISpouseModel> spouseModel { get; set; }

          IEnumerable<IEmergency> emergencyModel { get; set; }
          IList<INextOfKin> nextOfKinModel { get; set; }
          IEnumerable<IBeneficiariesModel> beneficiaryModel { get; set; }
          IEnumerable<IChildrenModel> childrenModel { get; set; }

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>
        /// The employee.
        /// </value>
        IEmployee Employee { get; set; }
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        IUserDetail User { get; set; }

        IList<SelectListItem> CompanyDropDown { get; set; }

        IList<ILeaveRequestModel> PendingLeaveRquest { get; set; }

         IList<IEmployeeTrainingModel> PendingTrainingRequest { get; set; }

         IList<IEmployeeLoan> PendingLoanRequest { get; set; }

        /// <summary>
        /// Gets or sets the level collection.
        /// </summary>
        /// <value>
        /// The level collection.
        /// </value>
        IList<ILevel> LevelCollection { get; set; }

        /// <summary>
        /// Gets or sets the grade collection.
        /// </summary>
        /// <value>
        /// The grade collection.
        /// </value>
        IList<IGrade> GradeCollection { get; set; }

        /// <summary>
        /// Gets or sets the job title.
        /// </summary>
        /// <value>
        /// The job title.
        /// </value>
        IList<IJobTitle> JobTitle { get; set; }

        /// <summary>
        /// Gets or sets the profile.
        /// </summary>
        /// <value>
        /// The profile.
        /// </value>
        IProfile Profile { get; set; }

        /// <summary>
        /// Gets or sets the training collection.
        /// </summary>
        /// <value>
        /// The training collection.
        /// </value>
        IList<ITraining> TrainingCollection { get; set; }

        /// <summary>
        /// Gets or sets the training request collection.
        /// </summary>
        /// <value>
        /// The training request collection.
        /// </value>
        IList<IEmployeeTrainingModel> TrainingRequestCollection { get; set; }

        /// <summary>
        /// Gets or sets the employee collection.
        /// </summary>
        /// <value>
        /// The employee collection.
        /// </value>
        IList<IEmployee> EmployeeCollection { get; set; }

        /// <summary>
        /// Gets or sets the leave type collection.
        /// </summary>
        /// <value>
        /// The leave type collection.
        /// </value>
        IList<ILeaveRequestModel> LeaveTypeCollection { get; set; }

        /// <summary>
        /// Gets or sets the leave request.
        /// </summary>
        /// <value>
        /// The leave request.
        /// </value>
        ILeaveRequestModel LeaveRequest { get; set; }

        /// <summary>
        /// Gets or sets the query collection.
        /// </summary>
        /// <value>
        /// The query collection.
        /// </value>
        IList<IDiscipline> QueryCollection { get; set; }

        /// <summary>
        /// Gets or sets the department collection.
        /// </summary>
        /// <value>
        /// The department collection.
        /// </value>
        IList<IDepartment> DepartmentCollection { get; set; }

        /// <summary>
        /// Gets or sets the company collection.
        /// </summary>
        /// <value>
        /// The company collection.
        /// </value>
        IList<ICompanyDetail> CompanyCollection { get; set; }

        /// <summary>
        /// Gets or sets the education history.
        /// </summary>
        /// <value>
        /// The education history.
        /// </value>
        IList<IEducationHistory> EducationHistory { get; set; }

        /// <summary>
        /// Gets or sets the employment history.
        /// </summary>
        /// <value>
        /// The employment history.
        /// </value>
        IList<IEmploymentHistory> EmploymentHistory { get; set; }

        /// <summary>
        /// Gets or sets the skill set.
        /// </summary>
        /// <value>
        /// The skill set.
        /// </value>
        IList<ISkillSetModel> SkillSet { get; set; }

        /// <summary>
        /// Gets or sets the profile picture detail.
        /// </summary>
        /// <value>
        /// The profile picture detail.
        /// </value>
        IDigitalFile ProfilePictureDetail { get; set; }

        /// <summary>
        /// Gets or sets the cv document.
        /// </summary>
        /// <value>
        /// The cv document.
        /// </value>
        IDigitalFile CVDocumentDetail { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

        ICompanyDetail Company { get; set; }
    }
}
