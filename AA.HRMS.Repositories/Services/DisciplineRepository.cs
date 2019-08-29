using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Services
{

    
    public class DisciplineRepository : IDisciplineRepository
    {

        private readonly IDbContextFactory dbContextFactory;

        public DisciplineRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory; 
        }

        /// <summary>
        /// Gets the discipline by identifier.
        /// </summary>
        /// <param name="disciplineId">The discipline identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// disciplineId
        /// or
        /// GetDisciplineById {0}
        /// </exception>
        public IDiscipline GetDisciplineById(int disciplineId)
        {
            if (disciplineId <= 0) throw new ArgumentNullException(nameof(disciplineId));

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var result = DisciplineQueries.getDisciplineById(dbContext, disciplineId);

                    return result;
                }

            }
            catch (Exception e)
            {
                throw new ArgumentNullException("GetDisciplineById {0}", e);
            }
        }

        /// <summary>
        /// Saves the delete discipline information.
        /// </summary>
        /// <param name="disciplineId">The discipline identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">disciplineId</exception>
        public string SaveDeleteDisciplineInfo(int disciplineId)
        {
            if (disciplineId <= 0)
            {
                throw new ArgumentNullException(nameof(disciplineId));
            }

            string result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var modelView = dbContext.Disciplines.SingleOrDefault(p=>p.DisciplineId.Equals(disciplineId));
                    
                    modelView.IsActive = false;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Delete Discipline info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Saves the discipline information.
        /// </summary>
        /// <param name="disciplineView">The discipline view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">disciplineView</exception>
        public string SaveDisciplineInfo(IDisciplineView disciplineView)
        {
            if (disciplineView == null)
            {
                throw new ArgumentNullException(nameof(disciplineView));
            }

            var result = string.Empty;

            var newRecord = new Discipline
            {
                EmployeeId = disciplineView.EmployeeId,
                QueryDate = disciplineView.QueryDate,
                Offence = disciplineView.Offence,
                QueryInitiator = disciplineView.QueryInitiator,
                Investigator = disciplineView.Investigator,
                Response = disciplineView.Response,
                QueryStatusId = disciplineView.QueryStatusId,
                InvestigatorReport = disciplineView.InvestigatorReport,
                RecommendedSanction = disciplineView.RecommendedSanction,
                DisciplineCommitteeRecommendation = disciplineView.DisciplineCommitteeRecommendation,
                ActionTakenId = disciplineView.ActionTakenId,
                EvidenceDigitalFileId = disciplineView.EvidenceDigitalFileId,
                CompanyId = disciplineView.CompanyId,
                IsActive = true,
                DateCreated = DateTime.Now

            };

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.Disciplines.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Discipline info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Saves the edit discipline information.
        /// </summary>
        /// <param name="disciplineView">The discipline view.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">disciplineView</exception>
        public string SaveEditDisciplineInfo(IDisciplineView disciplineView)
        {
            if (disciplineView == null)
            {
                throw new ArgumentNullException(nameof(disciplineView));
            }

            string result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var modelInfo = dbContext.Disciplines.SingleOrDefault(p => p.DisciplineId == disciplineView.DisciplineId);

                    modelInfo.DisciplineId = disciplineView.DisciplineId;
                    modelInfo.ActionTakenId = disciplineView.ActionTakenId;
                    modelInfo.CompanyId = disciplineView.CompanyId;
                    modelInfo.IsActive = true;
                    modelInfo.DateCreated = disciplineView.DateCreated;
                    modelInfo.Response = disciplineView.Response;
                    modelInfo.Offence = disciplineView.Offence;
                    modelInfo.Investigator = disciplineView.Investigator;
                    modelInfo.EvidenceDigitalFileId = disciplineView.EvidenceDigitalFileId;
                    modelInfo.InvestigatorReport = disciplineView.InvestigatorReport;
                    modelInfo.QueryDate = disciplineView.QueryDate;
                    modelInfo.QueryStatusId = disciplineView.QueryStatusId;
                    modelInfo.EmployeeId = disciplineView.EmployeeId;
                    modelInfo.RecommendedSanction = disciplineView.RecommendedSanction;
                    modelInfo.DateCreated = disciplineView.DateCreated;
                    modelInfo.DisciplineCommitteeRecommendation = disciplineView.DisciplineCommitteeRecommendation;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Edit Discipline info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;

        }
    }
}
