using Drivers.Entities;

namespace Drivers.DAL.Contracts
{
    public interface IEventRepository : IGenericRepository<Event>
    {
        Task<IEnumerable<Event>> GetTop5Events();
    }
}
