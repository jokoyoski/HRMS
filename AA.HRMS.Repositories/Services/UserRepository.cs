using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Factories;
using AA.HRMS.Repositories.Queries;

namespace AA.HRMS.Repositories.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IUserRepository" />
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        public UserRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory ?? new DbContextFactory(null);
        }
        /// <summary>
        /// Gets all user.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository Get All User</exception>
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
        /// Deletes the user information.
        /// </summary>
        /// <param name="userInfo">The user information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userInfo</exception>
        public string DeleteUserInfo(IUserRegistrationView userInfo)
        {
            if (userInfo == null) throw new ArgumentNullException(nameof(userInfo));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var userData =
                        dbContext.Users.SingleOrDefault(m => m.UserId.Equals(userInfo.UserId));
                    userData.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Update User - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        /// <summary>
        /// Saves the user registration information.
        /// </summary>
        /// <param name="userInfo">The user information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userInfo</exception>
        public string SaveUserRegistrationInfo(IUserRegistrationView userInfo)
        {
            if (userInfo == null)
            {
                throw new ArgumentNullException(nameof(userInfo));
            }

            var result = string.Empty;

            var newRecord = new User
            {
                UserId = userInfo.UserId,
                Username = userInfo.Username,
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                IsActive = userInfo.IsActive,
                Email = userInfo.Email,
                Password = userInfo.Password,
                PhoneNumber = userInfo.PhoneNumber,

                DateCreated = userInfo.DateCreated,
                IsUserVerified = userInfo.IsUserVerified,
                CompanyId = userInfo.CompanyId,
                IsResetPassword = userInfo.IsResetPassword,
                IsLocked = userInfo.IsLocked,
                DateVerified = userInfo.DateVerified,

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
                var a = e;

                result = string.Format("SaveUserRegistrationInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetUserID</exception>
        public IUserDetail GetUserById(int userId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var userInfo = UserQueries.getUserById(dbContext, userId);

                    return userInfo;
                }
            }
            catch (Exception e)
            {


                throw new ApplicationException("Repository GetUserID", e);
            }
        }
        /// <summary>
        /// Updates the user registration information.
        /// </summary>
        /// <param name="userInfo">The user information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">userInfo</exception>
        public string UpdateUserRegistrationInfo(IUserRegistrationView userInfo)
        {
            if (userInfo == null)
            {
                throw new ArgumentNullException(nameof(userInfo));
            }

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = dbContext.Users.FirstOrDefault(x => x.UserId.Equals(userInfo.UserId));
                    aRecord.Username = userInfo.Username;
                    aRecord.FirstName = userInfo.FirstName;
                    aRecord.LastName = userInfo.LastName;            
                    aRecord.Email = userInfo.Email;                 
                    aRecord.PhoneNumber = userInfo.PhoneNumber;                  
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                var a = e;

                result = string.Format("UpdateUserRegistrationInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

       
    }
}
