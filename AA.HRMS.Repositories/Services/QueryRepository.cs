using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Services
{
    public class QueryRepository : IQueryRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public QueryRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Gets the Query by identifier.
        /// </summary>
        /// <param name="queryId">The Query identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// QueryId
        /// or
        /// Get Query By Id
        /// </exception>
        public IQuery GetQueryById(int queryId)
        {
            if (queryId <= 0)
            {
                throw new ArgumentNullException(nameof(queryId));
            }

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = QueryQueries.getQueryById(dbContext, queryId);

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Query By Id", e);
            }
        }

        /// <summary>
        /// Gets the name of the Query by.
        /// </summary>
        /// <param name="queryName">Name of the query.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Query By Name</exception>
        public IQuery GetQueryByName(string queryName)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var queryInfo = QueryQueries.getQueryByName(dbContext, queryName);
                    return queryInfo;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Query By Name", e);
            }
        }

        /// <summary>
        /// Saves the query information.
        /// </summary>
        /// <param name="queryInfo">The query information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">queryInfo</exception>
        public string SaveQueryInfo(IQueryView queryInfo)
        {
            if (queryInfo == null)
            {
                throw new ArgumentNullException(nameof(queryInfo));
            }

            var result = string.Empty;

            var newRecord = new Query
            {
                QueryName = queryInfo.QueryName,
                Consequences = queryInfo.Consequences,
                CompanyId = queryInfo.CompanyId,
                IsActive = true,
                DateCreated = DateTime.Now


            };

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Queries.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Query info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Saves the edit query information.
        /// </summary>
        /// <param name="queryInfo">The query information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">queryInfo</exception>
        public string SaveEditQueryInfo(IQueryView queryInfo)
        {
            if (queryInfo == null)
            {
                throw new ArgumentNullException(nameof(queryInfo));
            }

            string result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var modelInfo = dbContext.Queries.SingleOrDefault(p => p.QueryId == queryInfo.QueryId);

                    modelInfo.QueryId = queryInfo.QueryId;
                    modelInfo.QueryName = queryInfo.QueryName;
                    modelInfo.CompanyId = queryInfo.CompanyId;
                    modelInfo.Consequences = queryInfo.Consequences;
                    modelInfo.IsActive = queryInfo.IsActive;
                    modelInfo.DateCreated = DateTime.Now;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Edit Query info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Saves the delete query information.
        /// </summary>
        /// <param name="queryId">The query identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">queryId</exception>
        public string SaveDeleteQueryInfo(int queryId)
        {
            if (queryId <= 0)
            {
                throw new ArgumentNullException(nameof(queryId));
            }

            string result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var modelView = dbContext.Queries.Find(queryId);


                   

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Delete Query info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        /// <summary>
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAllMyQueries</exception>
        public IList<IQuery> GetAllMyQueries(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = QueryQueries.getAllMyQueries(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAllMyQueries", e);
            }
        }
    }
}
