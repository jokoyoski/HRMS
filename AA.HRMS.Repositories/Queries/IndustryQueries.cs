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
    public class IndustryQueries
    {
        /// <summary>
        /// Gets the industry by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="industryId">The industry identifier.</param>
        /// <returns></returns>
        internal static IIndustry getIndustryById(HRMSEntities db, int industryId)
        {
            var result = (from d in db.Industries
                where d.IndustryId.Equals(industryId)
                select new IndustryModel
                {
                    IndustryId = d.IndustryId,
                    IndustryName = d.IndustryName,
                    IsActive = d.IsActive,
                    DateCreated = d.DateCreated,
                }).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets the name of the industry by.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="industryName">Name of the industry.</param>
        /// <returns></returns>
        internal static IIndustry getIndustryByName(HRMSEntities db, string industryName)
        {
            var result = (from d in db.Industries
                where d.IndustryName.Equals(industryName)
                select new IndustryModel
                {
                    IndustryId = d.IndustryId,
                    IndustryName = d.IndustryName,
                    IsActive = d.IsActive,
                    DateCreated = d.DateCreated,
                }).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Gets all industry.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IIndustry> getAllIndustry(HRMSEntities db)
        {
            var result = (from d in db.Industries
                select new IndustryModel
                {
                    IndustryId = d.IndustryId,
                    IsActive = d.IsActive,
                    IndustryName = d.IndustryName,
                    DateCreated = d.DateCreated,
                }).OrderBy(x => x.IndustryName);

            return result;
        }
    }
}