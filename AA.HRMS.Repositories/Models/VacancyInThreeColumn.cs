using System.Collections.Generic;
using AA.HRMS.Interfaces;

namespace AA.HRMS.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IVacancyInThreeColumns" />
    public class VacancyInThreeColumn : IVacancyInThreeColumns
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VacancyInThreeColumn"/> class.
        /// </summary>
        public VacancyInThreeColumn()
        {
            this.Column1 = new VacancyDetail();
            this.Column2 = new VacancyDetail();
            this.Column3 = new VacancyDetail();
        }

        /// <summary>
        /// Gets or sets the column1.
        /// </summary>
        /// <value>
        /// The column1.
        /// </value>
        public IVacancyDetail Column1 { get; set; }

        /// <summary>
        /// Gets or sets the column2.
        /// </summary>
        /// <value>
        /// The column2.
        /// </value>
        public IVacancyDetail Column2 { get; set; }

        /// <summary>
        /// Gets or sets the column3.
        /// </summary>
        /// <value>
        /// The column3.
        /// </value>
        public IVacancyDetail Column3 { get; set; }
    }
}