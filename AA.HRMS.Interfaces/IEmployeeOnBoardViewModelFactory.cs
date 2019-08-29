using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IEmployeeOnBoardViewModelFactory
    {
        /// <summary>
        /// Creates the employee view.
        /// </summary>
        /// <param name="maritalStatusCollection">The marital status collection.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="religionCollection">The religion collection.</param>
        /// <param name="genderCollection">The gender collection.</param>
        /// <returns></returns>
        IEmployeeOnBoardView CreateEmployeeView(IList<IMaritalStatus> maritalStatusCollection, int companyId, IList<IEmployee> employeeCollection,
            IList<IReligion> religionCollection, IList<IYourGender> genderCollection, IList<IDepartment> departmentCollection, IList<ILevel> levelCollection,
            IList<IGrade> gradeCollection, IList<IPayScale> payScaleCollection, IList<IJobTitle> jobTitleCollection, IList<ICountry> countryCollecction, IList<IState> stateCollection, IList<IEmploymentType> employmentTypeCollection);

        /// <summary>
        /// Creates the edit updated employee view.
        /// </summary>
        /// <param name="onboadingInfo">The onboading information.</param>
        /// <returns></returns>
        IEmployeeOnBoardView CreateEditUpdatedEmployeeView(IEmployeeOnBoardView onboadingInfo);

        /// <summary>
        /// Creates the updated employee view.
        /// </summary>
        /// <param name="onboardingInfo">The onboarding information.</param>
        /// <param name="maritalStatusCollection">The marital status collection.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="religionCollection">The religion collection.</param>
        /// <param name="genderCollection">The gender collection.</param>
        /// <param name="departmentCollection">The department collection.</param>
        /// <param name="levelCollection">The level collection.</param>
        /// <param name="gradeCollection">The grade collection.</param>
        /// <param name="jobTitleCollection">The job title collection.</param>
        /// <param name="countryCollecction">The country collecction.</param>
        /// <param name="stateCollecction">The state collecction.</param>
        /// <param name="employmentTypeCollection">The employment type collection.</param>
        /// <param name="processMessage">The process message.</param>
        /// <returns></returns>
        IEmployeeOnBoardView CreateUpdatedEmployeeView(IEmployeeOnBoardView onboardingInfo, IList<IMaritalStatus> maritalStatusCollection, IList<IEmployee> employeeCollection,
            IList<IReligion> religionCollection, IList<IYourGender> genderCollection, IList<IDepartment> departmentCollection, IList<ILevel> levelCollection, IList<IGrade> gradeCollection,
            IList<IPayScale> payScaleCollection,
            IList<IJobTitle> jobTitleCollection, IList<ICountry> countryCollecction, IList<IState> stateCollecction, IList<IEmploymentType> employmentTypeCollection, string processMessage);


        /// <summary>
        /// Creates the edit employee view.
        /// </summary>
        /// <param name="onboardInfo">The onboard information.</param>
        /// <param name="maritalStatusCollection">The marital status collection.</param>
        /// <param name="religionCollection">The religion collection.</param>
        /// <param name="genderCollection">The gender collection.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="departmentCollection">The department collection.</param>
        /// <param name="levelCollection">The level collection.</param>
        /// <param name="gradeCollection">The grade collection.</param>
        /// <param name="jobTitleCollection">The job title collection.</param>
        /// <param name="profilePictureDetail">The profile picture detail.</param>
        /// <param name="employeeUser">The employee user.</param>
        /// <param name="countryCollection">The country collection.</param>
        /// <param name="stateCollection">The state collection.</param>
        /// <param name="employmentTypeCollection">The employment type collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeOnBoardView CreateEditEmployeeView(IEmployee onboardInfo,
            IList<IMaritalStatus> maritalStatusCollection,
            IList<IReligion> religionCollection, IList<IYourGender> genderCollection, IList<IEmployee> employeeCollection,
            IList<IDepartment> departmentCollection, IList<ILevel> levelCollection, IList<IGrade> gradeCollection, IList<IJobTitle> jobTitleCollection,
            IDigitalFile profilePictureDetail, IUser employeeUser, IList<ICountry> countryCollection, IList<IState> stateCollection, IList<IEmploymentType> employmentTypeCollection, string processingMessage);

        /// <summary>
        /// Creates the employee registration view.
        /// </summary>
        /// <returns></returns>
        IEmployeeOnBoardView CreateEmployeeRegistrationView();

        IEmployeeProfileView CreateEmployeeView(IEmployee employee, IUserDetail user, IList<ICompanyDetail> companyCollection,
            IList<IDiscipline> disciplineCollection, IList<ILeaveRequestModel> leaveRequestModel, IList<IEmploymentHistory> employmentHistory,
            IList<IEducationHistory> educationHistory, IList<ISkillSetModel> skillSet, IDigitalFile digitalFile, IList<ISpouseModel> spouseModel, IList<IEmergency> emergency,
            IList<IChildrenModel> childrenModel, IList<IBeneficiariesModel> beneficiariesModel,
            IList<INextOfKin> nextOfKin,
            string processingMessage);

        /// <summary>
        /// Creates the admin dash board view.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="company">The company.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="levelCollection">The level collection.</param>
        /// <param name="gradeCollection">The grade collection.</param>
        /// <param name="jobTitleCollection">The job title collection.</param>
        /// <param name="disciplineCollection">The discipline collection.</param>
        /// <param name="leaveRequestModel">The leave request model.</param>
        /// <param name="departmentCollection">The department collection.</param>
        /// <param name="trainingCollection">The training collection.</param>
        /// <param name="employeeCollection">The employee collection.</param>
        /// <param name="employmentHistory">The employment history.</param>
        /// <param name="educationHistory">The education history.</param>
        /// <param name="skillSet">The skill set.</param>
        /// <param name="digitalFile">The digital file.</param>
        /// <param name="pendingLeaveRequests">The pending leave requests.</param>
        /// <param name="pendingLoanRequest">The pending loan request.</param>
        /// <param name="pendingTrainingRequest">The pending training request.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeProfileView CreateAdminDashBoardView(IUserDetail user, IEmployee employeeInfo, ICompanyDetail company, IList<ICompanyDetail> companyCollection, IList<ILevel> levelCollection, IList<IGrade> gradeCollection, IList<IJobTitle> jobTitleCollection, IList<IDiscipline> disciplineCollection,
            IList<ILeaveRequestModel> leaveRequestModel, IList<IDepartment> departmentCollection, IList<ITraining> trainingCollection, IList<IEmployee> employeeCollection,
            IList<IEmploymentHistory> employmentHistory, IList<IEducationHistory> educationHistory, IList<ISkillSetModel> skillSet, IDigitalFile digitalFile, IList<ILeaveRequestModel> pendingLeaveRequests,
            IList<IEmployeeLoan> pendingLoanRequest, IList<IEmployeeTrainingModel> pendingTrainingRequest, string processingMessage);


        IEmployeeProfileView CreateDashBoardView(IUserDetail user, IEmployee employee, IList<ICompanyDetail> companyCollection,
            IList<IDiscipline> disciplineCollection, IList<ILeaveRequestModel> leaveRequestModel, IList<IDepartment> departmentCollection,
            IList<ITraining> trainingCollection, IList<IEmployeeTrainingModel> trainingRequestCollection, ILeaveRequestModel leaveRequest, IList<IEmployee> employeeCollection,
            IList<IEmploymentHistory> employmentHistory, IList<IEducationHistory> educationHistory, IList<ISkillSetModel> skillSet, IDigitalFile digitalFile,
            string processingMessage);



        /// <summary>
        /// Gets the employee ListView.
        /// </summary>
        /// <param name="onboardingCollections">The onboarding collections.</param>
        /// <param name="staffNumber">The staff number.</param>
        /// <param name="staffName">Name of the staff.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IEmployeeOnBoardListView GetEmployeeListView(
            IList<IEmployee> onboardingCollections, IList<ICompanyDetail> companyCollection, string sortOrder, string searchString, string message, int? page);

        /// <summary>
        /// Creates the employee report.
        /// </summary>
        /// <param name="userInfo">The user information.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="genderId">The gender identifier.</param>
        /// <param name="employeeTypeId">The employee type identifier.</param>
        /// <param name="countryId">The country identifier.</param>
        /// <param name="stateOfOriginId">The state of origin identifier.</param>
        /// <param name="dateExitedFrom">The date exited from.</param>
        /// <param name="dateExitTo">The date exit to.</param>
        /// <param name="dateRetirementFrom">The date retirement from.</param>
        /// <param name="dateRetirementTo">The date retirement to.</param>
        /// <param name="dateOfBirthFrom">The date of birth from.</param>
        /// <param name="dateOfBirthTo">The date of birth to.</param>
        /// <param name="age">The age.</param>
        /// <param name="locationStateId">The location state identifier.</param>
        /// <param name="locationCountryId">The location country identifier.</param>
        /// <returns></returns>
        IEmployeeOnBoardListView CreateEmployeeReport(IList<IEmployee> employeeCollection, string lastName, string firstName, int genderId, IList<IYourGender> genderCollection, int employeeTypeId,
            IList<IEmploymentType> employmentTypeCollecton, int countryId, IList<ICountry> countryCollection, int stateOfOriginId, IList<IState> stateCollection, DateTime? dateExitedFrom,
            DateTime? dateExitTo, DateTime? dateRetirementFrom, DateTime? dateRetirementTo, DateTime? dateOfBirthFrom, DateTime? dateOfBirthTo, int age, int locationStateId, int locationCountryId, int? page,
            DateTime? dateEmployedFrom, DateTime? dateEmployedTo);

        INextOfKinView CreateNextOfKin(int employeeId, string message);
        INextOfKinView CreateNextOfKin(INextOfKinView nextOfKin, string message);
        INextOfKinView CreateNextOfKinById(INextOfKin employeeId);



        IBeneficiariesView CreateBeneficiaries(int employeeId, string message);
        IBeneficiariesView CreateBeneficiaries(IBeneficiariesView beneficiaries, string message);
        IBeneficiariesView CreateBeneficiariesById(IBeneficiariesModel beneficiaries);


        IEmergencyContactView CreateEmergencyContact(IEmergency emergency);
        IEmergencyContactView CreateEmergencyContact(IEmergencyContactView emergencyContact, string message);
        IEmergencyContactView CreateEmergencyContact(int employeeId, string message);


        IChildrenInformationView CreateChildrenInformation(int employeeId, string message);
        IChildrenInformationView CreateChildrenInformation(IChildrenInformationView childrenInformation, string message);
        IChildrenInformationView CreateChildrenInformationById(IChildrenModel childrenInformation);
    }
}