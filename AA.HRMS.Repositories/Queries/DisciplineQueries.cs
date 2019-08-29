using AA.HRMS.Interfaces;
using AA.HRMS.Repositories.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Queries
{
    /// <summary>
    /// 
    /// </summary>
    internal static class DisciplineQueries
    {
        /// <summary>
        /// Gets the discipline by identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="disciplineId">The discipline identifier.</param>
        /// <returns></returns>
        internal static IDiscipline getDisciplineById(HRMSEntities db, int disciplineId)
        {
            var result = (from a in db.Disciplines
                          where a.DisciplineId.Equals(disciplineId)
                          select new Models.DisciplineModel
                          {
                              DisciplineId = a.DisciplineId,
                              EmployeeId = a.EmployeeId,
                              QueryDate = a.QueryDate,
                              Offence = a.Offence,
                              QueryInitiator = a.QueryInitiator,
                              Investigator = a.Investigator,
                              Response = a.Response,
                              QueryStatusId = a.QueryStatusId,
                              InvestigatorReport = a.InvestigatorReport,
                              RecommendedSanction = a.RecommendedSanction,
                              DisciplineCommitteeRecommendation = a.DisciplineCommitteeRecommendation,
                              ActionTakenId = a.ActionTakenId,
                              EvidenceDigitalFileId = a.EvidenceDigitalFileId,
                              DateCreated = a.DateCreated,
                              CompanyId = a.CompanyId,
                              IsActive = a.IsActive
                          }).FirstOrDefault();

            return result;
        }
    }
}
