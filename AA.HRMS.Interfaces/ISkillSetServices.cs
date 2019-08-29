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
    public interface ISkillSetServices
    {
        /// <summary>
        /// Gets the skill set create view.
        /// </summary>
        /// <returns></returns>
        ISkillSetModelView GetSkillSetCreateView(int? employeeId, string url);

        /// <summary>
        /// Processes the skill set create view.
        /// </summary>
        /// <param name="skillSetInfo">The skill set information.</param>
        /// <returns></returns>
        string ProcessSkillSetCreateView(ISkillSetModelView skillSetInfo);

        /// <summary>
        /// Gets the skill set edit view.
        /// </summary>
        /// <param name="skillSetId">The skill set identifier.</param>
        /// <returns></returns>
        ISkillSetModelView GetSkillSetEditView(int skillSetId, string URL);

        /// <summary>
        /// Processes the skill set edit view.
        /// </summary>
        /// <param name="skillSetInfo">The skill set information.</param>
        /// <returns></returns>
        string ProcessSkillSetEditView(ISkillSetModelView skillSetInfo);

        /// <summary>
        /// Gets the skill set delete view.
        /// </summary>
        /// <param name="skillSetId">The skill set identifier.</param>
        /// <returns></returns>
        ISkillSetModelView GetSkillSetDeleteView(int skillSetId, string URL);

        /// <summary>
        /// Processes the skill set delete view.
        /// </summary>
        /// <param name="skillSetId">The skill set identifier.</param>
        /// <returns></returns>
        string ProcessSkillSetDeleteView(int skillSetId);


        /// <summary>
        /// Gets the skill set create view.
        /// </summary>
        /// <param name="skillSetInfo">The skill set information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ISkillSetModelView GetSkillSetCreateView(ISkillSetModelView skillSetInfo, string processingMessage);
    }
}
