
    using System.ComponentModel.DataAnnotations;
    using AA.HRMS.Domain.Resources;
    using AA.HRMS.Interfaces;

namespace AA.HRMS.Domain.Models
{ 

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.ILogOnView" />
public class LogOnView : ILogOnView
{
    private string userName;

    /// <summary>
    /// {D255958A-8513-4226-94B9-080D98F904A1}Gets or sets the name of the user.
    /// </summary>
    /// <value>
    /// The name of the user.
    /// </value>
    [Required(ErrorMessageResourceName = "UserNameValidationError", ErrorMessageResourceType = typeof(Messages))]
    public string UserName
    {
        get { return this.userName; }
        set
        {
            if (value != Messages.UserNameWatermarkMessage)
            {
                this.userName = value;
            }
        }
    }

    /// <summary>
    /// {D255958A-8513-4226-94B9-080D98F904A1}Gets or sets the password.
    /// </summary>
    /// <value>
    /// The password.
    /// </value>
    [Required(ErrorMessageResourceName = "PasswordValidationError", ErrorMessageResourceType = typeof(Messages))]
    public string Password { get; set; }

    /// <summary>
    /// {D255958A-8513-4226-94B9-080D98F904A1}Gets or sets a value indicating whether to [remember me].
    /// </summary>
    /// <value>
    /// {D255958A-8513-4226-94B9-080D98F904A1}  <c>true</c> if [remember me]; otherwise, <c>false</c>.
    /// </value>
    public bool RememberMe { get; set; }

    /// <summary>
    /// {D255958A-8513-4226-94B9-080D98F904A1}Gets or sets the return URL.
    /// </summary>
    /// <value>
    /// The return URL.
    /// </value>
    public string ReturnUrl { get; set; }

    /// <summary>
    /// {D255958A-8513-4226-94B9-080D98F904A1}Gets or sets the error message.
    /// </summary>
    /// <value>
    /// The error message.
    /// </value>
    public string ErrorMessage { get; set; }

    /// <summary>
    /// {D255958A-8513-4226-94B9-080D98F904A1}Gets or sets the info message.
    /// </summary>
    /// <value>
    /// The info message.
    /// </value>
    public string InfoMessage { get; set; }

    /// <summary>
    /// {D255958A-8513-4226-94B9-080D98F904A1}Gets a value indicating whether this instance has info message.
    /// </summary>
    /// <value>
    /// {D255958A-8513-4226-94B9-080D98F904A1}<c>true</c> if this instance has info message; otherwise, <c>false</c>.
    /// </value>
    public bool HasInfoMessage
    {
        get { return !string.IsNullOrEmpty(this.InfoMessage); }
    }

    /// <summary>
    /// {D255958A-8513-4226-94B9-080D98F904A1}Gets or sets a value indicating whether this instance has invalid credentials.
    /// </summary>
    /// <value>
    /// {D255958A-8513-4226-94B9-080D98F904A1}<c>true</c> if this instance has invalid credentials; otherwise, <c>false</c>.
    /// </value>
    public bool HasInvalidCredentials { get; set; }

    /// <summary>
    /// {D255958A-8513-4226-94B9-080D98F904A1}Gets or sets a value indicating whether this instance has invalid user name.
    /// </summary>
    /// <value>
    /// {D255958A-8513-4226-94B9-080D98F904A1}<c>true</c> if this instance has invalid user name; otherwise, <c>false</c>.
    /// </value>
    public bool HasInvalidUserName { get; set; }

    /// <summary>
    /// {D255958A-8513-4226-94B9-080D98F904A1}Gets or sets a value indicating whether this instance has invalid password.
    /// </summary>
    /// <value>
    /// {D255958A-8513-4226-94B9-080D98F904A1}<c>true</c> if this instance has invalid password; otherwise, <c>false</c>.
    /// </value>
    public bool HasInvalidPassword { get; set; }
}
}