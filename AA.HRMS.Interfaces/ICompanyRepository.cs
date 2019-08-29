using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICompanyRepository
    {
        /// <summary>
        /// Gets all company.
        /// </summary>
        /// <returns></returns>
        IList<ICompanyDetail> GetAllCompany();

        // Get's all the companies (parents and children) that are managed by HR
        // with the given username
        IList<ICompanyDetail> GetCompaniesForHR(string username); 

        /// <summary>
        /// Saves the company registration information.
        /// </summary>
        /// <param name="companyInfo">The company information.</param>
        /// <returns></returns>
        string SaveCompanyRegistrationInfo(ICompanyRegistrationView companyInfo, out int companyId);

        /// <summary>
        /// Deletes the company information.
        /// </summary>
        /// <param name="companyInfo">The company information.</param>
        /// <returns></returns>
        string DeleteCompanyInfo(ICompanyRegistrationView companyInfo);

        /// <summary>
        /// Gets the company by identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        ICompanyDetail GetCompanyById(int companyId);

        /// <summary>
        /// Updates the company registration information.
        /// </summary>
        /// <param name="companyRegistrationInfo">The company registration information.</param>
        /// <returns></returns>
        string UpdateCompanyRegistrationInfo(ICompanyRegistrationView companyRegistrationInfo);

        /// <summary>
        /// Gets the company by cac number.
        /// </summary>
        /// <param name="CACNumber">The cac number.</param>
        /// <returns></returns>
        ICompanyDetail GetCompanyByCACNumber(string CACNumber);


        /// <summary>
        /// Gets my companies.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<ICompanyDetail> GetMyCompanies(int companyId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        IList<ICompanyDetail> getDeductionByCompanyId(int companyId);
       
    }
}