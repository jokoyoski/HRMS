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
    public interface IAdvertisementModelViewFactory
    {
        /// <summary>
        /// Creates the advertise view.
        /// </summary>
        /// <returns></returns>
        IAdvertisementModelView CreateAdvertiseView();

        /// <summary>
        /// Creates the updated advertisement model view.
        /// </summary>
        /// <param name="advertisementModelInfo">The advertisement model information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAdvertisementModelView CreateUpdatedAdvertisementModelView(IAdvertisementModelView advertisementModelInfo, string processingMessage);
    }
}
