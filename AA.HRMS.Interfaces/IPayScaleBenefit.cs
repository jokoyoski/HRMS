using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IPayScaleBenefit
    {
        /// <summary>
        /// Gets or sets the pay scale benefit identifier.
        /// </summary>
        /// <value>
        /// The pay scale benefit identifier.
        /// </value>
        int PayScaleBenefitId { get; set; }
        /// <summary>
        /// Gets or sets the benefit identifier.
        /// </summary>
        /// <value>
        /// The benefit identifier.
        /// </value>
        int BenefitId { get; set; }
        /// <summary>
        /// Gets or sets the name of the benefit.
        /// </summary>
        /// <value>
        /// The name of the benefit.
        /// </value>
        string BenefitName { get; set; }
        /// <summary>
        /// Gets or sets the percentageof base.
        /// </summary>
        /// <value>
        /// The percentageof base.
        /// </value>
        decimal PercentageofBase { get; set; }
        /// <summary>
        /// Gets or sets the cash value.
        /// </summary>
        /// <value>
        /// The cash value.
        /// </value>
        decimal CashValue { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the date modified.
        /// </summary>
        /// <value>
        /// The date modified.
        /// </value>
        DateTime? DateModified { get; set; }
        /// <summary>
        /// Gets or sets the pay scale identifier.
        /// </summary>
        /// <value>
        /// The pay scale identifier.
        /// </value>
        int PayScaleId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is monetized.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is monetized; otherwise, <c>false</c>.
        /// </value>
        bool IsMonetized { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is taxable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is taxable; otherwise, <c>false</c>.
        /// </value>
        bool IsTaxable { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is selected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is selected; otherwise, <c>false</c>.
        /// </value>
        bool isSelected { get; set; }
        /// <summary>
        /// Gets or sets the period.
        /// </summary>
        /// <value>
        /// The period.
        /// </value>
        string Period { get; set; }
    }
}
