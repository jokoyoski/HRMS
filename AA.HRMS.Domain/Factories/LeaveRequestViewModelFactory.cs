using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;
using AA.HRMS.Domain.Utilities;
using AA.HRMS.Domain.Models;

namespace AA.HRMS.Domain.Factories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.ILeaveRequestViewModelFactory" />
    public class LeaveRequestViewModelFactory : ILeaveRequestViewModelFactory
    {

        public ILeaveRequestListView CreateLeaveRequestList(IList<ILeaveRequestModel> leaveRequestCollection, IEmployee employee, ICompanyDetail company, int employeeId, string processingMessage)
        {

            
            var ViewModel = new LeaveRequestListView
            {


                LeaveRequestCollection = leaveRequestCollection,
                employeeId = employeeId,
                ProcessingMessage = processingMessage,
                Employee = employee,
                Company = company
            };
            return ViewModel;
        }

        /// <summary>
        /// Creates the leave request ListView.
        /// </summary>
        /// <param name="leaveRequestCollection">The leave request collection.</param>
        /// <param name="listViewData">The list view data.</param>
        /// <returns></returns>
        public ILeaveRequestListView CreateLeaveRequestListView(IList<ILeaveRequestModel> leaveRequestCollection,  IList<ILeaveStatus> leaveStatusCollection, string processingMessage)
        {
             

            // prepare the leaveStatus drop down and filter the list
            var filteredList = leaveRequestCollection;

            //Get drop down for Leave Status
            var leaveStatusDDL = GetDropDownList.LeaveStatusListItems(leaveStatusCollection, -1);
            

            // prepare the view model
            var viewModel = new LeaveRequestListView
            {
                LeaveRequestCollection = filteredList,
                LeaveStatusDropDown = leaveStatusDDL,
                ProcessingMessage = processingMessage
            };

            return viewModel;

        }
        /// <summary>
        /// Creates the leave request creation view.
        /// </summary>
        /// <param name="viewModelData">The view model data.</param>
        /// <returns></returns>
        public ILeaveRequestViewModel CreateLeaveRequestCreationView(IEmployee employee, IGrade grade, IList<ILeaveType> leaveTypeCollection, IList<ILeaveStatus> leaveStatusCollection, string processingMessage)
        {
            // Extract relevant data from the view


            var leaveTypeDDL = GetDropDownList.LeaveTypeListItems(leaveTypeCollection, -1);
            var leaveStatusDDL = GetDropDownList.LeaveStatusListItems(leaveStatusCollection, -1);

            var viewModel = new LeaveRequestViewModel
            {
                ProcessingMessage = processingMessage,
                LeaveTypeDropDown = leaveTypeDDL,
                LeaveStatusDropDown = leaveStatusDDL,
                EmployeeID = employee.EmployeeId,
                DateRequested = DateTime.Now,
                DateCreated = DateTime.Now,
                AnnualLeaveDuration = grade.AnnualLeaveDuration,
                CompanyId = employee.CompanyId
                
            };

            return viewModel;
        }
        /// <summary>
        /// Creates the selected leave request view.
        /// </summary>
        /// <param name="leaveRequestInfo">The leave request information.</param>
        /// <param name="viewModelData">The view model data.</param>
        /// <returns></returns>
        public ILeaveRequestViewModel CreateSelectedLeaveRequestView(ILeaveRequestModel leaveRequestInfo, IEmployee employee, IGrade grade,
            ILeaveType leaveType, IList<ILeaveType> leaveTypeCollection, IList<ILeaveStatus> leaveStatusCollection, string processingMessage)
        {
            
            var leaveTypeDDL = GetDropDownList.LeaveTypeListItems(leaveTypeCollection, leaveRequestInfo.LeaveTypeId);
            var leaveStatusDDL = GetDropDownList.LeaveStatusListItems(leaveStatusCollection, leaveRequestInfo.LeaveStatusId);

            var viewModel = new LeaveRequestViewModel
            {
                ProcessingMessage = processingMessage,
                LeaveTypeDropDown = leaveTypeDDL,
                LeaveStatusDropDown = leaveStatusDDL,

                LeaveID = leaveRequestInfo.LeaveId,
                EmployeeID = leaveRequestInfo.EmployeeId,
                LeaveTypeID = leaveRequestInfo.LeaveTypeId,
                DateLeaveStart = leaveRequestInfo.DateLeaveStart,
                DateLeaveEnds = leaveRequestInfo.DateLeaveEnds,
                Comment = leaveRequestInfo.Comment,
                LeaveStatusID = leaveRequestInfo.LeaveStatusId,
                DateRequested = leaveRequestInfo.DateRequested,
                ApprovingAuthorityID = leaveRequestInfo.ApprovingAuthorityId,
                HRApproverID = leaveRequestInfo.HRApproverId,
                ApprovingAuthorityComment = leaveRequestInfo.ApprovingAuthorityComment,
                HRApproverComment = leaveRequestInfo.HRApproverComment,
                DateApprovedDept = leaveRequestInfo.DateApprovedDept,
                DateApprovedHR = leaveRequestInfo.DateApprovedHR,
                DateCreated = leaveRequestInfo.DateCreated,
                LeaveType = leaveType,
                EmployeeName = employee.LastName + " " + employee.FirstName,
                LeaveStatusName = leaveRequestInfo.LeaveStatusName,
                LeaveTypeName = leaveRequestInfo.LeaveTypeName,
                CompanyId = leaveRequestInfo.CompanyId,

                AnnualLeaveDuration = grade.AnnualLeaveDuration,
                Grade = grade

                
            };

            return viewModel;
        }
        /// <summary>
        /// Creates the leave request update view.
        /// </summary>
        /// <param name="leaveRequestInfo">The leave request information.</param>
        /// <param name="viewModelData">The view model data.</param>
        /// <returns></returns>
        public ILeaveRequestViewModel CreateLeaveRequestUpdateView(ILeaveRequestViewModel leaveRequestInfo, Hashtable viewModelData)
        {
            // Extract relevant data from the viewModelData
            var leaveTypeCollection = viewModelData["leaveTypeCollection"] as List<ILeaveType>;
            var leaveStatusCollection = viewModelData["leaveStatusCollection"] as List<ILeaveStatus>;
            var processingMessage = (string)viewModelData["processingMessage"];
            var employeeName = (string)viewModelData["employeeName"];
            var approvingAuthorityName = (string)viewModelData["approvingAuthorityName"];
            var hrApproverName = (string)viewModelData["hrApproverName"];
            var leaveStatusName = (string)viewModelData["leaveStatusName"];
            var leaveTypeName = (string)viewModelData["leaveTypeName"];
            var annualLeaveDuration = (int)viewModelData["annualLeaveDuration"];
            var employeeId = (int)viewModelData["employeeId"];

            // Get the dropdown list items
            var leaveTypeDDL = GetDropDownList.LeaveTypeListItems(leaveTypeCollection, leaveRequestInfo.LeaveTypeID);
            var leaveStatusDDL = GetDropDownList.LeaveStatusListItems(leaveStatusCollection, leaveRequestInfo.LeaveStatusID);

            var viewModel = new LeaveRequestViewModel
            {
                ProcessingMessage = processingMessage,
                LeaveTypeDropDown = leaveTypeDDL,
                LeaveStatusDropDown = leaveStatusDDL,

                LeaveID = leaveRequestInfo.LeaveID,
                EmployeeID = leaveRequestInfo.EmployeeID,
                LeaveTypeID = leaveRequestInfo.LeaveTypeID,
                DateLeaveStart = leaveRequestInfo.DateLeaveStart,
                DateLeaveEnds = leaveRequestInfo.DateLeaveEnds,
                Comment = leaveRequestInfo.Comment,
                LeaveStatusID = leaveRequestInfo.LeaveStatusID,
                DateRequested = leaveRequestInfo.DateRequested,
                ApprovingAuthorityID = leaveRequestInfo.ApprovingAuthorityID,
                HRApproverID = leaveRequestInfo.HRApproverID,
                ApprovingAuthorityComment = leaveRequestInfo.ApprovingAuthorityComment,
                HRApproverComment = leaveRequestInfo.HRApproverComment,
                DateApprovedDept = leaveRequestInfo.DateApprovedDept,
                DateApprovedHR = leaveRequestInfo.DateApprovedHR,
                DateCreated = leaveRequestInfo.DateCreated,

                EmployeeName = employeeName,
                ApprovingAuthorityName = approvingAuthorityName,
                HRApproverName = hrApproverName,
                LeaveStatusName = leaveStatusName,
                LeaveTypeName = leaveTypeName, 
                AnnualLeaveDuration = annualLeaveDuration
            };

            return viewModel;
        }
    }
}
