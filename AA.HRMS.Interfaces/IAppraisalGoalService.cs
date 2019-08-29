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
    public interface IAppraisalGoalService
    {
        /// <summary>
        /// Gets the appraisal goal ListView.
        /// </summary>
        /// <returns></returns>
        IList<IAppraisalGoal> GetAppraisalGoalListView();

        /// <summary>
        /// Gets the appraisal goal registration view.
        /// </summary>
        /// <returns></returns>
        IAppraisalGoalView GetAppraisalGoalRegistrationView();

        /// <summary>
        /// Processes the appraisal goal information.
        /// </summary>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <returns></returns>
        string ProcessAppraisalGoalInfo(IAppraisalGoalView appraisalGoalInfo);

        /// <summary>
        /// Gets the appraisal goal edit view.
        /// </summary>
        /// <param name="appraisalGoalId">The appraisal goal identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalGoalView GetAppraisalGoalEditView(int appraisalGoalId, string processingMessage);

        /// <summary>
        /// Processes the edit appraisal goal information.
        /// </summary>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <returns></returns>
        string ProcessEditAppraisalGoalInfo(IAppraisalGoalView appraisalGoalInfo);
        /// <summary>
        /// Processes the delete appraisal goal information.
        /// </summary>
        /// <param name="appraisalGoalId">The appraisal goal identifier.</param>
        /// <returns></returns>
        string ProcessDeleteAppraisalGoalInfo(int appraisalGoalId);

        /// <summary>
        /// Creates the appraisal goal update view.
        /// </summary>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalGoalView CreateAppraisalGoalUpdateView(IAppraisalGoalView appraisalGoalInfo, string processingMessage);
    }
}
