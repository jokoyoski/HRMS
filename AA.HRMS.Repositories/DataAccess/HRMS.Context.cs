﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AA.HRMS.Repositories.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class HRMSEntities : DbContext
    {
        public HRMSEntities()
            : base("name=HRMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AboutUsSource> AboutUsSources { get; set; }
        public virtual DbSet<ActionTaken> ActionTakens { get; set; }
        public virtual DbSet<Advertisement> Advertisements { get; set; }
        public virtual DbSet<AdvertStatu> AdvertStatus { get; set; }
        public virtual DbSet<AnnualAssessingPerformance> AnnualAssessingPerformances { get; set; }
        public virtual DbSet<AnswerFormat> AnswerFormats { get; set; }
        public virtual DbSet<AppActivityLog> AppActivityLogs { get; set; }
        public virtual DbSet<ApplicationStatu> ApplicationStatus { get; set; }
        public virtual DbSet<Appraisal> Appraisals { get; set; }
        public virtual DbSet<AppraisalAction> AppraisalActions { get; set; }
        public virtual DbSet<AppraisalGoal> AppraisalGoals { get; set; }
        public virtual DbSet<AppraisalPeriod> AppraisalPeriods { get; set; }
        public virtual DbSet<AppraisalQualitativeMetric> AppraisalQualitativeMetrics { get; set; }
        public virtual DbSet<AppraisalQuantitiveMetric> AppraisalQuantitiveMetrics { get; set; }
        public virtual DbSet<AppraisalQuestion> AppraisalQuestions { get; set; }
        public virtual DbSet<AppraisalRating> AppraisalRatings { get; set; }
        public virtual DbSet<Appraiser> Appraisers { get; set; }
        public virtual DbSet<AppRole> AppRoles { get; set; }
        public virtual DbSet<AssessingPerformance> AssessingPerformances { get; set; }
        public virtual DbSet<Asset> Assets { get; set; }
        public virtual DbSet<Award> Awards { get; set; }
        public virtual DbSet<Beneficiary> Beneficiaries { get; set; }
        public virtual DbSet<Benefit> Benefits { get; set; }
        public virtual DbSet<Certification> Certifications { get; set; }
        public virtual DbSet<ChangePassword> ChangePasswords { get; set; }
        public virtual DbSet<Child> Children { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyAdministrator> CompanyAdministrators { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<Deduction> Deductions { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DigitalFile> DigitalFiles { get; set; }
        public virtual DbSet<DigitalType> DigitalTypes { get; set; }
        public virtual DbSet<Discipline> Disciplines { get; set; }
        public virtual DbSet<EducationHistory> EducationHistories { get; set; }
        public virtual DbSet<EmailLog> EmailLogs { get; set; }
        public virtual DbSet<Emergency> Emergencies { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeAnnualAssessingPerformance> EmployeeAnnualAssessingPerformances { get; set; }
        public virtual DbSet<EmployeeAppraisal> EmployeeAppraisals { get; set; }
        public virtual DbSet<EmployeeDeduction> EmployeeDeductions { get; set; }
        public virtual DbSet<EmployeeExit> EmployeeExits { get; set; }
        public virtual DbSet<EmployeeFeedback> EmployeeFeedbacks { get; set; }
        public virtual DbSet<EmployeeInfraction> EmployeeInfractions { get; set; }
        public virtual DbSet<EmployeeLoan> EmployeeLoans { get; set; }
        public virtual DbSet<EmployeeQuestionRating> EmployeeQuestionRatings { get; set; }
        public virtual DbSet<EmployeeReward> EmployeeRewards { get; set; }
        public virtual DbSet<EmployeeTraining> EmployeeTrainings { get; set; }
        public virtual DbSet<EmploymentHistory> EmploymentHistories { get; set; }
        public virtual DbSet<EmploymentType> EmploymentTypes { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<FrequencyOfDelivery> FrequencyOfDeliveries { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Industry> Industries { get; set; }
        public virtual DbSet<Infraction> Infractions { get; set; }
        public virtual DbSet<JobApplicationVacancy> JobApplicationVacancies { get; set; }
        public virtual DbSet<JobApplicationVacancyAnswer> JobApplicationVacancyAnswers { get; set; }
        public virtual DbSet<JobTitle> JobTitles { get; set; }
        public virtual DbSet<LeaveRequest> LeaveRequests { get; set; }
        public virtual DbSet<LeaveType> LeaveTypes { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<LoanType> LoanTypes { get; set; }
        public virtual DbSet<MaritalStatu> MaritalStatus { get; set; }
        public virtual DbSet<MethodOfDelivery> MethodOfDeliveries { get; set; }
        public virtual DbSet<Month> Months { get; set; }
        public virtual DbSet<NextOfKin> NextOfKins { get; set; }
        public virtual DbSet<OverTimesheet> OverTimesheets { get; set; }
        public virtual DbSet<Payroll> Payrolls { get; set; }
        public virtual DbSet<PayrollEmployeeDeduction> PayrollEmployeeDeductions { get; set; }
        public virtual DbSet<PayrollEmployeeLoan> PayrollEmployeeLoans { get; set; }
        public virtual DbSet<PayrollEmployeeReward> PayrollEmployeeRewards { get; set; }
        public virtual DbSet<PayrollHistory> PayrollHistories { get; set; }
        public virtual DbSet<PayScale> PayScales { get; set; }
        public virtual DbSet<PayScaleBenefit> PayScaleBenefits { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<Query> Queries { get; set; }
        public virtual DbSet<QueryStatu> QueryStatus { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<Religion> Religions { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Reward> Rewards { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<SkillSet> SkillSets { get; set; }
        public virtual DbSet<Spouse> Spouses { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Suspension> Suspensions { get; set; }
        public virtual DbSet<Tax> Taxes { get; set; }
        public virtual DbSet<Training> Trainings { get; set; }
        public virtual DbSet<TrainingCalender> TrainingCalenders { get; set; }
        public virtual DbSet<TrainingEvaluationRating> TrainingEvaluationRatings { get; set; }
        public virtual DbSet<TrainingHistory> TrainingHistories { get; set; }
        public virtual DbSet<TrainingNeedAnalysi> TrainingNeedAnalysis { get; set; }
        public virtual DbSet<TrainingReport> TrainingReports { get; set; }
        public virtual DbSet<TrainingStatu> TrainingStatus { get; set; }
        public virtual DbSet<TypeOfExit> TypeOfExits { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserActivationCode> UserActivationCodes { get; set; }
        public virtual DbSet<UserAppRole> UserAppRoles { get; set; }
        public virtual DbSet<Vacancy> Vacancies { get; set; }
        public virtual DbSet<VacancyQuestion> VacancyQuestions { get; set; }
        public virtual DbSet<Week> Weeks { get; set; }
        public virtual DbSet<Year> Years { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<LeaveStatu> LeaveStatus { get; set; }
        public virtual DbSet<CalendarEvent> CalendarEvents { get; set; }
        public virtual DbSet<EmployeeTask> EmployeeTasks { get; set; }
        public virtual DbSet<Milestone> Milestones { get; set; }
    
        public virtual int SendEmail(string recipients, string subject, string body)
        {
            var recipientsParameter = recipients != null ?
                new ObjectParameter("Recipients", recipients) :
                new ObjectParameter("Recipients", typeof(string));
    
            var subjectParameter = subject != null ?
                new ObjectParameter("Subject", subject) :
                new ObjectParameter("Subject", typeof(string));
    
            var bodyParameter = body != null ?
                new ObjectParameter("Body", body) :
                new ObjectParameter("Body", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SendEmail", recipientsParameter, subjectParameter, bodyParameter);
        }
    }
}
