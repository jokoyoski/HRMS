using System;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IProfile" />
    public class ProfileModel : IProfile
    {
        /// <summary>
        /// Gets or sets the bio data identifier.
        /// </summary>
        /// <value>
        /// The bio data identifier.
        /// </value>
        public int ProfileId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets the gender identifier.
        /// </summary>
        /// <value>
        /// The gender identifier.
        /// </value>
        public int GenderId { get; set; }

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
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>
        /// The date of birth.
        /// </value>
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
        public string GenderOother { get; set; }

        /// <summary>
        /// Gets or sets the profile summary.
        /// </summary>
        /// <value>
        /// The profile summary.
        /// </value>
        public string ProfileSummary { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the picture digital file identifier.
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
    }
}