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
    public interface IAppraisalGoalViewModelFactory
    {
        /// <summary>
        /// Creates the appraisal goal view.
        /// </summary>
        /// <param name="appraisersCollection">The appraisers collection.</param>
        /// <returns></returns>
        IAppraisalGoalView CreateAppraisalGoalView(IList<IAppraiser> appraisersCollection);

        /// <summary>
        /// Creates the updated appraisal goal view.
        /// </summary>
        /// <param name="appraisersCollection">The appraisers collection.</param>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalGoalView CreateUpdatedAppraisalGoalView(IList<IAppraiser> appraisersCollection, IAppraisalGoalView appraisalGoalInfo, string processingMessage);

        /// <summary>
        /// Creates the appraisal goal update view.
        /// </summary>
        /// <param name="appraisersCollection">The appraisers collection.</param>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalGoalView CreateAppraisalGoalUpdateView(IList<IAppraiser> appraisersCollection, IAppraisalGoalView appraisalGoalInfo, string processingMessage);

        /// <summary>
        /// Creates the edit appraisal goal view.
        /// </summary>
        /// <param name="appraisersCollection">The appraisers collection.</param>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalGoalView CreateEditAppraisalGoalView(IList<IAppraiser> appraisersCollection, IAppraisalGoal appraisalGoalInfo, string processingMessage);
    }
}
