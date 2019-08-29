using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEmployeeViewModelFactory
    {

        /// <summary>
        /// Generates the employee details from registration view.
        /// </summary>
        /// <param name="userRegistrationView">The user registration view.</param>
        /// <returns>
        /// IEmployeeView.
        /// </returns>
        IEmployeeView GenerateEmployeeDetailsFromRegistrationView(IUsersView userRegistrationView);


        ISpouseViewModel CreateSpouseView(int employeeId, string message);

        ISpouseViewModel CreateSpouseCreateView(ISpouseViewModel spouseViewModel, string processingMessage);

        ISpouseViewModel EditSpouseView(ISpouseModel spouseModel);



        IPromotionListView CreatePromotionListView(int employeeId, IList<IPromotion> promotionCollection, string message);

        IPromotionView CreatePromotionView(int companyId, IEmployee employee, IList<IPayScale> promotionCollection);

        IPromotionView CreatePromotionView(IPromotionView promotion, IEmployee employee, IList<IPayScale> promotionCollection, string message);
    }
}