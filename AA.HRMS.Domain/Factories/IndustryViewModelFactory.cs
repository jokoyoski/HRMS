using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Factories

{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IIndustryViewModelFactory" />
    public class IndustryViewModelFactory : IIndustryViewModelFactory
    {
        /// <summary>
        /// Creates the industry view.
        /// </summary>
        /// <returns></returns>
        public IIndustryView CreateIndustryView()
        {
            var viewModel = new IndustryView
            {
                ProcessingMessage = string.Empty
            };
            return viewModel;
        }

        /// <summary>
        /// Creates the updated industry view.
        /// </summary>
        /// <param name="industryInfo">The industry information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">industryInfo</exception>
        public IIndustryView CreateUpdatedIndustryView(IIndustryView industryInfo, string processingMessage)
        {
            if (industryInfo == null)
                throw new ArgumentNullException(nameof(industryInfo));
            industryInfo.ProcessingMessage = processingMessage;

            return industryInfo;
        }
        /// <summary>
        /// Edits the industry view.
        /// </summary>
        /// <param name="industryInfo">The industry information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">industryInfo</exception>
        public IIndustryView EditIndustryView(IIndustry industryInfo)
        {
            if (industryInfo == null)
                throw new ArgumentNullException(nameof(industryInfo));

            var industryView = new IndustryView
            {
                IndustryId = industryInfo.IndustryId,
                IndustryName = industryInfo.IndustryName,
                IsActive = industryInfo.IsActive,
                DateCreated = industryInfo.DateCreated
            };

            return industryView;
        }

        /// <summary>
        /// Edits the updated industry view.
        /// </summary>
        /// <param name="IndustryInfo">The industry information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">IndustryInfo</exception>
        public IIndustryView EditUpdatedIndustryView(IIndustryView IndustryInfo, string processingMessage)
        {
            if (IndustryInfo == null)
                throw new ArgumentNullException(nameof(IndustryInfo));

            IndustryInfo.ProcessingMessage = processingMessage;

            return IndustryInfo;
        }
    }
}
