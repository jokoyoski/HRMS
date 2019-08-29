using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Domain.Resources;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IAwardService" />
    public class AwardService : IAwardService
    {
        private readonly IAwardViewModelFactory awardViewModelFactory;
        private readonly IAwardRepository awardRepository;
        private readonly ILookupRepository lookupRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AwardService"/> class.
        /// </summary>
        /// <param name="awardViewModelFactory">The award view model factory.</param>
        /// <param name="lookupRepository">The lookup repository.</param>
        /// <param name="awardRepository">The award repository.</param>
        public AwardService(IAwardViewModelFactory awardViewModelFactory, ILookupRepository lookupRepository,
            IAwardRepository awardRepository)
        {
            this.awardViewModelFactory = awardViewModelFactory;
            this.awardRepository = awardRepository;
            this.lookupRepository = lookupRepository;
        }

        /// <summary>
        /// Gets the award registration view.
        /// </summary>
        /// <returns></returns>
        public IAwardView GetAwardRegistrationView()
        {
            //Department Collection
            //var awardCollection = this.lookupRepository.GetAwardCollection();

            var viewModel =
                this.awardViewModelFactory.CreateAwardView();

            return viewModel;
        }

        /// <summary>
        /// Processes the award information.
        /// </summary>
        /// <param name="awardInfo">The award information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">awardInfo</exception>
        public string ProcessAwardInfo(IAwardView awardInfo)
        {
            if (awardInfo == null)
            {
                throw new ArgumentNullException(nameof(awardInfo));
            }

            var processingMessage = string.Empty;


            processingMessage = this.awardRepository.SaveAwardInfo(awardInfo);

            return processingMessage;
        }

        /// <summary>
        /// Creates the award updated view.
        /// </summary>
        /// <param name="awardInfo">The award information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">awardInfo</exception>
        public IAwardView CreateAwardUpdatedView(IAwardView awardInfo, string processingMessage)
        {
            if (awardInfo == null)
            {
                throw new ArgumentNullException(nameof(awardInfo));
            }

            var returnViewModel =
                awardViewModelFactory.CreateUpdatedAwardView(awardInfo, processingMessage);

            return returnViewModel;
        }

        /// <summary>
        /// Gets the award edit view.
        /// </summary>
        /// <param name="awardId">The award identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">awardInfo</exception>
        public IAwardView GetAwardEditView(int awardId)
        {
            var awardInfo = awardRepository.GetAwardById(awardId);

            if (awardInfo == null)
            {
                throw new ArgumentNullException(nameof(awardInfo));
            }


            var viewModel = this.awardViewModelFactory.CreateEditAwardView(awardInfo);

            return viewModel;
        }

        /// <summary>
        /// Processes the edit award information.
        /// </summary>
        /// <param name="awardInfo">The award information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">awardInfo</exception>
        public string ProcessEditAwardInfo(IAwardView awardInfo)
        {
            if (awardInfo == null)
            {
                throw new ArgumentNullException(nameof(awardInfo));
            }

            string processingMessage = string.Empty;


            //Store Compnay Information
            processingMessage = this.awardRepository.UpdateAwardInfo(awardInfo);


            return processingMessage;
        }

        /// <summary>
        /// Processes the delete award information.
        /// </summary>
        /// <param name="awardId">The award identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">awardId</exception>
        public string ProcessDeleteAwardInfo(int awardId)
        {
            if (awardId < 1)
            {
                throw new ArgumentNullException(nameof(awardId));
            }


            string processingMessage = string.Empty;


            processingMessage = this.awardRepository.DeleteAwardInfo(awardId);


            return processingMessage;
        }
    }
}