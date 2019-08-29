using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    public class TypeOfExitModel : ITypeOfExit
    {
        /// <summary>
        /// Gets or sets the type of exit identifier.
        /// </summary>
        /// <value>
        /// The type of exit identifier.
        /// </value>
        public int TypeOfExitId { get; set; }
        /// <summary>
        /// Gets or sets the name of the type of exit.
        /// </summary>
        /// <value>
        /// The name of the type of exit.
        /// </value>
        public string TypeOfExitName { get; set; }
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        public string CompanyName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
