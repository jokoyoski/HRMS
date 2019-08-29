using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ITypeOfExitRepository
    {
        // <summary>
        /// 
        /// </summary>
        ITypeOfExit GetTypeOfExitByID(int typeOfExitByID);
        /// <summary>
        /// 
        /// </summary>
        ITypeOfExit GetCompanyById(int CompanyId, string TypeOfExitName);
        /// <summary>
        /// 
        /// </summary>
        ITypeOfExit GetTypeOfExitByName(string typeOfExitByName);
        /// <summary>
        /// 
        /// </summary>
        string SaveTypeOfExitInfo(ITypeOfExitView typeOfExitInfo);

        string SaveDeleteTypeOfExitInfo(int TypeOfExitId);

        string SaveEditTypeOfExitInfo(ITypeOfExitView typeOfExitInfo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        IList<ITypeOfExit> GetAllMyTypeOfExit(int companyId);
        
    }
}
