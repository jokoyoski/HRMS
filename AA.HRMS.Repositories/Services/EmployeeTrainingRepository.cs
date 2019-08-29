using System;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Factories;
using AA.HRMS.Repositories.Queries;
using System.Collections.Generic;
using System.Linq;

namespace AA.HRMS.Repositories.Services
{
    public class EmployeeTrainingRepository : IEmployeeTrainingRepository
    {


        private readonly IDbContextFactory dbContextFactory;

        public EmployeeTrainingRepository (IDbContextFactory dbContextFactory)
        {
           this.dbContextFactory = dbContextFactory ?? new DbContextFactory(null);
        }

        /// <summary>
        /// Saves the employee training.
        /// </summary>
        /// <param name="employeeTrainingView">The employee training view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeTrainingView</exception>
        public string saveEmployeeTraining (IEmployeeTrainingView employeeTrainingView)
        {
            if (employeeTrainingView == null)
            {
                throw new ArgumentNullException(nameof(employeeTrainingView));
            }

            var result = string.Empty;
            var Trainee = new EmployeeTraining
            {
                TrainingId = employeeTrainingView.TrainingId,
                EmployeeId = employeeTrainingView.EmployeeId,
                SupervisorId = employeeTrainingView.SupervisorId,
                CompanyId = employeeTrainingView.CompanyId,
                IsApproved = null,
                IsActive = true,
                DateApproved = null,
                DateCreated = DateTime.Now,
                TrainingReportId = employeeTrainingView.TrainingReportId
            };
            try
            {
                using (

                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.EmployeeTrainings.Add(Trainee);
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
        /// Gets the employee training.
        /// </summary>
        /// <param name="EmployeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">GetEmployeeTraining {0}</exception>
        public IList<IEmployeeTrainingModel> GetEmployeeTraining(int EmployeeId)

        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var training =
                        EmployeeTrainingQueries.GetEmployeeTraining(dbContext, EmployeeId).ToList();

                    return training;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("GetEmployeeTraining {0}", e);
            }
        }

        /// <summary>
        /// Gets the employee training by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Training By Id</exception>
        public IEmployeeTrainingModel GetEmployeeTrainingById(int Id)
            {

               
                try
                {
                    using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                    {
                    var result = EmployeeTrainingQueries.getAllMyEmployeeTrainings(dbContext, Id);

                    return result;
                    }
                }
            catch (Exception e)
                {
                throw new ArgumentNullException("Get Training By Id", e);
                }
             }
        /// <summary>
        /// Updates the employee training.
        /// </summary>
        /// <param name="employeeTrainingView">The employee training view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// employeeTrainingView
        /// or
        /// employeeTrainingData
        /// </exception>
        public string UpdateEmployeeTraining (IEmployeeTrainingView employeeTrainingView)
        {
            if (employeeTrainingView == null) throw new ArgumentNullException(nameof(employeeTrainingView));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var employeeTrainingData =
                        dbContext.EmployeeTrainings.SingleOrDefault(m => m.EmployeeTrainingId.Equals(employeeTrainingView.EmployeeTrainingId));
                    if (employeeTrainingData == null) throw new ArgumentNullException(nameof(employeeTrainingData));

                    if (employeeTrainingData != null)
                    {
                        employeeTrainingData.IsApproved = employeeTrainingView.IsApproved;

                        if(employeeTrainingView.IsApproved == true)
                        {
                            employeeTrainingData.DateApproved = DateTime.Now;
                        }
                        else
                        {
                            employeeTrainingData.DateApproved = employeeTrainingView.DateApproved;
                        }
                        


                        dbContext.SaveChanges();
                    }

                }
            }
            catch (Exception e)
            {
                result = string.Format("Update Employee Training Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Delets the employee training information.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// Id
        /// or
        /// employeeTrainingData
        /// </exception>
        public string DeletEmployeeTrainingInfo (int employeeTrainingId)
        {
            if (employeeTrainingId < 1)
            {
                throw new ArgumentNullException(nameof(employeeTrainingId));
            }

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var employeeTrainingData =
                        dbContext.EmployeeTrainings.SingleOrDefault(m => m.EmployeeTrainingId.Equals(employeeTrainingId));
                    if (employeeTrainingData == null)
                    {
                        throw new ArgumentNullException(nameof(employeeTrainingData));
                    }

                    employeeTrainingData.IsActive = false;

                    dbContext.SaveChanges();
                }
            }catch(Exception e)
            {
                result = string.Format("Delete Employee Training Information? - {0} , {1}", e.Message,
                                  e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }





        /// <summary>
        /// Gets the employee training by employee identifier.
        /// </summary>
        /// <param name="EmployeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">GetEmployeeTraining {0}</exception>
        public IList<IEmployeeTrainingModel> GetEmployeeTrainingByEmployeeId(int EmployeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var training =
                        EmployeeTrainingQueries.getEmployeeTrainingList(dbContext, EmployeeId).ToList();

                    return training;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("GetEmployeeTraining {0}", e);
            }
        }


    }
}
