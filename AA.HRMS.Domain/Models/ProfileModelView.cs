using System;
using AA.HRMS.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Collections.Generic;
using AA.HRMS.Domain.CustomAttribute;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IProfileView" />
    public class ProfileModelView : IProfileView
    {

        public ProfileModelView()
        {
            this.CountryDropDown = new List<SelectListItem>();
            this.GenderDropDown = new List<SelectListItem>();
        }
        /// <summary>
        /// Gets or sets the bio data identifier.
        /// </summary>
        /// <value>
        /// The bio data identifier.
        /// </value>
        public int ProfileId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public IUserDetail User { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        [Required]
        [StringLength(1000, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Address { get; set; }


        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>
        /// The date of birth.
        /// </value>
        [Required]
        [MinimumAge(16, ErrorMessage ="Minimium Age is 16")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/YYYY}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the nationality.
        /// </summary>
        /// <value>
        /// The nationality.
        /// </value>
        public string Nationality { get; set; }


        /// <summary>
        /// Gets or sets the state of origin.
        /// </summary>
        /// <value>
        /// The state of origin.
        /// </value>
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string StateOfOrigin { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the gender oother.
        /// </summary>
        /// <value>
        /// The gender oother.
        /// </value>
        public string GenderOther { get; set; }


        /// <summary>
        /// Gets or sets the profile summary.
        /// </summary>
        /// <value>
        /// The profile summary.
        /// </value>
        [Required]
        [StringLength(1500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string ProfileSummary { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets the picture digital file identifier.
        /// </summary>
        /// <value>
        /// The picture digital file identifier.
        /// </value>
        public int PictureDigitalFileId { get; set; }
        /// <summary>
        /// Gets or sets the cv digital file identifier.
        /// </summary>
        /// <value>
        /// The cv digital file identifier.
        /// </value>
        public int CVDigitalFileId { get; set; }

        /// <summary>
        /// Gets or sets the gender identifier.
        /// </summary>
        /// <value>
        /// The gender identifier.
        /// </value>
        [Required]
        [Range(0, Int64.MaxValue, ErrorMessage = "You must select a valid gender.")]
        public int GenderId { get; set; }

        /// <summary>
        /// Gets or sets the gender drop down.
        /// </summary>
        /// <value>
        /// The gender drop down.
        /// </value>
        public IList<SelectListItem> GenderDropDown { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        [Range(0, Int64.MaxValue, ErrorMessage = "You must select a valid country.")]
        public int  CountryId { get; set; }
        /// <summary>
        /// 
        /// </summary>


        public IList<SelectListItem> CountryDropDown { get; set; }
        
    }
}