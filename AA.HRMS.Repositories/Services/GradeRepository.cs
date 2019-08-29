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
    /// <seealso cref="AA.HRMS.Interfaces.IGradeRepository" />
    public class GradeRepository : IGradeRepository
    {
        /// <summary>
        /// The database context factory
        /// </summary>
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="GradeRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public GradeRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Gets the name of the grade by.
        /// </summary>
        /// <param name="gradeName">Name of the grade.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetUserByCompanyID</exception>
        public IGrade GetGradeByName(string gradeName, int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = GradeQueries.getGradeByName(dbContext, gradeName, companyId);
                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetUserByCompanyID", e);
            }
        }
        
        /// <summary>
        /// Gets the grade by identifier.
        /// </summary>
        /// <param name="gradeId">The grade identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetUserByCompanyID</exception>
        public IGrade GetGradeById(int gradeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = GradeQueries.getGradeById(dbContext, gradeId);
                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetUserByCompanyID", e);
            }
        }

        /// <summary>
        /// Gets the grade list by identifier.
        /// </summary>
        /// <param name="gradeId">The grade identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetUserByCompanyID</exception>
        public IList<IGrade> GetGradeListById(int gradeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = GradeQueries.getGradeListById(dbContext, gradeId).ToList();
                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetUserByCompanyID", e);
            }
        }


        /// <summary>
        /// Saves the grade information.
        /// </summary>
        /// <param name="gradeInfo">The grade information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">gradeInfo</exception>
        public string SaveGradeInfo(IGradeView gradeInfo)
        {
            if (gradeInfo == null) throw new ArgumentNullException(nameof(gradeInfo));

            var result = string.Empty;

            var newRecord = new Grade
            {
                GradeName = gradeInfo.GradeName,
                GradeDescription = gradeInfo.GradeDescription,
                AnnualLeaveDuration = gradeInfo.AnnualLeaveDuration,
                IsActive = true,
                CompanyId = gradeInfo.CompanyId,
                DateCreated = DateTime.UtcNow,
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Grades.Add(newRecord);
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
        /// Updates the grade information.
        /// </summary>
        /// <param name="gradeInfo">The grade information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">gradeInfo</exception>
        public string UpdateGradeInfo(IGradeView gradeInfo)
        {
            if (gradeInfo == null) throw new ArgumentNullException(nameof(gradeInfo));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var gradeData = dbContext.Grades.SingleOrDefault(m => m.GradeId.Equals(gradeInfo.GradeId));

                    gradeData.GradeName = gradeInfo.GradeName;
                    gradeData.GradeDescription = gradeInfo.GradeDescription;
                    gradeData.AnnualLeaveDuration = gradeInfo.AnnualLeaveDuration;
                    gradeData.DateModified = DateTime.UtcNow;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Update Grade - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Deletes the grade information.
        /// </summary>
        /// <param name="gradeInfoId">The grade information identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">gradeInfoId</exception>
        /// <exception cref="ApplicationException">gradeInfoId</exception>
        public string DeleteGradeInfo(int gradeInfoId)
        {
            if (gradeInfoId < 1) throw new ArgumentNullException("gradeInfoId");

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var gradeData = dbContext.Grades.SingleOrDefault(m => m.GradeId.Equals(gradeInfoId));
                    if (gradeData == null)
                    {
                        throw new ApplicationException("gradeInfoId");
                    }

                    gradeData.IsActive = false;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Update Grade - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets the grade by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetUserByCompanyID</exception>
        public IList<IGrade> GetGradeByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = GradeQueries.getGradeByCompanyId(dbContext, companyId).ToList();
                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetUserByCompanyID", e);
            }
        }
    }
}