using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Factories;
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
    /// <seealso cref="AA.HRMS.Interfaces.IFrequencyOfDeliveryRepository" />
    public class FrequencyOfDeliveryRepository : IFrequencyOfDeliveryRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        public FrequencyOfDeliveryRepository (IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory ?? new DbContextFactory(null);
        }


        /// <summary>
        /// Gets the frequency of delivery.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">GetEmployeeTraining {0}</exception>
        public IList<IFrequencyOfDeliveryModel> GetFrequencyOfDelivery(int Id)

        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var training =
                        FrequencyOfDeliveryQueries.GetFrequencyOfDeliveryById(dbContext, Id).ToList();

                    return training;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("GetEmployeeTraining {0}", e);
            }
        }
    }
}
