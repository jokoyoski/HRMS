using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using AA.Infrastructure.Interfaces;
using AA.Infrastructure.Providers;
using AA.Infrastructure.Services;
using AA.Infrastructure.Utility;
using AA.HRMS.Interfaces;
using AA.HRMS.Domain.Services;

namespace AA.HRMS.DI.Windsor.Installers
{
    public class ServicesInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof(IEnvironment))
                    .ImplementedBy(typeof(Environment))
                    .Named("Environment")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(ISessionStateProvider))
                    .ImplementedBy(typeof(SessionStateProvider))
                    .Named("SessionStateProvider")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(ISessionStateService))
                    .ImplementedBy(typeof(SessionStateService))
                    .Named("SessionStateService")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
              Component.For(typeof(IEmail))
              .ImplementedBy(typeof(Email))
              .Named("Email")
              .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IFormsAuthenticationService))
                    .ImplementedBy(typeof(FormsAuthenticationService))
                    .Named("FormsAuthenticationService")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IAccountService))
                    .ImplementedBy(typeof(AccountService))
                    .Named("AccountService")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IUserService))
                    .ImplementedBy(typeof(UserService))
                    .Named("UserService")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));
            


            container.Register(
                Component.For(typeof(IEmploymentHistoryService))
                    .ImplementedBy(typeof(EmploymentHistoryService))
                    .Named("EmploymentHistoryService")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));
            
            container.Register(
                Component.For(typeof(IProfileService))
                    .ImplementedBy(typeof(ProfileService))
                    .Named("ProfileService")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IEducationHistoryService))
                    .ImplementedBy(typeof(EducationHistoryService))
                    .Named("EducationHistoryService")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IAdminService))
                    .ImplementedBy(typeof(AdminService))
                    .Named("AdminService")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(ISkillSetServices))
                    .ImplementedBy(typeof(SkillSetServices))
                    .Named("SkillSetServices")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IAwardService))
                    .ImplementedBy(typeof(AwardService))
                    .Named("AwardService")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IDigitalFileService))
                    .ImplementedBy(typeof(DigitalFileService))
                    .Named("DigitalFileService")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));


            container.Register(
                Component.For(typeof(IIndustryServices))
                    .ImplementedBy(typeof(IndustryServices))
                    .Named("IndustryServices")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IAesEncryption))
                .ImplementedBy(typeof(AesEncryption))
                .Named("AesEncryption")
                .LifeStyle.Is(LifestyleType.PerWebRequest));

            

            container.Register(
                Component.For(typeof(ICompanySetupServices))
                .ImplementedBy(typeof(CompanySetupServices))
                .Named("CompanySetupServices")
                .LifeStyle.Is(LifestyleType.PerWebRequest));


            container.Register(
                Component.For(typeof(IPayrollServices))
                .ImplementedBy(typeof(PayrollServices))
                .Named("PayrollServices")
                .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IEmployeeOnBoardService))
                .ImplementedBy(typeof(EmployeeService))
                .Named("EmployeeService")
                .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IPerformanceManagementService))
                .ImplementedBy(typeof(PerformanceManagementService))
                .Named("PerformanceManagementService")
                .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(ITrainingService))
                .ImplementedBy(typeof(TrainingService))
                .Named("TrainingService")
                .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(ITypeOfExitService))
                .ImplementedBy(typeof(TypeOfExitService))
                .Named("TypeOfExitService")
                .LifeStyle.Is(LifestyleType.PerWebRequest));
            


            container.Register(
               Component.For(typeof(IEmployeeTrainingService))
               .ImplementedBy(typeof(EmployeeTrainingService))
               .Named("EmployeeTrainingService")
               .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
              Component.For(typeof(IQueryService))
              .ImplementedBy(typeof(QueryService))
              .Named("QueryService")
              .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
              Component.For(typeof(ISuspensionService))
              .ImplementedBy(typeof(SuspensionService))
              .Named("SuspensionService")
              .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
              Component.For(typeof(IDisciplineService))
              .ImplementedBy(typeof(DisciplineService))
              .Named("DisciplineService")
              .LifeStyle.Is(LifestyleType.PerWebRequest));
            
            container.Register(
              Component.For(typeof(ILeaveRequestService))
              .ImplementedBy(typeof(LeaveRequestService))
              .Named("LeaveRequestService")
              .LifeStyle.Is(LifestyleType.PerWebRequest));


            container.Register(
              Component.For(typeof(IExitManagementService))
              .ImplementedBy(typeof(ExitManagementService))
              .Named("ExitManagementService")
              .LifeStyle.Is(LifestyleType.PerWebRequest));


            container.Register(
              Component.For(typeof(IGenerateDocumentService))
              .ImplementedBy(typeof(GenerateDocumentService))
              .Named("GenerateDocument")
              .LifeStyle.Is(LifestyleType.PerWebRequest));


            container.Register(
              Component.For(typeof(ISchedulerService))
              .ImplementedBy(typeof(SchedulerServices))
              .Named("SchedulerServices")
              .LifeStyle.Is(LifestyleType.PerWebRequest));
        }
    }
}