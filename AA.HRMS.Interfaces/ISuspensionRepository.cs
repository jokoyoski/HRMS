using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ISuspensionRepository
    {

        ISuspension GetSuspensionById(int suspensionId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="suspensionInfo"></param>
        /// <returns></returns>
        string SaveSuspensionInfo(ISuspensionView suspensionInfo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="suspensionInfo"></param>
        /// <returns></returns>
        string SaveEditSuspensionInfo(ISuspensionView suspensionInfo);
       /// <summary>
       /// 
       /// </summary>
       /// <param name="suspensionId"></param>
       /// <returns></returns>
        string SaveDeleteSuspensionInfo(int suspensionId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        IList<ISuspension> GetAllMySuspensions(int companyId);
    }
}
