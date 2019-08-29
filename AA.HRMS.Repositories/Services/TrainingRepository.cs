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
    public class TrainingRepository : ITrainingRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrainingRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public TrainingRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }


        public IList<IEmployeeTrainingModel> GetPendingTrainingByCompanyId(int companyId)
        {
            if (companyId <= 0)
            {
                throw new ArgumentNullException(nameof(companyId));
            }

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = TrainingQueries.getPendingTrainingByCompanyId(dbContext, companyId).ToList();

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Training By Id", e);
            }
        }

        /// <summary>
        /// Gets the training by identifier.
        /// </summary>
        /// <param name="trainingId">The training identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// trainingId
        /// or
        /// Get Training By Id
        /// </exception>
        public ITraining GetTrainingById(int trainingId)
        {
            if (trainingId <= 0)
            {
                throw new ArgumentNullException(nameof(trainingId));
            }

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = TrainingQueries.getTrainingById(dbContext, trainingId);

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Training By Id", e);
            }
        }

        /// <summary>
        /// Gets the name of the training by.
        /// </summary>
        /// <param name="trainingName">Name of the training.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Training By Name</exception>
        public ITraining GetTrainingByName(string trainingName)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var trainingInfo = TrainingQueries.getTrainingByName(dbContext, trainingName);
                    return trainingInfo;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Training By Name", e);
            }
        }

        /// <summary>
        /// Saves the training information.
        /// </summary>
        /// <param name="trainingInfo">The training information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingInfo</exception>
        public string SaveTrainingInfo(ITrainingView trainingInfo, out int trainingId)
        {
            if (trainingInfo == null)
            {
                throw new ArgumentNullException(nameof(trainingInfo));
            }

            var result = string.Empty;
            

            var newRecord = new Training
            {
                TrainingName = trainingInfo.TrainingName,
                TrainingDescription = trainingInfo.TrainingDescription,
                CompanyID = trainingInfo.CompanyID,
                IsActive = true,
                DateCreated = DateTime.Now

            };

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Trainings.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Training info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            trainingId = newRecord.TrainingID;

            return result;
        }

        /// <summary>
        /// Saves the edit training information.
        /// </summary>
        /// <param name="trainingInfo">The training information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingInfo</exception>
        public string SaveEditTrainingInfo(ITrainingView trainingInfo)
        {
            if (trainingInfo == null)
            {
                throw new ArgumentNullException(nameof(trainingInfo));
            }

            string result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var modelInfo = dbContext.Trainings.SingleOrDefault(p => p.TrainingID == trainingInfo.TrainingID);
                    
                    modelInfo.TrainingName = trainingInfo.TrainingName;
                    modelInfo.TrainingDescription = trainingInfo.TrainingDescription;



                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Edit Training info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Saves the delete training information.
        /// </summary>
        /// <param name="trainingId">The training identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">trainingId</exception>
        public string SaveDeleteTrainingInfo(int trainingId)
        {
            if (trainingId <= 0)
            {
                throw new ArgumentNullException(nameof(trainingId));
            }

            string result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var modelView = dbContext.Trainings.Find(trainingId);


                    modelView.IsActive = false;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Delete Training info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets the training calendar by identifier.
        /// </summary>
        /// <param name="trainingCalendarId">The training calendar identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Get Training Calendar By CompanyId</exception>
        public ITrainingCalendar GetTrainingCalendarById(int trainingCalendarId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = TrainingQueries.getTrainingsCalendarById(dbContext, trainingCalendarId);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Get Training Calendar By CompanyId", e);
            }
        }

        /// <summary>
        /// Gets all my trainings.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAllTraining</exception>
        public IList<ITraining> GetAllMyTrainings(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = TrainingQueries.getAllMyTrainings(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAllTrainings", e);
            }
        }

        /// <summary>
        /// Gets the training request by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTrainingRequestByCompanyId</exception>
        public IList<IEmployeeTrainingModel> GetTrainingRequestByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = TrainingQueries.getTrainingRequestByCompanyId(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTrainingRequestByCompanyId", e);
            }
        }


        /// <summary>
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAllTrainings</exception>
        public IList<IEmployeeTrainingModel> GetAllMyTrainingsByEmployeeId(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = TrainingQueries.getAllMyTrainingsByEmployeeId(dbContext, employeeId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAllTrainings", e);
            }
        }

        /// <summary>
        /// Gets the employee trainings by employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">Repository GetAllTrainings</exception>
        public IEmployeeTrainingModel GetEmployeeTrainingsByEmployeeId(int employeeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = TrainingQueries.getEmployeeTrainingsByEmployeeId(dbContext, employeeId);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAllTrainings", e);
            }
        }

        /// <summary>
        /// Gets all training calendar by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Get All Training Calendar By CompanyId</exception>
        public IList<ITrainingCalendar> GetAllTrainingCalendarByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = TrainingQueries.getAllTrainingsCalendarByCompanyId(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Get All Training Calendar By CompanyId", e);
            }
        }

        /// <summary>
        /// Gets the training calendar by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Get Training Calendar By CompanyId</exception>
        public IList<ITrainingCalendar> GetTrainingCalendarByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = TrainingQueries.getTrainingsCalendarByCompanyId(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Get Training Calendar By CompanyId", e);
            }
        }

        /// <summary>
        /// Gets the training calendar by company idand training identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="trainingId">The training identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Get Training Calendar By CompanyId</exception>
        public ITrainingCalendar GetTrainingCalendarByCompanyIdandTrainingId(int companyId, int trainingId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = TrainingQueries.getTrainingsCalendarByCompanyIdAndTrainingId(dbContext, companyId, trainingId);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Get Training Calendar By CompanyId and TrainingId {0}", e);
            }
        }

        /// <summary>
        /// Saves the training calendar information.
        /// </summary>
        /// <param name="traininingCalendarView">The trainining calendar view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">traininingCalendarView</exception>
        public string SaveTrainingCalendarInfo(ITraininingCalendarView traininingCalendarView)
        {
            if (traininingCalendarView == null) throw new ArgumentNullException(nameof(traininingCalendarView));

            var result = string.Empty;

            var newRecord = new TrainingCalender
            {
                TrainingId = traininingCalendarView.TrainingId,
                CompanyId = traininingCalendarView.CompanyId,
                TrainingStatusId = traininingCalendarView.TrainingStatusId,
                Location = traininingCalendarView.Location,
                DeliveryEndDate = traininingCalendarView.DeliveryEndDate,
                DeliveryStartDate = traininingCalendarView.DeliveryStartDate,
                DateCreated = DateTime.UtcNow,
                IsActive = true,
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.TrainingCalenders.Add(newRecord);

                    dbContext.SaveChanges();
                }

            }
            catch(Exception e)
            {
                result = string.Format("Save Training Calendar info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Saves the edit training calendar information.
        /// </summary>
        /// <param name="traininingCalendarView">The trainining calendar view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">traininingCalendarView</exception>
        public string SaveEditTrainingCalendarInfo(ITraininingCalendarView traininingCalendarView)
        {
            if (traininingCalendarView == null) throw new ArgumentNullException(nameof(traininingCalendarView));

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var record = dbContext.TrainingCalenders.SingleOrDefault(p => p.TrainingCalenderId == traininingCalendarView.TrainingCalenderId);
                    
                    record.TrainingId = traininingCalendarView.TrainingId;
                    record.TrainingStatusId = traininingCalendarView.TrainingStatusId;
                    record.Location = traininingCalendarView.Location;
                    record.DeliveryEndDate = traininingCalendarView.DeliveryEndDate;
                    record.DeliveryStartDate = traininingCalendarView.DeliveryStartDate;

                    dbContext.SaveChanges();
                }
            }
            catch(Exception e)
            {
                result = string.Format("Save Edit Training Calendar info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Saves the delete training calendar information.
        /// </summary>
        /// <param name="trainingCalendarId">The training calendar identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingCalendarId</exception>
        public string SaveDeleteTrainingCalendarInfo(int trainingCalendarId)
        {
            if (trainingCalendarId <= 0) throw new ArgumentNullException(nameof(trainingCalendarId));

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var record = dbContext.TrainingCalenders.SingleOrDefault(p => p.TrainingCalenderId == trainingCalendarId);

                    record.IsActive = false;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Delete Training Calendar info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="trainingNeedAnalysisId"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// trainingNeedAnalysisId
        /// or
        /// Get TrainingNeedAnalysisInfo By Id
        /// </exception>
        public ITrainingNeedAnalysis GetTrainingNeedAnalysisById(int trainingNeedAnalysisId)
        {
            if (trainingNeedAnalysisId <= 0)
            {
                throw new ArgumentNullException(nameof(trainingNeedAnalysisId));
            }

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = TrainingNeedAnalysisQueries.getTrainingNeedAnalysisById(dbContext, trainingNeedAnalysisId);

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get TrainingNeedAnalysisInfo By Id", e);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">Repository GetAllTrainingNeedAnalysis</exception>
        public IList<ITrainingNeedAnalysis> GetAllMyTrainingNeedAnalysis(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = TrainingNeedAnalysisQueries.getAllMyTrainingNeedAnalysis(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAllTrainingNeedAnalysis", e);
            }
        }

        /// <summary>
        /// Saves the training need analysis.
        /// </summary>
        /// <param name="trainingAnalysisViewModel">The training analysis view model.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">trainingAnalysisViewModel</exception>
        public string SaveTrainingNeedAnalysis(ITrainingNeedAnalysisView trainingAnalysisViewModel)
        {
            if (trainingAnalysisViewModel.Equals(null))
            {
                throw new ArgumentNullException(nameof(trainingAnalysisViewModel));
            }

            var result = string.Empty;
            var TrainingAnalysis = new TrainingNeedAnalysi
            {
                TrainingId = trainingAnalysisViewModel.TrainingID,
                CompanyId = trainingAnalysisViewModel.CompanyID,
                JobId = trainingAnalysisViewModel.JobID,
                TrainingDescription = trainingAnalysisViewModel.TrainingDescription,
                MethodOfDelivery = trainingAnalysisViewModel.MethodOfDelivery,
                TrainingProvider = trainingAnalysisViewModel.TrainingProvider,
                Cost = trainingAnalysisViewModel.Cost,
                Location = trainingAnalysisViewModel.Location,
                IsProviderApproved = false,
                ApprovedBudget = trainingAnalysisViewModel.ApprovedBudget,
                FrequecyOfDeliveryId = trainingAnalysisViewModel.FrequencyOfDeliveryID,
                TrainingDuration = trainingAnalysisViewModel.TrainingDuration,
                CertificateIssued = trainingAnalysisViewModel.CertificateIssued,
                DateCreated = DateTime.Now,
                IsActive = true,
                CurrencyId = trainingAnalysisViewModel.Currency,
                ApprovedBudgetCurrency = trainingAnalysisViewModel.ApprovedBudgetCurrency
            };
            try
            {
                using (

                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.TrainingNeedAnalysis.Add(TrainingAnalysis);
                    dbContext.SaveChanges();
                }

            }
            catch (Exception e)
            {
                result = string.Format("SaveTrainingAnalysis - {0} , {1}", e.Message,
                                   e.InnerException != null ? e.InnerException.Message : "");
            }
            return result;
        }

        /// <summary>
        /// Saves the edt training need analysis.
        /// </summary>
        /// <param name="trainingAnalysisViewModel">The training analysis view model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingAnalysisViewModel</exception>
        public string SaveEdtTrainingNeedAnalysis(ITrainingNeedAnalysisView trainingAnalysisViewModel)
        {
            if (trainingAnalysisViewModel.Equals(null))
            {
                throw new ArgumentNullException(nameof(trainingAnalysisViewModel));
            }

            var result = string.Empty;

            try
            {
                using (

                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {

                    var model = dbContext.TrainingNeedAnalysis.SingleOrDefault(p => p.TrainingNeedAnaylsisId.Equals(trainingAnalysisViewModel.TrainingNeedAnalysisID));

                    model.TrainingNeedAnaylsisId = trainingAnalysisViewModel.TrainingNeedAnalysisID;
                    model.JobId = trainingAnalysisViewModel.JobID;
                    model.CompanyId = trainingAnalysisViewModel.CompanyID;
                    model.TrainingId = trainingAnalysisViewModel.TrainingID;
                    model.TrainingDescription = trainingAnalysisViewModel.TrainingDescription;
                    model.MethodOfDelivery = trainingAnalysisViewModel.MethodOfDelivery;
                    model.TrainingProvider = trainingAnalysisViewModel.TrainingProvider;
                    model.Cost = trainingAnalysisViewModel.Cost;
                    model.CurrencyId = trainingAnalysisViewModel.Currency;
                    model.Location = trainingAnalysisViewModel.Location;
                    model.IsProviderApproved = trainingAnalysisViewModel.IsProviderApproved;
                    model.ApprovedBudget = trainingAnalysisViewModel.ApprovedBudget;
                    model.ApprovedBudgetCurrency = trainingAnalysisViewModel.ApprovedBudgetCurrency;
                    model.FrequecyOfDeliveryId = trainingAnalysisViewModel.FrequencyOfDeliveryID;
                    model.TrainingDuration = trainingAnalysisViewModel.TrainingDuration;
                    model.CertificateIssued = trainingAnalysisViewModel.CertificateIssued;

                    dbContext.SaveChanges();
                }

            }
            catch (Exception e)
            {
                result = string.Format("SaveTrainingAnalysis - {0} , {1}", e.Message,
                                   e.InnerException != null ? e.InnerException.Message : "");
            }
            return result;
        }
        

        /// <summary>
        /// Gets the training analysis by company idand training idand job identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="trainingId">The training identifier.</param>
        /// <param name="jobId">The job identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">Get Training Calendar By CompanyId and TrainingId {0}</exception>
        public ITrainingNeedAnalysis GetTrainingAnalysisByCompanyIdandTrainingIdandJobId(int companyId, int trainingId, int jobId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = TrainingQueries.getTrainingsNeedAnalysisByCompanyIdAndTrainingIdAndJobId(dbContext, companyId, trainingId, jobId);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Get TrainingAnalysis By CompanyId, TrainingId andJobId {0}", e);
            }
        }

        /// <summary>
        /// Gets the training analysis by identifier.
        /// </summary>
        /// <param name="trainingAnalysisId">The training analysis identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">Get TrainingAnalysis By CompanyId, TrainingId andJobId {0}</exception>
        public ITrainingNeedAnalysis GetTrainingAnalysisById(int trainingAnalysisId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = TrainingQueries.getTrainingsNeedAnalysisById(dbContext, trainingAnalysisId);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Get TrainingAnalysis By CompanyId, TrainingId andJobId {0}", e);
            }
        }

        /// <summary>
        /// Saves the delete training analysis information.
        /// </summary>
        /// <param name="trainingAnalysisId">The training analysis identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingAnalysisId</exception>
        public string SaveDeleteTrainingAnalysisInfo(int trainingAnalysisId)
        {
            if (trainingAnalysisId <= 0) throw new ArgumentNullException(nameof(trainingAnalysisId));

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var record = dbContext.TrainingNeedAnalysis.SingleOrDefault(p => p.TrainingNeedAnaylsisId == trainingAnalysisId);

                    record.IsActive = false;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Delete Training Anaylsis info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        /// <summary>
        /// Gets the training report.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository getTrainingReport</exception>
        public IList<ITrainingReport> GetTrainingReport(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = TrainingQueries.getTrainingReport(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository getTrainingReport", e);
            }
        }

        /// <summary>
        /// Trainings the calendar model.
        /// </summary>
        /// <param name="companyID">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository getTrainingCalendar</exception>
        public IList<ITrainingCalendar> TrainingCalendarModel(int companyID)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = TrainingQueries.getTrainingCalendar(dbContext, companyID).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository getTrainingCalendar", e);
            }
        }

        /// <summary>
        /// Saves the training report information.
        /// </summary>
        /// <param name="trainingInfo">The training information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">trainingInfo</exception>
        public string SaveTrainingReportInfo(ITrainingReportViewModel trainingReportInfo)
        {
            if (trainingReportInfo == null)
            {
                throw new ArgumentNullException(nameof(trainingReportInfo));
            }

            var result = string.Empty;

            var newRecord = new TrainingReport
            {
                EmployeeId = trainingReportInfo.EmployeeID,
                CompanyId = trainingReportInfo.CompanyID,
                TrainingId = trainingReportInfo.TrainingId,
                TrainerName = trainingReportInfo.TrainerName,
                TrainingCalendarId = trainingReportInfo.TrainingCalendarID,
                TrainerEvaluationRating = trainingReportInfo.TrainerEvaluationRating,
                TrainerEvaluationComment = trainingReportInfo.TrainerEvaluationComment,
                TrainingEvaluationRating = trainingReportInfo.TrainingEvaluationRating,
                TrainingEvaluationComment = trainingReportInfo.TrainingEvaluationComment,
                DateCreated = DateTime.Now

            };

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.TrainingReports.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save TrainingReport info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="trainingReportId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// trainingReportId
        /// or
        /// Get TrainingReportInfo By Id
        /// </exception>
        public ITrainingReport GetTrainingReportById(int trainingReportId)
        {
            if (trainingReportId <= 0)
            {
                throw new ArgumentNullException(nameof(trainingReportId));
            }

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = TrainingQueries.getTrainingReportById(dbContext, trainingReportId);

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get TrainingReportInfo By Id", e);
            }
        }

        /// <summary>
        /// Gets the name of the training by.
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAllTrainingReport</exception>
        public IList<ITrainingReport> GetAllMyTrainingReport(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = TrainingQueries.getAllMyTrainingReport(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAllTrainingReport", e);
            }
        }


        /// <summary>
        /// Gets the training history by history identifier.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// UserId
        /// or
        /// Get History of Training By Id
        /// </exception>
        public IList<ITrainingHistoryModel> GetTrainingHistoryByHistoryId(int UserId)
        {
            if (UserId <= 0)
            {
                throw new ArgumentNullException(nameof(UserId));
            }

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = TrainingQueries.GetTrainingWithId(dbContext, UserId).ToList();

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get History of Training By Id", e);
            }
        }

        /// <summary>
        /// Gets the training tarining history by identifier.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// UserId
        /// or
        /// Get History of Training By Id
        /// </exception>
        public ITrainingHistoryModel GetTrainingTariningHistoryById(int UserId)
        {
            if (UserId <= 0)
            {
                throw new ArgumentNullException(nameof(UserId));
            }

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = TrainingQueries.GetTrainingByHistoryId(dbContext, UserId);

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get History of Training By Id", e);
            }
        }



        /// <summary>
        /// TrainingHistoryList by UserId
        /// </summary>
        /// <param name="Certinfo"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Certinfo</exception>
        public string SaveTrainingHistoryInfo(ITrainingHistoryViewModel Certinfo)
        {
            if (Certinfo == null)
            {
                throw new ArgumentNullException(nameof(Certinfo));
            }

            var empty = string.Empty;

            var insertToDb = new TrainingHistory
            {
                TrainingVendorId = Certinfo.TrainingVendorId,
                TrainingId = Certinfo.TrainingId,
                Year = Certinfo.Year,
                UserId = Certinfo.UserId,
                CertificationId = Certinfo.CertificationId,
                IsActive = true
                

            };
            try
            {
                using (
                    var result = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    result.TrainingHistories.Add(insertToDb);
                    result.SaveChanges();

                }
            }
            catch (Exception e)
            {
                empty = string.Format("save history of Training information", e.Message, e.InnerException != null ? e.InnerException.Message : "");

            }
            return empty;
        }

        /// <summary>
        /// Processes the training history edit.
        /// </summary>
        /// <param name="trainingHistoryViewModel">The training history view model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">HistoryOfTraining</exception>
        public string ProcessTrainingHistoryEdit(ITrainingHistoryViewModel trainingHistoryViewModel)
        {
            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var HistoryOfTraining = dbContext.TrainingHistories.Find(trainingHistoryViewModel.TrainingHistoryId);

                    if (HistoryOfTraining == null)
                    {
                        throw new ArgumentNullException(nameof(HistoryOfTraining));
                    }
                    else if(HistoryOfTraining != null)
                    {
                        HistoryOfTraining.TrainingId = trainingHistoryViewModel.TrainingId;
                        HistoryOfTraining.TrainingVendorId = trainingHistoryViewModel.TrainingVendorId;
                        HistoryOfTraining.UserId = trainingHistoryViewModel.UserId;
                        HistoryOfTraining.Year = trainingHistoryViewModel.Year;
                        HistoryOfTraining.CertificationId = trainingHistoryViewModel.CertificationId;

                        dbContext.SaveChanges();
                    }
                }

            }catch(Exception e)
            {
                result = string.Format("Update Training History Goal Information - {0} , {1}", e.Message,
                   e.InnerException != null ? e.InnerException.Message : "");
            }
            return result;
        }

        /// <summary>
        /// Deletes the training history.
        /// </summary>
        /// <param name="trainingId">The training identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">info</exception>
        public string DeleteTrainingHistory (int trainingId)
        {
            var result = string.Empty;

            try
            {
                using (
                    var dbcontext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var info = dbcontext.TrainingHistories.SingleOrDefault(m => m.TrainingHistoryId.Equals(trainingId));

                    if (info == null) throw new ArgumentNullException(nameof(info));

                    else
                    {
                        info.IsActive = false;
                        dbcontext.SaveChanges();
                    }
                }
               
            }catch (Exception e)
            {
                result = string.Format("Delete Training History Information - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }
            return result;
        }

    }
}
        




   