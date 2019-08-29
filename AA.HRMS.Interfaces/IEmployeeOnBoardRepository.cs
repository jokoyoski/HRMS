using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IEmployeeOnBoardRepository
    {
        /// <summary>
        /// Deletes the on boarding.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        string DeleteOnBoarding(int employeeId);

        /// <summary>
        /// Gets the on boarder by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IEmployee GetOnBoarderById(int employeeId);

        /// <summary>
        /// Gets the employee by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        IEmployee GetEmployeeByEmail(string email);
        /// <summary>
        /// Gets the on boarder by company.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="lastName">The last name.</param>
        /// <returns></returns>
        IEmployee GetOnBoarderByCompany(int? companyId, string lastName);

        /// <summary>
        /// Saves the Promotion information.
        /// </summary>
        /// <param name="onboardInfo">The onboard information.</param>
        /// <returns></returns>
        string SavePromotionInfo(IPromotionView promotionView);

        /// <summary>
        /// Saves the on boarding information.
        /// </summary>
        /// <param name="onboardInfo">The onboard information.</param>
        /// <returns></returns>
        string SaveOnBoardingInfo(IEmployeeOnBoardView onboardInfo);

        /// <summary>
        /// Updates the on boarding information.
        /// </summary>
        /// <param name="onboardViewInfo">The onboard view information.</param>
        /// <returns></returns>
        string UpdateOnBoardingInfo(IEmployeeOnBoardView onboardViewInfo);

        /// <summary>
        /// Updates the promotion.
        /// </summary>
        /// <param name="promoteView">The promote view.</param>
        /// <returns></returns>
        string UpdatePromotion(IPromotionView promoteView);

        /// <summary>
        /// Gets the on boarder by email and staff number.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="email">The email.</param>
        /// <param name="staffNumber">The staff number.</param>
        /// <returns></returns>
        IEmployee GetOnBoarderByEmailAndStaffNumber(int? companyId, string email, string staffNumber);
        /// <summary>
        /// Updates the employee photo identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="photoId">The photo identifier.</param>
        /// <returns></returns>
        string UpdateEmployeePhotoId(IEmployee employee);

        /// <summary>
        /// Updates the on boarding lock information.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        string UpdateOnBoardingLockInfo(IEmployee employee);

        /// <summary>
        /// Gets all employee.
        /// </summary>
        /// <returns></returns>
        IList<IEmployee> GetAllEmployee();

        /// <summary>
        /// Gets the promotions by employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        IList<IPromotion> GetPromotionsByEmployeeId(int employeeId);

        /// <summary>
        /// Gets the promotions by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IPromotion> GetPromotionsByCompanyId(int companyId);
    }
}
