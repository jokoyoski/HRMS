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
    internal static class PerformanceManagementQueries
    {
        
        internal static IAppraisalRating GetAppraisalRatingById(HRMSEntities db, int appraisalRatingId)
        {
            var result = (from d in db.AppraisalRatings
                          where d.AppraisalRatingId.Equals(appraisalRatingId)
                          select new AppraisalRatingModel
                          {
                              AppraisalRatingId = d.AppraisalRatingId,

                              AppraisalRatingName = d.AppraisalRatingName
                          }).FirstOrDefault();
            return result;


        }
        
        internal static IEnumerable<IAppraisalRating> GetAppraisalRatingList(HRMSEntities db)
        {
            var result = (from d in db.AppraisalRatings
                          where d.IsActive.Equals(true)
                          select new AppraisalRatingModel
                          {
                              AppraisalRatingId = d.AppraisalRatingId,
                              AppraisalRatingName = d.AppraisalRatingName,
                              IsActive = d.IsActive
                          }).OrderBy(y => y.AppraisalRatingId);

            return result;
        }
        
        internal static IAppraisalAction GetAppraisalActionById(HRMSEntities db, int appraisalActionId)
        {
            var result = (from d in db.AppraisalActions
                          where d.AppraisalActionId.Equals(appraisalActionId)
                          select new AppraisalActionModel
                          {
                              AppraisalActionId = d.AppraisalActionId,

                              AppraisalActionName = d.AppraisalActionName
                          }).FirstOrDefault();
            return result;


        }
        
        internal static IEnumerable<IAppraisalAction> GetAppraisalActionListByCompanyId(HRMSEntities db, int CompanyId)
        {
            var result = (from d in db.AppraisalActions
                          join q in db.Companies on d.CompanyId equals q.CompanyId
                          where d.CompanyId.Equals(CompanyId)
                          select new Models.AppraisalActionModel
                          {
                              AppraisalActionId = d.AppraisalActionId,
                              ComapnyName= q.CompanyName,
                              AppraisalActionName = d.AppraisalActionName,
                              IsActive = d.IsActive
                          }).OrderBy(a => a.AppraisalActionName);

            return result;
        }
        
        internal static IEnumerable<IAppraisalAction> GetAppraisalActionList(HRMSEntities db)
        {
            var result = (from d in db.AppraisalActions
                          select new Models.AppraisalActionModel
                          {
                              AppraisalActionId = d.AppraisalActionId,
                              AppraisalActionName = d.AppraisalActionName,
                              IsActive = d.IsActive
                          }).OrderBy(a => a.AppraisalActionName);

            return result;
        }
        
        internal static IAppraiser GetAppraiserById(HRMSEntities db, int appraiserId)
        {
            var result = (from d in db.Appraisers
                          where d.AppraiserId.Equals(appraiserId)
                          select new AppraiserModel
                          {
                              AppraiserId = d.AppraiserId,

                              AppraiserName = d.AppraiserName
                          }).FirstOrDefault();
            return result;


        }
        
        internal static IAppraisal getAppraisalByEmployeeId(HRMSEntities db, int EmployeeID)
        {
            var result = (from d in db.Appraisals
                          join w in db.Companies on d.CompanyId equals w.CompanyId
                          //join q in db.Employees on d.EmployeeId equals q.EmployeeId
                          //where d.EmployeeId.Equals(EmployeeID)
                          select new AppraisalModel
                          {

                              AppraisalId = d.AppraisalId,
                              //EmployeeId = d.EmployeeId,
                              //AppraisalYear = d.AppraisalYearId,
                              //AppraisalPeriod = d.AppraisalPeriodId,
                              //InitiationDate = d.InitiationDate,

                              //AppraisalSummary = d.AppraisalSummary,
                              //KeyStrength = d.KeyStrength,
                              //AreasOfImprovement = d.AreasOfImprovement,

                              //AppraisalAgreedDate = d.AppraisalAgreedDate,
                              //DateApproved = d.DateApproved,
                              //ApprovedActionEffectiveDate = d.ApprovedActionEffectiveDate,
                              //DateCreated = d.DateCreated,
                              //IsActive = d.IsActive,

                              //AppraiserId = d.AppraiserId,
                              //AppraiserRatingId = d.AppraiserRatingId,
                              //RecommendedActionId = d.RecommendedActionId,
                              //FinalRatingId = d.FinalRatingId,
                              //ApprovedActionId = d.ApprovedActionId

                          }).FirstOrDefault();
            return result;
        }
        
        internal static IEnumerable<IAppraiser> GetAppraiserList(HRMSEntities db)
        {
            var result = (from d in db.Appraisers
                          where d.IsActive.Equals(true)
                          select new AppraiserModel
                          {
                              AppraiserId = d.AppraiserId,
                              AppraiserName = d.AppraiserName,
                              IsActive = d.IsActive
                          }).OrderBy(a => a.AppraiserName);

            return result;
        }
        
        internal static IAppraisalGoal GetAppraisalGoalById(HRMSEntities db, int appraisalGoalId)
        {
            var result = (from d in db.AppraisalGoals
                          where d.AppraisalGoalId.Equals(appraisalGoalId)
                          select new AppraisalGoalModel
                          {
                              AppraisalGoalId = d.AppraisalGoalId,
                              EmployeeAppraisalId = d.EmployeeAppraisalId,
                              Goal = d.Goal,
                              Measurements = d.Measurements,
                              Outcome = d.Outcome,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive
                          }).FirstOrDefault();
            return result;


        }
        
        internal static IAppraisalQuestion GetAppraisalQuestionById(HRMSEntities db, int appraisalQuestionId)
        {
            var result = (from d in db.AppraisalQuestions
                          where d.AppraisalQuestionId.Equals(appraisalQuestionId)
                          select new AppraisalQuestionModel
                          {
                              AppraisalQuestionId = d.AppraisalQuestionId,
                              DateModified = d.DateModified,
                              CompanyId = d.CompanyId,
                              Question = d.Question,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive
                          }).FirstOrDefault();
            return result;


        }
        
        internal static IEnumerable<IAppraisalGoal> GetAppraisalGoalList(HRMSEntities db, int employeeAppraisal)
        {
            var result = (from d in db.AppraisalGoals
                          where d.EmployeeAppraisalId.Equals(employeeAppraisal) && d.IsActive.Equals(true)
                          select new AppraisalGoalModel
                          {
                              AppraisalGoalId = d.AppraisalGoalId,
                              EmployeeAppraisalId = d.EmployeeAppraisalId,
                              Goal = d.Goal,
                              Measurements = d.Measurements,
                              Outcome = d.Outcome,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive
                          }).OrderBy(a => a.DateCreated);

            return result;
        }

        internal static IEnumerable<IEmployeeTask> getTaskListByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.EmployeeTasks
                          where d.CompanyId.Equals(companyId) && d.IsActive.Equals(true)
                          select new EmployeeTaskModel
                          {
                              AppraisalGoalId = d.AppraisalGoalId,
                              TaskId = d.TaskId,
                              TaskName = d.TaskName,
                              StartDate = d.StartDate,
                              EndDate = d.EndDate,
                              TaskDescription = d.TaskDescription,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive,
                              CompanyId = d.CompanyId,
                              Progress = d.Progress

                          }).OrderBy(a => a.AppraisalGoalId);

            return result;
        }

        internal static IEnumerable<IEmployeeTask> getEmployeeTaskList(HRMSEntities db, int employeeId)
        {
            var result = (from d in db.EmployeeTasks
                          join a in db.AppraisalGoals on d.AppraisalGoalId equals a.AppraisalGoalId
                          join c in db.EmployeeAppraisals on a.AppraisalGoalId equals c.EmployeeAppraisalId
                          where c.EmployeeId.Equals(employeeId) && d.IsActive.Equals(true)
                          select new EmployeeTaskModel
                          {
                              AppraisalGoalId = d.AppraisalGoalId,
                              TaskId = d.TaskId,
                              TaskName = d.TaskName,
                              StartDate = d.StartDate,
                              EndDate = d.EndDate,
                              TaskDescription = d.TaskDescription,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive,
                              Progress = d.Progress,
                              CompanyId = d.CompanyId
                          }).OrderBy(a => a.DateCreated);

            return result;
        }

        internal static IEmployeeTask GetEmployeeTaskById(HRMSEntities db, int employeeTaskId)
        { 
            var result = (from d in db.EmployeeTasks
                          where d.TaskId.Equals(employeeTaskId) && d.IsActive.Equals(true)
                          select new EmployeeTaskModel
                          {
                              AppraisalGoalId = d.AppraisalGoalId,
                              TaskId = d.TaskId,
                              TaskName = d.TaskName,
                              StartDate = d.StartDate,
                              EndDate = d.EndDate,
                              TaskDescription = d.TaskDescription,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive
                          }).FirstOrDefault();

            return result;
        }
        
        internal static IAppraisal GetAppraisalById(HRMSEntities db, int appraisalId)
        {
            var result = (from d in db.Appraisals
                          join c in db.AppraisalPeriods on d.AppraisalPeriodId equals c.AppraisalPeriodId
                          join v in db.Years on d.AppraisalYearId equals v.YearId
                          where d.AppraisalId.Equals(appraisalId) && d.IsActive.Equals(true)
                          select new AppraisalModel
                          {
                              AppraisalId = d.AppraisalId,
                              AppraisalYearId = d.AppraisalYearId,
                              AppraisalPeriodId = d.AppraisalPeriodId,
                              IsOpened =d.IsOpened,
                              DateInitiated = d.DateInitiated,
                              CompanyId = d.CompanyId,
                              AppraisalPeriodName = c.Appraisalperiod1,
                              AppraisalYearName = v.Year1,
                              IsActive = d.IsActive,
                              
                          }).FirstOrDefault();

            return result;
        }

        internal static IEmployeeAppraisal getEmployeeAppraisalById(HRMSEntities db, int employeeAppraisalId)
        {
            var result = (from d in db.EmployeeAppraisals
                          join c in db.Appraisals on d.AppraisalId equals c.AppraisalId
                          where d.EmployeeAppraisalId.Equals(employeeAppraisalId) && d.IsActive.Equals(true)
                          select new EmployeeAppraisalModel
                          {
                              AppraisalId = d.AppraisalId,
                              SupervisorId = d.SupervisorId,
                              EmployeeId = d.EmployeeId,
                              Status = d.Status,
                              DateCreated = d.DateCreated,
                              DateModified = d.DateModified,
                              DateInitiated = c.DateInitiated,
                              CompanyId = d.CompanyId,
                              IsActive = d.IsActive,
                              Things_I_Did_Not_Do_So_Well = d.Things_I_Did_Not_Do_So_Well,
                              Things_I_Did_Well = d.Things_I_Did_Well,
                              My_Development_Plan = d.My_Development_Plan,
                              EmployeeAppraisalId = d.EmployeeAppraisalId,
                              

                          }).FirstOrDefault();

            return result;
        }

        internal static IEnumerable<IAppraisalQualitativeMetric> getAppraisalQualitativeMetricByEmployeeAppraisalId(HRMSEntities db, int employeeAppraisalId)
        {
            var result = (from d in db.AppraisalQualitativeMetrics
                          join c in db.EmployeeAppraisals on d.EmployeeAppraisalId equals c.EmployeeAppraisalId
                          join m in db.AppraisalGoals on c.EmployeeAppraisalId equals m.EmployeeAppraisalId
                          where d.EmployeeAppraisalId.Equals(employeeAppraisalId) && d.IsActive.Equals(true)
                          select new AppraisalQualitativeMetricModel
                          {
                              AppraisalQualitativeMetricId = d.AppraisalQualitativeMetricId,
                              Target = d.Target,
                              ResultId = d.ResultId,
                              CompanyId = d.CompanyId,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive,
                              Goal = m.Goal,
                              EmployeeAppraisalId = d.EmployeeAppraisalId,


                          }).OrderBy(p=>p.EmployeeAppraisalId);

            return result;
        }

        internal static IEnumerable<IAppraisalQuantitativeMetric> getAppraisalQuantitativeMetricByEmployeeAppraisalId(HRMSEntities db, int employeeAppraisalId)
        {
            var result = (from d in db.AppraisalQuantitiveMetrics
                          join m in db.AppraisalGoals on d.EmployeeAppraisalId equals m.EmployeeAppraisalId
                          where d.EmployeeAppraisalId.Equals(employeeAppraisalId) && d.IsActive.Equals(true)
                          select new AppraisalQuantitativeMetricModel
                          {
                              AppraisalQuantitativeMetricId = d.AppraisalQuantitativeMetricId,
                              PrimaryActual = d.PrimaryActual,
                              PrimaryTarget = d.PrimaryTarget,
                              SecondaryActual = d.SecondaryActual,
                              SecondaryTarget = d.SecondaryTarget,
                              ResultId = d.ResultId ?? 0,
                              CompanyId = d.CompanyId,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive,
                              DateModified = d.DateModified,
                              EmployeeAppraisalId = d.EmployeeAppraisalId,
                              Goal = m.Goal,


                          }).OrderBy(p=>p.EmployeeAppraisalId);

            return result;
        }
        
        internal static IEnumerable<IAppraisal> GetAppraisalList(HRMSEntities db, int companyId)
        {
            var result = (from d in db.Appraisals
                          join c in db.Years on d.AppraisalYearId equals c.YearId
                          join x in db.Companies on d.CompanyId equals x.CompanyId
                          join z in db.AppraisalPeriods on d.AppraisalPeriodId equals z.AppraisalPeriodId
                          where d.CompanyId.Equals(companyId) && d.IsActive.Equals(true) 
                          select new AppraisalModel
                          {
                               AppraisalId = d.AppraisalId,
                               CompanyId = d.CompanyId,
                               AppraisalYearId = d.AppraisalYearId,
                               AppraisalPeriodId = d.AppraisalPeriodId,
                               DateInitiated = d.DateInitiated,
                               AppraisalPeriodName = z.Appraisalperiod1,
                               AppraisalYearName = c.Year1,
                               CompanyName = x.CompanyName,
                               IsActive = d.IsActive,
                               IsOpened = d.IsOpened,
                           }).OrderBy(a => a.DateInitiated);

            return result;
        }
        
        internal static IEnumerable<IAppraisalQuestion> GetAppraisalQuestionList(HRMSEntities db, int companyId)
        {
            var result = (from d in db.AppraisalQuestions
                          join x in db.Companies on d.CompanyId equals x.CompanyId
                          where d.CompanyId.Equals(companyId) && d.IsActive.Equals(true)
                          select new AppraisalQuestionModel
                          {
                              AppraisalQuestionId = d.AppraisalQuestionId,
                              CompanyId = d.CompanyId,
                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive,
                              Question = d.Question,
                              DateModified = d.DateModified
                          }).OrderBy(a => a.DateCreated);

            return result;
        }
        
        internal static IEnumerable<IAppraisalQuestion> getAppraisalQuestions(HRMSEntities db, int companyId)
        {
            var result = (from d in db.AppraisalQuestions
                          join x in db.Companies on d.CompanyId equals x.CompanyId
                          where d.CompanyId.Equals(companyId) && d.IsActive.Equals(true)
                          select new AppraisalQuestionModel
                          {
                              AppraisalQuestionId = d.AppraisalQuestionId,
                              Question = d.Question,
                              CompanyId = d.CompanyId,
                              DateCreated = d.DateCreated,
                              DateModified = d.DateModified,
                              IsActive = d.IsActive
                          }).OrderBy(d => d.AppraisalQuestionId);

            return result;
        }
        
        internal static IEnumerable<IEmployeeQuestionRating> getEmployeeAppraisalQuestionRating(HRMSEntities db, int employeeId, int appraisalId)
        {
            var result = (from d in db.EmployeeQuestionRatings
                          join f in db.Employees on d.EmployeeId equals f.EmployeeId
                          join c in db.Appraisals on d.AppraisalId equals c.AppraisalId
                          join q in db.AppraisalQuestions on d.AppraisalQuestionId equals q.AppraisalQuestionId
                          join v in db.EmployeeAppraisals on d.EmployeeAppraisalId equals v.EmployeeAppraisalId
                          where d.EmployeeId.Equals(employeeId) && c.IsActive.Equals(true) && d.AppraisalId.Equals(appraisalId)
                          select new EmployeeQuestionRatingModel
                          {
                              AppraisalQuestionId = d.AppraisalQuestionId,
                              AppraisalId = d.AppraisalId,
                              AppraiseeRatingId = d.AppraiseeRatingId,
                              AppraiserRatingId = d.AppraiserRatingId,
                              EmployeeAppraisalId = d.EmployeeAppraisalId,
                              EmployeeId = d.EmployeeId,
                              Question = q.Question,
                              Status = v.Status,
                              EmployeeQuestionRatingId = d.EmployeeQuestionRatingId,
                              DateCreated = d.DateCreated,
                              DateModified = d.DateModified,
                          }).OrderBy(d => d.EmployeeQuestionRatingId);

            return result;
        }
        
        internal static IAnnualAssesingPerformance getAnnualAssessingPerformanceByCompanyIdYearId(HRMSEntities db, int companyId, int yearId)
        {
            var result = (from d in db.AnnualAssessingPerformances
                          where d.CompanyId.Equals(companyId) && d.IsActive.Equals(true) && d.YearId.Equals(yearId)
                          select new AnnualAssesingPerformanceModel
                          {
                              AnnualAssessingPerformanceId = d.AnnualAssessingPerformanceId,
                              CompanyId = d.CompanyId,
                              YearId = d.YearId,
                              IsActive = d.IsActive,

                              DateCreated = d.DateCreated,
                              DateModified = d.DateModified,
                          }).FirstOrDefault();

            return result;
        }
        
        internal static IEnumerable<IAnnualAssesingPerformance> getAnnualAssessingPerformanceByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.AnnualAssessingPerformances
                          join c in db.Years on d.YearId equals c.YearId
                          join v in db.Companies on d.CompanyId equals v.CompanyId
                          where d.CompanyId.Equals(companyId) && d.IsActive.Equals(true)
                          select new AnnualAssesingPerformanceModel
                          {
                              AnnualAssessingPerformanceId = d.AnnualAssessingPerformanceId,
                              CompanyId = d.CompanyId,
                              YearId = d.YearId,
                              IsActive = d.IsActive,
                              CompanyName = v.CompanyName,
                              Year = c.Year1,
                              DateCreated = d.DateCreated,
                              DateModified = d.DateModified,
                          }).OrderBy(d => d.AnnualAssessingPerformanceId);

            return result;
        }
        
        internal static IAnnualAssesingPerformance getAnnualAssessingPerformanceById(HRMSEntities db, int annualAssessingPerformance)
        {
            var result = (from d in db.AnnualAssessingPerformances
                          join c in db.Years on d.YearId equals c.YearId
                          join v in db.Companies on d.CompanyId equals v.CompanyId
                          where d.AnnualAssessingPerformanceId.Equals(annualAssessingPerformance) && d.IsActive.Equals(true)
                          select new AnnualAssesingPerformanceModel
                          {
                              AnnualAssessingPerformanceId = d.AnnualAssessingPerformanceId,
                              CompanyId = d.CompanyId,
                              YearId = d.YearId,
                              IsActive = d.IsActive,
                              CompanyName = v.CompanyName,
                              Year = c.Year1,
                              DateCreated = d.DateCreated,
                              DateModified = d.DateModified,
                              IsOpen =  d.IsOpen,
                          }).FirstOrDefault();

            return result;
        }
        
        internal static IEnumerable<IEmployeeAnnualAssessingPerformance> getEmployeeAnnualAssessingPerformanceListById(HRMSEntities db, int annualAssessingPerformanceId)
        {
            var result = (from d in db.EmployeeAnnualAssessingPerformances
                          join b in db.Employees on d.RevieweeId equals b.EmployeeId
                          join c in db.AnnualAssessingPerformances on d.AnnualAssessingPerformanceId equals c.AnnualAssessingPerformanceId
                          join v in db.Companies on d.CompanyId equals v.CompanyId
                          join n in db.Years on c.YearId equals n.YearId
                          where d.AnnualAssessingPerformanceId.Equals(annualAssessingPerformanceId) && d.IsActive.Equals(true)
                          select new EmployeeAnnualAssessingPerformanceModel
                          {
                              EmployeeAnnualAssesssingPerformanceId = d.EmployeeAnnualAssesssingPerformanceId,

                              AnnualAssessingPerformanceId = d.AnnualAssessingPerformanceId,
                              Things_I_Did_Not_Do_Well = d.Things_I_Did_Not_Do_Well,
                              Thing_I_Did_Well = d.Thing_I_Did_Well,
                              Driven_Exceptional_Client_Service = d.Driven_Exceptional_Client_Service,
                              Highest_Performing_Teams = d.Highest_Performing_Teams,
                              Examples_Of_Living_Our_Values = d.Examples_Of_Living_Our_Values,
                              Enhanced_Quality_And_Effective_Risk_Management = d.Enhanced_Quality_And_Effective_Risk_Management,
                              ReviewerRatingId = d.ReviewerRatingId,
                              RevieweeRatingId = d.RevieweeRatingId,
                              FinalRatingId = d.FinalRatingId,
                              ReviewerComment = d.ReviewerComment,
                              FinalRatingComment = d.FinalRatingComment,
                              RevieweeId = d.RevieweeId,
                              Reviewee  = b.LastName + " " + b.FirstName,
                              ReviewerId = d.ReviewerId,
                              FinalReviewerId = d.FinalReviewerId,
                              DateOfFinalReview = d.DateOfFinalReview,
                              DateOfReviewee = d.DateOfReviewee,
                              DateOfReviewer = d.DateOfReviewer,
                              Status = d.Status,
                              CompanyId = d.CompanyId,
                              CompanyName = v.CompanyName,
                              Year = n.Year1,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                          }).OrderBy(p=>p.EmployeeAnnualAssesssingPerformanceId);

            return result;
        }
        
        internal static IEnumerable<IEmployeeAnnualAssessingPerformance> getEmployeeAnnualAssessingPerformanceListByEmployeeId(HRMSEntities db, int employeeId)
        {
            var result = (from d in db.EmployeeAnnualAssessingPerformances
                          join c in db.AnnualAssessingPerformances on d.AnnualAssessingPerformanceId equals c.AnnualAssessingPerformanceId
                          join b in db.Companies on d.CompanyId equals b.CompanyId
                          join z in db.Employees on d.RevieweeId equals z.EmployeeId
                          join q in db.Years on c.YearId equals q.YearId
                          where d.RevieweeId == employeeId && d.IsActive.Equals(true)
                          select new EmployeeAnnualAssessingPerformanceModel
                          {
                              EmployeeAnnualAssesssingPerformanceId = d.EmployeeAnnualAssesssingPerformanceId,

                              AnnualAssessingPerformanceId = d.AnnualAssessingPerformanceId,
                              Things_I_Did_Not_Do_Well = d.Things_I_Did_Not_Do_Well,
                              Thing_I_Did_Well = d.Thing_I_Did_Well,
                              Driven_Exceptional_Client_Service = d.Driven_Exceptional_Client_Service,
                              Highest_Performing_Teams = d.Highest_Performing_Teams,
                              Examples_Of_Living_Our_Values = d.Examples_Of_Living_Our_Values,
                              Enhanced_Quality_And_Effective_Risk_Management = d.Enhanced_Quality_And_Effective_Risk_Management,
                              ReviewerRatingId = d.ReviewerRatingId,
                              RevieweeRatingId = d.RevieweeRatingId,
                              FinalRatingId = d.FinalRatingId,
                              ReviewerComment = d.ReviewerComment,
                              FinalRatingComment = d.FinalRatingComment,
                              RevieweeId = d.RevieweeId,
                              Reviewee = z.LastName + " " + z.FirstName,

                              ReviewerId = d.ReviewerId,
                              FinalReviewerId = d.FinalReviewerId,
                              DateOfFinalReview = d.DateOfFinalReview,
                              DateOfReviewee = d.DateOfReviewee,
                              DateOfReviewer = d.DateOfReviewer,
                              Status = d.Status,
                              CompanyId = d.CompanyId,
                              CompanyName = b.CompanyName,
                              Year = q.Year1,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                          }).OrderBy(o => o.EmployeeAnnualAssesssingPerformanceId);

            return result;
        }
        
        internal static IEnumerable<IEmployeeAnnualAssessingPerformance> getEmployeeAnnualAssessingPerformanceListBySupervisorId(HRMSEntities db, int employeeId)
        {
            var result = (from d in db.EmployeeAnnualAssessingPerformances
                          join c in db.AnnualAssessingPerformances on d.AnnualAssessingPerformanceId equals c.AnnualAssessingPerformanceId
                          join b in db.Companies on d.CompanyId equals b.CompanyId
                          join z in db.Employees on d.RevieweeId equals z.EmployeeId
                          join q in db.Years on c.YearId equals q.YearId
                          where d.ReviewerId == employeeId && d.IsActive.Equals(true)
                          select new EmployeeAnnualAssessingPerformanceModel
                          {
                              EmployeeAnnualAssesssingPerformanceId = d.EmployeeAnnualAssesssingPerformanceId,

                              AnnualAssessingPerformanceId = d.AnnualAssessingPerformanceId,
                              Things_I_Did_Not_Do_Well = d.Things_I_Did_Not_Do_Well,
                              Thing_I_Did_Well = d.Thing_I_Did_Well,
                              Driven_Exceptional_Client_Service = d.Driven_Exceptional_Client_Service,
                              Highest_Performing_Teams = d.Highest_Performing_Teams,
                              Examples_Of_Living_Our_Values = d.Examples_Of_Living_Our_Values,
                              Enhanced_Quality_And_Effective_Risk_Management = d.Enhanced_Quality_And_Effective_Risk_Management,
                              ReviewerRatingId = d.ReviewerRatingId,
                              RevieweeRatingId = d.RevieweeRatingId,
                              FinalRatingId = d.FinalRatingId,
                              ReviewerComment = d.ReviewerComment,
                              FinalRatingComment = d.FinalRatingComment,
                              RevieweeId = d.RevieweeId,
                              Reviewee = z.LastName + " " + z.FirstName,

                              ReviewerId = d.ReviewerId,
                              FinalReviewerId = d.FinalReviewerId,
                              DateOfFinalReview = d.DateOfFinalReview,
                              DateOfReviewee = d.DateOfReviewee,
                              DateOfReviewer = d.DateOfReviewer,
                              Status = d.Status,
                              CompanyId = d.CompanyId,
                              CompanyName = b.CompanyName,
                              Year = q.Year1,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                          }).OrderBy(o => o.EmployeeAnnualAssesssingPerformanceId);

            return result;
        }
        
        internal static IEmployeeAnnualAssessingPerformance getEmployeeAnnualAssessingPerformanceListByEmployeeYearId(HRMSEntities db, int employeeId, int yearId)
        {
            var result = (from d in db.EmployeeAnnualAssessingPerformances
                          join b in db.Employees on d.RevieweeId equals b.EmployeeId
                          join c in db.AnnualAssessingPerformances on d.AnnualAssessingPerformanceId equals c.AnnualAssessingPerformanceId
                          join v in db.Companies on d.CompanyId equals v.CompanyId
                          join n in db.Years on c.YearId equals n.YearId
                          where d.RevieweeId.Equals(employeeId) && c.YearId.Equals(yearId) && d.IsActive.Equals(true)
                          select new EmployeeAnnualAssessingPerformanceModel
                          {
                              EmployeeAnnualAssesssingPerformanceId = d.EmployeeAnnualAssesssingPerformanceId,

                              AnnualAssessingPerformanceId = d.AnnualAssessingPerformanceId,
                              Things_I_Did_Not_Do_Well = d.Things_I_Did_Not_Do_Well,
                              Thing_I_Did_Well = d.Thing_I_Did_Well,
                              Driven_Exceptional_Client_Service = d.Driven_Exceptional_Client_Service,
                              Highest_Performing_Teams = d.Highest_Performing_Teams,
                              Examples_Of_Living_Our_Values = d.Examples_Of_Living_Our_Values,
                              Enhanced_Quality_And_Effective_Risk_Management = d.Enhanced_Quality_And_Effective_Risk_Management,
                              ReviewerRatingId = d.ReviewerRatingId,
                              RevieweeRatingId = d.RevieweeRatingId,
                              FinalRatingId = d.FinalRatingId,
                              ReviewerComment = d.ReviewerComment,
                              FinalRatingComment = d.FinalRatingComment,
                              RevieweeId = d.RevieweeId,
                              Reviewee = b.LastName + " " + b.FirstName,
                              ReviewerId = d.ReviewerId,
                              FinalReviewerId = d.FinalReviewerId,
                              DateOfFinalReview = d.DateOfFinalReview,
                              DateOfReviewee = d.DateOfReviewee,
                              DateOfReviewer = d.DateOfReviewer,
                              Status = d.Status,
                              CompanyId = d.CompanyId,
                              CompanyName = v.CompanyName,
                              Year = n.Year1,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                          }).FirstOrDefault();

            return result;
        }
        
        internal static IEmployeeAnnualAssessingPerformance getEmployeeAnnualAssessingPerformanceById(HRMSEntities db, int employeeAnnualAssessingPerformanceId)
        {
            var result = (from d in db.EmployeeAnnualAssessingPerformances
                          join c in db.AnnualAssessingPerformances on d.AnnualAssessingPerformanceId equals c.AnnualAssessingPerformanceId
                          join v in db.Companies on d.CompanyId equals v.CompanyId
                          join n in db.Years on c.YearId equals n.YearId
                          where d.EmployeeAnnualAssesssingPerformanceId.Equals(employeeAnnualAssessingPerformanceId) && d.IsActive.Equals(true)
                          select new EmployeeAnnualAssessingPerformanceModel
                          {
                              EmployeeAnnualAssesssingPerformanceId = d.EmployeeAnnualAssesssingPerformanceId,
                              AnnualAssessingPerformanceId = d.AnnualAssessingPerformanceId,
                              Things_I_Did_Not_Do_Well = d.Things_I_Did_Not_Do_Well,
                              Thing_I_Did_Well = d.Thing_I_Did_Well,
                              Driven_Exceptional_Client_Service = d.Driven_Exceptional_Client_Service,
                              Highest_Performing_Teams = d.Highest_Performing_Teams,
                              Examples_Of_Living_Our_Values = d.Examples_Of_Living_Our_Values,
                              Enhanced_Quality_And_Effective_Risk_Management = d.Enhanced_Quality_And_Effective_Risk_Management,
                              ReviewerRatingId = d.ReviewerRatingId,
                              RevieweeRatingId = d.RevieweeRatingId,
                              FinalRatingId = d.FinalRatingId,
                              ReviewerComment = d.ReviewerComment,
                              FinalRatingComment = d.FinalRatingComment,
                             RevieweeId = d.RevieweeId,
                              ReviewerId = d.ReviewerId,
                              FinalReviewerId = d.FinalReviewerId,
                              DateOfFinalReview = d.DateOfFinalReview,
                              DateOfReviewee = d.DateOfReviewee,
                              DateOfReviewer = d.DateOfReviewer,
                              Status = d.Status,
                              CompanyId = d.CompanyId,
                              CompanyName = v.CompanyName,
                              Year = n.Year1,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                          }).FirstOrDefault();

            return result;
        }
        
        internal static IEnumerable<IEmployeeAppraisal> getAppraisalListEmployee(HRMSEntities db, int companyId, int employeeId)
        {
            var result = (from d in db.EmployeeAppraisals
                          join x in db.Companies on d.CompanyId equals x.CompanyId
                          join c in db.Appraisals on d.AppraisalId equals c.AppraisalId
                          where d.CompanyId.Equals(companyId) && d.IsActive.Equals(true) && d.EmployeeId.Equals(employeeId)
                          select new EmployeeAppraisalModel
                          {
                              AppraisalId = d.AppraisalId,
                              CompanyId = d.CompanyId,
                              DateInitiated = c.DateInitiated,
                              CompanyName = x.CompanyName,
                              IsActive = d.IsActive,
                              IsOpened = c.IsOpened,
                              EmployeeId = d.EmployeeId,
                              EmployeeAppraisalId = d.EmployeeAppraisalId,
                              SupervisorId = d.SupervisorId,
                              DateCreated = d.DateCreated,
                              Status = d.Status,
                              DateModified = d.DateModified

                          }).OrderBy(d => d.DateInitiated);


            return result;
        }
        
        internal static IEnumerable<IEmployeeAppraisal> getAppraiseeListEmployee(HRMSEntities db, int companyId, int supervisorId)
        {
            var result = (from d in db.EmployeeAppraisals
                          join x in db.Companies on d.CompanyId equals x.CompanyId
                          join c in db.Appraisals on d.AppraisalId equals c.AppraisalId
                          where d.CompanyId.Equals(companyId) && d.IsActive.Equals(true)  && d.SupervisorId.Equals(supervisorId)
                          select new EmployeeAppraisalModel
                          {
                              AppraisalId = d.AppraisalId,
                              CompanyId = d.CompanyId,
                              DateInitiated = c.DateInitiated,
                              CompanyName = x.CompanyName,
                              IsActive = d.IsActive,
                              IsOpened = c.IsOpened,
                              EmployeeId = d.EmployeeId,
                              EmployeeAppraisalId = d.EmployeeAppraisalId,
                              SupervisorId = d.SupervisorId,
                              DateCreated = d.DateCreated,
                              Status = d.Status,
                              DateModified = d.DateModified
                              
                          }).OrderBy(d => d.DateInitiated);

            return result;
        }
        
        internal static IAppraisal getAppraisalByCompanyYearPeriod(HRMSEntities db, int companyId, int yearId, int peeriodId)
        {
            var result = (from d in db.Appraisals
                          join c in db.Years on d.AppraisalYearId equals c.YearId
                          join x in db.Companies on d.CompanyId equals x.CompanyId
                          join z in db.AppraisalPeriods on d.AppraisalPeriodId equals z.AppraisalPeriodId
                          where d.CompanyId.Equals(companyId) && d.IsActive.Equals(true) && d.AppraisalYearId.Equals(yearId) && d.AppraisalPeriodId.Equals(peeriodId)
                          select new AppraisalModel
                          {
                              AppraisalId = d.AppraisalId,
                              //EmployeeId = s.EmployeeId,
                              CompanyId = x.CompanyId,
                              AppraisalYearId = d.AppraisalYearId,
                              AppraisalPeriodId = d.AppraisalPeriodId,
                              //InitiationDate = d.InitiationDate,
                              //AppraisalPeriodName = z.Appraisalperiod1,
                              //AppraisalYearName = c.Year1,
                              //AppraisalSummary = d.AppraisalSummary,
                              //KeyStrength = d.KeyStrength,
                              //AreasOfImprovement = d.AreasOfImprovement,
                              //EmployeeName = s.FirstName + " " + s.LastName,
                              CompanyName = x.CompanyName,
                              //AppraisalAgreedDate = d.AppraisalAgreedDate,
                              //DateApproved = d.DateApproved,
                              //ApprovedActionEffectiveDate = d.ApprovedActionEffectiveDate,
                              //DateCreated = d.DateCreated,
                              IsActive = d.IsActive,

                              //AppraiserId = d.AppraiserId,
                              //AppraiserRatingId = d.AppraiserRatingId,
                              //RecommendedActionId = d.RecommendedActionId,
                              //FinalRatingId = d.FinalRatingId,
                              //ApprovedActionId = d.ApprovedActionId

                          }).FirstOrDefault();

            return result;
        }
        
        internal static IAppraisal getAppraisalByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.Appraisals
                          join c in db.Years on d.AppraisalYearId equals c.YearId
                          join x in db.Companies on d.CompanyId equals x.CompanyId
                          join z in db.AppraisalPeriods on d.AppraisalPeriodId equals z.AppraisalPeriodId
                          where d.CompanyId.Equals(companyId) && d.IsActive.Equals(true) && d.IsOpened.Equals(true)
                          select new AppraisalModel
                          {
                              AppraisalId = d.AppraisalId,
                              CompanyId = x.CompanyId,
                              AppraisalYearId = d.AppraisalYearId,
                              AppraisalPeriodId = d.AppraisalPeriodId,
                              CompanyName = x.CompanyName,
                              IsActive = d.IsActive,
                              IsOpened = d.IsOpened,
                              DateInitiated = d.DateInitiated,

                          }).FirstOrDefault();

            return result;
        }
        
        internal static IEnumerable<IEmployeeAppraisal> getAppraisalListBySupervisorId(HRMSEntities db, int supervisorId, int companyId, int appraisalId)
        {
            var result = (from d in db.EmployeeAppraisals
                          join s in db.Employees on d.EmployeeId equals s.EmployeeId
                          join w in db.Appraisals on d.AppraisalId equals w.AppraisalId
                          join c in db.Years on w.AppraisalYearId equals c.YearId
                          join x in db.Companies on d.CompanyId equals x.CompanyId
                          join z in db.AppraisalPeriods on w.AppraisalPeriodId equals z.AppraisalPeriodId
                          where (d.CompanyId.Equals(companyId) && d.IsActive.Equals(true) && w.IsOpened.Equals(true) && d.AppraisalId.Equals(appraisalId)) && (d.SupervisorId == supervisorId)
                          select new EmployeeAppraisalModel
                          {
                              AppraisalId = d.AppraisalId,
                              EmployeeId = d.EmployeeId,
                              CompanyId = d.CompanyId,
                              AppraisalYear = c.Year1,
                              AppraisalPeriod = z.Appraisalperiod1,
                              EmployeeAppraisalId = d.EmployeeAppraisalId,
                              SupervisorId = d.SupervisorId,
                              DateCreated = d.DateCreated,
                              DateModified = d.DateModified,
                              IsActive = d.IsActive,
                              DateInitiated = w.DateInitiated,
                              Status = d.Status

                          }).OrderBy(p=>p.DateCreated);

            return result;
        }
        
        internal static IEnumerable<IEmployeeAppraisal> getAppraisalListByEmployeeIdSuperrvisorId(HRMSEntities db, int supervisorId, int companyId, int appraisalId)
        {
            var result = (from d in db.EmployeeAppraisals
                          join s in db.Employees on d.EmployeeId equals s.EmployeeId
                          join w in db.Appraisals on d.AppraisalId equals w.AppraisalId
                          join c in db.Years on w.AppraisalYearId equals c.YearId
                          join x in db.Companies on d.CompanyId equals x.CompanyId
                          join z in db.AppraisalPeriods on w.AppraisalPeriodId equals z.AppraisalPeriodId
                          where (d.CompanyId.Equals(companyId) && d.IsActive.Equals(true) && w.IsOpened.Equals(true) && d.AppraisalId.Equals(appraisalId)) && (d.SupervisorId == supervisorId || d.EmployeeId == supervisorId)
                          select new EmployeeAppraisalModel
                          {
                              AppraisalId = d.AppraisalId,
                              EmployeeId = d.EmployeeId,
                              CompanyId = d.CompanyId,
                              AppraisalYear = c.Year1,
                              AppraisalPeriod = z.Appraisalperiod1,
                              EmployeeAppraisalId = d.EmployeeAppraisalId,
                              SupervisorId = d.SupervisorId,
                              DateCreated = d.DateCreated,
                              DateModified = d.DateModified,
                              IsActive = d.IsActive,
                              DateInitiated = w.DateInitiated,
                              Status = d.Status

                          }).OrderBy(p => p.DateCreated);

            return result;
        }
        
        internal static IEnumerable<IEmployeeAppraisal> getEmployeeAppraisalByAppraisalId(HRMSEntities db, int companyId, int appraisalId)
        {
            var result = (from d in db.EmployeeAppraisals
                          join s in db.Employees on d.EmployeeId equals s.EmployeeId
                          join w in db.Appraisals on d.AppraisalId equals w.AppraisalId
                          join c in db.Years on w.AppraisalYearId equals c.YearId
                          join x in db.Companies on d.CompanyId equals x.CompanyId
                          join z in db.AppraisalPeriods on w.AppraisalPeriodId equals z.AppraisalPeriodId
                          where d.CompanyId.Equals(companyId) && d.IsActive.Equals(true) && w.IsOpened.Equals(true) && d.AppraisalId.Equals(appraisalId)
                          select new EmployeeAppraisalModel
                          {
                              AppraisalId = d.AppraisalId,
                              EmployeeId = d.EmployeeId,
                              CompanyId = d.CompanyId,
                              EmployeeName = s.LastName + " " + s.FirstName,
                              AppraisalYear = c.Year1,
                              AppraisalPeriod = z.Appraisalperiod1,
                              EmployeeAppraisalId = d.EmployeeAppraisalId,
                              SupervisorId = d.SupervisorId,
                              DateCreated = d.DateCreated,
                              DateModified = d.DateModified,
                              IsActive = d.IsActive,
                              DateInitiated = w.DateInitiated,
                              Status = d.Status,

                          }).OrderBy(p => p.DateCreated);

            return result;
        }
        
        internal static IEnumerable<IEmployeeAppraisal> getAppraisalListByEmployeeId(HRMSEntities db, int employeeId, int companyId, int appraisalId)
        {
            var result = (from d in db.EmployeeAppraisals
                          join s in db.Employees on d.EmployeeId equals s.EmployeeId
                          join w in db.Appraisals on d.AppraisalId equals w.AppraisalId
                          join c in db.Years on w.AppraisalYearId equals c.YearId
                          join x in db.Companies on d.CompanyId equals x.CompanyId
                          join z in db.AppraisalPeriods on w.AppraisalPeriodId equals z.AppraisalPeriodId
                          where d.CompanyId.Equals(companyId) && d.IsActive.Equals(true) && w.IsOpened.Equals(true) && d.AppraisalId.Equals(appraisalId) && d.EmployeeId.Equals(employeeId)
                          select new EmployeeAppraisalModel
                          {
                              AppraisalId = d.AppraisalId,
                              EmployeeId = d.EmployeeId,
                              CompanyId = d.CompanyId,
                              AppraisalYear = c.Year1,
                              AppraisalPeriod = z.Appraisalperiod1,
                              EmployeeAppraisalId = d.EmployeeAppraisalId,
                              SupervisorId = d.SupervisorId,
                              DateCreated = d.DateCreated,
                              DateModified = d.DateModified,
                              IsActive = d.IsActive,
                              DateInitiated = w.DateInitiated,
                              Status = d.Status,

                          }).OrderBy(p => p.DateCreated);

            return result;
        }
        
        internal static IEmployeeAppraisal getEmployeeAppraisalByCompanyIdAppraisalIdEmployeeId(HRMSEntities db, int employeeId, int companyId, int appraisalId)
        {
            var result = (from d in db.EmployeeAppraisals
                          join s in db.Employees on d.EmployeeId equals s.EmployeeId
                          join w in db.Appraisals on d.AppraisalId equals w.AppraisalId
                          join c in db.Years on w.AppraisalYearId equals c.YearId
                          join x in db.Companies on d.CompanyId equals x.CompanyId
                          join z in db.AppraisalPeriods on w.AppraisalPeriodId equals z.AppraisalPeriodId
                          where (d.CompanyId.Equals(companyId) && d.IsActive.Equals(true) && w.IsOpened.Equals(true) && d.AppraisalId.Equals(appraisalId)) && (d.SupervisorId == employeeId || d.EmployeeId == employeeId)
                          select new EmployeeAppraisalModel
                          {
                              AppraisalId = d.AppraisalId,
                              EmployeeId = d.EmployeeId,
                              CompanyId = d.CompanyId,
                              AppraisalYear = c.Year1,
                              AppraisalPeriod = z.Appraisalperiod1,
                              EmployeeAppraisalId = d.EmployeeAppraisalId,
                              SupervisorId = d.SupervisorId,
                              DateCreated = d.DateCreated,
                              DateModified = d.DateModified,
                              IsActive = d.IsActive,
                              DateInitiated = w.DateInitiated,
                              Status = d.Status

                          }).FirstOrDefault();

            return result;
        }
        
        internal static IEnumerable<IFeedbackModel> GetFeedBackById(HRMSEntities db,int companyId)
        {
            var result = ( from f in db.FeedBacks
                          where f.CompanyId == companyId
                          join y in db.Years on f.YearId equals y.YearId
                          join c in db.Companies on f.CompanyId equals c.CompanyId
                          select new Models.FeedbackModel
                          {
                              FeedbackId = f.FeedbackId,
                              CompanyId = c.CompanyId,
                              years = y.Year1,
                              IsActive = f.IsActive,
                              DateCreated = f.DateCreated,
                              IsLock = f.IsLock,
                              CompanyName = c.CompanyName,
                              noOfFeedbacks = f.NoOfFeedBacks,
                              
                           }).ToList();

           
             
            return result;
                        

        }

        internal static IEnumerable<IEmployeeFeedbackModel> GetEmployeeFeedbackById(HRMSEntities db, int employeeFeedBackId, int employeeId, int companyId, int feedbackId)
        {
            var result = (from d in db.EmployeeFeedbacks
                          where d.EmployeeFeedbackId == employeeFeedBackId && d.CompanyId == companyId && d.FeedbackId == feedbackId && employeeId == employeeId
                          select new Models.EmployeeFeedbackModel
                          {
                              EmployeeFeedbackId = d.EmployeeFeedbackId,
                              EmployeeId = d.EmployeeId ?? 0,
                              WhatAreas = d.WhatAreas,
                              InWhatContext = d.InWhatContext,
                              CompanyId = d.CompanyId,
                              DateCreated = d.DateCreated,
                              DateOfFeedback = d.DateOfFeedback,
                              Experience = d.Experience,
                              FeedbackId = d.FeedbackId,
                              FeedbackOnEmployeeId = d.FeedbackOnEmployeeId,
                              ProvideOverview = d.ProvideOverview
                          }).ToList();
            return result;
        }

        internal static IEmployeeFeedbackModel getEmployeeFeedbackByFeedbackIdEmployeeIdFeedbackOnEmployeeId(HRMSEntities db, int employeeId, int feedbackId, int feedonemployeeId)
        {
            var result = (from d in db.EmployeeFeedbacks
                          where d.EmployeeId == employeeId && d.FeedbackId == feedbackId && d.EmployeeFeedbackId == feedonemployeeId
                          select new Models.EmployeeFeedbackModel
                          {
                              EmployeeFeedbackId = d.EmployeeFeedbackId,
                              EmployeeId = d.EmployeeId ?? 0,
                              WhatAreas = d.WhatAreas,
                              InWhatContext = d.InWhatContext,
                              CompanyId = d.CompanyId,
                              DateCreated = d.DateCreated,
                              DateOfFeedback = d.DateOfFeedback,
                              Experience = d.Experience,
                              FeedbackId = d.FeedbackId,
                              FeedbackOnEmployeeId = d.FeedbackOnEmployeeId,
                              ProvideOverview = d.ProvideOverview
                          }).FirstOrDefault();
            return result;
        }
        
        internal static IEnumerable<IEmployeeFeedbackModel> GetEmployeeFeedbackByEmployeeFeedbackId(HRMSEntities db, int employeeFeedBackId)
        {
            var result = (from d in db.EmployeeFeedbacks
                          where d.EmployeeFeedbackId == employeeFeedBackId
                          select new Models.EmployeeFeedbackModel
                          {
                              EmployeeFeedbackId = d.EmployeeFeedbackId,
                              EmployeeId = d.EmployeeId ?? 0,
                              WhatAreas = d.WhatAreas,
                              InWhatContext = d.InWhatContext,
                              CompanyId = d.CompanyId,
                              DateCreated = d.DateCreated,
                              DateOfFeedback = d.DateOfFeedback,
                              Experience = d.Experience,
                              FeedbackId = d.FeedbackId,
                              FeedbackOnEmployeeId = d.FeedbackOnEmployeeId,
                              ProvideOverview = d.ProvideOverview,
                          }).ToList();
            return result;
        }

        internal static IEnumerable<IMilestone> getMilestoneListByTaskId(HRMSEntities db, int milestoneId)
        {
            var result = (from d in db.Milestones
                          where d.MilestoneId.Equals(milestoneId)
                          join c in db.EmployeeTasks on d.TaskId equals c.TaskId
                          select new Models.MilestoneModel
                          {
                              MilestoneId = d.MilestoneId,
                              MilestoneName = d.MilestoneName,
                              MilestoneDescription = d.MilestoneDescription,

                              hasStarted = d.hasStarted,
                              DateStarted = d.DateStarted,
                              
                              hasCompleted = d.hasCompleted,
                              DateCompleted = d.DateCompleted,

                              IsApproved = d.IsApproved,
                              DateApproved = d.DateApproved,
                              ApprovalComment = d.ApprovalComment,

                              DateCreated = d.DateCreated,
                              IsActive = d.IsActive,
                              TaskId = d.TaskId,
                              TaskName = c.TaskName

                          }).OrderBy(p=>p.MilestoneId);
            return result;
        }

        

    }
}