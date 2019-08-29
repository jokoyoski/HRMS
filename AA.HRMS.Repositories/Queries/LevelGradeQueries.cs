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
    internal static class LevelGradeQueries
    {
        
        internal static IPayScale getLevelGradeById(HRMSEntities db, int payscaleid)
        {
            var result = (from d in db.PayScales
                          where d.PayScaleId.Equals(payscaleid)
                          join e in db.Grades on d.GradeId equals e.GradeId
                          join f in db.Levels on d.LevelId equals f.LevelId
                          select new Models.PayScaleModel
                          {
                              PayScaleId = d.PayScaleId,
                              LevelName = f.LevelName,
                              GradeName = e.GradeName,
                              LevelId = d.LevelId,
                              GradeId = d.GradeId,
                              IsActive = d.IsActive,
                              CompanyId = d.CompanyId,
                              DateCreated = d.DateCreated,
                              BasePay = d.BasePay,
                          }).ToArray().Last();
            return result;
        }
        
        internal static IEnumerable<IPayScaleBenefit> getIPayScaleBenefitByPayScaleId(HRMSEntities db, int payscaleid)
        {
            var result = (from d in db.PayScaleBenefits
                          where d.PayScaleId.Equals(payscaleid) && d.IsActive.Equals(true)
                          join s in db.Benefits on d.BenefitId equals s.BenefitId
                          join v in db.AppraisalPeriods on s.Period equals v.AppraisalPeriodId
                          select new Models.PayScaleBenefitModel
                          {
                              PayScaleId = d.PayScaleId,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              IsMonetized = s.IsMonetized,
                              IsTaxable = s.IsTaxable,
                              BenefitName = s.BenefitName,
                              PercentageofBase = d.PercentageofBase,
                              CashValue = d.CashValue,
                              DateModified = d.DateModified,
                              Period = v.Appraisalperiod1
                          }).OrderBy(p=>p.DateModified);

            return result;
        }
       
        internal static IEnumerable<IPayScaleBenefit> getIPayScaleBenefitByBenefitId(HRMSEntities db, int benefitId)
        {
            var result = (from d in db.PayScaleBenefits
                          where d.BenefitId.Equals(benefitId)
                          join s in db.Benefits on d.BenefitId equals s.BenefitId
                          select new Models.PayScaleBenefitModel
                          {
                              PayScaleId = d.PayScaleId,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              BenefitName = s.BenefitName,
                              IsMonetized = s.IsMonetized,
                              IsTaxable = s.IsTaxable,
                              PercentageofBase = d.PercentageofBase,
                              CashValue = d.CashValue,
                              DateModified = d.DateModified
                          }).OrderBy(p => p.DateModified);

            return result;
        }
        
        internal static IPayScale getLevelGradeByLevelIdAndGradeId(HRMSEntities db, int companyId, int levelId, int gradeId)
        {
            var result = (from d in db.PayScales
                          where d.CompanyId.Equals(companyId) && d.LevelId.Equals(levelId) && d.GradeId.Equals(gradeId) && d.IsActive.Equals(true)
                          select new Models.PayScaleModel
                          {
                              PayScaleId = d.PayScaleId,
                              LevelId = d.LevelId,
                              GradeId = d.GradeId,
                              CompanyId = d.CompanyId,
                              IsActive = d.IsActive,
                              DateCreated = d.DateCreated,
                              BasePay = d.BasePay,
                              
                          }).FirstOrDefault();

            return result;
        }
        
        internal static IEnumerable<IPayScale> getLevelGradeByCompanyId(HRMSEntities db, int companyId)
        {
            var result = (from d in db.PayScales
                          where d.CompanyId.Equals(companyId) && d.IsActive.Equals(true)
                          join t in db.Companies on d.CompanyId equals t.CompanyId
                          join e in db.Grades on d.GradeId equals e.GradeId
                          join f in db.Levels on d.LevelId equals f.LevelId
                          select new Models.PayScaleModel
                          {
                              PayScaleId = d.PayScaleId,
                              LevelName = f.LevelName,
                              GradeName = e.GradeName,
                              LevelId = d.LevelId,
                              GradeId = d.GradeId,
                              IsActive = d.IsActive,
                              CompanyId = d.CompanyId,
                              DateCreated = d.DateCreated,
                              BasePay = d.BasePay,
                              CompanyName = t.CompanyName
                          }).OrderBy(p=>p.CompanyName);
            return result;
        }
        
    }
}
