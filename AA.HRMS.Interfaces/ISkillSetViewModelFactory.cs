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
    public interface ISkillSetViewModelFactory
    {
        /// <summary>
        /// Creates the skill set view.
        /// </summary>
        /// <param name="experienceCollection">The experience collection.</param>
        /// <returns></returns>
        ISkillSetModelView CreateSkillSetView(int? employeeId, string url, IList<IExperience> experienceCollection);


        /// <summary>
        /// Creates the updated skill set view.
        /// </summary>
        /// <param name="skillSetInfo">The skill set information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ISkillSetModelView CreateUpdatedSkillSetView(ISkillSetModelView skillSetInfo, string processingMessage);

        /// <summary>
        /// Edits the skill set view.
        /// </summary>
        /// <param name="skillSetInfo">The skill set information.</param>
        /// <param name="experienceCollection">The experience collection.</param>
        /// <returns></returns>
        ISkillSetModelView EditSkillSetView(ISkillSetModel skillSetInfo, string URL, IList<IExperience> experienceCollection);

        /// <summary>
        /// Edits the updated skill set view.
        /// </summary>
        /// <param name="skillSetInfo">The skill set information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        ISkillSetModelView EditUpdatedSkillSetView(ISkillSetModelView skillSetInfo, string processingMessage);

        /// <summary>
        /// Deletes the skill set view.
        /// </summary>
        /// <param name="skillSetInfo">The skill set information.</param>
        /// <returns></returns>
        ISkillSetModelView DeleteSkillSetView(ISkillSetModel skillSetInfo, string URL);


    }
}
