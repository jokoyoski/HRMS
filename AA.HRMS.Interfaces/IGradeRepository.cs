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
    public interface IGradeRepository
    {
        /// <summary>
        /// Gets the name of the grade by.
        /// </summary>
        /// <param name="grade">The grade.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IGrade GetGradeByName(string grade, int companyId);

        /// <summary>
        /// Deletes the grade information.
        /// </summary>
        /// <param name="gradeId">The grade identifier.</param>
        /// <returns></returns>
        string DeleteGradeInfo(int gradeId);
        
        /// <summary>
        /// Saves the grade information.
        /// </summary>
        /// <param name="gradeInfo">The grade information.</param>
        /// <returns></returns>
        string SaveGradeInfo(IGradeView gradeInfo);
        
        /// <summary>
        /// Gets the grade by identifier.
        /// </summary>
        /// <param name="gradeId">The grade identifier.</param>
        /// <returns></returns>
        IGrade GetGradeById(int gradeId);
        
        /// <summary>
        /// Updates the grade information.
        /// </summary>
        /// <param name="gradeInfo">The grade information.</param>
        /// <returns></returns>
        string UpdateGradeInfo(IGradeView gradeInfo);

        /// <summary>
        /// Gets the grade by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IGrade> GetGradeByCompanyId(int companyId);

        /// <summary>
        /// Gets the grade list by identifier.
        /// </summary>
        /// <param name="gradeId">The grade identifier.</param>
        /// <returns></returns>
        IList<IGrade> GetGradeListById(int gradeId);
    }
}