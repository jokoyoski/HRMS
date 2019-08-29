using System;
using System.Collections.Generic;
using System.Linq;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Factories;
using AA.HRMS.Repositories.Queries;

namespace AA.HRMS.Repositories.Services
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IDbContextFactory dbContextFactory;
        
        public UsersRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory ?? new DbContextFactory(null);
        }

        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>
        /// IUsers.
        /// </returns>
        /// <exception cref="ApplicationException">Repository GetUserByEmail</exception>
        public IUser GetUserByEmail(string email)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = UsersQueries.getUserByEmail(dbContext, email);
                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetUserByEmail", e);
            }
        }

        /// <summary>
        /// Gets the user by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetUserByCompanyID</exception>
        public IUser GetUserByCompanyID(string companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = UsersQueries.getUserByEmail(dbContext, companyId);
                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetUserByCompanyID", e);
            }
        }

        /// <summary>
        /// Saves the user registration information.
        /// </summary>
        /// <param name="userRegistrationInfo">The user registration information.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        /// <exception cref="ArgumentNullException">userRegistrationInfo</exception>
        public string SaveUserRegistrationInfo(IUsersView userRegistrationInfo, out int userId)
        {
            if (userRegistrationInfo == null) throw new ArgumentNullException(nameof(userRegistrationInfo));

            var result = string.Empty;

            //Create New user Account
            var newRecord = new User
            {
                Email = userRegistrationInfo.Email,
                CompanyId = userRegistrationInfo.CompanyId,
                IsUserVerified = userRegistrationInfo.IsUserVerified,
                DateCreated = DateTime.Now,
                Password = "secret", //TODO: Password Hashing
            };


            //Add New User to Employee Table
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
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

            userId = newRecord.UserId;
            return result;
        }

        /// <summary>
        /// Saves the edit user information.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">users</exception>
        public string SaveEditUserInfo(IUserViewModel users)
        {

            if (users == null)
            {
                throw new ArgumentNullException(nameof(users));
            }

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var recordInfo = dbContext.Users.Find(users.UserId);

                    recordInfo.CompanyId = users.CompanyId;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveEditUserInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }
            return result;
        }

        /// <summary>
        /// Passwords the reset.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">users</exception>
        public string PasswordReset(IUser users)
        {

            if (users == null)
            {
                throw new ArgumentNullException(nameof(users));
            }

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var recordInfo = dbContext.Users.Find(users.UserId);

                    recordInfo.IsResetPassword = users.IsResetPassword;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveEditUserInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }
            return result;
        }
        
        /// <summary>
        /// Creates the activation code.
        /// </summary>
        /// <returns>
        /// System.String.
        /// </returns>
        /// <exception cref="ApplicationException">repository Create Activation Code</exception>
        public string CreateActivationCode()
        {
            try
            {
                var activationKey = Guid.NewGuid().ToString();
                if (GetActivationCode(activationKey) != null)
                {
                    CreateActivationCode();
                }

                return activationKey;
            }
            catch (Exception e)
            {
                throw new ApplicationException("repository Create Activation Code", e);
            }
        }

        /// <summary>
        /// Gets the activation code.
        /// </summary>
        /// <param name="activationCode">The activation code.</param>
        /// <returns>
        /// IUsers.
        /// </returns>
        /// <exception cref="ApplicationException">Repository GetActivation Code</exception>
        private IUser GetActivationCode(string activationCode)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var activationCodeAlreadyExists = UsersQueries.GetActivationCode(dbContext, activationCode);

                    return activationCodeAlreadyExists;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetActivation Code", e);
            }
        }

        /// <summary>
        /// Gets all user.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">Repository Get All User</exception>
        public IList<IUserDetail> GetAllUser()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = UserQueries.getUserList(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get All User", e);
            }
        }

        /// <summary>
        /// Gets all user list by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository Get All User</exception>
        public IList<IUserDetail> GetAllUserListByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = UserQueries.GetUserListByCompanyId(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get All User", e);
            }
        }

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">GetUserById</exception>
        public IUserDetail GetUserById(int userId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var user = UserQueries.getUserById(dbContext, userId);

                    return user;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("GetUserById", e);
            }
        }

        /// <summary>
        /// Saves the user application role.
        /// </summary>
        /// <param name="userDetail">The user detail.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userDetail</exception>
        public string SaveUserAppRole(IUserAppRoleView userDetail)
        {
            if(userDetail == null)
            {
                throw new ArgumentNullException(nameof(userDetail));
            }

            string result = string.Empty;

            var newRecord = new UserAppRole
            {
                Username = userDetail.Username,
                AppRoleId = userDetail.AppRoleId,
                DateCreated = DateTime.UtcNow,
                CreateByUsername = userDetail.CreateByUsername
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.UserAppRoles.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch(Exception e)
            {
                result = string.Format("SaveRegistrationInfo - {0} , {1}", e.Message,
                   e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Saves the edit user application role.
        /// </summary>
        /// <param name="userDetail">The user detail.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userDetail</exception>
        public string SaveEditUserAppRole(IUserAppRoleView userDetail)
        {

            if (userDetail == null)
            {
                throw new ArgumentNullException(nameof(userDetail));
            }

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                   var userRole =  dbContext.UserAppRoles.SingleOrDefault(p => p.Username == userDetail.Username);

                    userRole.Username = userDetail.Username;
                    userRole.AppRoleId = userDetail.AppRoleId;
                    userRole.CreateByUsername = userDetail.Username;
                    userRole.DateCreated = userDetail.DateCreated;

                    dbContext.SaveChanges();

                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveEditUserAppRole - {0} , {1}", e.Message,
                   e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Saves the delete user application role.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userName</exception>
        public string SaveDeleteUserAppRole(int userAppRoleId)
        {

            if (userAppRoleId <= 0) {
                throw new ArgumentNullException(nameof(userAppRoleId));
            }

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var returnModel = dbContext.UserAppRoles.SingleOrDefault(p => p.UserAppRoleId.Equals(userAppRoleId));

                    dbContext.UserAppRoles.Remove(returnModel);

                    dbContext.SaveChanges();
                }
            }
            catch(Exception e)
            {
                result = string.Format("SaveDeleteUserAppRole - {0} , {1}", e.Message,
                   e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets the application role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IAppRole GetAppRole(int roleId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the user application role by user application role identifier.
        /// </summary>
        /// <param name="userAppRoleId">The user application role identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// userAppRoleId
        /// or
        /// GetUserAppRoleByUserAppRoleId
        /// </exception>
        public IUserAppRole GetUserAppRoleByUserAppRoleId(int userAppRoleId)
        {
            if(userAppRoleId <= 0)
            {
                throw new ArgumentNullException(nameof(userAppRoleId));
            }

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = UsersQueries.getUserRoleByUserRoleId(dbContext, userAppRoleId);

                    return result;
                }
            }
            catch(Exception e)
            {
                throw new ArgumentNullException("GetUserAppRoleByUserAppRoleId", e);
            }
        }

        /// <summary>
        /// Gets the user application role by username.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// userName
        /// or
        /// GetUserAppRoleByUserAppRoleId
        /// </exception>
        public IUserAppRole GetUserAppRoleByUsername(string userName)
        {
            if (userName == null)
            {
                throw new ArgumentNullException(nameof(userName));
            }

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = UsersQueries.getUserRoleByUsername(dbContext, userName);

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("GetUserAppRoleByUserAppRoleId", e);
            }
        }
        
        /// <summary>
        /// Saves the calendar event.
        /// </summary>
        /// <param name="calendarEvent">The calendar event.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">calendarEvent</exception>
        public string SaveCalendarEvent(ICalendarEvent calendarEvent)
        {
            if (calendarEvent == null)
            {
                throw new ArgumentNullException(nameof(calendarEvent));
            }

            var result = string.Empty;

            var record = new CalendarEvent
            {
                Subject = calendarEvent.Subject,
                Start = calendarEvent.Start,
                End = calendarEvent.End,
                IsFullDay = calendarEvent.IsFullDay,
                ThemeColor = calendarEvent.ThemeColor
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.CalendarEvents.Add(record);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                var a = e;

                result = string.Format("Save Calendar Event - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        
        /// <summary>
        /// Deletes the calendar event.
        /// </summary>
        /// <param name="eventId">The event identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">eventId</exception>
        public string DeleteCalendarEvent(int eventId)
        {
            if (eventId <= 0)
            {
                throw new ArgumentNullException(nameof(eventId));
            }

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = dbContext.CalendarEvents.FirstOrDefault(x => x.EventId.Equals(eventId));
                    dbContext.CalendarEvents.Remove(aRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                var a = e;

                result = string.Format("Delete Calendar Event - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Updates the user lock information.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">user</exception>
        public string UpdateUserLockInfo(IUser user)
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
                    var aRecord = dbContext.Users.FirstOrDefault(x => x.Email.Equals(user.Email));
                    aRecord.IsLocked = user.IsLocked;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                var a = e;

                result = string.Format("Update User Lock Info - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        
        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="userRegistrationNotificationEmail">The user registration notification email.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public string SendEmail(IEmailDetail userRegistrationNotificationEmail)
        {
            throw new NotImplementedException();
        }

    }
}