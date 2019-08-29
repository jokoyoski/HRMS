using AA.HRMS.Controllers;
using AA.HRMS.Domain.Models;
using AA.HRMS.Domain.Resources;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.Infrastructure.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AA.HRMS.Tests.Controllers
{/// </summary>
    [TestFixture, Category("Controllers")]
    public class JobControllerTest
    {
        /// <summary>
        /// 
        /// </summary>
        private HttpContextBase httpContext;
        /// <summary>
        /// 
        /// </summary>
        private JobController jobController;

        /// <summary>
        /// 
        /// </summary>
        private IVacancyService vacancyService;
        /// <summary>
        /// 
        /// </summary>
        private IAccountService accountService;
        /// <summary>
        /// 
        /// </summary>
        private ISessionStateService session;
        /// <summary>
        /// 
        /// </summary>
        private IProfileService profileService;
        /// <summary>
        /// 
        /// </summary>
        private IHomeView homeView;
        private IUserProfileView userProfileView;
        private IApplicationsListView applicationsListView;

        [SetUp]
        public void SetUp()
        {
            this.session = MockRepository.GenerateMock<ISessionStateService>();
            this.httpContext = MockRepository.GenerateStub<HttpContextBase>();
            this.vacancyService = MockRepository.GenerateMock<IVacancyService>();
            this.accountService = MockRepository.GenerateMock<IAccountService>();
            this.profileService = MockRepository.GenerateMock<IProfileService>();

            this.jobController = new JobController(this.vacancyService, this.accountService, this.session, this.profileService);

            this.jobController.ControllerContext =
               new ControllerContext(this.httpContext, new System.Web.Routing.RouteData(), this.jobController);
        }

        [Test]
        public void Index_should_return_redictrect_to_Action()
        {
            //
            var result = (RedirectToRouteResult)this.jobController.Index();

            // Assert
            Assert.AreEqual("Vacancies", result.RouteValues["action"]);
        }
        [Test]
        public void Vacancies_should_call_GetOpenVacancies_of_vacancyService()
        {
            string serachvalue = string.Empty;
            //setup
            this.vacancyService.Expect(p => p.GetOpenVacancies(serachvalue)).IgnoreArguments().Return(homeView);
            //act
            this.jobController.Vacancies(serachvalue);
            //assert
            this.vacancyService.VerifyAllExpectations();
        }

        [Test]
        public void Vacancies_should_redirect_to_Vacancies()
        {
            string searchValue = string.Empty;
            //Act
            var model = (this.jobController.Vacancies(searchValue));
            //Asert
            Assert.IsNotNull(model);
        }



        [Test]
        public void CV_should_call_GetUserProfile_of_accountService()
        {
            int UserId = 6;
            var message = string.Empty;
            //arrange
            this.accountService.Stub(p => p.GetUserProfile(UserId, message)).IgnoreArguments().Return(userProfileView);

            //act
            this.jobController.CV();
            //assert
            this.accountService.VerifyAllExpectations();
        }


        [Test]
        public void CV_should_return_RedirectToAction_Create_if_User_Profile_does_not_exist()
        {
            //Arrange
            var profileview = false;
            //act
            var model = (RedirectToRouteResult)this.jobController.CV();
            //assert
            Assert.AreEqual("Account", model.RouteValues["controller"]);


        }

        [Test]
        public void Apply_should_redirect_to_action_if_User_Id_does_Not_exist()
        {

            //Arrange
            JobApplicationVacancyView jobApplicationVacancyInfo = new JobApplicationVacancyView();
            var profileview = false;
            //act
            var model = (RedirectToRouteResult)this.jobController.Apply(jobApplicationVacancyInfo);
            //assert
            Assert.AreEqual("Account", model.RouteValues["controller"]);
        }

        [Test]
        public void Get_Apply_should_redirect_to_action_if_Id__is_greater_than_0()
        {
            var message = Messages.ProfileDoesntExist;
            int vacancyId = 9;
            //Arrange
            JobApplicationVacancyView jobApplicationVacancyInfo = new JobApplicationVacancyView();




            //act
            var model = (RedirectToRouteResult)this.jobController.Apply(vacancyId);
            //assert
            Assert.AreEqual("Job", model.RouteValues["controller"]);
        }

        [Test]
        public void Get_Apply_should_throw_exception_if_Id_is_less_than_0()
        {
            int Id = 0;

            Assert.Throws<ArgumentNullException>(() =>
                this.jobController.Apply(Id));
        }

        [Test]
        public void Post_Apply_should_throw_exception_if_jobApplicationVacancyInfo_is_null()
        {
            //arrange 
            JobApplicationVacancyView jobApplicationVacancyInfo = new JobApplicationVacancyView();
            // jobApplicationVacancyInfo = null;


            Assert.Throws<ArgumentNullException>(() =>
                this.jobController.Apply(null));

        }

        [Test]
        public void _Post_Apply__should_call_ProcessJobApplication_of_vacancyService()
        {
            var message = string.Empty;
            JobApplicationVacancyView jobApplicationVacancyInfo = new JobApplicationVacancyView();
            //arrange
            this.vacancyService.Stub(p => p.ProcessJobApplication(jobApplicationVacancyInfo)).IgnoreArguments().Return(message);


            //act
            this.jobController.Apply(jobApplicationVacancyInfo);


            //Assert
            this.vacancyService.VerifyAllExpectations();
        }


        [Test]
        public void Applications_should_call_GetApplicationsView_of_vacancyService()
        {
            int UserId = 8;
            var message = string.Empty;
            //arrange
            this.vacancyService.Expect(p => p.GetApplicationsView(UserId, message)).IgnoreArguments().Return(applicationsListView);

            //act
            this.jobController.Applications(message);

            //Assert
            this.vacancyService.VerifyAllExpectations();
        }



        [Test]
        public void Applications_should_redrect_action_if_isUserIdValueDoesNotExist()

        {
            var message = string.Empty;
            JobApplicationVacancyView jobApplicationVacancyInfo = new JobApplicationVacancyView();
         
            //act
            var model = (RedirectToRouteResult)this.jobController.Applications(message);
            //assert
            Assert.AreEqual("Account", model.RouteValues["controller"]);
        }

        


    }
}
