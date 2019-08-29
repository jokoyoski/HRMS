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
    public interface IAppraiserViewModelFactory
    {
        /// <summary>
        /// Creates the appraiser view.
        /// </summary>
        /// <returns></returns>
        IAppraiserView CreateAppraiserView();
        /// <summary>
        /// Creates the updated appraiser view.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraiserView CreateUpdatedAppraiserView(IAppraiserView appraiserInfo, string processingMessage);
        /// <summary>
        /// Creates the appraiser update view.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <returns></returns>
        IAppraiserView CreateAppraiserUpdateView(IAppraiserView appraiserInfo);
        /// <summary>
        /// Creates the edit appraiser view.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <returns></returns>
        IAppraiserView CreateEditAppraiserView(IAppraiser appraiserInfo);
    }
}
