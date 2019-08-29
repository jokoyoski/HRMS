using System;
using System.Collections.Generic;
using AA.HRMS.Domain.Models;
using AA.HRMS.Domain.Utilities;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Domain.Factories
{
    public class ProfileViewModelFactory : IProfileViewModelFactory
    {
        /// <summary>
        /// Creates the profile view.
        /// </summary>
        /// <param name="userInfo">The user information.</param>
        /// <param name="genderCollection">The gender collection.</param>
        /// <param name="countrycollection">The countrycollection.</param>
        /// <param name="processingMesage">The processing mesage.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">genderCollection</exception>
        public IProfileView CreateProfileView(IUserDetail userInfo, IList<IYourGender> genderCollection, IList<ICountry> countrycollection, string processingMesage)
        {
            if (genderCollection == null)
            {
                throw new ArgumentException(nameof(genderCollection));
            }
            

            var genderDLL = GetDropDownList.GenderListItems(genderCollection, -1);
            var CountryDDL = GetDropDownList.CountryListItem(countrycollection, 161);

            var viewModel = new ProfileModelView
            {
                User = userInfo,        
                GenderDropDown = genderDLL,
                CountryDropDown = CountryDDL,
                ProcessingMessage = processingMesage ?? string.Empty,
                CountryId = 161

            };

            return viewModel;
        }

        /// <summary>
        /// Creates the profile view.
        /// </summary>
        /// <param name="profileInfo">The profile information.</param>
        /// <param name="users">The users.</param>
        /// <param name="genderCollection">The gender collection.</param>
        /// <param name="countryCollection">The country collection.</param>
        /// <param name="processingMesage">The processing mesage.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">genderCollection</exception>
        public IProfileView CreateProfileView(IProfileView profileInfo, IUserDetail users, IList<IYourGender> genderCollection, IList<ICountry> countryCollection, string processingMesage)
        {
            if (genderCollection == null)
            {
                throw new ArgumentException(nameof(genderCollection));
            }

            var genderDLL = GetDropDownList.GenderListItems(genderCollection, profileInfo.GenderId);
            var countryDLL = GetDropDownList.CountryListItem(countryCollection, profileInfo.CountryId);

            profileInfo.GenderDropDown = genderDLL;
            profileInfo.CountryDropDown = countryDLL;
            profileInfo.User = users;
            profileInfo.ProcessingMessage = processingMesage;
            

            return profileInfo;
        }

        /// <summary>
        /// Edits the profile view.
        /// </summary>
        /// <param name="profileInfo">The profile information.</param>
        /// <param name="userDetail">The user detail.</param>
        /// <param name="genderCollection">The gender collection.</param>
        /// <param name="countryCollection">The country collection.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">genderCollection</exception>
        /// <exception cref="ArgumentNullException">
        /// profileInfo
        /// or
        /// userDetail
        /// </exception>
        public IProfileView EditProfileView(IProfile profileInfo, IUserDetail userDetail, IList<IYourGender> genderCollection, IList<ICountry> countryCollection, string processingMessage)
        {
            if (genderCollection == null)
            {
                throw new ArgumentException(nameof(genderCollection));
            }

            if(profileInfo == null)
            {
                throw new ArgumentNullException(nameof(profileInfo));
            }

            if(userDetail == null)
            {
                throw new ArgumentNullException(nameof(userDetail));
            }

            var genderDLL = GetDropDownList.GenderListItems(genderCollection, profileInfo.GenderId);
            var CountryDLL = GetDropDownList.CountryListItem(countryCollection, profileInfo.CountryId);

            var viewModel = new ProfileModelView
            {
                User = userDetail,
                ProfileId = profileInfo.ProfileId,
                CountryId = profileInfo.CountryId,
                Address = profileInfo.Address,
                DateOfBirth = profileInfo.DateOfBirth,
                Nationality = profileInfo.Nationality,
                StateOfOrigin = profileInfo.StateOfOrigin,
                Gender = profileInfo.Gender,
                GenderId = profileInfo.GenderId,
                ProfileSummary = profileInfo.ProfileSummary,
                DateCreated = profileInfo.DateCreated,
                PictureDigitalFileId = profileInfo.PictureDigitalFileId,
                CVDigitalFileId = profileInfo.CVDigitalFileId,
                GenderDropDown = genderDLL,
                CountryDropDown = CountryDLL,
                ProcessingMessage = processingMessage?? string.Empty
            };

            return viewModel;
        }

        /// <summary>
        /// Edits the update profile view.
        /// </summary>
        /// <param name="profileInfo">The profile information.</param>
        /// <param name="proceesingMessage">The proceesing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">profileInfo</exception>
        public IProfileView EditUpdateProfileView(IProfileView profileInfo, string proceesingMessage)
        {
            if (profileInfo == null)
                throw new ArgumentNullException(nameof(profileInfo));

            profileInfo.ProcessingMessage = proceesingMessage;

            return profileInfo;
        }
    }
}