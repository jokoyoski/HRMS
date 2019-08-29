using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IPaySlipViewModel
    {
        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        /// <value>
        /// The employee.
        /// </value>
        IEmployee Employee { get; set; }
        /// <summary>
        /// Gets or sets the payroll.
        /// </summary>
        /// <value>
        /// The payroll.
        /// </value>
        IPayroll Payroll { get; set; }
        /// <summary>
        /// Gets or sets the reward.
        /// </summary>
        /// <value>
        /// The reward.
        /// </value>
        IList<IPayrollEmployeeReward> Reward { get; set; }
        /// <summary>
        /// Gets or sets the employee deduction.
        /// </summary>
        /// <value>
        /// The employee deduction.
        /// </value>
        IList<IPayrollEmployeeDeduction> EmployeeDeduction { get; set; }
        /// <summary>
        /// Gets or sets the loan.
        /// </summary>
        /// <value>
        /// The loan.
        /// </value>
        IList<IPayrollEmployeeLoan> Loan { get; set; }
        /// <summary>
        /// Gets or sets the benefit.
        /// </summary>
        /// <value>
        /// The benefit.
        /// </value>
        IPayScale PayScale { get; set; }
        /// <summary>
        /// Gets or sets the pay scale collection.
        /// </summary>
        /// <value>
        /// The pay scale collection.
        /// </value>
        IList<IPayScaleBenefit> PayScaleCollection { get; set; }
        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        ILevel Level { get; set; }
        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>
        /// The grade.
        /// </value>
        IGrade Grade { get; set; }
        /// <summary>
        /// Gets or sets the company detail.
        /// </summary>
        /// <value>
        /// The company detail.
        /// </value>
        ICompanyDetail CompanyDetail { get; set; }
        /// <summary>
        /// Gets or sets the taxation amount.
        /// </summary>
        /// <value>
        /// The taxation amount.
        /// </value>
        decimal TaxationAmount { get; set; }
        /// <summary>
        /// Gets or sets the digital file.
        /// </summary>
        /// <value>
        /// The digital file.
        /// </value>
        IDigitalFile CompanyLogo { get; set; }
        /// <summary>
        /// Gets or sets the tax rate.
        /// </summary>
        /// <value>
        /// The tax rate.
        /// </value>
        decimal TaxRate { get; set; }

        /// <summary>
        /// Gets or sets the pension contribution.
        /// </summary>
        /// <value>
        /// The pension contribution.
        /// </value>
        decimal PensionContribution { get; set; }

        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>
        /// The children.
        /// </value>
        decimal Children { get; set; }

        /// <summary>
        /// Gets or sets the dependant.
        /// </summary>
        /// <value>
        /// The dependant.
        /// </value>
        decimal Dependant { get; set; }

        /// <summary>
        /// Gets or sets the tax collation.
        /// </summary>
        /// <value>
        /// The tax collation.
        /// </value>
        decimal TaxCollation { get; set; }
    }
}
