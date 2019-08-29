using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ITrainingNeedAnalysisService
    {
        /// <summary>
        /// Gets the trainingNeedAnalysis registration view.
        /// </summary>
        /// <returns></returns>
        ITrainingNeedAnalysisView GetTrainingNeedAnalysisRegistrationView(int loggedUserId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainingNeedAnalysisInfo"></param>
        /// <returns></returns>
        string ProcessTrainingNeedAnalysisInfo(ITrainingNeedAnalysisView trainingNeedAnalysisInfo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="selectedTrainingNeedAnalysisId"></param>
        /// <param name="selectedCompany"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        ITrainingNeedAnalysisListView CreateTrainingNeedAnalysisList(int userId, int? selectedTrainingNeedAnalysisId, string selectedCompany, string processingMessage);
    }
}
