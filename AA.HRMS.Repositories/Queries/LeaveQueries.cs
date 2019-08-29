using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Models;



namespace AA.HRMS.Repositories.Queries
{
    internal static class LeaveQueries
    {

        /// <summary>
        /// Gets the type of the leave.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<ILeaveType> GetLeaveType(HRMSEntities db)
        {
            var result = (from d in db.LeaveTypes

                          select new LeaveTypeModel
                          {
                              LeaveTypeID = d.LeaveTypeId,
                              LeaveTypeName = d.LeaveTypeName,
                              CompanyID = d.CompanyId,
                              DateCreated = d.DateCreated,
                              Description = d.Description,
                              IsActive = d.IsActive

                          }).OrderBy(x => x.LeaveTypeID);

            return result;
        }
        /// <summary>
        /// Gets the leave type by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="leaveTypeId">The leave type identifier.</param>
        /// <returns></returns>
        internal static ILeaveType getLeaveTypeById(HRMSEntities db, int leaveTypeId)
        {
            var result = (from a in db.LeaveTypes
                          where a.LeaveTypeId.Equals(leaveTypeId)
                          select new LeaveTypeModel
                          {
                              LeaveTypeID = a.LeaveTypeId,
                              CompanyID = a.CompanyId,
                              LeaveTypeName = a.LeaveTypeName,
                              Description = a.Description,
                              Duration = a.Duration,
                              IsActive = a.IsActive,
                              DateCreated = a.DateCreated

                          }).FirstOrDefault();
            return result;
        }

        internal static ILeaveType getLeaveTypeByName(HRMSEntities db, string leaveTypeName, int compampyId)
        {
            var result = (from a in db.LeaveTypes
                          where a.LeaveTypeName.Equals(leaveTypeName) && a.CompanyId == compampyId
                          select new LeaveTypeModel
                          {
                              LeaveTypeID = a.LeaveTypeId,
                              CompanyID = a.CompanyId,
                              LeaveTypeName = a.LeaveTypeName,
                              Description = a.Description,
                              Duration = a.Duration,
                              IsActive = a.IsActive,
                              DateCreated = a.DateCreated

                          }).FirstOrDefault();
            return result;
        }
        /// <summary>
        /// Gets the leave type by company identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<ILeaveType> GetLeaveTypeByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.LeaveTypes
                          where d.CompanyId.Equals(companyId) && d.IsActive.Equals(true)
                          select new LeaveTypeModel
                          {
                              LeaveTypeID = d.LeaveTypeId,
                              LeaveTypeName = d.LeaveTypeName,
                              CompanyID = d.CompanyId,
                              DateCreated = d.DateCreated,
                              Description = d.Description,
                              IsActive = d.IsActive
                          }).Where(x => x.IsActive == true).OrderBy(x => x.LeaveTypeID);

            return result;
        }

        /// <summary>
        /// Gets the pending leave request by company identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<ILeaveRequestModel> getPendingLeaveRequestByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.LeaveRequests
                          join w in db.Companies on d.CompanyID equals w.CompanyId
                          join z in db.LeaveStatus on d.LeaveStatusID equals z.LeaveStatusId
                          where d.EmployeeID.Equals(companyId) && d.IsActive.Equals(true) && d.LeaveStatusID.Equals(3)
                          select new LeaveRequestModel
                          {
                              LeaveId = d.LeaveID,
                              EmployeeId = d.EmployeeID,
                              LeaveTypeId = d.LeaveTypeID,
                              DateLeaveStart = d.DateLeaveStart,
                              DateLeaveEnds = d.DateLeaveEnds,
                              Comment = d.Comment,
                              LeaveStatusId = d.LeaveStatusID,
                              DateRequested = d.DateRequested,
                              ApprovingAuthorityId = d.ApprovingAuthorityID,
                              HRApproverId = d.HRApproverID,
                              DateApprovedDept = d.DateApprovedDept,
                              DateCreated = d.DateCreated,
                              DateApprovedHR = d.DateApprovedHR,
                              CompanyName = w.CompanyName,

                          }).OrderBy(x => x.LeaveId);

            return result;
        }

        internal static IEnumerable<ILeaveRequestModel> getLeaveRequestByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.LeaveRequests
                          join w in db.Companies on d.CompanyID equals w.CompanyId
                          join z in db.LeaveStatus on d.LeaveStatusID equals z.LeaveStatusId
                          where d.EmployeeID.Equals(companyId) && d.IsActive.Equals(true)
                          select new LeaveRequestModel
                          {
                              LeaveId = d.LeaveID,
                              EmployeeId = d.EmployeeID,
                              LeaveTypeId = d.LeaveTypeID,
                              DateLeaveStart = d.DateLeaveStart,
                              DateLeaveEnds = d.DateLeaveEnds,
                              Comment = d.Comment,
                              LeaveStatusId = d.LeaveStatusID,
                              DateRequested = d.DateRequested,
                              ApprovingAuthorityId = d.ApprovingAuthorityID,
                              HRApproverId = d.HRApproverID,
                              DateApprovedDept = d.DateApprovedDept,
                              DateCreated = d.DateCreated,
                              DateApprovedHR = d.DateApprovedHR,
                              CompanyName = w.CompanyName,

                          }).OrderBy(x => x.LeaveId);

            return result;
        }


        /// <summary>
        /// Gets the name of the leave status by.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="statusName">Name of the status.</param>
        /// <returns></returns>
        internal static ILeaveStatus GetLeaveStatusByName(HRMSEntities db, string statusName)
        {
            var result = (from d in db.LeaveStatus
                          where d.Description.Equals(statusName)
                          select new LeaveStatusModel
                          {
                              LeaveStatusId = d.LeaveStatusId,
                              Description = d.Description
                          }).FirstOrDefault();

            return result;
        }
        /// <summary>
        /// Gets the leave status by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="leaveStatusId">The leave status identifier.</param>
        /// <returns></returns>
        internal static ILeaveStatus GetLeaveStatusById(HRMSEntities db, int leaveStatusId)
        {
            var result = (from d in db.LeaveStatus
                          where d.LeaveStatusId.Equals(leaveStatusId)
                          select new LeaveStatusModel
                          {
                              LeaveStatusId = d.LeaveStatusId,
                              Description = d.Description
                          }).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Gets the leave status.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<ILeaveStatus> GetLeaveStatus(HRMSEntities db)
        {
            var result = (from d in db.LeaveStatus
                              //join e in db.LeaveTypes on d. equals e.LeaveTypeID
                              //join e in db.LeaveTypes on d.LeaveTypeID equals e.LeaveTypeID
                          select new LeaveStatusModel
                          {
                              LeaveStatusId = d.LeaveStatusId,
                              Description = d.Description


                          }).OrderBy(x => x.LeaveStatusId);

            return result;
        }


        //==============================================LEAVE REQUESTS==============================//
        /// <summary>
        /// Gets the leave request by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        internal static ILeaveRequestModel GetLeaveRequestById(HRMSEntities db, int id)
        {
            var result = (from d in db.LeaveRequests
                          join f in db.Employees on d.EmployeeID equals f.EmployeeId
                          join v in db.LeaveStatus on d.LeaveStatusID equals v.LeaveStatusId
                          join n in db.LeaveTypes on d.LeaveTypeID equals n.LeaveTypeId
                          where d.LeaveID.Equals(id)

                          select new LeaveRequestModel
                          {
                              LeaveId = d.LeaveID,
                              EmployeeId = d.EmployeeID,
                              LeaveTypeId = d.LeaveTypeID,
                              DateLeaveStart = d.DateLeaveStart,
                              DateLeaveEnds = d.DateLeaveEnds,
                              Comment = d.Comment,
                              LeaveStatusId = d.LeaveStatusID,
                              DateRequested = d.DateRequested,
                              ApprovingAuthorityId = d.ApprovingAuthorityID,
                              HRApproverId = d.HRApproverID,
                              ApprovingAuthorityComment = d.ApprovingAuthorityComment,
                              HRApproverComment = d.HRApproverComment,
                              DateApprovedDept = d.DateApprovedDept,
                              DateApprovedHR = d.DateApprovedHR,
                              DateCreated = d.DateCreated,
                              EmployeeName = f.LastName + " " + f.FirstName,
                              LeaveStatusName = v.Description,
                              LeaveTypeName = n.LeaveTypeName

                          }).FirstOrDefault();

            return result;
        }

        internal static IEnumerable<ILeaveRequestModel> GetLeaveRequestByEmployeeId(HRMSEntities db, int companyId, int employeeId)
        {
            var result = (from d in db.LeaveRequests
                          join e in db.LeaveTypes on d.LeaveTypeID equals e.LeaveTypeId
                          where d.EmployeeID.Equals(employeeId)
                          select new LeaveRequestModel
                          {
                              LeaveId = d.LeaveID,
                              EmployeeId = d.EmployeeID,
                              LeaveTypeId = d.LeaveTypeID,
                              DateLeaveStart = d.DateLeaveStart,
                              DateLeaveEnds = d.DateLeaveEnds,
                              Comment = d.Comment,
                              LeaveStatusId = d.LeaveStatusID,
                              DateRequested = d.DateRequested,
                              ApprovingAuthorityId = d.ApprovingAuthorityID,
                              HRApproverId = d.HRApproverID,
                              ApprovingAuthorityComment = d.ApprovingAuthorityComment,
                              HRApproverComment = d.HRApproverComment,
                              DateApprovedDept = d.DateApprovedDept,
                              DateApprovedHR = d.DateApprovedHR,
                              DateCreated = d.DateCreated

                          }).OrderByDescending(x => x.LeaveId);

            return result;
        }

        internal static ILeaveRequestModel GetLatestLeaveRequestByEmployeeId(HRMSEntities db, int employeeId)
        {
            var result = (from d in db.LeaveRequests
                          join e in db.LeaveTypes on d.LeaveTypeID equals e.LeaveTypeId
                          where d.EmployeeID.Equals(employeeId)
                          select new LeaveRequestModel
                          {
                              LeaveId = d.LeaveID,
                              EmployeeId = d.EmployeeID,
                              LeaveTypeId = d.LeaveTypeID,
                              DateLeaveStart = d.DateLeaveStart,
                              DateLeaveEnds = d.DateLeaveEnds,
                              Comment = d.Comment,
                              LeaveStatusId = d.LeaveStatusID,
                              DateRequested = d.DateRequested,
                              ApprovingAuthorityId = d.ApprovingAuthorityID,
                              HRApproverId = d.HRApproverID,
                              ApprovingAuthorityComment = d.ApprovingAuthorityComment,
                              HRApproverComment = d.HRApproverComment,
                              DateApprovedDept = d.DateApprovedDept,
                              DateApprovedHR = d.DateApprovedHR,
                              DateCreated = d.DateCreated

                          }).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Gets the list of leave requests.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<ILeaveRequestModel> GetLeaveRequest(HRMSEntities db)
        {
            var result = (from d in db.LeaveRequests
                          select new LeaveRequestModel
                          {
                              LeaveId = d.LeaveID,
                              EmployeeId = d.EmployeeID,
                              LeaveTypeId = d.LeaveTypeID,
                              DateLeaveStart = d.DateLeaveStart,
                              DateLeaveEnds = d.DateLeaveEnds,
                              Comment = d.Comment,
                              LeaveStatusId = d.LeaveStatusID,
                              DateRequested = d.DateRequested,
                              ApprovingAuthorityId = d.ApprovingAuthorityID,
                              HRApproverId = d.HRApproverID,
                              ApprovingAuthorityComment = d.ApprovingAuthorityComment,
                              HRApproverComment = d.HRApproverComment,
                              DateApprovedDept = d.DateApprovedDept,
                              DateApprovedHR = d.DateApprovedHR,
                              DateCreated = d.DateCreated,
                             

                          }).OrderByDescending(x => x.DateCreated);

            return result;
        }

        internal static IEnumerable<ILeaveRequestModel> GetLeaveRequestByCompanyId(HRMSEntities db, int companyId)
        {
            var leaveRequests = (from d in db.LeaveRequests
                                 join e in db.Employees on d.EmployeeID equals e.EmployeeId
                                 join r in db.LeaveTypes on d.LeaveTypeID equals r.LeaveTypeId
                                 join y in db.LeaveStatus on d.LeaveStatusID equals y.LeaveStatusId
                                 where e.CompanyId.Equals(companyId)
                                 select new LeaveRequestModel
                                 {
                                     LeaveId = d.LeaveID,
                                     EmployeeId = d.EmployeeID,
                                     LeaveTypeId = d.LeaveTypeID,
                                     DateLeaveStart = d.DateLeaveStart,
                                     DateLeaveEnds = d.DateLeaveEnds,
                                     Comment = d.Comment,
                                     LeaveStatusId = d.LeaveStatusID,
                                     DateRequested = d.DateRequested,
                                     ApprovingAuthorityId = d.ApprovingAuthorityID,
                                     HRApproverId = d.HRApproverID,
                                     ApprovingAuthorityComment = d.ApprovingAuthorityComment,
                                     HRApproverComment = d.HRApproverComment,
                                     DateApprovedDept = d.DateApprovedDept,
                                     DateApprovedHR = d.DateApprovedHR,
                                     DateCreated = d.DateCreated,
                                     LeaveStatusName = y.Description,
                                     LeaveTypeName = r.LeaveTypeName,
                                     EmployeeName = e.LastName + " " + e.FirstName
                                     

                                 }).OrderByDescending(x => x.DateCreated);

            return leaveRequests;
        }

        internal static IEnumerable<ILeaveRequestModel> GetLeaveRequestByEmployeeId(HRMSEntities db, int employeeId)
        {
            var result = (from d in db.LeaveRequests
                          join s in db.Employees on d.EmployeeID equals s.EmployeeId
                          join q in db.LeaveStatus on d.LeaveStatusID equals q.LeaveStatusId
                          join w in db.LeaveTypes on d.LeaveTypeID equals w.LeaveTypeId
                          where d.EmployeeID.Equals(employeeId)
                          select new LeaveRequestModel
                          {
                              LeaveId = d.LeaveID,
                              EmployeeId = d.EmployeeID,
                              EmployeeName = s.FirstName + " " + s.LastName,
                              LeaveTypeId = d.LeaveTypeID,
                              LeaveTypeName = w.LeaveTypeName,
                              DateLeaveStart = d.DateLeaveStart,
                              DateLeaveEnds = d.DateLeaveEnds,
                              Comment = d.Comment,
                              LeaveStatusId = d.LeaveStatusID,
                              LeaveStatusName = q.Description,
                              DateRequested = d.DateRequested,
                              ApprovingAuthorityId = d.ApprovingAuthorityID,
                              HRApproverId = d.HRApproverID,
                              ApprovingAuthorityComment = d.ApprovingAuthorityComment,
                              HRApproverComment = d.HRApproverComment,
                              DateApprovedDept = d.DateApprovedDept,
                              DateApprovedHR = d.DateApprovedHR,
                              DateCreated = d.DateCreated
                          }).OrderByDescending(x => x.DateCreated);

            return result;
        }

        internal static IEnumerable<ILeaveRequestModel> GetLeaveRequestByHrAdminId(HRMSEntities db, int HrAdminId, int companyId)
        {
            /* This method will be used if we only have the HRAdmin Id available instead of the username. 
             * It will simply use the Id to retrieve the HR's username and then call the overload of this method that takes
             * the Hr's username
             */
            var hrUser = UserQueries.getUserById(db, HrAdminId);

           var leave =  GetLeaveRequestByCompanyId(db, companyId);

            return leave;
        }

        internal static IEnumerable<ILeaveRequestModel> GetLeaveRequestByHrAdminId(HRMSEntities db, string HrAdminUsername)
        {
            // Step 1: Get the company for this HR Admin.
            var companyInfo = CompanyQueries.getCompanyForHrAdmin(db, HrAdminUsername);

            // Step 2: Get the leave requests of employees in that company.
            var leaveRequests = GetLeaveRequestByCompanyId(db, companyInfo.CompanyId);

            return leaveRequests;

        }

        internal static IEnumerable<ILeaveRequestModel> GetLeaveRequestByEmployeeSupervisorId(HRMSEntities db, int supervisorId)
        {
            var leaveRequests = (from d in db.LeaveRequests
                                 join e in db.Employees
      on d.EmployeeID equals e.EmployeeId
                                 where e.SupervisorEmployeeId.Equals(supervisorId)
                                 select new LeaveRequestModel
                                 {
                                     LeaveId = d.LeaveID,
                                     EmployeeId = d.EmployeeID,
                                     LeaveTypeId = d.LeaveTypeID,
                                     DateLeaveStart = d.DateLeaveStart,
                                     DateLeaveEnds = d.DateLeaveEnds,
                                     Comment = d.Comment,
                                     LeaveStatusId = d.LeaveStatusID,
                                     DateRequested = d.DateRequested,
                                     ApprovingAuthorityId = d.ApprovingAuthorityID,
                                     HRApproverId = d.HRApproverID,
                                     ApprovingAuthorityComment = d.ApprovingAuthorityComment,
                                     HRApproverComment = d.HRApproverComment,
                                     DateApprovedDept = d.DateApprovedDept,
                                     DateApprovedHR = d.DateApprovedHR,
                                     DateCreated = d.DateCreated
                                 }).OrderByDescending(x => x.DateCreated);

            return leaveRequests;
        }

        internal static IEnumerable<ILeaveRequestModel> GetLeaveRequestByHrAdminIdWithChildCompanies(HRMSEntities db, int HrAdminId)
        {
            var hrUser = UserQueries.getUserById(db, HrAdminId);
            var companyIDsForHr = CompanyQueries.GetCompanyIDsForHRList(db, hrUser.Username);

            var leaveRequests = new List<ILeaveRequestModel>();

            foreach (int companyId in companyIDsForHr)
            {
                leaveRequests.AddRange(GetLeaveRequestByCompanyId(db, companyId).ToList());
            }

            return leaveRequests;
        }

    }
}
