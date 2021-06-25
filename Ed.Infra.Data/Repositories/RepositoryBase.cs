using ED.Domain.Data.Interfaces.Repositories.RepositoryBase;
using ED.Infra.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ed.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {

        private readonly ApplicationDbContext _contex;
        public RepositoryBase(ApplicationDbContext contex)
           => _contex = contex;    

        public async Task <TEntity> AddAsync(TEntity obj)
        {
          await _contex.AddAsync(obj);
          await _contex.SaveChangesAsync();
          return  obj;
        }

        public List<TEntity> AddRange(List<TEntity> obj)
        {
            _contex.AddRange(obj);
            _contex.SaveChanges();
            return obj;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _contex.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetByIdAsync(int id)
             => await _contex.Set<TEntity>().FindAsync(id);

        public async Task<TEntity> GetById(Guid id)
            => await _contex.Set<TEntity>().FindAsync(id);

        public async Task Remove(TEntity obj)
        {
            _contex.Remove(obj);
            await _contex.SaveChangesAsync();
        }

        public async Task RemoveRange(IEnumerable<TEntity> obj)
        {
            _contex.RemoveRange(obj);
            await _contex.SaveChangesAsync();
        }
       
        public virtual Task UpdateAsync(TEntity obj)
        {
            _contex.Set<TEntity>().Attach(obj);
            _contex.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public virtual Task UpdateCollectionAsync(IEnumerable<TEntity> entities)
        {
            _contex.UpdateRange(entities);
            return Task.CompletedTask;
        }

        public virtual async Task AddCollectionAsync(IEnumerable<TEntity> entities)
        {
            await _contex.AddRangeAsync(entities).ConfigureAwait(false);
        }

        public async Task UpdateRange(List<TEntity> list)
        {
            try
            {
                _contex.Set<TEntity>().AttachRange(list);
                await _contex.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }
    }
}