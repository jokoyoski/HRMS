namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHowSource
    {
        /// <summary>
        /// Gets or sets the about us source identifier.
        /// </summary>
        /// <value>
        /// The about us source identifier.
        /// </value>
        int AboutUsSourceId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }
    }
}
