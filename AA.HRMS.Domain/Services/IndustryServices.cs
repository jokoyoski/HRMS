using AA.HRMS.Domain.Factories;
using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Services
{
    public class IndustryServices : IIndustryServices
    {
        private readonly IIndustryRepository industryRepository;

        private readonly IIndustryViewModelFactory industryViewModelFactory;

        public IndustryServices(IIndustryRepository industryRepository,
            IIndustryViewModelFactory industryViewModelFactory)
        {
            this.industryViewModelFactory = industryViewModelFactory;
            this.industryRepository = industryRepository;
        }

        /// <summary>
        /// Gets the industry create view.
        /// </summary>
        /// <returns></returns>
        public IIndustryView GetIndustryCreateView()
        {
            var viewModel = industryViewModelFactory.CreateIndustryView();

            return viewModel;
        }

        /// <summary>
        /// Gets the industry create view.
        /// </summary>
        /// <param name="industryInfo">The industry information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IIndustryView GetIndustryCreateView(IIndustryView industryInfo, string processingMessage)
        {
            var returnViewModel = industryViewModelFactory.CreateUpdatedIndustryView(industryInfo, processingMessage);

            return returnViewModel;
        }

        /// <summary>
        /// Processes the industry create view.
        /// </summary>
        /// <param name="industryInfo">The industry information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">industryInfo</exception>
        public string ProcessIndustryCreateView(IIndustryView industryInfo)
        {
            if (industryInfo == null)
            {
                throw new ArgumentNullException(nameof(industryInfo));
            }

            var processingMessage = string.Empty;

            var message = this.industryRepository.SaveIndustryInfo(industryInfo);

            return message;
        }

        /// <summary>
        /// Gets the industry edit view.
        /// </summary>
        /// <param name="industryId">The industry identifier.</param>
        /// <returns></returns>
        public IIndustryView GetIndustryEditView(int industryId)
        {
            var industryInfo = industryRepository.GetIndustryById(industryId);

            var viewModel = industryViewModelFactory.EditIndustryView(industryInfo);

            return viewModel;
        }


        /// <summary>
        /// Processes the industry edit view.
        /// </summary>
        /// <param name="IndustryInfo">The industry information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">IndustryInfo</exception>
        public string ProcessIndustryEditView(IIndustryView IndustryInfo)
        {
            if (IndustryInfo == null)
                throw new ArgumentNullException(nameof(IndustryInfo));

            var processingMessage = string.Empty;
            var isDataOkay = true;

            var returnViewModel = industryViewModelFactory.CreateUpdatedIndustryView(IndustryInfo, processingMessage);


            var message = this.industryRepository.UpdateIndustryInfo(IndustryInfo);

            return message;
        }
    }
}