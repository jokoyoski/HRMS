using AA.HRMS.Domain.Models;
using AA.HRMS.Domain.Utilities;
using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Factories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.ICertificateViewModelFactory" />
    public class CertificateViewModelFactory : ICertificateViewModelFactory
    {
        public ICertificateListView  CreateCertificateList (IList<ICertificationModel> certificationModel,  int UserId, string processingMessage, string certificateName, int certificateId)
        {

            var filter = certificationModel.Where(m => m.CertificationName.Contains(string.IsNullOrEmpty(certificateName) ? m.CertificationName : certificateName)).ToList();

            var ViewModel = new CertificateListView
            {
                certificateModel = filter,
                UserId = UserId,
                CertificationId = certificateId,
                ProcessingMessage = processingMessage 
            };
            return ViewModel;
        }
        /// <summary>
        /// Create Certificate View
        /// </summary>
        /// <param name="ProcessingMessage"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ICertificateViewModel createECertListView(string ProcessingMessage, int userId)
        {
           
            var view = new CertificateViewModel
            {
               
                ProcessingMessage = ProcessingMessage,
                UserId = userId
            };
            return view;
        }
        /// <summary>
        /// </summary>
        /// <param name="certificationModel"></param>
        /// <returns></returns>
        public ICertificateViewModel CreateEditCertificateView (ICertificationModel certificationModel)
        {
            var viewModel = new CertificateViewModel
            {
                CertificationId = certificationModel.CertificationId,
                CertificationName = certificationModel.CertificationName,
                Description = certificationModel.Description,
                UserId = certificationModel.UserId,
                ProcessingMessage = string.Empty
            };
            return viewModel;
        }
        /// <summary>
        /// </summary>
        /// <param name="CertificateDetails"></param>
        /// <returns></returns>
        public ICertificateViewModel createCertListViewGetCertificateByID(ICertificationModel CertificateDetails)
        {
            //if (appraisalActionInfo == null) throw new ArgumentNullException(nameof(appraisalActionInfo));

            var CertificateResult = new CertificateViewModel
            {
                CertificationId = CertificateDetails.CertificationId,
                CertificationName = CertificateDetails.CertificationName,
                Description = CertificateDetails.Description,
                UserId = CertificateDetails.UserId
            };
            return CertificateResult;
        }
        /// <summary>
        /// </summary>
        /// <param name="certificateViewModel"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">certificateViewModel</exception>
        public ICertificateViewModel CreateUpdatedCertificateViewModel(ICertificateViewModel certificateViewModel, string processingMessage)
        {
            if (certificateViewModel == null) throw new ArgumentNullException(nameof(certificateViewModel));

            certificateViewModel.ProcessingMessage = processingMessage;

            return certificateViewModel;
        }
    }
}
