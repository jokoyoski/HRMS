using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Domain.Factories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IAppraisalRatingViewModelFactory" />
    public class AppraisalRatingViewModelFactory : IAppraisalRatingViewModelFactory
    {
        public IAppraisalRatingView CreateAppraisalRatingView()
        {
            var viewModel = new AppraisalRatingView();

            return viewModel;
        }

        public IAppraisalRatingView CreateUpdatedAppraisalRatingView(IAppraisalRatingView appraisalRatingInfo, string processingMessage)
        {
            if (appraisalRatingInfo == null) throw new ArgumentNullException(nameof(appraisalRatingInfo));

            appraisalRatingInfo.ProcessingMessage = processingMessage;

            return appraisalRatingInfo;
        }

        /// <summary>
        /// Creates the appraisal rating update view.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalRatingInfo</exception>
        public IAppraisalRatingView CreateAppraisalRatingUpdateView(IAppraisalRatingView appraisalRatingInfo)
        {
            if (appraisalRatingInfo == null) throw new ArgumentNullException(nameof(appraisalRatingInfo));

            var appraisalRatingView = new AppraisalRatingView
            {
                AppraisalRatingId = appraisalRatingInfo.AppraisalRatingId,
                AppraisalRatingName = appraisalRatingInfo.AppraisalRatingName,
            };

            return appraisalRatingView;
        }
        /// <summary>
        /// Creates the edit appraisal rating view.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalRatingInfo</exception>
        public IAppraisalRatingView CreateEditAppraisalRatingView(IAppraisalRating appraisalRatingInfo)
        {
            if (appraisalRatingInfo == null) throw new ArgumentNullException(nameof(appraisalRatingInfo));

            var returnAppraisalRating = new AppraisalRatingView
            {
                AppraisalRatingId = appraisalRatingInfo.AppraisalRatingId,
                AppraisalRatingName = appraisalRatingInfo.AppraisalRatingName,
                IsActive = appraisalRatingInfo.IsActive
            };
            return returnAppraisalRating;
        }
    }
}