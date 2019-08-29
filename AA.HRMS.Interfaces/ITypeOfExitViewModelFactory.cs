using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ITypeOfExitViewModelFactory
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyCollection"></param>
        /// <param name="typeOfExitCollection"></param>
        /// <param name="employeeCollection"></param>
        /// <param name="typeOfExitInfo"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        ITypeOfExitView CreateTypeOfExitView(int companyId, IList<ITypeOfExit> typeOfExitCollection,
            IList<IEmployee> employeeCollection, ITypeOfExit typeOfExitInfo, string message);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyCollection"></param>
        /// <param name="typeOfExitCollection"></param>
        /// <returns></returns>
        ITypeOfExitListView CreateTypeOfExitListView(IList<ITypeOfExit> typeOfExitCollection, ICompanyDetail companyInfo,
            string processingMessage);

        /// <summary>
        /// Creates the edit type of exit view.
        /// </summary>
        /// <param name="TypeOfExit">The type of exit.</param>
        /// <returns></returns>
        ITypeOfExitView CreateEditTypeOfExitView(ITypeOfExit TypeOfExit);

        /// <summary>
        /// Creates the type of exit update view.
        /// </summary>
        /// <param name="TypeOfExit">The type of exit.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ITypeOfExitView CreateTypeOfExitUpdateView(ITypeOfExitView TypeOfExit, string processingMessage);
    }
}
