using System;
using System.Collections.Generic;
using System.Linq;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Queries;

namespace AA.HRMS.Repositories.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IOverTimesheetRepository" />
    
    public class OverTimesheetRepository : IOverTimesheetRepository
    {
        private readonly IDbContextFactory dbContextFactory;
        /// <summary>
        /// Initializes a new instance of the <see cref="OverTimesheetRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        /// 
        public OverTimesheetRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="overTimesheetInfo"></param>
        /// <returns></returns>
       
        public string SaveOverTimesheetInfo(IOverTimesheetView overTimesheetInfo)
        {
            if (overTimesheetInfo == null) throw new ArgumentNullException(nameof(overTimesheetInfo));

            var result = string.Empty;

            
            var newRecord = new OverTimesheet
            {
                EmployeeId = overTimesheetInfo.EmployeeId,
                OverTimeDate = overTimesheetInfo.OverTimeDate,
                NumberofHours = overTimesheetInfo.NumberofHours,
                DateCreated = DateTime.Now,
                CompanyId = overTimesheetInfo.CompanyId,
            };
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.OverTimesheets.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveOverTimesheetinfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Saves the edit over timesheet information.
        /// </summary>
        /// <param name="overTimesheetInfo">The over timesheet information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">overTimesheetInfo</exception>
        public string SaveEditOverTimesheetInfo(IOverTimesheetView overTimesheetInfo)
        {
            if (overTimesheetInfo == null) throw new ArgumentNullException(nameof(overTimesheetInfo));

            var result = string.Empty;

            
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var dataResult = dbContext.OverTimesheets.SingleOrDefault(p => p.OverTimesheetId.Equals(overTimesheetInfo.OverTimesheetId));
                    
                    dataResult.OverTimeDate = overTimesheetInfo.OverTimeDate;
                    dataResult.NumberofHours = overTimesheetInfo.NumberofHours;
                    dataResult.EmployeeId = overTimesheetInfo.EmployeeId;
                    dataResult.CompanyId = overTimesheetInfo.CompanyId;
                    
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveOverTimesheetinfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Saves the delete over timesheet information.
        /// </summary>
        /// <param name="overTimesheetId">The over timesheet identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">overTimesheetId</exception>
        public string SaveDeleteOverTimesheetInfo(int overTimesheetId)
        {
            if (overTimesheetId <= 0) throw new ArgumentNullException(nameof(overTimesheetId));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var dataResult = dbContext.OverTimesheets.SingleOrDefault(p => p.OverTimesheetId.Equals(overTimesheetId));

                    
                    

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveOverTimesheetinfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets the over timesheet by company identifier.
        /// </summary>
        /// <param name="CompanyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">Repository GetEmployeeByName</exception>
        public IList<IOverTimesheet> GetOverTimesheetByCompanyId(int CompanyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = OverTimesheetQueries.GetOverTimesheetByCompanyId(dbContext, CompanyId).ToList();
                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetEmployeeByName", e);
            }
        }

        /// <summary>
        /// Gets the over timesheet by identifier.
        /// </summary>
        /// <param name="overTimeSheetId">The over time sheet identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">Repository GetEmployeeByName</exception>
        public IOverTimesheet GetOverTimesheetById(int overTimeSheetId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = OverTimesheetQueries.GetOverTimesheetById(dbContext, overTimeSheetId);
                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetEmployeeByName", e);
            }
        }

    }
}
