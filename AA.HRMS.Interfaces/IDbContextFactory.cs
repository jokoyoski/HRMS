using System.Data.Entity;

namespace AA.HRMS.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDbContextFactory
    {
        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <param name="contextType">Type of the context.</param>
        /// <returns></returns>
        DbContext GetDbContext(string contextType);
    }
}
