namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IVacancyInThreeColumns
    {
        /// <summary>
        /// Gets or sets the column1.
        /// </summary>
        /// <value>
        /// The column1.
        /// </value>
        IVacancyDetail Column1 { get; set; }

        /// <summary>
        /// Gets or sets the column2.
        /// </summary>
        /// <value>
        /// The column2.
        /// </value>
        IVacancyDetail Column2 { get; set; }

        /// <summary>
        /// Gets or sets the column3.
        /// </summary>
        /// <value>
        /// The column3.
        /// </value>
        IVacancyDetail Column3 { get; set; }

    }
}