namespace Drivers.DAL.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository _eventRepository { get; }

        void Commit();
        void Dispose();
    }
}
