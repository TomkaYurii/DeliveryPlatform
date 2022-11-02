﻿using Drivers.DAL.Entities;

namespace Drivers.DAL.Contracts
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task DeleteAsync(int id);
        Task<T> GetAsync(int id);
        Task<int> AddRangeAsync(IEnumerable<T> list);
        Task ReplaceAsync(T t);
        Task<int> AddAsync(T t);
        Task<IEnumerable<Driver>> GetAllDrivers();
    }
}
