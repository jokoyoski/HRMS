using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Factories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IAdvertisementModelViewFactory" />
    public class AdvertisementModelViewFactory : IAdvertisementModelViewFactory
    {

        /// <summary>
        /// Creates the department view.
        /// </summary>
        /// <returns></returns>
        public IAdvertisementModelView CreateAdvertiseView()
        {
            var view = new AdvertisementModelView
            {
                ProcessingMessage = string.Empty
            };
            return view;
        }
        /// <summary>
        /// Creates the updated department view.
        /// </summary>
        /// <param name="advertisementModelInfo">The advertisement model information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">advertisementModelInfo</exception>
        public IAdvertisementModelView CreateUpdatedAdvertisementModelView(IAdvertisementModelView advertisementModelInfo, string processingMessage)
        {
            if (advertisementModelInfo == null) throw new ArgumentNullException(nameof(advertisementModelInfo));

            advertisementModelInfo.ProcessingMessage = processingMessage;

            return advertisementModelInfo;
        }

    }
}
