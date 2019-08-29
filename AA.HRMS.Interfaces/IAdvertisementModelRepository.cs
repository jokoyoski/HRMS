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
    public interface IAdvertisementModelRepository
    {
        /// <summary>
        /// Saves the advertisement model information.
        /// </summary>
        /// <param name="advertisementModelInfo">The advertisement model information.</param>
        /// <returns></returns>
        string SaveAdvertisementModelInfo(IAdvertisementModelView advertisementModelInfo);
    }
}
