using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Domain.Resources;
using AA.HRMS.Interfaces;
using AA.Infrastructure.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;

namespace AA.HRMS.Domain.Services
{

    public class UserService : IUserService

    {
        private readonly IUsersViewsModelFactory usersViewsModelFactory;
        private readonly IEmployeeViewModelFactory employeeViewModelFactory;
        private readonly ILookupRepository lookupRepository;
        private readonly IAccountRepository accountRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IEmailFactory emailFactory;
        private readonly IUsersRepository usersRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly ISessionStateService session;
        private readonly IDigitalFileRepository digitalFileRepository;

        
        public UserService(IUsersViewsModelFactory usersViewsModelFactory, ILookupRepository lookupRepository,
            IEmailFactory emailFactory, IUsersRepository usersRepository, ISessionStateService session,
            IEmployeeViewModelFactory employeeViewModelFactory, IEmployeeRepository employeeRepository,
            IAccountRepository accountRepository, ICompanyRepository companyRepository, IDigitalFileRepository digitalFileRepository)
        {
            this.usersViewsModelFactory = usersViewsModelFactory;
            this.usersViewsModelFactory = usersViewsModelFactory;
            this.employeeViewModelFactory = employeeViewModelFactory;
            this.lookupRepository = lookupRepository;
            this.emailFactory = emailFactory;
            this.usersRepository = usersRepository;
            this.employeeRepository = employeeRepository;
            this.accountRepository = accountRepository;
            this.session = session;
            this.companyRepository = companyRepository;
            this.digitalFileRepository = digitalFileRepository;
        }

        /// <summary>
        /// Gets the edit user view.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// userId
        /// or
        /// userInfo
        /// or
        /// companyList
        /// </exception>
        public IUserViewModel GetEditUserView(int userId)
        {
            if (userId < 0)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var userInfo = this.usersRepository.GetUserById(userId);

            if (userInfo == null)
            {
                throw new ArgumentNullException(nameof(userInfo));
            }

            var companyList = this.lookupRepository.GetCompanyCollection();

            if (companyList == null)
            {
                throw new ArgumentNullException(nameof(companyList));
            }

            var appRoleCollection = this.lookupRepository.GetAppRole();

            var returnModel = this.usersViewsModelFactory.CreateEditUserView(userInfo, companyList, appRoleCollection);

            return returnModel;
        }

        /// <summary>
        /// Gets the edit user view.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// user
        /// or
        /// companyList
        /// or
        /// appRoleCollection
        /// </exception>
        public IUserViewModel GetEditUserView(IUserViewModel user, string message)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var companyList = this.lookupRepository.GetCompanyCollection();

            if (companyList == null)
            {
                throw new ArgumentNullException(nameof(companyList));
            }

            var appRoleCollection = this.lookupRepository.GetAppRole();

            if (appRoleCollection == null)
            {
                throw new ArgumentNullException(nameof(appRoleCollection));
            }

            var returnView = this.usersViewsModelFactory.CreateEditUserView(user, companyList, appRoleCollection, message);

            return returnView;
        }

        /// <summary>
        /// Processes the edit user.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">users</exception>
        public string ProcessEditUser(IUserViewModel users)
        {

            if(users == null)
            {
                throw new ArgumentNullException(nameof(users));
            }

            var processingMessage = string.Empty;
            var isDataOkay = true;
            //validate User Entry
         
            //If user Data is not Valid
            if (!isDataOkay)
            {
                return processingMessage;
            }

            //Store User Information to database
            processingMessage = this.usersRepository.SaveEditUserInfo(users);

            return processingMessage;
        }

        /// <summary>
        /// Gets the user role view.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// userId
        /// or
        /// userInfo
        /// </exception>
        public IUsersView GetUserRoleViewList(int userId)
        {
            if (userId < 0)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var userInfo = this.usersRepository.GetUserById(userId);

            if (userInfo == null)
            {
                throw new ArgumentNullException(nameof(userInfo));
            }

            var userRoleList = this.lookupRepository.GetUserAppRoleByUsername(userInfo.Username);

            var appRoleCollection = this.lookupRepository.GetAppRole();

            var returnModel =
                this.usersViewsModelFactory.CreateUserRoleViewList(userInfo, userRoleList, appRoleCollection);

            return returnModel;
        }

        /// <summary>
        /// Gets the user role view.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userName</exception>
        public IUserAppRoleView GetUserRoleView(int userId)
        {
            if (userId < 0)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var loggedInUser = (string)this.session.GetSessionValue(SessionKey.UserName);

            var userInfo = this.usersRepository.GetUserById(userId);

            if (userInfo == null)
            {
                throw new ArgumentNullException(nameof(userInfo));
            }


            //Get The List of Available Roles
            var appRoleCollection = this.lookupRepository.GetAppRole();

            //Generate Factory
            var returnModel = this.usersViewsModelFactory.CreateUserRoleView(appRoleCollection, userInfo, loggedInUser);
            

            return returnModel;
        }

        /// <summary>
        /// Gets the edit create user role view.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// roleId
        /// or
        /// userName
        /// or
        /// userRole
        /// or
        /// appRoleCollection
        /// </exception>
        public IUserAppRoleView GetEditCreateUserRoleView(int roleId, string userName)
        {
            if (roleId < 0)
            {
                throw new ArgumentNullException(nameof(roleId));
            }

            if (userName == null)
            {
                throw new ArgumentNullException(nameof(userName));
            }

            var userRole = this.lookupRepository.GetuserAooRoleByRoleIdandUsername(userName, roleId);

            if (userRole == null)
            {
                throw new ArgumentNullException(nameof(userRole));
            }

            var appRoleCollection = this.lookupRepository.GetAppRole();

            if (appRoleCollection == null)
            {
                throw new ArgumentNullException(nameof(appRoleCollection));
            }

            var returnViewModel = this.usersViewsModelFactory.GetEditUserAppRoleView(userRole, appRoleCollection);

            return returnViewModel;
        }

        /// <summary>
        /// Gets the deleteuser role view.
        /// </summary>
        /// <param name="userRoleId">The user role identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userRoleId</exception>
        public IUserAppRoleView GetDeleteuserRoleView(int userAppRoleId)
        {
            if(userAppRoleId <= 0)
            {
                throw new ArgumentNullException(nameof(userAppRoleId));
            }

            var userAppRole = this.usersRepository.GetUserAppRoleByUserAppRoleId(userAppRoleId);

            var userInfo = this.accountRepository.GetUserByUsername(userAppRole.Username);
           

            var returnModel = this.usersViewsModelFactory.GetDeleteUserAppRoleView(userAppRole, userInfo.UserId);

            return returnModel;


        }

        /// <summary>
        /// Processes the edit user role information.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">users</exception>
        public string ProcessEditUserRoleInfo(IUserAppRoleView users)
        {
            if (users == null)
            {
                throw new ArgumentNullException(nameof(users));
            }

            var returnModel = this.usersRepository.SaveEditUserAppRole(users);

            return returnModel;
        }

        /// <summary>
        /// Gets the updated user view.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">users</exception>
        public IUserAppRoleView GetUpdatedUserRoleView(IUserAppRoleView users, string processingMessage)
        {
            if (users == null)
            {
                throw new ArgumentNullException(nameof(users));
            }

            var viewModel = this.usersViewsModelFactory.CreateUpdatedUserRoleView(users, processingMessage);

            return viewModel;
        }

        /// <summary>
        /// Processes the user application role.
        /// </summary>
        /// <param name="userView">The user view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userView</exception>
        public string ProcessUserAppRole(IUserAppRoleView userView)
        {
            if (userView == null)
            {
                throw new ArgumentNullException(nameof(userView));
            }

            userView.CreateByUsername = (string)session.GetSessionValue(SessionKey.UserName);

            //var userAppRoleCollection = this.lookupRepository.GetuserAooRoleByRoleIdandUsername(userView.Username, userView.AppRoleId);

            //    if(userView.AppRoleId == userAppRoleCollection.AppRoleId)
            //    {
            //        userView.ProcessingMessage = Messages.UsernameExist;
            //    }


            var viewModel = this.usersRepository.SaveUserAppRole(userView);

            return viewModel;
        }

        /// <summary>
        /// Gets the user registration view.
        /// </summary>
        /// <returns>
        /// IUsersView.
        /// </returns>
        public IUsersView GetUserRegistrationView()
        {
            // go to users view factory to create the view factory
            var viewModel = this.usersViewsModelFactory.CreateUserRegistrationView();

            //Return generated view factory
            return viewModel;
        }

        /// <summary>
        /// Processes the delete user role information.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userName</exception>
        public string ProcessDeleteUserRoleInfo(int userAppRole)
        {
            if (userAppRole <= 0)
            {
                throw new ArgumentNullException(nameof(userAppRole));
            }

            var returnModel = this.usersRepository.SaveDeleteUserAppRole(userAppRole);

            return returnModel;
        }

        /// <summary>
        /// Processes the user registration view.
        /// </summary>
        /// <param name="userRegistrationInfo">The user registration information.</param>
        /// <returns>
        /// IUsersView.
        /// </returns>
        /// <exception cref="ArgumentNullException">userRegistrationInfo</exception>
        public IUsersView ProcessUserRegistrationInfo(IUsersView userRegistrationInfo)
        {
            if (userRegistrationInfo == null)
            {
                throw new ArgumentNullException(nameof(userRegistrationInfo));
            }

            var processingMessage = string.Empty;
            var isDataOkay = true;
            //validate User Entry


            //1. Validate Email

            var userData = this.usersRepository.GetUserByEmail(userRegistrationInfo.Email);
            var isRecordExist =
                (userData == null) ? false : true; // Returns false if no record is found and true if a record is found
            if (isRecordExist)
            {
                processingMessage = Messages.EmailAlreadyUsedText;

                processingMessage = !userData.IsUserVerified
                    ? Messages.ConfirmRegistrationText
                    : ""; // email used and account not confirmed by user

                isDataOkay = false;
            }


            //Get Updated ViewModel
            var returnViewModel =
                this.usersViewsModelFactory.CreateUpdatedUserView(userRegistrationInfo, processingMessage);

            //If user Data is not Valid
            if (!isDataOkay)
            {
                return returnViewModel;
            }


            var userId = 0;

            //save to database

            //Assign Applicant Role to the Newly Registered User
            //: Set User Role Here
            userRegistrationInfo.Role = 1;

            //Store User Information to database
            var registrationData = this.usersRepository.SaveUserRegistrationInfo(userRegistrationInfo, out userId);


            //Store User Information to Employee Table
            //NOTE : Company Administrator is registered here and Company Administrator is also and Employee in the Company
            var employeeInfo =
                employeeViewModelFactory.GenerateEmployeeDetailsFromRegistrationView(userRegistrationInfo);


            //send Mail to User

            //1. generate Email Details
            var registrationRequestEmail =
                this.emailFactory.CreateUserRegistrationRequestEmail(userRegistrationInfo, userId);


            //2. Send Email to User
            var sendMail = this.usersRepository.SendEmail(registrationRequestEmail);

            //Goto Company Registration After a Successfully Registration
            returnViewModel =
                this.usersViewsModelFactory.CreateUpdatedUserView(userRegistrationInfo, processingMessage);

            return returnViewModel;
        }

        /// <summary>
        /// Gets the updated user view.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">users</exception>
        public IUsersView GetUpdatedUserView(IUsersView users, string processingMessage)
        {
            if (users == null)
            {
                throw new ArgumentNullException(nameof(users));
            }

            var viewModel = this.usersViewsModelFactory.CreateUpdatedUserView(users, processingMessage);

            return viewModel;
        }


        //Get User Information by Id        
        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userId</exception>
        public IUsersView GetUserInfo(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            //Get User Information from the user Table
            var user = this.accountRepository.GetUserByUserId(userId);

            var viewModel = this.usersViewsModelFactory.UserInformationModel(user);

            return viewModel;
        }

        /// <summary>
        /// Gets the content of the header.
        /// </summary>
        /// <returns></returns>
        public IHeaderViewModel GetHeaderContent()
        {

            var userDetail = this.usersRepository.GetUserById((int)this.session.GetSessionValue(SessionKey.UserId));

            var companyDetail = this.companyRepository.GetCompanyById(userDetail.CompanyId);

            var companyLogo = this.digitalFileRepository.GetDigitalFileDetail(companyDetail.LogoDigitalFileId ?? 0);

            var returnModel = this.usersViewsModelFactory.CreateHeaderView(userDetail, companyDetail, companyLogo);

            return returnModel;
        }
    }
}