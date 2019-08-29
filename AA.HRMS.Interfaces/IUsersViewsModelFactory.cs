using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUsersViewsModelFactory
    {

        /// <summary>
        /// Gets the edit user application role view.
        /// </summary>
        /// <param name="userAppRole">The user application role.</param>
        /// <param name="roleCollection">The role collection.</param>
        /// <returns></returns>
        IUserAppRoleView GetEditUserAppRoleView(IUserAppRole userAppRole, IList<IAppRole> roleCollection);

        /// <summary>
        /// Creates the user registration view.
        /// </summary>
        /// <returns>
        /// IUsersView.
        /// </returns>
        IUsersView CreateUserRegistrationView();
        
        /// <summary>
        /// Creates the updated user view.
        /// </summary>
        /// <param name="userRegistrationInfo">The user registration information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IUsersView CreateUpdatedUserView(IUsersView userRegistrationInfo, string processingMessage);

        /// <summary>
        /// Creates the edit user view.
        /// </summary>
        /// <param name="userDetail">The user detail.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="appRoleCollection">The application role collection.</param>
        /// <returns></returns>
        IUserViewModel CreateEditUserView(IUserDetail userDetail, IList<ICompanyDetail> companyCollection, IList<IAppRole> appRoleCollection);

        /// <summary>
        /// Creates the edit user view.
        /// </summary>
        /// <param name="userDetail">The user detail.</param>
        /// <param name="companyCollection">The company collection.</param>
        /// <param name="appRoleCollection">The application role collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IUserViewModel CreateEditUserView(IUserViewModel userDetail, IList<ICompanyDetail> companyCollection,
           IList<IAppRole> appRoleCollection, string processingMessage);

        /// <summary>
        /// Creates the user role view.
        /// </summary>
        /// <param name="appRoleCollection">The application role collection.</param>
        /// <param name="userDetail">The user detail.</param>
        /// <returns></returns>
        IUserAppRoleView CreateUserRoleView(IList<IAppRole> appRoleCollection, IUserDetail userDetail, string loggedInUsername);

        /// <summary>
        /// Creates the user role view list.
        /// </summary>
        /// <param name="userDetail">The user detail.</param>
        /// <param name="userAppCollection">The user application collection.</param>
        /// <param name="appRoleCollection">The application role collection.</param>
        /// <returns></returns>
        IUsersView CreateUserRoleViewList(IUserDetail userDetail, IList<IUserAppRole> userAppCollection, IList<IAppRole> appRoleCollection);


        /// <summary>
        /// Creates the updated user role view.
        /// </summary>
        /// <param name="usersView">The users view.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        IUserAppRoleView CreateUpdatedUserRoleView(IUserAppRoleView usersView, string processingMessage);


        /// <summary>
        /// Users the information model.
        /// </summary>
        /// <param name="userDetail">The user detail.</param>
        /// <returns></returns>
        IUsersView UserInformationModel(IUser userDetail);

        /// <summary>
        /// Gets the delete user application role view.
        /// </summary>
        /// <param name="userAppRole">The user application role.</param>
        /// <returns></returns>
        IUserAppRoleView GetDeleteUserAppRoleView(IUserAppRole userAppRole, int userId);


        /// <summary>
        /// Creates the header view.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="company">The company.</param>
        /// <param name="companyLogo">The company logo.</param>
        /// <returns></returns>
        IHeaderViewModel CreateHeaderView(IUserDetail user, ICompanyDetail company, IDigitalFile companyLogo);
    }
}