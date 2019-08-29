using AA.HRMS.Interfaces;
using System;
using AA.HRMS.Interfaces.ValueTypes;
using AA.Infrastructure.Interfaces;

namespace AA.HRMS.Domain.Services
{
    public class SkillSetServices : ISkillSetServices
    {

        private readonly ISkillSetRepository skillSetRepository;
        private readonly ILookupRepository lookupRepository;
        private readonly ISkillSetViewModelFactory skillSetViewModelFactory;
        private readonly ISessionStateService session;
        private readonly IUsersRepository usersRepository;
        private readonly IEmployeeOnBoardRepository employeeOnBoardRepository;

        
        public SkillSetServices(ISkillSetRepository skillSetRepository, ILookupRepository lookupRepository, IEmployeeOnBoardRepository employeeOnBoardRepository,
            ISkillSetViewModelFactory skillSetViewModelFactory, ISessionStateService session, IUsersRepository usersRepository)
        {
            this.lookupRepository = lookupRepository;
            this.skillSetViewModelFactory = skillSetViewModelFactory;
            this.skillSetRepository = skillSetRepository;
            this.session = session;
            this.usersRepository = usersRepository;
            this.employeeOnBoardRepository = employeeOnBoardRepository;
        }


        /// <summary>
        /// Gets the skill set create view.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="URL">The URL.</param>
        /// <returns></returns>
        public ISkillSetModelView GetSkillSetCreateView(int? employeeId, string URL)
        {

            var experienceDDL = this.lookupRepository.GetExperienceCollection();

            var viewModel = skillSetViewModelFactory.CreateSkillSetView(employeeId ?? 0, URL, experienceDDL);

            return viewModel;
        }
        
        /// <summary>
        /// Gets the skill set create view.
        /// </summary>
        /// <param name="skillSetInfo">The skill set information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public ISkillSetModelView GetSkillSetCreateView(ISkillSetModelView skillSetInfo, string processingMessage)
        {
            if (skillSetInfo == null)
            {
                throw new ArgumentNullException(nameof(skillSetInfo));
            }
            var returnViewModel = skillSetViewModelFactory.CreateUpdatedSkillSetView(skillSetInfo, processingMessage);


            return returnViewModel;
        }

        /// <summary>
        /// Processes the skill set create view.
        /// </summary>
        /// <param name="skillSetInfo">The skill set information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">skillSetInfo</exception>
        public string  ProcessSkillSetCreateView(ISkillSetModelView skillSetInfo)
        {
            if (skillSetInfo == null)
            {
                throw new ArgumentNullException(nameof(skillSetInfo));
            }

            var processingMessage = string.Empty;

            if (skillSetInfo.EmployeeId == 0)
            {
                var user = this.usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

                var employee = this.employeeOnBoardRepository.GetEmployeeByEmail(user.Email);

                if (employee != null)
                {
                    skillSetInfo.EmployeeId = employee.EmployeeId;
                }
                else
                {
                    skillSetInfo.EmployeeId = user.UserId;
                }

            }

            //Store Skill Set Repository
            processingMessage = this.skillSetRepository.SaveSkillSetInfo(skillSetInfo);


            return processingMessage;
        }

        /// <summary>
        /// Gets the skill set edit view.
        /// </summary>
        /// <param name="skillSetId">The skill set identifier.</param>
        /// <param name="URL"></param>
        /// <returns></returns>
        public ISkillSetModelView GetSkillSetEditView(int skillSetId, string URL)
        {
            var skillSetInfo = skillSetRepository.GetSkillSetById(skillSetId);

            var experienceDDL = this.lookupRepository.GetExperienceCollection();

            var viewModel = skillSetViewModelFactory.EditSkillSetView(skillSetInfo, URL, experienceDDL);

            return viewModel;
        }

        /// <summary>
        /// Processes the skill set edit view.
        /// </summary>
        /// <param name="skillSetInfo">The skill set information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">skillSetInfo</exception>
        public string ProcessSkillSetEditView(ISkillSetModelView skillSetInfo)
        {
            if (skillSetInfo == null)
            {
                throw new ArgumentNullException(nameof(skillSetInfo));
            }

            var processingMessage = string.Empty;





            processingMessage = this.skillSetRepository.UpdateSkillSetInfo(skillSetInfo);

            return processingMessage;
        }

        /// <summary>
        /// Gets the skill set delete view.
        /// </summary>
        /// <param name="skillSetId">The skill set identifier.</param>
        /// <param name="URL"></param>
        /// <returns></returns>
        public ISkillSetModelView GetSkillSetDeleteView(int skillSetId, string URL)
        {
            var skillSetInfo = skillSetRepository.GetSkillSetById(skillSetId);

            var viewModel = skillSetViewModelFactory.DeleteSkillSetView(skillSetInfo, URL);

            return viewModel;
        }

        /// <summary>
        /// Processes the skill set delete view.
        /// </summary>
        /// <param name="skillSetId">The skill set identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">skillSetId</exception>
        public string ProcessSkillSetDeleteView(int skillSetId)
        {
            if (skillSetId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(skillSetId));
            }

            var deleteData = this.skillSetRepository.DeleteSkillSetInfo(skillSetId);

            return deleteData;
        }
    }
}