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
    public class TrainingNeedAnalysisQueries
    {

        /// <summary>
        /// Gets the training need analysis by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trainingNeedAnalysisId">The training need analysis identifier.</param>
        /// <returns></returns>
        internal static ITrainingNeedAnalysis getTrainingNeedAnalysisById(HRMSEntities db, int trainingNeedAnalysisId)
        {
            var result = (from s in db.TrainingNeedAnalysis
                          join x in db.Companies on s.CompanyId equals x.CompanyId
                          join v in db.Trainings on s.TrainingId equals v.TrainingID
                          join b in db.JobTitles on s.JobId equals b.JobTitleId
                          join p in db.FrequencyOfDeliveries on s.FrequecyOfDeliveryId equals p.FrequencyOfDeliveryId
                          where s.CompanyId.Equals(trainingNeedAnalysisId)
                          select new Models.TrainingNeedAnalysisModel
                          {
                              TrainingNeedAnaylsisId = s.TrainingNeedAnaylsisId,
                              JobId = s.JobId,
                              CompanyId = s.CompanyId,
                              DateCreated = s.DateCreated,
                              TrainingId = s.TrainingId,                 
                              MethodOfDelivery = s.MethodOfDelivery,
                              IsProviderApproved = s.IsProviderApproved,
                              Cost = s.Cost,
                              CurrencyId = s.CurrencyId,
                              Location = s.Location,
                              ApprovedBudget = s.ApprovedBudget,
                              ApprovedBudgetCurrency = s.ApprovedBudgetCurrency,
                              FrequecyOfDeliveryId = s.FrequecyOfDeliveryId,
                              CertificateIssued = s.CertificateIssued,
                               TrainingDescription = s.TrainingDescription

                          }).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Gets all my training need analysis.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<ITrainingNeedAnalysis> getAllMyTrainingNeedAnalysis(HRMSEntities db, int companyId)
        {
            var result = (from d in db.TrainingNeedAnalysis
                          where d.CompanyId == companyId
                          join e in db.Companies on d.CompanyId equals e.CompanyId
                          join pdept in db.TrainingNeedAnalysis on d.TrainingNeedAnaylsisId equals pdept.TrainingNeedAnaylsisId 
                          select new TrainingNeedAnalysisModel
                          {
                              TrainingNeedAnaylsisId = d.TrainingNeedAnaylsisId,
                              JobId = d.JobId,
                              CompanyId = d.CompanyId,
                              DateCreated = d.DateCreated,
                              TrainingId = d.TrainingId,
                              MethodOfDelivery = d.MethodOfDelivery,
                              IsProviderApproved = d.IsProviderApproved,
                              Cost = d.Cost,
                              CurrencyId = d.CurrencyId,
                              Location = d.Location,
                              ApprovedBudget = d.ApprovedBudget,
                              ApprovedBudgetCurrency = d.ApprovedBudgetCurrency,
                              FrequecyOfDeliveryId = d.FrequecyOfDeliveryId,
                              CertificateIssued = d.CertificateIssued,
                              TrainingDescription = d.TrainingDescription

                          }).OrderBy(p => p.TrainingNeedAnaylsisId);

            return result;
        }
    }

}
