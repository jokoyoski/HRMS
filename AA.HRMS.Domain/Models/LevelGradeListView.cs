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
    /// <seealso cref="AA.HRMS.Interfaces.ILevelGradeListView" />
    public class LevelGradeListView : ILevelGradeListView
    {
        /// <summary>
        /// Gets or sets the selected level.
        /// </summary>
        /// <value>
        /// The selected level.
        /// </value>
        public string selectedLevel { get; set; }
        /// <summary>
        /// Gets or sets the selected grade.
        /// </summary>
        /// <value>
        /// The selected grade.
        /// </value>
        public string selectedGrade { get; set; }
        /// <summary>
        /// Gets or sets the selected company.
        /// </summary>
        /// <value>
        /// The selected company.
        /// </value>
        public string selectedCompany { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the level grade collection.
        /// </summary>
        /// <value>
        /// The level grade collection.
        /// </value>
        public IList<IPayScale> LevelGradeCollection { get; set; }
    }
}
