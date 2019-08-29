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
    /// <seealso cref="AA.HRMS.Interfaces.IAppraisalActionViewModelFactory" />
    public class AppraisalActionViewModelFactory : IAppraisalActionViewModelFactory
    {
        public IAppraisalActionView CreateAppraisalActionView()
        {
            var viewModel = new AppraisalActionView();

            return viewModel;
        }

        public IAppraisalActionView CreateUpdatedAppraisalActionView(IAppraisalActionView appraisalActionInfo, string processingMessage)
        {
            if (appraisalActionInfo == null) throw new ArgumentNullException(nameof(appraisalActionInfo));

            appraisalActionInfo.ProcessingMessage = processingMessage;

            return appraisalActionInfo;
        }
        /// <summary>
        /// Creates the appraisal action update view.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalActionInfo</exception>
        public IAppraisalActionView CreateAppraisalActionUpdateView(IAppraisalActionView appraisalActionInfo)
        {
            if (appraisalActionInfo == null) throw new ArgumentNullException(nameof(appraisalActionInfo));

            var appraisalActionView = new AppraisalActionView
            {
                AppraisalActionId = appraisalActionInfo.AppraisalActionId,
                AppraisalActionName = appraisalActionInfo.AppraisalActionName,
            };

            return appraisalActionView;
        }
        /// <summary>
        /// Creates the edit appraisal action view.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalActionInfo</exception>
        public IAppraisalActionView CreateEditAppraisalActionView(IAppraisalAction appraisalActionInfo)
        {
            if (appraisalActionInfo == null) throw new ArgumentNullException(nameof(appraisalActionInfo));

            var returnAppraisalAction = new AppraisalActionView
            {
                AppraisalActionId = appraisalActionInfo.AppraisalActionId,
                AppraisalActionName = appraisalActionInfo.AppraisalActionName,
                IsActive = appraisalActionInfo.IsActive
            };
            return returnAppraisalAction;
        }
    }
}
