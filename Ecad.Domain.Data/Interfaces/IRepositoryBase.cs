using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ED.Domain.Data.Interfaces.Repositories.RepositoryBase
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity obj);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetById(Guid id);
        Task <IEnumerable<TEntity>> GetAllAsync();
        Task Remove(TEntity obj);
        Task RemoveRange(IEnumerable<TEntity> obj);

    }
}