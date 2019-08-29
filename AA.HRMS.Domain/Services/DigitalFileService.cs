using System.IO;
using System.Web;
using AA.HRMS.Domain.Extensions;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Domain.Services
{
    public class DigitalFileService : IDigitalFileService
    {

        private readonly IDigitalFileRepository digitalFileRepository;

        
        public DigitalFileService (IDigitalFileRepository digitalFileRepository)
        {
            this.digitalFileRepository = digitalFileRepository;
        }

        /// <summary>
        /// Saves the file.
        /// </summary>
        /// <param name="digitalFileTypeId">The digital file type identifier.</param>
        /// <param name="profilePicture">The profile picture.</param>
        /// <param name="digitalFileId">The digital file identifier.</param>
        /// <returns></returns>
        public string SaveFile(int digitalFileTypeId, HttpPostedFileBase profilePicture, out int digitalFileId)
        {
            digitalFileId = 0;
            var processingMessage = string.Empty;

            if ((profilePicture == null) || (profilePicture.ContentLength < 1))
            {
                return processingMessage;
            }

            byte[] theContent;

            using (Stream inputStream = profilePicture.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                theContent = memoryStream.ToArray();
            }

            var fileName = profilePicture.FileName;
            var contentType = profilePicture.ContentType;
            var fileExtension = fileName.FileExtension();
            
            processingMessage = this.digitalFileRepository.SaveDigitalFile(digitalFileTypeId, fileName, fileExtension, contentType, theContent, out digitalFileId);
           
            return processingMessage;
        }
    }
}
