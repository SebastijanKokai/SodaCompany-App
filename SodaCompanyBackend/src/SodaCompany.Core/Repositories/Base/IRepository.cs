using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SodaCompany.Core.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> GetNumberOfRecord();
        Task<IReadOnlyList<T>> GetEntitiesPaged(int recordsPerPage, int pageNumber);
    }
}
