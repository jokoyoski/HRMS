using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Queries;

namespace AA.HRMS.Repositories.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IEducationHistoryRepository" />
    public class EducationHistoryRepository : IEducationHistoryRepository
    {
        /// <summary>
        /// The database context factory
        /// </summary>
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="EducationHistoryRepository" /> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public EducationHistoryRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Gets the education history by identifier.
        /// </summary>
        /// <param name="educationHistoryId">The education history identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository Get Education History By Id</exception>
        /// <exception cref="System.ApplicationException">Repository Get Education History By Id</exception>
        public IEducationHistory GetEducationHistoryById(int educationHistoryId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = EducationHistoryQueries.GetEducationHistoryById(dbContext, educationHistoryId);
                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get Education History By Id",e);
            }
        }

        /// <summary>
        /// Gets the education history by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository Get Education History By User Id</exception>
        /// <exception cref="System.ApplicationException">Repository Get Education History By User Id</exception>
        public IList<IEducationHistory> GetEducationHistoriesByUserId(int userId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = EducationHistoryQueries.GetEducationHistoryByUserId(dbContext, userId).ToList();
                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get Education History By User Id", e);
            }
        }

        /// <summary>
        /// Saves the education history information.
        /// </summary>
        /// <param name="educationHistoryInfo">The education history information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">educationHistoryInfo</exception>
        /// <exception cref="System.ArgumentNullException">educationHistoryInfo</exception>
        public string SaveEducationHistoryInfo(IEducationHistoryView educationHistoryInfo)
        {
            if (educationHistoryInfo == null) throw new ArgumentNullException(nameof(educationHistoryInfo));

            var result = string.Empty;

            var newRecord = new EducationHistory
            {
                //note dont include primary key here

                EmployeeId = educationHistoryInfo.EmployeeId,
                SchoolName = educationHistoryInfo.SchoolName,
                Degree = educationHistoryInfo.Degree,
                GraduationYear = educationHistoryInfo.GraduationYear,
                Note = educationHistoryInfo.Note,
                IsActive = true,
                DateCreated = DateTime.UtcNow,
            };
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.EducationHistories.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveRegistrationInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Updates the education history information.
        /// </summary>
        /// <param name="educationHistoryInfo">The education history information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">educationHistoryInfo</exception>
        /// <exception cref="System.ArgumentNullException">educationHistoryInfo</exception>
        public string UpdateEducationHistoryInfo(IEducationHistoryView educationHistoryInfo)
        {
            if(educationHistoryInfo == null)
            {
                throw new ArgumentNullException(nameof(educationHistoryInfo));
            }

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var data = dbContext.EducationHistories.Find(educationHistoryInfo.EducationHistoryId);

                    data.SchoolName = educationHistoryInfo.SchoolName;
                    data.Degree = educationHistoryInfo.Degree;
                    data.GraduationYear = educationHistoryInfo.GraduationYear;
                    data.Note = educationHistoryInfo.Note;

                    dbContext.SaveChanges();
                }
            }
            catch(Exception e)
            {
                result = string.Format("Update Educational - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Deletes the education history information.
        /// </summary>
        /// <param name="educationHistoryId">The education history identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">educationHistoryId</exception>
        /// <exception cref="System.ArgumentNullException">educationHistoryInfo</exception>
        public string DeleteEducationHistoryInfo(int educationHistoryId)
        {
            if (educationHistoryId <= 0)
            {
                throw new ArgumentNullException(nameof(educationHistoryId));
            }

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var data = dbContext.EducationHistories.SingleOrDefault(a => a.EducationHistoryId == educationHistoryId);

                    data.IsActive = false;

                    dbContext.SaveChanges();
                }
            }
            catch(Exception e)
            {
                result = string.Format("Educatonal History - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
    }
}