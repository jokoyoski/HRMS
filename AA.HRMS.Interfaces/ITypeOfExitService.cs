using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AA.HRMS.Interfaces
{
    public interface ITypeOfExitService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeOfExitInfo"></param>
        /// <returns></returns>
        string ProcessTypeOfExitInfo(ITypeOfExitView typeOfExitInfo);

        /// <summary>
        /// Processes the edit type of exit information.
        /// </summary>
        /// <param name="typeOfExitInfo">The type of exit information.</param>
        /// <returns></returns>
        string ProcessEditTypeOfExitInfo(ITypeOfExitView typeOfExitInfo);

        /// <summary>
        /// Processes the delete type of exit information.
        /// </summary>
        /// <param name="TypeOfExitId">The type of exit identifier.</param>
        /// <returns></returns>
        string ProcessDeleteTypeOfExitInfo(int TypeOfExitId);

        /// <summary>
        /// Gets the type of exit registration view.
        /// </summary>
        /// <returns></returns>
        ITypeOfExitView GetTypeOfExitRegistrationView();

        /// <summary>
        /// Creates the type of exit list.
        /// </summary>
        /// <param name="selectedTypeOfExitID">The selected type of exit identifier.</param>
        /// <param name="selectedCompany">The selected company.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ITypeOfExitListView CreateTypeOfExitList(int? selectedTypeOfExitID, string selectedCompany, string processingMessage);

        /// <summary>
        /// Gets the type of exit edit view.
        /// </summary>
        /// <param name="TypeOfExitId">The type of exit identifier.</param>
        /// <returns></returns>
        ITypeOfExitView GetTypeOfExitEditView(int TypeOfExitId);

        string ProcessUploadExceltypeOfExit(HttpPostedFileBase typeOfExitExcelFile);
        

            /// <summary>
            /// Gets the type of exit update view.
            /// </summary>
            /// <param name="TypeOfExit">The type of exit.</param>
            /// <param name="processingMessage">The processing message.</param>
            /// <returns></returns>
            ITypeOfExitView GetTypeOfExitUpdateView(ITypeOfExitView TypeOfExit, string processingMessage);
    }
}
