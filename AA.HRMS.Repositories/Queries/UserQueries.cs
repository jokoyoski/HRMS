using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Models;

namespace AA.HRMS.Repositories.Queries
{
    internal static class UserQueries
    {
        /// <summary>
        /// Gets the user list.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        internal static IEnumerable<IUserDetail> getUserList(HRMSEntities db)
        {
            var result = (from d in db.Users
                        
                          select new UserRegistrationModel
                          {
                              UserId = d.UserId,
                              Username = d.Username,
                              FirstName = d.FirstName,
                              LastName = d.LastName,
                              IsActive = d.IsActive,
                              Email = d.Email,
                              Password = d.Password,
                              PhoneNumber = d.PhoneNumber,
                            
                              DateCreated = d.DateCreated,
                              IsUserVerified = d.IsUserVerified,
                              CompanyId = d.CompanyId,
                              IsResetPassword = d.IsResetPassword,
                              IsLocked = d.IsLocked,
                              DateVerified = d.DateVerified,
                              
                          }).OrderBy(x => x.Username);

            return result;
        }

        /// <summary>
        /// Gets the user list by company identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<IUserDetail> GetUserListByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.Users
                          join w in db.Companies on d.CompanyId equals w.CompanyId
                          where w.CompanyId.Equals(companyId)
                          select new UserRegistrationModel
                          {
                              UserId = d.UserId,
                              Username = d.Username,
                              FirstName = d.FirstName,
                              LastName = d.LastName,
                              IsActive = d.IsActive,
                              Email = d.Email,
                              Password = d.Password,
                              PhoneNumber = d.PhoneNumber,

                              DateCreated = d.DateCreated,
                              IsUserVerified = d.IsUserVerified,
                              CompanyId = w.CompanyId,
                              IsResetPassword = d.IsResetPassword,
                              IsLocked = d.IsLocked,
                              DateVerified = d.DateVerified,

                          }).OrderBy(x => x.Username);

            return result;
        }


        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="UserId">The user identifier.</param>
        /// <returns></returns>
        internal static IUserDetail getUserById(HRMSEntities db, int UserId)
        {
            var result = (from d in db.Users
                          where d.UserId.Equals(UserId) && d.IsActive.Equals(true)
                          select new UserRegistrationModel
                          {
                              UserId = d.UserId,
                              Username = d.Username,
                              FirstName = d.FirstName,
                              LastName = d.LastName,
                              IsActive = d.IsActive,
                              Email = d.Email,
                              Password = d.Password,
                              PhoneNumber = d.PhoneNumber,
                              
                              DateCreated = d.DateCreated,
                              IsUserVerified = d.IsUserVerified,
                              CompanyId = d.CompanyId,
                              IsResetPassword = d.IsResetPassword,
                              IsLocked = d.IsLocked,
                              DateVerified = d.DateVerified,
                          }).FirstOrDefault();
            return result;
        }
    }
}
