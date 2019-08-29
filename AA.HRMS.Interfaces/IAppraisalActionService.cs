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
    public interface IAppraisalActionService
    {
        /// <summary>
        /// Gets the appraisal action ListView.
        /// </summary>
        /// <returns></returns>
        IList<IAppraisalAction> GetAppraisalActionListView();

        /// <summary>
        /// Gets the appraisal action registration view.
        /// </summary>
        /// <returns></returns>
        IAppraisalActionView GetAppraisalActionRegistrationView();

        /// <summary>
        /// Processes the appraisal action information.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <returns></returns>
        string ProcessAppraisalActionInfo(IAppraisalActionView appraisalActionInfo);

        /// <summary>
        /// Gets the appraisal action edit view.
        /// </summary>
        /// <param name="appraisalActionId">The appraisal action identifier.</param>
        /// <returns></returns>
        IAppraisalActionView GetAppraisalActionEditView(int appraisalActionId);

        /// <summary>
        /// Processes the edit appraisal action information.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <returns></returns>
        string ProcessEditAppraisalActionInfo(IAppraisalActionView appraisalActionInfo);

        /// <summary>
        /// Processes the delete appraisal action information.
        /// </summary>
        /// <param name="appraisalActionId">The appraisal action identifier.</param>
        /// <returns></returns>
        string ProcessDeleteAppraisalActionInfo(int appraisalActionId);

        /// <summary>
        /// Creates the appraisal action update view.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalActionView CreateAppraisalActionUpdateView(IAppraisalActionView appraisalActionInfo, string processingMessage);
    }
}
