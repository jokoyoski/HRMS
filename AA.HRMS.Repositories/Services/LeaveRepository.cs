using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AA.HRMS.Repositories.Services
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="GradeRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public LeaveRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        /// <summary>
        /// Gets the leave type list for company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetLeaveTypeListForCompanyId</exception>
        public IList<ILeaveType> GetLeaveTypeListForCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LeaveQueries.GetLeaveTypeByCompanyId(dbContext, companyId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetLeaveTypeListForCompanyId", e);
            }
        }

        /// <summary>
        /// Gets the pending leave request by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetLeaveTypeListForCompanyId</exception>
        public IList<ILeaveRequestModel> GetPendingLeaveRequestByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LeaveQueries.getPendingLeaveRequestByCompanyId(dbContext, companyId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetLeaveTypeListForCompanyId", e);
            }
        }


        public IList<ILeaveRequestModel> GetLeaveRequestByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LeaveQueries.getLeaveRequestByCompanyId(dbContext, companyId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetLeaveTypeListForCompanyId", e);
            }
        }




        /// <summary>
        /// Gets the leave type by identifier.
        /// </summary>
        /// <param name="leaveTypeId">The leave type identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">leaveTypeId</exception>
        public ILeaveType GetLeaveTypeById(int leaveTypeId)
        {
            try
            {
                using (
                   var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var leaveTypeInfo = LeaveQueries.getLeaveTypeById(dbContext, leaveTypeId);

                    return leaveTypeInfo;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException(nameof(leaveTypeId));
            }
        }

        public ILeaveType GetLeaveTypeByName(string leaveTypeName, int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = LeaveQueries.getLeaveTypeByName(dbContext, leaveTypeName, companyId);
                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetLeaveTypetByName", e);
            }
        }


        /// <summary>
        /// Saves the leave type model information.
        /// </summary>
        /// <param name="leaveTypeModelInfo">The leave type model information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">leaveTypeModelInfo</exception>
        public string SaveLeaveTypeModelInfo(ILeaveTypeModelView leaveTypeModelInfo)
        {
            if (leaveTypeModelInfo == null) throw new ArgumentNullException(nameof(leaveTypeModelInfo));


            var result = string.Empty;

            var newLeaveType = new LeaveType
            {
                CompanyId = leaveTypeModelInfo.CompanyID,
                LeaveTypeName = leaveTypeModelInfo.LeaveTypeName,
                Description = leaveTypeModelInfo.Description,
                Duration = leaveTypeModelInfo.Duration,
                IsActive = true,
                DateCreated = DateTime.Now
            };
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.LeaveTypes.Add(newLeaveType);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Leave Type Model Info - {0}, {1}", e.Message, e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;

        }

        /// <summary>
        /// Updates the leave type information.
        /// </summary>
        /// <param name="leaveTypeInfo">The leave type information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// leaveTypeInfo
        /// or
        /// leaveTypeData
        /// </exception>
        public string UpdateLeaveTypeInfo(ILeaveTypeModelView leaveTypeInfo)
        {
            if (leaveTypeInfo == null) throw new ArgumentNullException(nameof(leaveTypeInfo));

            var result = string.Empty;

            try
            {
                using (var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var leaveTypeData = dbContext.LeaveTypes.SingleOrDefault(m => m.LeaveTypeId.Equals(leaveTypeInfo.LeaveTypeID));

                    if (leaveTypeData == null)
                    {
                        throw new ArgumentNullException(nameof(leaveTypeData));

                    }
                    
                    leaveTypeData.LeaveTypeName = leaveTypeInfo.LeaveTypeName;
                    leaveTypeData.Description = leaveTypeInfo.Description;
                    leaveTypeData.Duration = leaveTypeInfo.Duration;
                    //leaveTypeData.DateModified = DateTime.UtcNow;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Update Leave Type Information - {0}, {1}", e.Message, e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Deletes the type of the leave.
        /// </summary>
        /// <param name="leaveTypeId">The leave type identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">leaveTypeId</exception>
        /// <exception cref="ArgumentNullException">leaveTypeId</exception>
        public string DeleteLeaveType(int leaveTypeId)
        {
            if (leaveTypeId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(leaveTypeId));
            }

            var result = string.Empty;

            try
            {
                using (var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var leaveTypeData = dbContext.LeaveTypes.SingleOrDefault(p => p.LeaveTypeId.Equals(leaveTypeId));

                    if (leaveTypeData == null)
                    {
                        throw new ArgumentNullException(nameof(leaveTypeId));
                    }

                    leaveTypeData.IsActive = false;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {

                result = string.Format("Delete Leave Type Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Gets the leave type list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetLeaveTypeList</exception>
        public IList<ILeaveType> GetLeaveTypeList()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LeaveQueries.GetLeaveType(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetLeaveTypeList", e);
            }
        }


        /// <summary>
        /// Gets the leave status list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetLeaveStatus</exception>
        public IList<ILeaveStatus> GetLeaveStatusList()
        {

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LeaveQueries.GetLeaveStatus(dbContext).ToList();

                    //var leaveRequestListView = new LeaveRequest();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetLeaveStatus", e);
            }

        }

        /// <summary>
        /// Gets the name of the leave status by.
        /// </summary>
        /// <param name="statusName">Name of the status.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetLeaveStatusByName</exception>
        public ILeaveStatus GetLeaveStatusByName(string statusName)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var leaveStatus = LeaveQueries.GetLeaveStatusByName(dbContext, statusName);

                    //var leaveRequestListView = new LeaveRequest();
                    return leaveStatus;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetLeaveStatusByName", e);
            }
        }

        /// <summary>
        /// Gets the leave status by identifier.
        /// </summary>
        /// <param name="leaveStatusId">The leave status identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetLeaveStatusById</exception>
        public ILeaveStatus GetLeaveStatusById(int leaveStatusId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var leaveStatus = LeaveQueries.GetLeaveStatusById(dbContext, leaveStatusId);

                    //var leaveRequestListView = new LeaveRequest();
                    return leaveStatus;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetLeaveStatusById", e);
            }
        }

        /// <summary>
        /// Gets the leave request details.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetRequestDetails</exception>
        public ILeaveRequestModel GetLeaveRequestDetails(int id)
        {

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var model = LeaveQueries.GetLeaveRequestById(dbContext, id);

                    //var leaveRequestListView = new LeaveRequest();
                    return model;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetRequestDetails", e);
            }

        }



        //=====================================LEAVE REQUEST=================================//

        /// <summary>
        /// Gets the leave request list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetLeaveRequestList</exception>
        public IList<ILeaveRequestModel> GetLeaveRequestList()
        {

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LeaveQueries.GetLeaveRequest(dbContext).ToList();

                    //var leaveRequestListView = new LeaveRequest();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetLeaveRequestList", e);
            }

        }

        /// <summary>
        /// Gets the leave request by employee identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetLeaveRequestByEmployeeId</exception>
        public IList<ILeaveRequestModel> GetLeaveRequestByEmployeeId(int companyId, int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LeaveQueries.GetLeaveRequestByEmployeeId(dbContext, companyId, employeeId).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetLeaveRequestByEmployeeId", e);
            }
        }

        /// <summary>
        /// Gets the latest leave request by employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetLeaveRequestByEmployeeId</exception>
        public ILeaveRequestModel GetLatestLeaveRequestByEmployeeId(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LeaveQueries.GetLatestLeaveRequestByEmployeeId(dbContext, employeeId);
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetLeaveRequestByEmployeeId", e);
            }
        }

        /// <summary>
        /// Gets the leave requests made by a particular employee.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository Get Leave Request By EmployeeId List</exception>
        public IList<ILeaveRequestModel> GetLeaveRequestByEmployeeId(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LeaveQueries.GetLeaveRequestByEmployeeId(dbContext, employeeId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get Leave Request By EmployeeId List", e);
            }
        }

        /// <summary>
        /// Gets the list of leave requests made by employees in just the parent company of the HR admin
        /// </summary>
        /// <param name="hrId">The hr identifier.</param>
        /// <returns></returns>
        public IList<ILeaveRequestModel> GetLeaveRequestByHrAdminId(int hrId, int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LeaveQueries.GetLeaveRequestByHrAdminId(dbContext, hrId, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get Leave Request by HR Admin List", e);
            }
        }

        /// <summary>
        /// Gets the leave request by employee supervisor identifier.
        /// </summary>
        /// <param name="supervisorId">The supervisor identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository Get Leave Request by SupervisorId List</exception>
        public IList<ILeaveRequestModel> GetLeaveRequestByEmployeeSupervisorId(int supervisorId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LeaveQueries.GetLeaveRequestByEmployeeSupervisorId(dbContext, supervisorId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get Leave Request by SupervisorId List", e);
            }
        }

        /// <summary>
        /// Gets the list of leave requests made by employees in both the parent company and child companies of an HR admin
        /// </summary>
        /// <param name="hrId">The hr identifier.</param>
        /// <returns></returns>
        public IList<ILeaveRequestModel> GetLeaveRequestByHrAdminIdWithChildCompanies(int hrId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LeaveQueries.GetLeaveRequestByHrAdminIdWithChildCompanies(dbContext, hrId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get Leave Request by HRAdminId with child companies List", e);
            }
        }

        /// <summary>
        /// Saves the leave request information.
        /// </summary>
        /// <param name="leaveRequestModelInfo">The leave request model information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">leaveRequestModelInfo</exception>
        public string SaveLeaveRequestInfo(ILeaveRequestViewModel leaveRequestModelInfo)
        {
            if (leaveRequestModelInfo == null) throw new ArgumentNullException(nameof(leaveRequestModelInfo));

            var result = string.Empty;

            var newLeaveRequest = new LeaveRequest
            {
                EmployeeID = leaveRequestModelInfo.EmployeeID,
                LeaveTypeID = leaveRequestModelInfo.LeaveTypeID,
                DateLeaveStart = leaveRequestModelInfo.DateLeaveStart,
                DateLeaveEnds = leaveRequestModelInfo.DateLeaveEnds,
                Comment = leaveRequestModelInfo.Comment,
                LeaveStatusID = 3,
                DateRequested = DateTime.Now,
                DateCreated = DateTime.Now,
                CompanyID = leaveRequestModelInfo.CompanyId,
            };
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.LeaveRequests.Add(newLeaveRequest);
                    dbContext.SaveChanges();
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                //result = string.Format("SaveEmploymentHistoryInfo - {0} , {1}", e.Message,
                //e.InnerException != null ? e.InnerException.Message : "");
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;

            }

            return result;

        }

        /// <summary>
        /// Updates the leave request information.
        /// </summary>
        /// <param name="leaveRequestInfo">The leave request information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">leaveRequestDetails</exception>
        public string UpdateLeaveRequestInfo(ILeaveRequestViewModel leaveRequestInfo)
        {

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {

                    var leaveRequestDetails = dbContext.LeaveRequests.SingleOrDefault(x => x.LeaveID == leaveRequestInfo.LeaveID);

                    if (leaveRequestDetails == null) throw new ArgumentNullException(nameof(leaveRequestDetails));
                    

                    // Store the leaveRequestViewModel in the database
                    
                    leaveRequestDetails.DateLeaveStart = leaveRequestInfo.DateLeaveStart;
                    leaveRequestDetails.DateLeaveEnds = leaveRequestInfo.DateLeaveEnds;
                    leaveRequestDetails.LeaveStatusID = leaveRequestInfo.LeaveStatusID;
                    leaveRequestDetails.DateApprovedHR = DateTime.UtcNow;
                    leaveRequestDetails.HRApproverComment = leaveRequestInfo.HRApproverComment;
                    leaveRequestDetails.HRApproverID = leaveRequestInfo.HRApproverID;



                    dbContext.SaveChanges();

                }
            }
            catch (Exception e)
            {
                result = string.Format("Update Leave Request- {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;

        }




    }


}
