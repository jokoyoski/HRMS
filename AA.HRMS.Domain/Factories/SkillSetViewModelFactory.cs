using AA.HRMS.Domain.Models;
using AA.HRMS.Domain.Utilities;
using AA.HRMS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Domain.Factories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AA.HRMS.Interfaces.ISkillSetViewModelFactory" />
    public class SkillSetViewModelFactory : ISkillSetViewModelFactory
    {
        /// <summary>
        /// Creates the skill set view.
        /// </summary>
        /// <param name="experienceCollection"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">experienceCollection</exception>
        public ISkillSetModelView CreateSkillSetView(int? empployeeId, string url, IList<IExperience> experienceCollection)
        {
            if(experienceCollection == null)
            {
                throw new ArgumentNullException(nameof(experienceCollection));
            }

            var experienceDDL = GetDropDownList.ExperienceListItem(experienceCollection, -1);

            var viewModel = new SkillSetModelView
            {
                EmployeeId = empployeeId ?? 0,
                URL = url,
                ExperienceDropDown = experienceDDL,
                ProcessingMessage = string.Empty
            };

            return viewModel;
        }




        /// <summary>
        /// Creates the updated skill set view.
        /// </summary>
        /// <param name="skillSetInfo">The skill set information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">skillSetInfo</exception>
        public ISkillSetModelView CreateUpdatedSkillSetView(ISkillSetModelView skillSetInfo, string processingMessage)
        {
            if (skillSetInfo == null)
                throw new ArgumentNullException(nameof(skillSetInfo));

            skillSetInfo.ProcessingMessage = processingMessage;

            return skillSetInfo;
        }
        /// <summary>
        /// Edits the skill set view.
        /// </summary>
        /// <param name="skillSetInfo">The skill set information.</param>
        /// <param name="experienceCollection"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">skillSetInfo</exception>
        public ISkillSetModelView EditSkillSetView(ISkillSetModel skillSetInfo, string URL, IList<IExperience> experienceCollection)
        {
            if (skillSetInfo == null)
                throw new ArgumentNullException(nameof(skillSetInfo));

            var experienceDDL = GetDropDownList.ExperienceListItem(experienceCollection, skillSetInfo.Experience ?? -1);

            var skillSetView = new SkillSetModelView
            {
                SkillId = skillSetInfo.SkillId,
                SkillName = skillSetInfo.SkillName,
                SkillDescription = skillSetInfo.SkillDescription,
                EmployeeId = skillSetInfo.EmployeeId,
                IsActive = skillSetInfo.IsActive,
                DateCreated = skillSetInfo.DateCreated,
                Experience = skillSetInfo.Experience,
                ExperienceDropDown = experienceDDL,
                URL = URL,
            };

            return skillSetView;
        }

        /// <summary>
        /// Edits the updated skill set view.
        /// </summary>
        /// <param name="skillSetInfo">The skill set information.</param>
        /// <param name="processingMessage">The processing message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">skillSetInfo</exception>
        public ISkillSetModelView EditUpdatedSkillSetView(ISkillSetModelView skillSetInfo, string processingMessage)
        {
            if (skillSetInfo == null)
                throw new ArgumentNullException(nameof(skillSetInfo));

            skillSetInfo.ProcessingMessage = processingMessage;

            return skillSetInfo;
        }

        /// <summary>
        /// Deletes the skill set view.
        /// </summary>
        /// <param name="skillSetInfo">The skill set information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">skillSetInfo</exception>
        public ISkillSetModelView DeleteSkillSetView(ISkillSetModel skillSetInfo, string URL)
        {
            if (skillSetInfo == null)
                throw new ArgumentNullException(nameof(skillSetInfo));

            var skillSetView = new SkillSetModelView
            {
                SkillId = skillSetInfo.SkillId,
                SkillName = skillSetInfo.SkillName,
                SkillDescription = skillSetInfo.SkillDescription,
                EmployeeId = skillSetInfo.EmployeeId,
                IsActive = skillSetInfo.IsActive,
                DateCreated = skillSetInfo.DateCreated,
                URL = URL
            };

            return skillSetView;
        }
    }
}
