using System;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.Infrastructure.Interfaces;

namespace AA.HRMS.Domain.Services
{
    public class EducationHistoryService : IEducationHistoryService
    {

        private readonly IEducationHistoryViewModelFactory applicationeducationhistoryViewModelFactory;

        private readonly IEmployeeOnBoardRepository employeeOnBoardRepository;

        private readonly ISessionStateService session;

        private readonly IUsersRepository usersRepository;

        private readonly IEducationHistoryRepository applicationeducationhistoryRepository;
        
        public EducationHistoryService(IEducationHistoryViewModelFactory applicationeducationhistoryViewModelFactory, ISessionStateService session,
            IEducationHistoryRepository applicationeducationhistoryRepository, IEmployeeOnBoardRepository employeeOnBoardRepository, IUsersRepository usersRepository)
        {
            this.applicationeducationhistoryViewModelFactory = applicationeducationhistoryViewModelFactory;
            this.applicationeducationhistoryRepository = applicationeducationhistoryRepository;
            this.employeeOnBoardRepository = employeeOnBoardRepository;
            this.usersRepository = usersRepository;
            this.session = session;
        }


        /// <summary>
        /// Gets the education history view.
        /// </summary>
        /// <returns></returns>
        public IEducationHistoryView GetEducationHistoryView(int employeeId, string URL)
        {
            var viewModel = applicationeducationhistoryViewModelFactory.CreateEducationHistoryView(employeeId, URL);

            return viewModel;
        }

        /// <summary>
        /// Gets the education history view.
        /// </summary>
        /// <param name="educationHistory">The education history.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IEducationHistoryView GetEducationHistoryView(IEducationHistoryView educationHistory,
            string processingMessage)
        {
            var viewModel =
                applicationeducationhistoryViewModelFactory.CreateUpdatedEducationHistoryView(educationHistory,
                    processingMessage);

            return viewModel;
        }


        /// <summary>
        /// Processes the education history information.
        /// </summary>
        /// <param name="educationHistoryInfo"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">educationHistoryInfo</exception>
        public string ProcessEducationHistoryInfo(IEducationHistoryView educationHistoryInfo)
        {
            if (educationHistoryInfo == null)
            {
                throw new ArgumentNullException(nameof(educationHistoryInfo));
            }

            if(educationHistoryInfo.EmployeeId == 0)
            {
                var user = this.usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

                var employee = this.employeeOnBoardRepository.GetEmployeeByEmail(user.Email);

                if (employee != null)
                {
                    educationHistoryInfo.EmployeeId = employee.EmployeeId;
                }
                else
                {
                    educationHistoryInfo.EmployeeId = user.UserId;
                }
            }

            var message = this.applicationeducationhistoryRepository.SaveEducationHistoryInfo(educationHistoryInfo);


            return message;
        }

        /// <summary>
        /// Gets the educational edit view.
        /// </summary>
        /// <param name="educationHistoryId">The education history identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">educationHistoryId</exception>
        public IEducationHistoryView GetEducationalEditView(int educationHistoryId, string URL)
        {
            if (educationHistoryId == 0)
            {
                throw new ArgumentNullException(nameof(educationHistoryId));
            }

            var educationalHistoryInfo =
                applicationeducationhistoryRepository.GetEducationHistoryById(educationHistoryId);

            if (educationalHistoryInfo == null)
            {
                throw new ArgumentNullException(nameof(educationalHistoryInfo));
            }

            var viewModel =
                applicationeducationhistoryViewModelFactory.EditEducationHistoryView(educationalHistoryInfo, URL);

            return viewModel;
        }

        /// <summary>
        /// Processes the education history edit view.
        /// </summary>
        /// <param name="educationHistoryInfo">The education history information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">educationHistoryInfo</exception>
        public string ProcessEducationHistoryEditView(IEducationHistoryView educationHistoryInfo)
        {
            if (educationHistoryInfo == null)
            {
                throw new ArgumentNullException(nameof(educationHistoryInfo));
            }


            var message =
                this.applicationeducationhistoryRepository.UpdateEducationHistoryInfo(educationHistoryInfo);

            return message;
        }

        /// <summary>
        /// Gets the education history delete view.
        /// </summary>
        /// <param name="educationHistoryId">The education history identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">educationHistoryId</exception>
        public IEducationHistoryView GetEducationHistoryDeleteView(int educationHistoryId, string URL)
        {
            if (educationHistoryId == 0)
            {
                throw new ArgumentNullException(nameof(educationHistoryId));
            }

            var educationInfo = applicationeducationhistoryRepository.GetEducationHistoryById(educationHistoryId);

            if (educationInfo == null)
            {
                throw new ArgumentNullException(nameof(educationInfo));
            }

            var viewModel = applicationeducationhistoryViewModelFactory.DeleteEducationHistory(educationInfo, URL);

            return viewModel;
        }

        /// <summary>
        /// Processes the education history delete view.
        /// </summary>
        /// <param name="educationHistoryId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">educationHistoryId</exception>
        public string ProcessEducationHistoryDeleteView(int educationHistoryId)
        {
            if (educationHistoryId <= 0)
            {
                throw new ArgumentNullException(nameof(educationHistoryId));
            }

            var message = this.applicationeducationhistoryRepository.DeleteEducationHistoryInfo(educationHistoryId);

            return message;
        }
    }
}