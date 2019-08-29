using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Queries
{
    internal static class QueryQueries
    {
        /// <summary>
        /// Gets the query by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="queryId">The query identifier.</param>
        /// <returns></returns>
        internal static IQuery getQueryById(HRMSEntities db, int queryId)
        {
            var result = (from s in db.Queries
                          where s.QueryId.Equals(queryId)
                          select new Models.QueryModel
                          {
                              QueryId = s.QueryId,
                              QueryName = s.QueryName,
                              CompanyId = s.CompanyId,
                              Consequences = s.Consequences

                          }).FirstOrDefault();

            return result;
        }


        /// <summary>
        /// Gets the name of the query by.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="queryName">Name of the query.</param>
        /// <returns></returns>
        internal static IQuery getQueryByName(HRMSEntities db, string queryName)
        {
            var result = (from a in db.Queries
                          where a.QueryName.Equals(queryName)
                          select new Models.QueryModel
                          {
                              QueryId = a.QueryId,
                              QueryName = a.QueryName,
                              CompanyId = a.CompanyId,
                              IsActive = a.IsActive,
                              DateCreated = a.DateCreated,
                              Consequences = a.Consequences

                          }).FirstOrDefault();
            return result;
        }
        /// <summary>
        /// Gets all my queries.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IQuery> getAllMyQueries(HRMSEntities db, int companyId)
        {
            var result = (from d in db.Queries
                          where d.CompanyId == companyId
                          join e in db.Companies on d.CompanyId equals e.CompanyId
                          join pdept in db.Queries on d.QueryId equals pdept.QueryId into gj
                          from f in gj.DefaultIfEmpty()
                          select new QueryModel
                          {
                              QueryId = d.QueryId,
                              QueryName = d.QueryName,
                              CompanyId = e.CompanyId,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              Consequences = f.Consequences
                          }).OrderBy(p => p.QueryName);

            return result;
        }
    }

}
