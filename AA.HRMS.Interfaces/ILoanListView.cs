using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ILoanListView
    {
        /// <summary>
        /// Gets or sets the loan collection.
        /// </summary>
        /// <value>
        /// The loan collection.
        /// </value>
        IList<ILoan> LoanCollection { get; set; }

        /// <summary>
        /// Gets or sets the company information.
        /// </summary>
        /// <value>
        /// The company information.
        /// </value>
        ICompanyDetail Company { get; set; }

        /// <summary>
        /// Gets or sets the selected company identifier.
        /// </summary>
        /// <value>
        /// The selected company identifier.
        /// </value>
        int SelectedCompanyID { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
    }
}
