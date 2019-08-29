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
    public class LevelGradeRepository : ILevelGradeRepository
    {
        /// <summary>
        /// The database context factory
        /// </summary>
        private readonly IDbContextFactory dbContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="LevelGradeRepository"/> class.
        /// </summary>
        /// <param name="dbContextFactory">The database context factory.</param>
        public LevelGradeRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Gets the level grade by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get LevelGrade by CompanyId</exception>
        public IPayScale GetLevelGradeById(int levelGradeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LevelGradeQueries.getLevelGradeById(dbContext, levelGradeId);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get LevelGrade by CompanyId", e);
            }
        }
        /// <summary>
        /// Gets the i pay scale benefit by pay scale identifier.
        /// </summary>
        /// <param name="payscaleId">The payscale identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get LevelGrade by CompanyId</exception>
        public IList<IPayScaleBenefit> GetIPayScaleBenefitByPayScaleId(int payscaleId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LevelGradeQueries.getIPayScaleBenefitByPayScaleId(dbContext, payscaleId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get LevelGrade by CompanyId", e);
            }
        }

        /// <summary>
        /// Gets the i pay scale benefit by benefit identifier.
        /// </summary>
        /// <param name="benefitId">The benefit identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get LevelGrade by CompanyId</exception>
        public IList<IPayScaleBenefit> GetIPayScaleBenefitByBenefitId(int benefitId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LevelGradeQueries.getIPayScaleBenefitByBenefitId(dbContext, benefitId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get LevelGrade by CompanyId", e);
            }
        }

        /// <summary>
        /// Gets the level grade by level identifier and grade identifier.
        /// </summary>
        /// <param name="levelId">The level identifier.</param>
        /// <param name="gradeId">The grade identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get LevelGrade by CompanyId</exception>
        public IPayScale GetLevelGradeByLevelIdAndGradeId(int companyId, int levelId, int gradeId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LevelGradeQueries.getLevelGradeByLevelIdAndGradeId(dbContext, companyId, levelId, gradeId);

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get LevelGrade by CompanyId", e);
            }
        }

        /// <summary>
        /// Gets the level grade by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Get Level Grade B yCompanyId {0}</exception>
        public IList<IPayScale> GetLevelGradeByCompanyId(int companyId)
        {
            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var list = LevelGradeQueries.getLevelGradeByCompanyId(dbContext, companyId).ToList();

                    return list;
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("Get Level Grade B yCompanyId {0}", e);
            }
        }
        /// <summary>
        /// Saves the level grade information.
        /// </summary>
        /// <param name="levelGradeInfo">The level grade information.</param>
        /// <param name="payScaleId">The pay scale identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">levelGradeInfo</exception>
        public string SaveLevelGradeInfo(IPayScale levelGradeInfo, out int payScaleId)
        {

            if (levelGradeInfo == null) throw new ArgumentNullException(nameof(levelGradeInfo));

            var result = string.Empty;

            var newRecord = new PayScale
            {
                PayScaleId = levelGradeInfo.PayScaleId,
                LevelId = levelGradeInfo.LevelId,
                GradeId = levelGradeInfo.GradeId,
                CompanyId = levelGradeInfo.CompanyId,
                BasePay = levelGradeInfo.BasePay,
                DateCreated = DateTime.UtcNow,
                IsActive = true,
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.PayScales.Add(newRecord);
                    dbContext.SaveChanges();
                    
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Level Grade Info - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            payScaleId = newRecord.PayScaleId;

            return result;
        }

        /// <summary>
        /// Saves the level grade edit information.
        /// </summary>
        /// <param name="levelGradeInfo">The level grade information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">levelGradeInfo</exception>
        public string SaveLevelGradeEditInfo(IPayScale levelGradeInfo)
        {

            if (levelGradeInfo == null) throw new ArgumentNullException(nameof(levelGradeInfo));

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities) this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var levelGradeModel = dbContext.PayScales.SingleOrDefault(p => p.PayScaleId.Equals(levelGradeInfo.PayScaleId));
                    
                    levelGradeModel.LevelId = levelGradeInfo.LevelId;
                    levelGradeModel.GradeId = levelGradeInfo.GradeId;
                    levelGradeModel.DateModified = DateTime.UtcNow; ;
                    levelGradeModel.BasePay = levelGradeInfo.BasePay;

                    dbContext.SaveChanges();

                }
            }
            catch(Exception e)
            {
                result = string.Format("Save Level Grade Edit Info - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }
            return result;

        }

        /// <summary>
        /// Saves the level grade delete information.
        /// </summary>
        /// <param name="levelGradeInfo">The level grade information.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">levelGradeInfo</exception>
        public string SaveLevelGradeDeleteInfo(int levelGradeId)
        {

            if (levelGradeId <= 0) throw new ArgumentNullException(nameof(levelGradeId));

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var levelGradeModel = dbContext.PayScales.SingleOrDefault(p => p.PayScaleId.Equals(levelGradeId));
                    
                    levelGradeModel.IsActive = false;

                    dbContext.SaveChanges();

                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Level Grade Edit Info - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }
            return result;

        }
        
        /// <summary>
        /// Saves the pay scale benefit.
        /// </summary>
        /// <param name="payScaleBenefit">The pay scale benefit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">payScaleBenefit</exception>
        public string SavePayScaleBenefit(IPayScaleBenefit payScaleBenefit)
        {

            if (payScaleBenefit == null) throw new ArgumentNullException(nameof(payScaleBenefit));

            var result = string.Empty;

            var newRecord = new PayScaleBenefit
            {
                PayScaleId = payScaleBenefit.PayScaleId,
                BenefitId = payScaleBenefit.BenefitId,
                PercentageofBase = payScaleBenefit.PercentageofBase,
                CashValue = payScaleBenefit.CashValue,
                DateCreated = DateTime.UtcNow,
                IsActive = true,
            };

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    dbContext.PayScaleBenefits.Add(newRecord);
                    dbContext.SaveChanges();

                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Pay Scale Benefit - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }
            

            return result;
        }

        /// <summary>
        /// Saves the pay scale benefit edit information.
        /// </summary>
        /// <param name="payScaleBenefit">The pay scale benefit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">payScaleBenefit</exception>
        public string SavePayScaleBenefitEditInfo(IPayScaleBenefit payScaleBenefit)
        {

            if (payScaleBenefit == null) throw new ArgumentNullException(nameof(payScaleBenefit));

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var levelGradeModel = dbContext.PayScaleBenefits.SingleOrDefault(p => p.PayScaleId.Equals(payScaleBenefit.PayScaleId));
                    
                    levelGradeModel.BenefitId = payScaleBenefit.BenefitId;
                    levelGradeModel.CashValue = payScaleBenefit.CashValue;
                    levelGradeModel.PercentageofBase = payScaleBenefit.PercentageofBase;
                    levelGradeModel.DateModified = DateTime.UtcNow;

                    dbContext.SaveChanges();

                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Pay Scale Benefit Edit Info - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }
            return result;
        }
        /// <summary>
        /// Saves the pay scale benefit delete information.
        /// </summary>
        /// <param name="payScaleBenefitId">The pay scale benefit identifier.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">payScaleBenefitId</exception>
        public string SavePayScaleBenefitDeleteInfo(int payScaleBenefitId)
        {

            if (payScaleBenefitId <= 0) throw new ArgumentNullException(nameof(payScaleBenefitId));

            var result = string.Empty;

            try
            {
                using (
                    var dbContext = (HRMSEntities)this.dbContextFactory.GetDbContext(ObjectContextType.HRMS))
                {
                    var levelGradeModel = dbContext.PayScaleBenefits.SingleOrDefault(p => p.PayScaleId.Equals(payScaleBenefitId));

                    levelGradeModel.IsActive = false;
                    levelGradeModel.DateModified = DateTime.UtcNow;

                    dbContext.SaveChanges();

                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Pay Scale Benefit Edit Info - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }
            return result;
        }
    }
}
