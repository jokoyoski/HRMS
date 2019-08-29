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
    public interface IAwardViewModelFactory
    {
        /// <summary>
        /// Creates the award view.
        /// </summary>
        /// <returns></returns>
        IAwardView CreateAwardView();

        /// <summary>
        /// Creates the updated award view.
        /// </summary>
        /// <param name="awardInfo">The award information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAwardView CreateUpdatedAwardView(IAwardView awardInfo, string processingMessage);

        /// <summary>
        /// Creates the award update view.
        /// </summary>
        /// <param name="awardInfo">The award information.</param>
        /// <returns></returns>
        IAwardView CreateAwardUpdateView(IAward awardInfo);

        /// <summary>
        /// Creates the edit award view.
        /// </summary>
        /// <param name="awardInfo">The award information.</param>
        /// <returns></returns>
        IAwardView CreateEditAwardView(IAward awardInfo);

    }
}
