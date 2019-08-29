using System;
using System.Collections.Generic;
using System.Linq;
using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Models;

namespace AA.HRMS.Repositories.Queries
{
    internal static class AccountQueries
    {
        internal static IRegistration getRegistrationByUsername(HRMSEntities db, string username)
        {
            var result = (from d in db.Registrations
                where d.Username.Equals(username)
                select new RegistrationRepModel
                {
                    RegistrationId = d.RegistrationId,
                    Username = d.Username,
                    Password = d.Password,
                    CompanyId = d.CompanyId,
                    FirstName = d.FirstName,
                    LastName = d.Lastname,
                    CompanyName = d.CompanyName,
                    Email = d.Email,
                    PhoneNumber = d.PhoneNumber,
                    AboutUsSourceId = d.AboutUsSourceId,
                    AboutUsOthers = d.AboutUsOthers,
                    IsActive = d.IsActive.HasValue ? d.IsActive.Value : false,
                    IsRegistered = d.IsRegistered,
                    DateCreated = d.DateCreated,
                    DateRegistered = d.DateCreated
                }).FirstOrDefault();
            return result;
        }
        
        internal static IRegistration getRegistrationByEmail(HRMSEntities db, string email)
        {
            var result = (from d in db.Registrations
                where d.Email.Equals(email)
                select new RegistrationRepModel
                {
                    RegistrationId = d.RegistrationId,
                    Username = d.Username,
                    Password = d.Password,
                    CompanyId = d.CompanyId,
                    FirstName = d.FirstName,
                    LastName = d.Lastname,
                    CompanyName = d.CompanyName,
                    Email = d.Email,
                    PhoneNumber = d.PhoneNumber,
                    AboutUsSourceId = d.AboutUsSourceId,
                    AboutUsOthers = d.AboutUsOthers,
                    IsActive = d.IsActive.HasValue ? d.IsActive.Value : false,
                    IsRegistered = d.IsRegistered,
                    DateCreated = d.DateCreated,
                    DateRegistered = d.DateCreated
                }).FirstOrDefault();
            return result;
        }
        
        internal static IUser getUserByUsername(HRMSEntities db, string usermame)
        {
            var result = (from d in db.Users
                where d.Username == usermame
                select new UserModel
                {
                    UserId = d.UserId,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Password = d.Password,
                    Email = d.Email,
                    PhoneNumber = d.PhoneNumber,
                    DateCreated = d.DateCreated,
                    IsActive = d.IsActive,
                    IsUserVerified = d.IsUserVerified,
                    IsLocked = d.IsLocked.HasValue && d.IsLocked.Value,
                    IsResetPassword = d.IsResetPassword.HasValue && d.IsResetPassword.Value,
                    Username = d.Username,
                    CompanyId = d.CompanyId,
                    DateVerified = d.DateVerified
                }).FirstOrDefault();
            return result;
        }
        
        internal static IUser getUserByUserId(HRMSEntities db, int userId)
        {
            var result = (from d in db.Users
                where d.UserId == userId
                join e in db.Companies on d.CompanyId equals e.CompanyId into company
                from f in company.DefaultIfEmpty()
                select new UserModel
                {
                    UserId = d.UserId,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Password = d.Password,
                    Email = d.Email,
                    PhoneNumber = d.PhoneNumber,
                    DateCreated = d.DateCreated,
                    IsActive = d.IsActive,
                    IsUserVerified = d.IsUserVerified,
                    IsLocked = d.IsLocked.HasValue && d.IsLocked.Value,
                    IsResetPassword = d.IsResetPassword.HasValue && d.IsResetPassword.Value,
                    Username = d.Username,
                    CompanyId = d.CompanyId,
                    CompanyName = f.CompanyName,
                    DateVerified = d.DateVerified
                }).FirstOrDefault();
            return result;
        }
        
        internal static IEnumerable<string> getUserRoleActionCollection(HRMSEntities db, string username)
        {
            var result = (from d in db.UserAppRoles
                join s in db.AppRoles on d.AppRoleId equals s.AppRoleId
                where d.Username == username
                select s.Action);
            return result;
        }
        
        internal static IUser getUserByEmail(HRMSEntities db, string email)
        {
            var result = (from d in db.Users
                where d.Email == email
                select new UserModel
                {
                    UserId = d.UserId,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Password = d.Password,
                    Email = d.Email,
                    PhoneNumber = d.PhoneNumber,
                    DateCreated = d.DateCreated,
                    IsActive = d.IsActive,
                    IsUserVerified = d.IsUserVerified,
                    IsLocked = d.IsLocked.HasValue && d.IsLocked.Value,
                    IsResetPassword = d.IsResetPassword.HasValue && d.IsResetPassword.Value,
                    Username = d.Username,
                    CompanyId = d.CompanyId,
                    DateVerified = d.DateVerified
                }).FirstOrDefault();
            return result;
        }
        
        internal static IUserActivationCode getActivationCode(HRMSEntities db, string activationCode)
        {
            var result = (from d in db.UserActivationCodes
                where d.ActivationCode == activationCode
                select new UserActivationCodeModel
                {
                    DateCreated = d.DateCreated,
                    ActivationCode = d.ActivationCode,
                    UserActivationCodeId = d.UserActivationCodeId,
                    ExpirationDate = d.ExpirationDate,
                    IsUsed = d.IsUsed,
                    UserId = d.UserId,
                  
                }).FirstOrDefault();
            return result;
        }
        
        internal static IChangePassword getChangePasswordByCode(HRMSEntities db, string code)
        {
            var getemail = (from d in db.ChangePasswords
                            where d.Code.Equals(code)
                            select new Models.ChangePasswordModel
                            {
                                Email = d.Email,
                                Code = d.Code,
                                Date = d.Date,
                                Id = d.Id
                                
                            }).FirstOrDefault();

            return getemail;
        }
    }
}