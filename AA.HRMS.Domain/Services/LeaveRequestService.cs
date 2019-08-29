using System;
using System.Collections.Generic;
using AA.HRMS.Interfaces;
using AA.Infrastructure.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using System.Collections;

namespace AA.HRMS.Domain.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveRepository leaveRepository;
        private readonly ILeaveRequestViewModelFactory leaveRequestViewModelFactory;
        private readonly IUsersRepository usersRepository;
        private readonly ISessionStateService session;
        private readonly IEmployeeOnBoardRepository employeeRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IGradeRepository gradeRepository;
        private readonly ILookupRepository lookupRepository;


        public LeaveRequestService(ILeaveRepository leaveRepository, ILeaveRequestViewModelFactory leaveRequestViewModelFactory,
          IUsersRepository usersRepository, ICompanyRepository companyRepository,
          ISessionStateService session, ILookupRepository lookupRepository,
          IEmployeeOnBoardRepository employeeRepository,
          IGradeRepository gradeRepository)
        {
            this.leaveRepository = leaveRepository;
            this.leaveRequestViewModelFactory = leaveRequestViewModelFactory;
            this.usersRepository = usersRepository;
            this.session = session;
            this.employeeRepository = employeeRepository;
            this.companyRepository = companyRepository;
            this.gradeRepository = gradeRepository;
            this.lookupRepository = lookupRepository;
        }

        /// <summary>
        /// Gets the leave request ListView for employee.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ILeaveRequestListView GetLeaveRequestListViewForEmployee(string message)
        {
            // get the user that's logged in
            var currentUserId = (int)session.GetSessionValue(SessionKey.UserId);

            var currentUser = usersRepository.GetUserById(currentUserId);
            
            // use the current user's email to get their employee record
            var employeeInfo = this.employeeRepository.GetEmployeeByEmail(currentUser.Email);

            var companyInfo = this.companyRepository.GetCompanyById(employeeInfo.CompanyId);

            var leaveInfo = this.leaveRepository.GetLeaveRequestByEmployeeId(employeeInfo.EmployeeId);

            var viewModel = this.leaveRequestViewModelFactory.CreateLeaveRequestList(leaveInfo, employeeInfo, companyInfo, employeeInfo.EmployeeId, message);
            return viewModel;
        }

        /// <summary>
        /// Gets the leave request ListView for employee.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ILeaveRequestListView GetLeaveRequestListViewForEmployee(int employeeId, string message)
        {
            // get the user that's logged in
            var currentUserId = (int)session.GetSessionValue(SessionKey.UserId);

            var currentUser = usersRepository.GetUserById(currentUserId);

            // use the current user's email to get their employee record
            var employeeInfo = this.employeeRepository.GetOnBoarderById(employeeId);

            var companyInfo = this.companyRepository.GetCompanyById(employeeInfo.CompanyId);

            var leaveInfo = this.leaveRepository.GetLeaveRequestByEmployeeId(employeeId);

            var viewModel = this.leaveRequestViewModelFactory.CreateLeaveRequestList(leaveInfo, employeeInfo, companyInfo, employeeInfo.EmployeeId, message);
            return viewModel;
        }

        /// <summary>
        /// Gets the leave request ListView for hr admin.
        /// </summary>
        /// <param name="leaveStatusId">The leave status identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ILeaveRequestListView GetLeaveRequestListViewForHRAdmin(int leaveStatusId, string message)
        {
            // get the user that's logged in
            var currentUserId = (int)session.GetSessionValue(SessionKey.UserId);


            return GetLeaveRequestListViewForHRAdmin(currentUserId, leaveStatusId, message);
        }

        /// <summary>
        /// Gets the leave request ListView for supervisor.
        /// </summary>
        /// <param name="leaveStatusId">The leave status identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ILeaveRequestListView GetLeaveRequestListViewForSupervisor(int leaveStatusId, string message)
        {
            // get the user that's logged in
            var currentUserId = (int)session.GetSessionValue(SessionKey.UserId);

            var currentUser = usersRepository.GetUserById(currentUserId);

            // use the current user's email to get their employee record
            var currentEmployee = employeeRepository.GetEmployeeByEmail(currentUser.Email);

            return GetLeaveRequestListViewForSupervisor(currentEmployee.EmployeeId, leaveStatusId, message);
        }

        /// <summary>
        /// Gets the leave request ListView for employee.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="leaveStatusId">The leave status identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ILeaveRequestListView GetLeaveRequestListViewForEmployee(int employeeId, int leaveStatusId, string message)
        {

            var leaveStatusCollection = leaveRepository.GetLeaveStatusList();

            var leaveRequestCollection = leaveRepository.GetLeaveRequestByEmployeeId(employeeId);

            var employeeInfo = this.employeeRepository.GetOnBoarderById(employeeId);

            var leaveRequestViewModelCollection = this.leaveRepository.GetLeaveRequestByCompanyId(employeeInfo.CompanyId);

            var viewModel = leaveRequestViewModelFactory.CreateLeaveRequestListView(leaveRequestViewModelCollection, leaveStatusCollection, message);

            return viewModel;
        }

        /// <summary>
        /// Gets the leave request ListView for hr admin.
        /// </summary>
        /// <param name="hrUserId">The hr user identifier.</param>
        /// <param name="leaveStatusId">The leave status identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ILeaveRequestListView GetLeaveRequestListViewForHRAdmin(int hrUserId, int leaveStatusId, string message)
        {

            var leaveStatusCollection = leaveRepository.GetLeaveStatusList();

            var companyInSession = (int)this.session.GetSessionValue(SessionKey.CompanyId);

            var leaveRequestCollection = leaveRepository.GetLeaveRequestByHrAdminId(hrUserId, companyInSession);

            var hrInformation = this.employeeRepository.GetOnBoarderById(hrUserId);

            var leaveRequestViewModelCollection = this.leaveRepository.GetLeaveRequestByCompanyId(hrInformation.CompanyId);


            var viewModel = leaveRequestViewModelFactory.CreateLeaveRequestListView(leaveRequestCollection, leaveStatusCollection, message);

            return viewModel;
        }

        /// <summary>
        /// Gets the leave request ListView for supervisor.
        /// </summary>
        /// <param name="supervisorId">The supervisor identifier.</param>
        /// <param name="leaveStatusId">The leave status identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ILeaveRequestListView GetLeaveRequestListViewForSupervisor(int supervisorId, int leaveStatusId, string message)
        {

            var supervisorInfo = this.employeeRepository.GetOnBoarderById(supervisorId);

            var leaveStatusCollection = leaveRepository.GetLeaveStatusList();

            var leaveRequestCollection = leaveRepository.GetLeaveRequestByEmployeeSupervisorId(supervisorId);

            var leaveRequestViewModelCollection = this.leaveRepository.GetLeaveRequestByCompanyId(supervisorInfo.CompanyId);

            var viewModel = leaveRequestViewModelFactory.CreateLeaveRequestListView(leaveRequestCollection, leaveStatusCollection, message);

            return viewModel;
        }

        /// <summary>
        /// Gets the leave employee request create view.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ILeaveRequestViewModel GetLeaveRequestCreateViewForHR(int employeeId, string message)
        {
            var currentUser = usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));
            
            var employee = employeeRepository.GetOnBoarderById(employeeId); 

            var employeeGrade = gradeRepository.GetGradeById(employee.GradeId);
            
            var companyCollection = this.companyRepository.GetMyCompanies(employee.CompanyId);

            var leaveTypeCollection = new List<ILeaveType>();

            foreach (var item in companyCollection)
            {
                leaveTypeCollection.AddRange(leaveRepository.GetLeaveTypeListForCompanyId(item.CompanyId));
            }

            var leaveStatusCollection = leaveRepository.GetLeaveStatusList();
            

            var viewModel = leaveRequestViewModelFactory.CreateLeaveRequestCreationView(employee, employeeGrade, leaveTypeCollection, leaveStatusCollection, message);

            return viewModel;
        }

        /// <summary>
        /// Gets the leave request create view.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ILeaveRequestViewModel GetLeaveRequestCreateView(string message)
        {
            var currentUser = usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            // use the current user's email to get their employee record
            var currentEmployee = employeeRepository.GetEmployeeByEmail(currentUser.Email);

            var currentEmployeeGrade = gradeRepository.GetGradeById(currentEmployee.GradeId); 

            var companyCollection = this.companyRepository.GetCompaniesForHR(currentUser.Username);

            var leaveTypeCollection = new List<ILeaveType>();

            foreach (var item in companyCollection)
            {
                leaveTypeCollection.AddRange(leaveRepository.GetLeaveTypeListForCompanyId(currentUser.CompanyId));
            }

            var leaveStatusCollection = leaveRepository.GetLeaveStatusList();
            

            var viewModel = leaveRequestViewModelFactory.CreateLeaveRequestCreationView(currentEmployee, currentEmployeeGrade, leaveTypeCollection, leaveStatusCollection, message);

            return viewModel;
        }

        /// <summary>
        /// Gets the selected leave request view.
        /// </summary>
        /// <param name="leaveRequestId">The leave request identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">leaveRequestInfo</exception>
        public ILeaveRequestViewModel GetSelectedLeaveRequestView(int leaveRequestId, string message)
        {

            var loggedInUser = (int)session.GetSessionValue(SessionKey.UserId);

            // get the selected leave request
            var leaveRequestInfo = leaveRepository.GetLeaveRequestDetails(leaveRequestId);

            leaveRequestInfo.HRApproverId = loggedInUser;

            if (leaveRequestInfo == null)
            {
                throw new ArgumentNullException(nameof(leaveRequestInfo));
            }
            
            var leaveStatusCollection = leaveRepository.GetLeaveStatusList();

            var employee = employeeRepository.GetOnBoarderById(leaveRequestInfo.EmployeeId);

            var employeeGrade = gradeRepository.GetGradeById(employee.GradeId); 

            var leaveTypeCollection = leaveRepository.GetLeaveTypeListForCompanyId(employee.CompanyId);
            
            var leaveType = leaveRepository.GetLeaveTypeById(leaveRequestInfo.LeaveTypeId);
            
            
            var viewModel = leaveRequestViewModelFactory.CreateSelectedLeaveRequestView(leaveRequestInfo, employee, employeeGrade, leaveType, leaveTypeCollection,
                leaveStatusCollection, message);
            return viewModel;
        }

        /// <summary>
        /// Gets the leave request update view.
        /// </summary>
        /// <param name="leaveRequestInfo">The leave request information.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">leaveRequestInfo</exception>
        public ILeaveRequestViewModel GetLeaveRequestUpdateView(ILeaveRequestViewModel leaveRequestInfo, string message)
        {
            if (leaveRequestInfo == null)
            {
                throw new ArgumentNullException(nameof(leaveRequestInfo));
            }

            // get necessary data to build the view model for this leave request
            var viewModelData = new Hashtable();

            viewModelData.Add("processingMessage", message);
            var leaveStatusCollection = leaveRepository.GetLeaveStatusList();
            viewModelData.Add("leaveStatusCollection", leaveStatusCollection);

            var employee = employeeRepository.GetOnBoarderById(leaveRequestInfo.EmployeeID);
            var employeeGrade = gradeRepository.GetGradeById(employee.GradeId); 

            var leaveTypeCollection = leaveRepository.GetLeaveTypeListForCompanyId(employee.CompanyId);
            viewModelData.Add("leaveTypeCollection", leaveTypeCollection);

            viewModelData.Add("employeeId", employee.EmployeeId);

            viewModelData.Add("employeeName", employee.FirstName + " " + employee.LastName);
            viewModelData.Add("hrApproverName", null);
            viewModelData.Add("approvingAuthorityName", null);
            viewModelData.Add("annualLeaveDuration", employeeGrade.AnnualLeaveDuration);

            if (leaveRequestInfo.HRApproverID != null)
            {
                int hrApproverId = leaveRequestInfo.HRApproverID ?? -1;

                var hrApprover = usersRepository.GetUserById(hrApproverId);
                viewModelData["hrApproverName"] = hrApprover.FirstName + " " + hrApprover.LastName;
            }

            if (leaveRequestInfo.ApprovingAuthorityID != null)
            {
                int approvingAuthorityId = leaveRequestInfo.HRApproverID ?? -1;

                var approvingAuthority = employeeRepository.GetOnBoarderById(approvingAuthorityId);

                viewModelData["approvingAuthorityName"] = approvingAuthority.FirstName + " " + approvingAuthority.LastName;
            }

            var viewModel = leaveRequestViewModelFactory.CreateLeaveRequestUpdateView(leaveRequestInfo, viewModelData);

            return viewModel;

        }

        /// <summary>
        /// Processes the leave request create.
        /// </summary>
        /// <param name="leaveRequestInfo">The leave request information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">leaveRequestInfo</exception>
        public string ProcessLeaveRequestCreate(ILeaveRequestViewModel leaveRequestInfo)
        {
            if (leaveRequestInfo == null)
            {
                throw new ArgumentNullException(nameof(leaveRequestInfo));
            }

            string processingMessage = string.Empty;

            //This date setting segment might end up being removed
            //Because I repeated it again in the view model factory
            //And I've not yet decided where it should stay, so it's in both for now
            leaveRequestInfo.DateRequested = DateTime.Now;
            leaveRequestInfo.DateCreated = DateTime.Now;

            var leaveData = this.leaveRepository.GetLatestLeaveRequestByEmployeeId(leaveRequestInfo.EmployeeID);

            

            //if (leaveData != null)
            //{
            //    if ((leaveData.DateLeaveEnds - leaveData.DateLeaveStart).TotalDays > 0 && leaveData.LeaveStatusId == 1)
            //    {
            //        processingMessage = Messages.LeaveRunning;


            //        return processingMessage;
            //    }

            //    if (leaveData.LeaveStatusId == 3)
            //    {
            //        processingMessage = Messages.LeavePending;


            //        return processingMessage;
            //    }

            //}
            
                

            processingMessage = leaveRepository.SaveLeaveRequestInfo(leaveRequestInfo);


            return processingMessage;
        }

        /// <summary>
        /// Processes the leave request approval status change hr.
        /// </summary>
        /// <param name="leaveRequestInfo">The leave request information.</param>
        /// <returns></returns>
        public string ProcessLeaveRequestApprovalStatusChangeHr(ILeaveRequestViewModel leaveRequestInfo)
        {
            // get the user that's logged in...this user should ideally be the Hr admin for the company
            var currentUserId = (int)session.GetSessionValue(SessionKey.UserId);

            return ProcessLeaveRequestApprovalStatusChange(leaveRequestInfo, currentUserId);
        }

        /// <summary>
        /// Processes the leave request approval status change supervisor.
        /// </summary>
        /// <param name="leaveRequestInfo">The leave request information.</param>
        /// <returns></returns>
        public string ProcessLeaveRequestApprovalStatusChangeSupervisor(ILeaveRequestViewModel leaveRequestInfo)
        {
            // get the user that's logged in...this user should ideally be the supervisor
            var currentUserId = (int)session.GetSessionValue(SessionKey.UserId);

            var currentUser = usersRepository.GetUserById(currentUserId);

            // use the current user's email to get their employee record
            var currentEmployee = employeeRepository.GetEmployeeByEmail(currentUser.Email);

            return ProcessLeaveRequestApprovalStatusChange(leaveRequestInfo, supervisorId: currentEmployee.EmployeeId);
        }

        /// <summary>
        /// Processes the leave request approval status change.
        /// </summary>
        /// <param name="leaveRequestInfo">The leave request information.</param>
        /// <param name="hrUserId">The hr user identifier.</param>
        /// <param name="supervisorId">The supervisor identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">leaveRequestInfo</exception>
        public string ProcessLeaveRequestApprovalStatusChange(ILeaveRequestViewModel leaveRequestInfo, int hrUserId = -1, int supervisorId = -1)
        {

            if (leaveRequestInfo == null)
            {
                throw new ArgumentNullException(nameof(leaveRequestInfo));

            }
            if (hrUserId >= 0)
            {
                leaveRequestInfo.HRApproverID = hrUserId;
                leaveRequestInfo.DateApprovedHR = DateTime.Now;
            }

            else if (supervisorId >= 0)
            {
                leaveRequestInfo.ApprovingAuthorityID = supervisorId;
                leaveRequestInfo.DateApprovedDept = DateTime.Now;
            }

            var processingMessage = leaveRepository.UpdateLeaveRequestInfo(leaveRequestInfo);

            return processingMessage;
        }

        /// <summary>
        /// Gets the type of the duration by leave.
        /// </summary>
        /// <param name="leaveTypeId">The leave type identifier.</param>
        /// <returns></returns>
        public int GetDurationByLeaveType(int leaveTypeId)
        {
            var leaveType = leaveRepository.GetLeaveTypeById(leaveTypeId);
            return leaveType.Duration;
        }
    }
}
