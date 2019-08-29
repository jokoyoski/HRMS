using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IVacancyListFilter" />
    public class VacancyListFilter : IVacancyListFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VacancyListFilter"/> class.
        /// </summary>
        public VacancyListFilter()
        {
            this.SelectedVacancyId = -1;
            this.SelectedJobName = string.Empty;
            this.SelectedCompanyId = -1;
            this.SelectedDepartmentId = -1;
            this.SelectedJobTitleId = -1;
            this.SelectedGradeId = -1;
        }

        /// <summary>
        /// Gets or sets the selected vacancy identifier.
        /// </summary>
        /// <value>
        /// The selected vacancy identifier.
        /// </value>
        public int SelectedVacancyId { get; set; }

        /// <summary>
        /// Gets or sets the name of the selected job.
        /// </summary>
        /// <value>
        /// The name of the selected job.
        /// </value>
        public string SelectedJobName { get; set; }

        /// <summary>
        /// Gets or sets the selected company identifier.
        /// </summary>
        /// <value>
        /// The selected company identifier.
        /// </value>
        public int SelectedCompanyId { get; set; }

        /// <summary>
        /// Gets or sets the selected department identifier.
        /// </summary>
        /// <value>
        /// The selected department identifier.
        /// </value>
        public int SelectedDepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the selected job title identifier.
        /// </summary>
        /// <value>
        /// The selected job title identifier.
        /// </value>
        public int SelectedJobTitleId { get; set; }

        /// <summary>
        /// Gets or sets the selected grade identifier.
        /// </summary>
        /// <value>
        /// The selected grade identifier.
        /// </value>
        public int SelectedGradeId { get; set; }

    }
}
