using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IEmployeeProfileView" />
    public class EmployeeProfileView : IEmployeeProfileView
    {
        public EmployeeProfileView()
        {
            LevelCollection = new List<ILevel>();
            GradeCollection = new List<IGrade>();
            TrainingCollection = new List<ITraining>();

            JobTitle = new List<IJobTitle>();

            TrainingRequestCollection = new List<IEmployeeTrainingModel>();

            LeaveTypeCollection = new List<ILeaveRequestModel>();
            DepartmentCollection = new List<IDepartment>();

            QueryCollection = new List<IDiscipline>();

            CompanyCollection = new List<ICompanyDetail>();
            EducationHistory = new List<IEducationHistory>();
            EmploymentHistory = new List<IEmploymentHistory>();
            SkillSet = new List<ISkillSetModel>();
            EmployeeCollection = new List<IEmployee>();
            DepartmentCollection = new List<IDepartment>();
            QueryCollection = new List<IDiscipline>();

            emergencyModel = new List<IEmergency>();
            spouseModel = new List<ISpouseModel>();
            nextOfKinModel = new List<INextOfKin>();
            beneficiaryModel = new List<IBeneficiariesModel>();
            childrenModel = new List<IChildrenModel>();

            CompanyDropDown = new List<SelectListItem>();
        }

        public IEnumerable<ISpouseModel> spouseModel { get; set; }

        public IEnumerable<IEmergency> emergencyModel { get; set; }
        public IList<INextOfKin> nextOfKinModel { get; set; }
        public IEnumerable<IBeneficiariesModel> beneficiaryModel { get; set; }
        public IEnumerable<IChildrenModel> childrenModel { get; set; }

        public IEmployee Employee { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public IUserDetail User { get; set; }

        /// <summary>
        /// Gets or sets the level collection.
        /// </summary>
        /// <value>
        /// The level collection.
        /// </value>
        public IList<ILevel> LevelCollection { get; set; }

        public IList<ILeaveRequestModel> PendingLeaveRquest { get; set; }

        public IList<IEmployeeTrainingModel> PendingTrainingRequest { get; set; }

        public IList<IEmployeeLoan> PendingLoanRequest { get; set; }

        /// <summary>
        /// Gets or sets the grade collection.
        /// </summary>
        /// <value>
        /// The grade collection.
        /// </value>
        public IList<IGrade> GradeCollection { get; set; }

        /// <summary>
        /// Gets or sets the job title.
        /// </summary>
        /// <value>
        /// The job title.
        /// </value>
        public IList<IJobTitle> JobTitle { get; set; }

        /// <summary>
        /// Gets or sets the training collection.
        /// </summary>
        /// <value>
        /// The training collection.
        /// </value>
        public IList<ITraining> TrainingCollection { get; set; }


        public IList<SelectListItem> CompanyDropDown { get; set; }

        /// <summary>
        /// Gets or sets the training request collection.
        /// </summary>
        /// <value>
        /// The training request collection.
        /// </value>
        public IList<IEmployeeTrainingModel> TrainingRequestCollection { get; set; }

        /// <summary>
        /// Gets or sets the employee training.
        /// </summary>
        /// <value>
        /// The employee training.
        /// </value>
        public IEmployeeTrainingModel EmployeeTraining { get; set; }


        /// <summary>
        /// Gets or sets the leave type collection.
        /// </summary>
        /// <value>
        /// The leave type collection.
        /// </value>
        public IList<ILeaveRequestModel> LeaveTypeCollection { get; set; }

        /// <summary>
        /// Gets or sets the leave request.
        /// </summary>
        /// <value>
        /// The leave request.
        /// </value>
        public ILeaveRequestModel LeaveRequest { get; set; }


        /// <summary>
        /// Gets or sets the query collection.
        /// </summary>
        /// <value>
        /// The query collection.
        /// </value>
        public IList<IDiscipline> QueryCollection { get; set; }

        /// <summary>
        /// Gets or sets the department collection.
        /// </summary>
        /// <value>
        /// The department collection.
        /// </value>
        public IList<IDepartment> DepartmentCollection { get; set; }

        /// <summary>
        /// Gets or sets the company collection.
        /// </summary>
        /// <value>
        /// The company collection.
        /// </value>
        public IList<ICompanyDetail> CompanyCollection { get; set; }

        /// <summary>
        /// Gets or sets the profile.
        /// </summary>
        /// <value>
        /// The profile.
        /// </value>
        public IProfile Profile { get; set; }

        /// <summary>
        /// Gets or sets the education history.
        /// </summary>
        /// <value>
        /// The education history.
        /// </value>
        public IList<IEducationHistory> EducationHistory { get; set; }

        /// <summary>
        /// Gets or sets the employment history.
        /// </summary>
        /// <value>
        /// The employment history.
        /// </value>
        public IList<IEmploymentHistory> EmploymentHistory { get; set; }

        /// <summary>
        /// Gets or sets the skill set.
        /// </summary>
        /// <value>
        /// The skill set.
        /// </value>
        public IList<ISkillSetModel> SkillSet { get; set; }

        /// <summary>
        /// Gets or sets the profile picture detail.
        /// </summary>
        /// <value>
        /// The profile picture detail.
        /// </value>
        public IDigitalFile ProfilePictureDetail { get; set; }


        /// <summary>
        /// Gets or sets the cv document.
        /// </summary>
        /// <value>
        /// The cv document.
        /// </value>
        public IDigitalFile CVDocumentDetail { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }


        /// <summary>
        /// Gets or sets the employee collection.
        /// </summary>
        /// <value>
        /// The employee collection.
        /// </value>
        public IList<IEmployee> EmployeeCollection { get; set; }

        public ICompanyDetail Company { get; set; }
    }
}