using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.ILevelListView" />
    public class LevelListView : ILevelListView
    {

        /// <summary>
        /// Gets or sets the level collection.
        /// </summary>
        /// <value>
        /// The level collection.
        /// </value>
        public IList<ILevel> LevelCollection { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        public ICompanyDetail Company { get; set; }
        /// <summary>
        /// </summary>
        public IList<SelectListItem> CompanyDropDown { get; set; }

        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        public string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the selected company.
        /// </summary>
        /// <value>
        /// The selected company.
        /// </value>
        public string SelectedLevel { get; set; }

    }
}
