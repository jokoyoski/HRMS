using AA.HRMS.Domain.Resources;
using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces.ValueTypes;
using AA.Infrastructure.Interfaces;

namespace AA.HRMS.Domain.Services
{ 
    public class EmploymentHistoryService : IEmploymentHistoryService
    {
        private readonly IEmploymentHistoryViewModelFactory employmentHistoryViewsFactoryModel;
        private readonly IEmploymentHistoryRepository employmentHistoryRepository;
        private readonly IEmployeeOnBoardRepository employeeOnBoardRepository;
        private readonly ISessionStateService session;
        private readonly IUsersRepository usersRepository;
        
        public EmploymentHistoryService(IEmploymentHistoryViewModelFactory employmentHistoryViewsFactoryModel, ISessionStateService session,
            IEmploymentHistoryRepository employmentHistoryRepository, IEmployeeOnBoardRepository employeeOnBoardRepository, IUsersRepository usersRepository)
        {
            this.employmentHistoryViewsFactoryModel = employmentHistoryViewsFactoryModel;
            this.employmentHistoryRepository = employmentHistoryRepository;
            this.session = session;
            this.employeeOnBoardRepository = employeeOnBoardRepository;
            this.usersRepository = usersRepository;
        }

        /// <summary>
        /// Gets the employment history view.
        /// </summary>
        /// <returns></returns>
        public IEmploymentHistoryView GetEmploymentHistoryView(int employeeId, string URL)
        {
            //Get View Model From Factory
            var viewModel = this.employmentHistoryViewsFactoryModel.CreateEmploymentHistoryView(employeeId, URL);

            return viewModel;
        }


        /// <summary>
        /// Gets the employment history view.
        /// </summary>
        /// <param name="employmentHistoryInfo">The employment history information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IEmploymentHistoryView GetEmploymentHistoryView(IEmploymentHistoryView employmentHistoryInfo,
            string processingMessage)
        {
            var viewModel =
                this.employmentHistoryViewsFactoryModel.CreateUpdatedEmploymentHistoryView(employmentHistoryInfo,
                    processingMessage);

            return viewModel;
        }

        /// <summary>
        /// Gets the employment history edit view.
        /// </summary>
        /// <param name="employeeHistoryId">The employee history identifier.</param>
        /// <returns></returns>
        public IEmploymentHistoryView GetEmploymentHistoryEditView(int employeeHistoryId, string URL)
        {
            if (employeeHistoryId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(employeeHistoryId));
            }

            var employeeHistory = this.employmentHistoryRepository.GetEmployementHistoryById(employeeHistoryId);

            var viewModel = this.employmentHistoryViewsFactoryModel.CreateEditEmploymentHistoryView(employeeHistory, URL);

            return viewModel;
        }


        /// <summary>
        /// Processes the employment history information.
        /// </summary>
        /// <param name="employmentHistoryInfo">The employment history information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employmentHistoryInfo</exception>
        public string ProcessEmploymentHistoryInfo(IEmploymentHistoryView employmentHistoryInfo)
        {
            if (employmentHistoryInfo == null)
            {
                throw new ArgumentNullException(nameof(employmentHistoryInfo));
            }

            if (employmentHistoryInfo.EmployeeId == 0)
            {
                var user = this.usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

                var employee = this.employeeOnBoardRepository.GetEmployeeByEmail(user.Email);

                if (employee != null)
                {
                    employmentHistoryInfo.EmployeeId = employee.EmployeeId;
                }
                else
                {
                    employmentHistoryInfo.EmployeeId = user.UserId;
                }
            }

            //Store Compnay Information
            var message = this.employmentHistoryRepository.SaveEmploymentHistoryInfo(employmentHistoryInfo);


            return message;
        }

        /// <summary>
        /// Processes the edit employment history information.
        /// </summary>
        /// <param name="employmentHistoryInfo">The employment history information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employmentHistoryInfo</exception>
        public string ProcessEditEmploymentHistoryInfo(IEmploymentHistoryView employmentHistoryInfo)
        {
            if (employmentHistoryInfo == null)
            {
                throw new ArgumentNullException(nameof(employmentHistoryInfo));
            }


            //Store Compnay Information
            var message = this.employmentHistoryRepository.UpdateEmploymentHistoryInfo(employmentHistoryInfo);


            return message;
        }

        /// <summary>
        /// Deletes the employment history information.
        /// </summary>
        /// <param name="employmentHistoryId">The employment history identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employmentHistoryId</exception>
        public string DeleteEmploymentHistoryInfo(int employmentHistoryId)
        {
            if (employmentHistoryId <= 0)
            {
                throw new ArgumentNullException(nameof(employmentHistoryId));
            }

            var result = this.employmentHistoryRepository.DeleteEmploymentHistoryInfo(employmentHistoryId);

            return result;
        }
    }
}