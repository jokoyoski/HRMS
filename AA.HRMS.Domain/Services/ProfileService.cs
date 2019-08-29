using System;
using System.IO;
using System.Web;
using AA.HRMS.Domain.Resources;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.Infrastructure.Interfaces;

namespace AA.HRMS.Domain.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileViewModelFactory profileViewModelFactory;
        private readonly IProfileRepository profileRepository;
        private readonly ISessionStateService session;
        private readonly IDigitalFileService digitalFileService;
        private readonly IDigitalFileRepository digitalFileRepository;
        private readonly ILookupRepository lookupRepository;
        private readonly IUsersRepository usersRepository;
        private readonly IEmployeeOnBoardRepository employeeOnBoardRepository;


        
        public ProfileService(IProfileViewModelFactory profileViewModelFactory, IProfileRepository profileRepository, IUsersRepository usersRepository,
            ISessionStateService session, IDigitalFileService digitalFileService, ILookupRepository lookupRepository, IEmployeeOnBoardRepository employeeOnBoardRepository,
            IDigitalFileRepository digitalFileRepository)
        {
            this.profileViewModelFactory = profileViewModelFactory;
            this.profileRepository = profileRepository;
            this.session = session;
            this.digitalFileService = digitalFileService;
            this.lookupRepository = lookupRepository;
            this.usersRepository = usersRepository;
            this.employeeOnBoardRepository = employeeOnBoardRepository;
            this.digitalFileRepository = digitalFileRepository;
        }


        /// <summary>
        /// Gets the profile view.
        /// </summary>
        /// <returns></returns>
        public IProfileView GetProfileView()
        {
            int userId = (int)this.session.GetSessionValue(SessionKey.UserId);
            //Get The Employee Profile From Queries
            var profile = this.profileRepository.GetProfileByUserId(userId);
            
            var userInfo = this.usersRepository.GetUserById(userId);

            var genderCollection = this.lookupRepository.GetGenderCollection();
            var countrycollection = this.lookupRepository.GetCountryCollection();

            var viewModel = this.profileViewModelFactory.CreateProfileView(userInfo, genderCollection, countrycollection, "");

            return viewModel;
        }
        
        /// <summary>
        /// Gets the profile view.
        /// </summary>
        /// <param name="profileInfo">The profile information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        public IProfileView GetProfileView(IProfileView profileInfo, string processingMessage)
        {
            var genderCollection = this.lookupRepository.GetGenderCollection();
            var countryCollection = this.lookupRepository.GetCountryCollection();
            var userInfo = this.usersRepository.GetUserById(profileInfo.UserId);
            var viewModel =
                this.profileViewModelFactory.CreateProfileView(profileInfo, userInfo, genderCollection, countryCollection, processingMessage);

            return viewModel;
        }

        /// <summary>
        /// Saves the profile information.
        /// </summary>
        /// <param name="profileInfo">The profile information.</param>
        /// <param name="profilePicture">The profile picture.</param>
        /// <param name="profileCV">The profile cv.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">profileInfo</exception>
        public string SaveProfileInfo(IProfileView profileInfo, HttpPostedFileBase profilePicture,
            HttpPostedFileBase profileCV)
        {
            if (profileInfo == null)
            {
                throw new ArgumentNullException(nameof(profileInfo));
            }

            var userInfo = this.usersRepository.GetUserById(profileInfo.UserId);

            var employee = this.employeeOnBoardRepository.GetEmployeeByEmail(userInfo.Email);


            var processingMessage = string.Empty;

            var imageDigitalFileId = -1;

            var documentDigitalFileId = -1;
            
            var processingImage =
                this.digitalFileService.SaveFile(FileType.Image, profilePicture, out imageDigitalFileId);

            var procecssingCV = this.digitalFileService.SaveFile(FileType.Pdf, profileCV, out documentDigitalFileId);

            // check if file saved to database and save the Id as part of the profile record
            if (imageDigitalFileId > 0)
            {
                profileInfo.PictureDigitalFileId = imageDigitalFileId;
            }

            if (documentDigitalFileId > 0)
            {
                profileInfo.CVDigitalFileId = documentDigitalFileId;
            }
            
            if (employee != null)
            {
                employee.PhotoDigitalFileId = imageDigitalFileId;
                employeeOnBoardRepository.UpdateEmployeePhotoId(employee);
            }

            var message = this.profileRepository.StoreProfileInfo(profileInfo);


            return message;
        }
        

        /// <summary>
        /// Gets the profile edit view.
        /// </summary>
        /// <returns></returns>
        public IProfileView GetProfileEditView()
        {

            var userInfo = this.usersRepository.GetUserById((int)session.GetSessionValue(SessionKey.UserId));
            
            var profileInfo = profileRepository.GetProfileByUserId(userInfo.UserId);
            
            var yourGenderCollection = this.lookupRepository.GetGenderCollection();
            var countryCollection = this.lookupRepository.GetCountryCollection();

            var viewModel = this. profileViewModelFactory.EditProfileView(profileInfo, userInfo, yourGenderCollection, countryCollection, "");

            return viewModel;
        }
        
        /// <summary>
        /// Processes the profile edit view.
        /// </summary>
        /// <param name="profileInfo">The profile information.</param>
        /// <param name="profilePicture">The profile picture.</param>
        /// <param name="profileCV">The profile cv.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Profile</exception>
        public string ProcessProfileEditView(IProfileView profileInfo, HttpPostedFileBase profilePicture,
            HttpPostedFileBase profileCV)
        {
            if (profileInfo == null)
            {
                throw new ArgumentNullException(nameof(Profile));
            }

            var processingMessage = string.Empty;

            var imageDigitalFileId = -1;

            var documentDigitalFileId = -1;

            if(profilePicture != null)
            {

                var processingImage =
                    this.digitalFileService.SaveFile(FileType.Image, profilePicture, out imageDigitalFileId);
            }

            if (profileCV != null)
            {

                var procecssingCV = 
                    this.digitalFileService.SaveFile(FileType.Pdf, profileCV, out documentDigitalFileId);
            }

            
            // check if file saved to database and save the Id as part of the profile record
            if (imageDigitalFileId > 0)
            {
                profileInfo.PictureDigitalFileId = imageDigitalFileId;

                session.RemoveSessionValue(SessionKey.ProfilePicture);

                var digitalFile = this.digitalFileRepository.GetDigitalFileDetail(profileInfo.PictureDigitalFileId);

                var imgSrc = "";

                if (profilePicture != null)
                {
                    var base64 = Convert.ToBase64String(digitalFile.TheDigitalFile);
                    imgSrc = string.Format("data:{0};base64,{1}", profilePicture.ContentType, base64);
                    session.AddValueToSession(SessionKey.ProfilePicture, imgSrc);
                }
            }

            if (documentDigitalFileId > 0)
            {
                profileInfo.CVDigitalFileId = documentDigitalFileId;
            }

            processingMessage = this.profileRepository.UpdateProfileInfo(profileInfo);

            
            return processingMessage;
        }
    }
}