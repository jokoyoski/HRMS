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
    public interface IAppraisalService
    {
        /// <summary>
        /// Gets the appraisal ListView.
        /// </summary>
        /// <returns></returns>
        IList<IAppraisal> GetAppraisalListView();
        /// <summary>
        /// Gets the appraisal registration view.
        /// </summary>
        /// <returns></returns>
        IAppraisalView GetAppraisalRegistrationView();
        /// <summary>
        /// Processes the appraisal information.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <returns></returns>
        string ProcessAppraisalInfo(IAppraisalView appraisalInfo);
        /// <summary>
        /// Gets the appraisal edit view.
        /// </summary>
        /// <param name="appraisalId">The appraisal identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalView GetAppraisalEditView(int appraisalId, string processingMessage);
        /// <summary>
        /// Processes the edit appraisal information.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <returns></returns>
        string ProcessEditAppraisalInfo(IAppraisalView appraisalInfo);
        /// <summary>
        /// Processes the delete appraisal information.
        /// </summary>
        /// <param name="appraisalId">The appraisal identifier.</param>
        /// <returns></returns>
        string ProcessDeleteAppraisalInfo(int appraisalId);
        /// <summary>
        /// Creates the appraisal update view.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalView CreateAppraisalUpdateView(IAppraisalView appraisalInfo, string processingMessage);
    }
}
