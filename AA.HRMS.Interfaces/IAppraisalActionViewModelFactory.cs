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
    public interface IAppraisalActionViewModelFactory
    {
        /// <summary>
        /// Creates the appraisal action view.
        /// </summary>
        /// <returns></returns>
        IAppraisalActionView CreateAppraisalActionView();

        /// <summary>
        /// Creates the updated appraisal action view.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalActionView CreateUpdatedAppraisalActionView(IAppraisalActionView appraisalActionInfo, string processingMessage);

        /// <summary>
        /// Creates the appraisal action update view.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <returns></returns>
        IAppraisalActionView CreateAppraisalActionUpdateView(IAppraisalActionView appraisalActionInfo);
        /// <summary>
        /// Creates the edit appraisal action view.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <returns></returns>
        IAppraisalActionView CreateEditAppraisalActionView(IAppraisalAction appraisalActionInfo);
    }
}
