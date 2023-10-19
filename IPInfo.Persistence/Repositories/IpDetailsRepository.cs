using IPInfo.Application.Contracts.Persistence;
using IPInfo.Domain.Entities.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPInfo.Persistence.Repositories
{
    public class IpDetailsRepository : IIpDetailsRepository
    {
        private readonly AppDbContext _db;
        //private readonly IMemoryCache _cache;

        public IpDetailsRepository(AppDbContext appDbContext)//
        {
            _db = appDbContext;
            //_cache = cache;
        }

        public async Task CommitChangesAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<Guid> CreateOneAsync(IpDetails entity)
        {
            var createdDetail = await _db.IpDetails.AddAsync(entity);
            if (createdDetail != null) {
                await CommitChangesAsync();
                return createdDetail.Entity.Id;
            }
            else {
                return Guid.Empty; 
            }
        }

        public async  Task<bool> DeleteOneAsync(Guid id)
        {

            if(await Exists(id))
            {
                var deletedRecordsCount = await _db.IpDetails.Where(x => x.Id == id).ExecuteDeleteAsync();
                if (deletedRecordsCount > 0)
                {
                    await CommitChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            
        }

        public async Task<bool> Exists(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<IpDetails>> GetAllAsync()
        {
            var results = await _db.IpDetails.ToListAsync();
            return results ?? Enumerable.Empty<IpDetails>();
        }

        public Task<IpDetails> GetByIdAsync(Guid id)
        {
            var detail = _db.IpDetails.FirstOrDefaultAsync(x=>x.Id == id);
            return detail;
        }

        public async Task<IEnumerable<IpDetails>> GetBySearchTermAsync(string searchTerm)
        {
            var results = await _db.IpDetails.Where(x => x.Ip.StartsWith(searchTerm)).ToListAsync();
            return results ?? Enumerable.Empty<IpDetails>();
        }

        public async Task<IpDetails> GetSingleBySearchTermAsync(string searchTerm)
        {
                var details = await _db.IpDetails.FirstOrDefaultAsync(x => x.Ip.Equals(searchTerm));
                return details;
        }
        public async Task<IpDetails> UpdateOneAsync(IpDetails entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await CommitChangesAsync();
            return entity;
        }

       
        public async Task UpdateManyAsync(IEnumerable<IpDetails> entities)
        {
            foreach (var entity in entities)
            {
                _db.Entry(entity).State = EntityState.Modified;
            }
            await CommitChangesAsync();
        }
        public Task<IEnumerable<Guid>> CreateManyAsync(IEnumerable<IpDetails> entities)
        {
            throw new NotImplementedException();
        }


        Task<bool> IRepository<IpDetails>.DeleteManyAsync(IEnumerable<Guid> id)
        {
            throw new NotImplementedException();
        }

        public async  Task<bool> Exists(string searchTerm)
        {
            var entity = await GetSingleBySearchTermAsync(searchTerm);
            if (entity != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
