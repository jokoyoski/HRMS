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
    public interface IAwardRepository
    {
        /// <summary>
        /// Saves the award information.
        /// </summary>
        /// <param name="awardInfo">The award information.</param>
        /// <returns></returns>
        string SaveAwardInfo(IAwardView awardInfo);

        /// <summary>
        /// Updates the award information.
        /// </summary>
        /// <param name="awardInfo">The award information.</param>
        /// <returns></returns>
        string UpdateAwardInfo(IAwardView awardInfo);

        /// <summary>
        /// Gets the award by identifier.
        /// </summary>
        /// <param name="awardId">The award identifier.</param>
        /// <returns></returns>
        IAward GetAwardById(int awardId);

        /// <summary>
        /// Deletes the award information.
        /// </summary>
        /// <param name="awardId">The award identifier.</param>
        /// <returns></returns>
        string DeleteAwardInfo(int awardId);

    }
}
