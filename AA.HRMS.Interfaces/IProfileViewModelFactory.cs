using System.Collections.Generic;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProfileViewModelFactory
    {
        /// <summary>
        /// Gets the profile view.
        /// </summary>
        /// <param name="profile">The profile.</param>
        /// <param name="genderCollection">The gender collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IProfileView CreateProfileView(IUserDetail userInfo, IList<IYourGender> genderCollection, IList<ICountry> countrycollection, string processingMessage);




        /// <summary>
        /// Creates the profile view.
        /// </summary>
        /// <param name="profileInfo">The profile information.</param>
        /// <param name="genderCollection">The gender collection.</param>
        /// <param name="processingMesage">The processing mesage.</param>
        /// <returns></returns>
        IProfileView CreateProfileView(IProfileView profileInfo, IUserDetail users, IList<IYourGender> genderCollection, IList<ICountry> countrycollection,
            string processingMesage);


        /// <summary>
        /// Edits the profile view.
        /// </summary>
        /// <param name="profileInfo">The profile information.</param>
        /// <param name="genderCollection">The gender collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IProfileView EditProfileView(IProfile profileInfo, IUserDetail userDetail, IList<IYourGender> genderCollection, IList<ICountry> companyCollection, string processingMessage);

        /// <summary>
        /// Edits the update profile view.
        /// </summary>
        /// <param name="profileInfo">The profile information.</param>
        /// <param name="proceesingMessage">The proceesing message.</param>
        /// <returns></returns>
        IProfileView EditUpdateProfileView(IProfileView profileInfo, string proceesingMessage);

    }
}