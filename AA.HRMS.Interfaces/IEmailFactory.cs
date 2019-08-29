namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEmailFactory
    {
        /// <summary>
        /// Creates the registration request email.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <param name="registrationId">The registration identifier.</param>
        /// <returns></returns>
        IEmailDetail CreateRegistrationRequestEmail(IRegistrationView registrationInfo, int registrationId, string activationCode);

        /// <summary>
        /// Creates the registration confirmation email.
        /// </summary>
        /// <param name="registrationInfo">The registration information.</param>
        /// <param name="registrationId">The registration identifier.</param>
        /// <returns></returns>
        IEmailDetail CreateRegistrationConfirmationEmail(IRegistrationView registrationInfo, int registrationId);

        /// <summary>
        /// Creates the user registration request email.
        /// </summary>
        /// <param name="userRegistrationInfo">The user registration information.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IEmailDetail CreateUserRegistrationRequestEmail(IUsersView userRegistrationInfo, int userId);
    }
}
