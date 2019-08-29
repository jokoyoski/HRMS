using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Queries
{
    internal static class TrainingQueries
    {
        /// <summary>
        /// Gets the training by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trainingId">The training identifier.</param>
        /// <returns></returns>
        internal static ITraining getTrainingById(HRMSEntities db, int trainingId)
        {
            var result = (from s in db.Trainings
                          where s.TrainingID.Equals(trainingId)
                          select new Models.TrainingModel
                          {
                              TrainingID = s.TrainingID,
                              TrainingName = s.TrainingName,
                              CompanyID = s.CompanyID,
                              IsActive = s.IsActive,
                              DateCreated = s.DateCreated,
                              TrainingDescription = s.TrainingDescription

                          }).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Gets the name of the training by.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trainingName">Name of the training.</param>
        /// <returns></returns>
        internal static ITraining getTrainingByName(HRMSEntities db, string trainingName)
        {
            var result = (from a in db.Trainings
                          where a.TrainingName.Equals(trainingName)
                          select new Models.TrainingModel
                          {
                              TrainingID = a.TrainingID,
                              TrainingName = a.TrainingName,
                              CompanyID = a.CompanyID,
                              IsActive = a.IsActive,
                              DateCreated = a.DateCreated,
                              TrainingDescription = a.TrainingDescription

                          }).FirstOrDefault();
            return result;
        }
        
        /// <summary>
        /// Gets all my trainings.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<ITraining> getAllMyTrainings(HRMSEntities db, int companyId)
        {
            var result = (from d in db.Trainings
                          where d.CompanyID == companyId && d.IsActive.Equals(true)
                          join e in db.Companies on d.CompanyID equals e.CompanyId
                          join pdept in db.Trainings on d.TrainingID equals pdept.TrainingID into gj
                          from f in gj.DefaultIfEmpty()
                          select new TrainingModel
                          {
                              TrainingID = d.TrainingID,
                              TrainingName = d.TrainingName,
                              CompanyID = e.CompanyId,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              TrainingDescription = f.TrainingDescription
                          }).OrderBy(p=>p.TrainingName);

            return result;
        }

        /// <summary>
        /// Gets the training request by company identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IEmployeeTrainingModel> getTrainingRequestByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.EmployeeTrainings
                          join e in db.Companies on d.CompanyId equals e.CompanyId
                          join p in db.Trainings on d.TrainingId equals p.TrainingID
                          join v in db.Employees on d.EmployeeId equals v.EmployeeId
                          where d.CompanyId.Equals(companyId)
                          select new EmployeeTrainingModel
                          {
                              EmployeeId = d.EmployeeId,
                              TrainingId = d.TrainingId,
                              TrainingName = p.TrainingName,
                              EmployeeName = v.FirstName,
                              SupervisorId = d.SupervisorId,
                              IsApproved = d.IsApproved,
                              DateApproved = d.DateApproved,
                              CompanyName = e.CompanyName,
                              EmployeeTrainingId = d.EmployeeTrainingId,
                              CompanyId = d.CompanyId,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive

                          }).Where(d => d.IsActive == true)
                          .OrderBy(p => p.TrainingName);

            return result;
        }


        internal static IEnumerable<IEmployeeTrainingModel> getPendingTrainingByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.EmployeeTrainings
                          join e in db.Companies on d.CompanyId equals e.CompanyId
                          join p in db.Trainings on d.TrainingId equals p.TrainingID
                          join v in db.Employees on d.EmployeeId equals v.EmployeeId
                          where d.CompanyId.Equals(companyId) && d.IsApproved.Equals(null)
                          select new EmployeeTrainingModel
                          {
                              EmployeeId = d.EmployeeId,
                              TrainingId = d.TrainingId,
                              TrainingName = p.TrainingName,
                              EmployeeName = v.FirstName,
                              SupervisorId = d.SupervisorId,
                              IsApproved = d.IsApproved,
                              DateApproved = d.DateApproved,
                              CompanyName = e.CompanyName,
                              EmployeeTrainingId = d.EmployeeTrainingId,
                              CompanyId = d.CompanyId,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive

                          }).Where(d => d.IsActive == true)
                          .OrderBy(p => p.TrainingName);

            return result;
        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        internal static IEnumerable<IEmployeeTrainingModel> getAllMyTrainingsByEmployeeId(HRMSEntities db, int employeeId)
        {
            var result = (from d in db.EmployeeTrainings
                          join e in db.Companies on d.CompanyId equals e.CompanyId
                          join p in db.Trainings on d.TrainingId equals p.TrainingID
                          join v in db.Employees on d.EmployeeId equals v.EmployeeId
                          select new EmployeeTrainingModel
                          {
                              EmployeeId = d.EmployeeId,
                              TrainingId = d.TrainingId,
                              TrainingName = p.TrainingName,
                              EmployeeName = v.FirstName,
                              SupervisorId = d.SupervisorId,
                              IsApproved = d.IsApproved,
                              DateApproved = d.DateApproved,
                              CompanyName = e.CompanyName,
                              EmployeeTrainingId = d.EmployeeTrainingId,
                              CompanyId = d.CompanyId,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive
                              
                          }).Where(d=>d.EmployeeId.Equals(employeeId))
                          .OrderBy(p => p.TrainingName);

            return result;
        }

        /// <summary>
        /// Gets the employee trainings by employee identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        internal static IEmployeeTrainingModel getEmployeeTrainingsByEmployeeId(HRMSEntities db, int employeeId)
        {
            var result = (from d in db.EmployeeTrainings
                          where d.EmployeeId == employeeId
                          join e in db.Companies on d.CompanyId equals e.CompanyId
                          join p in db.Trainings on d.TrainingId equals p.TrainingID
                          join v in db.Employees on d.EmployeeId equals v.EmployeeId
                          select new EmployeeTrainingModel
                          {
                              EmployeeId = d.EmployeeId,
                              TrainingId = d.TrainingId,
                              TrainingName = p.TrainingName,
                              EmployeeName = v.FirstName,
                              SupervisorId = d.SupervisorId,
                              IsApproved = d.IsApproved,
                              DateApproved = d.DateApproved,
                              CompanyName = e.CompanyName,
                              EmployeeTrainingId = d.EmployeeTrainingId,
                              CompanyId = d.CompanyId,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive

                          }).FirstOrDefault();

            return result;
        }


        /// <summary>
        /// Gets the trainings calendar by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trainingCalendarId">The training calendar identifier.</param>
        /// <returns></returns>
        internal static ITrainingCalendar getTrainingsCalendarById(HRMSEntities db, int trainingCalendarId)
        {
            var result = (from d in db.TrainingCalenders
                          where d.TrainingCalenderId == trainingCalendarId
                          join e in db.Companies on d.CompanyId equals e.CompanyId
                          join r in db.TrainingStatus on d.TrainingStatusId equals r.TrainingStatusId
                          join pdept in db.Trainings on d.TrainingId equals pdept.TrainingID into gj
                          from f in gj.DefaultIfEmpty()
                          select new TrainingCalendarModel
                          {
                              TrainingCalenderId = d.TrainingCalenderId,
                              TrainingId = d.TrainingId,
                              TrainingName = f.TrainingName,
                              CompanyId = e.CompanyId,
                              IsActive = d.IsActive,
                              TrainingStatusId = d.TrainingStatusId,
                              DateCreated = d.DateCreated,
                              Location = d.Location,
                              DeliveryStartDate = d.DeliveryStartDate,
                              DeliveryEndDate = d.DeliveryEndDate,
                              CompanyName = e.CompanyName,
                              TrainingStatusName = r.Status
                          }).FirstOrDefault();

            return result;
        }
        
        /// <summary>
        /// Gets the trainings calendar by company identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<ITrainingCalendar> getAllTrainingsCalendarByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.TrainingCalenders
                          where d.CompanyId == companyId && d.IsActive.Equals(true)
                          join e in db.Companies on d.CompanyId equals e.CompanyId
                          join r in db.TrainingStatus on d.TrainingStatusId equals r.TrainingStatusId
                          join pdept in db.Trainings on d.TrainingId equals pdept.TrainingID into gj
                          from f in gj.DefaultIfEmpty()
                          select new TrainingCalendarModel
                          {
                              TrainingCalenderId = d.TrainingCalenderId,
                              TrainingId = d.TrainingId,
                              TrainingName = f.TrainingName,
                              CompanyId = e.CompanyId,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              Location = d.Location, 
                              DeliveryStartDate = d.DeliveryStartDate,
                              DeliveryEndDate = d.DeliveryEndDate,
                              CompanyName = e.CompanyName,
                              TrainingStatusName = r.Status
                          }).OrderBy(p=>p.DeliveryStartDate);

            return result;
        }

        /// <summary>
        /// Gets the trainings calendar by company identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<ITrainingCalendar> getTrainingsCalendarByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.TrainingCalenders
                          join e in db.Companies on d.CompanyId equals e.CompanyId
                          join r in db.TrainingStatus on d.TrainingStatusId equals r.TrainingStatusId
                          join pdept in db.Trainings on d.TrainingId equals pdept.TrainingID
                          where d.CompanyId == companyId
                          select new TrainingCalendarModel
                          {
                              TrainingCalenderId = d.TrainingCalenderId,
                              TrainingId = d.TrainingId,
                              TrainingName = pdept.TrainingName,
                              CompanyId = e.CompanyId,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              Location = d.Location,
                              DeliveryStartDate = d.DeliveryStartDate,
                              DeliveryEndDate = d.DeliveryEndDate,
                              CompanyName = e.CompanyName,
                              TrainingStatusName = r.Status,
                          }).OrderBy(p=>p.DeliveryStartDate);

            return result;
        }

        /// <summary>
        /// Gets the trainings calendar by company identifier and training identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="trainingId">The training identifier.</param>
        /// <returns></returns>
        internal static ITrainingCalendar getTrainingsCalendarByCompanyIdAndTrainingId(HRMSEntities db, int companyId, int trainingId)
        {
            var result = (from d in db.TrainingCalenders
                          where d.CompanyId == companyId && d.TrainingId == trainingId
                          join e in db.Companies on d.CompanyId equals e.CompanyId
                          join r in db.TrainingStatus on d.TrainingStatusId equals r.TrainingStatusId
                          join pdept in db.Trainings on d.TrainingId equals pdept.TrainingID into gj
                          from f in gj.DefaultIfEmpty()
                          select new TrainingCalendarModel
                          {
                              TrainingCalenderId = d.TrainingCalenderId,
                              TrainingId = d.TrainingId,
                              TrainingName = f.TrainingName,
                              CompanyId = e.CompanyId,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              Location = d.Location,
                              DeliveryStartDate = d.DeliveryStartDate,
                              DeliveryEndDate = d.DeliveryEndDate,
                              CompanyName = e.CompanyName,
                              TrainingStatusName = r.Status
                          }).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Gets the trainings need analysis by company identifier and training identifier and job identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="trainingId">The training identifier.</param>
        /// <param name="jobId">The job identifier.</param>
        /// <returns></returns>
        internal static ITrainingNeedAnalysis getTrainingsNeedAnalysisByCompanyIdAndTrainingIdAndJobId(HRMSEntities db, int companyId, int trainingId, int jobId)
        {
            var result = (from d in db.TrainingNeedAnalysis
                          where d.CompanyId == companyId && d.TrainingId == trainingId && d.JobId == jobId && d.IsActive.Equals(true)
                          join e in db.Companies on d.CompanyId equals e.CompanyId
                          join pdept in db.Trainings on d.TrainingId equals pdept.TrainingID
                          join r in db.JobTitles on d.JobId equals r.JobTitleId
                          select new TrainingNeedAnalysisModel
                          {
                              TrainingNeedAnaylsisId = d.TrainingNeedAnaylsisId,
                              JobId = d.JobId,
                              TrainingId = d.TrainingId,
                              TrainingName = pdept.TrainingName,
                              CompanyId = e.CompanyId,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              Location = d.Location,
                              CompanyName = e.CompanyName,
                          }).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Gets the training analysis by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trainingAnalysisId">The training analysis identifier.</param>
        /// <returns></returns>
        internal static ITrainingNeedAnalysis getTrainingsNeedAnalysisById(HRMSEntities db, int trainingAnalysisId)
        {
            var result = (from d in db.TrainingNeedAnalysis
                          where d.TrainingNeedAnaylsisId == trainingAnalysisId
                          join e in db.Companies on d.CompanyId equals e.CompanyId
                          join pdept in db.Trainings on d.TrainingId equals pdept.TrainingID 
                          select new TrainingNeedAnalysisModel
                          {
                              TrainingNeedAnaylsisId = d.TrainingNeedAnaylsisId,
                              JobId = d.JobId,
                              Cost = d.Cost,
                              
                              CurrencyId = d.CurrencyId,
                              FrequecyOfDeliveryId = d.FrequecyOfDeliveryId,
                              TrainingDescription = d.TrainingDescription,
                              IsProviderApproved = d.IsProviderApproved,
                              CertificateIssued = d.CertificateIssued,
                              ApprovedBudget = d.ApprovedBudget,
                              TrainingDuration = d.TrainingDuration,
                              TrainingProvider = d.TrainingProvider,
                              MethodOfDelivery = d.MethodOfDelivery,
                              ApprovedBudgetCurrency = d.ApprovedBudgetCurrency,
                              TrainingId = d.TrainingId,
                              TrainingName = pdept.TrainingName,
                              CompanyId = e.CompanyId,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              Location = d.Location,
                              CompanyName = e.CompanyName,
                          }).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Gets the training report by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trainingReportId">The training report identifier.</param>
        /// <returns></returns>
        internal static ITrainingReport getTrainingReportById(HRMSEntities db, int trainingReportId)
        {
            var result = (from s in db.TrainingReports
                          join x in db.TrainingEvaluationRatings on s.TrainingEvaluationRating equals x.TrainingEvaluationRatingId
                          join y in db.TrainingEvaluationRatings on s.TrainerEvaluationRating equals y.TrainingEvaluationRatingId
                          join q in db.TrainingCalenders on s.TrainingCalendarId equals q.TrainingCalenderId
                          join v in db.Trainings on s.TrainingId equals v.TrainingID
                          join z in db.Employees on s.EmployeeId equals z.EmployeeId
                          join e in db.Companies on s.CompanyId equals e.CompanyId
                          join pdept in db.Trainings on s.TrainingId equals pdept.TrainingID into gj
                          where s.TrainingReportId.Equals(trainingReportId)
                          select new Models.TrainingReportModel
                          {
                              TrainingReportId = s.TrainingReportId,
                              DateCreated = s.DateCreated,
                              TrainingId = s.TrainingId,
                              TrainingName = v.TrainingName,
                              CompanyId = s.CompanyId,
                              CompanyName = e.CompanyName,
                              EmployeeId = s.EmployeeId,
                              EmployeeName = z.LastName + " " + z.FirstName,
                              TrainingCalendarId = s.TrainingCalendarId,
                              TrainingStarts = q.DeliveryStartDate,
                              TrainingEnds = q.DeliveryEndDate,
                              TrainerName = s.TrainerName,
                              TrainerEvaluationRating = s.TrainerEvaluationRating,
                              TrainerEvaluationRatingName = y.TrainingEvaluationRating1,
                              TrainerEvaluationComment = s.TrainerEvaluationComment,
                              TrainingEvaluationRating = s.TrainingEvaluationRating,
                              TrainingEvaluationRatingName = x.TrainingEvaluationRating1,
                              TrainingEvaluationComment = s.TrainerEvaluationComment

                          }).FirstOrDefault();

            return result;
        }
        /// <summary>
        /// Gets all my training report.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<ITrainingReport> getAllMyTrainingReport(HRMSEntities db, int companyId)
        {
            var result = (from d in db.TrainingReports
                          where d.CompanyId == companyId
                          join e in db.Employees on d.EmployeeId equals e.EmployeeId
                          join c in db.Companies on d.CompanyId equals c.CompanyId
                          join pdept in db.TrainingReports on d.TrainingReportId equals pdept.TrainingReportId into gj
                          from f in gj.DefaultIfEmpty()

                          select new TrainingReportModel
                          {
                              TrainingReportId = d.TrainingReportId,
                              DateCreated = d.DateCreated,
                              TrainingId = d.TrainingId,
                              CompanyId = d.CompanyId,
                              EmployeeId = d.EmployeeId,
                              TrainingCalendarId = d.TrainingCalendarId,
                              TrainerName = d.TrainerName,
                              TrainerEvaluationRating = d.TrainerEvaluationRating,
                              TrainerEvaluationComment = d.TrainerEvaluationComment,
                              TrainingEvaluationRating = d.TrainingEvaluationRating,
                              TrainingEvaluationComment = d.TrainerEvaluationComment

                          }).OrderBy(p => p.TrainingReportId);

            return result;
        }


        /// <summary>
        /// Gets the training report.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<ITrainingReport> getTrainingReport(HRMSEntities db, int companyId)
        {
            var result = (from d in db.TrainingReports
                          where d.CompanyId == companyId
                          join e in db.Companies on d.CompanyId equals e.CompanyId
                          join pdept in db.Trainings on d.TrainingId equals pdept.TrainingID
                          join p in db.TrainingEvaluationRatings on d.TrainerEvaluationRating equals p.TrainingEvaluationRatingId
                          join m in db.TrainingEvaluationRatings on d.TrainingEvaluationRating equals m.TrainingEvaluationRatingId
                          join w in db.Employees on d.EmployeeId equals w.EmployeeId
                          join c in db.TrainingCalenders on d.TrainingCalendarId equals c.TrainingCalenderId
                          select new TrainingReportModel
                          {
                             TrainingReportId = d.TrainingReportId,
                             TrainingId = pdept.TrainingID,
                             TrainingCalendarId = c.TrainingCalenderId,
                             CompanyId = e.CompanyId,
                             EmployeeId = w.EmployeeId,
                             TrainerName = w.FirstName,
                             TrainerEvaluationRating = m.TrainingEvaluationRatingId,
                             TrainingEvaluationRating = m.TrainingEvaluationRatingId,
                             TrainerEvaluationComment = d.TrainerEvaluationComment,
                             TrainingEvaluationComment = d.TrainingEvaluationComment,
                             DateCreated = d.DateCreated

                          }).ToList();

            return result;
        }




        /// <summary>
        /// Gets the training calendar.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<ITrainingCalendar> getTrainingCalendar(HRMSEntities db, int companyId)
        {
            var result = (from d in db.TrainingCalenders
                          where d.CompanyId == companyId
                          
                          select new TrainingCalendarModel
                          {

                              TrainingId = d.TrainingId,
                              CompanyId = d.CompanyId,
                             DeliveryStartDate = d.DeliveryStartDate,
                             DeliveryEndDate = d.DeliveryEndDate,
                             Location = d.Location,
                             TrainingStatusId = d.TrainingStatusId,
                              DateCreated = d.DateCreated,
                          }).ToList();

            return result;
        }

        /// <summary>
        /// Gets the training history by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="UserId">The user identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<ITrainingHistoryModel> getTrainingHistoryById(HRMSEntities db, int UserId)
        {
            var result = (from s in db.TrainingHistories
                          join d in db.Users on s.UserId equals d.UserId
                          where s.TrainingHistoryId.Equals(UserId)
                          select new Models.TrainingHistoryModel
                          {
                              TrainingHistoryId = s.TrainingHistoryId,
                              TrainingNameId = s.TrainingId,
                              CertificationId = s.CertificationId,
                              TrainingVendorId = s.TrainingVendorId,
                              Year = s.Year,
                              UserId = s.UserId,
                              IsActive = s.IsActive
                          }).ToList();

            return result;
        }


        /// <summary>
        /// Gets the training by user identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static ITrainingHistoryModel GetTrainingByUserId (HRMSEntities db, int userId)
        {
            var result  = (from d in db.TrainingHistories
                           join s in db.Users on d.UserId equals(userId)
                           //join p in db.Certifications on d.Certification equals p.Certificate_Name
                           //join w in db.TrainingReports on d.TrainingVendor equals w.TrainerName
                           where d.UserId.Equals(userId)
                           select new TrainingHistoryModel
                           {
                               TrainingHistoryId = d.TrainingHistoryId,
                               TrainingNameId = d.TrainingId,
                               TrainingVendorId = d.TrainingVendorId,
                               CertificationId = d.CertificationId,
                               Year = d.Year,
                               //vendorName = w.TrainerName,
                               //CertificateName = p.Certificate_Name,
                               UserId = d.UserId,
                               UserName = s.FirstName + ""  +  s.LastName,
                               IsActive = d.IsActive
                           }).FirstOrDefault();
            return result;
        }
        /// <summary>
        /// Gets the training by history identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trainingHistoryId">The training history identifier.</param>
        /// <returns></returns>
        internal static ITrainingHistoryModel GetTrainingByHistoryId(HRMSEntities db, int trainingHistoryId)
        {
            var result = (from d in db.TrainingHistories
                          join s in db.Users on d.UserId equals s.UserId
                          join p in db.Certifications on d.CertificationId equals p.CertificateId
                          join w in db.TrainingReports on d.TrainingVendorId equals w.TrainingReportId
                          where d.TrainingHistoryId.Equals(trainingHistoryId)
                          select new TrainingHistoryModel
                          {
                              TrainingHistoryId = d.TrainingHistoryId,
                              TrainingNameId = d.TrainingId,
                              TrainingVendorId = d.TrainingVendorId,
                              CertificationId = d.CertificationId,
                              Year = d.Year,
                              VendorName = w.TrainerName,
                              CertificateName = p.Certificate_Name,
                              UserId = d.UserId,
                              UserName = s.FirstName + "" + s.LastName,
                              IsActive = d.IsActive
                          }).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Gets the training with identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<ITrainingHistoryModel> GetTrainingWithId(HRMSEntities db, int userId)
        {
            var result = (from d in db.TrainingHistories
                          join x in db.Users on d.UserId equals x.UserId
                          join w in db.Trainings on d.TrainingId equals w.TrainingID
                          join p in db.TrainingReports on d.TrainingVendorId equals p.TrainingReportId
                          join s in db.Certifications on d.CertificationId equals s.CertificateId
                          where d.UserId.Equals(userId)
                          select new TrainingHistoryModel
                          {
                              TrainingHistoryId = d.TrainingHistoryId,
                              TrainingNameId = d.TrainingId,
                              Tname = w.TrainingName,
                              TrainingVendorId = d.TrainingVendorId,
                              VendorName = p.TrainerName,
                              CertificationId = d.CertificationId,
                              CertificateName = s.Certificate_Name,
                              Year = d.Year,
                              UserId = d.UserId,
                              IsActive = d.IsActive,
                              UserName = x.LastName + " " + x.FirstName
                          }).ToList();
            return result;
        }



    }
}  

