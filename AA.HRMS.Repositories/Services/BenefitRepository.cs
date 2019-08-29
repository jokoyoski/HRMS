using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Models;
using AA.HRMS.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Services
{
    public class BenefitRepository : IBenefitRepository
    {
        /// <summary>
        /// The database context factory
        /// </summary>
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="BenefitRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public BenefitRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Gets the name of the benefit by.
        /// </summary>
        /// <param name="benefitName">Name of the benefit.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">e</exception>
        public IBenefit GetBenefitByName(string benefitName, int companyId)
        {
            try
            {
                using (
                var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = BenefitQueries.getBenefitByName(dbContext, benefitName, companyId);
                    return aRecord;
                }
            }
            catch(Exception e)
            {
                throw new ApplicationException(nameof(e));
            }
        }

        /// <summary>
        /// Gets the benefit by identifier.
        /// </summary>
        /// <param name="benefitId">The benefit identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetBenefitById</exception>
        public IBenefit GetBenefitById(int benefitId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = BenefitQueries.getBenefitById(dbContext, benefitId);

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetBenefitById ", e);
            }
        }

        /// <summary>
        /// Gets the benefit by company identifier identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">GetBenefitById</exception>
        public IList<IBenefit> GetBenefitByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = BenefitQueries.getBenefitByCompanyId(dbContext, companyId).ToList();

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("GetBenefitById ", e);
            }
        }

        /// <summary>
        /// Saves the benefit.
        /// </summary>
        /// <param name="benefit">The benefit.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">benefit</exception>
        public string SaveBenefit(IBenefitModelView benefit)
        {
            if(benefit == null)
            {
                throw new ArgumentNullException(nameof(benefit));
            }

            var result = string.Empty;

            var newRecord = new Benefit
            {
                BenefitName = benefit.BenefitName,
                BenefitDescription = benefit.BenefitDescription,
                IsActive = true,
                IsMonetized = benefit.IsMonetized,
                IsTaxable = benefit.IsTaxable,
                CompanyId = benefit.CompanyId,
                DateCreated = DateTime.UtcNow,
                Period = benefit.Period,
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Benefits.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch(Exception e)
            {
                result = string.Format("SaveBenefit - {0} , {1}", e.Message,
                   e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        /// <summary>
        /// Saves the edit benefit.
        /// </summary>
        /// <param name="benefit">The benefit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">benefit</exception>
        public string SaveEditBenefit(IBenefitModelView benefit)
        {
            if (benefit == null)
            {
                throw new ArgumentNullException(nameof(benefit));
            }

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var checkBenefitInfo = dbContext.Benefits.SingleOrDefault(x => x.BenefitId.Equals(benefit.BenefitId));

                    checkBenefitInfo.BenefitName = benefit.BenefitName;
                    checkBenefitInfo.BenefitDescription = benefit.BenefitDescription;
                    checkBenefitInfo.IsTaxable = benefit.IsTaxable;
                    checkBenefitInfo.IsMonetized = benefit.IsMonetized;
                    checkBenefitInfo.DateModified = DateTime.UtcNow;
                    checkBenefitInfo.Period = benefit.Period;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveEditBenefit - {0} , {1}", e.Message,
                   e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        /// <summary>
        /// Saves the deleted benefit.
        /// </summary>
        /// <param name="benefitId">The benefit identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">benefitId</exception>
        public string SaveDeletedBenefit(int benefitId)
        {
            if (benefitId < 0)
            {
                throw new ArgumentNullException(nameof(benefitId));
            }

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var checkBenefitInfo = dbContext.Benefits.SingleOrDefault(x => x.BenefitId.Equals(benefitId));

                    checkBenefitInfo.IsActive = false;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveDeletedBenefit - {0} , {1}", e.Message,
                   e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
    }
}
