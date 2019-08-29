using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    public class PaySlipViewModel : IPaySlipViewModel
    {

        public PaySlipViewModel()
        {
            this.Reward = new List<IPayrollEmployeeReward>();
            this.EmployeeDeduction = new List<IPayrollEmployeeDeduction>();
            this.Loan = new List<IPayrollEmployeeLoan>();
            this.PayScaleCollection = new List<IPayScaleBenefit>();
        }
        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>
        /// The employee.
        /// </value>
        public IEmployee Employee { get; set; }

        /// <summary>
        /// Gets or sets the payroll.
        /// </summary>
        /// <value>
        /// The payroll.
        /// </value>
        public IPayroll Payroll { get; set; }

        /// <summary>
        /// Gets or sets the reward.
        /// </summary>
        /// <value>
        /// The reward.
        /// </value>
        public IList<IPayrollEmployeeReward> Reward { get; set; }

        /// <summary>
        /// Gets or sets the employee deduction.
        /// </summary>
        /// <value>
        /// The employee deduction.
        /// </value>
        public IList<IPayrollEmployeeDeduction> EmployeeDeduction { get; set; }

        /// <summary>
        /// Gets or sets the loan.
        /// </summary>
        /// <value>
        /// The loan.
        /// </value>
        public IList<IPayrollEmployeeLoan> Loan { get; set; }

        /// <summary>
        /// Gets or sets the benefit.
        /// </summary>
        /// <value>
        /// The benefit.
        /// </value>
        public IPayScale PayScale { get; set; }
        /// <summary>
        /// Gets or sets the pay scale collection.
        /// </summary>
        /// <value>
        /// The pay scale collection.
        /// </value>
        public IList<IPayScaleBenefit> PayScaleCollection { get; set; }
        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        public ILevel Level { get; set; }
        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>
        /// The grade.
        /// </value>
        public IGrade Grade { get; set; }
        /// <summary>
        /// Gets or sets the company detail.
        /// </summary>
        /// <value>
        /// The company detail.
        /// </value>
        public ICompanyDetail CompanyDetail { get; set; }
        /// <summary>
        /// Gets or sets the digital file.
        /// </summary>
        /// <value>
        /// The digital file.
        /// </value>
        public IDigitalFile CompanyLogo { get; set; }
        /// <summary>
        /// Gets or sets the taxation amount.
        /// </summary>
        /// <value>
        /// The taxation amount.
        /// </value>
        public decimal TaxationAmount { get; set; }
        /// <summary>
        /// Gets or sets the tax rate.
        /// </summary>
        /// <value>
        /// The tax rate.
        /// </value>
        public decimal TaxRate { get; set; }

        /// <summary>
        /// Gets or sets the pension contribution.
        /// </summary>
        /// <value>
        /// The pension contribution.
        /// </value>
        public decimal PensionContribution { get; set; }

        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>
        /// The children.
        /// </value>
        public decimal Children { get; set; }

        /// <summary>
        /// Gets or sets the dependant.
        /// </summary>
        /// <value>
        /// The dependant.
        /// </value>
        public decimal Dependant { get; set; }

        /// <summary>
        /// Gets or sets the tax collation.
        /// </summary>
        /// <value>
        /// The tax collation.
        /// </value>
        public decimal TaxCollation { get; set; }
    }
}
