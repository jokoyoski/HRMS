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
    public interface IAppraisalGoalRepository
    {
        /// <summary>
        /// Gets the appraisal goal list.
        /// </summary>
        /// <returns></returns>
        IList<IAppraisalGoal> GetAppraisalGoalList();

        /// <summary>
        /// Saves the appraisal goal information.
        /// </summary>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <returns></returns>
        string SaveAppraisalGoalInfo(IAppraisalGoalView appraisalGoalInfo);

        /// <summary>
        /// Updates the appraisal goal information.
        /// </summary>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <returns></returns>
        string UpdateAppraisalGoalInfo(IAppraisalGoalView appraisalGoalInfo);

        /// <summary>
        /// Gets the appraisal goal by identifier.
        /// </summary>
        /// <param name="appraisalGoalId">The appraisal goal identifier.</param>
        /// <returns></returns>
        IAppraisalGoal GetAppraisalGoalById(int appraisalGoalId);

        /// <summary>
        /// Deletes the appraisal goal information.
        /// </summary>
        /// <param name="appraisalGoalId">The appraisal goal identifier.</param>
        /// <returns></returns>
        string DeleteAppraisalGoalInfo(int appraisalGoalId);
    }
}
