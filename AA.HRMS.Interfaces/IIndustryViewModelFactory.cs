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
    public interface IIndustryViewModelFactory
    {

        /// <summary>
        /// Creates the industry view.
        /// </summary>
        /// <returns></returns>
        IIndustryView CreateIndustryView();
      //  IIndustryView GetIndustryEditView(int industryId);
        //IIndustryView EditUpdatedIndustryView(IIndustryView IndustryInfo, string processingMessage);

       IIndustryView EditIndustryView(IIndustry industryInfo);
        

        /// <summary>
        /// Creates the updated industry view.
        /// </summary>
        /// <param name="industryInfo">The industry information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IIndustryView CreateUpdatedIndustryView(IIndustryView industryInfo, string processingMessage);
    }
}
