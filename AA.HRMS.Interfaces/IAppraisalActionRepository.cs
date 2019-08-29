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
    public interface IAppraisalActionRepository
    {
        /// <summary>
        /// Gets the appraisal action list.
        /// </summary>
        /// <returns></returns>
        IList<IAppraisalAction> GetAppraisalActionList();

        /// <summary>
        /// Saves the appraisal action information.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <returns></returns>
        string SaveAppraisalActionInfo(IAppraisalActionView appraisalActionInfo);

        /// <summary>
        /// Updates the appraisal action information.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <returns></returns>
        string UpdateAppraisalActionInfo(IAppraisalActionView appraisalActionInfo);

        /// <summary>
        /// Gets the appraisal action by identifier.
        /// </summary>
        /// <param name="appraisalActionId">The appraisal action identifier.</param>
        /// <returns></returns>
        IAppraisalAction GetAppraisalActionById(int appraisalActionId);

        /// <summary>
        /// Deletes the appraisal action information.
        /// </summary>
        /// <param name="appraisalActionId">The appraisal action identifier.</param>
        /// <returns></returns>
        string DeleteAppraisalActionInfo(int appraisalActionId);
    }
}
