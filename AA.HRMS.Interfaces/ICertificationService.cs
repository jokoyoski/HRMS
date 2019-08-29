using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
   public interface ICertificationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        ICertificateListView getCertificateById(int userId, string companyName, int CertificateId);


        /// <summary> 
        /// save Certififcate info to the db
        /// </summary>
        /// <param name="certInfo"></param>
        /// <returns></returns>
        string ProcessCertificateInfo(ICertificateViewModel certInfo);

        /// <summary>
        /// Create Certificate view
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        /// ICertificateViewModel createCertView(int UserId, ICertificationModel CertModel);
       ICertificateViewModel createCertView(int UserId, string Message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CertificateId"></param>
        /// <returns></returns>
        ICertificateViewModel createUpdateCertificateView(int CertificateId);

        /// <summary>
        /// ProcessupdateCertificateById
        /// </summary>
        /// <param name="certificateViewModel"></param>
        /// <returns></returns>
        string ProcessEditCertificateInfo(ICertificateViewModel certificateViewModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="certificateViewModelInfo"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        ICertificateViewModel getUpdatedView(ICertificateViewModel certificateViewModelInfo, string Message);

        /// <summary>
        /// getCertificateDelete
        /// </summary>
        /// <param name="certificateId"></param>
        /// <returns></returns>
        ICertificateViewModel DeleteCertById(int certificateId);

        /// <summary>
        /// Trigger Delete service
        /// </summary>
        /// <param name="certificateViewModelInfo"></param>
        /// <returns></returns>
        string DeleteCerrtificate(ICertificateViewModel certificateViewModelInfo);
    }
}
