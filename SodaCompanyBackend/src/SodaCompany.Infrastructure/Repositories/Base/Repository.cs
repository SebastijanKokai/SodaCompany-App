using Microsoft.EntityFrameworkCore;
using SodaCompany.Core.Repositories.Base;
using SodaCompany.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SodaCompany.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SodaCompanyContext _sodaCompanyContext;

        public Repository(SodaCompanyContext sodaCompanyContext)
        {
            _sodaCompanyContext = sodaCompanyContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _sodaCompanyContext.Set<T>().AddAsync(entity);
            await _sodaCompanyContext.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            _sodaCompanyContext.Set<T>().Remove(entity);
            await _sodaCompanyContext.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _sodaCompanyContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _sodaCompanyContext.Set<T>().FindAsync(id);
        }

        public async Task<int> GetNumberOfRecord()
        {
            return await _sodaCompanyContext.Set<T>().CountAsync();
        }

        public async Task<IReadOnlyList<T>> GetEntitiesPaged(int recordsPerPage, int pageNumber)
        {
            return await _sodaCompanyContext.Set<T>().Skip(recordsPerPage * (pageNumber - 1)).Take(recordsPerPage).ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await _sodaCompanyContext.SaveChangesAsync();
        }
    }
}
