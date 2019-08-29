using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface IDisciplineRepository
    {
        /// <summary>
        /// Gets the discipline by identifier.
        /// </summary>
        /// <param name="disciplineId">The discipline identifier.</param>
        /// <returns></returns>
        IDiscipline GetDisciplineById(int disciplineId);
        /// <summary>
        /// Saves the edit discipline information.
        /// </summary>
        /// <param name="disciplineView">The discipline view.</param>
        /// <returns></returns>
        string SaveEditDisciplineInfo(IDisciplineView disciplineView);
        /// <summary>
        /// Saves the discipline information.
        /// </summary>
        /// <param name="disciplineView">The discipline view.</param>
        /// <returns></returns>
        string SaveDisciplineInfo(IDisciplineView disciplineView);
        /// <summary>
        /// Saves the delete discipline information.
        /// </summary>
        /// <param name="disciplineId">The discipline identifier.</param>
        /// <returns></returns>
        string SaveDeleteDisciplineInfo(int disciplineId);
    }
}
