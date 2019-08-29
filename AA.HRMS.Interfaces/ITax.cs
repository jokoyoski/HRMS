using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ITax
    {
        /// <summary>
        /// Gets or sets the tax identifier.
        /// </summary>
        /// <value>
        /// The tax identifier.
        /// </value>
        int TaxId { get; set; }
        /// <summary>
        /// Gets or sets the annual income.
        /// </summary>
        /// <value>
        /// The annual income.
        /// </value>
        decimal AnnualIncome { get; set; }
        /// <summary>
        /// Gets or sets the tax rate.
        /// </summary>
        /// <value>
        /// The tax rate.
        /// </value>
        decimal TaxRate { get; set; }
    }
}
