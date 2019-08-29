using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Queries
{
    internal static class TypeOfExitQueries
    {
        /// <summary>
        /// Gets all my type of exit.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        internal static IEnumerable<ITypeOfExit> GetAllMyTypeOfExit(HRMSEntities db, int companyId)
        {
            var result = (from d in db.TypeOfExits
                          where d.CompanyId == companyId
                          join e in db.Companies on d.CompanyId equals e.CompanyId
                          select new TypeOfExitModel
                          {
                              TypeOfExitId = d.TypeOFExitId,
                              TypeOfExitName = d.TypeOFExitName,
                              CompanyId = d.CompanyId,
                              IsActive = d.IsActive,

                          }).OrderBy(p => p.CompanyId);

            return result;
        }


        /// <summary>
        /// Gets the type of exit by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="typeOfExitId">The type of exit identifier.</param>
        /// <returns></returns>
        internal static ITypeOfExit GetTypeOfExitById(HRMSEntities db, int typeOfExitId)
        {
            var result = (from d in db.TypeOfExits
                          join e in db.Companies on d.CompanyId equals e.CompanyId
                          join pdept in db.TypeOfExits on d.TypeOFExitId equals pdept.TypeOFExitId
                          where d.TypeOFExitId == typeOfExitId
                          select new TypeOfExitModel
                          {

                              TypeOfExitId = d.TypeOFExitId,
                              IsActive = d.IsActive,
                              TypeOfExitName = d.TypeOFExitName,
                              CompanyId = d.CompanyId,

                          }).FirstOrDefault();

            return result;
        }
        /// <summary>
        /// Gets the type of exit by company.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="companyId">The company identifier.</param>
        /// <param name="typeOfExitName">Name of the type of exit.</param>
        /// <returns></returns>
        internal static ITypeOfExit getTypeOfExitByCompany(HRMSEntities db, int companyId, string typeOfExitName)
        {
            var result = (from d in db.TypeOfExits
                          join e in db.Companies on d.CompanyId equals e.CompanyId
                          join pdept in db.TypeOfExits on d.TypeOFExitId equals pdept.TypeOFExitId
                          where d.TypeOFExitName == typeOfExitName
                          where d.CompanyId == companyId
                          select new TypeOfExitModel
                          {

                              TypeOfExitId = d.TypeOFExitId,
                              IsActive = d.IsActive,
                              TypeOfExitName = d.TypeOFExitName,
                              CompanyId = e.CompanyId,

                          }).FirstOrDefault();

            return result;
        }
        /// <summary>
        /// Gets the name of the type of exit by.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="typeOfExitName">Name of the type of exit.</param>
        /// <returns></returns>
        internal static ITypeOfExit getTypeOfExitByName(HRMSEntities db, string typeOfExitName)
        {
            var result = (from d in db.TypeOfExits
                          join e in db.Companies on d.CompanyId equals e.CompanyId
                          join pdept in db.TypeOfExits on d.TypeOFExitId equals pdept.TypeOFExitId
                          where d.TypeOFExitName == typeOfExitName
                          select new TypeOfExitModel
                          {

                              TypeOfExitId = d.TypeOFExitId,
                              IsActive = d.IsActive,
                              TypeOfExitName = d.TypeOFExitName,
                              CompanyId = d.CompanyId,

                          }).FirstOrDefault();

            return result;
        }
    }
}
