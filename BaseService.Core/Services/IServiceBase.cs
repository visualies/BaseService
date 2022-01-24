using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseService.Core.Services
{
    public interface IServiceBase<TEntity, TKey> where TEntity : class
    {
        Task<TEntity> GetAsync(TKey key);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TKey key);
    }
}
