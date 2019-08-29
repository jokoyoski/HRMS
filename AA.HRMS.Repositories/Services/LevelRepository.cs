using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Models;
using AA.HRMS.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Services
{
    public class LevelRepository : ILevelRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="LevelRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public LevelRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Saves the level information.
        /// </summary>
        /// <param name="levelInfo">The level information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">levelInfo</exception>
        public string SaveLevelInfo(ILevelView levelInfo)
        {
            if (levelInfo == null) throw new ArgumentNullException(nameof(levelInfo));

            var result = string.Empty;

            var newRecord = new Level
            {
                LevelName = levelInfo.LevelName,
                LevelDescription = levelInfo.LevelDescription,
                CompanyId = levelInfo.CompanyId,
                DateCreated = DateTime.UtcNow,
                IsActive = true,
                
            };
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Levels.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Level Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Updates the level information.
        /// </summary>
        /// <param name="levelInfo">The level information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// levelInfo
        /// or
        /// levelData
        /// </exception>
        public string UpdateLevelInfo(ILevelView levelInfo)
        {
            if (levelInfo == null) throw new ArgumentNullException(nameof(levelInfo));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var levelData =
                        dbContext.Levels.SingleOrDefault(m => m.LevelId.Equals(levelInfo.LevelId));
                    if (levelData == null) throw new ArgumentNullException(nameof(levelData));

                    levelData.LevelName = levelInfo.LevelName;
                    levelData.LevelDescription = levelInfo.LevelDescription;
                    levelData.DateModified = DateTime.UtcNow;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Update Level Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets the level by identifier.
        /// </summary>
        /// <param name="levelId">The level identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetLevelById</exception>
        public ILevel GetLevelById(int levelId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var newRecord =
                        LevelQueries.getLevelById(dbContext, levelId);

                    return newRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetLevelById", e);
            }
        }

        /// <summary>
        /// Gets the level list by identifier.
        /// </summary>
        /// <param name="levelId">The level identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetLevelById</exception>
        public IList<ILevel> GetLevelListById(int levelId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var newRecord =
                        LevelQueries.getLevelListById(dbContext, levelId).ToList();

                    return newRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetLevelById", e);
            }
        }
        
        /// <summary>
        /// Deletes the level information.
        /// </summary>
        /// <param name="levelId">The level identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">levelId</exception>
        /// <exception cref="ArgumentNullException">levellId</exception>
        public string DeleteLevelInfo(int levelId)
        {
            if (levelId < 1)

            {
                throw new ArgumentOutOfRangeException("levelId");
            }

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var levelData =
                        dbContext.Levels.SingleOrDefault(m => m.LevelId.Equals(levelId));
                    if (levelData == null) throw new ArgumentNullException("levellId");

                    levelData.IsActive = false;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete Level Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets the level by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Get Level By CompanyId {0}</exception>
        public IList<ILevel> GetLevelByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var newRecord =
                        LevelQueries.getLevelByCompanyId(dbContext, companyId).ToList();

                    return newRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Get Level By CompanyId {0}", e);
            }
        }

        /// <summary>
        /// Gets the level by name company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Get Level By Name and CompanyId {0}</exception>
        public ILevel GetLevelByNameCompanyId(int companyId, string name)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var newRecord =
                        LevelQueries.getLevelByNameCompanyId(dbContext, companyId, name);

                    return newRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Get Level By Name and CompanyId {0}", e);
            }
        }
    }
}
