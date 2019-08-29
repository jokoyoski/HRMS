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
    public interface IAppraisalRatingRepository
    {
        /// <summary>
        /// Gets the appraisal rating list.
        /// </summary>
        /// <returns></returns>
        IList<IAppraisalRating> GetAppraisalRatingList();
        /// <summary>
        /// Saves the appraisal rating information.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        string SaveAppraisalRatingInfo(IAppraisalRatingView appraisalRatingInfo);
        /// <summary>
        /// Updates the appraisal rating information.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        string UpdateAppraisalRatingInfo(IAppraisalRatingView appraisalRatingInfo);
        /// <summary>
        /// Gets the appraisal rating by identifier.
        /// </summary>
        /// <param name="appraisalRatingId">The appraisal rating identifier.</param>
        /// <returns></returns>
        IAppraisalRating GetAppraisalRatingById(int appraisalRatingId);
        /// <summary>
        /// Deletes the appraisal rating information.
        /// </summary>
        /// <param name="appraisalRatingId">The appraisal rating identifier.</param>
        /// <returns></returns>
        string DeleteAppraisalRatingInfo(int appraisalRatingId);
    }
}
