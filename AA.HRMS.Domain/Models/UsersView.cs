using System;
using System.ComponentModel.DataAnnotations;
using AA.HRMS.Interfaces;
using System.Collections;
using System.Web.Mvc;
using System.Collections.Generic;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IUsersView" />
    public class UsersView : IUsersView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersView"/> class.
        /// </summary>
        public UsersView()
        {
            this.ProcessingMessage = string.Empty;
            this.CompanyDropDown = new List<SelectListItem>();
            this.RoleDropDown = new List<SelectListItem>();
        }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string LastName { get; set; }


        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Username { get; set; }


        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        [Required]
        [StringLength(15, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string StaffNumber { get; set; }


        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [EmailAddress]
        public string Email { get; set; }



        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long and a valid CAC number.",
            MinimumLength = 6)]
        public int CompanyId { get; set; }


        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the job title.
        /// </summary>
        /// <value>
        /// The job title.
        /// </value>
        public string JobTitle { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        public int Role { get; set; }

        /// <summary>
        /// Gets or sets the user verified.
        /// </summary>
        /// <value>
        /// The user verified.
        /// </value>
        public bool IsUserVerified { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date registered.
        /// </summary>
        /// <value>
        /// The date registered.
        /// </value>
        public DateTime? DateVerified { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the company drop down.
        /// </summary>
        /// <value>
        /// The company drop down.
        /// </value>
        public IList<SelectListItem> CompanyDropDown { get; set; }

        /// <summary>
        /// Gets or sets the role drop down.
        /// </summary>
        /// <value>
        /// The role drop down.
        /// </value>
        public IList<SelectListItem> RoleDropDown { get; set; }

        /// <summary>
        /// Gets or sets the application role collection.
        /// </summary>
        /// <value>
        /// The application role collection.
        /// </value>
        public IList<IUserAppRole> AppRoleCollection { get; set; }
    }
}