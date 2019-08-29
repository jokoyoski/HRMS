using System.Collections.Generic;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Repositories.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IApplicationsListView" />
    public class ApplicationsListView : IApplicationsListView
    {
        /// <summary>
        /// Gets or sets the applications collections.
        /// </summary>
        /// <value>
        /// The applications collections.
        /// </value>
        public IList<IApplicationsListInThrees> ApplicationsCollections { get; set; }


        /// <summary>
        /// Gets or sets the processing mesage.
        /// </summary>
        /// <value>
        /// The processing mesage.
        /// </value>
        public string ProcessingMesage { get; set; }
    }
}