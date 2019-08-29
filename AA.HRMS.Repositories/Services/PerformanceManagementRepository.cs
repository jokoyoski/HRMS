using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Queries;
using AA.HRMS.Repositories.Models;

namespace AA.HRMS.Repositories.Services
{
    public class PerformanceManagementRepository : IPerformanceManagementRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        public PerformanceManagementRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        #region //=========================APPRAISAL ACTION================//

        /// <summary>
        /// Gets the appraisal action list.
        /// </summary>
        /// <param name="CompanyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisal action list {0}</exception>
        public IList<IAppraisalAction> GetAppraisalActionList(int CompanyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalActionList =
                        PerformanceManagementQueries.GetAppraisalActionListByCompanyId(dbContext, CompanyId).ToList();

                    return appraisalActionList;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("appraisal action list {0}", e);
            }
        }

        /// <summary>
        /// Gets the appraisal action list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisal action list {0}</exception>
        public IList<IAppraisalAction> GetAppraisalActionList()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalActionList =
                        PerformanceManagementQueries.GetAppraisalActionList(dbContext).ToList();

                    return appraisalActionList;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("appraisal action list {0}", e);
            }
        }

        /// <summary>
        /// Saves the appraisal action information.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalActionInfo</exception>
        public string SaveAppraisalActionInfo(IAppraisalActionView appraisalActionInfo)
        {
            if (appraisalActionInfo == null) throw new ArgumentNullException(nameof(appraisalActionInfo));

            var result = string.Empty;

            var newRecord = new AppraisalAction
            {
                AppraisalActionName = appraisalActionInfo.AppraisalActionName,
                CompanyId = appraisalActionInfo.CompanyId,
                IsActive = true
            };


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.AppraisalActions.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveAppraisalActionInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Updates the appraisal action information.
        /// </summary>
        /// <param name="appraisalActionInfo">The appraisal action information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// appraisalActionInfo
        /// or
        /// appraisalActionData
        /// </exception>
        public string UpdateAppraisalActionInfo(IAppraisalActionView appraisalActionInfo)
        {
            if (appraisalActionInfo == null) throw new ArgumentNullException(nameof(appraisalActionInfo));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalActionData =
                        dbContext.AppraisalActions.SingleOrDefault(m => m.AppraisalActionId.Equals(appraisalActionInfo.AppraisalActionId));
                    if (appraisalActionData == null) throw new ArgumentNullException(nameof(appraisalActionData));

                    if (appraisalActionData != null)
                    {
                        appraisalActionData.AppraisalActionName = appraisalActionInfo.AppraisalActionName;

                        dbContext.SaveChanges();
                    }

                }
            }
            catch (Exception e)
            {
                result = string.Format("Update Appraisal Action Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets the appraisal action by identifier.
        /// </summary>
        /// <param name="appraisalActionId">The appraisal action identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAppraisalActionById</exception>
        public IAppraisalAction GetAppraisalActionById(int appraisalActionId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord =
                        PerformanceManagementQueries.GetAppraisalActionById(dbContext, appraisalActionId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAppraisalActionById", e);
            }
        }

        /// <summary>
        /// Deletes the appraisal action information.
        /// </summary>
        /// <param name="appraisalActionId">The appraisal action identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">appraisalActionId</exception>
        /// <exception cref="ArgumentNullException">appraisalActionId</exception>
        public string DeleteAppraisalActionInfo(int appraisalActionId)
        {
            if (appraisalActionId < 1)

            {
                throw new ArgumentOutOfRangeException("appraisalActionId");
            }

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalActionData =
                        dbContext.AppraisalActions.SingleOrDefault(m => m.AppraisalActionId.Equals(appraisalActionId));
                    if (appraisalActionData == null) throw new ArgumentNullException("appraisalActionId");


                    appraisalActionData.IsActive = false;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete Appraisal Action Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        #endregion

        #region //=========================EMPLOYEE GOAL TASK==============//

        /// <summary>
        /// Gets the task list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employee task list {0}</exception>
        public IList<IEmployeeTask> GetTaskListByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var employeeTaskList =
                        PerformanceManagementQueries.getTaskListByCompanyId(dbContext, companyId).ToList();

                    return employeeTaskList;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("employee task list {0}", e);
            }
        }

        /// <summary>
        /// Gets the employee task list.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employee task list {0}</exception>
        public IList<IEmployeeTask> GetEmployeeTaskList(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var employeeTaskList =
                        PerformanceManagementQueries.getEmployeeTaskList(dbContext, employeeId).ToList();

                    return employeeTaskList;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("employee task list {0}", e);
            }
        }

        /// <summary>
        /// Saves the employee task information.
        /// </summary>
        /// <param name="employeeTaskInfo">The employee task information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeTaskInfo</exception>
        public string SaveEmployeeTaskInfo(IEmployeeTaskView employeeTaskInfo)
        {
            if (employeeTaskInfo == null) throw new ArgumentNullException(nameof(employeeTaskInfo));

            var result = string.Empty;

            var newRecord = new EmployeeTask
            {
                TaskName = employeeTaskInfo.TaskName,
                TaskDescription = employeeTaskInfo.TaskDescription,
                StartDate = employeeTaskInfo.StartDate,
                EndDate = employeeTaskInfo.EndDate,
                IsActive = true,
                DateCreated = DateTime.UtcNow
            };


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.EmployeeTasks.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveEmployeeRTaskInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Updates the employee task information.
        /// </summary>
        /// <param name="employeeTaskInfo">The employee task information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// employeeTaskInfo
        /// or
        /// employeeTaskInfoData
        /// </exception>
        public string UpdateEmployeeTaskInfo(IEmployeeTaskView employeeTaskInfo)
        {
            if (employeeTaskInfo == null) throw new ArgumentNullException(nameof(employeeTaskInfo));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var employeeTaskInfoData =
                        dbContext.EmployeeTasks.SingleOrDefault(m => m.TaskId.Equals(employeeTaskInfo.TaskId));
                    if (employeeTaskInfoData == null) throw new ArgumentNullException(nameof(employeeTaskInfoData));

                    employeeTaskInfoData.TaskName = employeeTaskInfo.TaskName;
                    employeeTaskInfoData.TaskDescription = employeeTaskInfo.TaskDescription;
                    employeeTaskInfoData.StartDate = employeeTaskInfo.StartDate;
                    employeeTaskInfoData.EndDate = employeeTaskInfo.EndDate;
                    employeeTaskInfoData.IsActive = true;
                    employeeTaskInfoData.DateCreated = DateTime.UtcNow;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Update Employee Task Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Deletes the employee task information.
        /// </summary>
        /// <param name="employeeTaskInfoId">The employee task information identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">employeeTaskId</exception>
        /// <exception cref="ArgumentNullException">employeeTaskId</exception>
        public string DeleteEmployeeTaskInfo(int employeeTaskInfoId)
        {
            if (employeeTaskInfoId < 1)

            {
                throw new ArgumentOutOfRangeException("employeeTaskId");
            }

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var employeeTaskInfData =
                        dbContext.EmployeeTasks.SingleOrDefault(m => m.TaskId.Equals(employeeTaskInfoId));
                    if (employeeTaskInfData == null) throw new ArgumentNullException("employeeTaskId");

                    employeeTaskInfData.IsActive = false;


                    dbContext.SaveChanges();
                }
            }   
            catch (Exception e)
            {
                result = string.Format("Delete Employee Task Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets the employee task by identifier.
        /// </summary>
        /// <param name="employeeTaskId">The employee task identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetEmployeeTaskById</exception>
        public IEmployeeTask GetEmployeeTaskById(int employeeTaskId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord =
                        PerformanceManagementQueries.GetEmployeeTaskById(dbContext, employeeTaskId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetEmployeeTaskById", e);
            }
        }

        #endregion

        #region //=================================Milestone Section =====================================//

        /// <summary>
        /// Gets the milestone list by task identifier.
        /// </summary>
        /// <param name="taskId">The task identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employee task list {0}</exception>
        public IList<IMilestone> GetMilestoneListByTaskId(int taskId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var employeeTaskList =
                        PerformanceManagementQueries.getMilestoneListByTaskId(dbContext, taskId).ToList();

                    return employeeTaskList;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("employee task list {0}", e);
            }
        }

        #endregion

        #region //=========================APPRAISAL RATING==============//

        /// <summary>
        /// Gets the appraisal rating list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisal rating list {0}</exception>
        public IList<IAppraisalRating> GetAppraisalRatingList()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalRatingList =
                        PerformanceManagementQueries.GetAppraisalRatingList(dbContext).ToList();

                    return appraisalRatingList;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("appraisal rating list {0}", e);
            }

        }

        /// <summary>
        /// Saves the appraisal rating information.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalRatingInfo</exception>
        public string SaveAppraisalRatingInfo(IAppraisalRatingView appraisalRatingInfo)
        {
            if (appraisalRatingInfo == null) throw new ArgumentNullException(nameof(appraisalRatingInfo));

            var result = string.Empty;

            var newRecord = new AppraisalRating
            {
                AppraisalRatingName = appraisalRatingInfo.AppraisalRatingName
            };


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.AppraisalRatings.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveAppraisalRatingInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Updates the appraisal rating information.
        /// </summary>
        /// <param name="appraisalRatingInfo">The appraisal rating information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// appraisalRatingInfo
        /// or
        /// appraisalRatingData
        /// </exception>
        public string UpdateAppraisalRatingInfo(IAppraisalRatingView appraisalRatingInfo)
        {
            if (appraisalRatingInfo == null) throw new ArgumentNullException(nameof(appraisalRatingInfo));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalRatingData =
                        dbContext.AppraisalRatings.SingleOrDefault(m => m.AppraisalRatingId.Equals(appraisalRatingInfo.AppraisalRatingId));
                    if (appraisalRatingData == null) throw new ArgumentNullException(nameof(appraisalRatingData));

                    appraisalRatingData.AppraisalRatingName = appraisalRatingInfo.AppraisalRatingName;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Update Appraisal Rating Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        
        /// <summary>
        /// Gets the appraisal rating by identifier.
        /// </summary>
        /// <param name="appraisalRatingId">The appraisal rating identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAppraisalRatingById</exception>
        public IAppraisalRating GetAppraisalRatingById(int appraisalRatingId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord =
                        PerformanceManagementQueries.GetAppraisalRatingById(dbContext, appraisalRatingId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAppraisalRatingById", e);
            }
        }

        /// <summary>
        /// Deletes the appraisal rating information.
        /// </summary>
        /// <param name="appraisalRatingId">The appraisal rating identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">appraisalRatingId</exception>
        /// <exception cref="ArgumentNullException">appraisalRatingId</exception>
        public string DeleteAppraisalRatingInfo(int appraisalRatingId)
        {
            if (appraisalRatingId < 1)

            {
                throw new ArgumentOutOfRangeException("appraisalRatingId");
            }

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalRatingData =
                        dbContext.AppraisalRatings.SingleOrDefault(m => m.AppraisalRatingId.Equals(appraisalRatingId));
                    if (appraisalRatingData == null) throw new ArgumentNullException("appraisalRatingId");

                    appraisalRatingData.IsActive = false;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete Appraisal Rating Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        #endregion

        #region //====================APPRAISER===========//

        /// <summary>
        /// Gets the appraiser list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraiser list {0}</exception>
        public IList<IAppraiser> GetAppraiserList()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraiserList =
                        PerformanceManagementQueries.GetAppraiserList(dbContext).ToList();

                    return appraiserList;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("appraiser list {0}", e);
            }
        }

        /// <summary>
        /// Saves the appraiser information.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraiserInfo</exception>
        public string SaveAppraiserInfo(IAppraiserView appraiserInfo)
        {
            if (appraiserInfo == null) throw new ArgumentNullException(nameof(appraiserInfo));

            var result = string.Empty;

            var newRecord = new Appraiser
            {
                AppraiserName = appraiserInfo.AppraiserName
            };


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Appraisers.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveAppraiserInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Updates the appraiser information.
        /// </summary>
        /// <param name="appraiserInfo">The appraiser information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// appraiserInfo
        /// or
        /// appraiserData
        /// </exception>
        public string UpdateAppraiserInfo(IAppraiserView appraiserInfo)
        {
            if (appraiserInfo == null) throw new ArgumentNullException(nameof(appraiserInfo));

            var result = string.Empty;



            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraiserData =
                        dbContext.Appraisers.SingleOrDefault(m => m.AppraiserId.Equals(appraiserInfo.AppraiserId));
                    if (appraiserData == null) throw new ArgumentNullException(nameof(appraiserData));

                    appraiserData.AppraiserName = appraiserInfo.AppraiserName;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Update Appraiser Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets the appraiser by identifier.
        /// </summary>
        /// <param name="appraiserId">The appraiser identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAppraisalActionById</exception>
        public IAppraiser GetAppraiserById(int appraiserId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord =
                        PerformanceManagementQueries.GetAppraiserById(dbContext, appraiserId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAppraisalActionById", e);
            }
        }

        /// <summary>
        /// Deletes the appraiser information.
        /// </summary>
        /// <param name="appraiserId">The appraiser identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">appraiserId</exception>
        /// <exception cref="ArgumentNullException">appraiserId</exception>
        public string DeleteAppraiserInfo(int appraiserId)
        {
            if (appraiserId < 1)

            {
                throw new ArgumentOutOfRangeException("appraiserId");
            }

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraiserData =
                        dbContext.Appraisers.SingleOrDefault(m => m.AppraiserId.Equals(appraiserId));
                    if (appraiserData == null) throw new ArgumentNullException("appraiserId");

                    appraiserData.IsActive = false;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete Appraiser Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        #endregion

        #region //======================APPRAISAL GOAL====================//  
        
        /// <summary>
        /// Gets the appraisal goal list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisal goal list {0}</exception>
        public IList<IAppraisalGoal> GetAppraisalGoalList(int employeeAppraisalId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalGoalList =
                        PerformanceManagementQueries.GetAppraisalGoalList(dbContext, employeeAppraisalId).ToList();

                    return appraisalGoalList;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("appraisal goal list {0}", e);
            }
        }

        /// <summary>
        /// Saves the appraisal goal information.
        /// </summary>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalGoalInfo</exception>
        public string SaveAppraisalGoalInfo(IAppraisalGoalView appraisalGoalInfo)
        {
            if (appraisalGoalInfo == null) throw new ArgumentNullException(nameof(appraisalGoalInfo));

            var result = string.Empty;

            var newRecord = new AppraisalGoal
            {
                EmployeeAppraisalId = appraisalGoalInfo.EmployeeAppraisalId,
                Goal = appraisalGoalInfo.Goal,
                Measurements = appraisalGoalInfo.Measurements,
                Outcome = appraisalGoalInfo.Outcome,
                DateCreated = DateTime.UtcNow,
                IsActive = true,
                CompanyId = appraisalGoalInfo.CompanyId
            };


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.AppraisalGoals.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveAppraisalGoalInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        
        /// <summary>
        /// Updates the appraisal goal information.
        /// </summary>
        /// <param name="appraisalGoalInfo">The appraisal goal information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// appraisalGoalInfo
        /// or
        /// appraisalGoalData
        /// </exception>
        public string UpdateAppraisalGoalInfo(IAppraisalGoalView appraisalGoalInfo)
        {
            if (appraisalGoalInfo == null) throw new ArgumentNullException(nameof(appraisalGoalInfo));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalGoalData =
                        dbContext.AppraisalGoals.SingleOrDefault(m => m.AppraisalGoalId.Equals(appraisalGoalInfo.AppraisalGoalId));
                    if (appraisalGoalData == null) throw new ArgumentNullException(nameof(appraisalGoalData));


                    appraisalGoalData.Goal = appraisalGoalInfo.Goal;
                    appraisalGoalData.Measurements = appraisalGoalInfo.Measurements;
                    appraisalGoalData.Outcome = appraisalGoalInfo.Outcome;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Update Appraisal Goal Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets the appraisal goal by identifier.
        /// </summary>
        /// <param name="appraisalGoalId">The appraisal goal identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAppraisalGoalById</exception>
        public IAppraisalGoal GetAppraisalGoalById(int appraisalGoalId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord =
                        PerformanceManagementQueries.GetAppraisalGoalById(dbContext, appraisalGoalId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAppraisalGoalById", e);
            }
        }

        /// <summary>
        /// Gets the appraisal question by identifier.
        /// </summary>
        /// <param name="appraisalQuestionId">The appraisal question identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAppraisalQuestionById</exception>
        public IAppraisalQuestion GetAppraisalQuestionById(int appraisalQuestionId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord =
                        PerformanceManagementQueries.GetAppraisalQuestionById(dbContext, appraisalQuestionId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAppraisalQuestionById", e);
            }
        }

        /// <summary>
        /// Deletes the appraisal goal information.
        /// </summary>
        /// <param name="appraisalGoalId">The appraisal goal identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">appraisalGoalId</exception>
        /// <exception cref="ArgumentNullException">appraisalGoalId</exception>
        public string DeleteAppraisalGoalInfo(int appraisalGoalId)
        {
            if (appraisalGoalId < 1)

            {
                throw new ArgumentOutOfRangeException("appraisalGoalId");
            }

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalGoalData =
                        dbContext.AppraisalGoals.SingleOrDefault(m => m.AppraisalGoalId.Equals(appraisalGoalId));
                    if (appraisalGoalData == null) throw new ArgumentNullException("appraisalGoalId");

                    appraisalGoalData.IsActive = false;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete Appraisal Goal Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        #endregion

        #region //=================================APPRAISAL=============//        
        
        /// <summary>
        /// Gets the appraisal list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisal list {0}</exception>
        public IList<IAppraisal> GetAppraisalList(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalList =
                        PerformanceManagementQueries.GetAppraisalList(dbContext, companyId).ToList();

                    return appraisalList;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("appraisal list {0}", e);
            }
        }

        /// <summary>
        /// Gets the appraisal question list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisal question list {0}</exception>
        public IList<IAppraisalQuestion> GetAppraisalQuestionList(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalQuestionList =
                        PerformanceManagementQueries.GetAppraisalQuestionList(dbContext, companyId).ToList();

                    return appraisalQuestionList;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("appraisal question list {0}", e);
            }

        }

        /// <summary>
        /// Gets the appraisal list employee.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisal list {0}</exception>
        public IList<IEmployeeAppraisal> GetAppraisalListEmployee(int companyId, int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalList =
                        PerformanceManagementQueries.getAppraisalListEmployee(dbContext, companyId, employeeId).ToList();

                    return appraisalList;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("appraisal list {0}", e);
            }
        }

        /// <summary>
        /// Gets the appraisee list employee.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="supervisorId">The supervisor identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisal list {0}</exception>
        public IList<IEmployeeAppraisal> GetAppraiseeListEmployee(int companyId, int supervisorId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalList =
                        PerformanceManagementQueries.getAppraiseeListEmployee(dbContext, companyId, supervisorId).ToList();

                    return appraisalList;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("appraisal list {0}", e);
            }
        }

        /// <summary>
        /// Gets the appraisal by company year period.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="yearId">The year identifier.</param>
        /// <param name="peeriodId">The peeriod identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisal list {0}</exception>
        public IAppraisal GetAppraisalByCompanyYearPeriod(int companyId, int yearId, int peeriodId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalList =
                        PerformanceManagementQueries.getAppraisalByCompanyYearPeriod(dbContext, companyId, yearId, peeriodId);

                    return appraisalList;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("appraisal list {0}", e);
            }
        }

        /// <summary>
        /// Gets the appraisal by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisal list {0}</exception>
        public IAppraisal GetAppraisalByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalList =
                        PerformanceManagementQueries.getAppraisalByCompanyId(dbContext, companyId);

                    return appraisalList;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("appraisal list {0}", e);
            }
        }
        
        /// <summary>
        /// Gets the employee appraisal by company identifier appraisal identifier employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="appraisalId">The appraisal identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisal list {0}</exception>
        public IEmployeeAppraisal GetEmployeeAppraisalByCompanyIdAppraisalIdEmployeeId(int employeeId, int companyId, int appraisalId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalList =
                        PerformanceManagementQueries.getEmployeeAppraisalByCompanyIdAppraisalIdEmployeeId(dbContext, employeeId, companyId, appraisalId);

                    return appraisalList;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("appraisal list {0}", e);
            }
        }

        /// <summary>
        /// Gets the appraisal list by employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisal list {0}</exception>
        public IList<IEmployeeAppraisal> GetAppraisalBySupervisorId(int supervisorId, int companyId, int appraisalId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalList =
                        PerformanceManagementQueries.getAppraisalListBySupervisorId(dbContext, supervisorId, companyId, appraisalId).ToList();

                    return appraisalList;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("appraisal list {0}", e);
            }
        }

        /// <summary>
        /// Gets the appraisal by employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="appraisalId">The appraisal identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisal list {0}</exception>
        public IList<IEmployeeAppraisal> GetAppraisalByEmployeeId(int employeeId, int companyId, int appraisalId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalList =
                        PerformanceManagementQueries.getAppraisalListByEmployeeId(dbContext, employeeId, companyId, appraisalId).ToList();

                    return appraisalList;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("appraisal list {0}", e);
            }
        }

        /// <summary>
        /// Gets the appraisal by employee identifier supervisor identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="appraisalId">The appraisal identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisal list {0}</exception>
        public IList<IEmployeeAppraisal> GetAppraisalByEmployeeIdSupervisorId(int employeeId, int companyId, int appraisalId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalList =
                        PerformanceManagementQueries.getAppraisalListByEmployeeIdSuperrvisorId(dbContext, employeeId, companyId, appraisalId).ToList();

                    return appraisalList;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("appraisal list {0}", e);
            }
        }

        /// <summary>
        /// Gets the employee appraisal by appraisal identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="appraisalId">The appraisal identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisal list {0}</exception>
        public IList<IEmployeeAppraisal> GetEmployeeAppraisalByAppraisalId(int companyId, int appraisalId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalList =
                        PerformanceManagementQueries.getEmployeeAppraisalByAppraisalId(dbContext, companyId, appraisalId).ToList();

                    return appraisalList;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("appraisal list {0}", e);
            }
        }

        /// <summary>
        /// Saves the appraisal information.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalInfo</exception>
        public string SaveAppraisalInfo(IAppraisalView appraisalInfo, out int appraisalId)
        {
            if (appraisalInfo == null) throw new ArgumentNullException(nameof(appraisalInfo));

            var result = string.Empty;

            var newRecord = new Appraisal
            {
                DateInitiated = DateTime.UtcNow,
                IsOpened = true,
                AppraisalPeriodId = appraisalInfo.AppraisalPeriodId,
                AppraisalYearId = appraisalInfo.AppraisalYearId,
                CompanyId = appraisalInfo.CompanyId,
                IsActive = true
            };


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Appraisals.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveAppraisalInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            appraisalId = newRecord.AppraisalId;

            return result;
        }

        /// <summary>
        /// Saves the appraisal question information.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalInfo</exception>
        public string SaveAppraisalQuestionInfo(IAppraisalQuestionView appraisalInfo)
        {
            if (appraisalInfo == null) throw new ArgumentNullException(nameof(appraisalInfo));

            var result = string.Empty;

            var newRecord = new AppraisalQuestion
            {
                CompanyId = appraisalInfo.CompanyId,
                DateCreated = DateTime.Now,
                IsActive = true,
                Question = appraisalInfo.Question
            };


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.AppraisalQuestions.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveAppraisalQuestionInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Saves the employee appraisal question information.
        /// </summary>
        /// <param name="employeeQuestionAppraisalInfo">The employee question appraisal information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeQuestionAppraisalInfo</exception>
        public string SaveEmployeeAppraisalQuestionInfo(IEmployeeQuestionRating employeeQuestionAppraisalInfo)
        {
            if (employeeQuestionAppraisalInfo == null) throw new ArgumentNullException(nameof(employeeQuestionAppraisalInfo));

            var result = string.Empty;

            var newRecord = new EmployeeQuestionRating
            {
                EmployeeId = employeeQuestionAppraisalInfo.EmployeeId,
                AppraisalId = employeeQuestionAppraisalInfo.AppraisalId,
                AppraisalQuestionId = employeeQuestionAppraisalInfo.AppraisalQuestionId,
                EmployeeAppraisalId = employeeQuestionAppraisalInfo.EmployeeAppraisalId,
                AppraiseeRatingId = employeeQuestionAppraisalInfo.AppraiseeRatingId,
                AppraiserRatingId = employeeQuestionAppraisalInfo.AppraiserRatingId,
                DateCreated = DateTime.UtcNow,


            };


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.EmployeeQuestionRatings.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveAppraisalInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }

        /// <summary>
        /// Updates the employee appraisal question information.
        /// </summary>
        /// <param name="employeeQuestionAppraisalInfo">The employee question appraisal information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// employeeQuestionAppraisalInfo
        /// or
        /// appraisalData
        /// </exception>
        public string UpdateEmployeeAppraisalQuestionInfo(IEmployeeQuestionRating employeeQuestionAppraisalInfo)
        {
            if (employeeQuestionAppraisalInfo == null)
                throw new ArgumentNullException(nameof(employeeQuestionAppraisalInfo));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalData =
                        dbContext.EmployeeQuestionRatings.Where(m => m.EmployeeId.Equals(employeeQuestionAppraisalInfo.EmployeeId)
                        && m.EmployeeAppraisalId.Equals(employeeQuestionAppraisalInfo.EmployeeAppraisalId)
                        && m.AppraisalQuestionId.Equals(employeeQuestionAppraisalInfo.AppraisalQuestionId)).SingleOrDefault();

                    if (appraisalData == null) throw new ArgumentNullException(nameof(appraisalData));


                    if (employeeQuestionAppraisalInfo.AppraiseeRatingId > 0)
                    {

                        appraisalData.AppraiseeRatingId = employeeQuestionAppraisalInfo.AppraiseeRatingId;
                    }

                    if (employeeQuestionAppraisalInfo.AppraiserRatingId > 0)
                    {

                        appraisalData.AppraiserRatingId = employeeQuestionAppraisalInfo.AppraiserRatingId;
                    }

                    appraisalData.DateModified = DateTime.UtcNow;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("UpdateAppraisalInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Updates the appraisal information.
        /// </summary>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="appraiser">The appraiser.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// appraisalInfo
        /// or
        /// appraisalData
        /// </exception>
        public string UpdateAppraisalInfo(IAppraisal appraisalInfo)
        {
            if (appraisalInfo == null)
                throw new ArgumentNullException(nameof(appraisalInfo));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalData =
                        dbContext.Appraisals.Find(appraisalInfo.AppraisalId);

                    if (appraisalData == null) throw new ArgumentNullException(nameof(appraisalData));

                    appraisalData.IsOpened = appraisalInfo.IsOpened;
                    appraisalData.IsActive = appraisalInfo.IsActive;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("UpdateAppraisalInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        
        /// <summary>
        /// Saves the apraisal qualitative information.
        /// </summary>
        /// <param name="appraisalQualitativeMetric">The appraisal qualitative metric.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalQualitativeMetric</exception>
        public string SaveApraisalQualitativeInfo(IAppraisalQualitativeMetric appraisalQualitativeMetric)
        {
            {
                if (appraisalQualitativeMetric == null)
                    throw new ArgumentNullException(nameof(appraisalQualitativeMetric));

                var result = string.Empty;

                var newRecord = new AppraisalQualitativeMetric
                {
                    Target = appraisalQualitativeMetric.Target,
                    ResultId = appraisalQualitativeMetric.ResultId,
                    EmployeeAppraisalId = appraisalQualitativeMetric.EmployeeAppraisalId,
                    CompanyId = appraisalQualitativeMetric.CompanyId,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,

                };

                try
                {
                    using (
                        var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                    {

                        dbContext.AppraisalQualitativeMetrics.Add(newRecord);
                        dbContext.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    result = string.Format("SaveApraisalQualitativeInfo - {0} , {1}", e.Message,
                        e.InnerException != null ? e.InnerException.Message : "");
                }

                return result;
            }
        }

        /// <summary>
        /// Saves the apraisal quantitative information.
        /// </summary>
        /// <param name="appraisalQuantitativeMetric">The appraisal quantitative metric.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalQuantitativeMetric</exception>
        public string SaveApraisalQuantitativeInfo(IAppraisalQuantitativeMetric appraisalQuantitativeMetric)
        {
            {
                if (appraisalQuantitativeMetric == null)
                    throw new ArgumentNullException(nameof(appraisalQuantitativeMetric));

                var result = string.Empty;

                var newRecord = new AppraisalQuantitiveMetric
                {
                    PrimaryTarget = appraisalQuantitativeMetric.PrimaryTarget,
                    PrimaryActual = appraisalQuantitativeMetric.PrimaryActual,
                    SecondaryActual = appraisalQuantitativeMetric.SecondaryActual,
                    SecondaryTarget = appraisalQuantitativeMetric.SecondaryTarget,

                    ResultId = appraisalQuantitativeMetric.ResultId,
                    EmployeeAppraisalId = appraisalQuantitativeMetric.EmployeeAppraisalId,
                    CompanyId = appraisalQuantitativeMetric.CompanyId,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,

                };

                try
                {
                    using (
                        var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                    {

                        dbContext.AppraisalQuantitiveMetrics.Add(newRecord);
                        dbContext.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    result = string.Format("SaveApraisalQualitativeInfo - {0} , {1}", e.Message,
                        e.InnerException != null ? e.InnerException.Message : "");
                }

                return result;
            }
        }
        
        /// <summary>
        /// Saves the update employee appraisal.
        /// </summary>
        /// <param name="employeeAppraisal">The employee appraisal.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// employeeAppraisal
        /// or
        /// appraisalData
        /// </exception>
        public string SaveUpdateEmployeeAppraisal(IEmployeeAppraisal employeeAppraisal)
        {
            {
                if (employeeAppraisal == null)
                    throw new ArgumentNullException(nameof(employeeAppraisal));

                var result = string.Empty;


                try
                {
                    using (
                        var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                    {
                        var appraisalData =
                            dbContext.EmployeeAppraisals.Where(x=>x.EmployeeAppraisalId.Equals(employeeAppraisal.EmployeeAppraisalId)).SingleOrDefault();

                        if (appraisalData == null) throw new ArgumentNullException(nameof(appraisalData));

                        appraisalData.Status = employeeAppraisal.Status;
                        appraisalData.Things_I_Did_Not_Do_So_Well = employeeAppraisal.Things_I_Did_Not_Do_So_Well;
                        appraisalData.Things_I_Did_Well = employeeAppraisal.Things_I_Did_Well;
                        appraisalData.My_Development_Plan = employeeAppraisal.My_Development_Plan;
                        appraisalData.DateModified = DateTime.UtcNow;
                        


                        dbContext.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    result = string.Format("UpdateAppraisalInfo - {0} , {1}", e.Message,
                        e.InnerException != null ? e.InnerException.Message : "");
                }

                return result;
            }
        }

        /// <summary>
        /// Saves the update appraisal question.
        /// </summary>
        /// <param name="AppraisalQuestion">The appraisal question.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// AppraisalQuestion
        /// or
        /// appraisalQuestionData
        /// </exception>
        public string SaveUpdateAppraisalQuestion(IAppraisalQuestion AppraisalQuestion)
        {
            {
                if (AppraisalQuestion == null)
                    throw new ArgumentNullException(nameof(AppraisalQuestion));

                var result = string.Empty;


                try
                {
                    using (
                        var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                    {
                        var questionId = AppraisalQuestion.AppraisalQuestionId;
                        var appraisalQuestionData = PerformanceManagementQueries.GetAppraisalQuestionById(dbContext, questionId);

                        if (appraisalQuestionData == null) throw new ArgumentNullException(nameof(appraisalQuestionData));

                        var QuestionData =
                        dbContext.AppraisalQuestions.Find(appraisalQuestionData.AppraisalQuestionId);

                        QuestionData.Question = AppraisalQuestion.Question;
                        QuestionData.DateModified = DateTime.Now;


                        dbContext.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    result = string.Format("UpdateAppraisalQuestion - {0} , {1}", e.Message,
                        e.InnerException != null ? e.InnerException.Message : "");
                }

                return result;
            }
        }
        
        /// <summary>
        /// Saves the delete appraisal question.
        /// </summary>
        /// <param name="AppraisalQuestion">The appraisal question.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// AppraisalQuestion
        /// or
        /// appraisalQuestionData
        /// </exception>
        public string SaveDeleteAppraisalQuestion(IAppraisalQuestion AppraisalQuestion)
        {
            {
                if (AppraisalQuestion == null)
                    throw new ArgumentNullException(nameof(AppraisalQuestion));

                var result = string.Empty;


                try
                {
                    using (
                        var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                    {
                        var questionId = AppraisalQuestion.AppraisalQuestionId;
                        var appraisalQuestionData = PerformanceManagementQueries.GetAppraisalQuestionById(dbContext, questionId);

                        if (appraisalQuestionData == null) throw new ArgumentNullException(nameof(appraisalQuestionData));

                        var QuestionData =
                        dbContext.AppraisalQuestions.Find(appraisalQuestionData.AppraisalQuestionId);

                        QuestionData.IsActive = false;
                        QuestionData.DateModified = DateTime.Now;


                        dbContext.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    result = string.Format("DeleteAppraisalQuestion - {0} , {1}", e.Message,
                        e.InnerException != null ? e.InnerException.Message : "");
                }

                return result;
            }
        }

        /// <summary>
        /// Gets the appraisal by identifier.
        /// </summary>
        /// <param name="appraisalId">The appraisal identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAppraisalById</exception>
        public IAppraisal GetAppraisalById(int appraisalId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord =
                        PerformanceManagementQueries.GetAppraisalById(dbContext, appraisalId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAppraisalById", e);
            }
        }

        /// <summary>
        /// Gets the employee appraisal by identifier.
        /// </summary>
        /// <param name="employeeAppraisalId">The employee appraisal identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAppraisalById</exception>
        public IEmployeeAppraisal GetEmployeeAppraisalById(int employeeAppraisalId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord =
                        PerformanceManagementQueries.getEmployeeAppraisalById(dbContext, employeeAppraisalId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAppraisalById", e);
            }
        }

        /// <summary>
        /// Gets the appraisal quantitative metric by employee appraisal identifier.
        /// </summary>
        /// <param name="employeeAppraisalId">The employee appraisal identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAppraisalById</exception>
        public IList<IAppraisalQuantitativeMetric> GetAppraisalQuantitativeMetricByEmployeeAppraisalId(int employeeAppraisalId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord =
                        PerformanceManagementQueries.getAppraisalQuantitativeMetricByEmployeeAppraisalId(dbContext, employeeAppraisalId).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAppraisalById", e);
            }
        }

        /// <summary>
        /// Gets the appraisal qualitative metric by employee appraisal identifier.
        /// </summary>
        /// <param name="employeeAppraisalId">The employee appraisal identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAppraisalById</exception>
        public IList<IAppraisalQualitativeMetric> GetAppraisalQualitativeMetricByEmployeeAppraisalId(int employeeAppraisalId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord =
                        PerformanceManagementQueries.getAppraisalQualitativeMetricByEmployeeAppraisalId(dbContext, employeeAppraisalId).ToList();

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAppraisalById", e);
            }
        }
        
        /// <summary>
        /// Deletes the appraisal information.
        /// </summary>
        /// <param name="appraisalId">The appraisal identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">appraisalId</exception>
        /// <exception cref="ArgumentNullException">appraisalId</exception>
        public string DeleteAppraisalInfo(int appraisalId)
        {
            if (appraisalId < 1)

            {
                throw new ArgumentOutOfRangeException("appraisalId");
            }

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisalData =
                        dbContext.Appraisals.SingleOrDefault(m => m.AppraisalId.Equals(appraisalId));
                    if (appraisalData == null) throw new ArgumentNullException("appraisalId");

                    appraisalData.IsActive = false;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Delete Appraisal Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets all my appraisals by employee identifier.
        /// </summary>
        /// <param name="EmployeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">GetAppraisal {0}</exception>
        public IList<IAppraisal> GetAllMyAppraisalsByEmployeeId(int EmployeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisal =
                        PerformanceManagementQueries.GetAppraisalList(dbContext, EmployeeId).ToList();

                    return appraisal;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("GetAppraisal {0}", e);
            }
        }

        /// <summary>
        /// Saves the employee appraisal.
        /// </summary>
        /// <param name="appraisalView">The appraisal view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appraisalView</exception>
        public string saveEmployeeAppraisal(IAppraisalView appraisalView)
        {

            if (appraisalView == null)
            {
                throw new ArgumentNullException(nameof(appraisalView));
            }

            var result = string.Empty;
            var Trainee = new Appraisal
            {
                AppraisalId = appraisalView.AppraisalId,
            };
            try
            {
                using (

                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Appraisals.Add(Trainee);
                    dbContext.SaveChanges();
                }

            }
            catch (Exception e)
            {
                result = string.Format("SaveEmployeeTraining - {0} , {1}", e.Message,
                                   e.InnerException != null ? e.InnerException.Message : "");
            }
            return result;

        }

        /// <summary>
        /// Gets all my appraisals.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IList<IAppraisal> GetAllMyAppraisals(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisal =
                        PerformanceManagementQueries.GetAppraisalList(dbContext, companyId).ToList();

                    return appraisal;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("GetAppraisal {0}", e);
            }
        }

        /// <summary>
        /// Saves the employee appraisal information.
        /// </summary>
        /// <param name="employeeAppraisalInfo">The employee appraisal information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeAppraisalInfo</exception>
        public string SaveEmployeeAppraisalInfo(IEmployeeAppraisalView employeeAppraisalInfo)
        {
            if (employeeAppraisalInfo == null) throw new ArgumentNullException(nameof(employeeAppraisalInfo));

            var result = string.Empty;

            var newRecord = new EmployeeAppraisal
            {
                EmployeeId = employeeAppraisalInfo.EmployeeId,
                SupervisorId = employeeAppraisalInfo.SupervisorId,
                DateCreated = DateTime.UtcNow,
                AppraisalId = employeeAppraisalInfo.AppraisalId,
                IsActive = true,
                CompanyId = employeeAppraisalInfo.CompanyId,
                Status = employeeAppraisalInfo.Status,

            };


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.EmployeeAppraisals.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveAppraisalInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets the appraisal question.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Appraisal Question {0}</exception>
        public IList<IAppraisalQuestion> GetAppraisalQuestion(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisal =
                        PerformanceManagementQueries.getAppraisalQuestions(dbContext, companyId).ToList();

                    return appraisal;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Appraisal Question {0}", e);
            }
        }

        /// <summary>
        /// Gets the employee appraisal question rating.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="appraisalId">The appraisal identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Ge Employee Appraisal Question Rating {0}</exception>
        public IList<IEmployeeQuestionRating> GetEmployeeAppraisalQuestionRating(int employeeId, int appraisalId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appraisal =
                        PerformanceManagementQueries.getEmployeeAppraisalQuestionRating(dbContext, employeeId, appraisalId).ToList();

                    return appraisal;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Ge Employee Appraisal Question Rating {0}", e);
            }
        }
        
        /// <summary>
        /// Gets the employee feedback.
        /// </summary>
        /// <returns></returns>
        public IList<IEmployeeFeedbackModel> GetEmployeeFeedbackByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = CompanyQueries.getEmployeeFeedbackList(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get All Employee Feedback", e);
            }
        }

        /// <summary>
        /// Gets the feedback by company year identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="yearId">The year identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository Get All Employee Feedback</exception>
        public IFeedbackModel GetFeedbackByCompanyYearId(int companyId, int yearId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = CompanyQueries.getFeedbackByCompanyYearId(dbContext, companyId, yearId);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get All Employee Feedback", e);
            }
        }

        /// <summary>
        /// Gets the employee feedback by feedback identifier.
        /// </summary>
        /// <param name="feedbackId">The feedback identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository Get All Employee Feedback</exception>
        public IList<IEmployeeFeedbackModel> GetEmployeeFeedbackByFeedbackId(int feedbackId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = CompanyQueries.getEmployeeFeedbackByFeedbackId(dbContext, feedbackId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get All Employee Feedback", e);
            }
        }

        #endregion

        #region //=============================Annual Assessing Performance Start============================================//

        /// <summary>
        /// Gets the annual assessing performance by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">Repository Get Annual Assessing Performance By CompanyId YearId</exception>
        public IList<IAnnualAssesingPerformance> GetAnnualAssessingPerformanceByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = PerformanceManagementQueries.getAnnualAssessingPerformanceByCompanyId(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get Annual Assessing Performance By CompanyId YearId", e);
            }
        }

        /// <summary>
        /// Gets the annual assessing performance by identifier.
        /// </summary>
        /// <param name="annualAssessingPerformanceId">The annual assessing performance identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">Repository Get Annual Assessing Performance By CompanyId YearId</exception>
        public IAnnualAssesingPerformance GetAnnualAssessingPerformanceById(int annualAssessingPerformanceId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = PerformanceManagementQueries.getAnnualAssessingPerformanceById(dbContext, annualAssessingPerformanceId);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get Annual Assessing Performance By CompanyId YearId", e);
            }
        }
        
        

        public IEmployeeFeedbackModel GetEmployeeFeedbackByemployeeFeedbackId(int employeefeedbackId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = CompanyQueries.getEmployeeFeedbackListById(dbContext, employeefeedbackId);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get All Employee Feedback", e);
            }
        }

        public IList<IFeedbackModel> GetFeedBackById(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = PerformanceManagementQueries.GetFeedBackById(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get All Employee Feedback", e);
            }
        }

        public IList<IEmployeeFeedbackModel> GetEmployeeFeedBackById(int employeeFeebackId, int employeeId, int companyId, int feedbackId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = PerformanceManagementQueries.GetEmployeeFeedbackById(dbContext, employeeFeebackId,  employeeId,  companyId,  feedbackId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get All Employee Feedback", e);
            }
        }

        public IEmployeeFeedbackModel GetEmployeeFeedbackByFeedbackIdEmployeeIdFeedbackOnEmployeeId(int employeeId, int feebackId, int feedbackOnEmployeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = PerformanceManagementQueries.getEmployeeFeedbackByFeedbackIdEmployeeIdFeedbackOnEmployeeId(dbContext, employeeId, feebackId, feedbackOnEmployeeId);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get All Employee Feedback", e);
            }
        }

        

        public IList<IEmployeeFeedbackModel> GetEmployeeFeedbackByEmployeeFeedbackId(int employeeFeebackId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = PerformanceManagementQueries.GetEmployeeFeedbackByEmployeeFeedbackId(dbContext, employeeFeebackId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get All Employee Feedback", e);
            }
        }

        public string SaveFeedbackInfo(IFeedbackModel feedbackViewModel, out int feedbackId)
        {
            if (feedbackViewModel == null) throw new ArgumentNullException(nameof(feedbackViewModel));

            var result = string.Empty;

            var newRecord = new FeedBack
            {
                CompanyId = feedbackViewModel.CompanyId,
                DateCreated = DateTime.Now,
                IsActive = true,
                IsLock = false,
                YearId = feedbackViewModel.YearId

            };


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.FeedBacks.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveAppraisalInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            feedbackId = newRecord.FeedbackId;
            return result;

        }

        /// <summary>
        /// Gets the annual assessing performance by company identifier year identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="yearId">The year identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">Repository Get Annual Assessing Performance By CompanyId YearId</exception>
        public IAnnualAssesingPerformance GetAnnualAssessingPerformanceByCompanyIdYearId(int companyId, int yearId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = PerformanceManagementQueries.getAnnualAssessingPerformanceByCompanyIdYearId(dbContext, companyId, yearId);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get Annual Assessing Performance By CompanyId YearId", e);
            }
        }

        /// <summary>
        /// Saves the annual performance information.
        /// </summary>
        /// <param name="annualAssesingPerformance">The annual assesing performance.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">annualAssesingPerformance</exception>
        public string SaveAnnualPerformanceInfo(IAnnualAssessingPerformanceView annualAssesingPerformance, out int annualAssessingPerformanceId)
        {
            if (annualAssesingPerformance == null) throw new ArgumentNullException(nameof(annualAssesingPerformance));

            var result = string.Empty;

            var newRecord = new AnnualAssessingPerformance
            {
                CompanyId = annualAssesingPerformance.CompanyId,
                YearId = annualAssesingPerformance.YearId,
                IsOpen = true,
                DateCreated = DateTime.UtcNow,
                IsActive = true,
                
            };


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.AnnualAssessingPerformances.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveAnnualPerformanceInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            annualAssessingPerformanceId = newRecord.AnnualAssessingPerformanceId;

            return result;
        }

        /// <summary>
        /// Saves the close annual performance information.
        /// </summary>
        /// <param name="annualAssessingPerformanceId">The annual assessing performance identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">annualAssessingPerformanceId</exception>
        /// <exception cref="ArgumentNullException">annualAssessingPerformanceData</exception>
        public string SaveCloseAnnualPerformanceInfo(int annualAssessingPerformanceId)
        {
            if (annualAssessingPerformanceId <= 0)

            {
                throw new ArgumentOutOfRangeException("annualAssessingPerformanceId");
            }

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var annualAssessingPerformanceData =
                        dbContext.AnnualAssessingPerformances.SingleOrDefault(m => m.AnnualAssessingPerformanceId.Equals(annualAssessingPerformanceId));

                    if (annualAssessingPerformanceData == null) throw new ArgumentNullException("annualAssessingPerformanceData");

                    annualAssessingPerformanceData.IsOpen = false;
                    annualAssessingPerformanceData.DateModified = DateTime.UtcNow;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Close Annual PerformanceInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        //=============================Annual Assessing Performance Start============================================//

        #endregion

        #region //======================================Employee Annual Performance Section Start=======================================//

        /// <summary>
        /// Gets the employee annual assessing performance by identifier.
        /// </summary>
        /// <param name="employeeAnnualAssessingPerformanceId">The employee annual assessing performance identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository Get Annual Assessing Performance By CompanyId YearId</exception>
        public IEmployeeAnnualAssessingPerformance GetEmployeeAnnualAssessingPerformanceById(int employeeAnnualAssessingPerformanceId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = PerformanceManagementQueries.getEmployeeAnnualAssessingPerformanceById(dbContext, employeeAnnualAssessingPerformanceId);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get Annual Assessing Performance By CompanyId YearId", e);
            }
        }

        /// <summary>
        /// Gets the employee annual assessing performance list by identifier.
        /// </summary>
        /// <param name="annualAssessingPerformanceId">The annual assessing performance identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository Get Annual Assessing Performance By CompanyId YearId</exception>
        public IList<IEmployeeAnnualAssessingPerformance> GetEmployeeAnnualAssessingPerformanceListByAnnualAssessingPerformanceId(int annualAssessingPerformanceId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = PerformanceManagementQueries.getEmployeeAnnualAssessingPerformanceListById(dbContext, annualAssessingPerformanceId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get Annual Assessing Performance By CompanyId YearId", e);
            }
        }

        /// <summary>
        /// Gets the employee annual assessing performance list by employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository Get Annual Assessing Performance By CompanyId YearId</exception>
        public IList<IEmployeeAnnualAssessingPerformance> GetEmployeeAnnualAssessingPerformanceListByEmployeeId(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = PerformanceManagementQueries.getEmployeeAnnualAssessingPerformanceListByEmployeeId(dbContext, employeeId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get Annual Assessing Performance By CompanyId YearId {0}", e);
            }
        }

        /// <summary>
        /// Gets the employee annual assessing performance list by supervisor identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository Get Annual Assessing Performance By CompanyId YearId {0}</exception>
        public IList<IEmployeeAnnualAssessingPerformance> GetEmployeeAnnualAssessingPerformanceListBySupervisorId(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = PerformanceManagementQueries.getEmployeeAnnualAssessingPerformanceListBySupervisorId(dbContext, employeeId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get Annual Assessing Performance By CompanyId YearId {0}", e);
            }
        }
        
        /// <summary>
        /// Gets the employee annual assessing performance list by employee year identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="yearId">The year identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository Get Annual Assessing Performance By CompanyId YearId</exception>
        public IEmployeeAnnualAssessingPerformance GetEmployeeAnnualAssessingPerformanceListByEmployeeYearId(int employeeId, int yearId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = PerformanceManagementQueries.getEmployeeAnnualAssessingPerformanceListByEmployeeYearId(dbContext, employeeId, yearId);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get Annual Assessing Performance By CompanyId YearId", e);
            }
        }

        /// <summary>
        /// Saves the employee annual performance information.
        /// </summary>
        /// <param name="employeeAnnualAssessingPerformance">The employee annual assessing performance.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">employeeAnnualAssessingPerformance</exception>
        public string SaveEmployeeAnnualPerformanceInfo(IEmployeeAnnualAssessingPerformanceView employeeAnnualAssessingPerformance)
        {
            if (employeeAnnualAssessingPerformance == null)
            {
                throw new ArgumentNullException(nameof(employeeAnnualAssessingPerformance));
            }

            var result = string.Empty;

            var newRecord = new EmployeeAnnualAssessingPerformance
            {
                AnnualAssessingPerformanceId = employeeAnnualAssessingPerformance.AnnualAssessingPerformanceId,
                RevieweeId = employeeAnnualAssessingPerformance.RevieweeId,
                ReviewerId = employeeAnnualAssessingPerformance.ReviewerId,
                CompanyId = employeeAnnualAssessingPerformance.CompanyId,
                DateCreated = DateTime.UtcNow,
                Status = employeeAnnualAssessingPerformance.Status,
                IsActive = true
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.EmployeeAnnualAssessingPerformances.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveAnnualPerformanceInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return "";
        }

        /// <summary>
        /// Edits the employee annual performance information.
        /// </summary>
        /// <param name="employeeAnnualAssessingPerformance">The employee annual assessing performance.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">employeeAnnualAssessingPerformance</exception>
        /// <exception cref="System.ArgumentNullException">appraisalGoalId</exception>
        public string EditEmployeeAnnualPerformanceInfo(IEmployeeAnnualAssessingPerformanceView employeeAnnualAssessingPerformance)
        {
            if (employeeAnnualAssessingPerformance == null)

            {
                throw new ArgumentOutOfRangeException("employeeAnnualAssessingPerformance");
            }

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var employeeAnnualAssessingPerformanceData =
                        dbContext.EmployeeAnnualAssessingPerformances.SingleOrDefault(m => m.EmployeeAnnualAssesssingPerformanceId.Equals(employeeAnnualAssessingPerformance.EmployeeAnnualAssesssingPerformanceId));

                    if (employeeAnnualAssessingPerformanceData == null) throw new ArgumentNullException("employeeAnnualAssessingPerformanceData");


                    if (employeeAnnualAssessingPerformance.RevieweeRatingId > 0 && employeeAnnualAssessingPerformance.Status == "Reviewer")
                    {
                        employeeAnnualAssessingPerformanceData.Things_I_Did_Not_Do_Well = employeeAnnualAssessingPerformance.Things_I_Did_Not_Do_Well;
                        employeeAnnualAssessingPerformanceData.Thing_I_Did_Well = employeeAnnualAssessingPerformance.Thing_I_Did_Well;
                        employeeAnnualAssessingPerformanceData.Driven_Exceptional_Client_Service = employeeAnnualAssessingPerformance.Driven_Exceptional_Client_Service;
                        employeeAnnualAssessingPerformanceData.Highest_Performing_Teams = employeeAnnualAssessingPerformance.Highest_Performing_Teams;
                        employeeAnnualAssessingPerformanceData.Examples_Of_Living_Our_Values = employeeAnnualAssessingPerformance.Examples_Of_Living_Our_Values;
                        employeeAnnualAssessingPerformanceData.Enhanced_Quality_And_Effective_Risk_Management = employeeAnnualAssessingPerformance.Enhanced_Quality_And_Effective_Risk_Management;
                        employeeAnnualAssessingPerformanceData.RevieweeRatingId = employeeAnnualAssessingPerformance.RevieweeRatingId;
                        employeeAnnualAssessingPerformanceData.Status = employeeAnnualAssessingPerformance.Status;
                        employeeAnnualAssessingPerformanceData.DateOfReviewee = DateTime.UtcNow;
                    }
                    

                    if (employeeAnnualAssessingPerformance.ReviewerRatingId > 0 && employeeAnnualAssessingPerformance.Status == "FinalReviewer")
                    {
                        employeeAnnualAssessingPerformanceData.ReviewerRatingId = employeeAnnualAssessingPerformance.ReviewerRatingId;
                        employeeAnnualAssessingPerformanceData.ReviewerComment = employeeAnnualAssessingPerformance.ReviewerComment;
                        employeeAnnualAssessingPerformanceData.Status = employeeAnnualAssessingPerformance.Status;
                        employeeAnnualAssessingPerformanceData.DateOfReviewer = DateTime.UtcNow;
                    }

                    if (employeeAnnualAssessingPerformance.FinalRatingId > 0 && employeeAnnualAssessingPerformance.Status == "Reviewed")
                    {
                        employeeAnnualAssessingPerformanceData.FinalRatingId = employeeAnnualAssessingPerformance.FinalRatingId;
                        employeeAnnualAssessingPerformanceData.FinalRatingComment = employeeAnnualAssessingPerformance.FinalRatingComment;
                        employeeAnnualAssessingPerformanceData.Status = employeeAnnualAssessingPerformance.Status;
                        employeeAnnualAssessingPerformanceData.DateOfFinalReview = DateTime.UtcNow;
                        employeeAnnualAssessingPerformanceData.FinalReviewerId = employeeAnnualAssessingPerformance.FinalReviewerId;
                    }


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Edit Employee Annual Performance Info - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        //==============================================Employeee Annual Performance Section Ends=============================================//

        #endregion
            
        #region //=========================================Employee Feedback==================================================//

        /// <summary>
        /// Saves the employee feedback.
        /// </summary>
        /// <param name="employeeView">The employee view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeView</exception>
        public string SaveEmployeeFeedback(IEmployeeFeedbackViewModel employeeView)
        {
            if (employeeView == null) throw new ArgumentNullException(nameof(employeeView));

            var result = string.Empty;

            var newRecord = new EmployeeFeedback
            {
                CompanyId = employeeView.CompanyId,
                EmployeeId = employeeView.EmployeeId,
            Experience = employeeView.Experience,
            DateOfFeedback = DateTime.Now,
            DateCreated = DateTime.Now,
            InWhatContext = employeeView.InWhatContext,
            FeedbackOnEmployeeId = employeeView.FeedbackOnEmployeeId,
            ProvideOverview = employeeView.ProvideOverview,
            WhatAreas = employeeView.WhatAreas,
            FeedbackId = employeeView.FeedbackId,
                IsActive = true,

            };


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.EmployeeFeedbacks.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveEmployeeFeedback - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        
        /// <summary>
        /// Saves the update employee feedback.
        /// </summary>
        /// <param name="employeeView">The employee view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// employeeView
        /// or
        /// record
        /// </exception>
        public string SaveUpdateEmployeeFeedback(IEmployeeFeedbackViewModel employeeView)
        {
            if (employeeView == null) throw new ArgumentNullException(nameof(employeeView));

            var result = string.Empty;

        

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var record = dbContext.EmployeeFeedbacks.SingleOrDefault(x =>  x.EmployeeFeedbackId == employeeView.EmployeeFeedbackId);
                    if (record == null) throw new ArgumentNullException(nameof(record));
                    record.CompanyId = employeeView.CompanyId;
                    record.EmployeeId = employeeView.EmployeeId;
                    record.Experience = employeeView.Experience;
                    record.DateOfFeedback = DateTime.Now;
                    record.DateCreated = DateTime.Now;
                    record.InWhatContext = employeeView.InWhatContext;
                    record.FeedbackOnEmployeeId = employeeView.FeedbackOnEmployeeId;
                    record.ProvideOverview = employeeView.ProvideOverview;
                    record.WhatAreas = employeeView.WhatAreas;
                    record.FeedbackId = employeeView.FeedbackId;
                    
                   

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveEmployeeFeedback - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Processes the edit feedback.
        /// </summary>
        /// <param name="feedbackViewModel">The feedback view model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// feedbackViewModel
        /// or
        /// feedbackData
        /// </exception>
        public string ProcessEditFeedback(IFeedbackViewModel feedbackViewModel)
        {
            if (feedbackViewModel == null) throw new ArgumentNullException(nameof(feedbackViewModel));

            var result = string.Empty;
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var feedbackData =
                        dbContext.FeedBacks.Where(x => x.FeedbackId.Equals(feedbackViewModel.FeedbackId)).SingleOrDefault();

                    if (feedbackData == null) throw new ArgumentNullException(nameof(feedbackData));

                    feedbackData.NoOfFeedBacks += 1;
                  

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("UpdateFeedBackInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        
        /// <summary>
        /// Saves the edited employee feedback.
        /// </summary>
        /// <param name="employeeView">The employee view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// employeeView
        /// or
        /// record
        /// </exception>
        public string SaveEditedEmployeeFeedback(IEmployeeFeedbackViewModel employeeView)
        {
            if (employeeView == null) throw new ArgumentNullException(nameof(employeeView));

            var result = string.Empty;



            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var record = dbContext.EmployeeFeedbacks.SingleOrDefault(x => x.EmployeeFeedbackId == employeeView.EmployeeFeedbackId);
                    if (record == null) throw new ArgumentNullException(nameof(record));
                    record.CompanyId = employeeView.CompanyId;
                    record.EmployeeId = employeeView.EmployeeId;
                    record.EmployeeId = employeeView.EmployeeId;
                    record.Experience = employeeView.Experience;
                    record.DateOfFeedback = DateTime.Today;
                    record.DateCreated = employeeView.DateCreated;
                    record.InWhatContext = employeeView.InWhatContext;
                    record.FeedbackOnEmployeeId = employeeView.FeedbackOnEmployeeId;
                    record.ProvideOverview = employeeView.ProvideOverview;
                    record.WhatAreas = employeeView.WhatAreas;


                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveEmployeeFeedback - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        #endregion
    }
}
