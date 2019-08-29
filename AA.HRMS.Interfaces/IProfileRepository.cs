namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProfileRepository
    {

        /// <summary>
        /// Gets the profile by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IProfile GetProfileByUserId(int userId);


        /// <summary>
        /// Stores the profile information.
        /// </summary>
        /// <param name="profileInfo">The profile information.</param>
        /// <returns></returns>
        string StoreProfileInfo(IProfileView profileInfo);


        /// <summary>
        /// Updates the profile information.
        /// </summary>
        /// <param name="profileInfo">The profile information.</param>
        /// <returns></returns>
        string UpdateProfileInfo(IProfileView profileInfo);
    }
}