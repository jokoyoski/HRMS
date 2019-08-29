using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ILevelGradeListView
    {
        /// <summary>
        /// Gets or sets the selected level.
        /// </summary>
        /// <value>
        /// The selected level.
        /// </value>
        string selectedLevel { get; set; }
        /// <summary>
        /// Gets or sets the selected grade.
        /// </summary>
        /// <value>
        /// The selected grade.
        /// </value>
        string selectedGrade { get; set; }
        /// <summary>
        /// Gets or sets the selected company.
        /// </summary>
        /// <value>
        /// The selected company.
        /// </value>
        string selectedCompany { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the level grade collection.
        /// </summary>
        /// <value>
        /// The level grade collection.
        /// </value>
        IList<IPayScale> LevelGradeCollection { get; set; }
    }
}
