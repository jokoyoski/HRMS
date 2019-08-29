namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDigitalFileRepository
    {

        /// <summary>
        /// Saves the digital file.
        /// </summary>
        /// <param name="digitalFileTypeId">The digital file type identifier.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="fileExtension">The file extension.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <param name="theContent">The content.</param>
        /// <param name="digitalFileId">The digital file identifier.</param>
        /// <returns></returns>
        string SaveDigitalFile(int digitalFileTypeId, string fileName, string fileExtension, string contentType, byte[] theContent, out int digitalFileId);

        /// <summary>
        /// Gets the digital file detail.
        /// </summary>
        /// <param name="digitalFileId">The digital file identifier.</param>
        /// <returns></returns>
        IDigitalFile GetDigitalFileDetail(int digitalFileId);
    }
}
