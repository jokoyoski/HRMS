namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IApplicationsListInThrees
    {
        /// <summary>
        /// Gets or sets the column one.
        /// </summary>
        /// <value>
        /// The column one.
        /// </value>
        IApplicationModel ColumnOne { get; set; }


        /// <summary>
        /// Gets or sets the column two.
        /// </summary>
        /// <value>
        /// The column two.
        /// </value>
        IApplicationModel ColumnTwo { get; set; }


        /// <summary>
        /// Gets or sets the column three.
        /// </summary>
        /// <value>
        /// The column three.
        /// </value>
        IApplicationModel ColumnThree { get; set; }
    }
}