using Drivers.DAL.Contracts;
using System.Data;

namespace MyEventsAdoNetDB.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IDriverRepository _driverRepository { get; }
        public IDriverLicenseRepository _driverLicenseRepository { get; }
        public ICarRepository _carRepository { get; }

        readonly IDbTransaction _dbTransaction;

        public UnitOfWork(
            IDriverRepository driverRepository,
            IDriverLicenseRepository driverLicenseRepository,
            ICarRepository carRepository,
            IDbTransaction dbTransaction)
        {
            _driverRepository = driverRepository;
            _driverLicenseRepository = driverLicenseRepository;
            _carRepository = carRepository;
            _dbTransaction = dbTransaction;
        }

        public void Commit()
        {
            try
            {
                _dbTransaction.Commit();
                // By adding this we can have muliple transactions as part of a single request
                //_dbTransaction.Connection.BeginTransaction();
            }
            catch (Exception ex)
            {
                _dbTransaction.Rollback();
                Console.WriteLine(ex.Message);
            }
        }

        public void Dispose()
        {
            //Close the SQL Connection and dispose the objects
            _dbTransaction.Connection?.Close();
            _dbTransaction.Connection?.Dispose();
            _dbTransaction.Dispose();
        }
    }
}
