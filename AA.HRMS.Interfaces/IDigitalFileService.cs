using System.Web;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDigitalFileService
    {
        /// <summary>
        /// Saves the file.
        /// </summary>
        /// <param name="digitalFileTypeId">The digital file type identifier.</param>
        /// <param name="profilePicture">The profile picture.</param>
        /// <param name="digitalFileId">The digital file identifier.</param>
        /// <returns></returns>
        string SaveFile(int digitalFileTypeId, HttpPostedFileBase profilePicture, out int digitalFileId);
    }
}
