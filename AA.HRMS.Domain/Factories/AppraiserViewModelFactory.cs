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
    /// <seealso cref="AA.HRMS.Interfaces.IAppraiserViewModelFactory" />
    public class AppraiserViewModelFactory : IAppraiserViewModelFactory
    {
        public IAppraiserView CreateAppraiserView()
        {
            var viewModel = new AppraiserView();

            return viewModel;
        }

        public IAppraiserView CreateUpdatedAppraiserView(IAppraiserView appraiserInfo, string processingMessage)
        {
            if (appraiserInfo == null) throw new ArgumentNullException(nameof(appraiserInfo));

            appraiserInfo.ProcessingMessage = processingMessage;

            return appraiserInfo;
        }
        /// <summary>
        /// Creates the appraiser update view.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraiserInfo</exception>
        public IAppraiserView CreateAppraiserUpdateView(IAppraiserView appraiserInfo)
        {
            if (appraiserInfo == null) throw new ArgumentNullException(nameof(appraiserInfo));

            var appraiserView = new AppraiserView
            {
                AppraiserId = appraiserInfo.AppraiserId,
                AppraiserName = appraiserInfo.AppraiserName,
            };

            return appraiserView;
        }
        /// <summary>
        /// Creates the edit appraiser view.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraiserInfo</exception>
        public IAppraiserView CreateEditAppraiserView(IAppraiser appraiserInfo)
        {
            if (appraiserInfo == null) throw new ArgumentNullException(nameof(appraiserInfo));

            var returnAppraiser = new AppraiserView
            {
                AppraiserId = appraiserInfo.AppraiserId,
                AppraiserName = appraiserInfo.AppraiserName,
                IsActive = appraiserInfo.IsActive
            };
            return returnAppraiser;
        }
    }
}
