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
    /// <seealso cref="AA.HRMS.Interfaces.ISkillSetRepository" />
    public class SkillSetRepository : ISkillSetRepository
    {
        /// <summary>
        /// The database context factory
        /// </summary>
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkillSetRepository" /> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public SkillSetRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Gets the skill set by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetSkillSetByUserId</exception>
        public IList<ISkillSetModel> GetSkillSetByUserId(int userId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = SkillSetQueries.getSkillSetByUserId(dbContext, userId).ToList();
                    return aRecord;
                }
            }
            catch(Exception e)
            {
                throw new ApplicationException("Repository GetSkillSetByUserId", e);
            }
        }

        /// <summary>
        /// Gets the skill set by identifier.
        /// </summary>
        /// <param name="skillSetId">The skill set identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetSkillSetById</exception>
        public ISkillSetModel GetSkillSetById(int skillSetId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = SkillSetQueries.getSkillSetById(dbContext, skillSetId);
                    return aRecord;
                }
            }
            catch(Exception e)
            {
                throw new ApplicationException("Repository GetSkillSetById", e);
            }
        }

        /// <summary>
        /// Saves the skill set information.
        /// </summary>
        /// <param name="skillSetInfo">The skill set information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">skillSetInfo</exception>
        public string SaveSkillSetInfo(ISkillSetModelView skillSetInfo)
        {
            if(skillSetInfo == null)
                throw new ArgumentNullException(nameof(skillSetInfo));

            var result = string.Empty;

            var newRecord = new SkillSet
            {
                SkillName = skillSetInfo.SkillName,
                SkillDescription = skillSetInfo.SkillDescription,
                EmployeeId = skillSetInfo.EmployeeId,
                ExperienceId = skillSetInfo.Experience,
                IsActive = true,
                DateCreated = DateTime.UtcNow
            };
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.SkillSets.Add(newRecord);
                    dbContext.SaveChanges();
                }   
            }
            catch(Exception e)
            {
                result = string.Format("SaveSkillSetInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Updates the skill set information.
        /// </summary>
        /// <param name="skillSetInfo">The skill set information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">skillSetInfo</exception>
        public string UpdateSkillSetInfo(ISkillSetModelView skillSetInfo)
        {
            if (skillSetInfo == null)
                throw new ArgumentNullException(nameof(skillSetInfo));

            var result = string.Empty;

            
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var data = dbContext.SkillSets.Find(skillSetInfo.SkillId);

                    data.SkillName = skillSetInfo.SkillName;
                    data.SkillDescription = skillSetInfo.SkillDescription;
                    data.ExperienceId = skillSetInfo.Experience;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveSkillSetInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Deletes the skill set information.
        /// </summary>
        /// <param name="skillSetId">The skill set identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">skillSetInfo</exception>
        /// <exception cref="ApplicationException">skillSetId</exception>
        public string DeleteSkillSetInfo(int skillSetId)
        {
            if (skillSetId < 1)
                throw new ArgumentNullException("skillSetId");

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var data = dbContext.SkillSets.SingleOrDefault(m => m.SkillId.Equals(skillSetId));
                    if (data == null)
                    {
                        throw new ApplicationException("skillSetId");
                    }
                    data.IsActive = false;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete SkillSet Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.InnerException.Message : "");
            }

            return result;
        }
    }
}
