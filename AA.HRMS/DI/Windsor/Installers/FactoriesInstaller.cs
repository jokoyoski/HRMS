using Castle.MicroKernel.Registration;
using Castle.Core;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.Factories;
using AA.HRMS.Domain.Factories;

namespace AA.HRMS.DI.Windsor.Installers
{
    public class FactoriesInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof(IDbContextFactory))
                    .ImplementedBy(typeof(DbContextFactory))
                    .Named("DbContextFactory")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IAccountViewsModelFactory))
                    .ImplementedBy(typeof(AccountViewsModelFactory))
                    .Named("AccountViewsModelFactory")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IEmailFactory))
                    .ImplementedBy(typeof(EmailFactory))
                    .Named("EmailFactory")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
            Component.For(typeof(IAdminViewModelFactory))
                .ImplementedBy(typeof(AdminViewModelFactory))
                .Named("AdminViewModelFactory")
                .LifeStyle.Is(LifestyleType.PerWebRequest));

            ///Users view Model Factory
            container.Register(
                Component.For(typeof(IUsersViewsModelFactory))
                    .ImplementedBy(typeof(UsersViewsModelFactory))
                    .Named("UsersViewsModelFactory")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            //Employee View Model Factory
            container.Register(
                Component.For(typeof(IEmployeeViewModelFactory))
                    .ImplementedBy(typeof(EmployeeViewModelFactory))
                    .Named("EmployeeViewModelFactory")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));


            container.Register(
                Component.For(typeof(IGradeViewModelFactory))
                    .ImplementedBy(typeof(GradeViewModelFactory))
                    .Named("GradeViewModelFactory")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

         

            container.Register(
                Component.For(typeof(IVacancyViewModelFactory))
                    .ImplementedBy(typeof(VacancyViewModelFactory))
                    .Named("VacancyViewModelFactory")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IEmploymentHistoryViewModelFactory))
                    .ImplementedBy(typeof(EmploymentHistoryViewModelFactory))
                    .Named("EmploymentHistoryViewModelFactory")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IAdvertisementModelViewFactory))
                    .ImplementedBy(typeof(AdvertisementModelViewFactory))
                    .Named("AdvertisementModelViewFactory")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IProfileViewModelFactory))
                    .ImplementedBy(typeof(ProfileViewModelFactory))
                    .Named("ProfileViewModelFactory")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IEducationHistoryViewModelFactory))
                    .ImplementedBy(typeof(EducationHistoryViewModelFactory))
                    .Named("EducationHistoryViewModelFactory")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));


            container.Register(
                          Component.For(typeof(IUserProfileModelFactory))
                              .ImplementedBy(typeof(UserProfileModelFactory))
                              .Named("UserProfileModelFactory")
                              .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                          Component.For(typeof(ISkillSetViewModelFactory))
                              .ImplementedBy(typeof(SkillSetViewModelFactory))
                              .Named("SkillSetViewModelFactory")
                              .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                         Component.For(typeof(IAwardViewModelFactory))
                             .ImplementedBy(typeof(AwardViewModelFactory))
                             .Named("AwardViewModelFactory")
                             .LifeStyle.Is(LifestyleType.PerWebRequest));


            container.Register(
                         Component.For(typeof(IHomeViewModelFactory))
                             .ImplementedBy(typeof(HomeViewModelFactory))
                             .Named("HomeViewModelFactory")
                             .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                        Component.For(typeof(IIndustryViewModelFactory))
                            .ImplementedBy(typeof(IndustryViewModelFactory))
                            .Named("IndustryViewModelFactory")
                            .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                        Component.For(typeof(ICompanySetupViewModelFactory))
                            .ImplementedBy(typeof(CompanySetupViewModelFactory))
                            .Named("CompanySetupViewModelFactory")
                            .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                        Component.For(typeof(ILeaveModelViewFactory))
                            .ImplementedBy(typeof(LeaveModelViewFactory))
                            .Named("LeaveModelViewFactory")
                            .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                        Component.For(typeof(IPayrollViewModelFactory))
                            .ImplementedBy(typeof(PayrollViewModelFactory))
                            .Named("PayrollViewModelFactory")
                            .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                        Component.For(typeof(IEmployeeOnBoardViewModelFactory))
                            .ImplementedBy(typeof(EmployeeOnBoardViewModelFactory))
                            .Named("EmployeeOnBoardViewModelFactory")
                            .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                        Component.For(typeof(IPerformanceManagementViewModelFactory))
                            .ImplementedBy(typeof(PerformanceManagementViewModelFactory))
                            .Named("PerformanceManagementViewModelFactory")
                            .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                        Component.For(typeof(ITrainingViewModelFactory))
                            .ImplementedBy(typeof(TrainingViewModelFactory))
                            .Named("TrainingViewModelFactory")
                            .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                        Component.For(typeof(ITypeOfExitViewModelFactory))
                            .ImplementedBy(typeof(TypeOfExitViewModelFactory))
                            .Named("TypeOfExitViewModelFactory")
                            .LifeStyle.Is(LifestyleType.PerWebRequest));
            


            container.Register(
                       Component.For(typeof(IEmployeeTrainingFactory))
                           .ImplementedBy(typeof(EmployeeTrainingFactory))
                           .Named("EmployeeTrainingFactory")
                           .LifeStyle.Is(LifestyleType.PerWebRequest));

            

            container.Register(
                       Component.For(typeof(IExitManagementViewModelFactory))
                           .ImplementedBy(typeof(ExitManagementViewModelFactory))
                           .Named("ExitManagementViewModelFactory")
                           .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                      Component.For(typeof(IQueryViewModelFactory))
                          .ImplementedBy(typeof(QueryViewModelFactory))
                          .Named("QueryViewModelFactory")
                          .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                       Component.For(typeof(IDisciplineViewModelFactory))
                           .ImplementedBy(typeof(DisciplineViewModelFactory))
                           .Named("DisciplineViewModelFactory")
                           .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                      Component.For(typeof(ICertificateViewModelFactory))
                          .ImplementedBy(typeof(CertificateViewModelFactory))
                          .Named("CertificateViewModelFactory")
                          .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                       Component.For(typeof(ISuspensionViewModelFactory))
                           .ImplementedBy(typeof(SuspensionViewModelFactory))
                           .Named("SuspensionViewModelFactory")
                           .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                       Component.For(typeof(ILeaveRequestViewModelFactory))
                            .ImplementedBy(typeof(LeaveRequestViewModelFactory))
                            .Named("LeaveRequestViewModelFactory")
                            .LifeStyle.Is(LifestyleType.PerWebRequest));


        }
    }
}