using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using AA.HRMS.Repositories.DataAccess;
using AA.HRMS.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Repositories.Services
{
    
    public class TypeOfExitRepository: ITypeOfExitRepository
    {
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeOfExitRepository" /> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public TypeOfExitRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        /// <summary>
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetAllMyTypeOfExit</exception>
        
        public IList<ITypeOfExit> GetAllMyTypeOfExit(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = TypeOfExitQueries.GetAllMyTypeOfExit(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetAllMyTypeOfExit", e);
            }
        }
        /// <summary>
        /// Gets the company by identifier.
        /// </summary>
        /// <param name="CompanyId">The company identifier.</param>
        /// <param name="typeOfExitName">Name of the type of exit.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository Get TypeOfExit by Company</exception>
        
        public ITypeOfExit GetCompanyById(int CompanyId, string typeOfExitName)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord = TypeOfExitQueries.getTypeOfExitByCompany(dbContext, CompanyId, typeOfExitName);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository Get TypeOfExit by Company", e);
            }

        }
        /// <summary>
        /// Gets the type of exit by identifier.
        /// </summary>
        /// <param name="typeOfExitId">The type of exit identifier.</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository get TypeOfExitById</exception>
        
        public ITypeOfExit GetTypeOfExitByID(int typeOfExitId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord =
                        TypeOfExitQueries.GetTypeOfExitById(dbContext, typeOfExitId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository get TypeOfExitById", e);
            }
        }
        /// <summary>
        /// </summary>
        /// <param name="typeOfExitByName"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Repository GetTypeOfExitByName</exception>
        
        public ITypeOfExit GetTypeOfExitByName(string typeOfExitByName)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var aRecord =
                        TypeOfExitQueries.getTypeOfExitByName(dbContext, typeOfExitByName);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetTypeOfExitByName", e);
            }
        }
        /// <summary>
        /// </summary>
        /// <param name="typeOfExitInfo"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">typeOfExitInfo</exception>
        public string SaveTypeOfExitInfo(ITypeOfExitView typeOfExitInfo)
        {
            if (typeOfExitInfo == null) throw new ArgumentNullException(nameof(typeOfExitInfo));

            var result = string.Empty;
            var newTypeOfExit = new TypeOfExit
            {
                CompanyId = typeOfExitInfo.CompanyId,
                TypeOFExitId = typeOfExitInfo.TypeOfExitId,
                TypeOFExitName = typeOfExitInfo.TypeOfExitName,
                IsActive = true,
            };
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.TypeOfExits.Add(newTypeOfExit);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveRegistrationInfo - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            var typeOfExitID = newTypeOfExit.TypeOFExitId;
            return result;
        }
        /// <summary>
        /// Saves the edit type of exit information.
        /// </summary>
        /// <param name="typeOfExitInfo">The type of exit information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">typeOfExitInfo</exception>
        public string SaveEditTypeOfExitInfo(ITypeOfExitView typeOfExitInfo)
        {
            if (typeOfExitInfo == null)
            {
                throw new ArgumentNullException(nameof(typeOfExitInfo));
            }

            string result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var modelInfo = dbContext.TypeOfExits.SingleOrDefault(p => p.TypeOFExitId == typeOfExitInfo.TypeOfExitId);
                    
                    modelInfo.TypeOFExitName = typeOfExitInfo.TypeOfExitName;

                    dbContext.SaveChanges();
                }
            }
            catch(Exception e)
            {
                result = string.Format("Save Edit TypeOfExit Info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        /// <summary>
        /// Saves the delete type of exit information.
        /// </summary>
        /// <param name="TypeOfExitId">The type of exit identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">TypeOfExitId</exception>
        public string SaveDeleteTypeOfExitInfo(int TypeOfExitId)
        {
            if (TypeOfExitId <= 0)
            {
                throw new ArgumentNullException(nameof(TypeOfExitId));
            }

            string result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var modelView = dbContext.TypeOfExits.Find(TypeOfExitId);

                    modelView.IsActive = false;

                    dbContext.SaveChanges();

                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Edit TypeOfExit info - {0}, {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }
    }
}
