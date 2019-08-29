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
    public class LeaveModelRepository : ILeaveModelRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="GradeRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public LeaveModelRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

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

                    leaveTypeData.CompanyId = leaveTypeInfo.CompanyID;
                    leaveTypeData.LeaveTypeName = leaveTypeInfo.LeaveTypeName;
                    leaveTypeData.Description = leaveTypeInfo.Description;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Update Leave Type Information - {0}, {1}", e.Message, e.InnerException != null ? e.InnerException.Message : ""); 
            }

            return result; 
        }


        public string DeleteLeaveType(int leaveTypeId)
        {
            if(leaveTypeId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(leaveTypeId));
            }

            var result = string.Empty;

            try
            {
                using (var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var leaveTypeData = dbContext.LeaveTypes.SingleOrDefault(p => p.LeaveTypeId.Equals(leaveTypeId)); 

                    if(leaveTypeData == null)
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
        /// Saves the leave request information.
        /// </summary>
        /// <param name="leaveRequestModelInfo">The leave request model information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">leaveRequestModelInfo</exception>
        public string SaveLeaveRequestInfo(ILeaveRequestModelView leaveRequestModelInfo)
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
                LeaveStatusID = leaveRequestModelInfo.LeaveStatusID,
                DateRequested = DateTime.Now,
                DateCreated = DateTime.Now
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
        /// Gets the leave request.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetLeaveRequest</exception>
        public IList<ILeaveRequestModel> GetLeaveRequest()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LeaveQueries.GetLeaveRequest(dbContext).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetLeaveRequest", e);
            }
        }

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

        /// <summary>
        /// Updates the leave approval hr.
        /// </summary>
        /// <param name="leaveHrUpdateView">The leave hr update view.</param>
        /// <param name="leaveId">The leave identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">leaveRequestDetails</exception>
        public string UpdateLeaveApprovalHR(ILeaveHrUpdateView leaveHrUpdateView, int leaveId)
        {

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {

                    var leaveRequestDetails = dbContext.LeaveRequests.SingleOrDefault(x => x.LeaveID == leaveId);
                    if (leaveRequestDetails == null) throw new ArgumentNullException(nameof(leaveRequestDetails));
                    leaveRequestDetails.HRApproverID = leaveHrUpdateView.HRApproverID;
                    leaveRequestDetails.LeaveStatusID = leaveHrUpdateView.LeaveStatusID;
                    leaveRequestDetails.HRApproverComment = leaveHrUpdateView.HRApproverComment;
                    leaveRequestDetails.DateApprovedHR = DateTime.Now;

                    dbContext.SaveChanges();

                }
            }
            catch (Exception e)
            {
                result = string.Format("UpdateLeaveApproval- {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;

        }

        /// <summary>
        /// Updates the leave approval supervisor.
        /// </summary>
        /// <param name="leaveSupervisorUpdateView">The leave supervisor update view.</param>
        /// <param name="leaveId">The leave identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">leaveRequestDetails</exception>
        public string UpdateLeaveApprovalSupervisor(ILeaveSupervisorUpdateView leaveSupervisorUpdateView, int leaveId)
        {

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {

                    var leaveRequestDetails = dbContext.LeaveRequests.SingleOrDefault(x => x.LeaveID == leaveId);
                    if (leaveRequestDetails == null) throw new ArgumentNullException(nameof(leaveRequestDetails));
                    leaveRequestDetails.ApprovingAuthorityID = leaveSupervisorUpdateView.ApprovingAuthorityID;
                    leaveRequestDetails.LeaveStatusID = leaveSupervisorUpdateView.LeaveStatusID;
                    leaveRequestDetails.ApprovingAuthorityComment = leaveSupervisorUpdateView.ApprovingAuthorityComment;
                    leaveRequestDetails.DateApprovedDept = DateTime.Now;

                    dbContext.SaveChanges();

                }
            }
            catch (Exception e)
            {
                result = string.Format("UpdateLeaveApproval- {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");

            }
            return result;

        }

    }
}
