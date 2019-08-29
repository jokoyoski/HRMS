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
    public interface IAppraisalRatingService
    {
        /// <summary>
        /// Gets the appraisal rating ListView.
        /// </summary>
        /// <returns></returns>
        IList<IAppraisalRating> GetAppraisalRatingListView();
        /// <summary>
        /// Gets the appraisal rating registration view.
        /// </summary>
        /// <returns></returns>
        IAppraisalRatingView GetAppraisalRatingRegistrationView();

        /// <summary>
        /// Processes the appraisal rating information.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        string ProcessAppraisalRatingInfo(IAppraisalRatingView appraisalRatingInfo);

        /// <summary>
        /// Gets the appraisal rating edit view.
        /// </summary>
        /// <param name="appraisalRatingId">The appraisal rating identifier.</param>
        /// <returns></returns>
        IAppraisalRatingView GetAppraisalRatingEditView(int appraisalRatingId);
        /// <summary>
        /// Processes the edit appraisal rating information.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        string ProcessEditAppraisalRatingInfo(IAppraisalRatingView appraisalRatingInfo);
        /// <summary>
        /// Processes the delete appraisal rating information.
        /// </summary>
        /// <param name="appraisalRatingId">The appraisal rating identifier.</param>
        /// <returns></returns>
        string ProcessDeleteAppraisalRatingInfo(int appraisalRatingId);
        /// <summary>
        /// Creates the appraisal rating update view.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalRatingView CreateAppraisalRatingUpdateView(IAppraisalRatingView appraisalRatingInfo, string processingMessage);
    }
}
