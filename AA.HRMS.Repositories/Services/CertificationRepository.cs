using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Models;
using AA.HRMS.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Services
{
    public class CertificationRepository : ICertificationRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContextFactory"></param>
        public CertificationRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        /// <summary>
        /// </summary>
        /// <param name="CertId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// CertId
        /// or
        /// Get Certificate Repository Error, e
        /// </exception>
        public IList<ICertificationModel> GetCertificateById(int CertId)
        {
            if (CertId <= 0) throw new ArgumentNullException(nameof(CertId));

            try
            {
                using (
                    var dbcontext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = CertificateQueries.getCertificateById(dbcontext, CertId).ToList();
                    return result;
                }
            }
                catch (Exception e)
                {
                throw new ArgumentNullException("Get Certificate Repository Error, e");
            
                }
        }
        /// <summary>
        /// </summary>
        /// <param name="Certinfo"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Certinfo</exception>
        public string SaveCertificateInfo (ICertificateViewModel Certinfo)
        {
            if (Certinfo == null)
            {
                throw new ArgumentNullException(nameof(Certinfo));
            }

            var empty = string.Empty;

            var insertToDb = new Certification
            {
                Certificate_Name= Certinfo.CertificationName,
                Description = Certinfo.Description,
                Year = Certinfo.Year,
                UserId = Certinfo.UserId

            };
            try
            {
                using (
                    var result = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    result.Certifications.Add(insertToDb);
                    result.SaveChanges();

                }
            }
                catch(Exception e)
            {
                empty = string.Format("save certificate info", e.Message, e.InnerException != null ? e.InnerException.Message : "");
            
            }
            return empty;
        }

        /// <summary>
        /// updateView
        /// </summary>
        /// <param name="CertInfo"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">CertInfo</exception>
        public string SaveEditCertInfo(ICertificateViewModel CertInfo)
        {
            if (CertInfo == null)
            {
                throw new ArgumentNullException(nameof(CertInfo));
            }

            string result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var modelInfo = dbContext.Certifications.SingleOrDefault(p => p.CertificateId == CertInfo.CertificationId);

                   

                        modelInfo.CertificateId = CertInfo.CertificationId;
                        modelInfo.Certificate_Name = CertInfo.CertificationName;
                        modelInfo.Description = CertInfo.Description;
                        modelInfo.Year = CertInfo.Year;
                        modelInfo.UserId = CertInfo.UserId;

                        
                    
                    dbContext.SaveChanges();


                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Edit Certificate info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="CertId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Certificate Repository Error, e</exception>
        public ICertificationModel GetCertificationById(int CertId)
        {
            
            try
            {
                using (
                    var dbcontext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    
                       var result = CertificateQueries.getCertId(dbcontext, CertId);
                    return result;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Certificate Repository Error, e");

            }
        }

        /// <summary>
        /// Deletes the certificate information.
        /// </summary>
        /// <param name="certInfo">The cert information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">certInfo</exception>
        public string DeleteCertificateInfo(ICertificateViewModel certInfo)
        {
            if (certInfo == null)
            {
                throw new ArgumentNullException(nameof(certInfo));
            }
            string empty = string.Empty;

            try
            {
                using (
                    var result = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var insertToDb = result.Certifications.SingleOrDefault(p => p.CertificateId.Equals(certInfo.CertificationId));

                    result.Certifications.Remove(insertToDb);

                    result.SaveChanges();

                }
            }
            catch (Exception e)
            {
                empty = string.Format("save certificate info", e.Message, e.InnerException != null ? e.InnerException.Message : "");

            }
            return empty;
        }
    }
}
