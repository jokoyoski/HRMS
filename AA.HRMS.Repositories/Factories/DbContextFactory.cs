using System;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity;
using AA.Infrastructure.Interfaces;
using Environment = AA.Infrastructure.Utility.Environment;
using AA.HRMS.Interfaces;
using AA.HRMS.Interfaces.ValueTypes;
using System.Data.Common;
using AA.HRMS.Repositories.DataAccess;

namespace AA.HRMS.Repositories.Factories
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly IEnvironment environment;

        public DbContextFactory(IEnvironment environment)
        {
            this.environment = environment ?? new Environment();
        }

        public DbContext GetDbContext(string contextType)
        {
            if (string.IsNullOrEmpty(contextType))
            {
                throw new ArgumentNullException("contextType");
            }

            DbContext dbContext = null;
            
            var userId = this.environment[EnvironmentValues.AAHrmsUId];
            var password = this.environment[EnvironmentValues.AAHrmsPwd];
            var server = this.environment[EnvironmentValues.AAHrmsSvr];

            if (string.IsNullOrEmpty(server))
            {
                throw new ApplicationException(string.Format("Server not specified in Environment file for database{0}",
                    contextType));
            }
            if (string.IsNullOrEmpty(userId))
            {
                throw new ApplicationException(string.Format("UserId not specified in Environment file for database{0}",
                    contextType));
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ApplicationException(string.Format("Password not specified in Environment file for database{0}",
                    contextType));
            }

            string connString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", server,
                contextType, userId, password);

            var docSearchEntities = new EntityConnectionStringBuilder
            {
                Metadata = @"res://*/DataAccess.HRMS.csdl|res://*/DataAccess.HRMS.ssdl|res://*/DataAccess.HRMS.msl",
                ProviderConnectionString = connString,
                Provider = "System.Data.SqlClient"
            };

            DbConnection dbConnection = new EntityConnection(docSearchEntities.ConnectionString);
            dbContext = new HRMSEntities(dbConnection, true);


            return dbContext;
        }


    }
}
