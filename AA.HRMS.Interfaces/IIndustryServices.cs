using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IIndustryServices
    {
        /// <summary>
        /// Gets the industry create view.
        /// </summary>
        /// <returns></returns>
        IIndustryView GetIndustryCreateView();

        /// <summary>
        /// Gets the industry create view.
        /// </summary>
        /// <param name="industryInfo">The industry information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IIndustryView GetIndustryCreateView(IIndustryView industryInfo, string processingMessage);

        /// <summary>
        /// Processes the industry create view.
        /// </summary>
        /// <param name="industryInfo">The industry information.</param>
        /// <returns></returns>
        string ProcessIndustryCreateView(IIndustryView industryInfo);

        /// <summary>
        /// Processes the industry edit view.
        /// </summary>
        /// <param name="IndustryInfo">The industry information.</param>
        /// <returns></returns>
        string ProcessIndustryEditView(IIndustryView IndustryInfo);

        /// <summary>
        /// Gets the industry edit view.
        /// </summary>
        /// <param name="industryId">The industry identifier.</param>
        /// <returns></returns>
        IIndustryView GetIndustryEditView(int industryId);
    }
}
