using System.Linq;
using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Models;

namespace AA.HRMS.Repositories.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public static class ProfileQueries
    {
        /// <summary>
        /// Gets the profileby user identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static IProfile getProfilebyUserId(HRMSEntities db, int userId)
        {
            var result = (from d in db.Profiles
                where d.UserId.Equals(userId)
                join a in db.Countries on d.CountryId equals a.CountryId
                join e in db.Genders on d.GenderId equals e.GenderId
                select new ProfileModel
                {
                    ProfileId = d.ProfileId,
                    UserId = d.UserId,
                    CountryId = d.CountryId,
                    Address = d.Address,
                    DateOfBirth = d.DateOfBirth,
                    Nationality = a.Name,
                    Gender = e.Description, //Gender Description
                    DateCreated = d.DateCreated,
                    ProfileSummary = d.ProfileSummary,
                    StateOfOrigin = d.StateOfOrigin,
                    PictureDigitalFileId = d.PictureDigitalFileId,
                    CVDigitalFileId = d.CVDigitalFileId,
                    GenderId = d.GenderId,
                    
                    
                }).FirstOrDefault();
            return result;
        }
    }
}