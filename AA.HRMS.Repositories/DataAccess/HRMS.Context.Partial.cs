using System;
using System.Data.Common;
using System.Data.Entity;

namespace AA.HRMS.Repositories.DataAccess
{
    public partial class HRMSEntities
    {
       
        public HRMSEntities(DbConnection dbConnection, bool contextOwnsConnection)
            : base(dbConnection, contextOwnsConnection)
        {

        }

       
    }
}
