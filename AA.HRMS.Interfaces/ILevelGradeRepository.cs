using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Interfaces
{
    public interface ILevelGradeRepository
    {
        /// <summary>
        /// Gets the level grade by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IPayScale GetLevelGradeById(int levelGradeId);

        /// <summary>
        /// Gets the i pay scale benefit by pay scale identifier.
        /// </summary>
        /// <param name="payscaleId">The payscale identifier.</param>
        /// <returns></returns>
        IList<IPayScaleBenefit> GetIPayScaleBenefitByPayScaleId(int payscaleId);

        /// <summary>
        /// Gets the i pay scale benefit by benefit identifier.
        /// </summary>
        /// <param name="benefitId">The benefit identifier.</param>
        /// <returns></returns>
        IList<IPayScaleBenefit> GetIPayScaleBenefitByBenefitId(int benefitId);

        /// <summary>
        /// Gets the level grade by level identifier and grade identifier.
        /// </summary>
        /// <param name="levelId">The level identifier.</param>
        /// <param name="gradeId">The grade identifier.</param>
        /// <returns></returns>
        IPayScale GetLevelGradeByLevelIdAndGradeId(int companyId, int levelId, int gradeId);

        /// <summary>
        /// Gets the level grade by company identifier.
        /// </summary>
        /// <param name="companyId">The company identifier.</param>
        /// <returns></returns>
        IList<IPayScale> GetLevelGradeByCompanyId(int companyId);

        /// <summary>
        /// Saves the level grade information.
        /// </summary>
        /// <param name="levelGradeInfo">The level grade information.</param>
        /// <returns></returns>
        string SaveLevelGradeInfo(IPayScale levelGradeInfo, out int payScaleId);

        /// <summary>
        /// Saves the level grade edit information.
        /// </summary>
        /// <param name="levelGradeInfo">The level grade information.</param>
        /// <returns></returns>
        string SaveLevelGradeEditInfo(IPayScale levelGradeInfo);

        /// <summary>
        /// Saves the level grade delete information.
        /// </summary>
        /// <param name="levelGradeInfo">The level grade information.</param>
        /// <returns></returns>
        string SaveLevelGradeDeleteInfo(int levelGradeId);

        /// <summary>
        /// Saves the pay scale benefit.
        /// </summary>
        /// <param name="payScaleBenefit">The pay scale benefit.</param>
        /// <returns></returns>
        string SavePayScaleBenefit(IPayScaleBenefit payScaleBenefit);
        /// <summary>
        /// Saves the pay scale benefit edit information.
        /// </summary>
        /// <param name="payScaleBenefit">The pay scale benefit.</param>
        /// <returns></returns>
        string SavePayScaleBenefitEditInfo(IPayScaleBenefit payScaleBenefit);
        /// <summary>
        /// Saves the pay scale benefit delete information.
        /// </summary>
        /// <param name="payScaleBenefitId">The pay scale benefit identifier.</param>
        /// <returns></returns>
        string SavePayScaleBenefitDeleteInfo(int payScaleBenefitId);
    }
}
