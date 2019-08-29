using System.Linq;
using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Models;

namespace AA.HRMS.Repositories.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public static class DigitalFileQueries
    {
        /// <summary>
        /// Gets the profileby user identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="digitalFileId">The digital file identifier.</param>
        /// <returns></returns>
        internal static IDigitalFile getDigitalFileDetail(HRMSEntities db, int digitalFileId)
        {
            var result = (from d in db.DigitalFiles
                where d.DigitalFileId.Equals(digitalFileId) && d.IsActive.Equals(true)
                select new DigitalFileModel
                {
                    DateCreated = d.DateCreated,
                    DigitalFileId = d.DigitalFileId,
                    DigitalTypeId = d.DigitalTypeId,
                    TheDigitalFile=d.TheDigitalFile,
                    IsActive = d.IsActive,
                    FileExtension = d.FileExtension,
                    FileName=d.FileName,
                    ContentType = d.ContentType
                    
                }).FirstOrDefault();
            return result;
        }
    }
}