using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.Models;
using AA.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AA.HRMS.Controllers
{
    public class CertificationController : Controller
    {
        private readonly ICertificationService certificateService;
        private readonly ISessionStateService session;

        public CertificationController(ICertificationService certificateService, ISessionStateService session)
        {
            this.certificateService = certificateService;
            this.session = session;
        }
        // GET: Certification
        public ActionResult CertificationList(int userId, string companyName)
        {

            var isUserIdValueExist = session.CheckCurrentSessionValueExists(SessionKey.UserId);
            if (!isUserIdValueExist)
            {
                //set return Url
                var returnUrl = "/Certification/CertificationList?userId=" + userId;

                // redirect to Login page
                return this.RedirectToAction("Login", "Account", new { returnUrl });
            }

            //Get The Currently Logged User Id
             userId = (int)session.GetSessionValue(SessionKey.UserId);
            int CertificateId = 0;

            var Viewmodel = this.certificateService.getCertificateById(userId, companyName, CertificateId);
            return this.View("CertificationList", Viewmodel);
        }
        [HttpGet]
        public ActionResult CreateCertification(int  userId)
        {
            var isUserIdValueExist = session.CheckCurrentSessionValueExists(SessionKey.UserId);

            if (!isUserIdValueExist)
            {
                //set return Url
                var returnUrl = "/Certification/CertificationList?userId=" + userId;

                // redirect to Login page
                return this.RedirectToAction("Login", "Account", new { returnUrl });
            }

            //Get The Currently Logged User Id
            userId = (int)session.GetSessionValue(SessionKey.UserId);

            var viewModel = this.certificateService.createCertView(userId, string.Empty);
            return this.PartialView("CreateCertification", viewModel);
        }

        [HttpPost]
        public ActionResult CreateCertification (CertificateViewModel certificationModel)
        {

            // check if userId exist in session
            var isUserIdValueExist = session.CheckCurrentSessionValueExists(SessionKey.UserId);
            if (!isUserIdValueExist)
            {
                //set return Url
                var returnUrl = "/Employee/EmployeeList";

                // redirect to Login page
                return this.RedirectToAction("Login", "Account", new { returnUrl });
            }

            if(certificationModel == null)
            {
                throw new ArgumentNullException(nameof(certificationModel));
            }

            var loggedUserId = (int)session.GetSessionValue(SessionKey.UserId);

            if (!ModelState.IsValid)
            {
             var View =   this.certificateService.createCertView(loggedUserId, string.Empty);

                return this.View("CreateCertification", View);
            }
            var viewmodel = this.certificateService.ProcessCertificateInfo(certificationModel);

            if (!string.IsNullOrEmpty(viewmodel))
            {
                var View = this.certificateService.createCertView(loggedUserId, string.Empty);
                return this.View("CreateCertification", View);
            }

            return RedirectToAction("CertificationList");

        }

        //Update Certificate

        [HttpGet]
        public ActionResult EditCertification(int CertificateId)
        {


            var isUserIdValueExist = session.CheckCurrentSessionValueExists(SessionKey.UserId);
            if (!isUserIdValueExist)
            {
                //set return Url
                var returnUrl = "/Certification/EditCertification?CertificateId=" + CertificateId;

                // redirect to Login page
                return this.RedirectToAction("Login", "Account", new { returnUrl });
            }


            //Get The Currently Logged User Id
            var loggedUserId = (int)session.GetSessionValue(SessionKey.UserId);



            var viewModel = this.certificateService.createUpdateCertificateView(CertificateId);
            return this.PartialView("EditCertification", viewModel);
        }

        [HttpPost]
        public ActionResult EditCertification(CertificateViewModel certificationModel)
        {

           

            if (certificationModel == null)
            {
                throw new ArgumentNullException(nameof(certificationModel));
            }

            
            if (!ModelState.IsValid)
            {
                var View = this.certificateService.getUpdatedView(certificationModel, string.Empty);

                return this.View("EditCertification", View);
            }
            var viewmodel = this.certificateService.ProcessEditCertificateInfo(certificationModel);

            if (!string.IsNullOrEmpty(viewmodel))
            {
                var View = this.certificateService.getUpdatedView(certificationModel, string.Empty);
                return this.View("EditCertification", View);
            }

            return RedirectToAction("CertificationList", new { userId = certificationModel.UserId });

        }

        [HttpGet]
        public ActionResult DeleteCertification (int CerificateId)
        {

            var ViewModel = this.certificateService.DeleteCertById(CerificateId);

            return this.PartialView("DeleteCertification", ViewModel);
        }

        [HttpPost]
        public ActionResult DeleteCertificate (CertificateViewModel certificateViewModel)
        {
            if (certificateViewModel == null)
            {
                throw new ArgumentNullException(nameof(certificateViewModel));
            }

            var viewModel = certificateService.DeleteCerrtificate(certificateViewModel);
            return RedirectToAction("CertificationList");
        }
        
    }
}