using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;
using AA.HRMS.Domain.Utilities;

namespace AA.HRMS.Domain.Factories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IUsersViewsModelFactory" />
    public class UsersViewsModelFactory : IUsersViewsModelFactory
    {
        /// <summary>
        /// Gets the edit user application role view.
        /// </summary>
        /// <param name="userAppRole">The user application role.</param>
        /// <param name="roleCollection">The role collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// userAppRole
        /// or
        /// roleCollection
        /// </exception>
        public IUserAppRoleView GetEditUserAppRoleView(IUserAppRole userAppRole, IList<IAppRole> roleCollection)
        {
            var appRoleName = string.Empty;

            if (userAppRole == null)
            {
                throw new ArgumentNullException(nameof(userAppRole));
            }

            if (roleCollection == null)
            {
                throw new ArgumentNullException(nameof(roleCollection));
            }

            var appRoleDropDown = GetDropDownList.AppRoleListItems(roleCollection, userAppRole.AppRoleId);

            foreach (var item in roleCollection)
            {
                if (item.AppRoleId == userAppRole.AppRoleId)
                {
                    appRoleName = item.Action;
                }
            }

            var result = new UserAppRoleView
            {
                AppRoleId = userAppRole.AppRoleId,
                Username = userAppRole.Username,
                CreateByUsername = userAppRole.CreateByUsername,
                DateCreated = userAppRole.DateCreated,
                AppRoleCollection = appRoleDropDown,
                AppRoleName = appRoleName
            };

            return result;
        }

        /// <summary>
        /// Gets the delete user application role view.
        /// </summary>
        /// <param name="userAppRole">The user application role.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userAppRole</exception>
        public IUserAppRoleView GetDeleteUserAppRoleView(IUserAppRole userAppRole, int userId)
        {
            if (userAppRole == null)
            {
                throw new ArgumentNullException(nameof(userAppRole));
            }
            

            var result = new UserAppRoleView
            {
                AppRoleId = userAppRole.AppRoleId,
                Username = userAppRole.Username,
                CreateByUsername = userAppRole.CreateByUsername,
                DateCreated = userAppRole.DateCreated,
                AppRoleName = userAppRole.RoleName,
                UserAppRoleId = userAppRole.UserAppRoleId,
                UserId = userId
                
            };

            return result;
        }

        /// <summary>
        /// Creates the user registration view.
        /// </summary>
        /// <returns>
        /// IUsersView.
        /// </returns>
        public IUsersView CreateUserRegistrationView()
        {
            var view = new UsersView { };

            return view;
        }

        /// <summary>
        /// Creates the updated user view.
        /// </summary>
        /// <param name="userRegistrationInfo">The user registration information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userRegistrationInfo</exception>
        public IUsersView CreateUpdatedUserView(IUsersView userRegistrationInfo, string processingMessage)
        {
            if (userRegistrationInfo == null)
            {
                throw new ArgumentNullException(nameof(userRegistrationInfo));
            }


            userRegistrationInfo.ProcessingMessage = processingMessage;


            return userRegistrationInfo;
        }

        /// <summary>
        /// Creates the edit user view.
        /// </summary>
        /// <param name="userDetail">The user detail.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="appRoleCollection">The application role collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// userDetail
        /// or
        /// companyCollection
        /// or
        /// appRoleCollection
        /// </exception>
        public IUserViewModel CreateEditUserView(IUserDetail userDetail, IList<ICompanyDetail> companyCollection,
            IList<IAppRole> appRoleCollection)
        {
            if (userDetail == null)
            {
                throw new ArgumentNullException(nameof(userDetail));
            }

            if (companyCollection == null)
            {
                throw new ArgumentNullException(nameof(companyCollection));
            }

            if (appRoleCollection == null)
            {
                throw new ArgumentNullException(nameof(appRoleCollection));
            }

            var companyDropDown = GetDropDownList.CompanyListItems(companyCollection, -1);

            var appRoleDropDown = GetDropDownList.AppRoleListItems(appRoleCollection, -1);


            var returnView = new UserViewModel
            {
                UserId = userDetail.UserId,
                Username = userDetail.Username,
                IsUserVerified = userDetail.IsUserVerified,
                FirstName = userDetail.FirstName,
                LastName = userDetail.LastName,
                Email = userDetail.Email,
                CompanyDropDown = companyDropDown,
                RoleDropDown = appRoleDropDown
            };

            return returnView;
        }

        /// <summary>
        /// Creates the edit user view.
        /// </summary>
        /// <param name="userDetail">The user detail.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="appRoleCollection">The application role collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// userDetail
        /// or
        /// companyCollection
        /// or
        /// appRoleCollection
        /// </exception>
        public IUserViewModel CreateEditUserView(IUserViewModel userDetail, IList<ICompanyDetail> companyCollection,
           IList<IAppRole> appRoleCollection, string processingMessage)
        {
            if (userDetail == null)
            {
                throw new ArgumentNullException(nameof(userDetail));
            }

            if (companyCollection == null)
            {
                throw new ArgumentNullException(nameof(companyCollection));
            }

            if (appRoleCollection == null)
            {
                throw new ArgumentNullException(nameof(appRoleCollection));
            }

            var companyDropDown = GetDropDownList.CompanyListItems(companyCollection, -1);

            var appRoleDropDown = GetDropDownList.AppRoleListItems(appRoleCollection, -1);

            userDetail.CompanyDropDown = companyDropDown;
            userDetail.RoleDropDown = appRoleDropDown;
            userDetail.ProcessingMessage = processingMessage;

            return userDetail;
        }

        /// <summary>
        /// Creates the user role view.
        /// </summary>
        /// <param name="appRoleCollection">The application role collection.</param>
        /// <param name="userDetail">The user detail.</param>
        /// <param name="loggedInUsername">The logged in username.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">appRoleCollection</exception>
        public IUserAppRoleView CreateUserRoleView(IList<IAppRole> appRoleCollection, IUserDetail userDetail, string loggedInUsername)
        {
            if (appRoleCollection == null)
            {
                throw new ArgumentNullException(nameof(appRoleCollection));
            }

            var appRoleDropDown = GetDropDownList.AppRoleListItems(appRoleCollection, -1);


            var returnView = new UserAppRoleView
            {
                AppRoleCollection = appRoleDropDown,
                Username = userDetail.Username,
                UserId = userDetail.UserId,
                CreateByUsername = loggedInUsername
            };

            return returnView;
        }

        /// <summary>
        /// Creates the user role view.
        /// </summary>
        /// <param name="userDetail">The user detail.</param>
        /// <param name="userAppCollection">The user application collection.</param>
        /// <param name="appRoleCollection">The application role collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// userDetail
        /// or
        /// userAppCollection
        /// or
        /// appRoleCollection
        /// </exception>
        public IUsersView CreateUserRoleViewList(IUserDetail userDetail, IList<IUserAppRole> userAppCollection,
            IList<IAppRole> appRoleCollection)
        {
            if (userDetail == null)
            {
                throw new ArgumentNullException(nameof(userDetail));
            }

            if (userAppCollection == null)
            {
                throw new ArgumentNullException(nameof(userAppCollection));
            }

            if (appRoleCollection == null)
            {
                throw new ArgumentNullException(nameof(appRoleCollection));
            }

            var appRoleDropDown = GetDropDownList.AppRoleListItems(appRoleCollection, -1);


            var returnView = new UsersView
            {
                UserId = userDetail.UserId,
                Username = userDetail.Username,
                IsUserVerified = userDetail.IsUserVerified,
                FirstName = userDetail.FirstName,
                LastName = userDetail.LastName,
                Email = userDetail.Email,
                AppRoleCollection = userAppCollection,
                RoleDropDown = appRoleDropDown
            };

            return returnView;
        }

        /// <summary>
        /// Creates the updated user role view.
        /// </summary>
        /// <param name="usersView">The users view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">usersView</exception>
        public IUserAppRoleView CreateUpdatedUserRoleView(IUserAppRoleView usersView, string processingMessage)
        {
            if (usersView == null)
            {
                throw new ArgumentNullException(nameof(usersView));
            }

            usersView.ProcessingMessage = processingMessage;

            return usersView;
        }

        /// <summary>
        /// Users the information model.
        /// </summary>
        /// <param name="userDetail">The user detail.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userDetail</exception>
        public IUsersView UserInformationModel(IUser userDetail)
        {
            if (userDetail == null)
            {
                throw new ArgumentNullException(nameof(userDetail));
            }

            var userInfor = new UsersView
            {
                FirstName = userDetail.FirstName,
                LastName = userDetail.LastName,
                CompanyId = userDetail.CompanyId,
                CompanyName = userDetail.CompanyName,
                Email = userDetail.Email
                
            };

            return userInfor;
        }

        /// <summary>
        /// Creates the header view.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="company">The company.</param>
        /// <param name="companyLogo">The company logo.</param>
        /// <returns></returns>
        public IHeaderViewModel CreateHeaderView(IUserDetail user, ICompanyDetail company, IDigitalFile companyLogo)
        {
            var result = new HeaderViewModel
            {
                User = user,
                Company = company,
                CompanyLogo = companyLogo
            };

            return result;
        }
    }
}