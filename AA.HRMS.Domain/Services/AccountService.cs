using AA.HRMS.Domain.Models;
using AA.HRMS.Domain.Resources;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.Models;
using AA.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using Environment = AA.Infrastructure.Utility.Environment;

namespace AA.HRMS.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountViewsModelFactory accountViewsModelFactory;
        private readonly IEmailFactory emailFactory;
        private readonly IUserProfileModelFactory userProfileModelFactory;
        private readonly IUsersRepository usersRepository;
        private readonly IEmployeeOnBoardRepository employeeOnBoardRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly ILookupRepository lookupRepository;
        private readonly IAccountRepository accountRepository;
        private readonly IProfileRepository profileRepository;
        private readonly IEducationHistoryRepository educationHistoryRepository;
        private readonly IEmploymentHistoryRepository employmentHistoryRepository;
        private readonly ISkillSetRepository skillSetRepository;
        private readonly IDigitalFileRepository digitalFileRepository;
        private readonly IFormsAuthenticationService formsAuthentication;
        private readonly ISessionStateService session;
        private readonly IAesEncryption encryptionService;
        private readonly ICompanyRepository companyRepository;
        private readonly IEmail email;
        private readonly IEnvironment environment;

        public AccountService(IAccountViewsModelFactory accountViewsModelFactory, IEmailFactory emailFactory,
            ILookupRepository lookupRepository, IAccountRepository accountRepository,
            IFormsAuthenticationService formsAuthentication, IEmployeeOnBoardRepository employeeOnBoardRepository,
            ISessionStateService session, IProfileRepository profileRepository, IEnvironment environment,
            IEmploymentHistoryRepository employmentHistoryRepository, ICompanyRepository companyRepository,
            IEducationHistoryRepository educationHistoryRepository, IUserProfileModelFactory userProfileModelFactory,
            ISkillSetRepository skillSetRepository, IDigitalFileRepository digitalFileRepository, IEmail email,
            IUsersRepository usersRepository, IAesEncryption encryptionService,IEmployeeRepository employeeRepository)
        {
            this.accountViewsModelFactory = accountViewsModelFactory;
            this.userProfileModelFactory = userProfileModelFactory;
            this.employeeRepository=employeeRepository;
            this.employeeOnBoardRepository = employeeOnBoardRepository;
            this.lookupRepository = lookupRepository;
            this.accountRepository = accountRepository;
            this.profileRepository = profileRepository;
            this.educationHistoryRepository = educationHistoryRepository;
            this.employmentHistoryRepository = employmentHistoryRepository;
            this.skillSetRepository = skillSetRepository;
            this.digitalFileRepository = digitalFileRepository;
            this.usersRepository = usersRepository;
            this.emailFactory = emailFactory;
            this.formsAuthentication = formsAuthentication;
            this.session = session;
            this.encryptionService = encryptionService;
            this.companyRepository = companyRepository;
            this.environment = environment;
            this.email = email;
        }


        /// <summary>
        /// Gets the user profile.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IUserProfileView GetUserProfile(string message)
        {

            //Get User Information from the user Table
            var user = this.accountRepository.GetUserByUserId((int) session.GetSessionValue(SessionKey.UserId));

            var employee = this.employeeOnBoardRepository.GetEmployeeByEmail(user.Email);



            //Get User Profile From The Profile Table
            var profile = this.profileRepository.GetProfileByUserId(user.UserId);

            if (profile == null)
            {
                return null;
            }

            if (employee != null)
            {
                //Get  A List of Employement Histories
                var employmentHistoriesE = this.employmentHistoryRepository.GetEmploymentHistoriesByUserId(employee.EmployeeId);

                // Get A List of Education Histories
                var educationHistoriesE = this.educationHistoryRepository.GetEducationHistoriesByUserId(employee.EmployeeId);

                //Get List of Skill SET
                var skillSetsE = this.skillSetRepository.GetSkillSetByUserId(employee.EmployeeId);

                //Get profilePictureDetail
                var profilePictureDetailE = this.digitalFileRepository.GetDigitalFileDetail(profile.PictureDigitalFileId);

                var spouse = this.employeeRepository.GetSpouseInfoById(employee.EmployeeId);

                var emergency = this.lookupRepository.GetEmployeeEmergencyContactById(employee.EmployeeId);

                var children = this.lookupRepository.GetChildrenInformationListById(employee.EmployeeId);

                var nextOfKin = this.lookupRepository.GetNextOfKinListById(employee.EmployeeId);

                var beneficiary = this.lookupRepository.GetBeneficiariesListById(employee.EmployeeId);
                //var get CV
                var applicantCVE = this.digitalFileRepository.GetDigitalFileDetail(profile.CVDigitalFileId);


                //Create The user Profile View From Factory
                var viewModel = this.userProfileModelFactory.CreateUserProfileView(user, profile, educationHistoriesE,
                    employmentHistoriesE, spouse, skillSetsE, profilePictureDetailE, applicantCVE, emergency, children, beneficiary, nextOfKin, message);

                return viewModel;
            }

            //Get  A List of Employement Histories
            var employmentHistories = this.employmentHistoryRepository.GetEmploymentHistoriesByUserId(user.UserId);

            // Get A List of Education Histories
            var educationHistories = this.educationHistoryRepository.GetEducationHistoriesByUserId(user.UserId);

            //Get List of Skill SET
            var skillSets = this.skillSetRepository.GetSkillSetByUserId(user.UserId);

            //Get profilePictureDetail
            var profilePictureDetail = this.digitalFileRepository.GetDigitalFileDetail(profile.PictureDigitalFileId);

            var spousE = this.employeeRepository.GetSpouseInfoById(user.UserId);

            var emergencY = this.lookupRepository.GetEmployeeEmergencyContactById(user.UserId);

            var childreN = this.lookupRepository.GetChildrenInformationListById(user.UserId);

            var nextOfKiN = this.lookupRepository.GetNextOfKinListById(user.UserId);

            var beneficiarY = this.lookupRepository.GetBeneficiariesListById(user.UserId);

            //var get CV
            var applicantCV = this.digitalFileRepository.GetDigitalFileDetail(profile.CVDigitalFileId);


            //Create The user Profile View From Factory
            var returnViewModel = this.userProfileModelFactory.CreateUserProfileView(user, profile, educationHistories,
                employmentHistories, spousE, skillSets, profilePictureDetail, applicantCV, emergencY, childreN, beneficiarY, nextOfKiN, message);

            return returnViewModel;
        }
        
        #region Registration Section

        /// <summary>
        /// Gets the registration view.
        /// </summary>
        /// <param name="selectedRole">The selected role.</param>
        /// <returns></returns>
        public IRegistrationView GetRegistrationView(string selectedRole)
        {
            // about us source records from database
            var aboutUsSourceCollection = this.lookupRepository.GetAboutUsSourceCollection().ToList();
            
            var viewModel = this.accountViewsModelFactory.CreateRegistrationView(aboutUsSourceCollection, selectedRole);
            
            return viewModel;
        }
        
        /// <summary>
        /// Processes the registration information.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">registrationInfo</exception>
        public IRegistrationView ProcessRegistrationInfo(IRegistrationView registrationInfo)
        {
            if (registrationInfo == null)
            {
                throw new System.ArgumentNullException(nameof(registrationInfo));
            }

            var processingMessage = string.Empty;
            var isDataOkay = true;

            // validate entries
            // 1) check userId does not exist in RegisterTable
            var registrationData = this.accountRepository.GetRegistrationByUsername(registrationInfo.Username);
            var isRecordExist = (registrationData == null) ? false : true;
            if (isRecordExist)
            {
                processingMessage = Messages.UserAlreadyExistText;
                isDataOkay = false;
            }

            // 2) check that email not used if no error so far
            if (isDataOkay)
            {
                registrationData = this.accountRepository.GetRegistrationByEmail(registrationInfo.Email);
                isRecordExist = (registrationData == null) ? false : true; // checks if registration already exist
                isDataOkay =
                    isRecordExist
                        ? false
                        : true; // implies registration info already exists and registration can not go through


                // set processing message 
                if (isRecordExist)
                {
                    processingMessage =
                        isRecordExist ? Messages.EmailAlreadyUsedText : ""; // email already used for registration

                    if (registrationData.IsRegistered)
                    {

                        processingMessage = (isRecordExist && registrationData.IsRegistered)
                            ? Messages.ConfirmRegistrationText
                            : ""; // email used and registration not confirmed by user
                    }
                }

            }

            // get updated view model to be returned to controller 
            var aboutUsSourceCollection = this.lookupRepository.GetAboutUsSourceCollection().ToList();
            var returnViewModel =
                this.accountViewsModelFactory.CreateUpdatedRegistraionView(registrationInfo, processingMessage,
                    aboutUsSourceCollection);

            if (!isDataOkay)
            {
                returnViewModel.ProcessingMessage = processingMessage;
                return returnViewModel;
            }

            //save data to database
            var userId = 0;

            // encrypt password here
            registrationInfo.Password = this.encryptionService.Encrypt(registrationInfo.Password);

            var IsEmployee = this.employeeOnBoardRepository.GetEmployeeByEmail(registrationInfo.Email) == null ? false: true ;

            if(registrationInfo.SelectedRole == "Employee" && IsEmployee == false)
            {
                processingMessage = Messages.NoEmployeeRecord;

                returnViewModel.ProcessingMessage = processingMessage;

                return returnViewModel;

            }

            if (IsEmployee && registrationInfo.SelectedRole == "Employee")
            {
                var employee = this.employeeOnBoardRepository.GetEmployeeByEmail(registrationInfo.Email);
                registrationInfo.FirstName = employee.FirstName;
                registrationInfo.LastName = employee.LastName;
                registrationInfo.PhoneNumber = employee.MobileNumber;
                registrationInfo.AboutUsOthers = "Bought by my company";
                registrationInfo.CompanyId = employee.CompanyId;
            }
            

            var savedData = this.accountRepository.SaveUserInfo(registrationInfo, out userId);

            //: Create User App Role
            this.accountRepository.CreateUserRole(registrationInfo);


            //Generate Activation Code
            string activationCode =
                String.Format("{0}{1}", userId, this.usersRepository.CreateActivationCode());
            this.accountRepository.StoreActivationCode(userId, activationCode);

            // generate email details
            var registrationRequestEmail =
                emailFactory.CreateRegistrationRequestEmail(registrationInfo, userId, activationCode);

            var emailKey = this.environment[EnvironmentValues.EmailKey];

            // send email to user including token or unique id for registration confirmation
            this.email.Send(emailKey, "aahrms.automataapps.com", "AA HRMS Team", registrationRequestEmail.Subject, registrationRequestEmail.Recipients, registrationInfo.LastName + " " + registrationInfo.FirstName, string.Empty, registrationRequestEmail.Body);

            return returnViewModel;
        }
        
        /// <summary>
        /// Gets the registration view.
        /// </summary>
        /// <param name="registrationData">The registration data.</param>
        /// <returns></returns>
        public IRegistrationView GetRegistrationView(IRegistrationView registrationData)
        {
            // about us source records from database
            var aboutUsSourceCollection = this.lookupRepository.GetAboutUsSourceCollection().ToList();

            // send it to accounts view factory to create the view factory
            var viewModel =
                this.accountViewsModelFactory.CreateUpdatedRegistraionView(registrationData, "",
                    aboutUsSourceCollection);

            // return the view to controller
            return viewModel;
        }
        
        /// <summary>
        /// Activates the account.
        /// </summary>
        /// <param name="activationCode">The activation code.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">activationCode</exception>
        public string ActivateAccount(string activationCode)
        {
            if (activationCode == null)
            {
                throw new ArgumentNullException(nameof(activationCode));
            }

            bool isDataOkay = true;
            string message = String.Empty;
            
            //Check For the Generated Activation Code to Activate
            var userActivation = accountRepository.GetActivationCode(activationCode);
            if (userActivation == null) //ACtivation Code Does Not Exist
            {
                isDataOkay = false;
                message = Messages.InvalidActivationCode;
            }
            else if (userActivation.IsUsed) //This Activation Code is Previously Used
            {
                isDataOkay = false;
                message = Messages.InvalidActivationCode;
            }

            //TODO: Check For Expired Activation Codes too Here

            if (isDataOkay)
            {
                //Update The Activation Code Table to Use The Current Activation Code
                this.accountRepository.UpdateActviationCode(userActivation.UserActivationCodeId);

                //Update User Account As Verified
                this.accountRepository.UpdateUserRecord(userActivation.UserId);
            }


            // return to the View As Well

            return message;
        }
        
        /// <summary>
        /// Generates the activation view.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public IUserActivationCode GenerateActivationView(string message)
        {
            return accountViewsModelFactory.GenerateActivationView(message);
        }

        #endregion

        #region Login/Logooff
        
        /// <summary>
        /// Gets the autthenication page.
        /// </summary>
        /// <returns></returns>
        public IHomeView GetAutthenicationPage(string message)
        {

            var LogOn = GetLogOnView("", "", "");
            var Register = GetRegistrationView(message);
            var ForgetPassword = GetChangePassword();

            var viewModel = this.accountViewsModelFactory.CreateAuthenticationPage(Register, LogOn, ForgetPassword, message);

            return viewModel;
        }

        /// <summary>
        /// Gets the log on model.
        /// </summary>
        /// <param name="infoMessage">The information message.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public ILogOnView GetLogOnView(string infoMessage = "", string errorMessage = "", string userName = "",
            string returnUrl = "")
        {
            var logOnView =
                this.accountViewsModelFactory.CreateLogOnView(infoMessage, errorMessage, userName, returnUrl);

            return logOnView;
        }

        /// <summary>
        /// Signs the in.
        /// </summary>
        /// <param name="logonModel">The logon model.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">logonModel</exception>
        public bool SignIn(ILogOnView logonModel)
        {
            if (logonModel == null)
            {
                throw new ArgumentNullException("logonModel");
            }

            var userInfo = this.accountRepository.GetUserByUsername(logonModel.UserName);

            if (userInfo == null)
            {
                userInfo = this.accountRepository.GetUserByEmail(logonModel.UserName);
            }


            if (userInfo == null || (userInfo.IsLocked ?? false))
            {
                return false;
            }

            var companyInfo = this.companyRepository.GetCompanyById(userInfo.CompanyId);

            var employeeInfo = this.employeeOnBoardRepository.GetEmployeeByEmail(userInfo.Email);

            var profileInfo = this.profileRepository.GetProfileByUserId(userInfo.UserId);


            var encriptedPwd =
                this.encryptionService.Encrypt(logonModel
                    .Password); // for debugging....you dont get the same result when encrypting

            var decryptedValue = this.encryptionService.Decrypt(userInfo.Password);

            //:todo compare encripted or decripted password here 
            if (!logonModel.Password.Equals(decryptedValue))
                //if (!logonModel.Password.Equals(userInfo.Password))
            {
                return false;
            }


            //
            var userActionList = this.accountRepository.GetUserRoleActions(userInfo.Username).ToList();
            if (!userActionList.Any())
            {
                userActionList = new List<string>();
            }

            session.AddValueToSession(SessionKey.UserRoles, userActionList.ToArray());
            session.AddValueToSession(SessionKey.UserId, userInfo.UserId);
            session.AddValueToSession(SessionKey.UserName, logonModel.UserName);
            session.AddValueToSession(SessionKey.FullUserName, userInfo.FirstName + " " + userInfo.LastName);
            session.AddValueToSession(SessionKey.UserIsAuthenticated, true);
            session.AddValueToSession(SessionKey.CompanyId, 0);

            IDigitalFile profilePicture = null;

            if (employeeInfo != null)
            {
                session.AddValueToSession(SessionKey.EmployeeId, employeeInfo.EmployeeId);
                session.AddValueToSession(SessionKey.CompanyId, employeeInfo.CompanyId);
                if (employeeInfo != null)
                {
                    profilePicture = this.digitalFileRepository.GetDigitalFileDetail(employeeInfo.PhotoDigitalFileId ?? 0);
                }
            }
            
            if(profileInfo != null)
            {
                session.AddValueToSession(SessionKey.ProfileId, profileInfo.ProfileId);

                profilePicture = this.digitalFileRepository.GetDigitalFileDetail(profileInfo.PictureDigitalFileId);
                
            }

            
            if (profilePicture != null)
            {

                var imgSrc = "";
                var base64 = Convert.ToBase64String(profilePicture.TheDigitalFile);
                imgSrc = string.Format("data:{0};base64,{1}", profilePicture.ContentType, base64);
                session.AddValueToSession(SessionKey.ProfilePicture, imgSrc);
            }


            if (companyInfo != null)
            {
                var companyLogo = this.digitalFileRepository.GetDigitalFileDetail(companyInfo.LogoDigitalFileId ?? -1);

                var imgSrc = companyInfo.CompanyName;

                if (companyLogo != null)
                {
                    var base64 = Convert.ToBase64String(companyLogo.TheDigitalFile);
                    imgSrc = string.Format("data:{0};base64,{1}", companyLogo.ContentType, base64);
                }

                session.AddValueToSession(SessionKey.CompanyLogo, imgSrc);

                session.AddValueToSession(SessionKey.CompanyId, companyInfo.CompanyId);
            }
            
            this.formsAuthentication.SignIn(logonModel.UserName, logonModel.RememberMe);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ICompanyListView GetMyCompanies(string message)
        {

            var loggedInUserInfo = this.usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));

            var companyCollection = this.companyRepository.GetMyCompanies(loggedInUserInfo.CompanyId);

            foreach (var company in companyCollection)
            {
                company.CompanyLogo = this.digitalFileRepository.GetDigitalFileDetail(company.LogoDigitalFileId ?? 0);
            }

            var viewModel = this.accountViewsModelFactory.GetMyCompanyies(companyCollection, message);

            return viewModel;
        }

        /// <summary>
        /// Switches the companies.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// companyId
        /// or
        /// companyInfo
        /// </exception>
        public string SwitchCompanies(int companyId)
        {
            if (companyId <= 0)
            {
                throw new ArgumentNullException("companyId");
            }

            var companyInfo = this.companyRepository.GetCompanyById(companyId);

            if (companyInfo == null)
            {
                throw new ArgumentNullException(nameof(companyInfo));
            }

            if (companyInfo != null)
            {
                var companyLogo = this.digitalFileRepository.GetDigitalFileDetail(companyInfo.LogoDigitalFileId ?? -1);

                var imgSrc = companyInfo.CompanyName;

                if (companyLogo != null)
                {
                    var base64 = Convert.ToBase64String(companyLogo.TheDigitalFile);
                    imgSrc = string.Format("data:{0};base64,{1}", companyLogo.ContentType, base64);
                }
                session.AddValueToSession(SessionKey.CompanyId, companyId);
                session.AddValueToSession(SessionKey.CompanyLogo, imgSrc);
            }


            return string.Empty;
        }
        
        /// <summary>
        /// Signs the off.
        /// </summary>
        public void SignOff()
        {
            session.RemoveSessionValue(SessionKey.UserRoles);
            session.RemoveSessionValue(SessionKey.UserId);
            session.RemoveSessionValue(SessionKey.UserName);
            session.RemoveSessionValue(SessionKey.UserIsAuthenticated);
            session.RemoveSessionValue(SessionKey.FullUserName);
            session.RemoveSessionValue(SessionKey.CompanyId);
            session.RemoveSessionValue(SessionKey.CompanyLogo);
            session.RemoveSessionValue(SessionKey.EmployeeId);
            session.RemoveSessionValue(SessionKey.ProfileId);
            session.RemoveSessionValue(SessionKey.ProfilePicture);

            var userName = (session.GetSessionValue(SessionKey.UserName) ?? "").ToString();
            this.formsAuthentication.SignOut(userName);
        }


        #endregion
        
        #region Change Password Section

        /// <summary>
        /// Gets the change password.
        /// </summary>
        /// <returns></returns>
        public IChangePasswordView GetChangePassword()
        {
            return accountViewsModelFactory.CreateChangePasswordView();
        }

        /// <summary>
        /// Gets the change password.
        /// </summary>
        /// <param name="changePassword">The change password.</param>
        /// <returns></returns>
        public IChangePasswordView GetChangePassword(IChangePasswordView changePassword, string message)
        {
            return accountViewsModelFactory.CreateChangePasswordView(changePassword, message);
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public IChangePasswordView ChangePassword(string Email)
        {
            var model = usersRepository.GetUserByEmail(Email);

            string message;


            var change = new ChangePasswordModel();

            if (model != null)
            {
                string code = Guid.NewGuid().ToString("N").Substring(0, 10);
                change.Code = code;
                change.Email = Email;
                change.Date = DateTime.Now;
                string res = accountRepository.SaveChangePasswordDetails(change);

                var user = this.usersRepository.GetUserByEmail(Email);

                user.IsResetPassword = true;
                usersRepository.PasswordReset(user);


                try
                {

                    MailMessage mail = new MailMessage("hartpraise@gmail.com", Email);
                    SmtpClient client = new SmtpClient();
                    client.Port = 25;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Host = "smtp.gmail.com";
                    mail.Subject = "Change Password";
                    mail.Body = "Click the following link to change your password <a href='http://localhost:54724/Account/ChangePasswordPage?+code'> click me </a>";
                    client.Send(mail);
                    message = "email is sent to " + Email + ", check your mail to continue.";

                }
                catch
                {
                    message = "Error!! Email not sent";
                }


            }
            else
            {
                message = "Invalid email";
            }

            return accountViewsModelFactory.CreateChangePasswordView(message);
        }

        /// <summary>
        /// Gets the change password page.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public IChangePasswordView GetChangePasswordPage(string code)
        {
            var message = string.Empty;

            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException(nameof(code));
            }

            var changePassword = accountRepository.GetChangePasswordByCode(code);

            if (changePassword == null)
            {
                throw new ArgumentNullException(nameof(changePassword));
            }

            return accountViewsModelFactory.CreateChangePasswordPageView(changePassword, code);
        }

        /// <summary>
        /// Gets the change password page.
        /// </summary>
        /// <param name="changePasswordView">The change password view.</param>
        /// <param name="messagee">The messagee.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">changePasswordView</exception>
        public IChangePasswordView GetChangePasswordPage(IChangePasswordView changePasswordView, string messagee)
        {

            if (changePasswordView == null)
            {
                throw new ArgumentNullException(nameof(changePasswordView));
            }

            return accountViewsModelFactory.CreateChangePasswordPageView(changePasswordView, messagee);
        }
        
        /// <summary>
        /// Gets the change password page.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <param name="NewPassword">The new password.</param>
        /// <param name="ConfirmNewPassword">The confirm new password.</param>
        /// <returns></returns>
        public string ProcessChangePasswordPage(IChangePasswordView changePasswordView)
        {
            string message;

            bool isDataOkay = false;

            if (changePasswordView == null)
            {
                throw new ArgumentNullException(nameof(changePasswordView));
            }

            isDataOkay = (this.accountRepository.GetChangePasswordByCode(changePasswordView.Code) == null) ? false : true;

            if (!isDataOkay)
            {
                message = Messages.EmailDoesNotExist;

                return message;
            }

            changePasswordView.NewPassword = this.encryptionService.Encrypt(changePasswordView.NewPassword);

            message = this.accountRepository.SaveChangePassword(changePasswordView);

            return message;
        }

        #endregion


    }
}