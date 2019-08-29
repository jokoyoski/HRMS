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
    public class BenefitQueries
    {

        /// <summary>
        /// Gets the name of the benefit by.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="benefitName">Name of the benefit.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IBenefit getBenefitByName(HRMSEntities db, string benefitName, int companyId)
        {
            var result = (from a in db.Benefits
                          where a.BenefitName.Equals(benefitName) && a.CompanyId.Equals(companyId) && a.IsActive.Equals(true)
                          select new BenefitModel {
                              BenefitId = a.BenefitId,
                              BenefitName = a.BenefitName,
                              BenefitDescription = a.BenefitDescription,
                              IsActive = a.IsActive,
                              IsMonetized = a.IsMonetized,
                              IsTaxable = a.IsTaxable,
                              CompanyId = a.CompanyId,
                              DateCreated = a.DateCreated,
                              DateModified = a.DateModified,
                              Period = a.Period
                          }).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Gets the benefit by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="benefitId">The benefit identifier.</param>
        /// <returns></returns>
        internal static IBenefit getBenefitById(HRMSEntities db, int benefitId)
        {
            var result = (from a in db.Benefits
                          where a.BenefitId.Equals(benefitId) && a.IsActive.Equals(true)
                          select new BenefitModel
                          {
                              BenefitId = a.BenefitId,
                              BenefitName = a.BenefitName,
                              BenefitDescription = a.BenefitDescription,
                              IsActive = a.IsActive,
                              IsMonetized = a.IsMonetized,
                              IsTaxable = a.IsTaxable,
                              CompanyId = a.CompanyId,
                              DateCreated = a.DateCreated,
                              DateModified = a.DateModified,
                              Period = a.Period
                          }).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Gets the benefit by company identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IBenefit> getBenefitByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from a in db.Benefits
                          where a.CompanyId.Equals(companyId) && a.IsActive.Equals(true)
                          select new BenefitModel
                          {
                              BenefitId = a.BenefitId,
                              BenefitName = a.BenefitName,
                              BenefitDescription = a.BenefitDescription,
                              IsActive = a.IsActive,
                              IsMonetized = a.IsMonetized,
                              IsTaxable = a.IsTaxable,
                              CompanyId = a.CompanyId,
                              DateCreated = a.DateCreated,
                              DateModified = a.DateModified,
                              Period = a.Period
                          }).OrderBy(p=>p.BenefitName);

            return result;
        }
    }
}
