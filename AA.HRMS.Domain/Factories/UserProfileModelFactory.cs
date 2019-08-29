using System;
using System.Collections.Generic;
using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Domain.Factories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IUserProfileModelFactory" />
    public class UserProfileModelFactory : IUserProfileModelFactory
    {
        /// <summary>
        /// Creates the user profile view.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="profile">The profile.</param>
        /// <param name="educationHistory">The education history.</param>
        /// <param name="employmentHistory">The employment history.</param>
        /// <param name="skillSets">The skill sets.</param>
        /// <param name="profilePictureDetail">The profile picture detail.</param>
        /// <param name="applicantCVDetails">The applicant cv details.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IUserProfileView CreateUserProfileView(IUser user, IProfile profile,
            IList<IEducationHistory> educationHistory,
            IList<IEmploymentHistory> employmentHistory,IList<ISpouseModel> spouseModel, IList<ISkillSetModel> skillSets,
            IDigitalFile profilePictureDetail, IDigitalFile applicantCVDetails,IList<IEmergency> emergency,
            IList<IChildrenModel> childrenModel, IList<IBeneficiariesModel> beneficiariesModel, 
            IList<INextOfKin> nextOfKin, string processingMessage)
        {
            var viewModel = new UserProfileView
            {
                User = user,
                Profile = profile,
                EducationHistory = educationHistory,
                EmploymentHistory = employmentHistory,
                SkillSet = skillSets,
                spouseModel = spouseModel,
                nextOfKinModel= nextOfKin,
                childrenModel = childrenModel,
                beneficiaryModel = beneficiariesModel,
                emergencyModel = emergency,
                ProfilePictureDetail = profilePictureDetail,
                CVDocumentDetail = applicantCVDetails,
                ProcessingMessage = processingMessage,
            };

            return viewModel;
        }
    }
}