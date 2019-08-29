using System.Collections.Generic;

namespace AA.HRMS.Interfaces
{
    public interface IApplicationsListView
    {
        /// <summary>
        /// Gets or sets the applications collections.
        /// </summary>
        /// <value>
        /// The applications collections.
        /// </value>
        IList<IApplicationsListInThrees> ApplicationsCollections { get; set; }

        /// <summary>
        /// Gets or sets the processing mesage.
        /// </summary>
        /// <value>
        /// The processing mesage.
        /// </value>
        string ProcessingMesage { get; set; }
    }
}