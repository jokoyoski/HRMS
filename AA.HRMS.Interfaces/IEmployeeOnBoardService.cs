using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web; 

namespace AA.HRMS.Interfaces
{
    public interface IEmployeeOnBoardService
    {
        /// <summary>
        /// Gets the create employee view.
        /// </summary>
        /// <returns></returns>
        IEmployeeOnBoardView GetCreateEmployeeView();

        /// <summary>
        /// Gets the on boarding view.
        /// </summary>
        /// <param name="onBoarding">The on boarding.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IEmployeeOnBoardView GetOnBoardingView(IEmployeeOnBoardView onBoarding, string message);


        /// <summary>
        /// Deletes the on boarding.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        string DeleteOnBoarding(int employeeId);

        /// <summary>
        /// Gets the on boarding edit view.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="loggedUserId">The logged user identifier.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeOnBoardView GetOnBoardingEditView(int employeeId, string processingMessage);

        /// <summary>
        /// Processes the employee lock.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="loggedUserId">The logged user identifier.</param>
        /// <returns></returns>
        string ProcessEmployeeLock(int employeeId);
        /// <summary>
        /// Processes the edit on boarding information.
        /// </summary>
        /// <param name="onboardInfo">The onboard information.</param>
        /// <param name="profilePicture">The profile picture.</param>
        /// <returns></returns>
        string ProcessEditOnBoardingInformation(IEmployeeOnBoardView onboardInfo, HttpPostedFileBase profilePicture);
        /// <summary>
        /// Processes the new employee information.
        /// </summary>
        /// <param name="onboardInfo">The onboard information.</param>
        /// <param name="profilePicture">The profile picture.</param>
        /// <returns></returns>
        string ProcessNewEmployeeInfo(IEmployeeOnBoardView onboardInfo, HttpPostedFileBase profilePicture);

        /// <summary>
        /// Processes the new employee information excel.
        /// </summary>
        /// <param name="employeeExcelSheet">The employee excel sheet.</param>
        /// <returns></returns>
        string ProcessNewEmployeeInfoExcel(HttpPostedFileBase employeeExcelSheet);

        /// <summary>
        /// Gets the on boarding view.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="loggedUserId">The logged user identifier.</param>
        /// <param name="processingMesage">The processing mesage.</param>
        /// <returns></returns>
        IEmployeeProfileView GetOnBoardingView(int employeeId, string processingMesage);
        /// <summary>
        /// Gets the admin dash board view.
        /// </summary>
        /// <param name="loggedUserId">The logged user identifier.</param>
        /// <param name="processingMesage">The processing mesage.</param>
        /// <returns></returns>
        IEmployeeProfileView GetAdminDashBoardView(string processingMesage);

        /// <summary>
        /// Gets the employee dash board view.
        /// </summary>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IEmployeeProfileView GetEmployeeDashBoardView(string processingMessage);

        /// <summary>
        /// Gets the list of employees.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="staffNumber">The staff number.</param>
        /// <param name="staffName">Name of the staff.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        IEmployeeOnBoardListView GetListOfEmployees(string sortOrder,
            string searchString,
            string message, int? page);

        /// <summary>
        /// Gets the report of employees.
        /// </summary>
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
        IEmployeeOnBoardListView GetReportOfEmployees(string lastName, string firstName, int genderId, int employeeTypeId,
            int countryId, int stateOfOriginId, DateTime? dateExitedFrom, DateTime? dateExitTo, DateTime? dateRetirementFrom, DateTime? dateRetirementTo,
            DateTime? dateOfBirthFrom, DateTime? dateOfBirthTo, int age, int locationStateId, int locationCountryId, int? page,
            DateTime? dateEmployedFrom, DateTime? dateEmployedTo);

        INextOfKinView CreateNextOfKinView(int? employeeId);
        INextOfKinView CreateNextOfKinView(INextOfKinView nextOfKin, string message);
        string ProcessNextOfKin(INextOfKinView nextOfKin);
        string ProcessEditNextOfKin(INextOfKinView nextOfKin);
        INextOfKinView GetNextOfKinViewById(int employeeId);
        string ProcessDeleteNextOfKin(int employeeId);

        IBeneficiariesView CreateBeneficiariesView(int? employeeId);
        IBeneficiariesView CreateBeneficiariesView(IBeneficiariesView beneficiaries, string message);
        string ProcessBeneficiaries(IBeneficiariesView beneficiaries);
        IBeneficiariesView GetBenefiiariesViewById(int employeeId);
        string ProcessEditBeneficiaries(IBeneficiariesView beneficiaries);
        string ProcessDeleteBeneficiaries(int employeeId);



        IEmergencyContactView CreateEmergencyContactView(int? employeeId);
        IEmergencyContactView CreateEmergencyContactView(IEmergencyContactView emergency, string message);
        string ProcessEmergencyContact(IEmergencyContactView emergency);
        IEmergencyContactView GetEmergencyContactViewById(int employeeId);
        string ProcessEditEmergencyContact(IEmergencyContactView emergency);
        string ProcessDeleteEmergency(IEmergencyContactView emergency);



        IChildrenInformationView CreateChildrenInformationView(int? employeeId);
        IChildrenInformationView CreateChildrenInformationView(IChildrenInformationView childrenInformation, string message);
        string ProcessChildrenInformation(IChildrenInformationView childrenInformation);
        IChildrenInformationView GetChildrenInformationViewById(int employeeId);
        string ProcessEditChildrenInformation(IChildrenInformationView information);
        string ProcessDeleteChildrenInformation(IChildrenInformationView information);


        ISpouseViewModel GetSpouseDetailsForEmployee(int? employeeId);

        string ProcessSpouseCreateView(ISpouseViewModel spouseViewModel);

        ISpouseViewModel GetSpouseCreateView(ISpouseViewModel spouseViewModel, string processingMessage);

        ISpouseViewModel GetspouseEditView(int spouseId);
        string ProcessSpouseEditView(ISpouseViewModel spouseViewModel);
        string ProcesspouseDeleteView(int spouseId);

        IPromotionListView GetPromotionListView(string message);
        IPromotionListView GetPromotionListView(int employeeId, string message);
        IPromotionView GetPromotionView(int employeeId);
        IPromotionView GetPromotionView(IPromotionView promottion, string processingMessage);
        string ProcessPromotion(IPromotionView promotionView);



    }
}