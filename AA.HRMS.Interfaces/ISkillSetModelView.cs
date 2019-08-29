using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISkillSetModelView
    {
        /// <summary>
        /// Gets or sets the skill identifier.
        /// </summary>
        /// <value>
        /// The skill identifier.
        /// </value>
        int SkillId { get; set; }
        /// <summary>
        /// Gets or sets the name of the skill.
        /// </summary>
        /// <value>
        /// The name of the skill.
        /// </value>
        string SkillName { get; set; }
        /// <summary>
        /// Gets or sets the skill description.
        /// </summary>
        /// <value>
        /// The skill description.
        /// </value>
        string SkillDescription { get; set; }
        /// <summary>
        /// Gets or sets the date creaed.
        /// </summary>
        /// <value>
        /// The date creaed.
        /// </value>
        DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        int EmployeeId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the processing message.
        /// </summary>
        /// <value>
        /// The processing message.
        /// </value>
        string ProcessingMessage { get; set; }
        /// <summary>
        /// Gets or sets the experience drop down.
        /// </summary>
        /// <value>
        /// The experience drop down.
        /// </value>
        IList<SelectListItem> ExperienceDropDown { get; set; }
        /// <summary>
        /// Gets or sets the experience.
        /// </summary>
        /// <value>
        /// The experience.
        /// </value>
        int? Experience { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        string URL { get; set; }
    }
}
