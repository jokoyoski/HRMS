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
    public interface IAppraisalRepository
    {
        /// <summary>
        /// Gets the appraisal list.
        /// </summary>
        /// <returns></returns>
        IList<IAppraisal> GetAppraisalList();

        /// <summary>
        /// Saves the appraisal information.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <returns></returns>
        string SaveAppraisalInfo(IAppraisalView appraisalInfo);

        /// <summary>
        /// Updates the appraisal information.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <returns></returns>
        string UpdateAppraisalInfo(IAppraisalView appraisalInfo);
        /// <summary>
        /// Gets the appraisal by identifier.
        /// </summary>
        /// <param name="appraisalId">The appraisal identifier.</param>
        /// <returns></returns>
        IAppraisal GetAppraisalById(int appraisalId);

        /// <summary>
        /// Deletes the appraisal information.
        /// </summary>
        /// <param name="appraisalId">The appraisal identifier.</param>
        /// <returns></returns>
        string DeleteAppraisalInfo(int appraisalId);

       
    }
}
