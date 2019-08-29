using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    public class LoanListView : ILoanListView
    {
        /// <summary>
        /// Gets or sets the loan collection.
        /// </summary>
        /// <value>
        /// The loan collection.
        /// </value>
        public IList<ILoan> LoanCollection { get; set; }

        /// <summary>
        /// Gets or sets the company information.
        /// </summary>
        /// <value>
        /// The company information.
        /// </value>
        public ICompanyDetail Company { get; set; }

        /// <summary>
        /// Gets or sets the selected company identifier.
        /// </summary>
        /// <value>
        /// The selected company identifier.
        /// </value>
        public int SelectedCompanyID { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
    }
}
