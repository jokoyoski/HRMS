using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
  public  interface ICertificateViewModelFactory
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="certificationModel"></param>
        /// <param name="UserId"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        ICertificateListView CreateCertificateList(IList<ICertificationModel> certificationModel, int UserId, string processingMessage, string certificateName, int certificateId);
        /// <summary>
        /// Create Certificate View
        /// </summary>
        /// <returns></returns>


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProcessingMessage"></param>
        /// <returns></returns>
        /// 

        ICertificateViewModel createECertListView(string ProcessingMessage, int userId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="certificationModel"></param>
        /// <returns></returns>
        ICertificateViewModel CreateEditCertificateView(ICertificationModel certificationModel);

        /// <summary>
        /// GetCetificateByid
        /// </summary>
        /// <param name="ProcessingMessage"></param>
        /// <param name="CertificateId"></param>
        /// <returns></returns>
        // createCertListViewGetCertificateByID(string ProcessingMessage, int CertificateId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CertificateDetails"></param>
        /// <returns></returns>
        ICertificateViewModel createCertListViewGetCertificateByID(ICertificationModel CertificateDetails);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="certificateViewModel"></param>
        /// <param name="processingMessage"></param>
        /// <returns></returns>
        ICertificateViewModel CreateUpdatedCertificateViewModel(ICertificateViewModel certificateViewModel, string processingMessage);
  }
}
