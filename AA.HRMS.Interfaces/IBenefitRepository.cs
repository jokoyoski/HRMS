using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IBenefitRepository
    {
        /// <summary>
        /// Gets the benefit by identifier.
        /// </summary>
        /// <param name="benefitId">The benefit identifier.</param>
        /// <returns></returns>
        IBenefit GetBenefitById(int benefitId);

        /// <summary>
        /// Gets the benefit by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IBenefit> GetBenefitByCompanyId(int companyId);
        /// <summary>
        /// Gets the name of the benefit by.
        /// </summary>
        /// <param name="benefitName">Name of the benefit.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IBenefit GetBenefitByName(string benefitName, int companyId);
        /// <summary>
        /// Saves the benefit.
        /// </summary>
        /// <param name="benefit">The benefit.</param>
        /// <returns></returns>
        string SaveBenefit(IBenefitModelView benefit);
        /// <summary>
        /// Saves the edit benefit.
        /// </summary>
        /// <param name="benefit">The benefit.</param>
        /// <returns></returns>
        string SaveEditBenefit(IBenefitModelView benefit);
        /// <summary>
        /// Saves the deleted benefit.
        /// </summary>
        /// <param name="benefitId">The benefit identifier.</param>
        /// <returns></returns>
        string SaveDeletedBenefit(int benefitId);
    }
}
