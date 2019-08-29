using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AA.HRMS.Domain.Attributes;
using AA.HRMS.Domain.Models;
using AA.HRMS.Domain.Services;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.Models;
using AA.Infrastructure.Interfaces;
using PagedList;
using AA.HRMS.Domain.Model;

namespace AA.HRMS.Controllers
{

    [CheckUserLogin]
    [AccessAuthorize(Roles = new[] {AppAction.CompanyAdmin, AppAction.Employee})]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeOnBoardService employeeService;
        private readonly IGenerateDocumentService generateDocument;

        public EmployeeController(IEmployeeOnBoardService employeeService, IGenerateDocumentService generateDocument)
        {
            this.employeeService = employeeService;
            this.generateDocument = generateDocument;
        }

        #region //-------------------------------------------Employee Section-----------------------------------------//

        /// <summary>
        /// Employees the list.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="selectedCompanyId">The selected company identifier.</param>
        /// <returns></returns>s
        public ActionResult EmployeeList(int? page, string sortOrder, string searchString, string message)
        {
            var viewModel = this.employeeService.GetListOfEmployees(sortOrder, searchString, message, page);

            return this.View("EmployeeList", viewModel);
        }

        /// <summary>
        /// Views the employee.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">employeeId</exception>
        [HttpGet]
        public ActionResult ViewEmployee(int employeeId, string message)
        {
            //Show the detials of a selected Company
            if (employeeId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(employeeId));
            }
            
            //Get The View
            var viewModel = this.employeeService.GetOnBoardingView(employeeId, message);

            return this.View("ViewEmployee", viewModel);
        }

        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddEmployee()
        {
            var viewModel = this.employeeService.GetCreateEmployeeView();
            
            return this.View("AddEmployee", viewModel);
        }

        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="employeeInfo">The employee information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeInfo</exception>
        [HttpPost]
        public ActionResult AddEmployee(EmployeeOnBoardView employeeInfo, HttpPostedFileBase employeePhoto,
            HttpPostedFileBase employeeExcelSheet)
        {
            var processingMessage = string.Empty;

            //If you are uploading with excel sheet
            if (employeeExcelSheet != null)
            {
                processingMessage = this.employeeService.ProcessNewEmployeeInfoExcel(employeeExcelSheet);

                if (!string.IsNullOrEmpty(processingMessage))
                {
                    var model = this.employeeService.GetOnBoardingView(employeeInfo, processingMessage);

                    return this.View("AddEmployee", model);
                }

                processingMessage = string.Format("New Employee Added {0}", employeeInfo.LastName);
                
                return RedirectToAction("EmployeeList", new { message = processingMessage });
            }

            if (employeeInfo == null)
            {
                throw new ArgumentNullException(nameof(employeeInfo));
            }
            
            //Check Model State
            if (!ModelState.IsValid)
            {
                var model = this.employeeService.GetOnBoardingView(employeeInfo, string.Empty);

                return this.View("AddEmployee", model);
            }

            //Get The Logged In User Information in Order to Get The COmpany Curently Logged In to
            processingMessage = this.employeeService.ProcessNewEmployeeInfo(employeeInfo, employeePhoto);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.employeeService.GetOnBoardingView(employeeInfo, processingMessage);

                return this.View("AddEmployee", model);
            }

            var returnMessage = string.Format("New Employee Added -{0}", employeeInfo.LastName);

            return RedirectToAction("EmployeeList", new {companyId = employeeInfo.CompanyID, message = returnMessage});
        }

        /// <summary>
        /// Uploads the excel.
        /// </summary>
        /// <returns></returns>
        public ActionResult UploadExcel()
        {
            return this.PartialView("UploadExcel");
        }

        /// <summary>
        /// Edits the employee.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditEmployee(int employeeId)
        {
            var viewModel = employeeService.GetOnBoardingEditView(employeeId, string.Empty);

            return this.View("EditEmployee", viewModel);
        }

        /// <summary>
        /// Edits the employee.
        /// </summary>
        /// <param name="employeeInfo">The employee information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeInfo</exception>
        [HttpPost]
        public ActionResult EditEmployee(EmployeeOnBoardView employeeInfo, HttpPostedFileBase employeePhoto)
        {
            if (employeeInfo == null)
            {
                throw new ArgumentNullException(nameof(employeeInfo));
            }

            if (!ModelState.IsValid)
            {
                var model = this.employeeService.GetOnBoardingView(employeeInfo, string.Empty);

                return this.View("EditEmployee", model);
            }

            var processingMessage = employeeService.ProcessEditOnBoardingInformation(employeeInfo, employeePhoto);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                // update model with dropdown list
                var model = employeeService.GetOnBoardingView(employeeInfo, processingMessage);

                return this.View("EditEmployee", model);
            }

            var returnMessage = string.Format("Selected Employee Updated -{0}", employeeInfo.LastName);

            return RedirectToAction("EmployeeList", new {companyId = employeeInfo.CompanyID, message = returnMessage});
        }

        /// <summary>
        /// Deletes the employee.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">employeeId</exception>
        [HttpGet]
        public ActionResult DeleteEmployee(int employeeId)
        {
            if (employeeId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(employeeId));
            }
            

            var viewModel = employeeService.GetOnBoardingEditView(employeeId, "");

            return this.PartialView("DeleteEmployee", viewModel);
        }

        /// <summary>
        /// Deletes the employee.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeId</exception>
        [HttpPost]
        public ActionResult DeleteEmployee(int employeeId, int companyId, string btnSubmit)
        {
            if (employeeId <= 0)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }

            var message = employeeService.DeleteOnBoarding(employeeId);

            var returnMessage = string.Format("Selected Employee Deleted");

            return RedirectToAction("EmployeeList", new {companyId, message = returnMessage});
        }

        /// <summary>
        /// Locks the employee.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult LockEmployee(int employeeId)
        {

            var viewModel = employeeService.GetOnBoardingEditView(employeeId, "");

            return this.PartialView("LockEmployee", viewModel);

        }

        /// <summary>
        /// Locks the employee.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">employeeId</exception>
        [HttpPost]
        public ActionResult LockEmployee(int employeeId, int companyId, string btnSubmit="")
        {
            if (employeeId <= 0)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }
           
            var returnMessage = employeeService.ProcessEmployeeLock(employeeId);

            return this.RedirectToAction("EmployeeList", new { companyId, message = returnMessage });
        }
        
        /// <summary>
        /// Generates the report.
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
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public ActionResult GenerateReport(string lastName, string firstName, int? genderId, int? employeeTypeId, DateTime? dateEmployedFrom, DateTime? dateEmployedTo,
            int? countryId, int? stateOfOriginId, DateTime? dateExitedFrom, DateTime? dateExitTo, DateTime? dateRetirementFrom, DateTime? dateRetirementTo,
            DateTime? dateOfBirthFrom, DateTime? dateOfBirthTo, int? age, int? locationStateId, int? locationCountryId, int? page)
        {

            var viewModel = this.employeeService.GetReportOfEmployees(lastName, firstName, genderId ?? -1, employeeTypeId ?? -1, countryId ?? -1, stateOfOriginId ?? -1,
                dateExitedFrom, dateExitTo, dateRetirementFrom, dateRetirementTo, dateOfBirthFrom, dateOfBirthTo, age ?? -1, locationStateId ?? -1, locationCountryId ?? -1,
                page, dateEmployedFrom, dateEmployedTo);

            //Excel(viewModel.EmployeeList.ToList());

            return this.View("GenerateReport", viewModel);
        }


        /// <summary>
        /// Excels the specified employee collection.
        /// </summary>
        /// <param name="employeeCollection">The employee collection.</param>
        public void Excel(List<IEmployee> employeeCollection)
        {

            var title = "Report";

            Response.ClearContent();
            Response.BinaryWrite(generateDocument.GenerateExcel(employeeCollection, title));
            Response.AddHeader("content-disposition", "attachment; filename=ExcelDocument.xlsx");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.Flush();
            Response.End();

        }

        #endregion


        #region //----------------------------------------------Next of Kin------------------------------------------//

        /// <summary>
        /// Creates the next of kin.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateNextOfKin(int? employeeId, string url)
        {
            var viewModel = this.employeeService.CreateNextOfKinView(employeeId);

            viewModel.URL = url;

            return this.PartialView("CreateNextOfKin", viewModel);
        }

        /// <summary>
        /// Creates the next of kin.
        /// </summary>
        /// <param name="nextOfKin">The next of kin.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">nextOfKin</exception>
        [HttpPost]
        public ActionResult CreateNextOfKin(NextOfKinView nextOfKin, string url)
        {
            if (nextOfKin == null)
            {
                throw new ArgumentNullException(nameof(nextOfKin));
            }

            
            if (!ModelState.IsValid)
            {
                // call service to generate the View and return Back
                var viewModel = this.employeeService.CreateNextOfKinView(nextOfKin, string.Empty);

                // return view
                return View("CreateNextOfKin", viewModel);
            }

            //Register New Company
            var processingMessage = this.employeeService.ProcessNextOfKin(nextOfKin);

            //Check If there is a Message from the Service
            if (!string.IsNullOrEmpty(processingMessage))
            {
                // call service to update parentCompany drop down list
                var viewModel = this.employeeService.CreateNextOfKinView(nextOfKin, processingMessage);

                // return the view
                return this.View("CreateNextOfKin", viewModel);
            }

            processingMessage = string.Format("{0} Added  Next of Kin", nextOfKin.NextOfKinName);


            return this.Redirect(url + "&message=" + processingMessage);
        }

        /// <summary>
        /// Edits the next of kin.
        /// </summary>
        /// <param name="nextOfKinId">The next of kin identifier.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditNextOfKin(int nextOfKinId, string url)
        {
            var viewModel = this.employeeService.GetNextOfKinViewById(nextOfKinId);

            viewModel.URL = url;

            return this.PartialView("EditNextOfKin", viewModel);
        }

        /// <summary>
        /// Edits the next of kin.
        /// </summary>
        /// <param name="nextOfKin">The next of kin.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">nextOfKin</exception>
        [HttpPost]
        public ActionResult EditNextOfKin(NextOfKinView nextOfKin, string url)
        {

            if (nextOfKin == null)
            {
                throw new ArgumentNullException(nameof(nextOfKin));
            }


            //if (!ModelState.IsValid)
            //{
            //    // call service to generate the View and return Back
            //    var viewModel = this.employeeService.CreateNextOfKinView(nextOfKin, string.Empty);

            //    // return view
            //    return View("CreateNextOfKin", viewModel);
            //}

            //Register New Company
            var processingMessage = this.employeeService.ProcessEditNextOfKin(nextOfKin);

            //Check If there is a Message from the Service
            //if (!string.IsNullOrEmpty(processingMessage))
            //{
            //    // call service to update parentCompany drop down list
            //    var viewModel = this.employeeService.CreateNextOfKinView(nextOfKin, processingMessage);

            //    // return the view
            //    return this.View("CreateNextOfKin", viewModel);
            //}
            processingMessage = string.Format("{0} Made a Modification to Next Of Kin a Spouse", nextOfKin.NextOfKinName);

            return this.Redirect(url+ "&message=" +processingMessage);
        }

        /// <summary>
        /// Deletes the next of kin.
        /// </summary>
        /// <param name="nextOfKinId">The next of kin identifier.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteNextOfKin(int nextOfKinId, string url)
        {
            var viewModel = this.employeeService.GetNextOfKinViewById(nextOfKinId);
            viewModel.URL = url;
            return PartialView("DeleteNextOfKin", viewModel);
        }

        /// <summary>
        /// Deletes the next of kin.
        /// </summary>
        /// <param name="nextOfKinId">The next of kin identifier.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">nextOfKinId</exception>
        [HttpPost]
        public ActionResult DeleteNextOfKin(int nextOfKinId, string btnSubmit, string url)
        {
            if (nextOfKinId <= 0)
            {
                throw new ArgumentOutOfRangeException("nextOfKinId");
            }

            var deleteNextofKin = this.employeeService.ProcessDeleteNextOfKin(nextOfKinId);


            var returnMessage = string.Format("Next of Kin Deleted");
            
            return Redirect(url + "&message="+ returnMessage);
           
        }

        #endregion


        #region //-------------------------------------------Beneficiary Section-----------------------------------//

        /// <summary>
        /// Creates the beneficiaries.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateBeneficiaries(int? employeeId, string url)
        {
            var viewModel = this.employeeService.CreateBeneficiariesView(employeeId);

            viewModel.URL = url;

            return PartialView("CreateBeneficiaries", viewModel);
        }

        /// <summary>
        /// Creates the beneficiaries.
        /// </summary>
        /// <param name="beneficiaries">The beneficiaries.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">beneficiaries</exception>
        [HttpPost]
        public ActionResult CreateBeneficiaries(BeneficiariesView beneficiaries, string url)
        {
            if (beneficiaries == null)
            {
                throw new ArgumentNullException(nameof(beneficiaries));
            }


            if (!ModelState.IsValid)
            {
                // call service to generate the View and return Back
                var viewModel = this.employeeService.CreateBeneficiariesView(beneficiaries, string.Empty);

                // return view
                return View("CreateBeneficiaries", viewModel);
            }

            //Register New Company
            var processingMessage = this.employeeService.ProcessBeneficiaries(beneficiaries);

            //Check If there is a Message from the Service
            if (!string.IsNullOrEmpty(processingMessage))
            {
                // call service to update parentCompany drop down list
                var viewModel = this.employeeService.CreateBeneficiariesView(beneficiaries, processingMessage);

                // return the view
                return this.View("CreateBeneficiaries", viewModel);
            }

            var returnMessage = string.Format("Beneficiaries added successfully");


            return Redirect(url + "&message=" + returnMessage);
        }

        /// <summary>
        /// Edits the beneficiaries.
        /// </summary>
        /// <param name="beneficiariesId">The beneficiaries identifier.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditBeneficiaries(int beneficiariesId, string url)
        {
            var viewModel = this.employeeService.GetBenefiiariesViewById(beneficiariesId);
            viewModel.URL = url;
            return PartialView("EditBeneficiaries", viewModel);
        }

        /// <summary>
        /// Edits the beneficiaries.
        /// </summary>
        /// <param name="beneficiaries">The beneficiaries.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">beneficiaries</exception>
        [HttpPost]
        public ActionResult EditBeneficiaries(BeneficiariesView beneficiaries, string url)
        {

            if (beneficiaries == null)
            {
                throw new ArgumentNullException(nameof(beneficiaries));
            }

            

            //Register New Company
            var processingMessage = this.employeeService.ProcessEditBeneficiaries(beneficiaries);

            //Check If there is a Message from the Service
          

            var returnMessage = string.Format("Beneficiaries Edited successfully");

            return Redirect(url +"&message="+ returnMessage);
         
        }

        /// <summary>
        /// Deletes the beneficiaries.
        /// </summary>
        /// <param name="beneficiariesId">The beneficiaries identifier.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteBeneficiaries(int beneficiariesId, string url)
        {
            var viewModel = this.employeeService.GetBenefiiariesViewById(beneficiariesId);
            viewModel.URL = url;
            return PartialView("DeleteBeneficiaries", viewModel);
        }

        /// <summary>
        /// Deletes the beneficiaries.
        /// </summary>
        /// <param name="beneficiariesId">The beneficiaries identifier.</param>
        /// <p aram name="btnSubmit">The BTN submit.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">employeeId</exception>
        [HttpPost]
        public ActionResult DeleteBeneficiaries(int beneficiariesId, string btnSubmit, string url)
        {
            if (beneficiariesId <= 0)
            {
                throw new ArgumentOutOfRangeException("employeeId");
            }

            var deleteBeneficiaries = this.employeeService.ProcessDeleteBeneficiaries(beneficiariesId);
            
            var returnMessage = string.Format("Beneficiaries Deleted");

            return Redirect(url + "&message=" + returnMessage);
        }

        #endregion


        #region //-----------------------------------------------------Emergency Contact Secton-------------------------------------------//

        /// <summary>
        /// Emergencies the contact.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EmergencyContact(int? employeeId, string url)
        {

            var viewModel = this.employeeService.CreateEmergencyContactView(employeeId);
            viewModel.URL = url;
            return this.PartialView("EmergencyContact", viewModel);
        }

        /// <summary>
        /// Emergencies the contact.
        /// </summary>
        /// <param name="emergency">The emergency.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">emergency</exception>
        [HttpPost]
        public ActionResult EmergencyContact(EmergencyContactView emergency, string url)
        {
            if (emergency == null)
            {
                throw new ArgumentNullException(nameof(emergency));
            }


            if (!ModelState.IsValid)
            {
                // call service to generate the View and return Back
                var viewModel = this.employeeService.CreateEmergencyContactView(emergency, string.Empty);

                // return view
                return View("EmergencyContact", viewModel);
            }

            //Register New Company
            var processingMessage = this.employeeService.ProcessEmergencyContact(emergency);

            //Check If there is a Message from the Service
            if (!string.IsNullOrEmpty(processingMessage))
            {
                // call service to update parentCompany drop down list
                var viewModel = this.employeeService.CreateEmergencyContactView(emergency, processingMessage);

                // return the view
                return this.View("EmergencyContact", viewModel);
            }

            var returnMessage = string.Format("Emergency Contact added successfully");

            return Redirect(url +"&message= " + returnMessage);
        }

        /// <summary>
        /// Edits the emergency contact.
        /// </summary>
        /// <param name="emergencyContactId">The emergency contact identifier.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditEmergencyContact(int emergencyContactId, string url)
        {
            var viewModel = this.employeeService.GetEmergencyContactViewById(emergencyContactId);
            viewModel.URL = url;
            return PartialView("EditEmergencyContact", viewModel);
        }

        /// <summary>
        /// Edits the emergency contact.
        /// </summary>
        /// <param name="emergency">The emergency.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">emergency</exception>
        [HttpPost]
        public ActionResult EditEmergencyContact(EmergencyContactView emergency, string url)
        {

            if (emergency == null)
            {
                throw new ArgumentNullException(nameof(emergency));
            }


            if (!ModelState.IsValid)
            {
                // call service to generate the View and return Back
                var viewModel = this.employeeService.CreateEmergencyContactView(emergency, string.Empty);

                // return view
                return View("EditBeneficiaries", viewModel);
            }

            //Register New Company
            var processingMessage = this.employeeService.ProcessEditEmergencyContact(emergency);

            //Check If there is a Message from the Service
            if (!string.IsNullOrEmpty(processingMessage))
            {
                // call service to update parentCompany drop down list
                var viewModel = this.employeeService.CreateEmergencyContactView(emergency, processingMessage);

                // return the view
                return this.View("EditBeneficiaries", viewModel);
            }

            var returnMessage = string.Format("Emergency Contact Edited successfully");

            return Redirect(url + "&message= " + returnMessage);
        }

        /// <summary>
        /// Deletes the emergency contact.
        /// </summary>
        /// <param name="emergencyContactId">The emergency contact identifier.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteEmergencyContact(int emergencyContactId, string url)
        {
            var viewModel = this.employeeService.GetEmergencyContactViewById(emergencyContactId);
            viewModel.URL = url;
            return PartialView("DeleteEmergencyContact", viewModel);
        }

        /// <summary>
        /// Deletes the emergency contact.
        /// </summary>
        /// <param name="emergency">The emergency.</param>
        /// <param name="url">The URL.</param>
        /// <param name="btnSubmit">The BTN submit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">emergency</exception>
        [HttpPost]
        public ActionResult DeleteEmergencyContact(EmergencyContactView emergency, string url, string btnSubmit)
        {
            if (emergency == null)
            {
                throw new ArgumentOutOfRangeException("emergency");
            }

            var deleteBeneficiaries = this.employeeService.ProcessDeleteEmergency(emergency);


            var returnMessage = string.Format("Beneficiaries Deleted");

            return Redirect(url + "&message=" + returnMessage);
        }

        #endregion


        #region //-------------------------------------------Children Information----------------------------------------------------//

        /// <summary>
        /// Creates the children information.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateChildrenInformation(int? employeeId, string url)
        {
            var viewModel = this.employeeService.CreateChildrenInformationView(employeeId);
            viewModel.URL = url;
            return PartialView("CreateChildrenInformation", viewModel);
        }

        /// <summary>
        /// Creates the children information.
        /// </summary>
        /// <param name="childrenInformation">The children information.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">childrenInformation</exception>
        [HttpPost]
        public ActionResult CreateChildrenInformation(ChildrenInformationView childrenInformation, string url)
        {
            if (childrenInformation == null)
            {
                throw new ArgumentNullException(nameof(childrenInformation));
            }


            if (!ModelState.IsValid)
            {
                // call service to generate the View and return Back
                var viewModel = this.employeeService.CreateChildrenInformationView(childrenInformation, string.Empty);

                // return view
                return View("CreateChildrenInformation", viewModel);
            }

            //Register New Company
            var processingMessage = this.employeeService.ProcessChildrenInformation(childrenInformation);

            //Check If there is a Message from the Service
            if (!string.IsNullOrEmpty(processingMessage))
            {
                // call service to update parentCompany drop down list
                var viewModel = this.employeeService.CreateChildrenInformationView(childrenInformation, processingMessage);

                // return the view
                return this.View("CreateChildrenInformation", viewModel);
            }

            var returnMessage = string.Format("Children Information added successfully");


            return Redirect(url + "&message=" + returnMessage);
        }

        /// <summary>
        /// Edits the children information.
        /// </summary>
        /// <param name="childrenId">The children identifier.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditChildrenInformation(int childrenId, string url)
        {
            var viewModel = this.employeeService.GetChildrenInformationViewById(childrenId);
            viewModel.URL = url;
            return PartialView("EditChildrenInformation", viewModel);
        }

        /// <summary>
        /// Edits the children information.
        /// </summary>
        /// <param name="information">The information.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">information</exception>
        [HttpPost]
        public ActionResult EditChildrenInformation(ChildrenInformationView information, string url)
        {

            if (information == null)
            {
                throw new ArgumentNullException(nameof(information));
            }


            //if (!ModelState.IsValid)
            //{
            //    // call service to generate the View and return Back
            //    var viewModel = this.employeeService.CreateChildrenInformationView(information, string.Empty);

            //    // return view
            //    return View("EditChildrenInformation", viewModel);
            //}

            //Register New Company
            var processingMessage = this.employeeService.ProcessEditChildrenInformation(information);

            ////Check If there is a Message from the Service
            //if (!string.IsNullOrEmpty(processingMessage))
            //{
            //    // call service to update parentCompany drop down list
            //    var viewModel = this.employeeService.CreateChildrenInformationView(information, processingMessage);

            //    // return the view
            //    return this.View("EditChildrenInformation", viewModel);
            //}

            var returnMessage = string.Format("Children Information Edited successfully");

            return Redirect(url + "&message=" + returnMessage);
       
        }

        /// <summary>
        /// Deletes the children information.
        /// </summary>
        /// <param name="childrenId">The children identifier.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteChildrenInformation(int childrenId, string url)
        {
            var viewModel = this.employeeService.GetChildrenInformationViewById(childrenId);
            viewModel.URL = url;
            return PartialView("DeleteChildrenInformation", viewModel);
        }

        /// <summary>
        /// Deletes the children information.
        /// </summary>
        /// <param name="information">The information.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">employeeId</exception>
        [HttpPost]
        public ActionResult DeleteChildrenInformation(ChildrenInformationView information, string url)
        {
            if (information == null)
            {
                throw new ArgumentOutOfRangeException("employeeId");
            }

            var deleteBeneficiaries = this.employeeService.ProcessDeleteChildrenInformation(information);


            var returnMessage = string.Format(" Children Information Deleted");


            return Redirect(url + "&message=" + returnMessage);
        }

        #endregion


        #region //--------------------------------------------Spouse Information--------------------------------------------------//

        /// <summary>
        /// Creates the spouse.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateSpouse(int? employeeId, string url)
        {
            var viewmodel = this.employeeService.GetSpouseDetailsForEmployee(employeeId);
            viewmodel.URL = url;
            return this.PartialView("CreateSpouse", viewmodel);
        }

        /// <summary>
        /// Creates the spouse.
        /// </summary>
        /// <param name="spouseViewModel">The spouse view model.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">spouseViewModel</exception>
        [HttpPost]
        public ActionResult CreateSpouse(SpouseViewModel spouseViewModel, string url)
        {
            if (spouseViewModel == null)
            {
                throw new ArgumentNullException(nameof(spouseViewModel));
            }
            if (!ModelState.IsValid)
            {
                var viewmodel = this.employeeService.GetSpouseCreateView(spouseViewModel, "");
                return this.View("CreateSpouse", viewmodel);
            }

            var processingMessage = this.employeeService.ProcessSpouseCreateView(spouseViewModel);
           

            if(!string.IsNullOrEmpty(processingMessage))
            {
                var viewmodel = this.employeeService.GetSpouseCreateView(spouseViewModel, processingMessage);
                return View("CreateSpouse", viewmodel);
            }

            processingMessage = string.Format("{0} Added a Spouse", spouseViewModel.SpouseName);

            return Redirect(url +"&message="+ processingMessage);
        }

        /// <summary>
        /// Edits the spouse.
        /// </summary>
        /// <param name="spouseId">The spouse identifier.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditSpouse(int spouseId, string url)
        {
            var viewModel = this.employeeService.GetspouseEditView(spouseId);
            viewModel.URL = url;
            return PartialView("EditSpouse", viewModel);
        }

        /// <summary>
        /// Edits the spouse.
        /// </summary>
        /// <param name="spouseViewModel">The spouse view model.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">spouseViewModel</exception>
        [HttpPost]
        public ActionResult EditSpouse(SpouseViewModel spouseViewModel, string url)
        {
            if (spouseViewModel == null)
            {
                throw new ArgumentNullException(nameof(spouseViewModel));
            }

            if (!ModelState.IsValid)
            {
                var viewmodel = this.employeeService.GetSpouseCreateView(spouseViewModel, "");
                return this.View("/Profile/Index?message="+viewmodel);
            }

            var processingMessage = this.employeeService.ProcessSpouseEditView(spouseViewModel);
            //return View("EditSpouse", processingMessage);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var viewmodel = this.employeeService.GetSpouseCreateView(spouseViewModel, processingMessage);
                return View("EditSpouse", viewmodel);
            }

            processingMessage = string.Format("{0} Updated", spouseViewModel.SpouseName, "Successfully");

        
            return Redirect(url + "&message=" + processingMessage);

        }

        /// <summary>
        /// Deletes the spouse.
        /// </summary>
        /// <param name="spouseId">The spouse identifier.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteSpouse(int spouseId, string url)
        {
            var viewModel = this.employeeService.GetspouseEditView(spouseId);
            viewModel.URL = url;
            return PartialView("DeleteSpouse", viewModel);
        }

        /// <summary>
        /// Deletes the spouse.
        /// </summary>
        /// <param name="spouseId">The spouse identifier.</param>
        /// <param name="url">The URL.</param>
        /// <param name="submitBtn">The submit BTN.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteSpouse(int spouseId, string url, string submitBtn)
        {
            var viewModel = this.employeeService.ProcesspouseDeleteView(spouseId);

            viewModel = string.Format("Spouse Delete Successfuly");

            return Redirect(url + "&message=" + viewModel);

        }

        #endregion


        #region //--------------------------------------------Promotion Section-------------------------------------------//

        /// <summary>
        /// Promotionses the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult Promotions(string message)
        {
            var model = this.employeeService.GetPromotionListView(message);

            return View("Promotions", model);
        }

        /// <summary>
        /// Employees the promotion.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeId</exception>
        public ActionResult EmployeePromotion(int employeeId, string message)
        {

            if (employeeId < 1) throw new ArgumentNullException(nameof(employeeId));

            var model = this.employeeService.GetPromotionListView(employeeId, message);
            
            return View("EmployeePromotion", model);
        }

        /// <summary>
        /// Promotes the specified employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employeeId</exception>
        [HttpGet]
        public ActionResult Promote(int employeeId)
        {
            if (employeeId < 1) throw new ArgumentNullException(nameof(employeeId));

            var model = this.employeeService.GetPromotionView(employeeId);

            return PartialView("Promote", model);
        }

        /// <summary>
        /// Promotes the specified promotion.
        /// </summary>
        /// <param name="promotion">The promotion.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">promotion</exception>
        [HttpPost]
        public ActionResult Promote(PromotionView promotion)
        {

            if (promotion == null) throw new ArgumentNullException(nameof(promotion));

            if (!ModelState.IsValid)
            {
                var model = this.employeeService.GetPromotionView(promotion, string.Empty);
                return View("Promote", model);
            }

            var processingMessage = this.employeeService.ProcessPromotion(promotion);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var model = this.employeeService.GetPromotionView(promotion, processingMessage);
                return View("Promote", model);
            }

            processingMessage = string.Format("Successfully promoted {0}", promotion.EmployeeName);

            return RedirectToAction("EmployeePromotion", new { employeeId = promotion.EmployeeId, message = processingMessage });
        }

        #endregion
    }
}