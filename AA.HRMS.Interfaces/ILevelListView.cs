using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    public interface ILevelListView
    {

        /// <summary>
        /// Gets or sets the level collection.
        /// </summary>
        /// <value>
        /// The level collection.
        /// </value>
        IList<ILevel> LevelCollection { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        ICompanyDetail Company { get; set; }
        /// <summary>
        /// 
        /// </summary>
        IList<SelectListItem> CompanyDropDown { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }

        /// <summary>
        /// Gets or sets the selected company.
        /// </summary>
        /// <value>
        /// The selected company.
        /// </value>
        string SelectedLevel { get; set; }
    }
}
