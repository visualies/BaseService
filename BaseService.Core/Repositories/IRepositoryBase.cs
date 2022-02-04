using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaseService.Core.Repositories
{
    public interface IRepositoryBase<TEntity, TParams, TKey> where TEntity : class
    {
        Task<IEnumerable<TEntity>> FindAsync(TParams @params);
        Task<TEntity> GetAsync(TKey key);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TKey key);
        void EnsureCreated();
    }
}
