using Drivers.DAL.Contracts;
using Drivers.DAL.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.DAL.Repositories
{
    public class DriverLicenseRepository : GenericRepository<DriverLicense>, IDriverLicenseRepository
    {
        public DriverLicenseRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "DriverLicense")
        {

        }
    }
}
