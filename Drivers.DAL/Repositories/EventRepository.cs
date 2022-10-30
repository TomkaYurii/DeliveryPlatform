using Drivers.DAL.Contracts;
using Drivers.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Drivers.DAL.Repositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "Events")
        {

        }

        public Task<IEnumerable<Event>> GetTop5Events()
        {
            throw new NotImplementedException();
        }
    }
}
