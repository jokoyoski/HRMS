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
    public class TaxRepository : ITaxRepository
    {
        /// <summary>
        /// The database context factory
        /// </summary>
        private readonly IDbContextFactory dbContextFactory;

        public TaxRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        /// <summary>
        /// Gets the tax by company identifier.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Tax By CompanyId {0}</exception>
        public IList<ITax> GetAllTax()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = taxQueries.getTaxByCompanyId(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Tax By CompanyId {0}", e);
            }
        }
    }
}
