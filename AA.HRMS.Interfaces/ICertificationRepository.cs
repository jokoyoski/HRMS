using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
   public  interface ICertificationRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CertId"></param>
        /// <returns></returns>
        IList<ICertificationModel> GetCertificateById(int CertId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Certinfo"></param>
        /// <returns></returns>
        string SaveCertificateInfo(ICertificateViewModel Certinfo);

        /// <summary>
        /// updateView
        /// </summary>
        /// <param name="CertInfo"></param>
        /// <returns></returns>
        string SaveEditCertInfo(ICertificateViewModel CertInfo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CertId"></param>
        /// <returns></returns>
        ICertificationModel GetCertificationById(int CertId);

        /// <summary>
        /// Delete Certificate
        /// </summary>
        /// <param name="Certinfo"></param>
        /// <returns></returns>
        string DeleteCertificateInfo(ICertificateViewModel Certinfo);
    }
}
