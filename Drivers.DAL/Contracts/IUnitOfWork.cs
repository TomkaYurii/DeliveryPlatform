namespace Drivers.DAL.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IDriverRepository _driverRepository { get; }
        IDriverLicenseRepository _driverLicenseRepository { get; }
        ICarRepository _carRepository { get; }

        void Commit();
        void Dispose();
    }
}
