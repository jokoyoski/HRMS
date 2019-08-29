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
    public interface IIndustryRepository
   {
        /// <summary>
        /// Gets the name of the industry by.
        /// </summary>
        /// <param name="industryName">Name of the industry.</param>
        /// <returns></returns>
        IIndustry GetIndustryByName(string industryName);

        /// <summary>
        /// Gets the industry by identifier.
        /// </summary>
        /// <param name="industryId">The industry identifier.</param>
        /// <returns></returns>
        IIndustry GetIndustryById(int industryId);


        /// <summary>
        /// Gets all industry.
        /// </summary>
        /// <returns></returns>
        IList<IIndustry> GetAllIndustry();


        /// <summary>
        /// Updates the industry information.
        /// </summary>
        /// <param name="IndustryInfo">The industry information.</param>
        /// <returns></returns>
        string UpdateIndustryInfo(IIndustryView IndustryInfo);


        /// <summary>
        /// Saves the industry information.
        /// </summary>
        /// <param name="industryInfo">The industry information.</param>
        /// <returns></returns>
        string SaveIndustryInfo(IIndustryView industryInfo);


        /// <summary>
        /// Deletes the industry information.
        /// </summary>
        /// <param name="industryId">The industry identifier.</param>
        /// <returns></returns>
        string DeleteIndustryInfo(int industryId);
    }
}
