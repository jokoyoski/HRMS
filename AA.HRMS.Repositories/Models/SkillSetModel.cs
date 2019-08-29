using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.ISkillSetModel" />
    public class SkillSetModel : ISkillSetModel
    {
        /// <summary>
        /// Gets or sets the skill identifier.
        /// </summary>
        /// <value>
        /// The skill identifier.
        /// </value>
        public int SkillId { get; set; }

        /// <summary>
        /// Gets or sets the name of the skill.
        /// </summary>
        /// <value>
        /// The name of the skill.
        /// </value>
        public string SkillName { get; set; }

        /// <summary>
        /// Gets or sets the skill description.
        /// </summary>
        /// <value>
        /// The skill description.
        /// </value>
        public string SkillDescription { get; set; }

        /// <summary>
        /// Gets or sets the date creaed.
        /// </summary>
        /// <value>
        /// The date creaed.
        /// </value>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the experience.
        /// </summary>
        /// <value>
        /// The experience.
        /// </value>
        public int? Experience { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }


        /// <summary>
        /// Gets or sets the name of the experience.
        /// </summary>
        /// <value>
        /// The name of the experience.
        /// </value>
        public string ExperienceName { get; set; }
    }
}