using System;
using AA.HRMS.Interfaces;
using System.Web.Mvc;
using AA.HRMS.Domain.Models;
using AA.HRMS.Domain.Attributes;
using AA.HRMS.Interfaces.ValueTypes;
using AA.Infrastructure.Interfaces;
using System.Web;

namespace AA.HRMS.Controllers
{

    [AccessAuthorize(Roles = new[] { AppAction.CompanyAdmin, AppAction.Administration })]
    [CheckUserLogin]
    public class AdministrationController : Controller
    {

        private readonly IAdminService adminService; 
        private readonly IUserService userService;
        private readonly IAccountService accountService;

        public AdministrationController(IAdminService adminService, IUserService userService,
            IAccountService accountService)
        {
            this.adminService = adminService;
            this.userService = userService;
            this.accountService = accountService;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View("Index");
        }

        /// <summary>
        /// Views the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userId</exception>
        /// <exception cref="Exception">invalid Model state.</exception>
        public ActionResult ViewUser(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var returnModel = this.userService.GetUserInfo(userId);

            return this.PartialView("ViewUser", returnModel);
        }

        //-Users List -----
        /// <summary>
        /// Users the specified selected email.
        /// </summary>
        /// <param name="selectedEmail">The selected email.</param>
        /// <param name="selectedName">Name of the selected.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult User(string selectedEmail, string selectedName, string message)
        {
            
            var viewModel = adminService.GetUserListViewModel(selectedEmail, selectedName, message);

            return this.View("User", viewModel);
        }

        #region //----------------------------------------Company Methods----------------------------------//
        
        /// <summary>
        /// Companies the list.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CompanyList(string message)
        {
            //Get Company List View
            var viewModel = adminService.GetCompanyListViewModel(message);

            if (viewModel.CompanyCollection.Count < 1) return RedirectToAction("InitialCompanyRegistration");

            return this.View("CompanyList", viewModel);  
        }

        /// <summary>
        /// Initials the company registration.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult InitialCompanyRegistration()
        {

            //Get Company registration View
            var viewModel = this.adminService.GetRegisterCompanyViewModel();

            return View("InitialCompanyRegistration", "~/Views/PartialLogin/Shared/_PartialLayout.cshtml", viewModel);
        }

        /// <summary>
        /// Registers the company.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult RegisterCompany()
        {
            //Get Company registration View
            var viewModel = this.adminService.GetRegisterCompanyViewModel();

            return this.View("RegisterCompany", viewModel);
        }

        /// <summary>
        /// Registers the company.
        /// </summary>
        /// <param name="companyInfo">The company information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyInfo</exception>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult RegisterCompany(CompanyRegistrationView companyInfo, HttpPostedFileBase compLogo)
        {
            if (companyInfo == null)
            {
                throw new ArgumentNullException(nameof(companyInfo));
            }

            if (!ModelState.IsValid)
            {
                // call service to generate the View and return Back
                var viewModel = this.adminService.GetRegisterCompanyViewModel(companyInfo, string.Empty);

                // return view
                return this.View("RegisterCompany", viewModel);
            }

            //Register New Company
            var processingMessage = this.adminService.ProcessCompanyRegistrationInfo(companyInfo, compLogo);

            //Check If there is a Message from the Service
            if (!string.IsNullOrEmpty(processingMessage))
            {
                // call service to update parentCompany drop down list
                var viewModel = this.adminService.GetRegisterCompanyViewModel(companyInfo, processingMessage);

                // return the view
                return this.View("RegisterCompany", viewModel);
            }


            //New Company Successfully created
            var returnMessage = string.Format("{0} - Company Registered", companyInfo.CompanyName);

            //Redirect to company List
            return this.RedirectToAction("CompanyList", new { message = returnMessage });
        }

        /// <summary>
        /// Views the company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">companyId</exception>
        [HttpGet]
        public ActionResult ViewCompany(int companyId)
        { 
            //Show the detials of a selected Company
            if (companyId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(companyId));
            }

            //Get The View
            var viewModel = this.adminService.GetSelectedCompanyInfo(companyId);

            return PartialView("ViewCompany", viewModel);
        }

        /// <summary>
        /// Edits the company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">companyId</exception>
        [HttpGet]
        public ActionResult EditCompany(int companyId)
        {

            if (companyId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(companyId));
            }

            var viewModel = this.adminService.GetSelectedCompanyInfo(companyId);

            return PartialView("EditCompany", viewModel);
        }

        /// <summary>
        /// Edits the company.
        /// </summary>
        /// <param name="companyInfo">The company information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyInfo</exception>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult EditCompany(CompanyRegistrationView companyInfo, HttpPostedFileBase compLogo)
        {
            if (companyInfo == null)
            {
                throw new ArgumentNullException(nameof(companyInfo));
            }

            if (!ModelState.IsValid)
            {
                // call service to update the view
                var viewModel = this.adminService.GetRegisterCompanyViewModel(companyInfo, string.Empty);

                // return view
                return this.View("EditCompany", viewModel);
            }

            //Update Company Information
            var processingMessage = this.adminService.UpdateCompanyRegistrationInfo(companyInfo, compLogo);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                // If Error, Call service to generate an updated view
                var viewModel = this.adminService.GetRegisterCompanyViewModel(companyInfo, processingMessage);

                // return the view
                return this.View("EditCompany", viewModel);
            }


            //Successful Update
            var returnMessage = string.Format("{0} - Company Modified", companyInfo.CompanyName);

            //Redirect to company Lists
            return this.RedirectToAction("CompanyList", new { message = returnMessage });
        }

        /// <summary>
        /// Deletes the company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteCompany(int companyId)
        {
            var viewModel = adminService.GetSelectedCompanyInfo(companyId);

            return this.PartialView(viewModel);
        }

        /// <summary>
        /// Deletes the company.
        /// </summary>
        /// <param name="companyInfo">The company information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyInfo</exception>
        [HttpPost]
        public ActionResult DeleteCompany(CompanyRegistrationView companyInfo)
        {
            //Check that Grade Info is Not Null
            if (companyInfo == null)
            {
                throw new ArgumentNullException(nameof(companyInfo));
            }

            var returnModel = adminService.DeleteCompanyInfo(companyInfo);

            return this.RedirectToAction("CompanyList", "Administration", new { companyId = companyInfo.CompanyId });
        }

        /// <summary>
        /// Switches the company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyId</exception>
        public ActionResult SwitchCompany(int companyId)
        {
            if (companyId <= 0)
            {
                throw new ArgumentNullException(nameof(companyId));
            }

            var viewModel = this.accountService.SwitchCompanies(companyId);

            viewModel = string.Format("CompanySwitch Successful");

            return RedirectToAction("AdminDashboard", "Home", new { message = viewModel });
        }


        #endregion


        #region //---------------------------------Industry Section------------------------------//

        /// <summary>
        /// Industries the list.
        /// </summary>
        /// <param name="selectedIndustryName">Name of the selected industry.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult IndustryList(string selectedIndustryName, string message)
        {
            //Get Industry List View
            var viewModel = adminService.GetIndustryListViewModel(selectedIndustryName, message);

            return this.View("IndustryList", viewModel);
        }


        // GET: Industry/Create        
        /// <summary>
        /// Creates the industry.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateIndustry()
        {
            var viewModel = this.adminService.GetIndustryCreateView();

            return this.PartialView("CreateIndustry", viewModel);
        }

        // POST: Industry/Create        
        /// <summary>
        /// Creates the industry.
        /// </summary>
        /// <param name="industryInfo">The industry information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">industryInfo</exception>
        [HttpPost]
        public ActionResult CreateIndustry(IndustryView industryInfo)
        {

            if (industryInfo == null) { throw new ArgumentNullException(nameof(industryInfo)); }

            if (!ModelState.IsValid)
            {
                var viewModel = this.adminService.GetIndustryCreateView(industryInfo, "");
                return this.View("CreateIndustry", viewModel);
            }

            var processingMessage = adminService.ProcessIndustryCreateView(industryInfo);

            if (!string.IsNullOrEmpty(processingMessage))
            {
                var viewModel = this.adminService.GetIndustryCreateView(industryInfo, processingMessage);

                return this.View("CreateIndustry", viewModel);
            }

            return this.RedirectToAction("IndustryList", "Administration", new { message = "Industry Added" });
        }

        // GET: Industry/Edit/5        
        /// <summary>
        /// Edits the industry.
        /// </summary>
        /// <param name="industryId">The industry identifier.</param>
        /// <returns></returns>
        public ActionResult EditIndustry(int industryId)
        {
            var viewModel = this.adminService.GetIndustryEditView(industryId);

            return this.PartialView("EditIndustry", viewModel);
        }

        // POST: Industry/Edit/5        
        /// <summary>
        /// Edits the industry.
        /// </summary>
        /// <param name="industryInfo">The industry information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">industryInfo</exception>
        [HttpPost]
        public ActionResult EditIndustry(IndustryView industryInfo)
        {
            if (industryInfo == null)
            {
                throw new ArgumentNullException(nameof(industryInfo));
            }
            
            if (!ModelState.IsValid)
            {
                var viewModel = this.adminService.GetIndustryCreateView(industryInfo, "");

                return this.View("EditIndustry", viewModel);
            }
            
            var message = adminService.ProcessIndustryEditView(industryInfo);

            if (!string.IsNullOrEmpty(message))
            {
                var viewModel = this.adminService.GetIndustryCreateView(industryInfo, message);

                return this.View("EditIndustry", viewModel);
            }



            var returnMessage = string.Format("Selected Industry updated");

            return this.RedirectToAction("IndustryList", "Administration", new { message = returnMessage });
        }

        /// <summary>
        /// Deletes the industry.
        /// </summary>
        /// <param name="industryId">The industry identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteIndustry(int industryId)
        {
            var viewModel = adminService.GetIndustryEditView(industryId);

            return PartialView(viewModel);
        }

        /// <summary>
        /// Deletes the department.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteIndustry(int industryId, string btnSubmit)
        {
            if (industryId < 1)
            {
                throw new ArgumentOutOfRangeException("industryId");
            }

            var message = adminService.ProcessDeleteIndustryInfo(industryId);

            var returnMessage = string.Format("Selected Industry Deleted");

            return this.RedirectToAction("IndustryList", "Administration", new { message = returnMessage });
        }
        
        #endregion        

      
        public ActionResult Administrators()
        {
            return View("Index");
        }

        public ActionResult ActivityLog()
        {
            return View("Index");
        }

        public ActionResult EmailLog()
        {
            return View("Index");
        }

     


    }

}