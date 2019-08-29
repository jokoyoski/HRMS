using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Factories;
using AA.HRMS.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AA.HRMS.Repositories.Services
{

    public class AccountRepository : IAccountRepository
    {

        private readonly IDbContextFactory dbContextFactory;
        
        public AccountRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory ?? new DbContextFactory(null);
        }
        

        public AccountRepository()
            : this(null)
        {
        }

        #region Registration Section

        /// <summary>
        /// Gets the registration by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetRegistrationByEmail</exception>
        public IRegistration GetRegistrationByEmail(string email)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = AccountQueries.getRegistrationByEmail(dbContext, email);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetRegistrationByEmail", e);
            }
        }
        
        /// <summary>
        /// Gets the registration by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetRegistrationByUserId</exception>
        public IRegistration GetRegistrationByUsername(string username)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = AccountQueries.getRegistrationByUsername(dbContext, username);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetRegistrationByUserId", e);
            }
        }

        /// <summary>
        /// Saves the registration information.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <param name="registrationId">The registration identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">registrationInfo</exception>
        public string SaveRegistrationInfo(IRegistrationView registrationInfo, out int registrationId)
        {
            if (registrationInfo == null)
            {
                throw new ArgumentNullException(nameof(registrationInfo));
            }

            var result = string.Empty;
            var newRecord = new Registration
            {
                Username = registrationInfo.Username,
                Password = registrationInfo.Password,
                CompanyId = 0,
                FirstName = registrationInfo.FirstName,
                Lastname = registrationInfo.LastName,
                CompanyName = registrationInfo.CompanyName,
                Email = registrationInfo.Email,
                PhoneNumber = registrationInfo.PhoneNumber,
                AboutUsSourceId = registrationInfo.AboutUsSourceId,
                AboutUsOthers = registrationInfo.AboutUsOthers,
                IsActive = registrationInfo.IsActive,
                IsRegistered = false,
                DateCreated = DateTime.Now
            };
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Registrations.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveRegistrationInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            registrationId = newRecord.RegistrationId;
            return result;
            ;
        }

        /// <summary>
        /// Stores the activation code.
        /// </summary>
        /// <param name="registrationId">The registration identifier.</param>
        /// <param name="activationCode">The activation code.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">registrationId</exception>
        /// <exception cref="ArgumentNullException">activationCode</exception>
        public string StoreActivationCode(int registrationId, string activationCode)
        {
            if (registrationId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(registrationId));
            }

            if (activationCode == null)
            {
                throw new ArgumentNullException(nameof(activationCode));
            }

            var result = string.Empty;
            var newRecord = new UserActivationCode
            {
                UserId = registrationId,
                ActivationCode = activationCode,
                DateCreated = DateTime.Now,
                ExpirationDate = DateTime.Now.AddHours(24), // Activation Code Expires in 24 Hours
            };
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.UserActivationCodes.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("StoreActivationCode - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
            
        }

        /// <summary>
        /// Gets the activation code.
        /// </summary>
        /// <param name="activationCode">The activation code.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetActivationCode</exception>
        public IUserActivationCode GetActivationCode(string activationCode)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = AccountQueries.getActivationCode(dbContext, activationCode);

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetActivationCode", e);
            }
        }

        /// <summary>
        /// Updates the actviation code.
        /// </summary>
        /// <param name="userActivationCodeId">The user activation code identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">userActivationCodeId</exception>
        public string UpdateActviationCode(int userActivationCodeId)
        {
            if (userActivationCodeId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userActivationCodeId));
            }


            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var activationCodeData =
                        dbContext.UserActivationCodes.SingleOrDefault(m =>
                            m.UserActivationCodeId.Equals(userActivationCodeId));
                    activationCodeData.IsUsed = true;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Update Actviation Code - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        
        /// <summary>
        /// Saves the user information.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <param name="registrationId">The registration identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">registrationInfo</exception>
        public string SaveUserInfo(IRegistrationView registrationInfo, out int registrationId)
        {
            if (registrationInfo == null)
            {
                throw new ArgumentNullException(nameof(registrationInfo));
            }

            var result = string.Empty;
            var newRecord = new User
            {
                Username = registrationInfo.Username,
                Password = registrationInfo.Password,
                FirstName = registrationInfo.FirstName,
                LastName = registrationInfo.LastName,
                IsActive = true,
                PhoneNumber = registrationInfo.PhoneNumber,
                IsLocked = false,
                Email = registrationInfo.Email,
                IsResetPassword = false,
                IsUserVerified = false,
                DateCreated = DateTime.Now,
                CompanyId = registrationInfo.CompanyId
            };
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Users.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveRegistrationInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            registrationId = newRecord.UserId;
            return result;
        }
        
        /// <summary>
        /// Creates the user role.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">registrationInfo</exception>
        public string CreateUserRole(IRegistrationView registrationInfo)
        {
            if (registrationInfo == null)
            {
                throw new ArgumentNullException(nameof(registrationInfo));
            }

            var result = string.Empty;
            var newRecord = new UserAppRole
            {
                Username = registrationInfo.Username,
                DateCreated = DateTime.Now,
                CreateByUsername = registrationInfo.Username
            };

            if (registrationInfo.SelectedRole == "CompanyAdmin")
            {
                newRecord.AppRoleId = 5; //CompanyAdmin
            }

            if (registrationInfo.SelectedRole == "Employee")
            {
                newRecord.AppRoleId = 2; //Employee
            }

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.UserAppRoles.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("CreateUserRole - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            return result;
        }
        
        /// <summary>
        /// Updates the user company.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">user</exception>
        public string UpdateUserCompany(IUserDetail user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var dbModel = dbContext.Users.SingleOrDefault(p => p.UserId.Equals(user.UserId));

                    dbModel.CompanyId = user.CompanyId;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("UpdateUserCompany - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }


        /// <summary>
        /// Updates the user record.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">userId</exception>
        public string UpdateUserRecord(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userId));
            }


            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var userRecord =
                        dbContext.Users.SingleOrDefault(m =>
                            m.UserId.Equals(userId));
                    userRecord.IsUserVerified = true;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Update User Record - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        #endregion
        
        #region Password Reset

        /// <summary>
        /// Saves the change password.
        /// </summary>
        /// <param name="changePasswordView">The change password view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">changePasswordView</exception>
        public string SaveChangePassword(IChangePasswordView changePasswordView)
        {
            if (changePasswordView == null)
            {
                throw new ArgumentNullException(nameof(changePasswordView));
            }

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var userInfo = dbContext.Users.SingleOrDefault(p => p.Email.Equals(changePasswordView.Email));

                    userInfo.Password = changePasswordView.NewPassword;
                    userInfo.IsResetPassword = true;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Change Password - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Updates the ChangePassword Table.
        /// </summary>
        /// <returns></returns>
        public string SaveChangePasswordDetails(IChangePassword changeP)
        {
            if (changeP == null)
            {
                throw new ArgumentNullException(nameof(changeP));
            }
            var result = string.Empty;
            var newPasswordDetails = new ChangePassword
            {
                Email = changeP.Email,
                Code = changeP.Code,
                Date = changeP.Date
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.ChangePasswords.Add(newPasswordDetails);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveChangePasswordDetails - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }
            return result;
        }

        /// <summary>
        /// Gets the change password by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository getEmailbyCode</exception>
        public IChangePassword GetChangePasswordByCode(string code)
        {
            HRMSEntities db = new HRMSEntities();

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = AccountQueries.getChangePasswordByCode(dbContext, code);

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository getEmailbyCode", e);
            }

        }

        #endregion
        
        #region Login/Logoff

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAppUser</exception>
        public IUser GetUserByUsername(string userName)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appUser = AccountQueries.getUserByUsername(dbContext, userName);

                    return appUser;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetUserByUsername", e);
            }
        }


        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetUserByUsername</exception>
        public IUser GetUserByEmail(string email)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appUser = AccountQueries.getUserByEmail(dbContext, email);

                    return appUser;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetUserByUsername", e);
            }
        }


        /// <summary>
        /// Gets the user role actions.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetUserRoleIdCollection</exception>
        public IList<string> GetUserRoleActions(string username)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = AccountQueries.getUserRoleActionCollection(dbContext, username).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetUserRoleIdCollection", e);
            }
        }

        #endregion

        /// <summary>
        /// Gets the user by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetUserByUserId</exception>
        public IUser GetUserByUserId(int userId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var appUser = AccountQueries.getUserByUserId(dbContext, userId);

                    return appUser;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetUserByUserId", e);
            }
        }
        
        /// <summary>
        /// Saves the company admin.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">user</exception>
        public string SaveCompanyAdmin(IUserDetail user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var result = string.Empty;

            var newRecord = new CompanyAdministrator
            {
                CompanyId = user.CompanyId,
                Username = user.Username,
                IsActive = true,

            };

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.CompanyAdministrators.Add(newRecord);

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("UpdateUserCompany - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="registrationRequestEmail">The registration request email.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string SendEmail(IEmailDetail registrationRequestEmail)
        {
            throw new NotImplementedException();
        }
    }
}