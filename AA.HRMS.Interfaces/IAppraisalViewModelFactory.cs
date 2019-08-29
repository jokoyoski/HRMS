using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAppraisalViewModelFactory
    {
        /// <summary>
        /// Creates the appraisal view.
        /// </summary>
        /// <param name="appraisersCollection">The appraisers collection.</param>
        /// <param name="appraisalRatingsCollection">The appraisal ratings collection.</param>
        /// <param name="appraisalActionsCollection">The appraisal actions collection.</param>
        /// <returns></returns>
        IAppraisalView CreateAppraisalView(IList<IAppraiser> appraisersCollection, 
                                           IList<IAppraisalRating> appraisalRatingsCollection, 
                                           IList<IAppraisalAction> appraisalActionsCollection,
                                           IList<IEmployee> employeeCollection);
        /// <summary>
        /// Creates the updated appraisal view.
        /// </summary>
        /// <param name="appraisersCollection">The appraisers collection.</param>
        /// <param name="appraisalRatingsCollection">The appraisal ratings collection.</param>
        /// <param name="appraisalActionsCollection">The appraisal actions collection.</param>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalView CreateUpdatedAppraisalView(IList<IAppraiser> appraisersCollection, 
                                                  IList<IAppraisalRating> appraisalRatingsCollection, 
                                                  IList<IAppraisalAction> appraisalActionsCollection,  
                                                  IAppraisalView appraisalInfo, 
                                                  string processingMessage);
        /// <summary>
        /// Creates the appraisal update view.
        /// </summary>
        /// <param name="appraisersCollection">The appraisers collection.</param>
        /// <param name="appraisalRatingsCollection">The appraisal ratings collection.</param>
        /// <param name="appraisalActionsCollection">The appraisal actions collection.</param>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalView CreateAppraisalUpdateView(IList<IAppraiser> appraisersCollection, 
                                                 IList<IAppraisalRating> appraisalRatingsCollection, 
                                                 IList<IAppraisalAction> appraisalActionsCollection,  
                                                 IAppraisalView appraisalInfo, IList<IEmployee> employeeCollection,
                                                 string processingMessage);
        /// <summary>
        /// Creates the edit appraisal view.
        /// </summary>
        /// <param name="appraisersCollection">The appraisers collection.</param>
        /// <param name="appraisalRatingsCollection">The appraisal ratings collection.</param>
        /// <param name="appraisalActionsCollection">The appraisal actions collection.</param>
        /// <param name="appraisalInfo">The appraisal information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IAppraisalView CreateEditAppraisalView(IList<IAppraiser> appraisersCollection, 
                                               IList<IAppraisalRating> appraisalRatingsCollection, 
                                               IList<IAppraisalAction> appraisalActionsCollection, 
                                               IAppraisal appraisalInfo, 
                                               string processingMessage);
    }
}
