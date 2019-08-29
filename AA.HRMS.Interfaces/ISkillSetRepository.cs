using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISkillSetRepository
    {
        /// <summary>
        /// Gets the skill set by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        IList<ISkillSetModel> GetSkillSetByUserId(int userId);
        /// <summary>
        /// Gets the skill set by identifier.
        /// </summary>
        /// <param name="skillSetId">The skill set identifier.</param>
        /// <returns></returns>
        ISkillSetModel GetSkillSetById(int skillSetId);
        /// <summary>
        /// Saves the skill set information.
        /// </summary>
        /// <param name="skillSetInfo">The skill set information.</param>
        /// <returns></returns>
        string SaveSkillSetInfo(ISkillSetModelView skillSetInfo);

        /// <summary>
        /// Deletes the skill set information.
        /// </summary>
        /// <param name="skillSetId">The skill set identifier.</param>
        /// <returns></returns>
        string DeleteSkillSetInfo(int skillSetId);

        /// <summary>
        /// Updates the skill set information.
        /// </summary>
        /// <param name="skillSetInfo">The skill set information.</param>
        /// <returns></returns>
        string UpdateSkillSetInfo(ISkillSetModelView skillSetInfo);
    }
}
