using System.Collections.Generic;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IUserProfileView" />
    public class UserProfileView : IUserProfileView
    {
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public IUser User { get; set; }

        public IEnumerable<ISpouseModel> spouseModel { get; set; }

        public IEnumerable<IEmergency> emergencyModel { get; set; }
        public IList<INextOfKin> nextOfKinModel { get; set; }
        public IEnumerable<IBeneficiariesModel> beneficiaryModel { get; set; }
        public IEnumerable<IChildrenModel> childrenModel { get; set; }


        /// <summary>
        /// Gets or sets the profile.
        /// </summary>
        /// <value>
        /// The profile.
        /// </value>
        /// 

        //public ISpouseModel Spouse { get; set; }

        public IProfile Profile { get; set; }

        /// <summary>
        /// Gets or sets the education history.
        /// </summary>
        /// <value>
        /// The education history.
        /// </value>
        public IEnumerable<IEducationHistory> EducationHistory { get; set; }

        /// <summary>
        /// Gets or sets the employment history.
        /// </summary>
        /// <value>
        /// The employment history.
        /// </value>
        public IEnumerable<IEmploymentHistory> EmploymentHistory { get; set; }

        /// <summary>
        /// Gets or sets the skill set.
        /// </summary>
        /// <value>
        /// The skill set.
        /// </value>
        public IEnumerable<ISkillSetModel> SkillSet { get; set; }

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
    }
}