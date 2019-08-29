using System.Collections.Generic;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserProfileView
    {
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        IUser User { get; set; }

        IEnumerable<ISpouseModel> spouseModel { get; set; }

        IEnumerable<IEmergency> emergencyModel { get; set; }
        IList<INextOfKin> nextOfKinModel { get; set; }
        IEnumerable<IBeneficiariesModel> beneficiaryModel { get; set; }
        IEnumerable<IChildrenModel> childrenModel { get; set; }
        //ISpouseModel Spouse { get; set; }

        /// <summary>
        /// Gets or sets the profile.
        /// </summary>
        /// <value>
        /// The profile.
        /// </value>
        IProfile Profile { get; set; }


        /// <summary>
        /// Gets or sets the education history.
        /// </summary>
        /// <value>
        /// The education history.
        /// </value>
        IEnumerable<IEducationHistory> EducationHistory { get; set; }

        /// <summary>
        /// Gets or sets the employment history.
        /// </summary>
        /// <value>
        /// The employment history.
        /// </value>
        IEnumerable<IEmploymentHistory> EmploymentHistory { get; set; }

        /// <summary>
        /// Gets or sets the skill set.
        /// </summary>
        /// <value>
        /// The skill set.
        /// </value>
        IEnumerable<ISkillSetModel> SkillSet { get; set; }

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
    }
}