using IPInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPInfo.Application.Contracts.Persistence
{
    public interface IRepository<T> where T : IRepositoryEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetBySearchTermAsync(string searchTerm);
        Task<T> GetSingleBySearchTermAsync(string searchTerm);
        Task<T> GetByIdAsync(Guid id);
        Task<Guid> CreateOneAsync(T entity);
        Task<IEnumerable<Guid>> CreateManyAsync(IEnumerable<T> entities);
        Task<T> UpdateOneAsync(T entity);
        Task UpdateManyAsync(IEnumerable<T> entity);
        Task<bool> DeleteOneAsync(Guid id);
        Task<bool> DeleteManyAsync(IEnumerable<Guid> id);
        Task<bool> Exists(Guid id);
        Task<bool> Exists(string searchTerm);
        Task CommitChangesAsync();
       
    }
}
