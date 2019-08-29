using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProfileView
    {
        /// <summary>
        /// Gets or sets the bio data identifier.
        /// </summary>
        /// <value>
        /// The bio data identifier.
        /// </value>
        int ProfileId { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        IUserDetail User { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int UserId { get; set; }

        /// <summary>
        /// Gets or sets the gender identifier.
        /// </summary>
        /// <value>
        /// The gender identifier.
        /// </value>
        int GenderId { get; set;}
        /// <summary>
        /// 
        /// </summary>
        int CountryId { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        string Address { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>
        /// The date of birth.
        /// </value>
        DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the gender oother.
        /// </summary>
        /// <value>
        /// The gender oother.
        /// </value>
        string GenderOther { get; set; }

        /// <summary>
        /// Gets or sets the nationality.
        /// </summary>
        /// <value>
        /// The nationality.
        /// </value>
        string Nationality { get; set; }

        /// <summary>
        /// Gets or sets the state of origin.
        /// </summary>
        /// <value>
        /// The state of origin.
        /// </value>
        string StateOfOrigin { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        string Gender { get; set; }

        /// <summary>
        /// Gets or sets the profile summary.
        /// </summary>
        /// <value>
        /// The profile summary.
        /// </value>
        string ProfileSummary { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }


        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets the picture digital file identifier.
        /// </summary>
        /// <value>
        /// The picture digital file identifier.
        /// </value>
        int PictureDigitalFileId { get; set; }

        /// <summary>
        /// Gets or sets the cv digital file identifier.
        /// </summary>
        /// <value>
        /// The cv digital file identifier.
        /// </value>
        int CVDigitalFileId { get; set; }

        /// <summary>
        /// Gets or sets the gender drop down.
        /// </summary>
        /// <value>
        /// The gender drop down.
        /// </value>
        IList<SelectListItem> GenderDropDown { get; set; }
        /// <summary>
        /// 
        /// </summary>
        IList<SelectListItem> CountryDropDown { get; set; }
    }
}