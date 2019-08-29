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
    public interface IAppraiserService
    {
        /// <summary>
        /// Gets the appraiser ListView.
        /// </summary>
        /// <returns></returns>
        IList<IAppraiser> GetAppraiserListView();
        /// <summary>
        /// Gets the appraiser registration view.
        /// </summary>
        /// <returns></returns>
        IAppraiserView GetAppraiserRegistrationView();
        /// <summary>
        /// Processes the appraiser information.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <returns></returns>
        string ProcessAppraiserInfo(IAppraiserView appraiserInfo);
        /// <summary>
        /// Gets the appraiser edit view.
        /// </summary>
        /// <param name="appraiserId">The appraiser identifier.</param>
        /// <returns></returns>
        IAppraiserView GetAppraiserEditView(int appraiserId);
        /// <summary>
        /// Processes the edit appraiser information.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <returns></returns>
        string ProcessEditAppraiserInfo(IAppraiserView appraiserInfo);
        /// <summary>
        /// Processes the delete appraiser information.
        /// </summary>
        /// <param name="appraiserId">The appraiser identifier.</param>
        /// <returns></returns>
        string ProcessDeleteAppraiserInfo(int appraiserId);
        /// <summary>
        /// Creates the appraiser update view.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraiserView CreateAppraiserUpdateView(IAppraiserView appraiserInfo, string processingMessage);
    }
}
