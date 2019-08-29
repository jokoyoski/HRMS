using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ICurrency
    {
        /// <summary>
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>
        /// The currency identifier.
        /// </value>
        int CurrencyId { get; set; }
        /// <summary>
        /// Gets or sets the currency1.
        /// </summary>
        /// <value>
        /// The currency1.
        /// </value>
        string Currency1 { get; set; }
    }
}
