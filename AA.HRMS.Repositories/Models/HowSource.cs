using AA.HRMS.Interfaces;

namespace AA.HRMS.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.IHowSource" />
    public class HowSource: IHowSource
    {
        /// <summary>
        /// Gets or sets the about us source identifier.
        /// </summary>
        /// <value>
        /// The about us source identifier.
        /// </value>
        public int AboutUsSourceId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}
