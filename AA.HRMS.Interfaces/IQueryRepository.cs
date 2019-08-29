using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IQueryRepository
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryId"></param>
        /// <returns></returns>
        IQuery GetQueryById(int queryId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryName"></param>
        /// <returns></returns>
        IQuery GetQueryByName(string queryName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryInfo"></param>
        /// <returns></returns>
        string SaveQueryInfo(IQueryView queryInfo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryInfo"></param>
        /// <returns></returns>
        string SaveEditQueryInfo(IQueryView queryInfo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryId"></param>
        /// <returns></returns>
        string SaveDeleteQueryInfo(int queryId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        IList<IQuery> GetAllMyQueries(int companyId);
    }
}
