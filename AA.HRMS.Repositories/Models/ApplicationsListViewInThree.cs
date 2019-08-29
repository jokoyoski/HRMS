using AA.HRMS.Interfaces;

namespace AA.HRMS.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IApplicationsListInThrees" />
    public class ApplicationsListViewInThree : IApplicationsListInThrees
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationsListViewInThree"/> class.
        /// </summary>
        public ApplicationsListViewInThree()
        {
            this.ColumnOne = new ApplicationsModel();
            this.ColumnTwo = new ApplicationsModel();
            this.ColumnThree = new ApplicationsModel();
        }


        /// <summary>
        /// Gets or sets the column one.
        /// </summary>
        /// <value>
        /// The column one.
        /// </value>
        public IApplicationModel ColumnOne { get; set; }


        /// <summary>
        /// Gets or sets the column two.
        /// </summary>
        /// <value>
        /// The column two.
        /// </value>
        public IApplicationModel ColumnTwo { get; set; }


        /// <summary>
        /// Gets or sets the column three.
        /// </summary>
        /// <value>
        /// The column three.
        /// </value>
        public IApplicationModel ColumnThree { get; set; }
    }
}