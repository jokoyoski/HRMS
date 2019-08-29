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
   public class FrequencyOfDeliveryQueries
    {
        /// <summary>
        /// Gets the frequency of delivery by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IFrequencyOfDeliveryModel> GetFrequencyOfDeliveryById(HRMSEntities db, int id)
        {
            var result = (from d in db.FrequencyOfDeliveries
                          where d.FrequencyOfDeliveryId.Equals(id)
                          select new FrequencyOfDeliveryModel
                          {
                             FrequencyOfDeliveryId = d.FrequencyOfDeliveryId,
                             FrequencyOfDelivery1 = d.FrequencyOfDelivery1
                          }).OrderBy(p => p.FrequencyOfDelivery1);
            return result;
        }


    }
}
