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
    public interface IAwardService
    {
        /// <summary>
        /// Gets the award registration view.
        /// </summary>
        /// <returns></returns>
        IAwardView GetAwardRegistrationView();

        /// <summary>
        /// Processes the award information.
        /// </summary>
        /// <param name="awardInfo">The award information.</param>
        /// <returns></returns>
        string ProcessAwardInfo(IAwardView awardInfo);

        /// <summary>
        /// Gets the award edit view.
        /// </summary>
        /// <param name="awardId">The award identifier.</param>
        /// <returns></returns>
        IAwardView GetAwardEditView(int awardId);

        /// <summary>
        /// Processes the edit award information.
        /// </summary>
        /// <param name="awardInfo">The award information.</param>
        /// <returns></returns>
        string ProcessEditAwardInfo(IAwardView awardInfo);

        /// <summary>
        /// Processes the delete award information.
        /// </summary>
        /// <param name="awardId">The award identifier.</param>
        /// <returns></returns>
        string ProcessDeleteAwardInfo(int awardId);

        /// <summary>
        /// Creates the award updated view.
        /// </summary>
        /// <param name="awardInfo">The award information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAwardView CreateAwardUpdatedView(IAwardView awardInfo, string processingMessage);
    }
}
