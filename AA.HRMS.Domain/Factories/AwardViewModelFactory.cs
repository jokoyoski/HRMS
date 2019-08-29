using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Domain.Factories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IAwardViewModelFactory" />
    public class AwardViewModelFactory : IAwardViewModelFactory
    {
        /// <summary>
        /// Creates the award view.
        /// </summary>
        /// <returns></returns>
        public IAwardView CreateAwardView()
        {
            //if (awardId == null) throw new ArgumentNullException(nameof(awardId));

            var viewModel = new AwardView
            {
                //AwardId = awardId,
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the updated award view.
        /// </summary>
        /// <param name="awardInfo">The award information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">awardInfo</exception>
        public IAwardView CreateUpdatedAwardView(IAwardView awardInfo, string processingMessage)
        {
            if (awardInfo == null) throw new ArgumentNullException(nameof(awardInfo));

            awardInfo.ProcessingMessage = processingMessage;

            return awardInfo;
        }

        /// <summary>
        /// Creates the award update view.
        /// </summary>
        /// <param name="awardInfo">The award information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">awardInfo</exception>
        public IAwardView CreateAwardUpdateView(IAward awardInfo)
        {
            if (awardInfo == null) throw new ArgumentNullException(nameof(awardInfo));

            var awardView = new AwardView
            {
                AwardId = awardInfo.AwardId,
                UserId = awardInfo.UserId,
                AwardName = awardInfo.AwardName,
                AwardYear = awardInfo.AwardYear,
                DateCreated = awardInfo.DateCreated,
                IsActive = awardInfo.IsActive,
            };

            return awardView;
        }

        /// <summary>
        /// Creates the edit award view.
        /// </summary>
        /// <param name="awardInfo">The award information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">awardInfo</exception>
        public IAwardView CreateEditAwardView(IAward awardInfo)
        {
            if (awardInfo == null) throw new ArgumentNullException(nameof(awardInfo));

            //if (awardCollection == null) throw new ArgumentNullException(nameof(awardCollection));

            //var departmentDDL =
            //    GetDropDownList.DepartmentListItems(departmentCollection, departmentInfo.ParentDepartmentId);


            var returnAward = new AwardView
            {
                AwardId = awardInfo.AwardId,
                UserId = awardInfo.UserId,
                AwardName = awardInfo.AwardName,
                AwardYear =awardInfo.AwardYear,
                IsActive = awardInfo.IsActive
            };
            return returnAward;
        }
    }
}
