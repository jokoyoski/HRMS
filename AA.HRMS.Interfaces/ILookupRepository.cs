using System;
using System.Collections.Generic;

namespace AA.HRMS.Interfaces
{
    public interface ILookupRepository
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        IList<ITraining> GetTrainingByCompanyId(int companyId);

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <returns></returns>
        IList<IResult> GetResult();

        /// <summary>
        /// Gets the training request by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IEmployeeTrainingModel> GetTrainingRequestByCompanyId(int companyId);

        /// <summary>
        /// Gets the appraisal by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IAppraisal> GetAppraisalByCompanyId(int companyId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        IList<ISuspension> GetSuspensionByCompanyId(int companyId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        IList<IQuery> GetQueryByCompanyId(int companyId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        IList<ITrainingNeedAnalysis> GetTrainingNeedAnalysisByCompanyID(int companyId);

        /// <summary>
        /// Gets the about us source collection.
        /// </summary>
        /// <returns></returns>
        IList<IHowSource> GetAboutUsSourceCollection();

        /// <summary>
        /// Gets the gender collection.
        /// </summary>
        /// <returns></returns>
        IList<IYourGender> GetGenderCollection();

        /// <summary>
        /// Gets the department collection by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IDepartment> GetDepartmentCollectionByCompanyId(int companyId);

        /// <summary>
        /// Gets the department collection.
        /// </summary>
        /// <returns></returns>
        IList<IDepartment> GetDepartmentCollection();

        /// <summary>
        /// Gets the award collection.
        /// </summary>
        /// <param name="awardId">The award identifier.</param>
        /// <returns></returns>
        IList<IAward> GetAwardCollection(int awardId);

        /// <summary>
        /// Gets the company collection.
        /// </summary>
        /// <returns></returns>
        IList<ICompanyDetail> GetCompanyCollection();

        /// <summary>
        /// Gets the active company collection.
        /// </summary>
        /// <returns></returns>
        IList<ICompanyDetail> GetActiveCompanyCollection();

        /// <summary>
        /// Gets the job title collection.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IJobTitle> GetJobTitleCollectionByCompanyId(int companyId);

        /// <summary>
        /// Gets the job title collection.
        /// </summary>
        /// <returns></returns>
        IList<IJobTitle> GetJobTitleCollection();

        /// <summary>
        /// Gets the grades collection.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IGrade> GetGradesCollectionByCompanyId(int companyId);
       
        /// <summary>
        /// Gets the grades collection.
        /// </summary>
        /// <returns></returns>
        IList<IGrade> GetGradesCollection();

        /// <summary>
        /// Gets the industry collection.
        /// </summary>
        /// <returns></returns>
        IList<IIndustry> GetIndustryCollection();

        /// <summary>
        /// Gets the experience collection.
        /// </summary>
        /// <returns></returns>
        IList<IExperience> GetExperienceCollection();

        /// <summary>
        /// Gets the benefit by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IBenefit> GetBenefitByCompanyId(int companyId);

        /// <summary>
        /// Gets all years.
        /// </summary>
        /// <returns></returns>
        IList<IYear> GetAllYears();

        /// <summary>
        /// Gets all months.
        /// </summary>
        /// <returns></returns>
        IList<IMonth> GetAllMonths();

        /// <summary>
        /// Gets the employee loan by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IEmployeeLoan> GetEmployeeLoanByEmployeeId(int employeeId);

        /// <summary>
        /// Gets the employee loan by employee identifier period zero.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IList<IEmployeeLoan> GetEmployeeLoanByEmployeeIdPeriodZero(int employeeId);

        /// <summary>
        /// Gets the employee reward by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IEmployeeReward> GetEmployeeRewardByEmployeeId(int companyId);

        /// <summary>
        /// Gets the employee by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IEmployee> GetEmployeeByCompanyId(int companyId);

        /// <summary>
        /// Gets the loan by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
       IList<ILoan> GetLoan();

        /// <summary>
        /// Gets the level by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<ILevel> GetLevelByCompanyId(int companyId);

        /// <summary>
        /// Gets the reward by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IReward> GetRewardByCompanyId(int companyId);

        /// <summary>
        /// Gets the deduction by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IDeduction> GetDeductionByCompanyId(int companyId);

        /// <summary>
        /// Gets the marital status collection.
        /// </summary>
        /// <returns></returns>
        IList<IMaritalStatus> GetMaritalStatusCollection();

        /// <summary>
        /// Gets the religion collection.
        /// </summary>
        /// <returns></returns>
        IList<IReligion> GetReligionCollection();

        /// <summary>
        /// Gets the application role.
        /// </summary>
        /// <returns></returns>
        IList<IAppRole> GetAppRole();

        /// <summary>
        /// Gets the user application role.
        /// </summary>
        /// <returns></returns>
        IList<IUserAppRole> GetUserAppRole();

        /// <summary>
        /// Gets the user application role by username.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        IList<IUserAppRole> GetUserAppRoleByUsername(string userName);

        /// <summary>
        /// Getusers the aoo role by role idand username.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="AppRoleId">The application role identifier.</param>
        /// <returns></returns>
        IUserAppRole GetuserAooRoleByRoleIdandUsername(string userName, int AppRoleId);
        /// <summary>
        /// Gets the type of exit by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<ITypeOfExit> GetTypeOfExitByCompanyId(int companyId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        IList<IEmployeeExit> GetEmployeeExitByCompanyID(int companyId);
        /// <summary>
        /// Gets all tax.
        /// </summary>
        /// <returns></returns>
        IList<ITax> GetAllTax();

        /// <summary>
        /// Gets the training report by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<ITrainingReport> GetTrainingReportByCompanyID(int companyId);

        /// <summary>
        /// Gets the evaluationratings.
        /// </summary>
        /// <returns></returns>
        IList<ITrainingEvaluationRating> GetEvaluationratings();

        /// <summary>
        /// Gets the training status.
        /// </summary>
        /// <returns></returns>
        IList<ITrainingStatus> GetTrainingStatus();

        /// <summary>
        /// Gets the frequency of distribution by company identifier.
        /// </summary>
        /// <param name="conpanyId">The conpany identifier.</param>
        /// <returns></returns>
        IList<IFrequencyOfDeliveryModel> GetFrequencyOfDistribution();

        /// <summary>
        /// Gets the currency.
        /// </summary>
        /// <returns></returns>
        IList<ICurrency> GetCurrency();

        /// <summary>
        /// Gets the method of delivery.
        /// </summary>
        /// <returns></returns>
        IList<IMethodOfDelivery> GetMethodOfDelivery();

        /// <summary>
        /// Gets the discipline by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IDiscipline> GetDisciplineByCompanyId(int companyId);

        /// <summary>
        /// Gets the query status.
        /// </summary>
        /// <returns></returns>
        IList<IQueryStatus> GetQueryStatus();

        /// <summary>
        /// Gets the action taken.
        /// </summary>
        /// <returns></returns>
        IList<IActionTaken> GetActionTaken();

        /// <summary>
        /// Gets the discipline by company idand employee identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IList<IDiscipline> GetDisciplineByCompanyIdandEmployeeId(int companyId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trainingReportId"></param>
        /// <returns></returns>
        IList<ITrainingReport> GetTrainingReportByReportID(int trainingReportId);
        /// <summary>
        /// Gets the appraisal period.
        /// </summary>
        /// <returns></returns>
        IList<IAppraisalPeriod> GetAppraisalPeriod();
        /// <summary>
        /// Gets the country collection.
        /// </summary>
        /// <returns></returns>
        IList<ICountry> GetCountryCollection();
        /// <summary>
        /// Gets the state collection.
        /// </summary>
        /// <returns></returns>
        IList<IState> GetStateCollection();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        IList<ITraining> GetTrainingInCalendarByCompanyId(int companyId);

        /// <summary>
        /// get employee Deduction
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        IList<IEmployeeDeduction> GetEmployeeDeductionByCompanyId(int companyId);
        

        /// <summary>
        /// getEmployeeDeductionByCompanyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        IList<IEmployeeReward> getEmployeeDeductionByCompanyId(int companyId);

        /// <summary>
        /// Gets the employment types.
        /// </summary>
        /// <returns></returns>
        IList<IEmploymentType> GetEmploymentTypes();

        /// <summary>
        /// Gets all deduction by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IDeduction> GetAllDeductionByCompanyId(int companyId);

        /// <summary>
        /// Gets the next of kin.
        /// </summary>
        /// <returns></returns>
        IList<INextOfKin> GetNextOfKin();

        /// <summary>
        /// Gets the next of kin by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        INextOfKin GetNextOfKinById(int employeeId);

        /// <summary>
        /// Gets the next of kin description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        INextOfKin GetNextOfKinDescriptionByValue(string description);

        /// <summary>
        /// Gets the beneficiaries description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        IBeneficiariesModel GetBeneficiariesDescriptionByValue(string description);

        /// <summary>
        /// Gets the beneficiaries by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IBeneficiariesModel GetBeneficiariesById(int employeeId);

        /// <summary>
        /// Gets the emergency contact description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        IEmergency GetEmergencyContactDescriptionByValue(string description);

        /// <summary>
        /// Gets the emergency contact description by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IEmergency GetEmergencyContactDescriptionById(int employeeId);

        /// <summary>
        /// Gets the children information description by value.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        IChildrenModel GetChildrenInformationDescriptionByValue(string description);

        /// <summary>
        /// Gets the children information description by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IChildrenModel GetChildrenInformationDescriptionById(int employeeId);

        /// <summary>
        /// Gets the employee emergency contact by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IList<IEmergency> GetEmployeeEmergencyContactById(int employeeId);

        /// <summary>
        /// Gets the beneficiaries list by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IList<IBeneficiariesModel> GetBeneficiariesListById(int employeeId);

        /// <summary>
        /// Gets the next of kin list by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IList<INextOfKin> GetNextOfKinListById(int employeeId);

        /// <summary>
        /// Gets the children information list by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IList<IChildrenModel> GetChildrenInformationListById(int employeeId);

        /// <summary>
        /// Gets the discipline by company idand employee identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IList<IDiscipline> GetDisciplineByCompanyIdandEmployeeId(int companyId, int employeeId);

        /// <summary>
        /// Gets the employee reward list by employee identifier.
        /// </summary>
        /// <param name="employeeRewardId">The employee reward identifier.</param>
        /// <returns></returns>
        IList<IEmployeeReward> getEmployeeRewardListByEmployeeId(int employeeRewardId);

        /// <summary>
        /// Gets the calendar events.
        /// </summary>
        /// <returns></returns>
        IList<ICalendarEvent> GetCalendarEvents();

        /// <summary>
        /// Gets the calendar event.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns></returns>
        ICalendarEvent GetCalendarEvent(DateTime start, DateTime end);

        /// <summary>
        /// Gets the days.
        /// </summary>
        /// <returns></returns>
        IList<IDay> GetDays();

        /// <summary>
        /// Gets the weeks.
        /// </summary>
        /// <returns></returns>
        IList<IWeek> GetWeeks();

        /// <summary>
        /// Gets the schedules.
        /// </summary>
        /// <returns></returns>
        IList<ISchedule> GetSchedules();

        /// <summary>
        /// Gets the schedules by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<ISchedule> GetSchedulesByUserId(int userId);

        /// <summary>
        /// Gets the calendar events by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IList<ICalendarEvent> GetCalendarEventsByUserId(int userId);
    }
}
