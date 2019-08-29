using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Queries
{
    /// <summary>
    /// 
    /// </summary>
    internal static class CertificateQueries
        {
            internal static IEnumerable<ICertificationModel> getCertificateById(HRMSEntities db, int CertId)
            {
                    var result = (from d in db.Certifications
                          join s in db.Users on d.UserId equals s.UserId
                          where d.UserId.Equals(CertId)
                          select new Models.CertificationModel
                          {
                              CertificationId = d.CertificateId,
                              CertificationName = d.Certificate_Name,
                              Description = d.Description,
                              Year = d.Year,
                              UserId = s.UserId,
                              UserName = s.FirstName + " " + s.LastName
                                  

                             }).ToList();
                             return result;
            }
        /// <summary>
        /// Gets the certification by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="CertId">The cert identifier.</param>
        /// <returns></returns>
        internal static ICertificationModel getCertificationById(HRMSEntities db, int CertId)
        {
            var result = (from d in db.Certifications
                          join s in db.Users on d.UserId equals s.UserId
                          where d.UserId.Equals(CertId)
                          select new Models.CertificationModel
                          {
                              CertificationId = d.CertificateId,
                              CertificationName = d.Certificate_Name,
                              Description = d.Description,
                              Year = d.Year,
                              UserId = s.UserId,
                              UserName = s.FirstName + " " + s.LastName

                              

                          }).FirstOrDefault();
            return result;
        }
        /// <summary>
        /// Gets the cert identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="certificateId">The certificate identifier.</param>
        /// <returns></returns>
        internal static ICertificationModel getCertId(HRMSEntities db, int certificateId)
        {
            var result = (from d in db.Certifications
                          where d.CertificateId.Equals(certificateId)
                          select new Models.CertificationModel
                          {
                              CertificationId = d.CertificateId,
                              CertificationName = d.Certificate_Name,
                              Description = d.Description,
                              Year = d.Year,
                              UserId = d.UserId
                          }).FirstOrDefault();
            return result;
        }
    }
    
}
