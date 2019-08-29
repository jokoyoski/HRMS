using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
   public interface ITrainingHistoryListView
    {
        int UserId { get; set; }
       string CertificateName { get; set; }
       string ProcessingMessage { get; set; }
         int TrainingHistoryId { get; set; }
        bool IsActive { get; set; }
        IList<ITrainingHistoryModel> trainingHistoryModel { get; set; }
    }
}
