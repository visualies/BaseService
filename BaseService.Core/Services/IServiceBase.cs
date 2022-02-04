using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseService.Core.Services
{
    public interface IServiceBase<TEntity, TParams, TKey> where TEntity : class
    {
        Task<IEnumerable<TEntity>> FindAsync(TParams @params);
        Task<TEntity> GetAsync(TKey key);
        Task CreateAsync(TParams @params);
        Task UpdateAsync(TKey key, TParams @params);
        Task DeleteAsync(TKey key);
    }
}
