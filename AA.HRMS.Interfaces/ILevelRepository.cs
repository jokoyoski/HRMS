using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ILevelRepository
    {
        /// <summary>
        /// Saves the level information.
        /// </summary>
        /// <param name="levelInfo">The level information.</param>
        /// <returns></returns>
        string SaveLevelInfo(ILevelView levelInfo);

        /// <summary>
        /// Updates the level information.
        /// </summary>
        /// <param name="levelInfo">The level information.</param>
        /// <returns></returns>
        string UpdateLevelInfo(ILevelView levelInfo);

        /// <summary>
        /// Deletes the level information.
        /// </summary>
        /// <param name="levelId">The level identifier.</param>
        /// <returns></returns>
        string DeleteLevelInfo(int levelId);

        /// <summary>
        /// Gets the level by identifier.
        /// </summary>
        /// <param name="levelId">The level identifier.</param>
        /// <returns></returns>
        ILevel GetLevelById(int levelId);

        /// <summary>
        /// Gets the level by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<ILevel> GetLevelByCompanyId(int companyId);

        /// <summary>
        /// Gets the level by name company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        ILevel GetLevelByNameCompanyId(int companyId, string name);

        /// <summary>
        /// Gets the level list by identifier.
        /// </summary>
        /// <param name="levelId">The level identifier.</param>
        /// <returns></returns>
        IList<ILevel> GetLevelListById(int levelId);

    }
}
