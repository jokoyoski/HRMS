using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAppraiserRepository
    {
        /// <summary>
        /// Gets the appraiser list.
        /// </summary>
        /// <returns></returns>
        IList<IAppraiser> GetAppraiserList();
        /// <summary>
        /// Saves the appraiser information.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <returns></returns>
        string SaveAppraiserInfo(IAppraiserView appraiserInfo);
        /// <summary>
        /// Updates the appraiser information.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <returns></returns>
        string UpdateAppraiserInfo(IAppraiserView appraiserInfo);
        /// <summary>
        /// Gets the appraiser by identifier.
        /// </summary>
        /// <param name="appraiserId">The appraiser identifier.</param>
        /// <returns></returns>
        IAppraiser GetAppraiserById(int appraiserId);
        /// <summary>
        /// Deletes the appraiser information.
        /// </summary>
        /// <param name="appraiserId">The appraiser identifier.</param>
        /// <returns></returns>
        string DeleteAppraiserInfo(int appraiserId);
    }
}
