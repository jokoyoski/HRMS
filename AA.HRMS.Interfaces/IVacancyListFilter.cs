using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IVacancyListFilter
    {
        /// <summary>
        /// Gets or sets the selected vacancy identifier.
        /// </summary>
        /// <value>
        /// The selected vacancy identifier.
        /// </value>
        int SelectedVacancyId { get; set; }

        /// <summary>
        /// Gets or sets the name of the selected job.
        /// </summary>
        /// <value>
        /// The name of the selected job.
        /// </value>
        string SelectedJobName { get; set; }

        /// <summary>
        /// Gets or sets the selected company identifier.
        /// </summary>
        /// <value>
        /// The selected company identifier.
        /// </value>
        int SelectedCompanyId { get; set; }

        /// <summary>
        /// Gets or sets the selected department identifier.
        /// </summary>
        /// <value>
        /// The selected department identifier.
        /// </value>
        int SelectedDepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the selected job title identifier.
        /// </summary>
        /// <value>
        /// The selected job title identifier.
        /// </value>
        int SelectedJobTitleId { get; set; }

        /// <summary>
        /// Gets or sets the selected grade identifier.
        /// </summary>
        /// <value>
        /// The selected grade identifier.
        /// </value>
        int SelectedGradeId { get; set; }

    }
}
