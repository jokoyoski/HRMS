using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AA.HRMS.Domain.Models;
using AA.HRMS.Interfaces;
using System.Collections;
using AA.HRMS.Domain.Utilities;

namespace AA.HRMS.Domain.Factories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IEmployeeViewModelFactory" />
    public class EmployeeViewModelFactory : IEmployeeViewModelFactory
    {
        /// <summary>
        /// Generates the employee details from registration view.
        /// </summary>
        /// <param name="userRegistrationView">The user registration view.</param>
        /// <returns>
        /// IEmployeeView.
        /// </returns>
        /// <exception cref="ArgumentNullException">userRegistrationView</exception>
        public IEmployeeView GenerateEmployeeDetailsFromRegistrationView(IUsersView userRegistrationView)
        {
            if (userRegistrationView == null)
            {
                throw new ArgumentNullException(nameof(userRegistrationView));
            }

            var employeeView = new EmployeeView
            {
                FirstName = userRegistrationView.FirstName,
                LastName = userRegistrationView.LastName,
                StaffNumber = userRegistrationView.StaffNumber,
                CompanyId = userRegistrationView.CompanyId,
            };

            return employeeView;
        }

        public ISpouseViewModel CreateSpouseView (int employeeId, string message)
        {

            if (employeeId <= 0)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }

            var viewModel = new SpouseViewModel
            {
                EmployeeId = employeeId,
                ProcessingMessage = message
            };

            return viewModel;
        }

        public ISpouseViewModel CreateSpouseCreateView(ISpouseViewModel spouseViewModel, string processingMessage)
        {
            if (spouseViewModel == null) { throw new ArgumentNullException(nameof(spouseViewModel));}

            spouseViewModel.ProcessingMessage = processingMessage;
            return spouseViewModel;
        }

        /// <summary>
        /// Edits the spouse view.
        /// </summary>
        /// <param name="spouseModel">The spouse model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">spouseModel</exception>
        public ISpouseViewModel EditSpouseView(ISpouseModel spouseModel)
        {
            if (spouseModel == null)
            {
                throw new ArgumentNullException(nameof(spouseModel));
            }
            var viewModel = new SpouseViewModel
            {
                SpouseId = spouseModel.SpouseId,
                SpouseName = spouseModel.SpouseName,
                EmployeeId = spouseModel.EmployeeId,
                Email = spouseModel.Email,
                Address = spouseModel.Address,
                DateCreated = spouseModel.DateCreated,
                DateModified = spouseModel.DateModified,
                DateOfBirth = spouseModel.DateOfBirth,
                IsActive = spouseModel.IsActive,
                IsApproved = spouseModel.IsApproved,
                Mobile = spouseModel.Mobile,
                ProcessingMessage = string.Empty
            };

            return viewModel;
        }

        /// <summary>
        /// Creates the promotion ListView.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="promotionCollection">The promotion collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">promotionCollection</exception>
        public IPromotionListView CreatePromotionListView(int employeeId, IList<IPromotion> promotionCollection, string message)
        {
            if (promotionCollection == null) throw new ArgumentNullException(nameof(promotionCollection));

            var result = new PromotionListView
            {
                PromotionCollection = promotionCollection,
                ProcessMessage = message,
                EmployeeId = employeeId,
                
            };

            return result;
        }

        /// <summary>
        /// Creates the promotion view.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="employee">The employee.</param>
        /// <param name="payScaleCollection">The pay scale collection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">employee</exception>
        public IPromotionView CreatePromotionView(int companyId, IEmployee employee, IList<IPayScale> payScaleCollection)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee));

            var payScaleDDL = GetDropDownList.PayScaleListItem(payScaleCollection, -1);

            var result = new PromotionView
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.LastName + " " + employee.FirstName,
                PayScaleDropDown = payScaleDDL,
                CompanyId = companyId
            };

            return result;
        }

        /// <summary>
        /// Creates the promotion view.
        /// </summary>
        /// <param name="promotion">The promotion.</param>
        /// <param name="payScaleCollection">The pay scale collection.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">promotion</exception>
        public IPromotionView CreatePromotionView(IPromotionView promotion, IEmployee employee, IList<IPayScale> payScaleCollection, string message)
        {
            if (promotion == null) throw new ArgumentNullException(nameof(promotion));

            var payScaleDDL = GetDropDownList.PayScaleListItem(payScaleCollection, promotion.PayScaleId);

            promotion.EmployeeId = employee.EmployeeId;
            promotion.EmployeeName = employee.LastName + " " + employee.FirstName;
            promotion.PayScaleDropDown = payScaleDDL;
            promotion.ProcessingMessage = message;

            return promotion;
        }
    }
}