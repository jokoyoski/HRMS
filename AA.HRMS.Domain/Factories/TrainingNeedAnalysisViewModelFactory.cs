using AA.HRMS.Domain.Models;
using AA.HRMS.Domain.Utilities;
using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Factories
{
    public class TrainingNeedAnalysisViewModelFactory : ITrainingNeedAnalysisViewModelFactory
    {
        public ITrainingNeedAnalysisListView CreateTrainingNeedAnalysisListView(int companyId, int? selectedTrainingNeedAnalysisID, IList<ITrainingNeedAnalysis> TrainingNeedAnalysisCollection, ICompanyDetail company, string processingMessage)
        {
            var filteredList = TrainingNeedAnalysisCollection
                 .Where(x => x.TrainingNeedAnalysisID.Equals(selectedTrainingNeedAnalysisID < 1 ? x.CompanyID : selectedTrainingNeedAnalysisID)).ToList();

            var viewModel = new TrainingNeedAnalysisListView
            {
                TrainingNeedAnalysisCollection = TrainingNeedAnalysisCollection,
                Company = company,
                ProcessingMessage = processingMessage
            };

            return viewModel;
        }

        public ITrainingNeedAnalysisView CreateTrainingNeedAnalysisView(IList<ICompanyDetail> companyCollection)
        {
            //if (trainingNeedAnalysisId == null) throw new ArgumentNullException(nameof(trainingNeedAnalysisId));

            var companyDDL = GetDropDownList.CompanyListItems(companyCollection, -1);

            var viewModel = new TrainingNeedAnalysisView
            {
                //TrainingNeedAnalysisID = trainingNeedAnalysisId,
                CompanyCollection = companyDDL
            };

            return viewModel;
        }

        public ITrainingNeedAnalysisView CreateTrainingNeedAnalysisView(int companyId, int? selectedTrainingNeedAnalysisID, IList<ITrainingNeedAnalysis> TrainingNeedAnalysisCollection, ICompanyDetail company, string processingMessage)
        {
            throw new NotImplementedException();
        }
    }
}
