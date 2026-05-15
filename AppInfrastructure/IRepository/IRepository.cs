using System;
using System.Collections.Generic;
using System.Text;

namespace AppInfrastructure.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task SaveAsync();
    }
}
