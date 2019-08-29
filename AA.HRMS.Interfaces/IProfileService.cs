using System.Web;

namespace AA.HRMS.Interfaces
{
   
    public interface IProfileService
    {

        /// <summary>
        /// Gets the profile view.
        /// </summary>
        /// <returns></returns>
        IProfileView GetProfileView();


        /// <summary>
        /// Gets the profile view.
        /// </summary>
        /// <param name="profileInfo">The profile information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IProfileView GetProfileView(IProfileView profileInfo, string processingMessage);

        /// <summary>
        /// Saves the profile information.
        /// </summary>
        /// <param name="profileInfo">The profile information.</param>
        /// <param name="profilePicture">The profile picture.</param>
        /// <param name="profileCV">The profile cv.</param>
        /// <returns></returns>
        string SaveProfileInfo(IProfileView profileInfo, HttpPostedFileBase profilePicture,
            HttpPostedFileBase profileCV);


        /// <summary>
        /// Gets the profile edit view.
        /// </summary>
        /// <returns></returns>
        IProfileView GetProfileEditView();

        /// <summary>
        /// Processes the profile edit view.
        /// </summary>
        /// <param name="profileInfo">The profile information.</param>
        /// <param name="profilePicture">The profile picture.</param>
        /// <param name="profileCV">The profile cv.</param>
        /// <returns></returns>
        string ProcessProfileEditView(IProfileView profileInfo, HttpPostedFileBase profilePicture, HttpPostedFileBase profileCV);
    }
}