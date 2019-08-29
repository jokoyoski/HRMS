using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ISuspensionService
    {

        /// <summary>
        /// Gets the suspension registration view.
        /// </summary>
        /// <returns></returns>
        ISuspensionView GetSuspensionRegistrationView();

        /// <summary>
        /// Processes the delete suspension information.
        /// </summary>
        /// <param name="suspensionInfo">The suspension information.</param>
        /// <returns></returns>
        string ProcessDeleteSuspensionInfo(int suspensionInfo);
        
        /// <summary>
        /// Gets the suspension edit view.
        /// </summary>
        /// <param name="suspensionId">The suspension identifier.</param>
        /// <returns></returns>
        ISuspensionView GetSuspensionEditView(int suspensionId);

        /// <summary>
        /// Processes the edit suspension information.
        /// </summary>
        /// <param name="suspensionInfo">The suspension information.</param>
        /// <returns></returns>
        string ProcessEditSuspensionInfo(ISuspensionView suspensionInfo);
        
        /// <summary>
        /// Processes the suspension information.
        /// </summary>
        /// <param name="suspensionId">The suspension identifier.</param>
        /// <returns></returns>
        string ProcessSuspensionInfo(ISuspensionView suspensionId);
        
        /// <summary>
        /// Creates the suspension updated view.
        /// </summary>
        /// <param name="suspensionInfo">The suspension information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ISuspensionView CreateSuspensionUpdatedView(ISuspensionView suspensionInfo, string processingMessage);

        /// <summary>
        /// Creates the suspension list.
        /// </summary>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <param name="SelectedEmployeeId">The selected employee identifier.</param>
        /// <param name="selectedQueryId">The selected query identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ISuspensionListView CreateSuspensionList(int? selectedCompanyId, int SelectedEmployeeId, int selectedQueryId, string processingMessage);
    }
}
