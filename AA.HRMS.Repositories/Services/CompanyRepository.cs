using System;
using System.Collections.Generic;
using System.Linq;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Factories;
using AA.HRMS.Repositories.Queries;

namespace AA.HRMS.Repositories.Services
{
    public class CompanyRepository : ICompanyRepository
    {
        
        private readonly IDbContextFactory dbContextFactory;
        
        public CompanyRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory ?? new DbContextFactory(null);
        }
        
        /// <summary>
        /// Gets all company.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository Get All Company</exception>
        public IList<ICompanyDetail> GetAllCompany()
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = CompanyQueries.getCompanyList(dbContext).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get All Company", e);
            }
        }

        /// <summary>
        /// Gets the companies for hr.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository Get All Companies for HR</exception>
        public IList<ICompanyDetail> GetCompaniesForHR(string username)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                { 
                    var list = CompanyQueries.getCompanyForHRList(dbContext, username).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get All Companies for HR", e);
            }
        }

        /// <summary>
        /// Deletes the company information.
        /// </summary>
        /// <param name="companyInfo">The company information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyInfo</exception>
        /// <exception cref="System.ArgumentNullException">companyInfo</exception>
        public string DeleteCompanyInfo(ICompanyRegistrationView companyInfo)
        {
            if (companyInfo == null) throw new ArgumentNullException(nameof(companyInfo));

            var result = string.Empty;


            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var companyData =
                        dbContext.Companies.SingleOrDefault(m => m.CompanyId.Equals(companyInfo.CompanyId));
                    companyData.IsActive = false;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Update Company - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Saves the company registration information.
        /// </summary>
        /// <param name="companyInfo">The company information.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        /// <exception cref="ArgumentNullException">companyInfo</exception>
        public string SaveCompanyRegistrationInfo(ICompanyRegistrationView companyInfo, out int companyId)
        {
            if (companyInfo == null)
            {
                throw new ArgumentNullException(nameof(companyInfo));
            }

            var result = string.Empty;

            var newRecord = new Company
            {
                CompanyAddressLine1 = companyInfo.CompanyAddressLine1,
                CompanyAddressLine2 = companyInfo.CompanyAddressLine2,
                CompanyCity = companyInfo.CompanyCity,
                IsActive = companyInfo.IsActive,
                CompanyEmail = companyInfo.CompanyEmail,
                CompanyCountryId = companyInfo.CompanyCountryId, 
                DateCreated = DateTime.Now,
                LogoDigitalFileId = companyInfo.LogoDigitalFileId,
                CompanyName = companyInfo.CompanyName,
                CompanyPhone = companyInfo.CompanyPhone,
                CompanyState = companyInfo.CompanyState,
                CompanyWebsite = companyInfo.CompanyWebsite,
                CompanyZipCode = companyInfo.CompanyZipCode,
                ParentCompanyId = companyInfo.ParentCompanyId,
                CACRegistrationNumber = companyInfo.CACRegistrationNumber,
                CompanyAlias = companyInfo.CompanyAlias,
                IndustryId = companyInfo.IndustryId,
                
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Companies.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                var a = e;

                result = string.Format("SaveCompanyRegistrationInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }


            companyId = newRecord.CompanyId;

            return result;
        }


        /// <summary>
        /// Gets the company by identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetCompanyID</exception>
        public ICompanyDetail GetCompanyById(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var companyInfo = CompanyQueries.getCompanyById(dbContext, companyId);

                    return companyInfo;
                }
            }
            catch (Exception e)
            {
                

                throw new ApplicationException("Repository GetCompanyID", e);
            }
        }

        /// <summary>
        /// Updates the company registration information.
        /// </summary>
        /// <param name="companyInfo">The company information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">companyInfo</exception>
        public string UpdateCompanyRegistrationInfo(ICompanyRegistrationView companyInfo)
        {
            if (companyInfo == null)
            {
                throw new ArgumentNullException(nameof(companyInfo));
            }

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = dbContext.Companies.FirstOrDefault(x => x.CompanyId.Equals(companyInfo.CompanyId));
                    aRecord.CACRegistrationNumber = companyInfo.CACRegistrationNumber;
                    aRecord.CompanyName = companyInfo.CompanyName;
                    aRecord.CompanyAddressLine1 = companyInfo.CompanyAddressLine1;
                    aRecord.CompanyAddressLine2 = companyInfo.CompanyAddressLine2;
                    aRecord.CompanyCity = companyInfo.CompanyCity;
                    aRecord.CompanyState = companyInfo.CompanyState;
                    aRecord.CompanyCountryId = companyInfo.CompanyCountryId;
                    aRecord.CompanyZipCode = companyInfo.CompanyZipCode;
                    aRecord.CompanyEmail = companyInfo.CompanyEmail;
                    aRecord.CompanyPhone = companyInfo.CompanyPhone;
                    aRecord.CompanyWebsite = companyInfo.CompanyWebsite;
                    aRecord.LogoDigitalFileId = companyInfo.LogoDigitalFileId;
                    aRecord.ParentCompanyId = companyInfo.ParentCompanyId;
                    aRecord.CompanyAlias = companyInfo.CompanyAlias;
                    aRecord.IndustryId = companyInfo.IndustryId;
                    

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                var a = e;

                result = string.Format("UpdateCompanyRegistrationInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Gets the company by cac number.
        /// </summary>
        /// <param name="CACNumber">The cac number.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetCompanyByCACRegistrationNumber</exception>
        /// <exception cref="System.ApplicationException">Repository GetCompanyByCACRegistrationNumber</exception>
        public ICompanyDetail GetCompanyByCACNumber(string CACNumber)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var companyInfo = CompanyQueries.getCompanyByCACNumber(dbContext, CACNumber);

                    return companyInfo;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetCompanyByCACRegistrationNumber", e);
            }
        }
        
        /// <summary>
        /// Gets my companies.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository Get All Company</exception>
        public IList<ICompanyDetail> GetMyCompanies(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = CompanyQueries.getMyCompaniesList(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get My Companies", e);
            }
        }
        
        /// <summary>
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository getDeductionByCompanyId</exception>
        public IList<ICompanyDetail> getDeductionByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = CompanyQueries.getMyCompaniesList(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository getDeductionByCompanyId", e);
            }
        }
    }
}