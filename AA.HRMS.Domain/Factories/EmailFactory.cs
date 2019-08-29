using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;
using System;
using System.Linq;

namespace AA.HRMS.Domain.Factories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IEmailFactory" />
    public class EmailFactory : IEmailFactory
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="registrationInfo"></param>
        /// <param name="registrationId"></param>
        /// <returns></returns>
        public IEmailDetail CreateRegistrationConfirmationEmail(IRegistrationView registrationInfo, int registrationId)
        {
            var mailDetail = new EmailDetail
            {
                Body = "Your registration is confirmed",
                Recipients = registrationInfo.Email,
                Subject = "Stop bordering us"
            };

            return mailDetail;
        }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="registrationInfo"></param>
    /// <param name="registrationId"></param>
    /// <returns></returns>
        public IEmailDetail CreateRegistrationRequestEmail(IRegistrationView registrationInfo, int registrationId, string activationCode)
        {
            if (registrationInfo == null)
            {
                throw new ArgumentNullException(nameof(registrationInfo));
            }

            var theSubject = "Welcome to AA HRMS";
            var recipient = registrationInfo.Email;
            var theBody = "Your registration was successful, we look forward to facilitate the growth and management of your Company.";
            theBody = string.Format("{0} {1}", theBody, "<br><br> Your username is your email or username");
            theBody = string.Format("{0} {1}", theBody, "<br><br>Please click the link below to activate you account ");
            theBody = string.Format("{0} {1} {2} {3}", theBody, "<br><br> <a class='btn sm-btn' href='localhost:5200/Account/Activate?activationCode=",activationCode,"'>Click Here</a>");
            theBody = string.Format("{0} {1}", theBody, "<br><br> Thank you");

            var mailDetail = new EmailDetail
            {
                Body = theBody,
                Recipients = recipient,
                Subject = theSubject
            };

            return mailDetail;
        }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userRegistrationInfo"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
        public IEmailDetail CreateUserRegistrationRequestEmail(IUsersView userRegistrationInfo, int userId)
        {
            if (userRegistrationInfo == null) throw new ArgumentNullException(nameof(userRegistrationInfo));


            var token = string.Format("xyz");
            var theSubject = "Confirm your AA.HRMS Registration Request";
            var recipient = userRegistrationInfo.Email;
            var theBody = "You are now registered for AA HRMS services.";
            theBody = string.Format("{0} {1}", theBody, "<br><br> Your username is your email.");
            theBody = string.Format("{0} {1}{2}", theBody, "<br><br> Your confirmation token is ", token);
            theBody = string.Format("{0} {1}", theBody, "<br><br> <a href='www.automataassociates.com'>AA.HRMS</a>");
            theBody = string.Format("{0} {1}", theBody, "<br><br> Thank you");

            var mailDetail = new EmailDetail
            {
                Body = theBody,
                Recipients = recipient,
                Subject = theSubject
            };

            return mailDetail;
        }

    }
}