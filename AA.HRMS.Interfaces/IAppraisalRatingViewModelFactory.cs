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
    public interface IAppraisalRatingViewModelFactory
    {
        /// <summary>
        /// Creates the appraisal rating view.
        /// </summary>
        /// <returns></returns>
        IAppraisalRatingView CreateAppraisalRatingView();

        /// <summary>
        /// Creates the updated appraisal rating view.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalRatingView CreateUpdatedAppraisalRatingView(IAppraisalRatingView appraisalRatingInfo, string processingMessage);

        /// <summary>
        /// Creates the appraisal rating update view.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        IAppraisalRatingView CreateAppraisalRatingUpdateView(IAppraisalRatingView appraisalRatingInfo);
        /// <summary>
        /// Creates the edit appraisal rating view.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        IAppraisalRatingView CreateEditAppraisalRatingView(IAppraisalRating appraisalRatingInfo);
    }
}
