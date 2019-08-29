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
    public class TrainingAnalysisQueries
    {

        internal static IEnumerable<ITrainingNeedAnalysis> GetTrainingAnalysis(HRMSEntities db, int CompanyId)
        {
            var Result = (from d in db.TrainingNeedAnalysis
                          join s in db.Trainings on d.TrainingId equals s.TrainingID
                          join q in db.Companies on d.CompanyId equals q.CompanyId
                          join w in db.JobTitles on d.JobId equals w.JobTitleId
                          join p in db.FrequencyOfDeliveries on d.FrequecyOfDeliveryId equals p.FrequencyOfDeliveryId
                          where d.CompanyId.Equals(CompanyId)
                          select new TrainingNeedAnalysisModel
                          {
                            TrainingNeedAnaylsisId = d.TrainingNeedAnaylsisId,
                            TrainingId = d.TrainingId,
                            CompanyId = q.CompanyId,
                            JobId = d.JobId,
                            TrainingDescription = d.TrainingDescription,
                            MethodOfDelivery=d.MethodOfDelivery,
                            TrainingProvider = d.TrainingProvider,
                            Cost = d.Cost,
                            Location = d.Location,
                            IsProviderApproved = d.IsProviderApproved,
                            ApprovedBudget = d.ApprovedBudget,
                            FrequecyOfDeliveryId = d.FrequecyOfDeliveryId,
                            TrainingDuration = d.TrainingDuration,
                            CertificateIssued =d.CertificateIssued,
                            DateCreated = d.DateCreated,
                            CurrencyId = d.CurrencyId,
                            ApprovedBudgetCurrency = d.ApprovedBudgetCurrency,

                            CompanyName = q.CompanyName,
                            JobTitle = w.JobTitleName,
                            TrainingName = s.TrainingName,
                            FrequencyOfDelivery = p.FrequencyOfDelivery1
                            

                          }).OrderBy(p => p.CompanyName);
            return Result;
        }
    }
}
