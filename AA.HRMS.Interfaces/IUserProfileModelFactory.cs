using System.Collections.Generic;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserProfileModelFactory
    {
        /// <summary>
        /// Creates the user profile view.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="profile">The profile.</param>
        /// <param name="educationHistory">The education history.</param>
        /// <param name="employmentHistory">The employment history.</param>
        /// <param name="SkillSet">The skill set.</param>
        /// <param name="profilePictureDetail">The profile picture detail.</param>
        /// <param name="applicantCVDetails">The applicant cv details.</param>
        /// <returns></returns>
        IUserProfileView CreateUserProfileView(IUser user, IProfile profile,
            IList<IEducationHistory> educationHistory,
            IList<IEmploymentHistory> employmentHistory, IList<ISpouseModel> spouseModel, IList<ISkillSetModel> skillSets,
            IDigitalFile profilePictureDetail, IDigitalFile applicantCVDetails, IList<IEmergency> emergency, IList<IChildrenModel> childrenModel, IList<IBeneficiariesModel> beneficiariesModel, IList<INextOfKin> nextOfKin, string processingMessage);
        }
}