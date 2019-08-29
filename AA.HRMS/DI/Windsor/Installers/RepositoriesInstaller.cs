using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.Services;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;


namespace AA.HRMS.DI.Windsor.Installers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof(ILookupRepository))
                    .ImplementedBy(typeof(LookupRepository))
                    .Named("LookupRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IAccountRepository))
                    .ImplementedBy(typeof(AccountRepository))
                    .Named("AccountRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IUsersRepository))
                    .ImplementedBy(typeof(UsersRepository))
                    .Named("UsersRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(ICompanyRepository))
                    .ImplementedBy(typeof(CompanyRepository))
                    .Named("CompanyRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IEmployeeRepository))
                    .ImplementedBy(typeof(EmployeeRepository))
                    .Named("EmployeeRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IGradeRepository))
                    .ImplementedBy(typeof(GradeRepository))
                    .Named("GradeRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IDepartmentRepository))
                    .ImplementedBy(typeof(DepartmentRepository))
                    .Named("DepartmentRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));
            

            container.Register(
                Component.For(typeof(IJobTitleRepository))
                    .ImplementedBy(typeof(JobTitleRepository))
                    .Named("JobTitleRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IEmploymentHistoryRepository))
                    .ImplementedBy(typeof(EmploymentHistoryRepository))
                    .Named("EmploymentHistoryRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IAdvertisementModelRepository))
                    .ImplementedBy(typeof(AdvertisementModelRepository))
                    .Named("AdvertisementModelRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));


            container.Register(
                Component.For(typeof(IProfileRepository))
                    .ImplementedBy(typeof(ProfileRepository))
                    .Named("ProfileRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IEducationHistoryRepository))
                    .ImplementedBy(typeof(EducationHistoryRepository))
                    .Named("EducationHistoryRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(ISkillSetRepository))
                    .ImplementedBy(typeof(SkillSetRepository))
                    .Named("SkillSetRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IAwardRepository))
                    .ImplementedBy(typeof(AwardRepository))
                    .Named("AwardRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IJobApplicationVacancyRepository))
                    .ImplementedBy(typeof(JobApplicationVacancyRepository))
                    .Named("JobApplicationVacancyRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IDigitalFileRepository))
                    .ImplementedBy(typeof(DigitalFileRepository))
                    .Named("DigitalFileRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IIndustryRepository))
                    .ImplementedBy(typeof(IndustryRepository))
                    .Named("IndustryRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IPayrollRepository))
                    .ImplementedBy(typeof(PayrollRepository))
                    .Named("PayrollRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IBenefitRepository))
                    .ImplementedBy(typeof(BenefitRepository))
                    .Named("BenefitRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IRewardRepository))
                    .ImplementedBy(typeof(RewardRepository))
                    .Named("RewardRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(ILevelGradeRepository))
                    .ImplementedBy(typeof(LevelGradeRepository))
                    .Named("LevelGradeRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(ILeaveRepository))
                    .ImplementedBy(typeof(LeaveRepository))
                    .Named("LeaveRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));


            container.Register(
                Component.For(typeof(ILevelRepository))
                    .ImplementedBy(typeof(LevelRepository))
                    .Named("LevelRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(ILoanRepository))
                    .ImplementedBy(typeof(LoanRepository))
                    .Named("LoanRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IDeductionRepository))
                    .ImplementedBy(typeof(DeductionRepository))
                    .Named("DeductionRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IEmployeeOnBoardRepository))
                    .ImplementedBy(typeof(EmployeeOnBoardRepository))
                    .Named("EmployeeOnBoardRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IPerformanceManagementRepository))
                    .ImplementedBy(typeof(PerformanceManagementRepository))
                    .Named("PerformanceManagementRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(ITrainingRepository))
                    .ImplementedBy(typeof(TrainingRepository))
                    .Named("TrainingRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(ITaxRepository))
                    .ImplementedBy(typeof(TaxRepository))
                    .Named("TaxRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IAssetRepository))
                    .ImplementedBy(typeof(AssetRepository))
                    .Named("AssetRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IOverTimesheetRepository))
                    .ImplementedBy(typeof(OverTimesheetRepository))
                    .Named("OverTimesheetRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IDisciplineRepository))
                    .ImplementedBy(typeof(DisciplineRepository))
                    .Named("DisciplineRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));


            container.Register(
                Component.For(typeof(IEmployeeLoanRepository))
                    .ImplementedBy(typeof(EmployeeLoanRepository))
                    .Named("EmployeeLoanRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));


            container.Register(
                Component.For(typeof(IEmployeeTrainingRepository))
                    .ImplementedBy(typeof(EmployeeTrainingRepository))
                    .Named("EmployeeTrainingRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(ITypeOfExitRepository))
                    .ImplementedBy(typeof(TypeOfExitRepository))
                    .Named("TypeOfExitRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));


            container.Register(
                Component.For(typeof(ISuspensionRepository))
                    .ImplementedBy(typeof(SuspensionRepository))
                    .Named("SuspensionRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IQueryRepository))
                    .ImplementedBy(typeof(QueryRepository))
                    .Named("QueryRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));


            container.Register(
                Component.For(typeof(ICertificationRepository))
                    .ImplementedBy(typeof(CertificationRepository))
                    .Named("CertificationRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(
                Component.For(typeof(IExitManagementRepository))
                    .ImplementedBy(typeof(ExitManagementRepository))
                    .Named("ExitManagementRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));


            container.Register(
                Component.For(typeof(IEmployeeDeductionRepository))
                    .ImplementedBy(typeof(EmployeeDeductionRepository))
                    .Named("EmployeeDeductionRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));


            container.Register(
                Component.For(typeof(IEmployeeRewardRepository))
                    .ImplementedBy(typeof(EmployeeRewardRepository))
                    .Named("EmployeeRewardRepository")
                    .LifeStyle.Is(LifestyleType.PerWebRequest));
        }
    }
}