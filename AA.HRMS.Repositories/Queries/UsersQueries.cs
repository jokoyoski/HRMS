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
    
    internal static class UsersQueries
    {
        
        internal static IUser getUserByEmail(HRMSEntities db, string email)
        {
            var result = (from d in db.Users
                          join c in db.Companies on d.CompanyId equals c.CompanyId
                          where d.Email.Equals(email)
                          select new UserModel
                          {
                              UserId = d.UserId,
                              Password = d.Password,
                              CompanyId = d.CompanyId,
                              LastName = d.LastName,
                              FirstName = d.FirstName,
                              Email = d.Email,
                              CompanyName = c.CompanyName,
                              IsUserVerified = d.IsUserVerified,
                              DateCreated = d.DateCreated,
                              DateVerified = d.DateVerified,
  
                          }).FirstOrDefault();
            return result;
        }

        
        internal static IUser GetActivationCode(HRMSEntities db, string activationCode)
        {
            var result = (from d in db.Users
                          where d.Email.Equals(activationCode)
                          select new UserModel
                          {
                              UserId = d.UserId
                          }).FirstOrDefault();
            return result;
        }

        
        internal static IUserAppRole getUserRoleByUserRoleId(HRMSEntities db, int userAppRoleId)
        {
            var result = (from d in db.UserAppRoles
                          where d.UserAppRoleId.Equals(userAppRoleId)
                          join e in db.AppRoles on d.AppRoleId equals e.AppRoleId
                          select new Models.UserAppRoleModel
                          {
                              Username = d.Username,
                              AppRoleId = d.AppRoleId,
                              CreateByUsername = d.CreateByUsername,
                              DateCreated = d.DateCreated,
                              UserAppRoleId = d.UserAppRoleId,
                              RoleName = e.Action,
                          }).FirstOrDefault();

            return result;
        }

        
        internal static IUserAppRole getUserRoleByUsername(HRMSEntities db, string userName)
        {
            var result = (from d in db.UserAppRoles
                          where d.Username.Equals(userName) && d.AppRoleId.Equals(6)
                          join e in db.AppRoles on d.AppRoleId equals e.AppRoleId
                          select new Models.UserAppRoleModel
                          {
                              Username = d.Username,
                              AppRoleId = d.AppRoleId,
                              CreateByUsername = d.CreateByUsername,
                              DateCreated = d.DateCreated,
                              UserAppRoleId = d.UserAppRoleId,
                              RoleName = e.Description,
                          }).FirstOrDefault();

            return result;
        }
    }
}