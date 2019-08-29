using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ITrainingNeedAnalysisViewModelFactory
    {

        ITrainingNeedAnalysisListView CreateTrainingNeedAnalysisListView(int companyId, int? selectedTrainingNeedAnalysisID, IList<ITrainingNeedAnalysis> TrainingNeedAnalysisCollection, ICompanyDetail company, string processingMessage);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyCollection"></param>
        /// <returns></returns>
        ITrainingNeedAnalysisView CreateTrainingNeedAnalysisView (IList<ICompanyDetail> companyCollection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="selectedTrainingNeedAnalysisID"></param>
        /// <param name="TrainingNeedAnalysisCollection"></param>
        /// <param name="company"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        ITrainingNeedAnalysisView CreateTrainingNeedAnalysisView (int companyId, int? selectedTrainingNeedAnalysisID, IList<ITrainingNeedAnalysis> TrainingNeedAnalysisCollection, ICompanyDetail company, string processingMessage);
    }
}
