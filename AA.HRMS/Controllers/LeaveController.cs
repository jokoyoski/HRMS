using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AA.HRMS.Domain.Attributes;
using AA.HRMS.Interfaces;
using AA.HRMS.Domain.Models; 
using AA.Infrastructure.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;

namespace AA.HRMS.Controllers
{
    [Authorize]
    [CheckUserLogin]
    public class LeaveController : Controller
    {
        private readonly ILeaveRequestService leaveRequestService;

        public LeaveController(ILeaveRequestService leaveRequestService)
        {
            this.leaveRequestService = leaveRequestService;
        }

        #region //=========================================LEAVE REQUESTS===================================================//
        
        /// <summary>
        /// Lists the of leave requests for employee.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult ListOfLeaveRequestsForEmployee(int employeeId, string message )
        {

            var viewModel = leaveRequestService.GetLeaveRequestListViewForEmployee(employeeId, message);

            viewModel.URL = "/Leave/ListOfLeaveRequestsForEmployee?employeeId=" + employeeId;

            return this.View("ListOfLeaveRequestsForEmployee", viewModel);
        }

        /// <summary>
        /// Lists the of leave requests for employee.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult ListOfLeaveRequestsEmployee(string message)
        {
            var viewModel = leaveRequestService.GetLeaveRequestListViewForEmployee(message);

            viewModel.URL = "/Leave/ListOfLeaveRequestsEmployee";

            return this.View("ListOfLeaveRequestsForEmployee", viewModel);
        }

        /// <summary>1`11````````
        /// Creates the leave request.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateLeaveRequest(string message = "")
        {

            var viewModel = leaveRequestService.GetLeaveRequestCreateView(message);

            return PartialView("CreateLeaveRequest", viewModel); 
        }

        /// <summary>
        /// Creates the leave request.
        /// </summary>
        /// <param name="leaveRequestInfo">The leave request information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">leaveRequestInfo</exception>
        [HttpPost]
        public ActionResult CreateLeaveRequest(LeaveRequestViewModel leaveRequestInfo)
        {
            if (leaveRequestInfo == null)
            {
                throw new ArgumentNullException(nameof(leaveRequestInfo));
            }

            //Check Model State
            if (!ModelState.IsValid)
            {
                var model = leaveRequestService.GetLeaveRequestUpdateView(leaveRequestInfo, string.Empty);

                return this.View("CreateLeaveRequest", model);
            }

            var processingMessage = leaveRequestService.ProcessLeaveRequestCreate(leaveRequestInfo);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = leaveRequestService.GetLeaveRequestUpdateView(leaveRequestInfo, processingMessage);

                return this.View("CreateLeaveRequest", model);
            }

            var returnMessage = string.Format("You've create a new leave request");

            return Redirect(leaveRequestInfo.URL); 

        }

        /// <summary>
        /// Views the leave request employee.
        /// </summary>
        /// <param name="leaveRequestId">The leave request identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">leaveRequestId</exception>
        [HttpGet]
        public ActionResult ViewLeaveRequestEmployee(int leaveRequestId)
        {
            if(leaveRequestId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(leaveRequestId)); 
            }
            
            var viewModel = leaveRequestService.GetSelectedLeaveRequestView(leaveRequestId, "");

            return PartialView("ViewLeaveRequestEmployee", viewModel); 
        }

        #endregion
        
        #region //==========================HR ADMIN VIEWS============================//     
        
        /// <summary>
        /// Lists the of leave requests for hr admin.
        /// </summary>
        /// <param name="leaveStatusId">The leave status identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult ListOfLeaveRequestsForHRAdmin(int? leaveStatusId, string message = "")
        {

            var viewModel = leaveRequestService.GetLeaveRequestListViewForHRAdmin(leaveStatusId ?? -1, message);

            viewModel.URL = "/Leave/ListOfLeaveRequestsForHRAdmin";

            return View("HRLeaveRequestListView", viewModel);
        }
        
        /// <summary>
        /// Creates the leave request hr.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateLeaveRequestHR(int employeeId, string url, string message = "")
        {
            
            var viewModel = leaveRequestService.GetLeaveRequestCreateViewForHR(employeeId, message);

            viewModel.URL = url;

            return PartialView("CreateLeaveRequestHR", viewModel);
        }
        
        /// <summary>
        /// Changes the leave request approval status hr.
        /// </summary>
        /// <param name="leaveRequestId">The leave request identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">leaveRequestId</exception>
        [HttpGet]
        public ActionResult ChangeLeaveRequestApprovalStatusHR(int leaveRequestId, string url)
        {
            if (leaveRequestId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(leaveRequestId));
            }

            var viewModel = leaveRequestService.GetSelectedLeaveRequestView(leaveRequestId, "");

            viewModel.URL = url;

            return this.PartialView("HRLeaveRequestApproval", viewModel);
        }
        
        /// <summary>
        /// Changes the leave request approval status hr.
        /// </summary>
        /// <param name="leaveRequestInfo">The leave request information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">leaveRequestInfo</exception>
        [HttpPost]
        public ActionResult ChangeLeaveRequestApprovalStatusHR(LeaveRequestViewModel leaveRequestInfo)
        {
            if(leaveRequestInfo == null)
            {
                throw new ArgumentNullException(nameof(leaveRequestInfo)); 
            }

            //Check Model State
            if (!ModelState.IsValid)
            {
                var model = leaveRequestService.GetLeaveRequestUpdateView(leaveRequestInfo, string.Empty);

                return PartialView("ChangeLeaveRequestApprovalStatusHR", model);
            }

            var processingMessage = leaveRequestService.ProcessLeaveRequestApprovalStatusChangeHr(leaveRequestInfo);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = leaveRequestService.GetLeaveRequestUpdateView(leaveRequestInfo, string.Empty);

                return this.View("ChangeLeaveRequestApprovalStatusHR", model);
            }
            
            return Redirect(leaveRequestInfo.URL); 

        }

        /// <summary>
        /// Gets the type of the duration for leave.
        /// </summary>
        /// <param name="leaveTypeId">The leave type identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public int GetDurationForLeaveType(int leaveTypeId)
        {
            return leaveRequestService.GetDurationByLeaveType(leaveTypeId); 
        }

        #endregion
        
        

    }
}