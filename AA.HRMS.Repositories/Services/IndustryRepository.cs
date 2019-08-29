using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Factories;
using AA.HRMS.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Services
{
    public class IndustryRepository : IIndustryRepository
    {

        /// <summary>
        /// The database context factory
        /// </summary>
        private readonly IDbContextFactory dbContextFactory;



        /// <summary>
        /// Initializes a new instance of the <see cref="IndustryRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public IndustryRepository (IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory ?? new DbContextFactory(null);
        }





        /// <summary>
        /// Saves the industry information.
        /// </summary>
        /// <param name="industryInfo">The industry information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">industryInfo</exception>
        public string SaveIndustryInfo(IIndustryView industryInfo)
        {
            if (industryInfo == null)
                throw new ArgumentNullException(nameof(industryInfo));

            var result = string.Empty;

            var newRecord = new Industry
            {
                IndustryName = industryInfo.IndustryName,
                IsActive = true,
                DateCreated = DateTime.UtcNow
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Industries.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }

            catch (Exception e)
            {
                result = string.Format("SaveIndustryInfo - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Gets the industry by identifier.
        /// </summary>
        /// <param name="industryId">The industry identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetIndustryById</exception>
        public IIndustry GetIndustryById(int industryId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = IndustryQueries.getIndustryById(dbContext, industryId);
                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetIndustryById", e);
            }
        }



        /// <summary>
        /// Gets the industry by identifier.
        /// </summary>
        /// <param name="industryId">The industry identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetIndustryById</exception>
        public IIndustry GetIndustryByName(string industryName)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = IndustryQueries.getIndustryByName(dbContext, industryName);
                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetIndustryByName", e);
            }
        }



        /// <summary>
        /// Updates the industry information.
        /// </summary>
        /// <param name="IndustryInfo">The industry information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">IndustryInfo</exception>
        public string UpdateIndustryInfo(IIndustryView IndustryInfo)
        {
            if (IndustryInfo == null)
                throw new ArgumentNullException(nameof(IndustryInfo));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var data = dbContext.Industries.SingleOrDefault(a => a.IndustryId.Equals(IndustryInfo.IndustryId));

                    data.IndustryId = IndustryInfo.IndustryId;
                    data.IndustryName = IndustryInfo.IndustryName;
                   
                    data.DateCreated = IndustryInfo.DateCreated;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveIndustryInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Gets all industry.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository Get All Industry</exception>
        public IList<IIndustry> GetAllIndustry()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = IndustryQueries.getAllIndustry(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get All Industry", e);
            }
        }



        /// <summary>
        /// Deletes the industry information.
        /// </summary>
        /// <param name="industryId">The industry identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">industryId</exception>
        /// <exception cref="ApplicationException">industryId</exception>
        public string DeleteIndustryInfo(int industryId)
        {
            if (industryId < 1)
            {
                throw new ArgumentOutOfRangeException("industryId");
            }

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var industryData = dbContext.Industries.SingleOrDefault(m => m.IndustryId.Equals(industryId));

                    if (industryData == null)
                    {
                        throw new ApplicationException("industryId");
                    }

                    industryData.IsActive = false;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete Industry Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

    }
}
