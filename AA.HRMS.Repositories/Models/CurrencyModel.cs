using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.ICurrency" />
    public class CurrencyModel : ICurrency
    {
        public int CurrencyId { get; set; }
        /// <summary>
        /// Gets or sets the currency1.
        /// </summary>
        /// <value>
        /// The currency1.
        /// </value>
        public string Currency1 { get; set; }
    }
}
