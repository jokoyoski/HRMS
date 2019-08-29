using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Factories;
using AA.HRMS.Repositories.Models;
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
    /// <seealso cref="AA.HRMS.Interfaces.IAdvertisementModelRepository" />
    public class AdvertisementModelRepository : IAdvertisementModelRepository
    {
        /// <summary>
        /// The database context factory
        /// </summary>
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdvertisementModelRepository" /> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public AdvertisementModelRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory ?? new DbContextFactory(null);
        }

        /// <summary>
        /// Saves the advertisement model information.
        /// </summary>
        /// <param name="advertisementModelInfo">The advertisement model information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">advertisementModelInfo</exception>
        public string SaveAdvertisementModelInfo(IAdvertisementModelView advertisementModelInfo)
        {
            if (advertisementModelInfo == null) throw new ArgumentNullException(nameof(advertisementModelInfo));

            var result = string.Empty;

            var newRecord = new Advertisement
            {
                Media = advertisementModelInfo.Media,
                Comment = advertisementModelInfo.Comment,
                IsStatus = advertisementModelInfo.IsStatus,
                DigitalFieldId = advertisementModelInfo.DigitalFieldId
            };
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Advertisements.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveEmploymentHistoryInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;

        }
    }
}
