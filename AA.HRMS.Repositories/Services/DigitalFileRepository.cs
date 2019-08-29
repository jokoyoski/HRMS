using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IDigitalFileRepository" />
    public class DigitalFileRepository : IDigitalFileRepository
    {
        /// <summary>
        /// The database context factory
        /// </summary>
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DigitalFileRepository" /> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public DigitalFileRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Gets the digital file detail.
        /// </summary>
        /// <param name="digitalFileId">The digital file identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetDigitalFileDetail</exception>
        public IDigitalFile GetDigitalFileDetail(int digitalFileId)
        {
            if(digitalFileId == 0)
            {
                return null; 
            }

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = DigitalFileQueries.getDigitalFileDetail(dbContext, digitalFileId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetDigitalFileDetail", e);
            }
        }


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
        /// <exception cref="ArgumentNullException">
        /// fileName
        /// or
        /// contentType
        /// or
        /// theContent
        /// </exception>
        public string SaveDigitalFile(int digitalFileTypeId, string fileName, string fileExtension, string contentType, byte[] theContent, out int digitalFileId)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (string.IsNullOrEmpty(contentType))
            {
                throw new ArgumentNullException(nameof(contentType));
            }

            if (theContent == null)
            {
                throw new ArgumentNullException(nameof(theContent));
            }

            var result = string.Empty;
            digitalFileId = 0;

            var newRecord = new DigitalFile
            {
                TheDigitalFile = theContent,
                FileExtension = fileExtension,
                FileName = fileName,
                ContentType = contentType,
                DigitalTypeId = digitalFileTypeId,
                IsActive = true,
                DateCreated = DateTime.Now
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.DigitalFiles.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveDigitalFile - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            digitalFileId = newRecord.DigitalFileId;
            return result;
        }
    }
}
