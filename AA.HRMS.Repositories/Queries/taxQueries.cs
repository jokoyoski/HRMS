using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Queries
{
    internal static class taxQueries
    {
        /// <summary>
        /// Gets the tax by company identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<ITax> getTaxByCompanyId(HRMSEntities db)
        {
            var result = (from a in db.Taxes
                          select new Models.TaxModel
                          {
                              TaxId = a.TaxId,
                              TaxRate = a.TaxRate,
                              AnnualIncome = a.AnnualIncome
                          }
                          ).OrderBy(p=>p.AnnualIncome);

            return result;

        }
    }
}
