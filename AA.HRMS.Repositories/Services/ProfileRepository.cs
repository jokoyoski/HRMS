using System;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Factories;
using AA.HRMS.Repositories.Queries;

namespace AA.HRMS.Repositories.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IProfileRepository" />
    public class ProfileRepository : IProfileRepository
    {
        /// <summary>
        /// The database context factory
        /// </summary>
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileRepository" /> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public ProfileRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory ?? new DbContextFactory(null);
        }


        /// <summary>
        /// Gets the profile by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetProfileByUserid</exception>
        /// <exception cref="ArgumentOutOfRangeException">userId</exception>
        public IProfile GetProfileByUserId(int userId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = ProfileQueries.getProfilebyUserId(dbContext, userId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetProfileByUserid", e);
            }
        }


        /// <summary>
        /// Stores the profile information.
        /// </summary>
        /// <param name="profileInfo">The profile information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">profileInfo</exception>
        public string StoreProfileInfo(IProfileView profileInfo)
        {
            if (profileInfo == null) throw new ArgumentNullException(nameof(profileInfo));

            var result = string.Empty;
            var newProfile = new Profile
            {
                UserId = profileInfo.UserId,
                ProfileSummary = profileInfo.ProfileSummary,
                Address = profileInfo.Address,
                DateOfBirth = profileInfo.DateOfBirth,
                GenderId = profileInfo.GenderId,
                Nationality = profileInfo.Nationality,
                StateOfOrigin = profileInfo.StateOfOrigin,
                DateCreated = DateTime.Now,
                PictureDigitalFileId = profileInfo.PictureDigitalFileId,
                CVDigitalFileId = profileInfo.CVDigitalFileId,
                CountryId = profileInfo.CountryId
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Profiles.Add(newProfile);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("StoreProfileInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Stores the profile information.
        /// </summary>
        /// <param name="profileInfo">The profile information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">profileInfo</exception>
        public string UpdateProfileInfo(IProfileView profileInfo)
        {
            if (profileInfo == null) throw new ArgumentNullException(nameof(profileInfo));


            //Get Profile From Database to Perform Update

            var result = string.Empty;
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var userProfile = dbContext.Profiles.Find(profileInfo.ProfileId);

                    userProfile.ProfileSummary = profileInfo.ProfileSummary;
                    userProfile.Address = profileInfo.Address;
                    userProfile.CountryId = profileInfo.CountryId;
                    userProfile.DateOfBirth = profileInfo.DateOfBirth;
                    userProfile.GenderId = profileInfo.GenderId;
                    userProfile.Nationality = profileInfo.Nationality;
                    userProfile.StateOfOrigin = profileInfo.StateOfOrigin;

                    if (profileInfo.PictureDigitalFileId > 0)
                    {
                        userProfile.PictureDigitalFileId = profileInfo.PictureDigitalFileId;
                    }

                    if (profileInfo.CVDigitalFileId > 0)
                    {
                        userProfile.CVDigitalFileId = profileInfo.CVDigitalFileId;
                    }

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Update Profile Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
    }
}