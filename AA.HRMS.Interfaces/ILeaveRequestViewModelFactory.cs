using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ILeaveRequestViewModelFactory
    {
        /// <summary>
        /// Creates the leave request list.
        /// </summary>
        /// <param name="leaveRequestCollection">The leave request collection.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="company">The company.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ILeaveRequestListView CreateLeaveRequestList(IList<ILeaveRequestModel> leaveRequestCollection, IEmployee employee, ICompanyDetail company, int employeeId, string processingMessage);
        /// <summary>
        /// Creates the leave request ListView.
        /// </summary>
        /// <param name="leaveRequestCollection">The leave request collection.</param>
        /// <param name="listViewData">The list view data.</param>
        /// <returns></returns>
        ILeaveRequestListView CreateLeaveRequestListView(IList<ILeaveRequestModel> leaveRequestCollection, IList<ILeaveStatus> leaveStatusCollection, string processingMessage);
        /// <summary>
        /// Creates the leave request creation view.
        /// </summary>
        /// <param name="viewModelData">The view model data.</param>
        /// <returns></returns>
        ILeaveRequestViewModel CreateLeaveRequestCreationView(IEmployee employee, IGrade grade, IList<ILeaveType> leaveTypeCollection, IList<ILeaveStatus> leaveStatusCollection, string processingMessage);
        /// <summary>
        /// Creates the selected leave request view.
        /// </summary>
        /// <param name="leaveRequestInfo">The leave request information.</param>
        /// <param name="viewModelData">The view model data.</param>
        /// <returns></returns>

        ILeaveRequestViewModel CreateSelectedLeaveRequestView(ILeaveRequestModel leaveRequestInfo, IEmployee employee, IGrade grade,
        ILeaveType leaveType, IList<ILeaveType> leaveTypeCollection, IList<ILeaveStatus> leaveStatusCollection, string processingMessage);

        /// <summary>
        /// Creates the leave request update view.
        /// </summary>
        /// <param name="leaveRequestInfo">The leave request information.</param>
        /// <param name="viewModelData">The view model data.</param>
        /// <returns></returns>
        ILeaveRequestViewModel CreateLeaveRequestUpdateView(ILeaveRequestViewModel leaveRequestInfo, Hashtable viewModelData);
    }
}
